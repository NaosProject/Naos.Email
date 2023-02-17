﻿// --------------------------------------------------------------------------------------------------------------------
// <auto-generated>
//   Generated using OBeautifulCode.CodeGen.ModelObject (1.0.178.0)
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

    using global::OBeautifulCode.Cloning.Recipes;
    using global::OBeautifulCode.Equality.Recipes;
    using global::OBeautifulCode.Type;
    using global::OBeautifulCode.Type.Recipes;

    using static global::System.FormattableString;

    [Serializable]
    public partial class SmtpServerConnectionDefinition : IModel<SmtpServerConnectionDefinition>
    {
        /// <summary>
        /// Determines whether two objects of type <see cref="SmtpServerConnectionDefinition"/> are equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are equal; otherwise false.</returns>
        public static bool operator ==(SmtpServerConnectionDefinition left, SmtpServerConnectionDefinition right)
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
        /// Determines whether two objects of type <see cref="SmtpServerConnectionDefinition"/> are not equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are not equal; otherwise false.</returns>
        public static bool operator !=(SmtpServerConnectionDefinition left, SmtpServerConnectionDefinition right) => !(left == right);

        /// <inheritdoc />
        public bool Equals(SmtpServerConnectionDefinition other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            var result = this.Host.IsEqualTo(other.Host, StringComparer.Ordinal)
                      && this.Port.IsEqualTo(other.Port)
                      && this.SecureConnectionMethod.IsEqualTo(other.SecureConnectionMethod)
                      && this.Username.IsEqualTo(other.Username, StringComparer.Ordinal)
                      && this.ClearTextPassword.IsEqualTo(other.ClearTextPassword, StringComparer.Ordinal);

            return result;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as SmtpServerConnectionDefinition);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.Host)
            .Hash(this.Port)
            .Hash(this.SecureConnectionMethod)
            .Hash(this.Username)
            .Hash(this.ClearTextPassword)
            .Value;

        /// <inheritdoc />
        public object Clone() => this.DeepClone();

        /// <inheritdoc />
        public SmtpServerConnectionDefinition DeepClone()
        {
            var result = new SmtpServerConnectionDefinition(
                                 this.Host?.DeepClone(),
                                 this.Port.DeepClone(),
                                 this.SecureConnectionMethod.DeepClone(),
                                 this.Username?.DeepClone(),
                                 this.ClearTextPassword?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Host" />.
        /// </summary>
        /// <param name="host">The new <see cref="Host" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SmtpServerConnectionDefinition" /> using the specified <paramref name="host" /> for <see cref="Host" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
        public SmtpServerConnectionDefinition DeepCloneWithHost(string host)
        {
            var result = new SmtpServerConnectionDefinition(
                                 host,
                                 this.Port.DeepClone(),
                                 this.SecureConnectionMethod.DeepClone(),
                                 this.Username?.DeepClone(),
                                 this.ClearTextPassword?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Port" />.
        /// </summary>
        /// <param name="port">The new <see cref="Port" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SmtpServerConnectionDefinition" /> using the specified <paramref name="port" /> for <see cref="Port" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
        public SmtpServerConnectionDefinition DeepCloneWithPort(int port)
        {
            var result = new SmtpServerConnectionDefinition(
                                 this.Host?.DeepClone(),
                                 port,
                                 this.SecureConnectionMethod.DeepClone(),
                                 this.Username?.DeepClone(),
                                 this.ClearTextPassword?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="SecureConnectionMethod" />.
        /// </summary>
        /// <param name="secureConnectionMethod">The new <see cref="SecureConnectionMethod" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SmtpServerConnectionDefinition" /> using the specified <paramref name="secureConnectionMethod" /> for <see cref="SecureConnectionMethod" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
        public SmtpServerConnectionDefinition DeepCloneWithSecureConnectionMethod(SecureConnectionMethod secureConnectionMethod)
        {
            var result = new SmtpServerConnectionDefinition(
                                 this.Host?.DeepClone(),
                                 this.Port.DeepClone(),
                                 secureConnectionMethod,
                                 this.Username?.DeepClone(),
                                 this.ClearTextPassword?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Username" />.
        /// </summary>
        /// <param name="username">The new <see cref="Username" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SmtpServerConnectionDefinition" /> using the specified <paramref name="username" /> for <see cref="Username" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
        public SmtpServerConnectionDefinition DeepCloneWithUsername(string username)
        {
            var result = new SmtpServerConnectionDefinition(
                                 this.Host?.DeepClone(),
                                 this.Port.DeepClone(),
                                 this.SecureConnectionMethod.DeepClone(),
                                 username,
                                 this.ClearTextPassword?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="ClearTextPassword" />.
        /// </summary>
        /// <param name="clearTextPassword">The new <see cref="ClearTextPassword" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SmtpServerConnectionDefinition" /> using the specified <paramref name="clearTextPassword" /> for <see cref="ClearTextPassword" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
        public SmtpServerConnectionDefinition DeepCloneWithClearTextPassword(string clearTextPassword)
        {
            var result = new SmtpServerConnectionDefinition(
                                 this.Host?.DeepClone(),
                                 this.Port.DeepClone(),
                                 this.SecureConnectionMethod.DeepClone(),
                                 this.Username?.DeepClone(),
                                 clearTextPassword);

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public override string ToString()
        {
            var result = Invariant($"Naos.Email.Domain.SmtpServerConnectionDefinition: Host = {this.Host?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, Port = {this.Port.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, SecureConnectionMethod = {this.SecureConnectionMethod.ToString() ?? "<null>"}, Username = {this.Username?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, ClearTextPassword = {this.ClearTextPassword?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}.");

            return result;
        }
    }
}