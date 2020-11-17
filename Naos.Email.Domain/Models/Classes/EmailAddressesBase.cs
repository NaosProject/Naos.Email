﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressesBase.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Collections.Generic;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Specifies the email addresses used in an email.
    /// </summary>
    public abstract partial class EmailAddressesBase : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressesBase"/> class.
        /// </summary>
        /// <param name="from">The email address of the sender of the email.</param>
        /// <param name="to">The email addresses of the recipients of the email.</param>
        /// <param name="cc">OPTIONAL email addresses of the carbon copy recipients of the email.  DEFAULT is null; the email will have no carbon copy recipients.</param>
        /// <param name="bcc">OPTIONAL email addresses of the blind carbon copy recipients of the email.  DEFAULT is null; the email will have no blind carbon copy recipients.</param>
        /// <param name="replyTo">OPTIONAL email addresses that the recipients (regular, cc, bcc) of the email should reply to.  DEFAULT is null; recipients should reply to <paramref name="to"/>.</param>
        protected EmailAddressesBase(
            string from,
            IReadOnlyCollection<string> to,
            IReadOnlyCollection<string> cc = null,
            IReadOnlyCollection<string> bcc = null,
            IReadOnlyCollection<string> replyTo = null)
        {
            new { from }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { to }.AsArg().Must().NotBeNullNorEmptyEnumerableNorContainAnyNulls().And().Each().NotBeNullNorWhiteSpace();

            if (cc != null)
            {
                new { cc }.AsArg().Must().Each().NotBeNullNorWhiteSpace();
            }

            if (bcc != null)
            {
                new { bcc }.AsArg().Must().Each().NotBeNullNorWhiteSpace();
            }

            if (replyTo != null)
            {
                new { replyTo }.AsArg().Must().Each().NotBeNullNorWhiteSpace();
            }

            this.From = from;
            this.To = to;
            this.Cc = cc;
            this.Bcc = bcc;
            this.ReplyTo = replyTo;
        }

        /// <summary>
        /// Gets the email address of the sender of the email.
        /// </summary>
        public string From { get; private set; }

        /// <summary>
        /// Gets the email addresses of the recipients of the email.
        /// </summary>
        public IReadOnlyCollection<string> To { get; private set; }

        /// <summary>
        /// Gets the email addresses of the carbon copy recipients of the email.
        /// </summary>
        public IReadOnlyCollection<string> Cc { get; private set; }

        /// <summary>
        /// Gets the email addresses of the blind carbon copy recipients of the email.
        /// </summary>
        public IReadOnlyCollection<string> Bcc { get; private set; }

        /// <summary>
        /// Gets the email addresses that the recipients (regular, cc, bcc) of the email should reply to.
        /// </summary>
        public IReadOnlyCollection<string> ReplyTo { get; private set; }
    }
}
