namespace StarboundAnimator
{
	partial class ConvertGridToListForm
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
			this.cmbDefaults = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbNames = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Default frames will be";
			// 
			// cmbDefaults
			// 
			this.cmbDefaults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDefaults.FormattingEnabled = true;
			this.cmbDefaults.Items.AddRange(new object[] {
            "Removed",
            "Converted"});
			this.cmbDefaults.Location = new System.Drawing.Point(109, 7);
			this.cmbDefaults.Name = "cmbDefaults";
			this.cmbDefaults.Size = new System.Drawing.Size(131, 21);
			this.cmbDefaults.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Named frames will be";
			// 
			// cmbNames
			// 
			this.cmbNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNames.FormattingEnabled = true;
			this.cmbNames.Items.AddRange(new object[] {
            "Converted to List frames",
            "Removed"});
			this.cmbNames.Location = new System.Drawing.Point(109, 34);
			this.cmbNames.Name = "cmbNames";
			this.cmbNames.Size = new System.Drawing.Size(131, 21);
			this.cmbNames.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(30, 67);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "Convert";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(140, 67);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// ConvertGridToListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(246, 96);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbNames);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbDefaults);
			this.Controls.Add(this.label1);
			this.Name = "ConvertGridToListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Convert Grid to List";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbDefaults;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbNames;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button button1;
	}
}