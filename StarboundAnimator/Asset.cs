using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StarboundAnimator
{
	public abstract class Asset
	{
		public abstract Asset LoadFromFile(string path);
	}
}
