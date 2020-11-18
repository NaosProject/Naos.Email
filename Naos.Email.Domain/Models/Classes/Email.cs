// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Email.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// An email; the item itself along with information about its delivery.
    /// </summary>
    public class Email : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="emailRequest">The request to send the email.</param>
        /// <param name="emailResponse">The result of sending the email.</param>
        public Email(
            EmailRequest emailRequest,
            EmailResponse emailResponse)
        {
            new { emailRequest }.AsArg().Must().NotBeNull();
            new { emailResponse }.AsArg().Must().NotBeNull();

            this.EmailRequest = emailRequest;
            this.EmailResponse = emailResponse;
        }

        /// <summary>
        /// Gets the request to send the email.
        /// </summary>
        public EmailRequest EmailRequest { get; private set; }

        /// <summary>
        /// Gets the result of sending the email.
        /// </summary>
        public EmailResponse EmailResponse { get; private set; }
    }
}
