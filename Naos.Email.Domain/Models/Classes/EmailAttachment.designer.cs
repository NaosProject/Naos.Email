﻿// --------------------------------------------------------------------------------------------------------------------
// <auto-generated>
//   Generated using OBeautifulCode.CodeGen.ModelObject (1.0.137.0)
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using global::System;
    using global::System.CodeDom.Compiler;
    using global::System.Collections.Concurrent;
    using global::System.Collections.Generic;
    using global::System.Collections.ObjectModel;
    using global::System.Diagnostics.CodeAnalysis;
    using global::System.Globalization;
    using global::System.Linq;

    using global::OBeautifulCode.Equality.Recipes;
    using global::OBeautifulCode.Type;
    using global::OBeautifulCode.Type.Recipes;

    using static global::System.FormattableString;

    [Serializable]
    public partial class EmailAttachment : IModel<EmailAttachment>
    {
        /// <summary>
        /// Determines whether two objects of type <see cref="EmailAttachment"/> are equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are equal; otherwise false.</returns>
        public static bool operator ==(EmailAttachment left, EmailAttachment right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            var result = left.Equals(right);

            return result;
        }

        /// <summary>
        /// Determines whether two objects of type <see cref="EmailAttachment"/> are not equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are not equal; otherwise false.</returns>
        public static bool operator !=(EmailAttachment left, EmailAttachment right) => !(left == right);

        /// <inheritdoc />
        public bool Equals(EmailAttachment other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            var result = this.FileBytes.IsEqualTo(other.FileBytes)
                      && this.FileName.IsEqualTo(other.FileName, StringComparer.Ordinal)
                      && this.MediaType.IsEqualTo(other.MediaType)
                      && this.FileNameEncodingKind.IsEqualTo(other.FileNameEncodingKind);

            return result;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as EmailAttachment);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.FileBytes)
            .Hash(this.FileName)
            .Hash(this.MediaType)
            .Hash(this.FileNameEncodingKind)
            .Value;

        /// <inheritdoc />
        public object Clone() => this.DeepClone();

        /// <inheritdoc />
        public EmailAttachment DeepClone()
        {
            var result = new EmailAttachment(
                                 this.FileBytes?.Select(i => i).ToArray(),
                                 this.FileName?.DeepClone(),
                                 this.MediaType,
                                 this.FileNameEncodingKind);

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="FileBytes" />.
        /// </summary>
        /// <param name="fileBytes">The new <see cref="FileBytes" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailAttachment" /> using the specified <paramref name="fileBytes" /> for <see cref="FileBytes" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public EmailAttachment DeepCloneWithFileBytes(byte[] fileBytes)
        {
            var result = new EmailAttachment(
                                 fileBytes,
                                 this.FileName?.DeepClone(),
                                 this.MediaType,
                                 this.FileNameEncodingKind);

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="FileName" />.
        /// </summary>
        /// <param name="fileName">The new <see cref="FileName" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailAttachment" /> using the specified <paramref name="fileName" /> for <see cref="FileName" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public EmailAttachment DeepCloneWithFileName(string fileName)
        {
            var result = new EmailAttachment(
                                 this.FileBytes?.Select(i => i).ToArray(),
                                 fileName,
                                 this.MediaType,
                                 this.FileNameEncodingKind);

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="MediaType" />.
        /// </summary>
        /// <param name="mediaType">The new <see cref="MediaType" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailAttachment" /> using the specified <paramref name="mediaType" /> for <see cref="MediaType" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public EmailAttachment DeepCloneWithMediaType(MediaType mediaType)
        {
            var result = new EmailAttachment(
                                 this.FileBytes?.Select(i => i).ToArray(),
                                 this.FileName?.DeepClone(),
                                 mediaType,
                                 this.FileNameEncodingKind);

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="FileNameEncodingKind" />.
        /// </summary>
        /// <param name="fileNameEncodingKind">The new <see cref="FileNameEncodingKind" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailAttachment" /> using the specified <paramref name="fileNameEncodingKind" /> for <see cref="FileNameEncodingKind" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public EmailAttachment DeepCloneWithFileNameEncodingKind(EncodingKind? fileNameEncodingKind)
        {
            var result = new EmailAttachment(
                                 this.FileBytes?.Select(i => i).ToArray(),
                                 this.FileName?.DeepClone(),
                                 this.MediaType,
                                 fileNameEncodingKind);

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public override string ToString()
        {
            var result = Invariant($"Naos.Email.Domain.EmailAttachment: FileBytes = {this.FileBytes?.ToString() ?? "<null>"}, FileName = {this.FileName?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, MediaType = {this.MediaType.ToString() ?? "<null>"}, FileNameEncodingKind = {this.FileNameEncodingKind?.ToString() ?? "<null>"}.");

            return result;
        }
    }
}