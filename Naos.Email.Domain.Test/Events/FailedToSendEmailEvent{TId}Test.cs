// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedToSendEmailEvent{TId}Test.cs" company="Naos Project">
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
    public static partial class FailedToSendEmailEventTIdTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static FailedToSendEmailEventTIdTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<FailedToSendEmailEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'sendEmailResponse' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<FailedToSendEmailEvent<Version>>();

                            var result = new FailedToSendEmailEvent<Version>(
                                                 referenceObject.Id,
                                                 referenceObject.TimestampUtc,
                                                 null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "sendEmailResponse", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<FailedToSendEmailEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when sendEmailResponse.SendEmailResult == SendEmailRequest.Success scenario",
                        ConstructionFunc = () =>
                        {
                            var emailSentEvent = A.Dummy<SucceededInSendingEmailEvent<Version>>();

                            var result = new FailedToSendEmailEvent<Version>(emailSentEvent.Id, emailSentEvent.TimestampUtc, emailSentEvent.SendEmailResponse);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "sendEmailResponse.SendEmailResult", "Success" },
                    });
        }
    }
}