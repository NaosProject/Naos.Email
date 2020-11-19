// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMailboxExtensionsTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain.Test
{
    using System;
    using FakeItEasy;
    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static class EmailMailboxExtensionsTest
    {
        [Fact]
        public static void ToMailAddress___Should_throw_ArgumentNullException___When_parameter_emailMailbox_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EmailMailboxExtensions.ToMailAddress(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("emailMailbox");
        }

        [Fact]
        public static void ToMailAddress___Should_throw_ArgumentException___When_emailMailbox_contains_not_valid_email_address()
        {
            // Arrange
            var emailMailbox = new EmailMailbox(A.Dummy<string>());

            // Act
            var actual = Record.Exception(() => emailMailbox.ToMailAddress());

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("emailMailbox.Address");
        }

        [Fact]
        public static void ToMailAddress___Should_return_a_MailAddress___When_emailMailbox_contains_valid_email_address()
        {
            // Arrange
            var emailMailbox = A.Dummy<EmailMailbox>();

            // Act
            var actual = emailMailbox.ToMailAddress();

            // Assert
            actual.DisplayName.AsTest().Must().BeEqualTo(emailMailbox.Name);
            actual.Address.AsTest().Must().BeEqualTo(emailMailbox.Address);
        }
    }
}
