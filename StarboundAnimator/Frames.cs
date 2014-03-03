using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace StarboundAnimator
{
	public class _frameName
	{
		public string name;
		public byte source;
		public string aliasof;

		public _frameName(string n, byte s, string ao)
		{
			name = n;
			source = s;
			aliasof = ao;
		}
	}

	public class _frameItem
	{
		public List<_frameName> names = new List<_frameName>();
		public int x, y;
		public int width, height;

		public _frameItem() { }

		public _frameItem(int X, int Y, int W, int H)
		{
			x = X;
			y = Y;
			width = W;
			height = H;
		}

		public void AddName(string n, byte s, string ao = "")
		{
			names.Add(new _frameName(n, s, ao));
		}

		public void RemoveName(string n)
		{
			names.RemoveAll(fn => fn.name == n);
		}
	}

	public class _frameGrid
	{
		public List<int> size = new List<int>();
		public List<int> dimensions = new List<int>();
		public List<List<string>> names;// = new List<List<string>>();
	}

	public class Frames : Asset
	{
		public string image;

		public _frameGrid frameGrid;
		public Dictionary<string, int[]> frameList;
		public Dictionary<string, string> aliases;

		[NonSerialized]
		public Image Img;
		[NonSerialized]
		public Dictionary<string, _frameItem> LookupFrameItems = new Dictionary<string, _frameItem>();
		[NonSerialized]
		public List<_frameItem> ListFrameItems = new List<_frameItem>();


		public Frames()
		{
		}

		public static Frames LoadFromFile(string path)
		{
			if (!File.Exists(path)) return null;

			string Source = File.ReadAllText(path);
			int i = Source.IndexOf('\n');
			if ((i == 0) || (Source[i - 1] != '\r')) Source = Source.Replace("\n", Environment.NewLine);

			Frames frame = JsonConvert.DeserializeObject<Frames>(Source);
			if (frame != null)
			{
				frame.Source = Source;
				// sanity check loaded data
				if (frame.frameGrid != null)
				{
					if (frame.frameGrid.size.Count == 0) frame.frameGrid = null;
					else if (frame.frameGrid.size.Count == 1) frame.frameGrid.size.Add(1);
					else frame.frameGrid.size.RemoveRange(2, frame.frameGrid.size.Count - 2);
				}
				if (frame.frameGrid != null)
				{
					if (frame.frameGrid.dimensions.Count == 0) frame.frameGrid = null;
					else if (frame.frameGrid.dimensions.Count == 1) frame.frameGrid.dimensions.Add(1);
					else frame.frameGrid.dimensions.RemoveRange(2, frame.frameGrid.dimensions.Count - 2);
				}
				if ((frame.frameGrid != null) && (frame.frameGrid.names != null))
				{
					if (frame.frameGrid.names.Count == 0) frame.frameGrid.names = null;
				}
			}

			frame.RecalcFrameItems();

			return frame;
		}

		public void RecalcFrameItems()
		{
			LookupFrameItems.Clear();
			ListFrameItems.Clear();
			_frameItem item = null;
			if (frameGrid != null)
			{
				string name;
				for (int j = 0; j < frameGrid.dimensions[1]; j++)
					for (int i = 0; i < frameGrid.dimensions[0]; i++)
					{
						name = (i + j * frameGrid.dimensions[0]).ToString();
						item = new _frameItem(i * frameGrid.size[0], j * frameGrid.size[1], frameGrid.size[0], frameGrid.size[1]);
						item.AddName(name, Globals.FrameSource_Grid);
						LookupFrameItems.Add(name, item);
						ListFrameItems.Add(item);
					}

				if (frameGrid.names != null)
				{
					for (int j = 0; j < frameGrid.names.Count; j++)
						for (int i = 0; i < frameGrid.names[j].Count; i++)
						{
							if (string.IsNullOrEmpty(frameGrid.names[j][i])) continue;
							if (LookupFrameItems.ContainsKey(frameGrid.names[j][i])) continue;

							name = frameGrid.names[j][i];
							if ((i < frameGrid.dimensions[0]) && (j < frameGrid.dimensions[1]))
							{
								item = LookupFrameItems[(i + j * frameGrid.dimensions[0]).ToString()];
							}
							else
							{
								item = new _frameItem(i * frameGrid.size[0], j * frameGrid.size[1], frameGrid.size[0], frameGrid.size[1]);
								ListFrameItems.Add(item);
							}
							LookupFrameItems.Add(name, item);
							item.AddName(name, Globals.FrameSource_Name);
						}
				}
			}

			if (aliases != null)
			{
				foreach (KeyValuePair<string, string> entry in aliases)
				{
					if (LookupFrameItems.ContainsKey(entry.Key)) continue;
					if (!LookupFrameItems.ContainsKey(entry.Value)) continue;

					item = LookupFrameItems[entry.Value];
					item.AddName(entry.Key, Globals.FrameSource_Alias, entry.Value);
					LookupFrameItems.Add(entry.Key, item);
				}
			}
		}

		public _frameItem GetItemUnder(int x, int y, byte sourceflags)
		{
			foreach (_frameItem fi in ListFrameItems)
			{
				if ((x >= fi.x) && (x <= fi.x + fi.width) &&
					(y >= fi.y) && (y <= fi.y + fi.height))
				{
					foreach (_frameName fn in fi.names)
					{
						if ((sourceflags & fn.source) > 0)
						{
							return fi;
						}
					}
				}
			}

			return null;
		}
	}

	/*public class FrameGridPropertiesConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(FrameGridProperty)) return true;

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
		{
			if (destinationType == typeof(System.String) && value is FrameGridProperty)
			{
				FrameGridProperty fgp = (FrameGridProperty)value;

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < fgp.size.Count; i++)
				{
					if (i > 0) sb.Append(',');
					sb.Append(fgp.size[i]);
				}
				sb.Append('|');
				for (int i = 0; i < fgp.dimensions.Count; i++)
				{
					if (i > 0) sb.Append(',');
					sb.Append(fgp.dimensions[i]);
				}
				sb.Append('|');
				for (int i = 0; i < fgp.names.Count; i++)
				{
					if (i > 0) sb.Append(':');
					for (int j = 0; j < fgp.names[i].Count; j++)
					{
						if (j > 0) sb.Append(',');
						sb.Append(fgp.names[i][j]);
					}
				}

				return sb.ToString();
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				try
				{
					string[] s = ((string)value).Split(new char[] { '|' });
					if ((s != null) && (s.Length == 3))
					{
						char[] commasplit = new char[] { ',' };

						FrameGridProperty fgp = new FrameGridProperty();

						string[] s1 = s[0].Split(commasplit);
						for (int i = 0; i < s1.Length; i++)
						{
							int ti = 0;
							if (int.TryParse(s1[i], out ti)) fgp.size.Add(ti);
						}

						s1 = s[1].Split(commasplit);
						for (int i = 0; i < s1.Length; i++)
						{
							int ti = 0;
							if (int.TryParse(s1[i], out ti)) fgp.dimensions.Add(ti);
						}

						s1 = s[2].Split(new char[] { ':' });
						string[] s2;
						List<string> ls;
						for (int i = 0; i < s1.Length; i++)
						{
							ls = new List<string>();

							s2 = s1[i].Split(commasplit);
							for (int j = 0; j < s2.Length; j++)
							{
								ls.Add(s2[j]);
							}
							fgp.names.Add(ls);
						}

						return fgp;
					}
				}
				catch
				{
					throw new ArgumentException(
						"Can not convert '" + (string)value +
										   "' to type FrameGridProperties");
				}
			}

			return base.ConvertFrom(context, culture, value);
		}
	}*/
}
