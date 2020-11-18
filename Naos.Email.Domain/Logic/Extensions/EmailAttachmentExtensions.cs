// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressBaseExtensions.cs" company="Naos Project">
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

            result.ContentDisposition.Inline = emailAttachment.IncludeFileWithEmail == IncludeFileWithEmail.Inline;

            result.ContentDisposition.Size = emailAttachment.FileBytes.Length;

            if (!string.IsNullOrWhiteSpace(emailAttachment.FileName))
            {
                result.ContentDisposition.FileName = emailAttachment.FileName;
            }

            if (emailAttachment.DateCreated != null)
            {
                result.ContentDisposition.CreationDate = (DateTime)emailAttachment.DateCreated;
            }

            if (emailAttachment.DateModified != null)
            {
                result.ContentDisposition.ModificationDate = (DateTime)emailAttachment.DateModified;
            }

            if (emailAttachment.DateAccessed != null)
            {
                result.ContentDisposition.ReadDate = (DateTime)emailAttachment.DateAccessed;
            }

            return result;
        }
    }
}
