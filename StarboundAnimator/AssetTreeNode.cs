using System;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public class AssetTreeNode : TreeNode
	{
		public Asset Asset;

		public AssetTreeNode(string title, int ilID, int silID, Asset a)
			: base(title, ilID, silID)
		{
			Asset = a;
		}
	}
}
