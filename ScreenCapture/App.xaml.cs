using ScreenCapture.Helpers.Implementations;
using ScreenCapture.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            var fileHelper = new FileHelper(this.GetBaseFolderLocation);
            var imageManger = new WordImageManager(messageBox, fileHelper);
            window.DataContext = new MainVM(messageBox, fileHelper, ()=> { return new WindowsHandler(); }, imageManger
                , window);
            window.Show();
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
