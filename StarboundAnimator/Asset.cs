using System;

namespace StarboundAnimator
{
	public abstract class Asset
	{
		public string Source;

		public Asset(string path)
		{
			LoadFromFile(path);
		}

		public abstract void LoadFromFile(string path);
	}
}
