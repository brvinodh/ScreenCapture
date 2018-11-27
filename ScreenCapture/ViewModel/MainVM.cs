using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MinimizeCapture;
using ScreenCapture.Helpers;
using ScreenCapture.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ScreenCapture.ViewModel
{
    internal class MainVM : ViewModelBase
    {
        /// <summary>
        /// The capture image command
        /// </summary>
        private ICommand captureImageCommand;

        /// <summary>
        /// The capture image command
        /// </summary>
        private ICommand captureAreaCommand;

        /// <summary>
        /// Represents a message box instance to display the messages to the user
        /// </summary>
        private IMessageBox messageBox;

        /// <summary>
        /// The base folder where the files will be stored
        /// </summary>
        private IImageFileHelper imageFileHelper = null;

        private IWindow uiWindow = null;

        /// <summary>
        /// Represents an window object to be shown when an area needs to be captured
        /// </summary>
        private CaptureAreaVM captureAreaWindow = null;

        /// <summary>
        /// Represents a window helper class instance using which all the open window items can be retrieved
        /// </summary>
        private Func<IWindowHelper> windowHelperfunc;

        /// <summary>
        /// The word image manager function which would retrieve the given image object
        /// </summary>
        private IImageManager wordImageManager;

        private IWindowHelper windowHelper;

        private bool isVisible = true;

        public bool IsApplicationVisible
        {
            get {
                return isVisible; }
            set { isVisible = value;
                this.RaisePropertyChanged(); }
        }

        private string snapStatus;

        /// <summary>
        /// state variable to capture the show advanced state
        /// </summary>
        private bool showAdvanced = false;

        /// <summary>
        /// Gets or sets a value indicating whether to show advanced option i.e. to show the process or not
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show advanced]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowAdvanced
        {
            get { return showAdvanced; }
            set { showAdvanced = value; this.RaisePropertyChanged(); }
        }

        public string SnapStatus
        {
            get { return snapStatus; }
            set { snapStatus = value; this.RaisePropertyChanged(); }
        }
        
        private ExportOptions selectedExportOption = ViewModel.ExportOptions.None;

        /// <summary>
        /// The get all processes command
        /// </summary>
        private ICommand getAllProcessesCommand;

        /// <summary>
        /// The command to be invoked on click of export button
        /// </summary>
        private ICommand onExportButtonClicked;

        /// <summary>
        /// Gets or sets the selected process item.
        /// </summary>
        /// <value>
        /// The selected process item.
        /// </value>
        public ProcessItem SelectedProcessItem { get; set; }


        /// <summary>
        /// Gets the export options.
        /// </summary>
        /// <value>
        /// The export options.
        /// </value>
        public List<ExportOptionItem> ExportOptions
        {
            get
            {
                List<ExportOptionItem> options = new List<ExportOptionItem>();
                options.Add(new ExportOptionItem("Export to New", ViewModel.ExportOptions.NewWordDocument));
                options.Add(new ExportOptionItem("Open Existing", ViewModel.ExportOptions.OpenDocument));
                return options;
            }
        }

        /// <summary>
        /// Gets the on export button clicked; selects a given word document
        /// </summary>
        /// <value>
        /// The on export button clicked.
        /// </value>
        public ICommand OnExportButtonClicked
        {
            get
            {
                return onExportButtonClicked ?? (onExportButtonClicked = new RelayCommand<ExportOptionItem>((o) =>
                 {
                     //this.messageBox.ShowErrorMessage("I have clicked: " + o.OptionType);
                     //this.selectedExportOption = o.OptionType;
                     switch (o.OptionType)
                     {
                         case ViewModel.ExportOptions.OpenDocument:
                             this.wordImageManager.OpenDocument("");
                             this.selectedExportOption = ViewModel.ExportOptions.OpenDocument;
                             break;
                         case ViewModel.ExportOptions.NewWordDocument:
                             this.selectedExportOption = ViewModel.ExportOptions.NewWordDocument;
                             this.wordImageManager.CreateNewDocument();
                             break;
                     }


                 }));
            }
        }

        public ObservableCollection<ProcessItem> ProcessItems { get; set; } = new ObservableCollection<ProcessItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="messageBox">The message box.</param>
        /// <param name="fileHelper">The file helper.</param>
        /// <param name="windowHelper">The window helper.</param>
        /// <param name="wordImageManager">The word image manager.</param>
        /// <param name="tempAction">The temporary action.</param>
        /// <param name="captureAreaWindow">The capture area window.</param>
        public MainVM(IMessageBox messageBox, IImageFileHelper fileHelper, Func<IWindowHelper> windowHelper
            , IImageManager wordImageManager, IWindow tempAction, CaptureAreaVM captureAreaWindow)
        {
            this.messageBox = messageBox;
            //this.methodToGetBaseFolder = methodToGetBaseFolder;
            this.imageFileHelper = fileHelper;
            this.windowHelperfunc = windowHelper;
            this.wordImageManager = wordImageManager;

            this.captureImageCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => {
                this.CaptureImage();
            });

            this.captureAreaCommand = new RelayCommand(() =>
            {
                this.CaptureArea();
            });

            this.uiWindow = tempAction;
            this.captureAreaWindow = captureAreaWindow;
        }

        private void CaptureArea()
        {
            this.uiWindow.HideWin();
            this.captureAreaWindow.ShowCaptureArea((Rect rect) =>
            {
                var image = WindowSnap.GetBitmapInCoordinates((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height) as Bitmap;

                // hide the current window, on complete show it back
                this.captureAreaWindow.HideCaptureArea();
                this.uiWindow.ShowWin();

                this.SaveImage(image);
            });
        }

        public ICommand CaptureImageCommand
        {
            get
            {
                return this.captureImageCommand;
            }
        }
        public ICommand CaptureAreaCommand
        {
            get
            {
                return this.captureAreaCommand;
            }
        }

        /// <summary>
        /// Gets the get all processes command.
        /// </summary>
        /// <value>
        /// The get all processes command.
        /// </value>
        public ICommand GetAllProcessesCommand
        {
            get
            {
                return this.getAllProcessesCommand ??
                    (
                    this.getAllProcessesCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (this.ProcessItems.Count == 0)
                            {                                
                                this.windowHelper = this.windowHelperfunc?.Invoke();
                            }

                            this.ProcessItems.Clear();

                            this.windowHelper.BeginProcessItemRefresh((o)=>
                            {
                                this.ProcessItems.Add(o);
                            });
                        }
                        catch (Exception ex)
                        {
                            this.messageBox.ShowErrorMessage("Error when retrieving all the processes", "Error", ex);
                        }
                    }));
            }
        }

        /// <summary>
        /// Captures the image.
        /// </summary>
        public void CaptureImage()
        {
            Bitmap image = null;

            // if the show advanced is not visible;  then always capture the current area
            if (this.SelectedProcessItem == null || this.ShowAdvanced == false)
            {
                // capture only the background
                this.uiWindow.HideWin();
                image = WindowSnap.GetCurrentBackgroundScreenShot() as Bitmap;
                this.IsApplicationVisible = true;
                this.uiWindow.ShowWin();
            }
            else
            {
                var snap = WindowSnap.GetWindowSnap(this.SelectedProcessItem.WindowHandle, true);
                image = snap.Image;
            }

            string fileName = this.SaveImage(image as Bitmap);
        }

        public void CaptureByRect(Rect rect)
        {

            if (rect.IsEmpty == false)
            {
                var image = WindowSnap.GetBitmapInCoordinates((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height) as Bitmap;
                this.SaveImage(image);
            }
        }


        /// <summary>
        /// Saves the image to the configured base directory
        /// </summary>
        /// <param name="image">The image to be saved to base directory.</param>
        private string SaveImage(Bitmap image)
        {
            try
            {
                string fileName = this.imageFileHelper.GetJpegFileName();
                image.Save(fileName, ImageFormat.Jpeg);

                // save to word
                if (this.selectedExportOption != ViewModel.ExportOptions.None && !string.IsNullOrEmpty(fileName))
                    this.wordImageManager.AddImageToDocument(fileName);

                this.SnapStatus = "Image Captured Successfully";
                return fileName;
            }
            catch (Exception ex)
            {
                this.messageBox.ShowErrorMessage("Unable to capture screenshot, below is the error details: " + ex.ToString(), "Failure");
                return string.Empty;
            }
        }
    }
}
