// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailResponse.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Naos.CodeAnalysis.Recipes;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    using static System.FormattableString;

    /// <summary>
    /// The result of sending an email.
    /// </summary>
    public partial class EmailResponse : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailResponse"/> class.
        /// </summary>
        /// <param name="sendEmailResult">The result of sending the email.</param>
        /// <param name="exceptionToString">OPTIONAL <see cref="object.ToString()"/> of the <see cref="Exception"/> if a failure has occurred.  DEFAULT is no exception information.</param>
        /// <param name="communicationLog">OPTIONAL log of communication between client and server.  DEFAULT is the absence of any communication log.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string", Justification = NaosSuppressBecause.CA1720_IdentifiersShouldNotContainTypeNames_TypeNameAddsClarityToIdentifierAndAlternativesDegradeClarity)]
        public EmailResponse(
            SendEmailResult sendEmailResult,
            string exceptionToString = null,
            string communicationLog = null)
        {
            new { sendEmailResult }.AsArg().Must().NotBeEqualTo(SendEmailResult.Unknown);

            if (sendEmailResult != SendEmailResult.Success)
            {
                new { exceptionToString }.AsArg().Must().NotBeNullNorWhiteSpace(Invariant($"When {nameof(sendEmailResult)} indicates a failure, {nameof(exceptionToString)} must not be null nor white space."));
            }

            if (sendEmailResult == SendEmailResult.Success)
            {
                new { exceptionToString }.AsArg().Must().BeNull(Invariant($"When {nameof(sendEmailResult)} indicates success, {nameof(exceptionToString)} must be null."));
            }

            this.SendEmailResult = sendEmailResult;
            this.ExceptionToString = exceptionToString;
            this.CommunicationLog = communicationLog;
        }

        /// <summary>
        /// Gets the result of sending the email.
        /// </summary>
        public SendEmailResult SendEmailResult { get; private set; }

        /// <summary>
        /// Gets the <see cref="object.ToString()"/> of the <see cref="Exception"/> for failures.
        /// </summary>
        public string ExceptionToString { get; private set; }

        /// <summary>
        /// Gets the log of communication between client and server.
        /// </summary>
        public string CommunicationLog { get; private set; }
    }
}
