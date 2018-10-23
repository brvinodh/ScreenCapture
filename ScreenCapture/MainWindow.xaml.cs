using MahApps.Metro.Controls;
using ScreenCapture.Helpers.Abstract;
using ScreenCapture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenCapture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IWindow
    {
        private HotKey _hotkey;

        public MainWindow()
        {
            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;

            Loaded += (s, e) =>
            {
                _hotkey = new HotKey( ModifierKeys.Alt, Key.NumPad9, this);
                _hotkey.HotKeyPressed += (k) =>
                {
                    Console.WriteLine("Yo im invoked");
                };
            };
            // ScreenshotHelper.CaptureImage();
        }

        public void HideWin()
        {
            this.Hide();
            // give sufficient time after hide so that the window can disappear
            System.Threading.Thread.Sleep(300);
        }

        public void ShowWin()
        {
            this.Show();
        }
    }
}
