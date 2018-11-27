//-----------------------------------------------------------------------
// <copyright file="FileHelper.cs" company="Sprocket Enterprises">
//     Copyright uCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ScreenCapture.Helpers.Implementations
{
    using ScreenCapture.Helpers.Abstract;
    using System;
    using System.Drawing;

    /// <summary>
    /// A file helper class for getting temporary file names
    /// </summary>
    internal class ImageFileHelper : IImageFileHelper
    {
        /// <summary>
        /// The method to get base folder; this helps in delayed execution and imporves boot up performance.
        /// </summary>
        Func<string> methodToGetBaseFolder;

        /// <summary>
        /// The base folder location in which the files needs to be created
        /// </summary>
        private string baseFolderLocation = string.Empty;
        public ImageFileHelper(Func<string> baseFolderLocationMethod)
        {
            this.methodToGetBaseFolder = baseFolderLocationMethod;
        }

        /// <summary>
        /// Gets the name of the JPEG file.
        /// </summary>
        /// <returns></returns>
        public string GetJpegFileName()
        {
            if (string.IsNullOrEmpty(this.baseFolderLocation))
            {
                this.baseFolderLocation = this.methodToGetBaseFolder();
                System.IO.Directory.CreateDirectory(this.baseFolderLocation);
            }

            string fileName = System.IO.Path.Combine(this.baseFolderLocation, DateTime.Now.ToString("yyyy-MM-dd-HHmmssfff") + ".jpg");

            return fileName;
        }

        /// <summary>
        /// Gets the name of the word file.
        /// </summary>
        /// <returns></returns>
        public string GetWordFileName()
        {
            string fileName = System.IO.Path.Combine(this.baseFolderLocation, DateTime.Now.ToString("yyyy-MM-dd-HHmmssfff") + ".docx");

            return fileName;
        }

        public string Save(Bitmap bitmap)
        {
            try
            {
                string fileName = this.GetJpegFileName();
                bitmap.Save(fileName);
                return fileName;
            }
            catch (Exception)
            {

                throw;
            }    
        }
    }
}
