// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAttachmentTest.cs" company="Naos Project">
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
    public static partial class EmailAttachmentTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static EmailAttachmentTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailAttachment>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'fileBytes' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailAttachment>();

                            var result = new EmailAttachment(
                                                 null,
                                                 referenceObject.FileName,
                                                 referenceObject.MediaType,
                                                 referenceObject.FileNameEncodingKind);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "fileBytes", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailAttachment>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'fileBytes' is an empty enumerable scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailAttachment>();

                            var result = new EmailAttachment(
                                                 new byte[0],
                                                 referenceObject.FileName,
                                                 referenceObject.MediaType,
                                                 referenceObject.FileNameEncodingKind);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "fileBytes", "is an empty enumerable", },
                    });
        }
    }
}