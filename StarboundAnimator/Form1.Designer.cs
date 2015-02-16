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
			this.tvAssets = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tabWorkspace = new System.Windows.Forms.TabControl();
			this.tabSource = new System.Windows.Forms.TabPage();
			this.tbSource = new System.Windows.Forms.TextBox();
			this.cmsSource = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateFromEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabEditor = new System.Windows.Forms.TabPage();
			this.pgProperties = new System.Windows.Forms.PropertyGrid();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.framesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.convertToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.allFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unpackStarboundAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsAssets = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.animationToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.framesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OFD = new System.Windows.Forms.OpenFileDialog();
			this.SFD = new System.Windows.Forms.SaveFileDialog();
			this.cmsEditorFrames = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addFrameNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addFrameAliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparatorFrames1 = new System.Windows.Forms.ToolStripSeparator();
			this.removeFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlEditor = new StarboundAnimator.EditorPanel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabWorkspace.SuspendLayout();
			this.tabSource.SuspendLayout();
			this.cmsSource.SuspendLayout();
			this.tabEditor.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.cmsAssets.SuspendLayout();
			this.cmsEditorFrames.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.tvAssets);
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
			// tvAssets
			// 
			this.tvAssets.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvAssets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvAssets.HideSelection = false;
			this.tvAssets.ImageIndex = 0;
			this.tvAssets.ImageList = this.imageList1;
			this.tvAssets.LabelEdit = true;
			this.tvAssets.Location = new System.Drawing.Point(0, 0);
			this.tvAssets.Name = "tvAssets";
			this.tvAssets.SelectedImageIndex = 0;
			this.tvAssets.Size = new System.Drawing.Size(190, 673);
			this.tvAssets.TabIndex = 0;
			this.tvAssets.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvAssets_BeforeLabelEdit);
			this.tvAssets.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvAssets_AfterLabelEdit);
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
			this.tbSource.ContextMenuStrip = this.cmsSource;
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
			// cmsSource
			// 
			this.cmsSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshFromFileToolStripMenuItem,
            this.generateFromEditorToolStripMenuItem});
			this.cmsSource.Name = "cmsSource";
			this.cmsSource.Size = new System.Drawing.Size(185, 48);
			// 
			// refreshFromFileToolStripMenuItem
			// 
			this.refreshFromFileToolStripMenuItem.Name = "refreshFromFileToolStripMenuItem";
			this.refreshFromFileToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.refreshFromFileToolStripMenuItem.Text = "Refresh from file";
			this.refreshFromFileToolStripMenuItem.Click += new System.EventHandler(this.refreshFromFileToolStripMenuItem_Click);
			// 
			// generateFromEditorToolStripMenuItem
			// 
			this.generateFromEditorToolStripMenuItem.Name = "generateFromEditorToolStripMenuItem";
			this.generateFromEditorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.generateFromEditorToolStripMenuItem.Text = "Generate from editor";
			this.generateFromEditorToolStripMenuItem.Click += new System.EventHandler(this.generateFromEditorToolStripMenuItem_Click);
			// 
			// tabEditor
			// 
			this.tabEditor.BackColor = System.Drawing.Color.Black;
			this.tabEditor.Controls.Add(this.pnlEditor);
			this.tabEditor.Location = new System.Drawing.Point(4, 4);
			this.tabEditor.Name = "tabEditor";
			this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
			this.tabEditor.Size = new System.Drawing.Size(594, 647);
			this.tabEditor.TabIndex = 1;
			this.tabEditor.Text = "Editor";
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
			this.pgProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgProperties_PropertyValueChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.framesToolStripMenuItem2,
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
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.settingsToolStripMenuItem.Text = "Settings...";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(122, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
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
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// framesToolStripMenuItem2
			// 
			this.framesToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.toolStripSeparator5,
            this.allFramesToolStripMenuItem});
			this.framesToolStripMenuItem2.Name = "framesToolStripMenuItem2";
			this.framesToolStripMenuItem2.Size = new System.Drawing.Size(57, 20);
			this.framesToolStripMenuItem2.Text = "Frames";
			this.framesToolStripMenuItem2.Visible = false;
			// 
			// gridToolStripMenuItem
			// 
			this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGridToolStripMenuItem,
            this.removeGridToolStripMenuItem,
            this.convertToListToolStripMenuItem});
			this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
			this.gridToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.gridToolStripMenuItem.Text = "Grid...";
			// 
			// addGridToolStripMenuItem
			// 
			this.addGridToolStripMenuItem.Name = "addGridToolStripMenuItem";
			this.addGridToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.addGridToolStripMenuItem.Text = "Add";
			this.addGridToolStripMenuItem.Click += new System.EventHandler(this.addGridToolStripMenuItem_Click);
			// 
			// removeGridToolStripMenuItem
			// 
			this.removeGridToolStripMenuItem.Name = "removeGridToolStripMenuItem";
			this.removeGridToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.removeGridToolStripMenuItem.Text = "Remove";
			this.removeGridToolStripMenuItem.Click += new System.EventHandler(this.removeGridToolStripMenuItem_Click);
			// 
			// convertToListToolStripMenuItem
			// 
			this.convertToListToolStripMenuItem.Name = "convertToListToolStripMenuItem";
			this.convertToListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.convertToListToolStripMenuItem.Text = "Convert to List";
			this.convertToListToolStripMenuItem.Click += new System.EventHandler(this.convertToListToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
			// 
			// allFramesToolStripMenuItem
			// 
			this.allFramesToolStripMenuItem.Enabled = false;
			this.allFramesToolStripMenuItem.Name = "allFramesToolStripMenuItem";
			this.allFramesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.allFramesToolStripMenuItem.Text = "All Frames";
			// 
			// unpackStarboundAssetsToolStripMenuItem
			// 
			this.unpackStarboundAssetsToolStripMenuItem.Name = "unpackStarboundAssetsToolStripMenuItem";
			this.unpackStarboundAssetsToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
			this.unpackStarboundAssetsToolStripMenuItem.Text = "Unpack Starbound Assets";
			this.unpackStarboundAssetsToolStripMenuItem.Click += new System.EventHandler(this.unpackStarboundAssetsToolStripMenuItem_Click);
			// 
			// cmsAssets
			// 
			this.cmsAssets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.toolStripSeparator8,
            this.saveToolStripMenuItem1,
            this.toolStripSeparator7,
            this.deleteToolStripMenuItem});
			this.cmsAssets.Name = "cmsAssets";
			this.cmsAssets.Size = new System.Drawing.Size(153, 132);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.animationToolStripMenuItem2,
            this.framesToolStripMenuItem3});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem1.Text = "Add";
			this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// folderToolStripMenuItem
			// 
			this.folderToolStripMenuItem.Image = global::StarboundAnimator.Properties.Resources.folder;
			this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
			this.folderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.folderToolStripMenuItem.Text = "Folder";
			this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
			// 
			// animationToolStripMenuItem2
			// 
			this.animationToolStripMenuItem2.Image = global::StarboundAnimator.Properties.Resources.animation;
			this.animationToolStripMenuItem2.Name = "animationToolStripMenuItem2";
			this.animationToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
			this.animationToolStripMenuItem2.Text = "Animation";
			// 
			// framesToolStripMenuItem3
			// 
			this.framesToolStripMenuItem3.Image = global::StarboundAnimator.Properties.Resources.frames;
			this.framesToolStripMenuItem3.Name = "framesToolStripMenuItem3";
			this.framesToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
			this.framesToolStripMenuItem3.Text = "Frames";
			this.framesToolStripMenuItem3.Click += new System.EventHandler(this.framesToolStripMenuItem3_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
			// 
			// saveToolStripMenuItem1
			// 
			this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
			this.saveToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem1.Text = "Save";
			this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// OFD
			// 
			this.OFD.FileName = "openFileDialog1";
			// 
			// cmsEditorFrames
			// 
			this.cmsEditorFrames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFrameNameToolStripMenuItem,
            this.addFrameAliasToolStripMenuItem,
            this.toolStripSeparatorFrames1,
            this.removeFrameToolStripMenuItem});
			this.cmsEditorFrames.Name = "cmsEditorFrames";
			this.cmsEditorFrames.Size = new System.Drawing.Size(168, 76);
			// 
			// addFrameNameToolStripMenuItem
			// 
			this.addFrameNameToolStripMenuItem.Name = "addFrameNameToolStripMenuItem";
			this.addFrameNameToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.addFrameNameToolStripMenuItem.Text = "Add Frame Name";
			// 
			// addFrameAliasToolStripMenuItem
			// 
			this.addFrameAliasToolStripMenuItem.Name = "addFrameAliasToolStripMenuItem";
			this.addFrameAliasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.addFrameAliasToolStripMenuItem.Text = "Add Frame Alias";
			// 
			// toolStripSeparatorFrames1
			// 
			this.toolStripSeparatorFrames1.Name = "toolStripSeparatorFrames1";
			this.toolStripSeparatorFrames1.Size = new System.Drawing.Size(164, 6);
			// 
			// removeFrameToolStripMenuItem
			// 
			this.removeFrameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.allToolStripMenuItem});
			this.removeFrameToolStripMenuItem.Name = "removeFrameToolStripMenuItem";
			this.removeFrameToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.removeFrameToolStripMenuItem.Text = "Remove Frame";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(85, 6);
			// 
			// allToolStripMenuItem
			// 
			this.allToolStripMenuItem.Name = "allToolStripMenuItem";
			this.allToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
			this.allToolStripMenuItem.Text = "All";
			// 
			// pnlEditor
			// 
			this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEditor.Location = new System.Drawing.Point(3, 3);
			this.pnlEditor.Name = "pnlEditor";
			this.pnlEditor.Size = new System.Drawing.Size(588, 641);
			this.pnlEditor.TabIndex = 0;
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
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.tabWorkspace.ResumeLayout(false);
			this.tabSource.ResumeLayout(false);
			this.tabSource.PerformLayout();
			this.cmsSource.ResumeLayout(false);
			this.tabEditor.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.cmsAssets.ResumeLayout(false);
			this.cmsEditorFrames.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TreeView tvAssets;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
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
		private System.Windows.Forms.OpenFileDialog OFD;
		private System.Windows.Forms.SaveFileDialog SFD;
		public System.Windows.Forms.ContextMenuStrip cmsEditorFrames;
		public System.Windows.Forms.ToolStripMenuItem addFrameNameToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem addFrameAliasToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparatorFrames1;
		public System.Windows.Forms.ToolStripMenuItem removeFrameToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		public System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem framesToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem convertToListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem allFramesToolStripMenuItem;
		public System.Windows.Forms.ContextMenuStrip cmsSource;
		private System.Windows.Forms.ToolStripMenuItem refreshFromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generateFromEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem framesToolStripMenuItem3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
    }
}

