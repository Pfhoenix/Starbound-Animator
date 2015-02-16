namespace StarboundAnimator
{
	partial class UnpackForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbUnpackPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBrowseUnpacker = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnUnpack = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbAssetFile = new System.Windows.Forms.TextBox();
			this.btnBrowseAssetFile = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tbAssetDirectory = new System.Windows.Forms.TextBox();
			this.btnBrowseUnpackDir = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.cbWipeAssetDir = new System.Windows.Forms.CheckBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbUnpackPath
			// 
			this.tbUnpackPath.Location = new System.Drawing.Point(12, 25);
			this.tbUnpackPath.Name = "tbUnpackPath";
			this.tbUnpackPath.Size = new System.Drawing.Size(348, 20);
			this.tbUnpackPath.TabIndex = 0;
			this.tbUnpackPath.TextChanged += new System.EventHandler(this.tbUnpackPath_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Path to unpack utility";
			// 
			// btnBrowseUnpacker
			// 
			this.btnBrowseUnpacker.Location = new System.Drawing.Point(366, 23);
			this.btnBrowseUnpacker.Name = "btnBrowseUnpacker";
			this.btnBrowseUnpacker.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseUnpacker.TabIndex = 2;
			this.btnBrowseUnpacker.Text = "Browse";
			this.btnBrowseUnpacker.UseVisualStyleBackColor = true;
			this.btnBrowseUnpacker.Click += new System.EventHandler(this.btnBrowseUnpacker_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "exe";
			this.openFileDialog1.FileName = "asset_unpacker.exe";
			this.openFileDialog1.Filter = "Unpacker|*.exe";
			this.openFileDialog1.Title = "Select unpacker utility";
			// 
			// btnUnpack
			// 
			this.btnUnpack.Enabled = false;
			this.btnUnpack.Location = new System.Drawing.Point(112, 461);
			this.btnUnpack.Name = "btnUnpack";
			this.btnUnpack.Size = new System.Drawing.Size(75, 23);
			this.btnUnpack.TabIndex = 3;
			this.btnUnpack.Text = "Unpack";
			this.btnUnpack.UseVisualStyleBackColor = true;
			this.btnUnpack.Click += new System.EventHandler(this.btnUnpack_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 461);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Close";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Path to asset file to unpack";
			// 
			// tbAssetFile
			// 
			this.tbAssetFile.Location = new System.Drawing.Point(12, 73);
			this.tbAssetFile.Name = "tbAssetFile";
			this.tbAssetFile.Size = new System.Drawing.Size(348, 20);
			this.tbAssetFile.TabIndex = 6;
			this.tbAssetFile.TextChanged += new System.EventHandler(this.tbAssetFile_TextChanged);
			// 
			// btnBrowseAssetFile
			// 
			this.btnBrowseAssetFile.Location = new System.Drawing.Point(366, 71);
			this.btnBrowseAssetFile.Name = "btnBrowseAssetFile";
			this.btnBrowseAssetFile.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseAssetFile.TabIndex = 7;
			this.btnBrowseAssetFile.Text = "Browse";
			this.btnBrowseAssetFile.UseVisualStyleBackColor = true;
			this.btnBrowseAssetFile.Click += new System.EventHandler(this.btnBrowseAssetFile_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Path to unpack assets to";
			// 
			// tbAssetDirectory
			// 
			this.tbAssetDirectory.Location = new System.Drawing.Point(12, 126);
			this.tbAssetDirectory.Name = "tbAssetDirectory";
			this.tbAssetDirectory.Size = new System.Drawing.Size(348, 20);
			this.tbAssetDirectory.TabIndex = 9;
			this.tbAssetDirectory.TextChanged += new System.EventHandler(this.tbAssetDirectory_TextChanged);
			// 
			// btnBrowseUnpackDir
			// 
			this.btnBrowseUnpackDir.Location = new System.Drawing.Point(366, 124);
			this.btnBrowseUnpackDir.Name = "btnBrowseUnpackDir";
			this.btnBrowseUnpackDir.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseUnpackDir.TabIndex = 10;
			this.btnBrowseUnpackDir.Text = "Browse";
			this.btnBrowseUnpackDir.UseVisualStyleBackColor = true;
			this.btnBrowseUnpackDir.Click += new System.EventHandler(this.btnBrowseUnpackDir_Click);
			// 
			// cbWipeAssetDir
			// 
			this.cbWipeAssetDir.AutoSize = true;
			this.cbWipeAssetDir.Location = new System.Drawing.Point(15, 153);
			this.cbWipeAssetDir.Name = "cbWipeAssetDir";
			this.cbWipeAssetDir.Size = new System.Drawing.Size(208, 17);
			this.cbWipeAssetDir.TabIndex = 11;
			this.cbWipeAssetDir.Text = "Wipe asset directory before unpacking";
			this.cbWipeAssetDir.UseVisualStyleBackColor = true;
			// 
			// tbOutput
			// 
			this.tbOutput.Location = new System.Drawing.Point(12, 191);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbOutput.Size = new System.Drawing.Size(429, 264);
			this.tbOutput.TabIndex = 12;
			this.tbOutput.WordWrap = false;
			// 
			// UnpackForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(453, 490);
			this.ControlBox = false;
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.cbWipeAssetDir);
			this.Controls.Add(this.btnBrowseUnpackDir);
			this.Controls.Add(this.tbAssetDirectory);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnBrowseAssetFile);
			this.Controls.Add(this.tbAssetFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnUnpack);
			this.Controls.Add(this.btnBrowseUnpacker);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbUnpackPath);
			this.Name = "UnpackForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Unpack assets";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbUnpackPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBrowseUnpacker;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnUnpack;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbAssetFile;
		private System.Windows.Forms.Button btnBrowseAssetFile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbAssetDirectory;
		private System.Windows.Forms.Button btnBrowseUnpackDir;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.CheckBox cbWipeAssetDir;
		private System.Windows.Forms.TextBox tbOutput;
	}
}