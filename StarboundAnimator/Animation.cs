using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace StarboundAnimator
{
	public class Animation : Asset
	{
		[NonSerialized]
		public const string FileExtension = ".animation";

		public static Animation LoadFromFile(string path)
		{
			Animation a = Asset.LoadFromFile<Animation>(path);
			if (a != null)
			{
			}

			return a;
		}
	}
}
