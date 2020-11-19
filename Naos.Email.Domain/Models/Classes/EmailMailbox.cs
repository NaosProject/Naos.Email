// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMailbox.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// The address of an electronic mail sender or recipient.
    /// </summary>
    public partial class EmailMailbox : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMailbox"/> class.
        /// </summary>
        /// <param name="address">The email address.</param>
        /// <param name="name">OPTIONAL name of the mailbox.  DEFAULT is to not specify a name.</param>
        public EmailMailbox(
            string address,
            string name = null)
        {
            new { address }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.Address = address;
            this.Name = name;
        }

        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the mailbox.
        /// </summary>
        public string Address { get; private set; }
    }
}
