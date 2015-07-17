using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace StarboundAnimator
{
	public enum EEdgeCorner { None = 0, TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left }

	public class _frameName
	{
		public string name;
		public FrameSource source;
		public string aliasof;

		public _frameName(string n, FrameSource s, string ao)
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

		public void AddName(string n, FrameSource s, string ao = "")
		{
			names.Add(new _frameName(n, s, ao));
		}

		public void RemoveName(string n)
		{
			names.RemoveAll(fn => fn.name == n);
		}

		public EEdgeCorner GetEdgeOrCorner(int px, int py, int tolerance)
		{
			if (Math.Abs(px - x) <= tolerance)
			{
				if (Math.Abs(py - y) <= tolerance) return EEdgeCorner.TopLeft;
				if (Math.Abs(py - y - height) <= tolerance) return EEdgeCorner.BottomLeft;
				return EEdgeCorner.Left;
			}
			if (Math.Abs(px - x - width) <= tolerance)
			{
				if (Math.Abs(py - y) <= tolerance) return EEdgeCorner.TopRight;
				if (Math.Abs(py - y - height) <= tolerance) return EEdgeCorner.BottomRight;
				return EEdgeCorner.Right;
			}
			if (Math.Abs(py - y) <= tolerance) return EEdgeCorner.Top;
			if (Math.Abs(py - y - height) <= tolerance) return EEdgeCorner.Bottom;

			return EEdgeCorner.None;
		}
	}

	public class _frameGrid
	{
		public List<int> size = new List<int>();
		public List<int> dimensions = new List<int>();
		public List<List<string>> names;

		public _frameGrid() { }

		public _frameGrid(int sw, int sh, int dw, int dh)
		{
			size = new List<int>(2);
			size.Add(sw);
			size.Add(sh);

			dimensions = new List<int>(2);
			dimensions.Add(dw);
			dimensions.Add(dh);
		}

		public void CreateNames()
		{
			names = new List<List<string>>(dimensions[1]);

			for (int j = 0; j < dimensions[1]; j++)
			{
				names.Add(new List<string>(dimensions[0]));
				for (int i = 0; i < dimensions[0]; i++)
					names[j].Add(null);
			}
		}

		// returns null if dn isn't a proper default frame name (a number) or if no such default frame number
		// else returns the prior name, "" if none
		public string SetNameFor(string dn, string n)
		{
			int di = -1;
			int.TryParse(dn, out di);
			if (di < 0) return null;

			if (names == null) CreateNames();

			for (int i = 0; i < names.Count; i++)
			{
				if (names[i].Count <= di)
				{
					di -= names[i].Count;
				}
				else
				{
					string on = names[i][di];
					names[i][di] = n;
					return (on == null ? "" : on);
				}
			}

			return null;
		}
	}

	public class Frames : JsonAsset
	{
		public string image;

		public _frameGrid frameGrid;
		public Dictionary<string, int[]> frameList;
		public Dictionary<string, string> aliases;

		[NonSerialized]
		public new const string FileExtension = ".frames";
		[NonSerialized]
		public Image Img;
		[NonSerialized]
		public Image AltImg;
		[NonSerialized]
		public Dictionary<string, _frameItem> LookupFrameItems = new Dictionary<string, _frameItem>();
		[NonSerialized]
		public List<_frameItem> ListFrameItems = new List<_frameItem>();


		public Frames()
		{
		}

		public void CreateFrameGrid()
		{
			frameGrid = new _frameGrid(1, 1, 1, 1);
		}

		public void CreateFrameList()
		{
			frameList = new Dictionary<string, int[]>();
		}

		public new static Frames LoadFromFile(string path)
		{
			Frames frame = JsonAsset.LoadFromFile<Frames>(path);
			if (frame != null)
			{
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

				frame.RecalcFrameItems();
			}

			return frame;
		}

		public void SetFrameGridName(string d, string n)
		{
			if (frameGrid == null) return;

			string on = frameGrid.SetNameFor(d, n);
			if (on == null) return;
			else
			{
				_frameItem fi = GetFrameItemOf(d);
				if (on == "")
				{
					fi.AddName(n, FrameSource.Name);
				}
				else
				{
					foreach (_frameName fn in fi.names)
					{
						if (fn.name == on)
						{
							fn.name = n;
							break;
						}
					}

					LookupFrameItems.Remove(on);
				}

				LookupFrameItems.Add(n, fi);
			}
		}

		public void SetFrameToList(_frameItem fi, string n)
		{
			for (int i = 0; i < fi.names.Count; i++)
			{
				if (fi.names[i].name == n)
				{
					SetFrameToList(fi, fi.names[i]);
					return;
				}
			}
		}

		public void SetFrameToList(_frameItem fi, _frameName fn)
		{
			fn.source = FrameSource.List;
			if (frameList == null) frameList = new Dictionary<string, int[]>();
			frameList.Add(fn.name, new int[] { fi.x, fi.y, fi.x + fi.width - 1, fi.y + fi.height - 1 });
		}

		public void AddFrameListItem(string n, int x, int y, int w, int h)
		{
			_frameItem item = GetFrameItemOfSize(x, y, w, h);
			if (item == null)
			{
				item = new _frameItem(x, y, w, h);
				ListFrameItems.Add(item);
			}
			LookupFrameItems.Add(n, item);
			item.AddName(n, FrameSource.List);

			if (frameList == null) frameList = new Dictionary<string, int[]>();
			frameList.Add(n, new int[] { x, y, x + w - 1, y + h - 1 });
		}

		public void UpdateFrameListItem(_frameItem fi)
		{
			if (frameList == null) return;
			foreach (_frameName fn in fi.names)
			{
				if (fn.source == FrameSource.List)
				{
					int[] v = frameList[fn.name];
					v[0] = fi.x;
					v[1] = fi.y;
					v[2] = fi.width;
					v[3] = fi.height;
					frameList[fn.name] = v;
					break;
				}
			}
		}

		public void AddAlias(string a, string ao)
		{
			_frameItem fi = GetFrameItemOf(ao);
			if (fi != null)
			{
				fi.AddName(a, FrameSource.Alias, ao);
				LookupFrameItems.Add(a, fi);
				if (aliases == null) aliases = new Dictionary<string, string>();
				aliases.Add(a, ao);
			}
		}

		public string ChangeImage(string nifn)
		{
			string err = "";
			string path = Path.Combine(FilePath, nifn);
			try
			{
				Image img = Image.FromFile(path);
				if (img != null)
				{
					Img = img;
					image = nifn;
				}
			}
			catch (Exception e)
			{
				err = e.Message;
			}

			return err;
		}

		public void ConvertGridtoList(bool bConvertDefaults, bool bConvertNames)
		{
			if (frameGrid == null) return;
			if (frameList == null) CreateFrameList();

			frameGrid = null;

			_frameItem fi;
			_frameName fn;
			for (int i = 0; i < ListFrameItems.Count; i++)
			{
				fi = ListFrameItems[i];
				for (int j = 0; j < fi.names.Count; j++)
				{
					fn = fi.names[j];
					if (fn.source == FrameSource.Grid)
					{
						if (bConvertDefaults) SetFrameToList(fi, fn);
						else
						{
							fi.names.RemoveAt(j--);
							LookupFrameItems.Remove(fn.name);
						}
					}
					else if (fn.source == FrameSource.Name)
					{
						if (bConvertNames) SetFrameToList(fi, fn);
						else
						{
							fi.names.RemoveAt(j--);
							LookupFrameItems.Remove(fn.name);
						}
					}
				}

				if (fi.names.Count == 0) ListFrameItems.RemoveAt(i--);
			}
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
						item.AddName(name, FrameSource.Grid);
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
							item.AddName(name, FrameSource.Name);
						}
				}
			}

			if (frameList != null)
			{
				foreach (KeyValuePair<string, int[]> entry in frameList)
				{
					item = GetFrameItemOfSize(entry.Value[0], entry.Value[1], entry.Value[2] - entry.Value[0] + 1, entry.Value[3] - entry.Value[1] + 1);
					if (item == null)
					{
						item = new _frameItem(entry.Value[0], entry.Value[1], entry.Value[2] - entry.Value[0] + 1, entry.Value[3] - entry.Value[1] + 1);
						ListFrameItems.Add(item);
					}
					LookupFrameItems.Add(entry.Key, item);
					item.AddName(entry.Key, FrameSource.List);
				}
			}

			if (aliases != null)
			{
				foreach (KeyValuePair<string, string> entry in aliases)
				{
					if (LookupFrameItems.ContainsKey(entry.Key)) continue;
					if (!LookupFrameItems.ContainsKey(entry.Value)) continue;

					item = LookupFrameItems[entry.Value];
					item.AddName(entry.Key, FrameSource.Alias, entry.Value);
					LookupFrameItems.Add(entry.Key, item);
				}
			}
		}

		public _frameItem GetItemUnder(int x, int y, FrameSource sourceflags)
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

		public List<_frameName> GetAliasesFor(string fname)
		{
			List<_frameName> als = new List<_frameName>();

			foreach (_frameItem fi in ListFrameItems)
			{
				foreach (_frameName fn in fi.names)
				{
					if (fn.aliasof == fname) als.Add(fn);
				}
			}

			return als;
		}

		public _frameItem GetFrameItemOf(_frameName fn)
		{
			if (LookupFrameItems.ContainsKey(fn.name)) return LookupFrameItems[fn.name];
			else return null;
		}

		public _frameItem GetFrameItemOf(string fnn)
		{
			if (LookupFrameItems.ContainsKey(fnn)) return LookupFrameItems[fnn];
			else return null;
		}

		public _frameItem GetFrameItemOfSize(int x, int y, int w, int h)
		{
			foreach (_frameItem fi in ListFrameItems)
			{
				if ((fi.x == x) && (fi.y == y) && (fi.width == w) && (fi.height == h)) return fi;
			}

			return null;
		}

		public void RemoveFrame(_frameName fn)
		{
			bool bRemove = false;

			if ((fn.source == FrameSource.List) && (frameList != null))
			{
				frameList.Remove(fn.name);
				if (frameList.Count == 0) frameList = null;
				bRemove = true;
			}
			else if ((fn.source == FrameSource.Name) && (frameGrid != null) && (frameGrid.names != null))
			{
				for (int i = 0; i < frameGrid.names.Count; i++)
				{
					for (int j = 0; j < frameGrid.names[i].Count; j++)
					{
						if (frameGrid.names[i][j] == fn.name)
						{
							frameGrid.names[i][j] = null;
							bRemove = true;
							break;
						}
					}

					if (bRemove) break;
				}
			}
			else if ((fn.source == FrameSource.Alias) && (aliases != null))
			{
				aliases.Remove(fn.name);
				if (aliases.Count == 0) aliases = null;
				bRemove = true;
			}

			if (bRemove)
			{
				_frameItem fi = GetFrameItemOf(fn);
				if (fi != null)
				{
					fi.RemoveName(fn.name);
					if (fi.names.Count == 0) ListFrameItems.Remove(fi);
					LookupFrameItems.Remove(fn.name);
				}
			}
		}

		void CleanupAliasesAt(_frameItem fi)
		{
			for (int i = 0; i < fi.names.Count; i++)
			{
				if (fi.names[i].source == FrameSource.Alias)
				{
					_frameName fn = fi.names.Find(tfn => tfn.name == fi.names[i].aliasof);
					if (fn == null)
					{
						LookupFrameItems.Remove(fi.names[i].name);
						aliases.Remove(fi.names[i].name);
						fi.names.RemoveAt(i--);
					}
				}
			}
		}

		public void RemoveFrameGrid(bool bAliasesToo)
		{
			frameGrid = null;

			_frameItem fi;
			_frameName fn;
			for (int i = 0; i < ListFrameItems.Count; i++)
			{
				fi = ListFrameItems[i];
				for (int j = 0; j < fi.names.Count; j++)
				{
					fn = fi.names[j];
					if ((fn.source == FrameSource.Grid) || (fn.source == FrameSource.Name))
					{
						fi.names.RemoveAt(j--);
						LookupFrameItems.Remove(fn.name);
					}
				}

				if (bAliasesToo) CleanupAliasesAt(fi);

				if (fi.names.Count == 0) ListFrameItems.RemoveAt(i--);
			}
		}
	}
}
