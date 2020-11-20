// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailContentTest.cs" company="Naos Project">
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
    public static partial class EmailContentTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static EmailContentTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailContent>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'attachments' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailContent>();

                            var result = new EmailContent(
                                                 referenceObject.Subject,
                                                 referenceObject.PlainTextBody,
                                                 referenceObject.HtmlBody,
                                                 new EmailAttachment[0].Concat(referenceObject.Attachments).Concat(new EmailAttachment[] { null }).Concat(referenceObject.Attachments).ToList(),
                                                 referenceObject.ContentIdToHtmlBodyLinkedResourceMap,
                                                 referenceObject.SubjectEncodingKind,
                                                 referenceObject.PlainTextBodyEncodingKind,
                                                 referenceObject.HtmlBodyEncodingKind);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "attachments", "contains at least one null element", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailContent>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'contentIdToHtmlBodyLinkedResourceMap' contains a key-value pair with a white space key scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailContent>();

                            var dictionaryWithWhiteSpaceKey = referenceObject.ContentIdToHtmlBodyLinkedResourceMap.ToDictionary(_ => _.Key, _ => _.Value);

                            dictionaryWithWhiteSpaceKey.Add(" \r\n ", A.Dummy<EmailAttachment>());

                            var result = new EmailContent(
                                                 referenceObject.Subject,
                                                 referenceObject.PlainTextBody,
                                                 referenceObject.HtmlBody,
                                                 referenceObject.Attachments,
                                                 dictionaryWithWhiteSpaceKey,
                                                 referenceObject.SubjectEncodingKind,
                                                 referenceObject.PlainTextBodyEncodingKind,
                                                 referenceObject.HtmlBodyEncodingKind);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "contentIdToHtmlBodyLinkedResourceMap.Keys", "contains an element that is white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<EmailContent>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'contentIdToHtmlBodyLinkedResourceMap' contains a key-value pair with a null value scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<EmailContent>();

                            var dictionaryWithNullValue = referenceObject.ContentIdToHtmlBodyLinkedResourceMap.ToDictionary(_ => _.Key, _ => _.Value);

                            var randomKey = dictionaryWithNullValue.Keys.ElementAt(ThreadSafeRandom.Next(0, dictionaryWithNullValue.Count));

                            dictionaryWithNullValue[randomKey] = null;

                            var result = new EmailContent(
                                                 referenceObject.Subject,
                                                 referenceObject.PlainTextBody,
                                                 referenceObject.HtmlBody,
                                                 referenceObject.Attachments,
                                                 dictionaryWithNullValue,
                                                 referenceObject.SubjectEncodingKind,
                                                 referenceObject.PlainTextBodyEncodingKind,
                                                 referenceObject.HtmlBodyEncodingKind);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "contentIdToHtmlBodyLinkedResourceMap", "contains at least one key-value pair with a null value", },
                    });
        }
    }
}