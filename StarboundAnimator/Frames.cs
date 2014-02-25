using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace StarboundAnimator
{
	public enum EFrameSource { FS_Default, FS_Name, FS_Alias };

	public class _frameItem
	{
		public EFrameSource source;
		public int x, y;
		public int width, height;

		public readonly bool bCopied;

		public _frameItem() { }

		public _frameItem(int X, int Y, int W, int H, EFrameSource S)
		{
			x = X;
			y = Y;
			width = W;
			height = H;
			source = S;
		}

		private _frameItem(int X, int Y, int W, int H, EFrameSource S, bool bC)
		{
			x = X;
			y = Y;
			width = W;
			height = H;
			source = S;
			bCopied = bC;
		}

		public _frameItem Copy()
		{
			return new _frameItem(x, y, width, height, source, true);
		}
	}

	public class _frameGrid
	{
		public List<int> size = new List<int>();
		public List<int> dimensions = new List<int>();
		public List<List<string>> names = new List<List<string>>();
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
		public Dictionary<string, _frameItem> FrameItems = new Dictionary<string, _frameItem>();


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
			}

			frame.RecalcFrameItems();

			return frame;
		}

		public void RecalcFrameItems()
		{
			FrameItems.Clear();
			_frameItem item = null;
			if (frameGrid != null)
			{
				for (int j = 0; j < frameGrid.dimensions[1]; j++)
					for (int i = 0; i < frameGrid.dimensions[0]; i++)
					{
						item = new _frameItem(i * frameGrid.size[0], j * frameGrid.size[1], frameGrid.size[0], frameGrid.size[1], EFrameSource.FS_Default);
						FrameItems.Add((i + j * frameGrid.dimensions[1]).ToString(), item);
					}

				for (int j = 0; j < frameGrid.names.Count; j++)
					for (int i = 0; i < frameGrid.names[j].Count; i++)
					{
						if (string.IsNullOrEmpty(frameGrid.names[j][i])) continue;
						if (FrameItems.ContainsKey(frameGrid.names[j][i])) continue;
						if ((i < frameGrid.dimensions[0]) && (j < frameGrid.dimensions[1]))
						{
							item = FrameItems[(i + j * frameGrid.dimensions[1]).ToString()].Copy();
							item.source = EFrameSource.FS_Name;
						}
						else
						{
							item = new _frameItem(i * frameGrid.size[0], j * frameGrid.size[1], frameGrid.size[0], frameGrid.size[1], EFrameSource.FS_Name);
						}
						FrameItems.Add(frameGrid.names[j][i], item);
					}
			}

			if (aliases != null)
			{
				foreach (KeyValuePair<string, string> entry in aliases)
				{
					if (FrameItems.ContainsKey(entry.Key)) continue;
					if (!FrameItems.ContainsKey(entry.Value)) continue;

					item = FrameItems[entry.Value].Copy();
					item.source = EFrameSource.FS_Alias;
					FrameItems.Add(entry.Key, item);
				}
			}
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
