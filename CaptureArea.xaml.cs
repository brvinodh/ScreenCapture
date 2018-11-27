
namespace ScreenCapture
{
    using ScreenCapture.Helpers.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for CaptureArea.xaml
    /// </summary>
    public partial class CaptureArea : Window, IWindow
    {
        /// <summary>
        /// Variable which indicates if user has made a valid selection 
        /// </summary>
        private bool isSelectingCaptureArea = true;

        /// <summary>
        /// Indicates if the user is dragging the mouse after mouse down
        /// </summary>
        private bool isDragging = false;

        public CaptureArea()
        {
            InitializeComponent();
        }

        private static Action EmptyDelegate = delegate () { };
        public void HideWin()
        {
            //this.canvasDrawPane.Visibility = Visibility.Collapsed;
            this.canvasDrawPane.Width = 0;
            this.canvasDrawPane.Height = 0;
            this.canvasBottom.Height = 0;
            this.canvasTop.Height = this.ActualHeight;
            this.isSelectingCaptureArea = true;
            this.isHighlighting = false;
            for (int i = this.canvasDrawPane.Children.Count - 1; i >=0 ; i--)
            {
                var child = this.canvasDrawPane.Children[i];

                if (!(child is Border && ((Border)child).Name == nameof(this.canvasBorder)))
                {
                    this.canvasDrawPane.Children.RemoveAt(i);
                }
            }

            this.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            this.Hide();
        }

        public void ShowWin()
        {
            this.Show();
        }

        /// <summary>
        /// The sourcepoint from where the rectangle should be drawn
        /// </summary>
        Point sourcepoint = new Point();

        Rectangle currentHighlightDrawRectangle = null;

        private bool isHighlighting = false;
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sourcepoint = e.GetPosition(this.mainCanvas);

            // capture if user is indeed doing dragging
            this.isDragging = true;

            // if the user is highligting then we need to create a new instance of the rectangle that can be added
            if (this.isHighlighting)
            {
                currentHighlightDrawRectangle = new Rectangle();
            }
        }
        private void canvasPlane_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDragging == false)
                return;

            Point destPoint = e.GetPosition(this.mainCanvas);
            if (this.isHighlighting)
            {
                this.DrawCanvasHighlighterRectangle(this.sourcepoint, destPoint);
            }
            else if (this.isSelectingCaptureArea)
            {
                this.UpdateLayoutControls(sourcepoint, destPoint);
            }
        }

        private void canvasPlane_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.isDragging = false;
            if (this.isHighlighting)
            {
                // set the rectangle to null; so that new one can be instantiated
                currentHighlightDrawRectangle = null;
            }
        }


        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            this.canvasTop.Height = this.ActualHeight - 3;
        }



        private void StartHighlighting()
        {
            this.isHighlighting = true;
        }

        private void UpdateLayoutControls(Point sourcepoint, Point destinationPoint)
        {
            double topCanvasheight = Math.Min(sourcepoint.Y, destinationPoint.Y);
            double heightOfCanvasDrawPane = Math.Abs(sourcepoint.Y - destinationPoint.Y);

            // cover the top with dark background
            this.canvasTop.Height = Math.Min(sourcepoint.Y, destinationPoint.Y);

            // make the canvas draw pane transparent by increasing its height so that we capture the area
            this.canvasDrawPane.Height = heightOfCanvasDrawPane;

            // cover the botton part with dark background
            this.canvasBottom.Height = this.ActualHeight - heightOfCanvasDrawPane - topCanvasheight;


            double canvasDrawPaneLeftWidth = Math.Min(sourcepoint.X, destinationPoint.X);
            double canvasDrawPaneWidth = Math.Abs(sourcepoint.X - destinationPoint.X);
            double canvasDrawPaneRightWidth = this.ActualWidth - canvasDrawPaneLeftWidth - canvasDrawPaneWidth;

            // make the left part of the point not highlighted dark
            this.canvasDrawPaneLeft.Width = canvasDrawPaneLeftWidth;

            // make the canvas draw pane transparent for the area between two rectangle point
            this.canvasDrawPane.Width = canvasDrawPaneWidth;

            // make the canvas right part of draw pane dark
            this.canvasPanelRight.Width = canvasDrawPaneRightWidth;

            Canvas.SetLeft(this.controlsPanel, canvasDrawPaneLeftWidth);
        }

        private void DrawCanvasHighlighterRectangle(Point srcPoint, Point destPoint)
        {
            // check if tag is null; this indicates if the rectangle has been added to the canvas 
            if (currentHighlightDrawRectangle.Tag == null)
            {
                currentHighlightDrawRectangle.Tag = this;
                currentHighlightDrawRectangle.Stroke = new SolidColorBrush(Colors.Red);
                currentHighlightDrawRectangle.StrokeThickness = 3;
                this.canvasDrawPane.Children.Add(currentHighlightDrawRectangle);
            }

            double leftSizeWrtCanvas = Math.Min(srcPoint.X, destPoint.X) - this.canvasDrawPaneLeft.Width;
            double topSizeWRTCanvas = Math.Min(srcPoint.Y, destPoint.Y) - this.canvasTop.Height;

            Canvas.SetLeft(this.currentHighlightDrawRectangle, leftSizeWrtCanvas);
            Canvas.SetTop(this.currentHighlightDrawRectangle, topSizeWRTCanvas);
            this.currentHighlightDrawRectangle.Height = Math.Abs(this.sourcepoint.Y - destPoint.Y);
            this.currentHighlightDrawRectangle.Width = Math.Abs(this.sourcepoint.X - destPoint.X);
        }

        private void CaptureArea_KeyDownEvent(object sender, KeyEventArgs e)
        {
            // if user has pressed the H key; 
            if (e.Key == Key.H && this.canvasDrawPane.Height > 0 && this.canvasDrawPane.Width > 0)
            {
                this.isSelectingCaptureArea = false;

                // indicates that the user wants to start highlighting
                this.isHighlighting = true;
            }
        }

        private void OnHighlightButtonClick(object sender, RoutedEventArgs e)
        {
            this.isSelectingCaptureArea = false;

            // indicates that the user wants to start highlighting
            this.isHighlighting = true;
        }


        private void captureAreaWindow_Activated(object sender, EventArgs e)
        {
            this.mainCanvas.Visibility = Visibility.Visible;
        }
    }


    public class GraphicsDimesionsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            Console.WriteLine(values[0]);

            if (values != null && values.Count() > 4)
            {
                double x, y, height, width = 0;
                Window wnd = values[4] as Window;
                double.TryParse(values[0].ToString(), out width);
                double.TryParse(values[1].ToString(), out height);
                double.TryParse(values[2].ToString(), out x);
                double.TryParse(values[3].ToString(), out y);
                try
                {
                    if (wnd.IsActive)
                    {
                        var pnt = wnd.PointToScreen(new Point(x + 1, y - 0.1 + 1));
                        Rect rect = new Rect(pnt.X, pnt.Y, width, height);
                        return rect;
                    }
                }
                catch (Exception)
                {

                }              
            }
            return new Rect();
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
