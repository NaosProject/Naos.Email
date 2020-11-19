// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaTypeExtensions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    using System;
    using System.Net.Mime;

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
        public static string ToMimeTypeName(
            this MediaType mediaType)
        {
            switch (mediaType)
            {
                case MediaType.ApplicationOctet:
                    return MediaTypeNames.Application.Octet;
                case MediaType.ApplicationPdf:
                    return MediaTypeNames.Application.Pdf;
                case MediaType.ApplicationRtf:
                    return MediaTypeNames.Application.Rtf;
                case MediaType.ApplicationSoap:
                    return MediaTypeNames.Application.Soap;
                case MediaType.ApplicationZip:
                    return MediaTypeNames.Application.Zip;
                case MediaType.ImageGif:
                    return MediaTypeNames.Image.Gif;
                case MediaType.ImageJpeg:
                    return MediaTypeNames.Image.Jpeg;
                case MediaType.ImageTiff:
                    return MediaTypeNames.Image.Tiff;
                case MediaType.ImagePng:
                    return "image/png";
                case MediaType.TextHtml:
                    return MediaTypeNames.Text.Html;
                case MediaType.TextPlain:
                    return MediaTypeNames.Text.Plain;
                case MediaType.TextRichText:
                    return MediaTypeNames.Text.RichText;
                case MediaType.TextXml:
                    return MediaTypeNames.Text.Xml;
                default:
                    throw new NotSupportedException(Invariant($"This {nameof(MediaType)} is not supported: {mediaType}."));
            }
        }
    }
}
