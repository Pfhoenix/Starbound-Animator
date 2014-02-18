using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StarboundAnimator
{
	[Serializable]
	public class Project
	{
		string FilePath;

		public string Title;
		public List<string> AnimPaths;	// these are relative paths, mirroring Starbounds setup, i.e. "/animations/blah/whatever.animation"

		public Project()
		{
			FilePath = "";
			Title = "default project title";
			AnimPaths = new List<string>();
		}

		public static Project LoadFromFile(string path)
		{
			Project p = new Project();

			FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
			if (fs.Length > 0)
			{
				XmlSerializer xmls = new XmlSerializer(typeof(Project));
				p = xmls.Deserialize(fs) as Project;
				if (p != null) p.FilePath = path;
			}
			fs.Close();

			return p;
		}

		public static Project CreateNew(string path)
		{
			Project p = new Project();
			p.FilePath = path;

			string newpath = Path.Combine(path, "/animations");
			Directory.CreateDirectory(newpath);
			newpath = Path.Combine(path, "/frames");
			Directory.CreateDirectory(newpath);

			return p;
		}

		public void SaveProject()
		{
			if (FilePath == "") return;

			FileStream fs = File.Open(FilePath, FileMode.Create, FileAccess.Write);
			XmlSerializer xmls = new XmlSerializer(typeof(Project));
			xmls.Serialize(fs, this);
			fs.Close();
		}
	}
}
