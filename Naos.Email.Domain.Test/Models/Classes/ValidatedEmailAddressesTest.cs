// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatedEmailAddressesTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using FakeItEasy;

    using OBeautifulCode.AutoFakeItEasy;
    using OBeautifulCode.CodeAnalysis.Recipes;
    using OBeautifulCode.CodeGen.ModelObject.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class ValidatedEmailAddressesTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static ValidatedEmailAddressesTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'from' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 null,
                                                 referenceObject.To,
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "from", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'from' is white space scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 Invariant($"  {Environment.NewLine}  "),
                                                 referenceObject.To,
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "from", "white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'from' is not a valid email address scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                Invariant($"not-a-valid-email-address"),
                                referenceObject.To,
                                referenceObject.Cc,
                                referenceObject.Bcc,
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "is not a valid email address", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'to' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 referenceObject.From,
                                                 null,
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "to", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'to' is an empty enumerable scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 referenceObject.From,
                                                 new List<string>(),
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "to", "is an empty enumerable", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'to' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 referenceObject.From,
                                                 new string[0].Concat(referenceObject.To).Concat(new string[] { null }).Concat(referenceObject.To).ToList(),
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "to", "contains at least one null element", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'to' contains a white space element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                new string[0].Concat(referenceObject.To).Concat(new string[] { "  \r\n  " }).Concat(referenceObject.To).ToList(),
                                referenceObject.Cc,
                                referenceObject.Bcc,
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "to", "contains an element that is white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'to' contains an element that is not a valid email address scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                new string[0].Concat(referenceObject.To).Concat(new string[] { "not-valid-email-address" }).Concat(referenceObject.To).ToList(),
                                referenceObject.Cc,
                                referenceObject.Bcc,
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "to", "is not a valid email address", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'cc' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 referenceObject.From,
                                                 referenceObject.To,
                                                 new string[0].Concat(referenceObject.Cc).Concat(new string[] { null }).Concat(referenceObject.Cc).ToList(),
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "cc", "contains an element that is null", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'cc' contains a white space element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                referenceObject.To,
                                new string[0].Concat(referenceObject.Cc).Concat(new string[] { " \r\n " }).Concat(referenceObject.Cc).ToList(),
                                referenceObject.Bcc,
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "cc", "contains an element that is white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'cc' contains an element that is not a valid email address scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                referenceObject.To,
                                new string[0].Concat(referenceObject.Cc).Concat(new string[] { "not-valid-email-address" }).Concat(referenceObject.Cc).ToList(),
                                referenceObject.Bcc,
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "cc", "is not a valid email address", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'bcc' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 referenceObject.From,
                                                 referenceObject.To,
                                                 referenceObject.Cc,
                                                 new string[0].Concat(referenceObject.Bcc).Concat(new string[] { null }).Concat(referenceObject.Bcc).ToList(),
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "bcc", "contains an element that is null", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'bcc' contains a white space element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                referenceObject.To,
                                referenceObject.Cc,
                                new string[0].Concat(referenceObject.Bcc).Concat(new string[] { " \r\n " }).Concat(referenceObject.Bcc).ToList(),
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "bcc", "contains an element that is white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'bcc' contains an element that is not a valid email address scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                referenceObject.To,
                                referenceObject.Cc,
                                new string[0].Concat(referenceObject.Bcc).Concat(new string[] { "not-valid-email-address" }).Concat(referenceObject.Bcc).ToList(),
                                referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "bcc", "is not a valid email address", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'replyTo' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                                 referenceObject.From,
                                                 referenceObject.To,
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 new string[0].Concat(referenceObject.ReplyTo).Concat(new string[] { null }).Concat(referenceObject.ReplyTo).ToList());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "replyTo", "contains an element that is null", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'replyTo' contains a white space element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                referenceObject.To,
                                referenceObject.Cc,
                                referenceObject.Bcc,
                                new string[0].Concat(referenceObject.ReplyTo).Concat(new string[] { " \r\n " }).Concat(referenceObject.ReplyTo).ToList());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "replyTo", "contains an element that is white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<ValidatedEmailAddresses>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'replyTo' contains an element that is not a valid email address scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<ValidatedEmailAddresses>();

                            var result = new ValidatedEmailAddresses(
                                referenceObject.From,
                                referenceObject.To,
                                referenceObject.Cc,
                                referenceObject.Bcc,
                                new string[0].Concat(referenceObject.ReplyTo).Concat(new string[] { "not-valid-email-address" }).Concat(referenceObject.ReplyTo).ToList());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "replyTo", "is not a valid email address", },
                    });
        }
    }
}