using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace StarboundAnimator
{
	[Serializable]
	public class CachedAsset
	{
		public string Title;
		public string Path;
		public List<string> Assets;

		public CachedAsset()
		{
			Title = "";
			Path = "";
			Assets = new List<string>();
		}

		public CachedAsset(string t, string p)
		{
			Title = t;
			Path = p;
			Assets = new List<string>();
		}

		public void SetAssetsFromFoundList(List<string> foundlist)
		{
			Assets.Clear();
			Assets.AddRange(foundlist);
		}
	}

	[Serializable]
    public class Settings
    {
		public int WindowWidth;
		public int WindowHeight;
		public int ExplorerWidth;
		public int PropertiesWidth;
		public string PathToLastProject;
		// public Color LastCanvasBackgroundColor;
		public List<CachedAsset> CachedAssets;

		public Settings()
        {
			PathToLastProject = "";
			CachedAssets = new List<CachedAsset>();
        }

        public static Settings LoadSettings()
        {
            Settings gs = new Settings();

            string file = Path.Combine(Globals.AppPath, "settings.xml");

            FileStream fs = File.Open(file, FileMode.OpenOrCreate, FileAccess.Read);
            if (fs.Length > 0)
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Settings));
                gs = xmls.Deserialize(fs) as Settings;
            }
            fs.Close();

            return gs;
        }

        public void SaveSettings()
        {
            string file = Path.Combine(Globals.AppPath, "settings.xml");

			FileStream fs = File.Open(file, FileMode.Create, FileAccess.Write);
			XmlSerializer xmls = new XmlSerializer(typeof(Settings));
            xmls.Serialize(fs, this);
            fs.Close();
        }

		public void ValidateSettings()
		{
			for (int i = 0; i < CachedAssets.Count; i++)
			{
				if (!Directory.Exists(CachedAssets[i].Path))
				{
					DialogResult dr = MessageBox.Show("Asset Scan Path \"" + CachedAssets[i].Path + "\" does not exist! Remove from the list?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
					if (dr == DialogResult.Yes) CachedAssets.RemoveAt(i--);
					else CachedAssets[i].Assets.Clear();
				}
				else
				{
					if (string.IsNullOrEmpty(CachedAssets[i].Title))
					{
						MessageBox.Show("Asset Scan Path \"" + CachedAssets[i].Path + "\" is missing a title!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						CachedAssets[i].Title = "default path title";
					}
				}

				// cull out duplicate path entries
				for (int j = i + 1; j < CachedAssets.Count; j++)
				{
					if (string.Compare(CachedAssets[j].Path, CachedAssets[i].Path, true) == 0)
					{
						CachedAssets.RemoveAt(j--);
					}
					if (CachedAssets[j].Title == CachedAssets[i].Title)
					{
						string t = CachedAssets[j].Title;
						if (char.IsNumber(t[t.Length - 1]))
						{
							bool bDone = false;
							for (int c = t.Length - 2; c >= 0; c--)
							{
								if (!char.IsNumber(t[c]))
								{
									int ni = int.Parse(t.Substring(c + 1));
									t = (ni + 1).ToString();
									bDone = true;
									break;
								}
							}
							if (!bDone)
							{
								// whole thing is a number
								int ni = int.Parse(t);
								t = (ni + 1).ToString();
							}
						}
						else t += '1';

						CachedAssets[j].Title = t;
					}
				}
			}

			if (!File.Exists(PathToLastProject)) PathToLastProject = "";
			else
			{
				// load last project
			}
		}

		public void RemoveAssetScanPath(string ttr)
		{
			int i = CachedAssets.FindIndex(ca => ca.Title == ttr);
			CachedAssets.RemoveAt(i);
		}

		public string GetPathForTitle(string title)
		{
			CachedAsset ca = CachedAssets.Find(tca => title == tca.Title);
			if (ca != null) return ca.Path;
			else return "";
		}

		public string GetTitleForPath(string path)
		{
			CachedAsset ca = CachedAssets.Find(tca => string.Compare(tca.Path, path, true) == 0);
			if (ca != null) return ca.Title;
			else return "";
		}
    }
}
