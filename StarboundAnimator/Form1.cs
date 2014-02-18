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
				AddAssetPath(ca.Title, ca.Assets);
			}
        }

		public void RemoveAssetGroupByTitle(string title)
		{
			for (int i = 0; i < tvAssets.Nodes.Count; i++)
				if (tvAssets.Nodes[i].Text == title)
				{
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

		public void AddAssetPath(string title, string path)
		{
			if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
			{
				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDERBAD, ASSET_IMAGELIST_FOLDERBAD);
				tvAssets.Nodes.Add(tn);
			}
			else
			{
				ScanPathForm spf = new ScanPathForm();
				spf.StartScan(path);

				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDER, ASSET_IMAGELIST_FOLDER);
				tvAssets.Nodes.Add(tn);
				if (spf.Found.Count > 0) AddAssetPath(title, spf.Found);
			}
		}

		public void AddAssetPath(string title, List<string> foundlist)
		{
			if ((foundlist == null) || (foundlist.Count == 0))
			{
				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDERBAD, ASSET_IMAGELIST_FOLDERBAD);
				tvAssets.Nodes.Add(tn);
			}
			else
			{
				LockAssetTreeView(true);

				foundlist.Sort();
				List<TreeNode> curnodepath = new List<TreeNode>();
				TreeNode tn = new TreeNode(title, ASSET_IMAGELIST_FOLDER, ASSET_IMAGELIST_FOLDER);
				tvAssets.Nodes.Add(tn);
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
					curnodepath[curnodepath.Count - 1].Nodes.Add(new TreeNode(split[split.Length - 1], tni, tni));
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
			// wipe the root and refresh it from disk
			if (tvAssets.SelectedNode.Parent == null)
			{

			}
		}
    }
}
