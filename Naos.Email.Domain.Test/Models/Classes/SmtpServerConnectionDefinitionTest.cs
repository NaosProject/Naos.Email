// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpServerConnectionDefinitionTest.cs" company="Naos Project">
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
    public static partial class SmtpServerConnectionDefinitionTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SmtpServerConnectionDefinitionTest()
        {
            ConstructorArgumentValidationTestScenarios
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SmtpServerConnectionDefinition>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'port' is = 0",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SmtpServerConnectionDefinition>();

                            var result = new SmtpServerConnectionDefinition(
                                referenceObject.Host,
                                0,
                                referenceObject.SecureConnectionMethod,
                                referenceObject.Username,
                                referenceObject.ClearTextPassword);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "port", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SmtpServerConnectionDefinition>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'port' is < 0",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SmtpServerConnectionDefinition>();

                            var result = new SmtpServerConnectionDefinition(
                                referenceObject.Host,
                                A.Dummy<NegativeInteger>(),
                                referenceObject.SecureConnectionMethod,
                                referenceObject.Username,
                                referenceObject.ClearTextPassword);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "port", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SmtpServerConnectionDefinition>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'port' is > 65535",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SmtpServerConnectionDefinition>();

                            var result = new SmtpServerConnectionDefinition(
                                referenceObject.Host,
                                65536,
                                referenceObject.SecureConnectionMethod,
                                referenceObject.Username,
                                referenceObject.ClearTextPassword);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "port", },
                    });
        }
    }
}