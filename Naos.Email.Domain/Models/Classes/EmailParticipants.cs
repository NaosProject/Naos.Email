// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailParticipants.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Collections.Generic;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Specifies the email mailboxes of all of the participants in an email.
    /// </summary>
    public partial class EmailParticipants : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailParticipants"/> class.
        /// </summary>
        /// <param name="from">The mailbox of the sender of the email.</param>
        /// <param name="to">The email mailboxes of the recipients of the email.</param>
        /// <param name="cc">OPTIONAL email mailboxes of the carbon copy recipients of the email.  DEFAULT is null; the email will have no carbon copy recipients.</param>
        /// <param name="bcc">OPTIONAL email mailboxes of the blind carbon copy recipients of the email.  DEFAULT is null; the email will have no blind carbon copy recipients.</param>
        /// <param name="replyTo">OPTIONAL email mailboxes that the recipients (regular, cc, bcc) of the email should reply to.  DEFAULT is null; recipients should reply to <paramref name="to"/>.</param>
        public EmailParticipants(
            EmailMailbox from,
            IReadOnlyCollection<EmailMailbox> to,
            IReadOnlyCollection<EmailMailbox> cc = null,
            IReadOnlyCollection<EmailMailbox> bcc = null,
            IReadOnlyCollection<EmailMailbox> replyTo = null)
        {
            new { from }.AsArg().Must().NotBeNull();
            new { to }.AsArg().Must().NotBeNullNorEmptyEnumerableNorContainAnyNulls();

            if (cc != null)
            {
                new { cc }.AsArg().Must().NotContainAnyNullElements();
            }

            if (bcc != null)
            {
                new { bcc }.AsArg().Must().NotContainAnyNullElements();
            }

            if (replyTo != null)
            {
                new { replyTo }.AsArg().Must().NotContainAnyNullElements();
            }

            this.From = from;
            this.To = to;
            this.Cc = cc;
            this.Bcc = bcc;
            this.ReplyTo = replyTo;
        }

        /// <summary>
        /// Gets the email mailbox of the sender of the email.
        /// </summary>
        public EmailMailbox From { get; private set; }

        /// <summary>
        /// Gets the email mailboxes of the recipients of the email.
        /// </summary>
        public IReadOnlyCollection<EmailMailbox> To { get; private set; }

        /// <summary>
        /// Gets the email mailboxes of the carbon copy recipients of the email.
        /// </summary>
        public IReadOnlyCollection<EmailMailbox> Cc { get; private set; }

        /// <summary>
        /// Gets the email mailboxes of the blind carbon copy recipients of the email.
        /// </summary>
        public IReadOnlyCollection<EmailMailbox> Bcc { get; private set; }

        /// <summary>
        /// Gets the email mailboxes that the recipients (regular, cc, bcc) of the email should reply to.
        /// </summary>
        public IReadOnlyCollection<EmailMailbox> ReplyTo { get; private set; }
    }
}
