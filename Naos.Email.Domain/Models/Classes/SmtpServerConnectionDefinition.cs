﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpServerConnectionDefinition.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Locates an SMTP server along with credentials for connecting to the server.
    /// </summary>
    public partial class SmtpServerConnectionDefinition : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpServerConnectionDefinition"/> class.
        /// </summary>
        /// <param name="host">The host to connect to.</param>
        /// <param name="port">The port to connect to.</param>
        /// <param name="secureConnectionMethod">The method by which the connection is secured.</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <param name="clearTextPassword">The clear text password to use for authentication.</param>
        public SmtpServerConnectionDefinition(
            string host,
            int port,
            SecureConnectionMethod secureConnectionMethod,
            string username,
            string clearTextPassword)
        {
            new { host }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { port }.AsArg().Must().BeGreaterThanOrEqualTo(1).And().BeLessThanOrEqualTo(65535);
            new { secureConnectionMethod }.AsArg().Must().NotBeEqualTo(SecureConnectionMethod.Unknown);
            new { username }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { clearTextPassword }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.Host = host;
            this.Port = port;
            this.SecureConnectionMethod = secureConnectionMethod;
            this.Username = username;
            this.ClearTextPassword = clearTextPassword;
        }

        /// <summary>
        /// Gets the host to connect to.
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Gets the port to connect to.
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Gets the method by which the connection is secured.
        /// </summary>
        public SecureConnectionMethod SecureConnectionMethod { get; private set; }

        /// <summary>
        /// Gets the username to use for authentication.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the clear text password to use for authentication.
        /// </summary>
        public string ClearTextPassword { get; private set; }
    }
}
