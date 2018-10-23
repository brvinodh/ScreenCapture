using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenCapture
{

    interface IMessageBox
    {
        void ShowErrorMessage(string message, string title="", Exception exception = null);
    }

    class CustomMessageBox : IMessageBox
    {
        public void ShowErrorMessage(string message, string title = "", Exception exception = null)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
