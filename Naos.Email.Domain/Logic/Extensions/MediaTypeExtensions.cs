// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaTypeExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Mime;

    using Naos.CodeAnalysis.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Extension methods on <see cref="MediaTypeExtensions"/>.
    /// </summary>
    public static class MediaTypeExtensions
    {
        /// <summary>
        /// Gets the MIME type name for the specified media type.
        /// </summary>
        /// <param name="mediaType">The media type.</param>
        /// <returns>
        /// The MIME type name for the specified media type.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = NaosSuppressBecause.CA1502_AvoidExcessiveComplexity_DisagreeWithAssessment)]
        public static string ToMimeTypeName(
            this MediaType mediaType)
        {
            switch (mediaType)
            {
                case MediaType.ApplicationOctet:
                    return MediaTypeNames.Application.Octet;
                case MediaType.ApplicationGoogleDocs:
                    return "application/vnd.google-apps.document";
                case MediaType.ApplicationGoogleDrawing:
                    return "application/vnd.google-apps.drawing";
                case MediaType.ApplicationGoogleSlides:
                    return "application/vnd.google-apps.presentation";
                case MediaType.ApplicationGoogleSheets:
                    return "application/vnd.google-apps.spreadsheet";
                case MediaType.ApplicationGzip:
                    return "application/gzip";
                case MediaType.ApplicationJson:
                    return "application/json";
                case MediaType.ApplicationMicrosoftOfficeExcel:
                    return "application/vnd.ms-excel";
                case MediaType.ApplicationMicrosoftOfficeOoxmlExcel:
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case MediaType.ApplicationMicrosoftOfficePowerPoint:
                    return "application/vnd.ms-powerpoint";
                case MediaType.ApplicationMicrosoftOfficeOoxmlPowerPoint:
                    return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case MediaType.ApplicationMicrosoftOfficeWord:
                    return "application/msword";
                case MediaType.ApplicationMicrosoftOfficeOoxmlWord:
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case MediaType.ApplicationPdf:
                    return MediaTypeNames.Application.Pdf;
                case MediaType.ApplicationPostscript:
                    return "application/postscript";
                case MediaType.ApplicationRtf:
                    return MediaTypeNames.Application.Rtf;
                case MediaType.ApplicationSoap:
                    return MediaTypeNames.Application.Soap;
                case MediaType.ApplicationSql:
                    return "application/sql";
                case MediaType.ApplicationZip:
                    return MediaTypeNames.Application.Zip;
                case MediaType.AudioMpeg4:
                    return "audio/m4a";
                case MediaType.AudioMpeg:
                    return "audio/mpeg";
                case MediaType.AudioWav:
                    return "audio/wav";
                case MediaType.ImageBmp:
                    return "image/bmp";
                case MediaType.ImageGif:
                    return MediaTypeNames.Image.Gif;
                case MediaType.ImageJpeg:
                    return MediaTypeNames.Image.Jpeg;
                case MediaType.ImagePhotoshop:
                    return "image/vnd.adobe.photoshop";
                case MediaType.ImagePng:
                    return "image/png";
                case MediaType.ImageSvg:
                    return "image/svg+xml";
                case MediaType.ImageTiff:
                    return MediaTypeNames.Image.Tiff;
                case MediaType.MessageEmail:
                    return "message/rfc822";
                case MediaType.TextCss:
                    return "text/css";
                case MediaType.TextCsv:
                    return "text/csv";
                case MediaType.TextHtml:
                    return MediaTypeNames.Text.Html;
                case MediaType.TextJavaScript:
                    return "text/javascript";
                case MediaType.TextMarkdown:
                    return "text/markdown";
                case MediaType.TextPlain:
                    return MediaTypeNames.Text.Plain;
                case MediaType.TextRichText:
                    return MediaTypeNames.Text.RichText;
                case MediaType.TextVcard:
                    return "text/vcard";
                case MediaType.TextXml:
                    return MediaTypeNames.Text.Xml;
                case MediaType.TextYaml:
                    return "text/yaml";
                case MediaType.VideoMpeg:
                    return "video/mpeg";
                case MediaType.VideoMpeg4:
                    return "video/mp4";
                case MediaType.VideoQuickTime:
                    return "video/quicktime";
                case MediaType.VideoWmv:
                    return "video/x-ms-wmv";
                default:
                    throw new NotSupportedException(Invariant($"This {nameof(MediaType)} is not supported: {mediaType}."));
            }
        }
    }
}
