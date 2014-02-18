using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class SettingsForm : Form
	{
		List<string> PathsToRemove = new List<string>();
		List<string> PathsToAdd = new List<string>();
		List<string> PathsToChange = new List<string>();

		public SettingsForm()
		{
			InitializeComponent();

			ListViewItem lvi;
			for (int i = 0; i < Globals.AppSettings.CachedAssets.Count; i++)
			{
				lvi = lvASP.Items.Add(Globals.AppSettings.CachedAssets[i].Title);
				lvi.SubItems.Add(Globals.AppSettings.CachedAssets[i].Path);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			foreach (string ptr in PathsToRemove)
			{
				string title = Globals.AppSettings.GetTitleForPath(ptr);
				Globals.AppSettings.RemoveAssetScanPath(ptr);
				Globals.AppForm.RemoveAssetGroupByTitle(title);
			}

			foreach (string ptc in PathsToChange)
			{
				CachedAsset ca = Globals.AppSettings.CachedAssets.Find(tca => tca.Path == ptc);
				for (int i = 0; i < lvASP.Items.Count; i++)
				{
					if (lvASP.Items[i].SubItems[1].Text == ptc)
					{
						Globals.AppForm.ChangeAssetTitle(ca.Title, lvASP.Items[i].Text);
						ca.Title = lvASP.Items[i].Text;
					}
				}
			}

			ScanPathForm spf = null;
			foreach (string pta in PathsToAdd)
			{
				if (spf == null) spf = new ScanPathForm();
				for (int i = 0; i < lvASP.Items.Count; i++)
				{
					if (lvASP.Items[i].SubItems[1].Text == pta)
					{
						CachedAsset ca = new CachedAsset();
						ca.Path = lvASP.Items[i].SubItems[1].Text;
						ca.Title = lvASP.Items[i].Text;
						Globals.AppSettings.CachedAssets.Add(ca);
						spf.StartScan(ca.Path);
						Globals.AppForm.AddAssetPath(ca.Title, spf.Found);
						ca.SetAssetsFromFoundList(spf.Found);
						break;
					}
				}
			}

			Globals.AppSettings.SaveSettings();

			Close();
		}

		private void btnAddPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.ShowNewFolderButton = true;
			DialogResult dr = folderBrowserDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				bool bFound = false;
				// redundancy check
				foreach (ListViewItem l in lvASP.Items)
				{
					foreach (ListViewItem.ListViewSubItem s in l.SubItems)
					{
						if (s.Text == folderBrowserDialog1.SelectedPath)
						{
							bFound = true;
							break;
						}
					}

					if (bFound) break;
				}

				if (bFound)
				{
					MessageBox.Show("Duplicate scan path found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					ListViewItem lvi;
					lvi = lvASP.Items.Add("default path title");
					lvi.SubItems.Add(folderBrowserDialog1.SelectedPath);
					PathsToAdd.Add(folderBrowserDialog1.SelectedPath);
				}
			}
		}

		private void btnDelPath_Click(object sender, EventArgs e)
		{
			int sl = lvASP.SelectedIndices[0];

			string pta = lvASP.Items[sl].SubItems[0].ToString();
			if (PathsToAdd.Exists(s => s == pta))
			{
				PathsToAdd.Remove(pta);
			}
			else
			{
				PathsToRemove.Add(lvASP.Items[sl].SubItems[0].Text);
				lvASP.Items.RemoveAt(sl);
			}
		}

		private void lvASP_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvASP.SelectedItems.Count == 0) btnDelPath.Enabled = false;
			else btnDelPath.Enabled = true;
		}

		private void lvASP_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (string.IsNullOrEmpty(e.Label))
			{
				e.CancelEdit = true;
				return;
			}

			foreach (ListViewItem lvi in lvASP.Items)
			{
				if (lvi == lvASP.Items[e.Item]) continue;

				if (lvi.Text == e.Label)
				{
					MessageBox.Show("Duplicate title found! Resetting title change.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					e.CancelEdit = true;
					return;
				}
			}

			// we don't want duplicate title change entries
			if (PathsToChange.Exists(s => s == lvASP.Items[e.Item].SubItems[0].Text)) return;

			// we don't need to manage a title change if this item is in PathsToAdd
			if (PathsToAdd.Exists(s => s == lvASP.Items[e.Item].SubItems[0].Text)) return;

			// we need to track this title change
			PathsToChange.Add(lvASP.Items[e.Item].SubItems[0].Text);
		}
	}
}
