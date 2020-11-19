// --------------------------------------------------------------------------------------------------------------------
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
        /// <param name="htmlBody">OPTIONAL body of the email in HTML.  DEFAULT is to have no HTML body.</param>
        /// <param name="attachments">OPTIONAL attachments to the email.  These will be attached to the email (NOT linked in the email body, those should be specified in <paramref name="contentIdToHtmlBodyLinkedResourceMap"/>).  DEFAULT is none.</param>
        /// <param name="contentIdToHtmlBodyLinkedResourceMap">OPTIONAL collection of attachments that are linked in the HTML body, as a map of content identifier (cid, e.g. 'My_Content_Identifier') to resources linked in the <paramref name="htmlBody"/> (e.g. &lt;img src='cid:My_Content_Identifier' /&gt;).  DEFAULT is none.</param>
        /// <param name="subjectEncodingKind">OPTIONAL encoding to use to encode the subject.  DEFAULT is to use the system default encoding.</param>
        /// <param name="plainTextBodyEncodingKind">OPTIONAL encoding to use to encode the <paramref name="plainTextBody"/>.  DEFAULT is to use the system default encoding.</param>
        /// <param name="htmlBodyEncodingKind">OPTIONAL encoding to use to encode the <paramref name="htmlBody"/>.  DEFAULT is to use the system default encoding.</param>
        public EmailContent(
            string subject,
            string plainTextBody,
            string htmlBody = null,
            IReadOnlyCollection<EmailAttachment> attachments = null,
            IReadOnlyDictionary<string, EmailAttachment> contentIdToHtmlBodyLinkedResourceMap = null,
            EncodingKind? subjectEncodingKind = null,
            EncodingKind? plainTextBodyEncodingKind = null,
            EncodingKind? htmlBodyEncodingKind = null)
        {
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
            this.SubjectEncodingKind = subjectEncodingKind;
            this.PlainTextBodyEncodingKind = plainTextBodyEncodingKind;
            this.HtmlBodyEncodingKind = htmlBodyEncodingKind;
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
        public EncodingKind? SubjectEncodingKind { get; private set; }

        /// <summary>
        /// Gets the encoding to use to encode the <see cref="PlainTextBody"/>.
        /// </summary>
        public EncodingKind? PlainTextBodyEncodingKind { get; private set; }

        /// <summary>
        /// Gets the encoding to use to encode the <see cref="HtmlBody"/>.
        /// </summary>
        public EncodingKind? HtmlBodyEncodingKind { get; private set; }
    }
}
