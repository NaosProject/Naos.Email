// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedToSendEmailEvent{TId}.cs" company="Naos Project">
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
    /// Failed to send an email.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class FailedToSendEmailEvent<TId> : EmailResponseEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToSendEmailEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="emailResponse">The result of sending the email.</param>
        public FailedToSendEmailEvent(
            TId id,
            DateTime timestampUtc,
            EmailResponse emailResponse)
            : base(id, timestampUtc, emailResponse)
        {
            new { emailResponse.SendEmailResult }.AsArg(Invariant($"{nameof(emailResponse)}.{nameof(this.EmailResponse.SendEmailResult)}")).Must().NotBeEqualTo(SendEmailResult.Success);
        }
    }
}
