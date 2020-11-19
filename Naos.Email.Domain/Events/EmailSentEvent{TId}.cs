// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailSentEvent{TId}.cs" company="Naos Project">
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
    /// An email has been sent.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class EmailSentEvent<TId> : EmailSendingEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSentEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="emailRequest">The request to send the email.</param>
        /// <param name="emailResponse">The result of sending the email.</param>
        public EmailSentEvent(
            TId id,
            DateTime timestampUtc,
            EmailRequest emailRequest,
            EmailResponse emailResponse)
            : base(id, timestampUtc, emailRequest, emailResponse)
        {
            new { emailResponse.SendEmailResult }.AsArg(Invariant($"{nameof(emailResponse)}.{nameof(this.EmailResponse.SendEmailResult)}")).Must().BeEqualTo(SendEmailResult.Success);
        }
    }
}
