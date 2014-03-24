using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class AddFrameForm : Form
	{
		public byte FrameType;
		public string FrameName
		{
			get { return tbFrameName.Text; }
		}
		public string NameOf
		{
			get
			{
				if (FrameType == Globals.FrameSource_Name) return cmbGridName.SelectedItem.ToString();
				else return "";
			}
		}
		public string AliasOf
		{
			get
			{
				if (FrameType == Globals.FrameSource_Alias) return cmbAlias.SelectedItem.ToString();
				else return "";
			}
		}
		public Rectangle FrameSize
		{
			get
			{
				if (FrameType == Globals.FrameSource_List)
				{
					return new Rectangle(int.Parse(tbListX.Text), int.Parse(tbListY.Text), int.Parse(tbListW.Text), int.Parse(tbListH.Text));
				}
				else return new Rectangle();
			}
		}

		public AddFrameForm()
		{
			InitializeComponent();

			FrameType = Globals.FrameSource_None;

			if (Globals.WorkingFrames == null)
			{
				MessageBox.Show("Cannot add a frame to a Frames not being editted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}

		void InitLists(bool bGrid, bool bAlias)
		{
			if (!bGrid || (Globals.WorkingFrames.frameGrid == null))
			{
				cmbGridName.Items.Clear();
				rbGridName.Enabled = false;
				bGrid = false;
			}

			cmbAlias.Items.Clear();
			rbAlias.Enabled = bAlias;

			if (!bGrid && !bAlias) return;

			foreach (_frameItem fi in Globals.WorkingFrames.ListFrameItems)
			{
				bool bNamed = false;
				string grid = "";
				foreach (_frameName fn in fi.names)
				{
					if (bGrid)
					{
						if (fn.source == Globals.FrameSource_Name)
						{
							bNamed = true;
							break;
						}
						else if (fn.source == Globals.FrameSource_Grid) grid = fn.name;
					}

					if (bAlias)
					{
						cmbAlias.Items.Add(fn.name);
					}
				}

				if (bGrid && !bNamed && (grid != "")) cmbGridName.Items.Add(grid);
			}

			if (bAlias && (cmbAlias.Items.Count == 0)) rbAlias.Enabled = false;
		}

		public void InitAll()
		{
			InitLists(true, true);
		}

		void DisableAll()
		{
			rbGridName.Enabled = false;
			cmbGridName.Enabled = false;
			rbListFrame.Enabled = false;
			tbListX.Enabled = false;
			tbListY.Enabled = false;
			tbListW.Enabled = false;
			tbListH.Enabled = false;
			rbAlias.Enabled = false;
			cmbAlias.Enabled = false;
		}

		public void InitGridName(string dn)
		{
			rbGridName.Enabled = true;
			cmbGridName.Items.Clear();
			cmbGridName.Items.Add(dn);
			cmbGridName.SelectedIndex = 0;
		}

		public void InitListFrame(int x, int y, int w, int h)
		{
			rbListFrame.Enabled = true;
			tbListX.Enabled = true;
			tbListX.Text = x.ToString();
			tbListY.Enabled = true;
			tbListY.Text = y.ToString();
			tbListW.Enabled = true;
			tbListW.Text = w.ToString();
			tbListH.Enabled = true;
			tbListH.Text = h.ToString();
		}

		public void InitForFrame(_frameItem fi)
		{
			DisableAll();

			cmbAlias.Items.Clear();
			if (fi.names.Count > 0) rbAlias.Enabled = true;

			string grid = "";
			foreach (_frameName fn in fi.names)
			{
				if (fn.source == Globals.FrameSource_Grid) grid = fn.name;
				else if (fn.source == Globals.FrameSource_Name) grid = "";

				cmbAlias.Items.Add(fn.name);
			}

			if (grid != "") InitGridName(grid);

			InitListFrame(fi.x, fi.y, fi.width, fi.height);
		}

		void UpdateControls()
		{
			bool bCheck = true;
			if (rbGridName.Checked)
			{
				FrameType = Globals.FrameSource_Name;
				cmbGridName.Enabled = true;
				tbListX.Enabled = false;
				tbListY.Enabled = false;
				tbListW.Enabled = false;
				tbListH.Enabled = false;
				cmbAlias.Enabled = false;
				if (cmbGridName.SelectedIndex == -1) bCheck = false;
			}
			else if (rbListFrame.Checked)
			{
				FrameType = Globals.FrameSource_List;
				tbListX.Enabled = true;
				tbListY.Enabled = true;
				tbListW.Enabled = true;
				tbListH.Enabled = true;
				cmbGridName.Enabled = false;
				cmbAlias.Enabled = false;

				int i = 0;
				if (!int.TryParse(tbListX.Text, out i)) bCheck = false;
				else if (i < 0) bCheck = false;
				if (!int.TryParse(tbListY.Text, out i)) bCheck = false;
				else if (i < 0) bCheck = false;
				if (!int.TryParse(tbListW.Text, out i)) bCheck = false;
				else if (i <= 0) bCheck = false;
				if (!int.TryParse(tbListH.Text, out i)) bCheck = false;
				else if (i <= 0) bCheck = false;
			}
			else if (rbAlias.Checked)
			{
				FrameType = Globals.FrameSource_Alias;
				cmbAlias.Enabled = true;
				cmbGridName.Enabled = false;
				tbListX.Enabled = false;
				tbListY.Enabled = false;
				tbListW.Enabled = false;
				tbListH.Enabled = false;
				if (cmbAlias.SelectedIndex == -1) bCheck = false;
			}
			else
			{
				FrameType = Globals.FrameSource_None;
				bCheck = false;
			}

			if (bCheck && (tbFrameName.Text.Length > 0)) btnOK.Enabled = true;
			else btnOK.Enabled = false;
		}

		private void rbGridName_CheckedChanged(object sender, EventArgs e)
		{
			if (rbGridName.Checked) UpdateControls();
		}

		private void rbListFrame_CheckedChanged(object sender, EventArgs e)
		{
			if (rbListFrame.Checked) UpdateControls();
		}

		private void rbAlias_CheckedChanged(object sender, EventArgs e)
		{
			if (rbAlias.Checked) UpdateControls();
		}

		private void tbFrameName_TextChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if ((tbFrameName.Text.Length > 6) && (string.Compare(tbFrameName.Text.Substring(0, 7), "default", true) == 0))
			{
				MessageBox.Show("You cannot begin a frame's name with 'default'. Choose a different name for the frame.", "Name conflict", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			// need to ensure that the desired frame name isn't already in use
			if (Globals.WorkingFrames.ListFrameItems.Exists(fi => fi.names.Exists(fn => fn.name == tbFrameName.Text)))
			{
				MessageBox.Show("You must choose a name that is unique.", "Name conflict", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void cmbGridName_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void cmbAlias_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}
	}
}
