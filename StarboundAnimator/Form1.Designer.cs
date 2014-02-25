namespace StarboundAnimator
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabPages = new System.Windows.Forms.TabControl();
			this.tabProject = new System.Windows.Forms.TabPage();
			this.tvProjects = new System.Windows.Forms.TreeView();
			this.tabAssets = new System.Windows.Forms.TabPage();
			this.tvAssets = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tabWorkspace = new System.Windows.Forms.TabControl();
			this.tabSource = new System.Windows.Forms.TabPage();
			this.tbSource = new System.Windows.Forms.TextBox();
			this.tabEditor = new System.Windows.Forms.TabPage();
			this.pnlEditor = new StarboundAnimator.EditorPanel();
			this.pgProperties = new System.Windows.Forms.PropertyGrid();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.framesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.animationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.framesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unpackStarboundAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsAssets = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabPages.SuspendLayout();
			this.tabProject.SuspendLayout();
			this.tabAssets.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabWorkspace.SuspendLayout();
			this.tabSource.SuspendLayout();
			this.tabEditor.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.cmsAssets.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabPages);
			this.splitContainer1.Panel1MinSize = 128;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1035, 677);
			this.splitContainer1.SplitterDistance = 194;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 0;
			// 
			// tabPages
			// 
			this.tabPages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabPages.Controls.Add(this.tabProject);
			this.tabPages.Controls.Add(this.tabAssets);
			this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPages.Location = new System.Drawing.Point(0, 0);
			this.tabPages.MinimumSize = new System.Drawing.Size(116, 0);
			this.tabPages.Multiline = true;
			this.tabPages.Name = "tabPages";
			this.tabPages.SelectedIndex = 0;
			this.tabPages.Size = new System.Drawing.Size(190, 673);
			this.tabPages.TabIndex = 0;
			// 
			// tabProject
			// 
			this.tabProject.AutoScroll = true;
			this.tabProject.Controls.Add(this.tvProjects);
			this.tabProject.Location = new System.Drawing.Point(4, 4);
			this.tabProject.Name = "tabProject";
			this.tabProject.Size = new System.Drawing.Size(182, 647);
			this.tabProject.TabIndex = 2;
			this.tabProject.Text = "Project";
			this.tabProject.UseVisualStyleBackColor = true;
			// 
			// tvProjects
			// 
			this.tvProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvProjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvProjects.Location = new System.Drawing.Point(0, 0);
			this.tvProjects.Name = "tvProjects";
			this.tvProjects.ShowRootLines = false;
			this.tvProjects.Size = new System.Drawing.Size(182, 647);
			this.tvProjects.TabIndex = 0;
			// 
			// tabAssets
			// 
			this.tabAssets.AutoScroll = true;
			this.tabAssets.BackColor = System.Drawing.Color.Transparent;
			this.tabAssets.Controls.Add(this.tvAssets);
			this.tabAssets.Location = new System.Drawing.Point(4, 4);
			this.tabAssets.Name = "tabAssets";
			this.tabAssets.Size = new System.Drawing.Size(182, 647);
			this.tabAssets.TabIndex = 3;
			this.tabAssets.Text = "Assets";
			// 
			// tvAssets
			// 
			this.tvAssets.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvAssets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvAssets.HideSelection = false;
			this.tvAssets.ImageIndex = 0;
			this.tvAssets.ImageList = this.imageList1;
			this.tvAssets.Location = new System.Drawing.Point(0, 0);
			this.tvAssets.Name = "tvAssets";
			this.tvAssets.SelectedImageIndex = 0;
			this.tvAssets.Size = new System.Drawing.Size(182, 647);
			this.tvAssets.TabIndex = 0;
			this.tvAssets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAssets_AfterSelect);
			this.tvAssets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvAssets_MouseClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder.png");
			this.imageList1.Images.SetKeyName(1, "folder_bad.png");
			this.imageList1.Images.SetKeyName(2, "animation.png");
			this.imageList1.Images.SetKeyName(3, "animation_bad.png");
			this.imageList1.Images.SetKeyName(4, "frames.png");
			this.imageList1.Images.SetKeyName(5, "frames_bad.png");
			this.imageList1.Images.SetKeyName(6, "framegrid.png");
			this.imageList1.Images.SetKeyName(7, "framelist.png");
			this.imageList1.Images.SetKeyName(8, "frames_untested.png");
			this.imageList1.Images.SetKeyName(9, "animation_untested.png");
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tabWorkspace);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pgProperties);
			this.splitContainer2.Size = new System.Drawing.Size(838, 677);
			this.splitContainer2.SplitterDistance = 606;
			this.splitContainer2.TabIndex = 0;
			// 
			// tabWorkspace
			// 
			this.tabWorkspace.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabWorkspace.Controls.Add(this.tabSource);
			this.tabWorkspace.Controls.Add(this.tabEditor);
			this.tabWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabWorkspace.Location = new System.Drawing.Point(0, 0);
			this.tabWorkspace.Name = "tabWorkspace";
			this.tabWorkspace.SelectedIndex = 0;
			this.tabWorkspace.Size = new System.Drawing.Size(602, 673);
			this.tabWorkspace.TabIndex = 0;
			this.tabWorkspace.Visible = false;
			// 
			// tabSource
			// 
			this.tabSource.Controls.Add(this.tbSource);
			this.tabSource.Location = new System.Drawing.Point(4, 4);
			this.tabSource.Margin = new System.Windows.Forms.Padding(0);
			this.tabSource.Name = "tabSource";
			this.tabSource.Padding = new System.Windows.Forms.Padding(3);
			this.tabSource.Size = new System.Drawing.Size(594, 647);
			this.tabSource.TabIndex = 0;
			this.tabSource.Text = "Source";
			this.tabSource.UseVisualStyleBackColor = true;
			// 
			// tbSource
			// 
			this.tbSource.BackColor = System.Drawing.SystemColors.Window;
			this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSource.Location = new System.Drawing.Point(3, 3);
			this.tbSource.Margin = new System.Windows.Forms.Padding(0);
			this.tbSource.MaxLength = 0;
			this.tbSource.Multiline = true;
			this.tbSource.Name = "tbSource";
			this.tbSource.ReadOnly = true;
			this.tbSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbSource.Size = new System.Drawing.Size(588, 641);
			this.tbSource.TabIndex = 0;
			// 
			// tabEditor
			// 
			this.tabEditor.Controls.Add(this.pnlEditor);
			this.tabEditor.Location = new System.Drawing.Point(4, 4);
			this.tabEditor.Name = "tabEditor";
			this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
			this.tabEditor.Size = new System.Drawing.Size(594, 647);
			this.tabEditor.TabIndex = 1;
			this.tabEditor.Text = "Editor";
			this.tabEditor.UseVisualStyleBackColor = true;
			// 
			// pnlEditor
			// 
			this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEditor.Location = new System.Drawing.Point(3, 3);
			this.pnlEditor.Name = "pnlEditor";
			this.pnlEditor.Size = new System.Drawing.Size(588, 641);
			this.pnlEditor.TabIndex = 0;
			// 
			// pgProperties
			// 
			this.pgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgProperties.Location = new System.Drawing.Point(0, 0);
			this.pgProperties.Name = "pgProperties";
			this.pgProperties.PropertySort = System.Windows.Forms.PropertySort.NoSort;
			this.pgProperties.Size = new System.Drawing.Size(224, 673);
			this.pgProperties.TabIndex = 1;
			this.pgProperties.ToolbarVisible = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.unpackStarboundAssetsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.animationToolStripMenuItem,
            this.framesToolStripMenuItem});
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.projectToolStripMenuItem.Text = "Project...";
			// 
			// animationToolStripMenuItem
			// 
			this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
			this.animationToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.animationToolStripMenuItem.Text = "Animation...";
			// 
			// framesToolStripMenuItem
			// 
			this.framesToolStripMenuItem.Name = "framesToolStripMenuItem";
			this.framesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.framesToolStripMenuItem.Text = "Frames...";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem1,
            this.animationToolStripMenuItem1,
            this.framesToolStripMenuItem1});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// projectToolStripMenuItem1
			// 
			this.projectToolStripMenuItem1.Name = "projectToolStripMenuItem1";
			this.projectToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.projectToolStripMenuItem1.Text = "Project...";
			// 
			// animationToolStripMenuItem1
			// 
			this.animationToolStripMenuItem1.Name = "animationToolStripMenuItem1";
			this.animationToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.animationToolStripMenuItem1.Text = "Animation...";
			// 
			// framesToolStripMenuItem1
			// 
			this.framesToolStripMenuItem1.Name = "framesToolStripMenuItem1";
			this.framesToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.framesToolStripMenuItem1.Text = "Frames...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(140, 6);
			// 
			// closeProjectToolStripMenuItem
			// 
			this.closeProjectToolStripMenuItem.Enabled = false;
			this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
			this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.closeProjectToolStripMenuItem.Text = "Close Project";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.settingsToolStripMenuItem.Text = "Settings...";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// unpackStarboundAssetsToolStripMenuItem
			// 
			this.unpackStarboundAssetsToolStripMenuItem.Enabled = false;
			this.unpackStarboundAssetsToolStripMenuItem.Name = "unpackStarboundAssetsToolStripMenuItem";
			this.unpackStarboundAssetsToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
			this.unpackStarboundAssetsToolStripMenuItem.Text = "Unpack Starbound Assets";
			this.unpackStarboundAssetsToolStripMenuItem.Click += new System.EventHandler(this.unpackStarboundAssetsToolStripMenuItem_Click);
			// 
			// cmsAssets
			// 
			this.cmsAssets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
			this.cmsAssets.Name = "cmsAssets";
			this.cmsAssets.Size = new System.Drawing.Size(114, 26);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1035, 701);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Starbound Animator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tabPages.ResumeLayout(false);
			this.tabProject.ResumeLayout(false);
			this.tabAssets.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.tabWorkspace.ResumeLayout(false);
			this.tabSource.ResumeLayout(false);
			this.tabSource.PerformLayout();
			this.tabEditor.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.cmsAssets.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.TreeView tvProjects;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem framesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem framesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabPage tabAssets;
        private System.Windows.Forms.TreeView tvAssets;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cmsAssets;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.TabControl tabWorkspace;
		private System.Windows.Forms.TabPage tabSource;
		private System.Windows.Forms.TextBox tbSource;
		private System.Windows.Forms.TabPage tabEditor;
		private System.Windows.Forms.PropertyGrid pgProperties;
		private System.Windows.Forms.ToolStripMenuItem unpackStarboundAssetsToolStripMenuItem;
		private EditorPanel pnlEditor;
    }
}

