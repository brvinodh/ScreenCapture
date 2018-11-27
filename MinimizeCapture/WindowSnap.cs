using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
namespace MinimizeCapture
{
	internal class WindowSnap
	{
		private const string PROGRAMMANAGER = "Program Manager";

		private const string RUNDLL = "RunDLL";

		private const uint WM_PAINT = 15;

		private const int GWL_EXSTYLE = -20;

		private const int WS_EX_LAYERED = 524288;

		private const int LWA_ALPHA = 2;

		private static bool forceMDI;

		[ThreadStatic]
		private static bool countMinimizedWindows;

		[ThreadStatic]
		private static bool useSpecialCapturing;

		[ThreadStatic]
		private static WindowSnapCollection windowSnaps;

		[ThreadStatic]
		private static int winLong;

		[ThreadStatic]
		private static bool minAnimateChanged;

		private Bitmap image;

		private System.Drawing.Size size;

		private Point location;

		private string text;

		private IntPtr hWnd;

		private bool isIconic;

		public static bool ForceMDICapturing
		{
			get
			{
				return WindowSnap.forceMDI;
			}
			set
			{
				WindowSnap.forceMDI = value;
			}
		}

		public IntPtr Handle
		{
			get
			{
				return this.hWnd;
			}
		}

		public Bitmap Image
		{
			get
			{
				if (this.image == null)
				{
					return null;
				}
				return this.image;
			}
		}

		public bool IsMinimized
		{
			get
			{
				return this.isIconic;
			}
		}

		public Point Location
		{
			get
			{
				return this.location;
			}
		}

		public System.Drawing.Size Size
		{
			get
			{
				return this.size;
			}
		}

		public string Text
		{
			get
			{
				return this.text;
			}
		}

		static WindowSnap()
		{
			WindowSnap.forceMDI = true;
			WindowSnap.minAnimateChanged = false;
		}

		private WindowSnap(IntPtr hWnd, bool specialCapturing)
		{
			this.isIconic = WindowSnap.IsIconic(hWnd);
			this.hWnd = hWnd;
			if (specialCapturing)
			{
				WindowSnap.EnterSpecialCapturing(hWnd);
			}
			WindowSnap.WINDOWINFO wINDOWINFO = new WindowSnap.WINDOWINFO()
			{
				cbSize = WindowSnap.WINDOWINFO.GetSize()
			};
			WindowSnap.GetWindowInfo(hWnd, ref wINDOWINFO);
			bool flag = false;
			IntPtr parent = WindowSnap.GetParent(hWnd);
			Rectangle windowPlacement = new Rectangle();
			Rectangle rectangle = new Rectangle();
			if (WindowSnap.forceMDI && parent != IntPtr.Zero && (wINDOWINFO.dwExStyle & WindowSnap.ExtendedWindowStyles.WS_EX_MDICHILD) == WindowSnap.ExtendedWindowStyles.WS_EX_MDICHILD)
			{
				StringBuilder stringBuilder = new StringBuilder();
				WindowSnap.GetClassName(parent, stringBuilder, "RunDLL".Length + 1);
				if (stringBuilder.ToString() != "RunDLL")
				{
					flag = true;
					windowPlacement = WindowSnap.GetWindowPlacement(hWnd);
					WindowSnap.MoveWindow(hWnd, 2147483647, 2147483647, windowPlacement.Width, windowPlacement.Height, true);
					WindowSnap.SetParent(hWnd, IntPtr.Zero);
					rectangle = WindowSnap.GetWindowPlacement(parent);
				}
			}
			Rectangle windowPlacement1 = WindowSnap.GetWindowPlacement(hWnd);
			this.size = windowPlacement1.Size;
			this.location = windowPlacement1.Location;
			this.text = WindowSnap.GetWindowText(hWnd);
			this.image = WindowSnap.GetWindowImage(hWnd, this.size);
			if (flag)
			{
				WindowSnap.SetParent(hWnd, parent);
				int left = wINDOWINFO.rcWindow.Left - rectangle.X;
				int top = wINDOWINFO.rcWindow.Top - rectangle.Y;
				if ((wINDOWINFO.dwStyle & WindowSnap.WindowStyles.WS_THICKFRAME) == WindowSnap.WindowStyles.WS_THICKFRAME)
				{
                    left -= 100;//SystemInformation.Border3DSize.Width;

                    top -= 100;//SystemInformation.Border3DSize.Height;
				}
				WindowSnap.MoveWindow(hWnd, left, top, windowPlacement.Width, windowPlacement.Height, true);
			}
			if (specialCapturing)
			{
				WindowSnap.ExitSpecialCapturing(hWnd);
			}
		}

		private static void EnterSpecialCapturing(IntPtr hWnd)
		{
			if (XPAppearance.MinAnimate)
			{
				XPAppearance.MinAnimate = false;
				WindowSnap.minAnimateChanged = true;
			}
			WindowSnap.winLong = WindowSnap.GetWindowLong(hWnd, -20);
			WindowSnap.SetWindowLong(hWnd, -20, WindowSnap.winLong | 524288);
			WindowSnap.SetLayeredWindowAttributes(hWnd, 0, 1, 2);
			WindowSnap.ShowWindow(hWnd, WindowSnap.ShowWindowEnum.Restore);
			WindowSnap.SendMessage(hWnd, 15, 0, 0);
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool EnumWindows(WindowSnap.EnumWindowsCallbackHandler lpEnumFunc, IntPtr lParam);

		private static bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
		{
			bool flag = false;
			if (hWnd == IntPtr.Zero)
			{
				return false;
			}
			if (!WindowSnap.IsWindowVisible(hWnd))
			{
				return true;
			}
			if (!WindowSnap.countMinimizedWindows)
			{
				if (WindowSnap.IsIconic(hWnd))
				{
					return true;
				}
			}
			else if (WindowSnap.IsIconic(hWnd) && WindowSnap.useSpecialCapturing)
			{
				flag = true;
			}
			if (WindowSnap.GetWindowText(hWnd) == "Program Manager")
			{
				return true;
			}
			WindowSnap.windowSnaps.Add(new WindowSnap(hWnd, flag));
			return true;
		}

		private static void ExitSpecialCapturing(IntPtr hWnd)
		{
			WindowSnap.ShowWindow(hWnd, WindowSnap.ShowWindowEnum.Minimize);
			WindowSnap.SetWindowLong(hWnd, -20, WindowSnap.winLong);
			if (WindowSnap.minAnimateChanged)
			{
				XPAppearance.MinAnimate = true;
				WindowSnap.minAnimateChanged = false;
			}
		}

		public static WindowSnapCollection GetAllWindows(bool minimized, bool specialCapturring)
		{
			WindowSnap.windowSnaps = new WindowSnapCollection();
			WindowSnap.countMinimizedWindows = minimized;
			WindowSnap.useSpecialCapturing = specialCapturring;
			WindowSnap.EnumWindowsCallbackHandler enumWindowsCallbackHandler = new WindowSnap.EnumWindowsCallbackHandler(WindowSnap.EnumWindowsCallback);
			WindowSnap.EnumWindows(enumWindowsCallbackHandler, IntPtr.Zero);
			return new WindowSnapCollection(WindowSnap.windowSnaps.ToArray(), true);
		}

		public static WindowSnapCollection GetAllWindows()
		{
			return WindowSnap.GetAllWindows(false, false);
		}

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder name, int maxCount);

		public static System.Drawing.Image GetCurrentBackgroundScreenShot()
		{
			var bounds = System.Windows.SystemParameters.WorkArea;
            int width =(int) bounds.Width;
            int height = (int)bounds.Height;
            Bitmap bitmap = new Bitmap(width, height);
			using (Graphics graphic = Graphics.FromImage(bitmap))
			{
				int x = (int) bounds.X;
				Rectangle rectangle = new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Height, (int)bounds.Width);
				graphic.CopyFromScreen(x, rectangle.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
			}
			return bitmap;
		}

        public static System.Drawing.Image GetBitmapInCoordinates(int left, int top, int  width, int height)
        {
            var bounds = System.Windows.SystemParameters.WorkArea;
           
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                int x = (int)bounds.X;
                Rectangle rectangle = new Rectangle((int)left, (int)top, (int)height, (int)width);
                graphic.CopyFromScreen((int)left, rectangle.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }

            return bitmap;
        }

        [DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern IntPtr GetParent(IntPtr hWnd);

		private static Bitmap GetWindowImage(IntPtr hWnd, System.Drawing.Size size)
		{
			Bitmap bitmap;
			try
			{
				if (size.IsEmpty || size.Height < 0 || size.Width < 0)
				{
					bitmap = null;
				}
				else
				{
					Bitmap bitmap1 = new Bitmap(size.Width, size.Height);
					Graphics graphic = Graphics.FromImage(bitmap1);
					WindowSnap.PrintWindow(hWnd, graphic.GetHdc(), 0);
					graphic.ReleaseHdc();
					graphic.Dispose();
					bitmap = bitmap1;
				}
			}
			catch
			{
				bitmap = null;
			}
			return bitmap;
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool GetWindowInfo(IntPtr hwnd, ref WindowSnap.WINDOWINFO pwi);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetWindowLong(IntPtr hWnd, int index);

		private static Rectangle GetWindowPlacement(IntPtr hWnd)
		{
			WindowSnap.RECT rECT = new WindowSnap.RECT();
			WindowSnap.GetWindowRect(hWnd, ref rECT);
			return rECT;
		}

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetWindowRect(IntPtr hWnd, ref WindowSnap.RECT rect);

		public static WindowSnap GetWindowSnap(IntPtr hWnd, bool useSpecialCapturing)
		{
			if (!useSpecialCapturing)
			{
				return new WindowSnap(hWnd, false);
			}
			return new WindowSnap(hWnd, WindowSnap.NeedSpecialCapturing(hWnd));
		}

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

		private static string GetWindowText(IntPtr hWnd)
		{
			int windowTextLength = WindowSnap.GetWindowTextLength(hWnd) + 1;
			StringBuilder stringBuilder = new StringBuilder(windowTextLength);
			WindowSnap.GetWindowText(hWnd, stringBuilder, windowTextLength);
			return stringBuilder.ToString();
		}

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool IsIconic(IntPtr hWnd);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool reDraw);

		private static bool NeedSpecialCapturing(IntPtr hWnd)
		{
			if (WindowSnap.IsIconic(hWnd))
			{
				return true;
			}
			return false;
		}

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int PrintWindow(IntPtr hWnd, IntPtr dc, uint flags);

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern uint SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int SetLayeredWindowAttributes(IntPtr hWnd, byte crey, byte alpha, int flags);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int SetWindowLong(IntPtr hWnd, int index, int dwNewLong);

		[DllImport("user32", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool ShowWindow(IntPtr hWnd, WindowSnap.ShowWindowEnum flags);

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Window Text: {0}, Handle: {1}", this.text, this.hWnd.ToString());
			return stringBuilder.ToString();
		}

		private delegate bool EnumWindowsCallbackHandler(IntPtr hWnd, IntPtr lParam);

		[Flags]
		private enum ExtendedWindowStyles : uint
		{
			WS_EX_LEFT = 0,
			WS_EX_LTRREADING = 0,
			WS_EX_RIGHTSCROLLBAR = 0,
			WS_EX_DLGMODALFRAME = 1,
			WS_EX_NOPARENTNOTIFY = 4,
			WS_EX_TOPMOST = 8,
			WS_EX_ACCEPTFILES = 16,
			WS_EX_TRANSPARENT = 32,
			WS_EX_MDICHILD = 64,
			WS_EX_TOOLWINDOW = 128,
			WS_EX_WINDOWEDGE = 256,
			WS_EX_PALETTEWINDOW = 392,
			WS_EX_CLIENTEDGE = 512,
			WS_EX_OVERLAPPEDWINDOW = 768,
			WS_EX_CONTEXTHELP = 1024,
			WS_EX_RIGHT = 4096,
			WS_EX_RTLREADING = 8192,
			WS_EX_LEFTSCROLLBAR = 16384,
			WS_EX_CONTROLPARENT = 65536,
			WS_EX_STATICEDGE = 131072,
			WS_EX_APPWINDOW = 262144
		}

		private struct RECT
		{
			private int left;

			private int top;

			private int right;

			private int bottom;

			public int Height
			{
				get
				{
					return this.bottom - this.top;
				}
			}

			public int Left
			{
				get
				{
					return this.left;
				}
			}

			public int Top
			{
				get
				{
					return this.top;
				}
			}

			public int Width
			{
				get
				{
					return this.right - this.left;
				}
			}

			public static implicit operator Rectangle(WindowSnap.RECT rect)
			{
				return new Rectangle(rect.left, rect.top, rect.Width, rect.Height);
			}
		}

		private enum ShowWindowEnum
		{
			Hide = 0,
			ShowNormal = 1,
			ShowMinimized = 2,
			Maximize = 3,
			ShowMaximized = 3,
			ShowNormalNoActivate = 4,
			Show = 5,
			Minimize = 6,
			ShowMinNoActivate = 7,
			ShowNoActivate = 8,
			Restore = 9,
			ShowDefault = 10,
			ForceMinimized = 11
		}

		private struct WINDOWINFO
		{
			public uint cbSize;

			public WindowSnap.RECT rcWindow;

			public WindowSnap.RECT rcClient;

			public WindowSnap.WindowStyles dwStyle;

			public WindowSnap.ExtendedWindowStyles dwExStyle;

			public uint dwWindowStatus;

			public uint cxWindowBorders;

			public uint cyWindowBorders;

			public ushort atomWindowType;

			public ushort wCreatorVersion;

			public static uint GetSize()
			{
				return (uint)Marshal.SizeOf(typeof(WindowSnap.WINDOWINFO));
			}
		}

		[Flags]
		private enum WindowStyles : uint
		{
			WS_OVERLAPPED = 0,
			WS_TILED = 0,
			WS_MAXIMIZEBOX = 65536,
			WS_TABSTOP = 65536,
			WS_GROUP = 131072,
			WS_MINIMIZEBOX = 131072,
			WS_SIZEBOX = 262144,
			WS_THICKFRAME = 262144,
			WS_SYSMENU = 524288,
			WS_HSCROLL = 1048576,
			WS_VSCROLL = 2097152,
			WS_DLGFRAME = 4194304,
			WS_BORDER = 8388608,
			WS_CAPTION = 12582912,
			WS_OVERLAPPEDWINDOW = 13565952,
			WS_TILEDWINDOW = 13565952,
			WS_MAXIMIZE = 16777216,
			WS_CLIPCHILDREN = 33554432,
			WS_CLIPSIBLINGS = 67108864,
			WS_DISABLED = 134217728,
			WS_VISIBLE = 268435456,
			WS_ICONIC = 536870912,
			WS_MINIMIZE = 536870912,
			WS_CHILD = 1073741824,
			WS_CHILDWINDOW = 1073741824,
			WS_POPUP = 2147483648,
			WS_POPUPWINDOW = 2156396544
		}
	}
}