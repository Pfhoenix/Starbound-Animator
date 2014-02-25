using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace StarboundAnimator
{
	public class Animation : Asset
	{
		public static Animation LoadFromFile(string path)
		{
			if (!File.Exists(path)) return null;

			string Source = File.ReadAllText(path);
			int i = Source.IndexOf('\n');
			if ((i == 0) || (Source[i - 1] != '\r')) Source = Source.Replace("\n", Environment.NewLine);

			Animation a = new Animation();
			a.Source = Source;

			return a;
		}
	}
}
