//-----------------------------------------------------------------------
// <copyright file="IImageManager.cs" company="Sprocket Enterprises">
//     Copyright uCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ScreenCapture.Helpers.Abstract
{
    /// <summary>
    /// Represents an image used to manage opening and closing of word documents
    /// </summary>
    public interface IImageManager
    {
        /// <summary>
        /// Opens the word document.
        /// </summary>
        void OpenDocument(string fileName);

        /// <summary>
        /// Creates the new document.
        /// </summary>
        void CreateNewDocument();

        /// <summary>
        /// Adds the image to document.
        /// </summary>
        /// <param name="image">The image.</param>
        void AddImageToDocument(string image);

        /// <summary>
        /// Closes the document.
        /// </summary>
        void CloseDocument();
    }
}
