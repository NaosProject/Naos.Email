// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailOptions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Net.Mail;

    using OBeautifulCode.Type;

    /// <summary>
    /// Some options/instructions about an email.
    /// </summary>
    public partial class EmailOptions : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailOptions"/> class.
        /// </summary>
        /// <param name="priority">OPTIONAL value that specifies the priority of the email.  DEFAULT is to use the system default.</param>
        /// <param name="deliveryNotification">OPTIONAL value that specifies the requested delivery notifications.  DEFAULT is to use the system default.</param>
        public EmailOptions(
            MailPriority? priority = null,
            DeliveryNotificationOptions? deliveryNotification = null)
        {
            this.Priority = priority;
            this.DeliveryNotification = deliveryNotification;
        }

        /// <summary>
        /// Gets a value that specifies the priority of the email.
        /// </summary>
        public MailPriority? Priority { get; private set; }

        /// <summary>
        /// Gets a value that specifies the requested delivery notifications.
        /// </summary>
        public DeliveryNotificationOptions? DeliveryNotification { get; private set; }
    }
}
