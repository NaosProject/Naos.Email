// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISendEmailProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using Naos.Protocol.Domain;

    /// <summary>
    /// Executes a <see cref="SendEmailOp"/>.
    /// </summary>
    public interface ISendEmailProtocol : ISyncAndAsyncReturningProtocol<SendEmailOp, EmailResponse>
    {
    }
}
