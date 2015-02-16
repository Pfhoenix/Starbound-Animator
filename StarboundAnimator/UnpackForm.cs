using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class UnpackForm : Form
	{
		Process UnpackerProcess;

		bool _ug = false;
		bool UnpackerGood
		{
			get { return _ug; }
			set
			{
				_ug = value;
				btnUnpack.Enabled = (_ug && _afg && _adg);
			}
		}

		bool _afg = false;
		bool AssetFileGood
		{
			get { return _afg; }
			set
			{
				_afg = value;
				btnUnpack.Enabled = (_ug && _afg && _adg);
			}
		}

		bool _adg = false;
		bool AssetDirectoryGood
		{
			get { return _adg; }
			set
			{
				_adg = value;
				btnUnpack.Enabled = (_ug && _afg && _adg);
			}
		}

		public delegate void ProcessOutputDelegate(Process sp, string text);
		public ProcessOutputDelegate ProcessOutputDel;

		public delegate void ProcessExitDelegate();
		public ProcessExitDelegate ProcessExitDel;

		public UnpackForm()
		{
			InitializeComponent();
			ProcessOutputDel += ProcessOutput;
			ProcessExitDel += ProcessExited;
			tbUnpackPath.Text = Globals.AppSettings.PathToUnpacker;
		}

		void ValidateUnpacker()
		{
			if (File.Exists(tbUnpackPath.Text))
			{
				if (string.Compare(Path.GetExtension(tbUnpackPath.Text), ".exe", true) == 0)
				{
					UnpackerGood = true;
					if (string.IsNullOrEmpty(tbAssetFile.Text))
					{
						DirectoryInfo di = Directory.GetParent(Path.GetDirectoryName(tbUnpackPath.Text));
						if ((di != null) && di.Exists)
						{
							string ad = Path.Combine(di.FullName, "assets");
							if (Directory.Exists(ad))
							{
								string af = Path.Combine(ad, "packed.pak");
								if (File.Exists(af)) tbAssetFile.Text = af;
								else tbAssetFile.Text = ad;
							}
						}
					}
				}
				else UnpackerGood = false;
			}
			else UnpackerGood = false;
		}

		void ValidateAssetFile()
		{
			if (File.Exists(tbAssetFile.Text))
			{
				AssetFileGood = true;
				if (string.Compare(Path.GetFileName(tbAssetFile.Text), "packed.pak") == 0)
				{
					if (string.IsNullOrEmpty(tbAssetDirectory.Text))
					{
						tbAssetDirectory.Text = Path.Combine(Path.GetDirectoryName(tbAssetFile.Text), "unpacked");
					}
				}
			}
			else AssetFileGood = false;
		}

		void ValidateAssetDirectory()
		{
			if (Directory.Exists(tbAssetDirectory.Text))
			{
				AssetDirectoryGood = true;
			}
			else
			{
				DirectoryInfo di = Directory.CreateDirectory(tbAssetDirectory.Text);
				if ((di != null) && di.Exists)
				{
					AssetDirectoryGood = true;
				}
				else AssetDirectoryGood = false;
			}
		}

		private void btnBrowseUnpacker_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Unpacker|*.exe";
			openFileDialog1.DefaultExt = "exe";
			if (!string.IsNullOrEmpty(tbUnpackPath.Text))
				openFileDialog1.InitialDirectory = tbUnpackPath.Text;
			if (DialogResult.OK == openFileDialog1.ShowDialog())
			{
				tbUnpackPath.Text = openFileDialog1.FileName;
			}
		}

		private void btnBrowseAssetFile_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Asset files|*.pak|All files|*.*";
			openFileDialog1.DefaultExt = "pak";
			if (!string.IsNullOrEmpty(tbAssetFile.Text))
				openFileDialog1.InitialDirectory = tbAssetFile.Text;
			if (DialogResult.OK == openFileDialog1.ShowDialog())
			{
				tbAssetFile.Text = openFileDialog1.FileName;
			}
		}

		private void btnBrowseUnpackDir_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(tbAssetDirectory.Text))
				folderBrowserDialog1.SelectedPath = tbAssetDirectory.Text;
			if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
			{
				tbAssetDirectory.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void tbUnpackPath_TextChanged(object sender, EventArgs e)
		{
			ValidateUnpacker();
		}

		private void tbAssetFile_TextChanged(object sender, EventArgs e)
		{
			ValidateAssetFile();
		}

		private void tbAssetDirectory_TextChanged(object sender, EventArgs e)
		{
			ValidateAssetDirectory();
		}

		private void btnUnpack_Click(object sender, EventArgs e)
		{
			tbOutput.Text = "";

			if (cbWipeAssetDir.Checked)
			{
				// attempt to wipe the asset dir of all files
				tbOutput.AppendText("Wiping unpacked assets directory..." + Environment.NewLine);
				try
				{
					if (Directory.Exists(tbAssetDirectory.Text))
					{
						string[] files = Directory.GetFiles(tbAssetDirectory.Text, "*", SearchOption.AllDirectories);
						foreach (string s in files)
						{
							File.Delete(s);
						}
						Directory.Delete(tbAssetDirectory.Text, true);
					}
					Directory.CreateDirectory(tbAssetDirectory.Text);
				}
				catch (Exception ex)
				{
					tbOutput.AppendText("Error: " + ex.Message);
				}
			}

			try
			{
				// call the unpacker and if successful, save Globals.AppSettings.PathToUnpacker = tbUnpackPath.Text
				ProcessStartInfo psi = new ProcessStartInfo(tbUnpackPath.Text);// + " \"" + tbAssetFile.Text + "\" \"" + tbAssetDirectory.Text + "\"");
				psi.Arguments = "\"" + tbAssetFile.Text + "\" \"" + tbAssetDirectory.Text + "\"";
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;
				psi.RedirectStandardInput = true;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;
				UnpackerProcess = new Process();
				UnpackerProcess.StartInfo = psi;
				UnpackerProcess.EnableRaisingEvents = true;
				UnpackerProcess.Exited += ProcessExitHandler;
				UnpackerProcess.OutputDataReceived += ProcessOutputHandler;
				UnpackerProcess.ErrorDataReceived += ProcessOutputHandler;
				UnpackerProcess.Start();
				UnpackerProcess.BeginOutputReadLine();
				UnpackerProcess.BeginErrorReadLine();
				tbOutput.AppendText("Please wait while the unpacker runs (this could take several minutes)..." + Environment.NewLine);
				btnUnpack.Enabled = false;
				btnCancel.Enabled = false;
				//Name = "";
			}
			catch (Exception ex)
			{
				tbOutput.AppendText("Error: " + ex.Message);
			}
		}

		public void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
		{
			BeginInvoke(ProcessOutputDel, sendingProcess as Process, outLine.Data);
		}

		public void ProcessOutput(Process sp, string text)
		{
			if (string.IsNullOrEmpty(text)) return;

			text = text.Trim();
			tbOutput.AppendText(text + Environment.NewLine);
		}

		public void ProcessExitHandler(object sendingProcess, EventArgs e)
		{
			BeginInvoke(ProcessExitDel);
		}

		public void ProcessExited()
		{
			tbOutput.AppendText("Unpacking has completed.");
			Globals.AppSettings.PathToUnpacker = tbUnpackPath.Text;
			btnUnpack.Enabled = true;
			btnCancel.Enabled = true;
		}
	}
}
