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
    public partial class EmailParticipants : IModel<EmailParticipants>
    {
        /// <summary>
        /// Determines whether two objects of type <see cref="EmailParticipants"/> are equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are equal; otherwise false.</returns>
        public static bool operator ==(EmailParticipants left, EmailParticipants right)
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
        /// Determines whether two objects of type <see cref="EmailParticipants"/> are not equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are not equal; otherwise false.</returns>
        public static bool operator !=(EmailParticipants left, EmailParticipants right) => !(left == right);

        /// <inheritdoc />
        public bool Equals(EmailParticipants other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            var result = this.From.IsEqualTo(other.From)
                      && this.To.IsEqualTo(other.To)
                      && this.Cc.IsEqualTo(other.Cc)
                      && this.Bcc.IsEqualTo(other.Bcc)
                      && this.ReplyTo.IsEqualTo(other.ReplyTo);

            return result;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as EmailParticipants);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.From)
            .Hash(this.To)
            .Hash(this.Cc)
            .Hash(this.Bcc)
            .Hash(this.ReplyTo)
            .Value;

        /// <inheritdoc />
        public object Clone() => this.DeepClone();

        /// <inheritdoc />
        public EmailParticipants DeepClone()
        {
            var result = new EmailParticipants(
                                 this.From?.DeepClone(),
                                 this.To?.Select(i => i?.DeepClone()).ToList(),
                                 this.Cc?.Select(i => i?.DeepClone()).ToList(),
                                 this.Bcc?.Select(i => i?.DeepClone()).ToList(),
                                 this.ReplyTo?.Select(i => i?.DeepClone()).ToList());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="From" />.
        /// </summary>
        /// <param name="from">The new <see cref="From" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailParticipants" /> using the specified <paramref name="from" /> for <see cref="From" /> and a deep clone of every other property.</returns>
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
        public EmailParticipants DeepCloneWithFrom(EmailMailbox from)
        {
            var result = new EmailParticipants(
                                 from,
                                 this.To?.Select(i => i?.DeepClone()).ToList(),
                                 this.Cc?.Select(i => i?.DeepClone()).ToList(),
                                 this.Bcc?.Select(i => i?.DeepClone()).ToList(),
                                 this.ReplyTo?.Select(i => i?.DeepClone()).ToList());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="To" />.
        /// </summary>
        /// <param name="to">The new <see cref="To" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailParticipants" /> using the specified <paramref name="to" /> for <see cref="To" /> and a deep clone of every other property.</returns>
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
        public EmailParticipants DeepCloneWithTo(IReadOnlyCollection<EmailMailbox> to)
        {
            var result = new EmailParticipants(
                                 this.From?.DeepClone(),
                                 to,
                                 this.Cc?.Select(i => i?.DeepClone()).ToList(),
                                 this.Bcc?.Select(i => i?.DeepClone()).ToList(),
                                 this.ReplyTo?.Select(i => i?.DeepClone()).ToList());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Cc" />.
        /// </summary>
        /// <param name="cc">The new <see cref="Cc" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailParticipants" /> using the specified <paramref name="cc" /> for <see cref="Cc" /> and a deep clone of every other property.</returns>
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
        public EmailParticipants DeepCloneWithCc(IReadOnlyCollection<EmailMailbox> cc)
        {
            var result = new EmailParticipants(
                                 this.From?.DeepClone(),
                                 this.To?.Select(i => i?.DeepClone()).ToList(),
                                 cc,
                                 this.Bcc?.Select(i => i?.DeepClone()).ToList(),
                                 this.ReplyTo?.Select(i => i?.DeepClone()).ToList());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Bcc" />.
        /// </summary>
        /// <param name="bcc">The new <see cref="Bcc" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailParticipants" /> using the specified <paramref name="bcc" /> for <see cref="Bcc" /> and a deep clone of every other property.</returns>
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
        public EmailParticipants DeepCloneWithBcc(IReadOnlyCollection<EmailMailbox> bcc)
        {
            var result = new EmailParticipants(
                                 this.From?.DeepClone(),
                                 this.To?.Select(i => i?.DeepClone()).ToList(),
                                 this.Cc?.Select(i => i?.DeepClone()).ToList(),
                                 bcc,
                                 this.ReplyTo?.Select(i => i?.DeepClone()).ToList());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="ReplyTo" />.
        /// </summary>
        /// <param name="replyTo">The new <see cref="ReplyTo" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="EmailParticipants" /> using the specified <paramref name="replyTo" /> for <see cref="ReplyTo" /> and a deep clone of every other property.</returns>
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
        public EmailParticipants DeepCloneWithReplyTo(IReadOnlyCollection<EmailMailbox> replyTo)
        {
            var result = new EmailParticipants(
                                 this.From?.DeepClone(),
                                 this.To?.Select(i => i?.DeepClone()).ToList(),
                                 this.Cc?.Select(i => i?.DeepClone()).ToList(),
                                 this.Bcc?.Select(i => i?.DeepClone()).ToList(),
                                 replyTo);

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public override string ToString()
        {
            var result = Invariant($"Naos.Email.Domain.EmailParticipants: From = {this.From?.ToString() ?? "<null>"}, To = {this.To?.ToString() ?? "<null>"}, Cc = {this.Cc?.ToString() ?? "<null>"}, Bcc = {this.Bcc?.ToString() ?? "<null>"}, ReplyTo = {this.ReplyTo?.ToString() ?? "<null>"}.");

            return result;
        }
    }
}