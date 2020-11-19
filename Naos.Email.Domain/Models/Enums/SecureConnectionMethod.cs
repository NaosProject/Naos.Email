// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureConnectionMethod.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    /// <summary>
    /// Specifies the method by which the connection is secured.
    /// </summary>
    public enum SecureConnectionMethod
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// The connection should use TLS (or SSL) encryption immediately.
        /// </summary>
        UseTlsOnConnect,

        /// <summary>
        /// Elevates the connection to use TLS encryption immediately after
        /// reading the greeting and capabilities of the server. If the server
        /// does not support the STARTTLS extension, then the connection will
        /// fail and an exception is thrown.
        /// </summary>
        StartTls,
    }
}
