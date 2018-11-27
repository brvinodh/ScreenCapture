using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MinimizeCapture;
using ScreenCapture.Helpers.Abstract;
using System.Drawing;

namespace ScreenCapture.ViewModel
{
    internal class CaptureAreaVM : ViewModelBase
    {
        private IImageFileHelper imageStorageHelper;

        private IWindow boundWindow;

        public Action<Rect> OnWindowCloseCallBack { get; set; }
        public CaptureAreaVM(IImageFileHelper imageFileHelper, IWindow window)
        {
            this.imageStorageHelper = imageFileHelper;
            this.boundWindow = window;
            this.CapturAreaCommand = new RelayCommand<Rect>((Rect r) =>
            {
               // Console.Write(r);
               // var bmp = WindowSnap.GetBitmapInCoordinates((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height);

                //this.boundWindow.Reset();
                //this.imageStorageHelper.Save(bmp as Bitmap);
                this.OnWindowCloseCallBack(r);
                //System.Threading.Thread.Sleep(10000);
                //this.boundWindow.HideWin();
            });
        }

        public void ShowCaptureArea(Action<Rect> callback)
        {
            this.boundWindow.ShowWin();
            this.OnWindowCloseCallBack = callback;
        }

        public void HideCaptureArea()
        {
            this.boundWindow.HideWin();
        }

        public ICommand CapturAreaCommand { get; set; }  
    }
}
