// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAttachmentExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;
    using System.IO;

    using System.Net.Mail;
    using System.Net.Mime;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Extension methods on <see cref="EmailAttachment"/>.
    /// </summary>
    public static class EmailAttachmentExtensions
    {
        /// <summary>
        /// Converts a <see cref="EmailAttachment"/> to an <see cref="Attachment"/>.
        /// </summary>
        /// <param name="emailAttachment">The email attachment to convert.</param>
        /// <returns>
        /// The <see cref="Attachment"/> that corresponds to the specified <see cref="EmailAttachment"/>.
        /// </returns>
        public static Attachment ToAttachment(
            this EmailAttachment emailAttachment)
        {
            new { emailAttachment }.AsArg().Must().NotBeNull();

            var mimeTypeName = emailAttachment.MediaType.ToMimeTypeName();

            var contentType = new ContentType { MediaType = mimeTypeName };

            if (!string.IsNullOrWhiteSpace(emailAttachment.FileName))
            {
                contentType.Name = emailAttachment.FileName;
            }

            var contentStream = new MemoryStream(emailAttachment.FileBytes);

            var result = new Attachment(contentStream, contentType);

            result.ContentDisposition.Size = emailAttachment.FileBytes.Length;

            if (!string.IsNullOrWhiteSpace(emailAttachment.FileName))
            {
                result.ContentDisposition.FileName = emailAttachment.FileName;
            }

            if (emailAttachment.FileNameEncodingKind != null)
            {
                result.NameEncoding = emailAttachment.FileNameEncodingKind?.ToEncoding();
            }

            return result;
        }

        /// <summary>
        /// Converts a <see cref="EmailAttachment"/> to an <see cref="LinkedResource"/>.
        /// </summary>
        /// <param name="emailAttachment">The email attachment to convert.</param>
        /// <param name="contentId">The content id to use for the resource.</param>
        /// <returns>
        /// The <see cref="LinkedResource"/> that corresponds to the specified <see cref="EmailAttachment"/>.
        /// </returns>
        public static LinkedResource ToLinkedResource(
            this EmailAttachment emailAttachment,
            string contentId)
        {
            new { emailAttachment }.AsArg().Must().NotBeNull();

            var mimeTypeName = emailAttachment.MediaType.ToMimeTypeName();

            var contentType = new ContentType { MediaType = mimeTypeName };

            if (!string.IsNullOrWhiteSpace(emailAttachment.FileName))
            {
                contentType.Name = emailAttachment.FileName;
            }

            var contentStream = new MemoryStream(emailAttachment.FileBytes);

            var result = new LinkedResource(contentStream, contentType)
            {
                ContentId = contentId,
                ContentLink = new Uri("cid:" + contentId),
            };

            return result;
        }
    }
}
