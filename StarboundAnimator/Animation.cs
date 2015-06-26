using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace StarboundAnimator
{
	public class Animation : Asset
	{
		[NonSerialized]
		public new const string FileExtension = ".animation";

		public static Animation LoadFromFile(string path)
		{
			VariantAnimation va = Asset.LoadFromFile<VariantAnimation>(path);
			if (va != null)
			{
				if (va.variants > 0)
				{
					// init variant animation stuff
					return va;
				}
			}

			ComplexAnimation ca = Asset.LoadFromFile<ComplexAnimation>(path);
			if (ca != null)
			{
				// init complex animation stuff
			}

			return ca;
		}
	}

	public class VariantAnimation : Animation
	{
		public string frames;
		public int variants;
		public int frameNumber;
		public float animationCycle;
		public int[] offset;
	}

	public class ComplexAnimation : Animation
	{
	}
}
