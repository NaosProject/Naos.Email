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
        /// <param name="includeFileWithEmail">OPTIONAL value that specifies how the file should be included with an email.  DEFAULT is to include the file as an attachment (versus inlining it).</param>
        /// <param name="mediaType">OPTIONAL value that specifies the MIME type of the file.  DEFAULT is indicate that this is a unknown/unspecified binary file.</param>
        /// <param name="dateCreated">OPTIONAL timestamp of when the file was created.  DEFAULT is null; no timestamp is provided.</param>
        /// <param name="dateModified">OPTIONAL timestamp of when the file was last modified.  DEFAULT is null; no timestamp is provided.</param>
        /// <param name="dateAccessed">OPTIONAL timestamp of when the file was last accessed (read).  DEFAULT is null; no timestamp is provided.</param>
        public EmailAttachment(
            byte[] fileBytes,
            string fileName = null,
            IncludeFileWithEmail includeFileWithEmail = IncludeFileWithEmail.AsAttachment,
            MediaType mediaType = MediaType.ApplicationOctet,
            DateTime? dateCreated = null,
            DateTime? dateModified = null,
            DateTime? dateAccessed = null)
        {
            // required versus optional?
            // - should dateCreated/modified be in UTC?  Gmail doesn't respect these
            // - TransferEncoding, NameEncoding
            //       there's an option to specify the encoding to use for the media type, but that feels like overkill
            //      .net will figure that out for us.
            // really necessary? IncludeFileWithEmail.Unknown
            // Charset?
            // Extra parameters?
            new { fileBytes }.AsArg().Must().NotBeNullNorEmptyEnumerable();
            new { includeFileWithEmail }.AsArg().Must().NotBeEqualTo(IncludeFileWithEmail.Unknown);

            this.FileBytes = fileBytes;
            this.FileName = fileName;
            this.IncludeFileWithEmail = includeFileWithEmail;
            this.MediaType = mediaType;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateAccessed = dateAccessed;
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
        /// Gets a value that specifies how the file should be included with an email.
        /// </summary>
        public IncludeFileWithEmail IncludeFileWithEmail { get; private set; }

        /// <summary>
        /// Gets a value that specifies the MIME type of the file.
        /// </summary>
        public MediaType MediaType { get; private set; }

        /// <summary>
        /// Gets a timestamp of when the file was created.
        /// </summary>
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// Gets a timestamp of when the file was last modified.
        /// </summary>
        public DateTime? DateModified { get; private set; }

        /// <summary>
        /// Gets a timestamp of when the file was last accessed (read).
        /// </summary>
        public DateTime? DateAccessed { get; private set; }
    }
}
