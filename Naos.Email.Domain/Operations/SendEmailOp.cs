// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailOp.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Sends an email.
    /// </summary>
    public partial class SendEmailOp : ReturningOperationBase<SendEmailResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailOp"/> class.
        /// </summary>
        /// <param name="sendEmailRequest">The request to send an email.</param>
        public SendEmailOp(
            SendEmailRequest sendEmailRequest)
        {
            new { sendEmailRequest }.AsArg().Must().NotBeNull();

            this.SendEmailRequest = sendEmailRequest;
        }

        /// <summary>
        /// Gets the request to send the email.
        /// </summary>
        public SendEmailRequest SendEmailRequest { get; private set; }
    }
}