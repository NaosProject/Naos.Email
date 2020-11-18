// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpServerConnectionDefinition.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Locates an SMTP server along with credentials for connecting to the server.
    /// </summary>
    public class SmtpServerConnectionDefinition : IResourceLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpServerConnectionDefinition"/> class.
        /// </summary>
        /// <param name="host">The host to connect to.</param>
        /// <param name="port">The port to connect to.</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <param name="clearTextPassword">The clear text password to use for authentication.</param>
        public SmtpServerConnectionDefinition(
            string host,
            int port,
            string username,
            string clearTextPassword)
        {
            new { host }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { port }.AsArg().Must().BeGreaterThanOrEqualTo(1).And().BeLessThanOrEqualTo(65535);
            new { username }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { clearTextPassword }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.Host = host;
            this.Port = port;
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
        /// Gets the username to use for authentication.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the clear text password to use for authentication.
        /// </summary>
        public string ClearTextPassword { get; private set; }
    }
}
