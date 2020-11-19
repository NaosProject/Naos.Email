// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMailboxExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Net.Mail;

    using OBeautifulCode.Assertion.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Extension methods on <see cref="EmailMailbox"/>.
    /// </summary>
    public static class EmailMailboxExtensions
    {
        /// <summary>
        /// Converts a <see cref="EmailMailbox"/> to an <see cref="MailAddress"/>.
        /// </summary>
        /// <param name="emailMailbox">The email mailbox to convert.</param>
        /// <returns>
        /// The <see cref="MailAddress"/> that corresponds to the specified <see cref="EmailMailbox"/>.
        /// </returns>
        public static MailAddress ToMailAddress(
            this EmailMailbox emailMailbox)
        {
            new { emailMailbox }.AsArg().Must().NotBeNull();

            new { emailMailbox.Address }.AsArg(Invariant($"{nameof(emailMailbox)}.{nameof(EmailMailbox.Address)}")).Must().BeValidEmailAddress();

            var displayName = string.IsNullOrWhiteSpace(emailMailbox.Name) ? null : emailMailbox.Name;

            var result = new MailAddress(emailMailbox.Address, displayName);

            return result;
        }
    }
}
