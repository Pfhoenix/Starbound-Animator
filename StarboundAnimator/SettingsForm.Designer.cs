namespace StarboundAnimator
{
	partial class SettingsForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnAddPath = new System.Windows.Forms.Button();
			this.btnDelPath = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lvASP = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Asset Scan Paths";
			// 
			// btnAddPath
			// 
			this.btnAddPath.Location = new System.Drawing.Point(301, 25);
			this.btnAddPath.Name = "btnAddPath";
			this.btnAddPath.Size = new System.Drawing.Size(42, 23);
			this.btnAddPath.TabIndex = 2;
			this.btnAddPath.Text = "Add";
			this.btnAddPath.UseVisualStyleBackColor = true;
			this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
			// 
			// btnDelPath
			// 
			this.btnDelPath.Enabled = false;
			this.btnDelPath.Location = new System.Drawing.Point(301, 54);
			this.btnDelPath.Name = "btnDelPath";
			this.btnDelPath.Size = new System.Drawing.Size(42, 23);
			this.btnDelPath.TabIndex = 3;
			this.btnDelPath.Text = "Del";
			this.btnDelPath.UseVisualStyleBackColor = true;
			this.btnDelPath.Click += new System.EventHandler(this.btnDelPath_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(73, 191);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(201, 191);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lvASP
			// 
			this.lvASP.CheckBoxes = true;
			this.lvASP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvASP.FullRowSelect = true;
			this.lvASP.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvASP.LabelEdit = true;
			this.lvASP.LabelWrap = false;
			this.lvASP.Location = new System.Drawing.Point(12, 25);
			this.lvASP.MultiSelect = false;
			this.lvASP.Name = "lvASP";
			this.lvASP.ShowGroups = false;
			this.lvASP.Size = new System.Drawing.Size(283, 160);
			this.lvASP.TabIndex = 8;
			this.lvASP.UseCompatibleStateImageBehavior = false;
			this.lvASP.View = System.Windows.Forms.View.Details;
			this.lvASP.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvASP_AfterLabelEdit);
			this.lvASP.SelectedIndexChanged += new System.EventHandler(this.lvASP_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 93;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Path";
			this.columnHeader2.Width = 186;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(350, 221);
			this.ControlBox = false;
			this.Controls.Add(this.lvASP);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnDelPath);
			this.Controls.Add(this.btnAddPath);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.Shown += new System.EventHandler(this.SettingsForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAddPath;
		private System.Windows.Forms.Button btnDelPath;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView lvASP;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}