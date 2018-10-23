//----------------------------------------------------------------------
// <copyright file="IFileHelper.cs" company="Sprocket Enterprises">
//     Copyright uCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ScreenCapture.Helpers.Abstract
{
    /// <summary>
    /// File helper class
    /// </summary>
    internal interface IFileHelper
    {
        /// <summary>
        /// A method which returns a random meaning full jpeg file name
        /// </summary>
        /// <returns> returns a meaning random full doc file name</returns>
        string GetJpegFileName();

        /// <summary>
        /// A method which returns a random meaning full doc file name
        /// </summary>
        /// <returns> returns a  meaning full doc file name</returns>
        string GetWordFileName();
    }
}
