// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMailboxTest.cs" company="Naos Project">
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
    public static partial class EmailMailboxTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static EmailMailboxTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailMailbox>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'address' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailMailbox>();

                            var result = new EmailMailbox(
                                                 null,
                                                 referenceObject.Name);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "address", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailMailbox>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'address' is white space scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailMailbox>();

                            var result = new EmailMailbox(
                                                 Invariant($"  {Environment.NewLine}  "),
                                                 referenceObject.Name);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "address", "white space", },
                    });
        }
    }
}