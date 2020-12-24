﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailDummyFactory.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package Naos.Build.Conventions.VisualStudioProjectTemplates.Domain.Test (1.55.46)
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain.Test
{
    using System;
    using System.Linq;
    using System.Net.Mail;

    using FakeItEasy;

    using OBeautifulCode.AutoFakeItEasy;
    using OBeautifulCode.Enum.Recipes;
    using OBeautifulCode.Math.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// A Dummy Factory for types in <see cref="Naos.Email.Domain"/>.
    /// </summary>
#if !NaosEmailSolution
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Naos.Email.Domain.Test", "See package version number")]
    internal
#else
    public
#endif
    class EmailDummyFactory : DefaultEmailDummyFactory
    {
        public EmailDummyFactory()
        {
            AutoFixtureBackedDummyFactory.ConstrainDummyToExclude(SecureConnectionMethod.Unknown);
            AutoFixtureBackedDummyFactory.ConstrainDummyToExclude(SendEmailResult.Unknown);

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                // DeliveryNotificationOptions.Never cannot be used in combination with any other flag
                // otherwise adding options to the MailMessage will throw.
                var validValues = EnumExtensions.GetAllPossibleEnumValues<DeliveryNotificationOptions>().Where(_ => !_.HasFlag(DeliveryNotificationOptions.Never)).ToList();

                var indexToUse = ThreadSafeRandom.Next(0, validValues.Count);

                var result = validValues[indexToUse];

                return result;
            });

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                var result = new SmtpServerConnectionDefinition(A.Dummy<string>(), A.Dummy<PositiveInteger>().ThatIs(_=> _ < 65000), A.Dummy<SecureConnectionMethod>(), A.Dummy<string>(), A.Dummy<string>());

                return result;
            });

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                var address = Invariant($"{A.Dummy<Guid>()}@example.com");

                var firstNames = new[] { "Bob", "Sara", "Jane", "Joe", "Tommy", "Nora" };

                var lastNames = new[] { "Jones", "Smith", "Tailor", "Wright", "Glass", "Willis" };

                var firstNameIndex = ThreadSafeRandom.Next(0, firstNames.Length);

                var lastNameIndex = ThreadSafeRandom.Next(0, lastNames.Length);

                var name = firstNames[firstNameIndex] + " " + lastNames[lastNameIndex];

                var result = new EmailMailbox(address, name);

                return result;
            });

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                var result = new SendEmailRequestedEvent<Version>(A.Dummy<Version>(), A.Dummy<DateTime>().ToUniversalTime(), A.Dummy<SendEmailRequest>());

                return result;
            });

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                var emailResponse = new SendEmailResponse(A.Dummy<SendEmailResult>().ThatIsNot(SendEmailResult.Success), A.Dummy<string>());

                var result = new FailedToSendEmailEvent<Version>(A.Dummy<Version>(), A.Dummy<DateTime>().ToUniversalTime(), emailResponse);

                return result;
            });

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                var emailResponse = new SendEmailResponse(SendEmailResult.Success, null, A.Dummy<string>());

                var result = new SucceededInSendingEmailEvent<Version>(A.Dummy<Version>(), A.Dummy<DateTime>().ToUniversalTime(), emailResponse);

                return result;
            });

            AutoFixtureBackedDummyFactory.AddDummyCreator(() =>
            {
                var sendEmailResult = A.Dummy<SendEmailResult>();

                var exceptionToString = sendEmailResult == SendEmailResult.Success
                    ? null
                    : A.Dummy<string>();

                var communicationLog = A.Dummy<string>();

                var result = new SendEmailResponse(sendEmailResult, exceptionToString, communicationLog);

                return result;
            });
        }
    }
}