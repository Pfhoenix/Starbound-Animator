using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public class Globals
	{
		public static Form1 AppForm;
		public static string AppPath;
		public static Settings AppSettings;
		public static Frames WorkingFrames;
		public static Animation WorkingAnimation;

		public const int FrameSource_None = 0;
		public const int FrameSource_Grid = 1;
		public const int FrameSource_Name = 2;
		public const int FrameSource_Alias = 4;
		public const int FrameSource_List = 8;
		public const int FrameSource_All = 15;

	}
}
