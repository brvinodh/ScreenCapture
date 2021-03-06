using System;
using System.Runtime.InteropServices;

namespace MinimizeCapture
{
	internal static class XPAppearance
	{
		private const uint SPI_GETBEEP = 1;

		private const uint SPI_SETBEEP = 2;

		private const uint SPI_GETMOUSE = 3;

		private const uint SPI_SETMOUSE = 4;

		private const uint SPI_GETBORDER = 5;

		private const uint SPI_SETBORDER = 6;

		private const uint SPI_GETKEYBOARDSPEED = 10;

		private const uint SPI_SETKEYBOARDSPEED = 11;

		private const uint SPI_LANGDRIVER = 12;

		private const uint SPI_ICONHORIZONTALSPACING = 13;

		private const uint SPI_GETSCREENSAVETIMEOUT = 14;

		private const uint SPI_SETSCREENSAVETIMEOUT = 15;

		private const uint SPI_GETSCREENSAVEACTIVE = 16;

		private const uint SPI_SETSCREENSAVEACTIVE = 17;

		private const uint SPI_GETGRIDGRANULARITY = 18;

		private const uint SPI_SETGRIDGRANULARITY = 19;

		private const uint SPI_SETDESKWALLPAPER = 20;

		private const uint SPI_SETDESKPATTERN = 21;

		private const uint SPI_GETKEYBOARDDELAY = 22;

		private const uint SPI_SETKEYBOARDDELAY = 23;

		private const uint SPI_ICONVERTICALSPACING = 24;

		private const uint SPI_GETICONTITLEWRAP = 25;

		private const uint SPI_SETICONTITLEWRAP = 26;

		private const uint SPI_GETMENUDROPALIGNMENT = 27;

		private const uint SPI_SETMENUDROPALIGNMENT = 28;

		private const uint SPI_SETDOUBLECLKWIDTH = 29;

		private const uint SPI_SETDOUBLECLKHEIGHT = 30;

		private const uint SPI_GETICONTITLELOGFONT = 31;

		private const uint SPI_SETDOUBLECLICKTIME = 32;

		private const uint SPI_SETMOUSEBUTTONSWAP = 33;

		private const uint SPI_SETICONTITLELOGFONT = 34;

		private const uint SPI_GETFASTTASKSWITCH = 35;

		private const uint SPI_SETFASTTASKSWITCH = 36;

		private const uint SPI_SETDRAGFULLWINDOWS = 37;

		private const uint SPI_GETDRAGFULLWINDOWS = 38;

		private const uint SPI_GETNONCLIENTMETRICS = 41;

		private const uint SPI_SETNONCLIENTMETRICS = 42;

		private const uint SPI_GETMINIMIZEDMETRICS = 43;

		private const uint SPI_SETMINIMIZEDMETRICS = 44;

		private const uint SPI_GETICONMETRICS = 45;

		private const uint SPI_SETICONMETRICS = 46;

		private const uint SPI_SETWORKAREA = 47;

		private const uint SPI_GETWORKAREA = 48;

		private const uint SPI_SETPENWINDOWS = 49;

		private const uint SPI_GETHIGHCONTRAST = 66;

		private const uint SPI_SETHIGHCONTRAST = 67;

		private const uint SPI_GETKEYBOARDPREF = 68;

		private const uint SPI_SETKEYBOARDPREF = 69;

		private const uint SPI_GETSCREENREADER = 70;

		private const uint SPI_SETSCREENREADER = 71;

		private const uint SPI_GETANIMATION = 72;

		private const uint SPI_SETANIMATION = 73;

		private const uint SPI_GETFONTSMOOTHING = 74;

		private const uint SPI_SETFONTSMOOTHING = 75;

		private const uint SPI_SETDRAGWIDTH = 76;

		private const uint SPI_SETDRAGHEIGHT = 77;

		private const uint SPI_SETHANDHELD = 78;

		private const uint SPI_GETLOWPOWERTIMEOUT = 79;

		private const uint SPI_GETPOWEROFFTIMEOUT = 80;

		private const uint SPI_SETLOWPOWERTIMEOUT = 81;

		private const uint SPI_SETPOWEROFFTIMEOUT = 82;

		private const uint SPI_GETLOWPOWERACTIVE = 83;

		private const uint SPI_GETPOWEROFFACTIVE = 84;

		private const uint SPI_SETLOWPOWERACTIVE = 85;

		private const uint SPI_SETPOWEROFFACTIVE = 86;

		private const uint SPI_SETICONS = 88;

		private const uint SPI_GETDEFAULTINPUTLANG = 89;

		private const uint SPI_SETDEFAULTINPUTLANG = 90;

		private const uint SPI_SETLANGTOGGLE = 91;

		private const uint SPI_GETWINDOWSEXTENSION = 92;

		private const uint SPI_SETMOUSETRAILS = 93;

		private const uint SPI_GETMOUSETRAILS = 94;

		private const uint SPI_SCREENSAVERRUNNING = 97;

		private const uint SPI_GETFILTERKEYS = 50;

		private const uint SPI_SETFILTERKEYS = 51;

		private const uint SPI_GETTOGGLEKEYS = 52;

		private const uint SPI_SETTOGGLEKEYS = 53;

		private const uint SPI_GETMOUSEKEYS = 54;

		private const uint SPI_SETMOUSEKEYS = 55;

		private const uint SPI_GETSHOWSOUNDS = 56;

		private const uint SPI_SETSHOWSOUNDS = 57;

		private const uint SPI_GETSTICKYKEYS = 58;

		private const uint SPI_SETSTICKYKEYS = 59;

		private const uint SPI_GETACCESSTIMEOUT = 60;

		private const uint SPI_SETACCESSTIMEOUT = 61;

		private const uint SPI_GETSERIALKEYS = 62;

		private const uint SPI_SETSERIALKEYS = 63;

		private const uint SPI_GETSOUNDSENTRY = 64;

		private const uint SPI_SETSOUNDSENTRY = 65;

		private const uint SPI_GETSNAPTODEFBUTTON = 95;

		private const uint SPI_SETSNAPTODEFBUTTON = 96;

		private const uint SPI_GETMOUSEHOVERWIDTH = 98;

		private const uint SPI_SETMOUSEHOVERWIDTH = 99;

		private const uint SPI_GETMOUSEHOVERHEIGHT = 100;

		private const uint SPI_SETMOUSEHOVERHEIGHT = 101;

		private const uint SPI_GETMOUSEHOVERTIME = 102;

		private const uint SPI_SETMOUSEHOVERTIME = 103;

		private const uint SPI_GETWHEELSCROLLLINES = 104;

		private const uint SPI_SETWHEELSCROLLLINES = 105;

		private const uint SPI_GETMENUSHOWDELAY = 106;

		private const uint SPI_SETMENUSHOWDELAY = 107;

		private const uint SPI_GETSHOWIMEUI = 110;

		private const uint SPI_SETSHOWIMEUI = 111;

		private const uint SPI_GETMOUSESPEED = 112;

		private const uint SPI_SETMOUSESPEED = 113;

		private const uint SPI_GETSCREENSAVERRUNNING = 114;

		private const uint SPI_GETDESKWALLPAPER = 115;

		private const uint SPI_GETACTIVEWINDOWTRACKING = 4096;

		private const uint SPI_SETACTIVEWINDOWTRACKING = 4097;

		private const uint SPI_GETMENUANIMATION = 4098;

		private const uint SPI_SETMENUANIMATION = 4099;

		private const uint SPI_GETCOMBOBOXANIMATION = 4100;

		private const uint SPI_SETCOMBOBOXANIMATION = 4101;

		private const uint SPI_GETLISTBOXSMOOTHSCROLLING = 4102;

		private const uint SPI_SETLISTBOXSMOOTHSCROLLING = 4103;

		private const uint SPI_GETGRADIENTCAPTIONS = 4104;

		private const uint SPI_SETGRADIENTCAPTIONS = 4105;

		private const uint SPI_GETKEYBOARDCUES = 4106;

		private const uint SPI_SETKEYBOARDCUES = 4107;

		private const uint SPI_GETMENUUNDERLINES = 4106;

		private const uint SPI_SETMENUUNDERLINES = 4107;

		private const uint SPI_GETACTIVEWNDTRKZORDER = 4108;

		private const uint SPI_SETACTIVEWNDTRKZORDER = 4109;

		private const uint SPI_GETHOTTRACKING = 4110;

		private const uint SPI_SETHOTTRACKING = 4111;

		private const uint SPI_GETMENUFADE = 4114;

		private const uint SPI_SETMENUFADE = 4115;

		private const uint SPI_GETSELECTIONFADE = 4116;

		private const uint SPI_SETSELECTIONFADE = 4117;

		private const uint SPI_GETTOOLTIPANIMATION = 4118;

		private const uint SPI_SETTOOLTIPANIMATION = 4119;

		private const uint SPI_GETTOOLTIPFADE = 4120;

		private const uint SPI_SETTOOLTIPFADE = 4121;

		private const uint SPI_GETCURSORSHADOW = 4122;

		private const uint SPI_SETCURSORSHADOW = 4123;

		private const uint SPI_GETMOUSESONAR = 4124;

		private const uint SPI_SETMOUSESONAR = 4125;

		private const uint SPI_GETMOUSECLICKLOCK = 4126;

		private const uint SPI_SETMOUSECLICKLOCK = 4127;

		private const uint SPI_GETMOUSEVANISH = 4128;

		private const uint SPI_SETMOUSEVANISH = 4129;

		private const uint SPI_GETFLATMENU = 4130;

		private const uint SPI_SETFLATMENU = 4131;

		private const uint SPI_GETDROPSHADOW = 4132;

		private const uint SPI_SETDROPSHADOW = 4133;

		private const uint SPI_GETBLOCKSENDINPUTRESETS = 4134;

		private const uint SPI_SETBLOCKSENDINPUTRESETS = 4135;

		private const uint SPI_GETUIEFFECTS = 4158;

		private const uint SPI_SETUIEFFECTS = 4159;

		private const uint SPI_GETFOREGROUNDLOCKTIMEOUT = 8192;

		private const uint SPI_SETFOREGROUNDLOCKTIMEOUT = 8193;

		private const uint SPI_GETACTIVEWNDTRKTIMEOUT = 8194;

		private const uint SPI_SETACTIVEWNDTRKTIMEOUT = 8195;

		private const uint SPI_GETFOREGROUNDFLASHCOUNT = 8196;

		private const uint SPI_SETFOREGROUNDFLASHCOUNT = 8197;

		private const uint SPI_GETCARETWIDTH = 8198;

		private const uint SPI_SETCARETWIDTH = 8199;

		private const uint SPI_GETMOUSECLICKLOCKTIME = 8200;

		private const uint SPI_SETMOUSECLICKLOCKTIME = 8201;

		private const uint SPI_GETFONTSMOOTHINGTYPE = 8202;

		private const uint SPI_SETFONTSMOOTHINGTYPE = 8203;

		private const uint SPI_GETFONTSMOOTHINGCONTRAST = 8204;

		private const uint SPI_SETFONTSMOOTHINGCONTRAST = 8205;

		private const uint SPI_GETFOCUSBORDERWIDTH = 8206;

		private const uint SPI_SETFOCUSBORDERWIDTH = 8207;

		private const uint SPI_GETFOCUSBORDERHEIGHT = 8208;

		private const uint SPI_SETFOCUSBORDERHEIGHT = 8209;

		private const uint SPI_GETFONTSMOOTHINGORIENTATION = 8210;

		private const uint SPI_SETFONTSMOOTHINGORIENTATION = 8211;

		public static bool MinAnimate
		{
			get
			{
				XPAppearance.ANIMATIONINFO aNIMATIONINFO = new XPAppearance.ANIMATIONINFO(false);
				XPAppearance.SystemParametersInfo(XPAppearance.SPI.SPI_GETANIMATION, XPAppearance.ANIMATIONINFO.GetSize(), ref aNIMATIONINFO, XPAppearance.SPIF.None);
				return aNIMATIONINFO.IMinAnimate;
			}
			set
			{
				XPAppearance.ANIMATIONINFO aNIMATIONINFO = new XPAppearance.ANIMATIONINFO(value);
				XPAppearance.SystemParametersInfo(XPAppearance.SPI.SPI_SETANIMATION, XPAppearance.ANIMATIONINFO.GetSize(), ref aNIMATIONINFO, XPAppearance.SPIF.SPIF_SENDCHANGE);
			}
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false, SetLastError=true)]
		private static extern bool SystemParametersInfo(XPAppearance.SPI uiAction, uint uiParam, ref XPAppearance.ANIMATIONINFO pvParam, XPAppearance.SPIF fWinIni);

		private struct ANIMATIONINFO
		{
			public uint cbSize;

			private int iMinAnimate;

			public bool IMinAnimate
			{
				get
				{
					if (this.iMinAnimate == 0)
					{
						return false;
					}
					return true;
				}
				set
				{
					if (value)
					{
						this.iMinAnimate = 1;
						return;
					}
					this.iMinAnimate = 0;
				}
			}

			public ANIMATIONINFO(bool iMinAnimate)
			{
				this.cbSize = XPAppearance.ANIMATIONINFO.GetSize();
				if (iMinAnimate)
				{
					this.iMinAnimate = 1;
					return;
				}
				this.iMinAnimate = 0;
			}

			public static uint GetSize()
			{
				return (uint)Marshal.SizeOf(typeof(XPAppearance.ANIMATIONINFO));
			}
		}

		private enum SPI : uint
		{
			SPI_GETBEEP = 1,
			SPI_SETBEEP = 2,
			SPI_GETMOUSE = 3,
			SPI_SETMOUSE = 4,
			SPI_GETBORDER = 5,
			SPI_SETBORDER = 6,
			SPI_GETKEYBOARDSPEED = 10,
			SPI_SETKEYBOARDSPEED = 11,
			SPI_LANGDRIVER = 12,
			SPI_ICONHORIZONTALSPACING = 13,
			SPI_GETSCREENSAVETIMEOUT = 14,
			SPI_SETSCREENSAVETIMEOUT = 15,
			SPI_GETSCREENSAVEACTIVE = 16,
			SPI_SETSCREENSAVEACTIVE = 17,
			SPI_GETGRIDGRANULARITY = 18,
			SPI_SETGRIDGRANULARITY = 19,
			SPI_SETDESKWALLPAPER = 20,
			SPI_SETDESKPATTERN = 21,
			SPI_GETKEYBOARDDELAY = 22,
			SPI_SETKEYBOARDDELAY = 23,
			SPI_ICONVERTICALSPACING = 24,
			SPI_GETICONTITLEWRAP = 25,
			SPI_SETICONTITLEWRAP = 26,
			SPI_GETMENUDROPALIGNMENT = 27,
			SPI_SETMENUDROPALIGNMENT = 28,
			SPI_SETDOUBLECLKWIDTH = 29,
			SPI_SETDOUBLECLKHEIGHT = 30,
			SPI_GETICONTITLELOGFONT = 31,
			SPI_SETDOUBLECLICKTIME = 32,
			SPI_SETMOUSEBUTTONSWAP = 33,
			SPI_SETICONTITLELOGFONT = 34,
			SPI_GETFASTTASKSWITCH = 35,
			SPI_SETFASTTASKSWITCH = 36,
			SPI_SETDRAGFULLWINDOWS = 37,
			SPI_GETDRAGFULLWINDOWS = 38,
			SPI_GETNONCLIENTMETRICS = 41,
			SPI_SETNONCLIENTMETRICS = 42,
			SPI_GETMINIMIZEDMETRICS = 43,
			SPI_SETMINIMIZEDMETRICS = 44,
			SPI_GETICONMETRICS = 45,
			SPI_SETICONMETRICS = 46,
			SPI_SETWORKAREA = 47,
			SPI_GETWORKAREA = 48,
			SPI_SETPENWINDOWS = 49,
			SPI_GETFILTERKEYS = 50,
			SPI_SETFILTERKEYS = 51,
			SPI_GETTOGGLEKEYS = 52,
			SPI_SETTOGGLEKEYS = 53,
			SPI_GETMOUSEKEYS = 54,
			SPI_SETMOUSEKEYS = 55,
			SPI_GETSHOWSOUNDS = 56,
			SPI_SETSHOWSOUNDS = 57,
			SPI_GETSTICKYKEYS = 58,
			SPI_SETSTICKYKEYS = 59,
			SPI_GETACCESSTIMEOUT = 60,
			SPI_SETACCESSTIMEOUT = 61,
			SPI_GETSERIALKEYS = 62,
			SPI_SETSERIALKEYS = 63,
			SPI_GETSOUNDSENTRY = 64,
			SPI_SETSOUNDSENTRY = 65,
			SPI_GETHIGHCONTRAST = 66,
			SPI_SETHIGHCONTRAST = 67,
			SPI_GETKEYBOARDPREF = 68,
			SPI_SETKEYBOARDPREF = 69,
			SPI_GETSCREENREADER = 70,
			SPI_SETSCREENREADER = 71,
			SPI_GETANIMATION = 72,
			SPI_SETANIMATION = 73,
			SPI_GETFONTSMOOTHING = 74,
			SPI_SETFONTSMOOTHING = 75,
			SPI_SETDRAGWIDTH = 76,
			SPI_SETDRAGHEIGHT = 77,
			SPI_SETHANDHELD = 78,
			SPI_GETLOWPOWERTIMEOUT = 79,
			SPI_GETPOWEROFFTIMEOUT = 80,
			SPI_SETLOWPOWERTIMEOUT = 81,
			SPI_SETPOWEROFFTIMEOUT = 82,
			SPI_GETLOWPOWERACTIVE = 83,
			SPI_GETPOWEROFFACTIVE = 84,
			SPI_SETLOWPOWERACTIVE = 85,
			SPI_SETPOWEROFFACTIVE = 86,
			SPI_SETCURSORS = 87,
			SPI_SETICONS = 88,
			SPI_GETDEFAULTINPUTLANG = 89,
			SPI_SETDEFAULTINPUTLANG = 90,
			SPI_SETLANGTOGGLE = 91,
			SPI_GETWINDOWSEXTENSION = 92,
			SPI_SETMOUSETRAILS = 93,
			SPI_GETMOUSETRAILS = 94,
			SPI_GETSNAPTODEFBUTTON = 95,
			SPI_SETSNAPTODEFBUTTON = 96,
			SPI_SCREENSAVERRUNNING = 97,
			SPI_SETSCREENSAVERRUNNING = 97,
			SPI_GETMOUSEHOVERWIDTH = 98,
			SPI_SETMOUSEHOVERWIDTH = 99,
			SPI_GETMOUSEHOVERHEIGHT = 100,
			SPI_SETMOUSEHOVERHEIGHT = 101,
			SPI_GETMOUSEHOVERTIME = 102,
			SPI_SETMOUSEHOVERTIME = 103,
			SPI_GETWHEELSCROLLLINES = 104,
			SPI_SETWHEELSCROLLLINES = 105,
			SPI_GETMENUSHOWDELAY = 106,
			SPI_SETMENUSHOWDELAY = 107,
			SPI_GETSHOWIMEUI = 110,
			SPI_SETSHOWIMEUI = 111,
			SPI_GETMOUSESPEED = 112,
			SPI_SETMOUSESPEED = 113,
			SPI_GETSCREENSAVERRUNNING = 114,
			SPI_GETDESKWALLPAPER = 115,
			SPI_GETACTIVEWINDOWTRACKING = 4096,
			SPI_SETACTIVEWINDOWTRACKING = 4097,
			SPI_GETMENUANIMATION = 4098,
			SPI_SETMENUANIMATION = 4099,
			SPI_GETCOMBOBOXANIMATION = 4100,
			SPI_SETCOMBOBOXANIMATION = 4101,
			SPI_GETLISTBOXSMOOTHSCROLLING = 4102,
			SPI_SETLISTBOXSMOOTHSCROLLING = 4103,
			SPI_GETGRADIENTCAPTIONS = 4104,
			SPI_SETGRADIENTCAPTIONS = 4105,
			SPI_GETKEYBOARDCUES = 4106,
			SPI_GETMENUUNDERLINES = 4106,
			SPI_SETKEYBOARDCUES = 4107,
			SPI_SETMENUUNDERLINES = 4107,
			SPI_GETACTIVEWNDTRKZORDER = 4108,
			SPI_SETACTIVEWNDTRKZORDER = 4109,
			SPI_GETHOTTRACKING = 4110,
			SPI_SETHOTTRACKING = 4111,
			SPI_GETMENUFADE = 4114,
			SPI_SETMENUFADE = 4115,
			SPI_GETSELECTIONFADE = 4116,
			SPI_SETSELECTIONFADE = 4117,
			SPI_GETTOOLTIPANIMATION = 4118,
			SPI_SETTOOLTIPANIMATION = 4119,
			SPI_GETTOOLTIPFADE = 4120,
			SPI_SETTOOLTIPFADE = 4121,
			SPI_GETCURSORSHADOW = 4122,
			SPI_SETCURSORSHADOW = 4123,
			SPI_GETMOUSESONAR = 4124,
			SPI_SETMOUSESONAR = 4125,
			SPI_GETMOUSECLICKLOCK = 4126,
			SPI_SETMOUSECLICKLOCK = 4127,
			SPI_GETMOUSEVANISH = 4128,
			SPI_SETMOUSEVANISH = 4129,
			SPI_GETFLATMENU = 4130,
			SPI_SETFLATMENU = 4131,
			SPI_GETDROPSHADOW = 4132,
			SPI_SETDROPSHADOW = 4133,
			SPI_GETBLOCKSENDINPUTRESETS = 4134,
			SPI_SETBLOCKSENDINPUTRESETS = 4135,
			SPI_GETUIEFFECTS = 4158,
			SPI_SETUIEFFECTS = 4159,
			SPI_GETFOREGROUNDLOCKTIMEOUT = 8192,
			SPI_SETFOREGROUNDLOCKTIMEOUT = 8193,
			SPI_GETACTIVEWNDTRKTIMEOUT = 8194,
			SPI_SETACTIVEWNDTRKTIMEOUT = 8195,
			SPI_GETFOREGROUNDFLASHCOUNT = 8196,
			SPI_SETFOREGROUNDFLASHCOUNT = 8197,
			SPI_GETCARETWIDTH = 8198,
			SPI_SETCARETWIDTH = 8199,
			SPI_GETMOUSECLICKLOCKTIME = 8200,
			SPI_SETMOUSECLICKLOCKTIME = 8201,
			SPI_GETFONTSMOOTHINGTYPE = 8202,
			SPI_SETFONTSMOOTHINGTYPE = 8203,
			SPI_GETFONTSMOOTHINGCONTRAST = 8204,
			SPI_SETFONTSMOOTHINGCONTRAST = 8205,
			SPI_GETFOCUSBORDERWIDTH = 8206,
			SPI_SETFOCUSBORDERWIDTH = 8207,
			SPI_GETFOCUSBORDERHEIGHT = 8208,
			SPI_SETFOCUSBORDERHEIGHT = 8209,
			SPI_GETFONTSMOOTHINGORIENTATION = 8210,
			SPI_SETFONTSMOOTHINGORIENTATION = 8211
		}

		[Flags]
		private enum SPIF
		{
			None = 0,
			SPIF_UPDATEINIFILE = 1,
			SPIF_SENDCHANGE = 2,
			SPIF_SENDWININICHANGE = 2
		}
	}
}