// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailResult.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    /// <summary>
    /// The result of sending an email.
    /// </summary>
    public enum SendEmailResult
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// The email was sent.
        /// </summary>
        Success,

        /// <summary>
        /// The email was not sent; failed to connect to the server.
        /// </summary>
        FailedToConnectToServer,

        /// <summary>
        /// The email was not sent; failed to authenticate with the server.
        /// </summary>
        FailedToAuthenticateWithServer,

        /// <summary>
        /// The email was not sent; failed to prepare the email for sending.
        /// </summary>
        FailedToPrepareEmailForSending,

        /// <summary>
        /// The email was not sent; a failure occurred when sending the email.
        /// </summary>
        FailedToSendEmailToServer,
    }
}
