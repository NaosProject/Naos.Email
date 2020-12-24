// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailResponseTest.cs" company="Naos Project">
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
    public static partial class SendEmailResponseTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SendEmailResponseTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendEmailResponse>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'sendEmailResult' is SendEmailResult.Unknown scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendEmailResponse>();

                            var result = new SendEmailResponse(
                                SendEmailResult.Unknown,
                                referenceObject.ExceptionToString,
                                referenceObject.CommunicationLog);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "sendEmailResult", "Unknown" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendEmailResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'sendEmailResult' is SendEmailResult.Success and 'exceptionToString' is not null",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendEmailResponse>();

                            var result = new SendEmailResponse(
                                                 SendEmailResult.Success,
                                                 "  \r\n  ",
                                                 referenceObject.CommunicationLog);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "When sendEmailResult indicates success, exceptionToString must be null", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendEmailResponse>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'sendEmailResult' is not SendEmailResult.Success and 'exceptionToString' is null",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendEmailResponse>();

                            var result = new SendEmailResponse(
                                A.Dummy<SendEmailResult>().ThatIsNot(SendEmailResult.Success),
                                null,
                                referenceObject.CommunicationLog);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "When sendEmailResult indicates a failure, exceptionToString must not be null nor white space.", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendEmailResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'sendEmailResult' is not SendEmailResult.Success and 'exceptionToString' is white space",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendEmailResponse>();

                            var result = new SendEmailResponse(
                                                 A.Dummy<SendEmailResult>().ThatIsNot(SendEmailResult.Success),
                                                 Invariant($"  {Environment.NewLine}  "),
                                                 referenceObject.CommunicationLog);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "When sendEmailResult indicates a failure, exceptionToString must not be null nor white space.", },
                    });

            DeepCloneWithTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<SendEmailResponse>
                    {
                        Name = "DeepCloneWithSendEmailResult should deep clone object and replace SendEmailResult with the provided sendEmailResult",
                        WithPropertyName = "SendEmailResult",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<SendEmailResponse>();

                            var sendEmailResult = systemUnderTest.SendEmailResult == SendEmailResult.Success
                                ? SendEmailResult.Success
                                : A.Dummy<SendEmailResult>().ThatIs(_ => (_ != SendEmailResult.Success) && (_ != systemUnderTest.SendEmailResult));

                            var result = new SystemUnderTestDeepCloneWithValue<SendEmailResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = sendEmailResult,
                            };

                            return result;
                        },
                    })
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<SendEmailResponse>
                    {
                        Name = "DeepCloneWithExceptionToString should deep clone object and replace ExceptionToString with the provided exceptionToString",
                        WithPropertyName = "ExceptionToString",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<SendEmailResponse>();

                            var exceptionToString = systemUnderTest.SendEmailResult == SendEmailResult.Success
                                ? null
                                : A.Dummy<string>().ThatIsNot(systemUnderTest.ExceptionToString);

                            var result = new SystemUnderTestDeepCloneWithValue<SendEmailResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = exceptionToString,
                            };

                            return result;
                        },
                    })
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<SendEmailResponse>
                    {
                        Name = "DeepCloneWithCommunicationLog should deep clone object and replace CommunicationLog with the provided communicationLog",
                        WithPropertyName = "CommunicationLog",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<SendEmailResponse>();

                            var referenceObject = A.Dummy<SendEmailResponse>().ThatIs(_ => !systemUnderTest.CommunicationLog.IsEqualTo(_.CommunicationLog));

                            var result = new SystemUnderTestDeepCloneWithValue<SendEmailResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.CommunicationLog,
                            };

                            return result;
                        },
                    });

            EquatableTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new EquatableTestScenario<SendEmailResponse>
                    {
                        Name = "Equatable Scenario",
                        ReferenceObject = ReferenceObjectForEquatableTestScenarios,
                        ObjectsThatAreEqualToButNotTheSameAsReferenceObject = new SendEmailResponse[]
                        {
                            new SendEmailResponse(
                                    ReferenceObjectForEquatableTestScenarios.SendEmailResult,
                                    ReferenceObjectForEquatableTestScenarios.ExceptionToString,
                                    ReferenceObjectForEquatableTestScenarios.CommunicationLog),
                        },
                        ObjectsThatAreNotEqualToReferenceObject = new SendEmailResponse[]
                        {
                            // If SendEmailResult == Success, we can just tweak that parameter
                            // because the constructor will throw when it finds a null ExceptionToString,
                            // so we'll just tweak CommunicationLog.  Setting to null breaks the test.
                            ReferenceObjectForEquatableTestScenarios.SendEmailResult == SendEmailResult.Success
                                ? new SendEmailResponse(SendEmailResult.Success, null, A.Dummy<string>())
                                : new SendEmailResponse(
                                    A.Dummy<SendEmailResponse>().Whose(_ => !_.SendEmailResult.IsEqualTo(ReferenceObjectForEquatableTestScenarios.SendEmailResult) && (_.SendEmailResult != SendEmailResult.Success)).SendEmailResult,
                                    ReferenceObjectForEquatableTestScenarios.ExceptionToString,
                                    ReferenceObjectForEquatableTestScenarios.CommunicationLog),

                            // If SendEmailResult == Success, we can just tweak that parameter
                            // because the constructor will throw when it finds a null ExceptionToString
                            // so we'll just tweak CommunicationLog.  Setting to null breaks the test.
                            ReferenceObjectForEquatableTestScenarios.SendEmailResult == SendEmailResult.Success
                                ? new SendEmailResponse(SendEmailResult.Success, null, A.Dummy<string>())
                                : new SendEmailResponse(
                                    ReferenceObjectForEquatableTestScenarios.SendEmailResult,
                                    A.Dummy<SendEmailResponse>().Whose(_ => !_.ExceptionToString.IsEqualTo(ReferenceObjectForEquatableTestScenarios.ExceptionToString) && (_.SendEmailResult != SendEmailResult.Success)).ExceptionToString,
                                    ReferenceObjectForEquatableTestScenarios.CommunicationLog),

                            new SendEmailResponse(
                                    ReferenceObjectForEquatableTestScenarios.SendEmailResult,
                                    ReferenceObjectForEquatableTestScenarios.ExceptionToString,
                                    A.Dummy<SendEmailResponse>().Whose(_ => !_.CommunicationLog.IsEqualTo(ReferenceObjectForEquatableTestScenarios.CommunicationLog)).CommunicationLog),
                        },
                        ObjectsThatAreNotOfTheSameTypeAsReferenceObject = new object[]
                        {
                            A.Dummy<object>(),
                            A.Dummy<string>(),
                            A.Dummy<int>(),
                            A.Dummy<int?>(),
                            A.Dummy<Guid>(),
                        },
                    });
        }
    }
}