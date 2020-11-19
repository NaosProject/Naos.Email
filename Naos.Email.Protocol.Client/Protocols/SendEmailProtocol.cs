// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Protocol.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using MailKit.Security;

    using MimeKit;

    using Naos.Email.Domain;
    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Executes a <see cref="SendEmailProtocol"/>.
    /// </summary>
    public class SendEmailProtocol : AsyncSpecificReturningProtocolBase<SendEmailOp, EmailResponse>
    {
        private readonly SmtpServerConnectionDefinition smtpServerConnectionDefinition;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailProtocol"/> class.
        /// </summary>
        /// <param name="smtpServerConnectionDefinition">Locates an SMTP server along with credentials for connecting to the server.</param>
        public SendEmailProtocol(
            SmtpServerConnectionDefinition smtpServerConnectionDefinition)
        {
            new { smtpServerConnectionDefinition }.AsArg().Must().NotBeNull();

            this.smtpServerConnectionDefinition = smtpServerConnectionDefinition;
        }

        /// <inheritdoc />
        public override async Task<EmailResponse> ExecuteAsync(
            SendEmailOp operation)
        {
            using (var message = new MailMessage())
            {
                AddValidatedEmailAddressesToMessage(message, operation.EmailRequest.ValidatedEmailAddresses);

                AddContentToMessage(message, operation.EmailRequest.EmailContent);

                AddOptionsToMessage(message, operation.EmailRequest.EmailOptions);

                var result = await SendMessageAsync(message, this.smtpServerConnectionDefinition);

                return result;
            }
        }

        private static void AddValidatedEmailAddressesToMessage(
            MailMessage message,
            ValidatedEmailAddresses validatedEmailAddresses)
        {
            if (!string.IsNullOrWhiteSpace(validatedEmailAddresses.From))
            {
                message.From = new MailAddress(validatedEmailAddresses.From);
            }

            AddEmailAddresses(message.To, validatedEmailAddresses.To);

            AddEmailAddresses(message.CC, validatedEmailAddresses.Cc);

            AddEmailAddresses(message.Bcc, validatedEmailAddresses.Bcc);

            AddEmailAddresses(message.ReplyToList, validatedEmailAddresses.ReplyTo);
        }

        private static void AddEmailAddresses(
            MailAddressCollection mailAddressCollection,
            IReadOnlyCollection<string> emailAddresses)
        {
            if (emailAddresses != null)
            {
                foreach (var emailAddress in emailAddresses)
                {
                    mailAddressCollection.Add(new MailAddress(emailAddress));
                }
            }
        }

        private static void AddContentToMessage(
            MailMessage message,
            EmailContent emailContent)
        {
            if (emailContent.Subject != null)
            {
                message.Subject = emailContent.Subject;
            }

            if (emailContent.SubjectEncoding != null)
            {
                message.SubjectEncoding = emailContent.SubjectEncoding;
            }

            if (emailContent.Attachments != null)
            {
                foreach (var emailAttachment in emailContent.Attachments)
                {
                    var attachment = emailAttachment.ToAttachment();

                    message.Attachments.Add(attachment);
                }
            }

            var hasPlainTextBody = !string.IsNullOrWhiteSpace(emailContent.PlainTextBody);

            var hasHtmlBody = !string.IsNullOrWhiteSpace(emailContent.HtmlBody);

            if (hasPlainTextBody)
            {
                var plainTextAlternateView = AlternateView.CreateAlternateViewFromString(emailContent.PlainTextBody, emailContent.PlainTextBodyEncoding, MediaType.TextPlain.ToMimeTypeName());

                message.AlternateViews.Add(plainTextAlternateView);
            }

            if (hasHtmlBody)
            {
                var htmlAlternateView = AlternateView.CreateAlternateViewFromString(emailContent.HtmlBody, emailContent.HtmlBodyEncoding, MediaType.TextHtml.ToMimeTypeName());

                if (emailContent.ContentIdToHtmlBodyLinkedResourceMap != null)
                {
                    foreach (var contentId in emailContent.ContentIdToHtmlBodyLinkedResourceMap.Keys)
                    {
                        var emailAttachment = emailContent.ContentIdToHtmlBodyLinkedResourceMap[contentId];

                        var linkedResource = emailAttachment.ToLinkedResource(contentId);

                        htmlAlternateView.LinkedResources.Add(linkedResource);
                    }
                }

                message.AlternateViews.Add(htmlAlternateView);
            }
        }

        private static void AddOptionsToMessage(
            MailMessage message,
            EmailOptions emailOptions)
        {
            if (emailOptions != null)
            {
                if (emailOptions.DeliveryNotification != null)
                {
                    message.DeliveryNotificationOptions = (DeliveryNotificationOptions)emailOptions.DeliveryNotification;
                }

                if (emailOptions.Priority != null)
                {
                    message.Priority = (MailPriority)emailOptions.Priority;
                }
            }
        }

        private static async Task<EmailResponse> SendMessageAsync(
            MailMessage message,
            SmtpServerConnectionDefinition smtpServerConnectionDefinition)
        {
            using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            {
                EmailResponse result;

                SecureSocketOptions secureSocketOptions;

                switch (smtpServerConnectionDefinition.SecureConnectionMethod)
                {
                    case SecureConnectionMethod.UseTlsOnConnect:
                        secureSocketOptions = SecureSocketOptions.SslOnConnect;
                        break;
                    case SecureConnectionMethod.StartTls:
                        secureSocketOptions = SecureSocketOptions.StartTls;
                        break;
                    default:
                        throw new NotSupportedException(Invariant($"This {nameof(SecureConnectionMethod)} is not supported: {smtpServerConnectionDefinition.SecureConnectionMethod}."));
                }

                try
                {
                    await smtpClient.ConnectAsync(smtpServerConnectionDefinition.Host, smtpServerConnectionDefinition.Port, secureSocketOptions);
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToConnectToServer, ex.ToString());

                    return result;
                }

                try
                {
                    await smtpClient.AuthenticateAsync(smtpServerConnectionDefinition.Username, smtpServerConnectionDefinition.ClearTextPassword);
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToAuthenticateWithServer, ex.ToString());

                    return result;
                }

                MimeMessage mimeMessage;

                try
                {
                    mimeMessage = (MimeMessage)message;
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToPrepareEmailForSending, ex.ToString());

                    return result;
                }

                try
                {
                    await smtpClient.SendAsync(mimeMessage);
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToSendEmailToServer, ex.ToString());

                    return result;
                }

                try
                {
                    await smtpClient.DisconnectAsync(true);
                }
                catch (Exception)
                {
                }

                result = new EmailResponse(SendEmailResult.Success, null);

                return result;
            }
        }
    }
}