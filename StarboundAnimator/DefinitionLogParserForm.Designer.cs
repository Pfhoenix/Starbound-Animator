namespace StarboundAnimator
{
	partial class DefinitionLogParserForm
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
			this.tbLogLine = new System.Windows.Forms.TextBox();
			this.btnParse = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Paste log line here";
			// 
			// tbLogLine
			// 
			this.tbLogLine.Location = new System.Drawing.Point(12, 25);
			this.tbLogLine.Name = "tbLogLine";
			this.tbLogLine.Size = new System.Drawing.Size(260, 20);
			this.tbLogLine.TabIndex = 1;
			this.tbLogLine.TextChanged += new System.EventHandler(this.tbLogLine_TextChanged);
			// 
			// btnParse
			// 
			this.btnParse.Enabled = false;
			this.btnParse.Location = new System.Drawing.Point(12, 51);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(121, 23);
			this.btnParse.TabIndex = 2;
			this.btnParse.Text = "Parse";
			this.btnParse.UseVisualStyleBackColor = true;
			this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(149, 51);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(123, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// DefinitionLogParserForm
			// 
			this.AcceptButton = this.btnParse;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 83);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnParse);
			this.Controls.Add(this.tbLogLine);
			this.Controls.Add(this.label1);
			this.Name = "DefinitionLogParserForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Definition Log Parser";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbLogLine;
		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.Button btnCancel;
	}
}