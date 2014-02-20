using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace StarboundAnimator
{
	public class Animation : Asset
	{
		public Animation(string path) : base(path) {}

		public override void LoadFromFile(string path)
		{
			Source = File.ReadAllText(path);

			return;
		}
	}
}
