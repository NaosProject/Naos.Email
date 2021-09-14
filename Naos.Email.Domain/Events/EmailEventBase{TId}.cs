// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;

    using OBeautifulCode.Type;

    /// <summary>
    /// Base class for email event.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class EmailEventBase<TId> : EventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        protected EmailEventBase(
            TId id,
            DateTime timestampUtc)
            : base(id, timestampUtc)
        {
        }
    }
}
