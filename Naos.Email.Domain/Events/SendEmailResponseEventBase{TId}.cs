// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailResponseEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class that tracks a <see cref="SendEmailResponse"/>.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class SendEmailResponseEventBase<TId> : EmailEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailResponseEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="sendEmailResponse">The result of sending the email.</param>
        protected SendEmailResponseEventBase(
            TId id,
            DateTime timestampUtc,
            SendEmailResponse sendEmailResponse)
            : base(id, timestampUtc)
        {
            new { sendEmailResponse }.AsArg().Must().NotBeNull();

            this.SendEmailResponse = sendEmailResponse;
        }

        /// <summary>
        /// Gets the result of sending the email.
        /// </summary>
        public SendEmailResponse SendEmailResponse { get; private set; }
    }
}
