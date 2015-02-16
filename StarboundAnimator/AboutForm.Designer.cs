namespace StarboundAnimator
{
	partial class AboutForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.linkStarbound = new System.Windows.Forms.LinkLabel();
			this.linkAuthor = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Version :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Author :";
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(64, 5);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(22, 13);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "0.2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Thanks go to :";
			// 
			// linkStarbound
			// 
			this.linkStarbound.AutoSize = true;
			this.linkStarbound.Cursor = System.Windows.Forms.Cursors.Default;
			this.linkStarbound.Location = new System.Drawing.Point(31, 64);
			this.linkStarbound.Name = "linkStarbound";
			this.linkStarbound.Size = new System.Drawing.Size(110, 13);
			this.linkStarbound.TabIndex = 5;
			this.linkStarbound.TabStop = true;
			this.linkStarbound.Tag = "\"http://www.playstarbound.com\"";
			this.linkStarbound.Text = "Creators of Starbound";
			this.linkStarbound.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkStarbound_LinkClicked);
			// 
			// linkAuthor
			// 
			this.linkAuthor.AutoSize = true;
			this.linkAuthor.LinkArea = new System.Windows.Forms.LinkArea(8, 8);
			this.linkAuthor.Location = new System.Drawing.Point(67, 18);
			this.linkAuthor.Name = "linkAuthor";
			this.linkAuthor.Size = new System.Drawing.Size(120, 17);
			this.linkAuthor.TabIndex = 6;
			this.linkAuthor.TabStop = true;
			this.linkAuthor.Tag = "\"http://community.playstarbound.com/index.php?members/pfhoenix.739/\"";
			this.linkAuthor.Text = "Martin \"Pfhoenix\" Actor";
			this.linkAuthor.UseCompatibleTextRendering = true;
			this.linkAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAuthor_LinkClicked);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 86);
			this.Controls.Add(this.linkAuthor);
			this.Controls.Add(this.linkStarbound);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Starbound Animator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkStarbound;
		private System.Windows.Forms.LinkLabel linkAuthor;
	}
}