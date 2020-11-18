// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailResponse.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    using static System.FormattableString;

    /// <summary>
    /// The result of sending an email.
    /// </summary>
    public class EmailResponse : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailResponse"/> class.
        /// </summary>
        /// <param name="sendEmailResult">The result of sending the email.</param>
        /// <param name="exceptionToString">If there's a failure, the <see cref="object.ToString()"/> of the <see cref="Exception"/>.</param>
        public EmailResponse(
            SendEmailResult sendEmailResult,
            string exceptionToString)
        {
            new { sendEmailResult }.AsArg().Must().NotBeEqualTo(SendEmailResult.Unknown);

            if (sendEmailResult != SendEmailResult.Success)
            {
                new { exceptionToString }.AsArg().Must().NotBeNullNorWhiteSpace(Invariant($"When {nameof(sendEmailResult)} indicates a failure, {nameof(exceptionToString)} is required.");)
            }

            this.SendEmailResult = sendEmailResult;
            this.ExceptionToString = exceptionToString;
        }

        /// <summary>
        /// Gets the result of sending the email.
        /// </summary>
        public SendEmailResult SendEmailResult { get; private set; }

        /// <summary>
        /// Gets the <see cref="object.ToString()"/> of the <see cref="Exception"/> for failures.
        /// </summary>
        public string ExceptionToString { get; private set; }
    }
}
