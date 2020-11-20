// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailParticipantsTest.cs" company="Naos Project">
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
    public static partial class EmailParticipantsTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static EmailParticipantsTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'from' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
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
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'to' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
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
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'to' is an empty enumerable scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
                                                 referenceObject.From,
                                                 new List<EmailMailbox>(),
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "to", "is an empty enumerable", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'to' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
                                                 referenceObject.From,
                                                 new EmailMailbox[0].Concat(referenceObject.To).Concat(new EmailMailbox[] { null }).Concat(referenceObject.To).ToList(),
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "to", "contains at least one null element", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'cc' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
                                                 referenceObject.From,
                                                 referenceObject.To,
                                                 new EmailMailbox[0].Concat(referenceObject.Cc).Concat(new EmailMailbox[] { null }).Concat(referenceObject.Cc).ToList(),
                                                 referenceObject.Bcc,
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "cc", "contains at least one null element", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'bcc' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
                                                 referenceObject.From,
                                                 referenceObject.To,
                                                 referenceObject.Cc,
                                                 new EmailMailbox[0].Concat(referenceObject.Bcc).Concat(new EmailMailbox[] { null }).Concat(referenceObject.Bcc).ToList(),
                                                 referenceObject.ReplyTo);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "bcc", "contains at least one null element", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailParticipants>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'replyTo' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailParticipants>();

                            var result = new EmailParticipants(
                                                 referenceObject.From,
                                                 referenceObject.To,
                                                 referenceObject.Cc,
                                                 referenceObject.Bcc,
                                                 new EmailMailbox[0].Concat(referenceObject.ReplyTo).Concat(new EmailMailbox[] { null }).Concat(referenceObject.ReplyTo).ToList());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "replyTo", "contains at least one null element", },
                    });
        }
    }
}