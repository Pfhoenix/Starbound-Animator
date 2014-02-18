namespace StarboundAnimator
{
	partial class ScanPathForm
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
			this.tbSource = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCurrent = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tbFound = new System.Windows.Forms.TextBox();
			this.lblCount = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Source :";
			// 
			// tbSource
			// 
			this.tbSource.Enabled = false;
			this.tbSource.Location = new System.Drawing.Point(57, 6);
			this.tbSource.Name = "tbSource";
			this.tbSource.Size = new System.Drawing.Size(434, 20);
			this.tbSource.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Current :";
			// 
			// tbCurrent
			// 
			this.tbCurrent.Enabled = false;
			this.tbCurrent.Location = new System.Drawing.Point(57, 36);
			this.tbCurrent.Name = "tbCurrent";
			this.tbCurrent.Size = new System.Drawing.Size(434, 20);
			this.tbCurrent.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(214, 241);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Found :";
			// 
			// tbFound
			// 
			this.tbFound.Enabled = false;
			this.tbFound.Location = new System.Drawing.Point(57, 90);
			this.tbFound.MaxLength = 0;
			this.tbFound.Multiline = true;
			this.tbFound.Name = "tbFound";
			this.tbFound.Size = new System.Drawing.Size(434, 145);
			this.tbFound.TabIndex = 6;
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Location = new System.Drawing.Point(54, 69);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(13, 13);
			this.lblCount.TabIndex = 7;
			this.lblCount.Text = "0";
			// 
			// ScanPathForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(503, 271);
			this.ControlBox = false;
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.tbFound);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbCurrent);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbSource);
			this.Controls.Add(this.label1);
			this.Name = "ScanPathForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Scanning for assets...";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbSource;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCurrent;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbFound;
		private System.Windows.Forms.Label lblCount;
	}
}