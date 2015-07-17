using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class ScanPathForm : Form
	{
		string ScanPath;
		string CurPath = "\\";
		int fCount;
		Thread worker;

		public List<string> Found = new List<string>(100);

		public ScanPathForm()
		{
			InitializeComponent();
		}

		public void Reset()
		{
			CurPath = "\\";
			fCount = 0;
			Found.Clear();
			worker = new Thread(DoScanning);
		}

		public void StartScan(string path)
		{
			ScanPath = path;
			Reset();
			Globals.AppForm.LockAssetTreeView(true);

			tbSource.Text = ScanPath;

			worker.Start();
			ShowDialog();
		}

		public delegate void UpdateControlTextDelegate(Control c, string text, bool bAppend);
		private void UpdateControlText(Control c, string text, bool bAppend)
		{
			if (tbCurrent.InvokeRequired)
			{
				Invoke(new UpdateControlTextDelegate(UpdateControlText), new object[] { c, text, bAppend });
			}
			else
			{
				if (bAppend) (c as TextBox).AppendText(Environment.NewLine + text);
				else c.Text = text;
			}
		}

		public delegate void ScanningDoneDelegate();
		private void ScanningDone()
		{
			if (btnOK.InvokeRequired)
			{
				Invoke(new ScanningDoneDelegate(ScanningDone), null);
			}
			else
			{
				Globals.AppForm.LockAssetTreeView(false);
				btnOK.Enabled = true;
			}
		}

		private void DoScanning()
		{
			List<string> dirs = new List<string>();
			string[] files;

			dirs.Add(ScanPath + CurPath);

			while (dirs.Count > 0)
			{
				UpdateControlText(tbCurrent, dirs[0].Substring(ScanPath.Length), false);
				try
				{
					files = Directory.GetFiles(dirs[0]);
					if ((files != null) && (files.Length > 0))
					{
						string fileext;
						for (int i = 0; i < files.Length; i++)
						{
							fileext = Path.GetExtension(files[i]);
							if ((string.Compare(fileext, Animation.FileExtension, true) == 0) || (string.Compare(fileext, Frames.FileExtension, true) == 0) || (string.Compare(fileext, LuaScriptAsset.FileExtension, true) == 0))
							{
								fCount++;
								UpdateControlText(lblCount, fCount.ToString(), false);
								Found.Add(files[i].Substring(ScanPath.Length));
								UpdateControlText(tbFound, Found[Found.Count - 1], true);
							}
						}
					}

					string[] ndirs = Directory.GetDirectories(dirs[0]);
					dirs.AddRange(ndirs);
				}
				catch (Exception e)
				{
				}

				dirs.RemoveAt(0);
			}

			ScanningDone();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
