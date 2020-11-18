﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailContent.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Collections.Generic;
    using System.Text;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    using static System.FormattableString;

    /// <summary>
    /// Contains the content of an email.
    /// </summary>
    public partial class EmailContent : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailContent"/> class.
        /// </summary>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="plainTextBody">The body of the email in plain text.</param>
        /// <param name="htmlBody">The body of the email in HTML.</param>
        /// <param name="attachments">OPTIONAL attachments to the email.  DEFAULT is none.</param>
        /// <param name="contentIdToHtmlBodyLinkedResourceMap">OPTIONAL map of content identifier (cid) to resources linked in the <paramref name="htmlBody"/> (e.g. &lt;img src='cid:Content_Identifier_Here' /&gt;).  DEFAULT is none.</param>
        /// <param name="subjectEncoding">OPTIONAL encoding to use to encode the subject.  DEFAULT is to use the system default encoding.</param>
        /// <param name="plainTextBodyEncoding">OPTIONAL encoding to use to encode the <paramref name="plainTextBody"/>.  DEFAULT is to use the system default encoding.</param>
        /// <param name="htmlBodyEncoding">OPTIONAL encoding to use to encode the <paramref name="htmlBody"/>.  DEFAULT is to use the system default encoding.</param>
        public EmailContent(
            string subject,
            string plainTextBody,
            string htmlBody,
            IReadOnlyCollection<EmailAttachment> attachments = null,
            IReadOnlyDictionary<string, EmailAttachment> contentIdToHtmlBodyLinkedResourceMap = null,
            Encoding subjectEncoding = null,
            Encoding plainTextBodyEncoding = null,
            Encoding htmlBodyEncoding = null)
        {
            // html body relative URI?
            if (attachments != null)
            {
                new { attachments }.AsTest().Must().NotContainAnyNullElements();
            }

            if (contentIdToHtmlBodyLinkedResourceMap != null)
            {
                new { contentIdToHtmlBodyLinkedResourceMap.Keys }.AsTest(Invariant($"{nameof(contentIdToHtmlBodyLinkedResourceMap)}.Keys")).Must().Each().NotBeNullNorWhiteSpace();
                new { contentIdToHtmlBodyLinkedResourceMap.Values }.AsTest(Invariant($"{nameof(contentIdToHtmlBodyLinkedResourceMap)}.Values")).Must().Each().NotBeNull();
            }

            this.Subject = subject;
            this.PlainTextBody = plainTextBody;
            this.HtmlBody = htmlBody;
            this.Attachments = attachments;
            this.ContentIdToHtmlBodyLinkedResourceMap = contentIdToHtmlBodyLinkedResourceMap;
            this.SubjectEncoding = subjectEncoding;
            this.PlainTextBodyEncoding = plainTextBodyEncoding;
            this.HtmlBodyEncoding = htmlBodyEncoding;
        }

        /// <summary>
        /// Gets the subject of the email.
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Gets the body of the email in plain text.
        /// </summary>
        public string PlainTextBody { get; private set; }

        /// <summary>
        /// Gets the body of the email in HTML.
        /// </summary>
        public string HtmlBody { get; private set; }

        /// <summary>
        /// Gets the attachments to the email.
        /// </summary>
        public IReadOnlyCollection<EmailAttachment> Attachments { get; private set; }

        /// <summary>
        /// Gets map of content identifier (cid) to resources linked in the <see cref="HtmlBody"/>.
        /// </summary>
        public IReadOnlyDictionary<string, EmailAttachment> ContentIdToHtmlBodyLinkedResourceMap { get; private set; }

        /// <summary>
        /// Gets the encoding to use to encode the subject.
        /// </summary>
        public Encoding SubjectEncoding { get; private set; }

        /// <summary>
        /// Gets the encoding to use to encode the <see cref="PlainTextBody"/>.
        /// </summary>
        public Encoding PlainTextBodyEncoding { get; private set; }

        /// <summary>
        /// Gets the encoding to use to encode the <see cref="HtmlBody"/>.
        /// </summary>
        public Encoding HtmlBodyEncoding { get; private set; }
    }
}
