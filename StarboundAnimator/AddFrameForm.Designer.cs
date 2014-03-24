namespace StarboundAnimator
{
	partial class AddFrameForm
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
			this.components = new System.ComponentModel.Container();
			this.btnOK = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.rbGridName = new System.Windows.Forms.RadioButton();
			this.tbFrameName = new System.Windows.Forms.TextBox();
			this.cmbGridName = new System.Windows.Forms.ComboBox();
			this.rbListFrame = new System.Windows.Forms.RadioButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.rbAlias = new System.Windows.Forms.RadioButton();
			this.cmbAlias = new System.Windows.Forms.ComboBox();
			this.tbListX = new System.Windows.Forms.TextBox();
			this.tbListY = new System.Windows.Forms.TextBox();
			this.tbListW = new System.Windows.Forms.TextBox();
			this.tbListH = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(7, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(101, 136);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// rbGridName
			// 
			this.rbGridName.AutoSize = true;
			this.rbGridName.Location = new System.Drawing.Point(6, 19);
			this.rbGridName.Name = "rbGridName";
			this.rbGridName.Size = new System.Drawing.Size(75, 17);
			this.rbGridName.TabIndex = 2;
			this.rbGridName.TabStop = true;
			this.rbGridName.Text = "Grid Name";
			this.toolTip1.SetToolTip(this.rbGridName, "Apply a name to a default grid frame");
			this.rbGridName.UseVisualStyleBackColor = true;
			this.rbGridName.CheckedChanged += new System.EventHandler(this.rbGridName_CheckedChanged);
			// 
			// tbFrameName
			// 
			this.tbFrameName.Location = new System.Drawing.Point(51, 5);
			this.tbFrameName.Name = "tbFrameName";
			this.tbFrameName.Size = new System.Drawing.Size(125, 20);
			this.tbFrameName.TabIndex = 3;
			this.toolTip1.SetToolTip(this.tbFrameName, "Desired name of the frame being created");
			this.tbFrameName.TextChanged += new System.EventHandler(this.tbFrameName_TextChanged);
			// 
			// cmbGridName
			// 
			this.cmbGridName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGridName.Enabled = false;
			this.cmbGridName.FormattingEnabled = true;
			this.cmbGridName.Location = new System.Drawing.Point(88, 18);
			this.cmbGridName.Name = "cmbGridName";
			this.cmbGridName.Size = new System.Drawing.Size(75, 21);
			this.cmbGridName.TabIndex = 4;
			this.toolTip1.SetToolTip(this.cmbGridName, "The grid default frame to be named");
			this.cmbGridName.SelectedIndexChanged += new System.EventHandler(this.cmbGridName_SelectedIndexChanged);
			// 
			// rbListFrame
			// 
			this.rbListFrame.AutoSize = true;
			this.rbListFrame.Location = new System.Drawing.Point(6, 46);
			this.rbListFrame.Name = "rbListFrame";
			this.rbListFrame.Size = new System.Drawing.Size(41, 17);
			this.rbListFrame.TabIndex = 5;
			this.rbListFrame.TabStop = true;
			this.rbListFrame.Text = "List";
			this.toolTip1.SetToolTip(this.rbListFrame, "A frame not tied to a grid. It will be created with default location of 0,0");
			this.rbListFrame.UseVisualStyleBackColor = true;
			this.rbListFrame.CheckedChanged += new System.EventHandler(this.rbListFrame_CheckedChanged);
			// 
			// toolTip1
			// 
			this.toolTip1.IsBalloon = true;
			// 
			// rbAlias
			// 
			this.rbAlias.AutoSize = true;
			this.rbAlias.Location = new System.Drawing.Point(6, 72);
			this.rbAlias.Name = "rbAlias";
			this.rbAlias.Size = new System.Drawing.Size(47, 17);
			this.rbAlias.TabIndex = 7;
			this.rbAlias.TabStop = true;
			this.rbAlias.Text = "Alias";
			this.toolTip1.SetToolTip(this.rbAlias, "An alias frame is a frame that references another frame, used to reduce duplicate" +
        " sprites");
			this.rbAlias.UseVisualStyleBackColor = true;
			this.rbAlias.CheckedChanged += new System.EventHandler(this.rbAlias_CheckedChanged);
			// 
			// cmbAlias
			// 
			this.cmbAlias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAlias.Enabled = false;
			this.cmbAlias.FormattingEnabled = true;
			this.cmbAlias.Location = new System.Drawing.Point(88, 71);
			this.cmbAlias.Name = "cmbAlias";
			this.cmbAlias.Size = new System.Drawing.Size(75, 21);
			this.cmbAlias.TabIndex = 8;
			this.toolTip1.SetToolTip(this.cmbAlias, "The frame to create an alias of");
			this.cmbAlias.SelectedIndexChanged += new System.EventHandler(this.cmbAlias_SelectedIndexChanged);
			// 
			// tbListX
			// 
			this.tbListX.Enabled = false;
			this.tbListX.Location = new System.Drawing.Point(57, 45);
			this.tbListX.Name = "tbListX";
			this.tbListX.Size = new System.Drawing.Size(22, 20);
			this.tbListX.TabIndex = 9;
			this.tbListX.Text = "X";
			this.toolTip1.SetToolTip(this.tbListX, "The X coordinate of the upper-left corner of the new list frame");
			this.tbListX.TextChanged += new System.EventHandler(this.tbFrameName_TextChanged);
			// 
			// tbListY
			// 
			this.tbListY.Enabled = false;
			this.tbListY.Location = new System.Drawing.Point(85, 45);
			this.tbListY.Name = "tbListY";
			this.tbListY.Size = new System.Drawing.Size(22, 20);
			this.tbListY.TabIndex = 10;
			this.tbListY.Text = "Y";
			this.toolTip1.SetToolTip(this.tbListY, "The Y coordinate of the upper-left corner of the new list frame");
			this.tbListY.TextChanged += new System.EventHandler(this.tbFrameName_TextChanged);
			// 
			// tbListW
			// 
			this.tbListW.Enabled = false;
			this.tbListW.Location = new System.Drawing.Point(113, 45);
			this.tbListW.Name = "tbListW";
			this.tbListW.Size = new System.Drawing.Size(22, 20);
			this.tbListW.TabIndex = 11;
			this.tbListW.Text = "W";
			this.toolTip1.SetToolTip(this.tbListW, "The Width of the new list frame");
			this.tbListW.TextChanged += new System.EventHandler(this.tbFrameName_TextChanged);
			// 
			// tbListH
			// 
			this.tbListH.Enabled = false;
			this.tbListH.Location = new System.Drawing.Point(141, 45);
			this.tbListH.Name = "tbListH";
			this.tbListH.Size = new System.Drawing.Size(22, 20);
			this.tbListH.TabIndex = 12;
			this.tbListH.Text = "H";
			this.toolTip1.SetToolTip(this.tbListH, "The Height of the new list frame");
			this.tbListH.TextChanged += new System.EventHandler(this.tbFrameName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Name :";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbListH);
			this.groupBox1.Controls.Add(this.tbListW);
			this.groupBox1.Controls.Add(this.tbListY);
			this.groupBox1.Controls.Add(this.tbListX);
			this.groupBox1.Controls.Add(this.cmbAlias);
			this.groupBox1.Controls.Add(this.rbAlias);
			this.groupBox1.Controls.Add(this.cmbGridName);
			this.groupBox1.Controls.Add(this.rbGridName);
			this.groupBox1.Controls.Add(this.rbListFrame);
			this.groupBox1.Location = new System.Drawing.Point(7, 31);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(169, 99);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Type";
			// 
			// AddFrameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(184, 165);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbFrameName);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnOK);
			this.Name = "AddFrameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Frame";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RadioButton rbGridName;
		private System.Windows.Forms.TextBox tbFrameName;
		private System.Windows.Forms.ComboBox cmbGridName;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.RadioButton rbListFrame;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbAlias;
		private System.Windows.Forms.RadioButton rbAlias;
		private System.Windows.Forms.TextBox tbListH;
		private System.Windows.Forms.TextBox tbListW;
		private System.Windows.Forms.TextBox tbListY;
		private System.Windows.Forms.TextBox tbListX;
	}
}