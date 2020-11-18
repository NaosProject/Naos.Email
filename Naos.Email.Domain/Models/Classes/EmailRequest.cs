// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailRequest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A request to send an email.
    /// </summary>
    public class EmailRequest : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRequest"/> class.
        /// </summary>
        /// <param name="validatedEmailAddresses">The email addresses to use in the email, where all of the email addresses have been validated.</param>
        /// <param name="emailContent">The content of the email.</param>
        /// <param name="emailOptions">OPTIONAL options/instructions for sending the email.  DEFAULT is to use the system defaults.</param>
        public EmailRequest(
            ValidatedEmailAddresses validatedEmailAddresses,
            EmailContent emailContent,
            EmailOptions emailOptions = null)
        {
            new { validatedEmailAddresses }.AsArg().Must().NotBeNull();
            new { emailContent }.AsArg().Must().NotBeNull();

            this.ValidatedEmailAddresses = validatedEmailAddresses;
            this.EmailContent = emailContent;
            this.EmailOptions = emailOptions;
        }

        /// <summary>
        /// Gets the email addresses to use in the email, where all of the email addresses have been validated.
        /// </summary>
        public ValidatedEmailAddresses ValidatedEmailAddresses { get; private set; }

        /// <summary>
        /// Gets the content of the email.
        /// </summary>
        public EmailContent EmailContent { get; private set; }

        /// <summary>
        /// Gets options/instructions for sending the email.
        /// </summary>
        public EmailOptions EmailOptions { get; private set; }
    }
}
