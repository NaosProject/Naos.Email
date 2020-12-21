// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailResponseEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class that tracks an email response.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class EmailResponseEventBase<TId> : EmailEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailResponseEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="emailResponse">The result of sending the email.</param>
        protected EmailResponseEventBase(
            TId id,
            DateTime timestampUtc,
            EmailResponse emailResponse)
            : base(id, timestampUtc)
        {
            new { emailResponse }.AsArg().Must().NotBeNull();

            this.EmailResponse = emailResponse;
        }

        /// <summary>
        /// Gets the result of sending the email.
        /// </summary>
        public EmailResponse EmailResponse { get; private set; }
    }
}
