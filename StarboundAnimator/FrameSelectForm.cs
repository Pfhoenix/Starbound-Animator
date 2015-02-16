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
	public partial class FrameSelectForm : Form
	{
		public string Value
		{
			get
			{
				if ((lvFrames.SelectedItems == null) || (lvFrames.SelectedItems.Count == 0)) return null;
				return lvFrames.SelectedItems[0].Text;
			}
		}

		public FrameSelectForm()
		{
			InitializeComponent();
		}

		public void InitFor(Frames frame, List<string> exclude = null)
		{
			lvFrames.Items.Clear();

			ListViewItem lvi;
			foreach (_frameItem fi in frame.ListFrameItems)
			{
				foreach (_frameName fn in fi.names)
				{
					if ((exclude != null) && exclude.Exists(e => e == fn.name)) continue;

					lvi = lvFrames.Items.Add(fn.name);
					if (fn.source == FrameSource.Grid) lvi.SubItems.Add("Grid Default");
					else if (fn.source == FrameSource.List) lvi.SubItems.Add("List");
					else if (fn.source == FrameSource.Name) lvi.SubItems.Add("Grid Name");
					else if (fn.source == FrameSource.Alias) lvi.SubItems.Add("Alias");
				}
			}
		}
	}
}
