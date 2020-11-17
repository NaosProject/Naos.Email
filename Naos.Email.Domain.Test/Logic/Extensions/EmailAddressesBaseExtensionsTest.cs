// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressesBaseExtensionsTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain.Test
{
    using System;
    using FakeItEasy;
    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static class EmailAddressesBaseExtensionsTest
    {
        [Fact]
        public static void ToValidatedEmailAddresses___Should_throw_ArgumentNullException___When_parameter_unvalidatedEmailAddresses_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EmailAddressBaseExtensions.ToValidatedEmailAddresses(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("unvalidatedEmailAddresses");
        }

        [Fact]
        public static void ToValidatedEmailAddresses___Should_throw_ArgumentException___When_unvalidatedEmailAddresses_contains_not_valid_email_addresses()
        {
            // Arrange
            var unvalidatedEmailAddresses = A.Dummy<UnvalidatedEmailAddresses>();

            // Act
            var actual = Record.Exception(() => unvalidatedEmailAddresses.ToValidatedEmailAddresses());

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void ToValidatedEmailAddresses___Should_return_a_ValidatedEmailAddresses___When_unvalidatedEmailAddresses_contains_only_valid_email_addresses()
        {
            // Arrange
            var expected = A.Dummy<ValidatedEmailAddresses>();

            var unvalidatedEmailAddresses = new UnvalidatedEmailAddresses(expected.From, expected.To, expected.Cc, expected.Bcc, expected.ReplyTo);

            // Act
            var actual = unvalidatedEmailAddresses.ToValidatedEmailAddresses();

            // Assert
            actual.AsTest().Must().BeEqualTo(expected);
        }
    }
}
