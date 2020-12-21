// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SucceededInSendingEmailEvent{TId}Test.cs" company="Naos Project">
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
    using OBeautifulCode.Equality.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class SucceededInSendingEmailEventTIdTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SucceededInSendingEmailEventTIdTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SucceededInSendingEmailEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'emailResponse' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SucceededInSendingEmailEvent<Version>>();

                            var result = new SucceededInSendingEmailEvent<Version>(
                                                 referenceObject.Id,
                                                 referenceObject.TimestampUtc,
                                                 null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "emailResponse", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SucceededInSendingEmailEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when emailResponse.SendEmailResult != SendEmailRequest.Success scenario",
                        ConstructionFunc = () =>
                        {
                            var emailFailedToSendEvent = A.Dummy<FailedToSendEmailEvent<Version>>();

                            var result = new SucceededInSendingEmailEvent<Version>(emailFailedToSendEvent.Id, emailFailedToSendEvent.TimestampUtc, emailFailedToSendEvent.EmailResponse);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "emailResponse.SendEmailResult", "Success" },
                    });
        }
    }
}