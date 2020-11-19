// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailOp.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Sends an email.
    /// </summary>
    public partial class SendEmailOp : ReturningOperationBase<EmailResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailOp"/> class.
        /// </summary>
        /// <param name="emailRequest">The request to send an email.</param>
        public SendEmailOp(
            EmailRequest emailRequest)
        {
            new { emailRequest }.AsArg().Must().NotBeNull();

            this.EmailRequest = emailRequest;
        }

        /// <summary>
        /// Gets the request to send the email.
        /// </summary>
        public EmailRequest EmailRequest { get; private set; }
    }
}