using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;

namespace StarboundAnimator
{
	[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
	public class FrameGridProperty
	{
		public Size size;
		[DescriptionAttribute("The dimensions, in pixels, of the individual frames in the grid.")]
		public Size Size
		{
			get { return size; }
			set { size = value; }
		}

		public Size dimensions;
		[DescriptionAttribute("The dimensions, in number of frames, of the grid.")]
		public Size Dimensions
		{
			get { return dimensions; }
			set { dimensions = value; }
		}

		public string names;
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)),
		 DescriptionAttribute("Unique names, with optional numbering for sequential ordering, for the frames.")]
		public string Names
		{
			get { return names; }
			set { names = value; }
		}
	}

	public class FramesProperties
	{
		public Frames Frame;

		public string Image
		{
			get { return Frame.image; }
			set { Frame.image = value; }
		}

		public FrameGridProperty FGP = new FrameGridProperty();
		public FrameGridProperty FrameGrid
		{
			get { return FGP; }
			set
			{
				FGP = value;
				if (Frame.frameGrid == null) Frame.frameGrid = new _frameGrid();
				Frame.frameGrid.size.Clear();
				Frame.frameGrid.size.Add(FGP.size.Width);
				Frame.frameGrid.size.Add(FGP.size.Height);
				Frame.frameGrid.dimensions.Clear();
				Frame.frameGrid.dimensions.Add(FGP.dimensions.Width);
				Frame.frameGrid.dimensions.Add(FGP.dimensions.Height);
				Frame.frameGrid.names.Clear();
				if (!string.IsNullOrEmpty(FGP.names))
				{
					string ts = FGP.names.Replace(Environment.NewLine, "|");
					string[] s = FGP.names.Split(new char[] { '|' });
					char[] spacesplit = new char[] { ' ' };
					for (int i = 0; i < s.Length; i++)
					{
						Frame.frameGrid.names.Add(new List<string>());
						string[] ss = s[i].Split(spacesplit);
						for (int j = 0; j < ss.Length; j++)
						{
							if (ss[j] == "!null!") Frame.frameGrid.names[i].Add(null);
							else Frame.frameGrid.names[i].Add(ss[j]);
						}
					}
				}
			}
		}

		public Dictionary<string, int[]> FrameList
		{
			get { return Frame.frameList; }
			set { Frame.frameList = FrameList; }
		}

		public void InitForFrames(Frames frame)
		{
			Frame = frame;

			if (Frame.frameGrid != null)
			{
				if (Frame.frameGrid.size.Count >= 2)
				{
					FrameGrid.size.Width = Frame.frameGrid.size[0];
					FrameGrid.size.Height = Frame.frameGrid.size[1];
				}
				else if (Frame.frameGrid.size.Count == 1)
				{
					FrameGrid.size.Width = Frame.frameGrid.size[0];
					FrameGrid.size.Height = 1;
					Frame.frameGrid.size.Add(1);
				}
				else
				{
					FrameGrid.size.Width = 1;
					FrameGrid.size.Height = 1;
					Frame.frameGrid.size.Add(1);
					Frame.frameGrid.size.Add(1);
				}

				if (Frame.frameGrid.dimensions.Count >= 2)
				{
					FrameGrid.dimensions.Width = Frame.frameGrid.dimensions[0];
					FrameGrid.dimensions.Height = Frame.frameGrid.dimensions[1];
				}
				else if (Frame.frameGrid.dimensions.Count == 1)
				{
					FrameGrid.dimensions.Width = Frame.frameGrid.dimensions[0];
					FrameGrid.dimensions.Height = 1;
					Frame.frameGrid.dimensions.Add(1);
				}
				else
				{
					FrameGrid.dimensions.Width = 1;
					FrameGrid.dimensions.Height = 1;
					Frame.frameGrid.dimensions.Add(1);
					Frame.frameGrid.dimensions.Add(1);
				}

				if (Frame.frameGrid.names.Count > 0)
				{
					StringBuilder sb = new StringBuilder();
					for (int i = 0; i < Frame.frameGrid.names.Count; i++)
					{
						if (i > 0) sb.AppendLine();
						for (int j = 0; j < Frame.frameGrid.names[i].Count; j++)
						{
							if (j > 0) sb.Append(' ');
							if (string.IsNullOrEmpty(Frame.frameGrid.names[i][j])) sb.Append("!null!");
							else sb.Append(Frame.frameGrid.names[i][j]);
						}
					}

					FrameGrid.names = sb.ToString();
				}
			}
		}
	}
}
