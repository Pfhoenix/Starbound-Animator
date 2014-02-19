using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StarboundAnimator
{
    public partial class Form1 : Form
    {
		public const int ASSET_IMAGELIST_FOLDER = 0;
		public const int ASSET_IMAGELIST_FOLDERBAD = 1;
		public const int ASSET_IMAGELIST_ANIMATION = 2;
		public const int ASSET_IMAGELIST_ANIMATIONBAD = 3;
		public const int ASSET_IMAGELIST_FRAMES = 4;
		public const int ASSET_IMAGELIST_FRAMESBAD = 5;

        public Form1()
        {
            InitializeComponent();

			Globals.AppForm = this;
			Globals.AppPath = Application.StartupPath;
			Globals.AppSettings = Settings.LoadSettings();
			if (Globals.AppSettings.WindowWidth > 0) Width = Globals.AppSettings.WindowWidth;
			if (Globals.AppSettings.WindowHeight > 0) Height = Globals.AppSettings.WindowHeight;
			if (Globals.AppSettings.ExplorerWidth > 0) splitContainer1.SplitterDistance = Globals.AppSettings.ExplorerWidth;
			if (Globals.AppSettings.PropertiesWidth > 0) splitContainer2.SplitterDistance = Globals.AppSettings.PropertiesWidth;
			Globals.AppSettings.ValidateSettings();
			foreach (CachedAsset ca in Globals.AppSettings.CachedAssets)
			{
				AddAssetPath(ca.Title, ca.Assets, null);
			}
        }



		public void RemoveAssetGroupByTitle(string title)
		{
			for (int i = 0; i < tvAssets.Nodes.Count; i++)
				if (tvAssets.Nodes[i].Text == title)
				{
					// need to go through all nodes to ensure animations and frames are unloaded properly
					tvAssets.Nodes.RemoveAt(i--);
					break;
				}
		}

		public void ChangeAssetTitle(string oldtitle, string newtitle)
		{
			for (int i = 0; i < tvAssets.Nodes.Count; i++)
			{
				if (tvAssets.Nodes[i].Text == oldtitle)
				{
					tvAssets.Nodes[i].Text = newtitle;
					break;
				}
			}
		}

		public List<string> AddAssetPath(string title, string path, TreeNode root)
		{
			if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
			{
				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDERBAD, ASSET_IMAGELIST_FOLDERBAD);
				tvAssets.Nodes.Add(tn);
				return new List<string>();
			}
			else
			{
				ScanPathForm spf = new ScanPathForm();
				spf.StartScan(path);

				if (spf.Found.Count > 0)
				{
					AddAssetPath(title, spf.Found, root);
					return spf.Found;
				}
				else
				{
					TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDERBAD, ASSET_IMAGELIST_FOLDERBAD);
					tvAssets.Nodes.Add(tn);
					return new List<string>();
				}
			}
		}

		public void AddAssetPath(string title, List<string> foundlist, TreeNode root)
		{
			if ((foundlist == null) || (foundlist.Count == 0))
			{
				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDERBAD, ASSET_IMAGELIST_FOLDERBAD);
				if (root != null) root.Nodes.Add(tn);
				else tvAssets.Nodes.Add(tn);
			}
			else
			{
				LockAssetTreeView(true);

				foundlist.Sort();
				List<TreeNode> curnodepath = new List<TreeNode>();
				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDER, ASSET_IMAGELIST_FOLDER);
				if (root != null) root.Nodes.Add(tn);
				else tvAssets.Nodes.Add(tn);
				curnodepath.Add(tn);
				string[] split;
				char[] splitchar = { '\\' };
				for (int i = 0; i < foundlist.Count; i++)
				{
					split = foundlist[i].Split(splitchar);
					// because each foundlist entry starts with \, split[0] will always be "", so we skip it
					for (int j = 1; j < split.Length - 1; j++)
					{
						// node doesn't exist
						if (curnodepath.Count == j)
						{
							tn = new TreeNode(split[j], ASSET_IMAGELIST_FOLDER, ASSET_IMAGELIST_FOLDER);
							curnodepath[curnodepath.Count - 1].Nodes.Add(tn);
							curnodepath.Add(tn);
						}
						// node doesn't match
						else if (curnodepath[j].Text != split[j])
						{
							curnodepath.RemoveRange(j, curnodepath.Count - j);
							tn = new TreeNode(split[j], ASSET_IMAGELIST_FOLDER, ASSET_IMAGELIST_FOLDER);
							curnodepath[curnodepath.Count - 1].Nodes.Add(tn);
							curnodepath.Add(tn);
						}
					}

					// adjust this to set animation or frame image
					int tni = 0;
					if (split[split.Length - 1].EndsWith("animation")) tni = ASSET_IMAGELIST_ANIMATION;
					else if (split[split.Length - 1].EndsWith("frames")) tni = ASSET_IMAGELIST_FRAMES;
					curnodepath[curnodepath.Count - 1].Nodes.Add(new AssetTreeNode(split[split.Length - 1], tni, tni, null));
				}

				LockAssetTreeView(false);
			}
		}

		public void LockAssetTreeView(bool bLock)
		{
			if (bLock) tvAssets.BeginUpdate();
			else tvAssets.EndUpdate();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsForm sf = new SettingsForm();
			sf.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Globals.AppSettings.WindowWidth = Width;
			Globals.AppSettings.WindowHeight = Height;
			Globals.AppSettings.ExplorerWidth = splitContainer1.SplitterDistance;
			Globals.AppSettings.PropertiesWidth = splitContainer2.SplitterDistance;

			Globals.AppSettings.SaveSettings();
		}

		private void tvAssets_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
			}
			else if (e.Button == MouseButtons.Right)
			{
				TreeNode tn = tvAssets.GetNodeAt(e.X, e.Y);
				tvAssets.SelectedNode = tn;
				cmsAssets.Show(tvAssets, e.X, e.Y);
			}
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tvAssets.SelectedNode.Parent == null)
			{
				string title = tvAssets.SelectedNode.Text;
				string path = Globals.AppSettings.GetPathForTitle(tvAssets.SelectedNode.Text);

				// change this to a proper unload+clear
				TreeNode sn = tvAssets.SelectedNode;
				tvAssets.SelectedNode = null;
				tvAssets.Nodes.Remove(sn);
				CachedAsset ca = Globals.AppSettings.CachedAssets.Find(tca => title == tca.Title);
				ca.Assets = AddAssetPath(title, path, null);
			}
			else if (tvAssets.SelectedNode.Text.EndsWith(".animation"))
			{
			}
			else if (tvAssets.SelectedNode.Text.EndsWith(".frames"))
			{
			}
			else
			{
				string title = tvAssets.SelectedNode.Text;
				string path = "";
				string root = "";

				TreeNode tn = tvAssets.SelectedNode;
				while (tn != null)
				{
					if (tn.Parent == null)
					{
						path = "\\" + path;
						root = tn.Text;
					}
					else
					{
						if (path == "") path = tn.Text;
						else path = tn.Text + '\\' + path;
					}

					tn = tn.Parent;
				}

				// change this to a proper unload+clear
				TreeNode sn = tvAssets.SelectedNode;
				TreeNode pn = sn.Parent;
				tvAssets.SelectedNode = null;
				tvAssets.Nodes.Remove(sn);
				CachedAsset ca = Globals.AppSettings.CachedAssets.Find(tca => root == tca.Title);
				ca.Assets.RemoveAll(tca => tca.StartsWith(path + '\\'));
				List<string> foundlist = AddAssetPath(title, ca.Path + path, pn);
				int i = ca.Assets.IndexOf(ca.Path + path);
				ca.Assets.InsertRange(i + 1, foundlist);
			}
		}
    }
}
