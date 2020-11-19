// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailSendingEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class that tracks an email request/response pair.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class EmailSendingEventBase<TId> : EventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSendingEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="emailRequest">The request to send the email.</param>
        /// <param name="emailResponse">The result of sending the email.</param>
        protected EmailSendingEventBase(
            TId id,
            DateTime timestampUtc,
            EmailRequest emailRequest,
            EmailResponse emailResponse)
            : base(id, timestampUtc)
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
