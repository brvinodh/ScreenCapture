using ScreenCapture.Helpers.Implementations;
using ScreenCapture.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ScreenCapture
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string BaseFolderLocation = "BaseFolderLocation";
        IMessageBox messageBox = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow();
            messageBox = new CustomMessageBox();
            var fileHelper = new ImageFileHelper(this.GetBaseFolderLocation);
            var imageManger = new WordImageManager(messageBox, fileHelper);

            var captureWindow = new CaptureArea();
            var captureAreaVM = new CaptureAreaVM(fileHelper, captureWindow);
            captureWindow.DataContext = captureAreaVM;
            // the idea behind passing parameters as function is delay the execution so that the boot time is faster
            window.DataContext = new MainVM(messageBox, fileHelper, () => { return new WindowsHandler(); }, imageManger
                , window, captureAreaVM);
            window.Show();

            //CaptureArea m = new CaptureArea()
            //{
            //    WindowStartupLocation = WindowStartupLocation.Manual,
            //    WindowStyle = WindowStyle.None,
            //    AllowsTransparency = true,
            //    Background = (true ? new SolidColorBrush(Color.FromArgb(1, 0, 0, 0)) : Brushes.WhiteSmoke)
            //};
            //var color = Color.FromArgb(1, 0, 0, 0);
            //m.Show();
        }

        private string GetBaseFolderLocation()
        {
            string locationName = string.Empty;
            try
            {
                locationName = System.Configuration.ConfigurationManager.AppSettings.Get("BaseFolderLocation");
                System.IO.Directory.CreateDirectory(locationName);
                locationName = System.IO.Path.GetFullPath(locationName);
            }
            catch (Exception ex)
            {
                locationName = System.IO.Path.GetFullPath("./ScreenCapture");
                this.messageBox.ShowErrorMessage("Unable to find the base location, storing images under: " + locationName  , "Error", ex);                
            }

            return locationName;
        }
    }
}
