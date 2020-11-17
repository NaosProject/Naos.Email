// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnvalidatedEmailAddresses.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Collections.Generic;

    using OBeautifulCode.Type;

    /// <summary>
    /// Specifies the email addresses used in an email, where none of the email addresses have been validated.
    /// </summary>
    public partial class UnvalidatedEmailAddresses : EmailAddressesBase, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnvalidatedEmailAddresses"/> class.
        /// </summary>
        /// <param name="from">The email address of the sender of the email.</param>
        /// <param name="to">The email addresses of the recipients of the email.</param>
        /// <param name="cc">OPTIONAL email addresses of the carbon copy recipients of the email.  DEFAULT is null; the email will have no carbon copy recipients.</param>
        /// <param name="bcc">OPTIONAL email addresses of the blind carbon copy recipients of the email.  DEFAULT is null; the email will have no blind carbon copy recipients.</param>
        /// <param name="replyTo">OPTIONAL email addresses that the recipients (regular, cc, bcc) of the email should reply to.  DEFAULT is null; recipients should reply to <paramref name="to"/>.</param>
        public UnvalidatedEmailAddresses(
            string from,
            IReadOnlyCollection<string> to,
            IReadOnlyCollection<string> cc = null,
            IReadOnlyCollection<string> bcc = null,
            IReadOnlyCollection<string> replyTo = null)
            : base(from, to, cc, bcc, replyTo)
        {
        }
    }
}
