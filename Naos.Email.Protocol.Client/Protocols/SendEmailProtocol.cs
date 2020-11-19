// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Protocol.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;

    using MailKit;
    using MailKit.Security;

    using MimeKit;

    using Naos.Email.Domain;
    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Executes a <see cref="SendEmailProtocol"/>.
    /// </summary>
    public class SendEmailProtocol : AsyncSpecificReturningProtocolBase<SendEmailOp, EmailResponse>, ISendEmailProtocol
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
                EmailResponse result;

                try
                {
                    AddEmailParticipantsToMessage(message, operation.EmailRequest.EmailParticipants);
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToAddParticipantsToEmail, ex.ToString(), null);

                    return result;
                }

                try
                {
                    AddContentToMessage(message, operation.EmailRequest.EmailContent);
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToAddContentToEmail, ex.ToString(), null);

                    return result;
                }

                try
                {
                    AddOptionsToMessage(message, operation.EmailRequest.EmailOptions);
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToAddOptionsToEmail, ex.ToString(), null);

                    return result;
                }

                MimeMessage mimeMessage;

                try
                {
                    mimeMessage = (MimeMessage)message;
                }
                catch (Exception ex)
                {
                    result = new EmailResponse(SendEmailResult.FailedToPackageEmailForSending, ex.ToString(), null);

                    return result;
                }

                result = await SendMessageAsync(mimeMessage, this.smtpServerConnectionDefinition);

                return result;
            }
        }

        private static void AddEmailParticipantsToMessage(
            MailMessage message,
            EmailParticipants emailParticipants)
        {
            message.From = emailParticipants.From.ToMailAddress();

            AddEmailAddresses(message.To, emailParticipants.To);

            AddEmailAddresses(message.CC, emailParticipants.Cc);

            AddEmailAddresses(message.Bcc, emailParticipants.Bcc);

            AddEmailAddresses(message.ReplyToList, emailParticipants.ReplyTo);
        }

        private static void AddEmailAddresses(
            MailAddressCollection mailAddressCollection,
            IReadOnlyCollection<EmailMailbox> emailMailboxes)
        {
            if (emailMailboxes != null)
            {
                foreach (var emailMailbox in emailMailboxes)
                {
                    var mailAddress = emailMailbox.ToMailAddress();

                    mailAddressCollection.Add(mailAddress);
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
            MimeMessage mimeMessage,
            SmtpServerConnectionDefinition smtpServerConnectionDefinition)
        {
            using (var logStream = new MemoryStream())
            {
                using (var protocolLogger = new ProtocolLogger(logStream, leaveOpen: false))
                {
                    using (var smtpClient = new MailKit.Net.Smtp.SmtpClient(protocolLogger))
                    {
                        EmailResponse result;

                        string logMessages;

                        var secureSocketOptions = GetSecureSocketOptions(smtpServerConnectionDefinition.SecureConnectionMethod);

                        try
                        {
                            await smtpClient.ConnectAsync(smtpServerConnectionDefinition.Host, smtpServerConnectionDefinition.Port, secureSocketOptions);
                        }
                        catch (Exception ex)
                        {
                            logMessages = GetLogMessages(logStream);

                            result = new EmailResponse(SendEmailResult.FailedToConnectToServer, ex.ToString(), logMessages);

                            return result;
                        }

                        try
                        {
                            await smtpClient.AuthenticateAsync(smtpServerConnectionDefinition.Username, smtpServerConnectionDefinition.ClearTextPassword);
                        }
                        catch (Exception ex)
                        {
                            logMessages = GetLogMessages(logStream);

                            result = new EmailResponse(SendEmailResult.FailedToAuthenticateWithServer, ex.ToString(), logMessages);

                            return result;
                        }

                        try
                        {
                            await smtpClient.SendAsync(mimeMessage);
                        }
                        catch (Exception ex)
                        {
                            logMessages = GetLogMessages(logStream);

                            result = new EmailResponse(SendEmailResult.FailedToSendEmailToServer, ex.ToString(), logMessages);

                            return result;
                        }

                        try
                        {
                            await smtpClient.DisconnectAsync(true);
                        }
                        catch (Exception)
                        {
                        }

                        logMessages = GetLogMessages(logStream);

                        result = new EmailResponse(SendEmailResult.Success, null, logMessages);

                        return result;
                    }
                }
            }
        }

        private static SecureSocketOptions GetSecureSocketOptions(
            SecureConnectionMethod secureConnectionMethod)
        {
            SecureSocketOptions result;

            switch (secureConnectionMethod)
            {
                case SecureConnectionMethod.UseTlsOnConnect:
                    result = SecureSocketOptions.SslOnConnect;
                    break;
                case SecureConnectionMethod.StartTls:
                    result = SecureSocketOptions.StartTls;
                    break;
                default:
                    throw new NotSupportedException(Invariant($"This {nameof(SecureConnectionMethod)} is not supported: {secureConnectionMethod}."));
            }

            return result;
        }

        private static string GetLogMessages(
            MemoryStream logStream)
        {
            var logBytes = logStream.ToArray();

            var result = Encoding.UTF8.GetString(logBytes);

            return result;
        }
    }
}