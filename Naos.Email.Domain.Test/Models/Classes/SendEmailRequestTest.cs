// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailRequestTest.cs" company="Naos Project">
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
    public static partial class SendEmailRequestTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SendEmailRequestTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendEmailRequest>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'emailParticipants' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendEmailRequest>();

                            var result = new SendEmailRequest(
                                                 null,
                                                 referenceObject.EmailContent,
                                                 referenceObject.EmailOptions);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "emailParticipants", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendEmailRequest>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'emailContent' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendEmailRequest>();

                            var result = new SendEmailRequest(
                                                 referenceObject.EmailParticipants,
                                                 null,
                                                 referenceObject.EmailOptions);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "emailContent", },
                    });
        }
    }
}