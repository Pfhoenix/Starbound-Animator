using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarboundAnimator
{
	[Flags]
	public enum FrameSource
	{
		None = 0,
		Grid = 1,
		Name = Grid << 1,
		Alias = Name << 1,
		List = Alias << 1,
		All = List | Alias | Name | Grid
	}

	public class Globals
	{
		public static Form1 AppForm;
		public static string AppPath;
		public static Settings AppSettings;
		public static Frames WorkingFrames;
		public static Animation WorkingAnimation;

		public const int MajVer = 0;
		public const int MinVer = 3;
		public static string AppVersion = "v" + MajVer.ToString() + "." + MinVer.ToString();
	}
}
