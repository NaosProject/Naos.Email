// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressBaseExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Extension methods on <see cref="EmailAddressesBase"/> and derivatives.
    /// </summary>
    public static class EmailAddressBaseExtensions
    {
        /// <summary>
        /// Attempts to construct a <see cref="ValidatedEmailAddresses"/>
        /// using the properties of <see cref="UnvalidatedEmailAddresses"/>.
        /// </summary>
        /// <param name="unvalidatedEmailAddresses">The email addresses to be used in an email, where none of the email addresses have been validated.</param>
        /// <returns>
        /// The email addresses to be used in an email, where all of the email addresses have been validated.
        /// </returns>
        public static ValidatedEmailAddresses ToValidatedEmailAddresses(
            this UnvalidatedEmailAddresses unvalidatedEmailAddresses)
        {
            new { unvalidatedEmailAddresses }.AsArg().Must().NotBeNull();

            var result = new ValidatedEmailAddresses(unvalidatedEmailAddresses.From, unvalidatedEmailAddresses.To, unvalidatedEmailAddresses.Cc, unvalidatedEmailAddresses.Bcc, unvalidatedEmailAddresses.ReplyTo);

            return result;
        }
    }
}
