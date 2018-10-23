//-----------------------------------------------------------------------
// <copyright file="ProcessItem.cs" company="Sprocket Enterprises">
//     Copyright uCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ScreenCapture.Helpers
{
    using System;

    /// <summary>
    /// Represents a Process item which contains the Process name, its OS pointer
    /// </summary>
    internal class ProcessItem
    {
        /// <summary>
        /// Gets or sets the window handle pointer
        /// </summary>
        /// <value>
        /// The window handle.
        /// </value>
        public IntPtr WindowHandle { get; set; }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
    }
}
