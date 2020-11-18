// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IncludeFileWithEmail.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    /// <summary>
    /// Specifies how a file should be included with an email.
    /// </summary>
    public enum IncludeFileWithEmail
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// The file should be included as an attachment to the email.
        /// </summary>
        /// <remarks>
        /// Attachments are usually not opened until the user performs some action, such as clicking an icon that represents the attachment.
        /// </remarks>
        AsAttachment,

        /// <summary>
        /// The file should be inlined with the email.
        /// </summary>
        /// <remarks>
        /// Inline attachments are usually displayed when the user opens the email.
        /// </remarks>
        Inline,
    }
}
