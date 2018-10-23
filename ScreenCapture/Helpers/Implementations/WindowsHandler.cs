using ScreenCapture.Helpers;
using ScreenCapture.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.ViewModel
{
    /// <summary>
    /// Represents a class responsible for retrieving all the windows opened in the application
    /// </summary>
    internal class WindowsHandler : IWindowHelper
    {
        /// <summary>
        /// A global variable which contains all the process items
        /// </summary>
        private List<ProcessItem> AllProcessItems= new List<ProcessItem>();

        private Action<ProcessItem> OnProcessEnumerationCallbackMethod;

        /// <summary>
        /// A callback handler delegate to be invoked after interop success
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        private delegate bool EnumWindowsCallbackHandler(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Enums the windows.
        /// </summary>
        /// <param name="lpEnumFunc">The lp enum function.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool EnumWindows(EnumWindowsCallbackHandler lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Determines whether the window is visible to the end user or hidden or minimized
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>
        ///   true if window is visible else its false
        /// </returns>
        [DllImport("user32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Gets the window text.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="text">The text.</param>
        /// <param name="maxCount">The maximum count.</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

        /// <summary>
        /// Gets the length of the window text.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Gets all open processes.
        /// </summary>
        /// <returns>
        /// Returns the list of processes open
        /// </returns>
        public void BeginProcessItemRefresh(Action<ProcessItem> callbackMethod)
        {
            var allProcessItems = new List<ProcessItem>();
            this.OnProcessEnumerationCallbackMethod = callbackMethod;
            EnumWindowsCallbackHandler enumWindowsCallbackHandler = new EnumWindowsCallbackHandler(this.EnumWindowsCallback);

            EnumWindows(this.EnumWindowsCallback, IntPtr.Zero);
            //return this.AllProcessItems;
        }

        /// <summary>
        /// This is the method called back by the operating system; when enumerating through each of the windows
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>Returns true if the windows was enumerated successfully</returns>
        private bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
        {
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }

            if (!IsWindowVisible(hWnd))
            {
                return true;
            }

            string windowText = this.GetWindowText(hWnd);
            if (!string.IsNullOrEmpty(windowText))
            {
                ProcessItem processItemCombo = new ProcessItem()
                {
                    WindowHandle = hWnd,
                    ProcessName = windowText,
                    Title = windowText
                };

                //this.AllProcessItems.Add(processItemCombo);
                this.OnProcessEnumerationCallbackMethod(processItemCombo);
            }

            return true;
        }

        /// <summary>
        /// Gets the window text associated with the window
        /// </summary>
        /// <param name="windowPtr">The h WND.</param>
        /// <returns></returns>
        private string GetWindowText(IntPtr windowPtr)
        {
            int windowTextLength = GetWindowTextLength(windowPtr) + 1;
            StringBuilder stringBuilder = new StringBuilder(windowTextLength);
            WindowsHandler.GetWindowText(windowPtr, stringBuilder, windowTextLength);
            return stringBuilder.ToString();
        }
    }
}
