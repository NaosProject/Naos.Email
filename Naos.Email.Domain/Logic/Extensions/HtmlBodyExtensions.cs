// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlBodyExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System.Diagnostics.CodeAnalysis;

    using Naos.CodeAnalysis.Recipes;

    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Extension methods on <see cref="string"/> HTML bodies.
    /// </summary>
    public static class HtmlBodyExtensions
    {
        /// <summary>
        /// Wraps the specified preview text in a div tag with the correct styling
        /// to have it interpreted as preview text by email clients.
        /// </summary>
        /// <param name="previewText">The preview text.</param>
        /// <returns>
        /// The div tag to use.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Div", Justification = NaosSuppressBecause.CA1704_IdentifiersShouldBeSpelledCorrectly_SpellingIsCorrectInContextOfTheDomain)]
        public static string ToPreviewTextHtmlDiv(
            this string previewText)
        {
            new { previewText }.AsArg().Must().NotBeNullNorWhiteSpace();

            var result = $@"<div style=""display: none; max-height: 0px; overflow: hidden;"">{previewText}</div>";

            return result;
        }
    }
}
