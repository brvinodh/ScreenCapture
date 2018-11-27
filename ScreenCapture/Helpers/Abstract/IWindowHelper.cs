//-----------------------------------------------------------------------
// <copyright file="IWindowHelper.cs" company="Sprocket Enterprises">
//     Copyright uCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ScreenCapture.Helpers.Abstract
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a helper interface which would retrieve all the open processes
    /// </summary>
    internal interface IWindowHelper
    {
        /// <summary>
        /// Gets all open processes.
        /// </summary>
        /// <returns>Returns the list of processes open</returns>
        void BeginProcessItemRefresh(Action<ProcessItem> callbackMethod);
    }
}
