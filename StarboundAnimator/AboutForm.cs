using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			lblVersion.Text = Globals.MajVer.ToString() + "." + Globals.MinVer.ToString();
		}

		private void linkStarbound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkStarbound.Tag.ToString());
		}

		private void linkAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkAuthor.Tag.ToString());
		}
	}
}
