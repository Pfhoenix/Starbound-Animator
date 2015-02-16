﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace StarboundAnimator
{
	public abstract class Asset
	{
		[NonSerialized]
		public const string FileExtension = ".";
		[NonSerialized]
		public string Source = "";
		[NonSerialized]
		public string Filename = "";
		[NonSerialized]
		public string FilePath = "";
		[NonSerialized]
		public bool bReadOnly = false;

		public static T LoadFromFile<T>(string path) where T : Asset
		{
			if (!File.Exists(path)) return null;

			string Source = File.ReadAllText(path);
			int i = Source.IndexOf('\n');
			if ((i == 0) || (Source[i - 1] != '\r')) Source = Source.Replace("\n", Environment.NewLine);

			T a = JsonConvert.DeserializeObject<T>(Source);
			if (a != null)
			{
				a.Filename = Path.GetFileName(path);
				a.FilePath = Path.GetDirectoryName(path);
				a.Source = Source;
			}

			return a;
		}

		public void SaveToFile()
		{
			try
			{
				JsonSerializerSettings jss = new JsonSerializerSettings();
				jss.NullValueHandling = NullValueHandling.Ignore;
				string text = JsonConvert.SerializeObject(this, Formatting.Indented, jss);
				Source = text;
				File.WriteAllText(Path.Combine(FilePath, Filename), text);
			}
			catch { }
		}

	}
}
