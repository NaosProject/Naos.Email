﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailRequestedEvent{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A request has been made to send an email.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class SendEmailRequestedEvent<TId> : EmailEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailRequestedEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="emailRequest">The request to send the email.</param>
        public SendEmailRequestedEvent(
            TId id,
            DateTime timestampUtc,
            EmailRequest emailRequest)
            : base(id, timestampUtc)
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