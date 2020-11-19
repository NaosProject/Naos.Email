// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailProtocolTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Protocol.Client.Test
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Naos.Email.Domain;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Reflection.Recipes;

    using Xunit;

    public static class SendEmailProtocolTest
    {
        [Fact(Skip = "For local testing only.")]
        public static async Task ExecuteAsync___Should_send_email_and_return_EmailResponse_with_SendEmailResult_Success___When_server_connection_is_well_formed()
        {
            // Arrange
            var smtpServerConnectionDefinition = new SmtpServerConnectionDefinition(
                "HOST_NAME_HERE",
                587,
                SecureConnectionMethod.StartTls,
                "USERNAME_HERE",
                "PASSWORD_HERE");

            var emailParticipants = new EmailParticipants(
                new EmailMailbox("FROM_ADDRESS_HERE"),
                new[] { new EmailMailbox("TO_ADDRESS_HERE") },
                new EmailMailbox[] { },
                new EmailMailbox[] { },
                new EmailMailbox[] { });

            const string heartFileName = "heart.png";
            const string documentFileName = "document.pdf";

            var heartFileBytes = AssemblyHelper.ReadEmbeddedResourceAsBytes(heartFileName);
            var heartAttachment = new EmailAttachment(heartFileBytes, heartFileName, MediaType.ImagePng);

            var documentFileBytes = AssemblyHelper.ReadEmbeddedResourceAsBytes(documentFileName);
            var documentAttachment = new EmailAttachment(documentFileBytes, documentFileName, MediaType.ApplicationPdf);

            const string heartContentId = "heart-content-id";

            var emailContent = new EmailContent(
                "SUBJECT_LINE_HERE",
                "this is some plain text",
                $@"<table style=""border: solid 1px #e9e9e9;"">
                      <tr>
                          <td>A1</td>
                          <td>B1</td>
                          <td>C1</td>
                      </tr>
                      <tr>
                          <td>A2</td>
                          <td><img src=""cid:{heartContentId}""></td>
                          <td>C2</td>
                      </tr>
                      <tr>
                          <td>A3</td>
                          <td>B3</td>
                          <td>C3</td>
                      </tr>
                  </table>",
                new EmailAttachment[]
                {
                    documentAttachment,
                },
                new Dictionary<string, EmailAttachment>
                {
                    { heartContentId,  heartAttachment },
                },
                null,
                null);

            var emailRequest = new EmailRequest(emailParticipants, emailContent);

            var operation = new SendEmailOp(emailRequest);

            var protocol = new SendEmailProtocol(smtpServerConnectionDefinition);

            // Act
            var actual = await protocol.ExecuteAsync(operation);

            // Assert
            actual.SendEmailResult.AsTest().Must().BeEqualTo(SendEmailResult.Success);
        }
    }
}
