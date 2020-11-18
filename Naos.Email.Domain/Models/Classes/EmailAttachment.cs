// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAttachment.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Represents an attachment to an email.
    /// </summary>
    public partial class EmailAttachment : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAttachment"/> class.
        /// </summary>
        /// <param name="fileBytes">The bytes of the files.</param>
        /// <param name="fileName">OPTIONAL suggested file name for the attachment, which an email client might display or use when storing the attachment on the recipient's computer. This name is a suggestion only; the receiving system can ignore it.  DEFAULT is null; no file name specified.</param>
        /// <param name="mediaType">OPTIONAL value that specifies the MIME type of the file.  DEFAULT is indicate that this is a unknown/unspecified binary file.</param>
        public EmailAttachment(
            byte[] fileBytes,
            string fileName = null,
            MediaType mediaType = MediaType.ApplicationOctet)
        {
            // required versus optional?
            // - TransferEncoding, NameEncoding
            //       there's an option to specify the encoding to use for the media type, but that feels like overkill
            //      .net will figure that out for us.
            // Charset?
            // Extra parameters?
            new { fileBytes }.AsArg().Must().NotBeNullNorEmptyEnumerable();

            this.FileBytes = fileBytes;
            this.FileName = fileName;
            this.MediaType = mediaType;
        }

        /// <summary>
        /// Gets the bytes of the files.
        /// </summary>
        public byte[] FileBytes { get; private set; }

        /// <summary>
        /// Gets the suggested file name for the attachment, which an email client might display or use when storing the attachment on the recipient's computer. This name is a suggestion only; the receiving system can ignore it.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets a value that specifies the MIME type of the file.
        /// </summary>
        public MediaType MediaType { get; private set; }
    }
}
