// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISendEmailProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Type;

    /// <summary>
    /// Executes a <see cref="SendEmailOp"/>.
    /// </summary>
    public interface ISendEmailProtocol : IAsyncReturningProtocol<SendEmailOp, SendEmailResponse>
    {
    }
}
