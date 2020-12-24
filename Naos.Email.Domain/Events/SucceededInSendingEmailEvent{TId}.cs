// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SucceededInSendingEmailEvent{TId}.cs" company="Naos Project">
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
    /// Succeeded in sending an email.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class SucceededInSendingEmailEvent<TId> : SendEmailResponseEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SucceededInSendingEmailEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="sendEmailResponse">The result of sending the email.</param>
        public SucceededInSendingEmailEvent(
            TId id,
            DateTime timestampUtc,
            SendEmailResponse sendEmailResponse)
            : base(id, timestampUtc, sendEmailResponse)
        {
            new { sendEmailResponse.SendEmailResult }.AsArg(Invariant($"{nameof(sendEmailResponse)}.{nameof(this.SendEmailResponse.SendEmailResult)}")).Must().BeEqualTo(SendEmailResult.Success);
        }
    }
}
