// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaType.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Email.Domain
{
    /// <summary>
    /// Specifies the type of media.
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// The application data is not interpreted (default).
        /// </summary>
        ApplicationOctet,

        /// <summary>
        /// The application data is in Portable Document Format (PDF).
        /// </summary>
        ApplicationPdf,

        /// <summary>
        /// The application data is in Rich Text Format (RTF).
        /// </summary>
        ApplicationRtf,

        /// <summary>
        /// The application data is a SOAP document.
        /// </summary>
        ApplicationSoap,

        /// <summary>
        /// The application data is compressed.
        /// </summary>
        ApplicationZip,

        /// <summary>
        /// The image data is in Graphics Interchange Format (GIF).
        /// </summary>
        ImageGif,

        /// <summary>
        /// The image data is in Joint Photographic Experts Group (JPEG) format.
        /// </summary>
        ImageJpeg,

        /// <summary>
        /// The image data is in Tagged Image File Format (TIFF).
        /// </summary>
        ImageTiff,

        /// <summary>
        /// The image data in Portable Network Graphics (PNG) format.
        /// </summary>
        ImagePng,

        /// <summary>
        /// The text data is in HTML format.
        /// </summary>
        TextHtml,

        /// <summary>
        /// The text data is in plain text format.
        /// </summary>
        TextPlain,

        /// <summary>
        /// The text data is in Rich Text Format (RTF).
        /// </summary>
        TextRichText,

        /// <summary>
        /// The text data is in XML format.
        /// </summary>
        TextXml,
    }
}
