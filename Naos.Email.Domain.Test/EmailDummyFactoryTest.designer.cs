﻿// --------------------------------------------------------------------------------------------------------------------
// <auto-generated>
//   Generated using OBeautifulCode.CodeGen.ModelObject (1.0.178.0)
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain.Test
{
    using global::System.CodeDom.Compiler;
    using global::System.Diagnostics.CodeAnalysis;

    using global::FakeItEasy;

    using global::OBeautifulCode.Assertion.Recipes;

    using global::Xunit;

    [ExcludeFromCodeCoverage]
    [GeneratedCode("OBeautifulCode.CodeGen.ModelObject", "1.0.178.0")]
    public static partial class EmailDummyFactoryTest
    {
        [Fact]
        public static void EmailDummyFactory___Should_derive_from_DefaultEmailDummyFactory___When_reflecting()
        {
            // Arrange
            var dummyFactoryType = typeof(EmailDummyFactory);

            var defaultDummyFactoryType = typeof(DefaultEmailDummyFactory);

            // Act, Assert
            defaultDummyFactoryType.GetInterface(nameof(IDummyFactory)).AsTest().Must().NotBeNull();

            dummyFactoryType.BaseType.AsTest().Must().BeEqualTo(defaultDummyFactoryType);
        }
    }
}