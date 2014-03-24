using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class EditorPanel : Panel
	{
		enum EEditMode { EM_None, EM_Translate };
		EEditMode EditMode;

		readonly int[] ZoomLevels = { 1, 2, 3, 4, 6, 8, 12, 16 };
		int ZoomIndex = 0;
		Color bgColor;
		int[] AreaCenter;
		int[] Translation;
		int[] LastMovePos;

		Color frameDefaultColor;
		Color frameEditColor;
		Pen penGrid;
		Pen penList;
		Pen penName;
		Pen penAlias;
		Pen frameControlBoxPen;

		byte ValidFramesFlag;

		OpenFileDialog OFD;
		VScrollBar vsbZoom;
		ComboBox cbFrameNames;
		CheckBox cbShowGrid;
		CheckBox cbShowList;
		CheckBox cbShowNames;
		CheckBox cbShowAliases;
		Button btnBackground;
		Button btnBgReset;
		Button btnAddFrame;
		Button btnRemoveFrame;

		Point LastImageOffset;
		Matrix LastTransform;

		_frameItem WorkingFrameItem;

		float ControlBoxWidth = 6f;

		public EditorPanel()
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.ResizeRedraw |
						  ControlStyles.ContainerControl |
						  ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.SupportsTransparentBackColor
						  , true);
			InitializeComponent();

			OFD = new OpenFileDialog();
			OFD.AutoUpgradeEnabled = true;
			OFD.CheckFileExists = true;
			OFD.Filter = "Image files (*.bmp, *.gif, *.jpg, *.jpeg, *.png, *.tiff)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff";
			OFD.InitialDirectory = Globals.AppPath;
			OFD.Multiselect = false;

			vsbZoom = new VScrollBar();
			Controls.Add(vsbZoom);
			vsbZoom.Cursor = Cursors.SizeNS;
			vsbZoom.Size = new Size(18, 215);
			vsbZoom.Location = new Point(Bounds.Right - vsbZoom.Width, Bounds.Bottom - vsbZoom.Height);
			vsbZoom.LargeChange = 1;
			vsbZoom.Maximum = ZoomLevels.Length - 1;
			vsbZoom.Value = vsbZoom.Maximum;
			vsbZoom.Name = "vsbZoom";
			vsbZoom.TabIndex = 1;
			vsbZoom.ValueChanged += vsbZoom_ValueChanged;

			cbFrameNames = new ComboBox();
			Controls.Add(cbFrameNames);
			cbFrameNames.Location = new Point(398, 617);
			cbFrameNames.Name = "cbFrameNames";
			cbFrameNames.Size = new Size(173, 21);
			cbFrameNames.TabIndex = 2;
			cbFrameNames.DropDownStyle = ComboBoxStyle.DropDownList;

			cbShowGrid = new CheckBox();
			Controls.Add(cbShowGrid);
			cbShowGrid.Appearance = Appearance.Button;
			cbShowGrid.AutoSize = true;
			cbShowGrid.Location = new Point(3, 3);
			cbShowGrid.Name = "cbShowGrid";
			cbShowGrid.Size = new Size(36, 23);
			cbShowGrid.TabIndex = 3;
			cbShowGrid.Text = "Grid";
			cbShowGrid.UseVisualStyleBackColor = true;
			cbShowGrid.Checked = false;
			cbShowGrid.CheckState = CheckState.Unchecked;
			cbShowGrid.CheckedChanged += FrameShowFilterChanged;

			cbShowList = new CheckBox();
			Controls.Add(cbShowList);
			cbShowList.Appearance = Appearance.Button;
			cbShowList.AutoSize = true;
			cbShowList.Location = new Point(cbShowGrid.Location.X + cbShowGrid.Width + 1, 3);
			cbShowList.Name = "cbShowList";
			cbShowList.Size = new Size(36, 23);
			cbShowList.TabIndex = 4;
			cbShowList.Text = "List";
			cbShowList.UseVisualStyleBackColor = true;
			cbShowList.Checked = false;
			cbShowList.CheckState = CheckState.Unchecked;
			cbShowList.CheckedChanged += FrameShowFilterChanged;

			cbShowNames = new CheckBox();
			Controls.Add(cbShowNames);
			cbShowNames.Appearance = Appearance.Button;
			cbShowNames.AutoSize = true;
			cbShowNames.Location = new Point(cbShowList.Location.X + cbShowList.Width + 1, 3);
			cbShowNames.Name = "cbShowNames";
			cbShowNames.Size = new Size(36, 23);
			cbShowNames.TabIndex = 5;
			cbShowNames.Text = "Names";
			cbShowNames.UseVisualStyleBackColor = true;
			cbShowNames.Checked = false;
			cbShowNames.CheckState = CheckState.Unchecked;
			cbShowNames.CheckedChanged += FrameShowFilterChanged;

			cbShowAliases = new CheckBox();
			Controls.Add(cbShowAliases);
			cbShowAliases.Appearance = Appearance.Button;
			cbShowAliases.AutoSize = true;
			cbShowAliases.Location = new Point(cbShowNames.Location.X + cbShowNames.Width + 1, 3);
			cbShowAliases.Name = "cbShowAliases";
			cbShowAliases.Size = new Size(36, 23);
			cbShowAliases.TabIndex = 5;
			cbShowAliases.Text = "Aliases";
			cbShowAliases.UseVisualStyleBackColor = true;
			cbShowAliases.Checked = false;
			cbShowAliases.CheckState = CheckState.Unchecked;
			cbShowAliases.CheckedChanged += FrameShowFilterChanged;

			btnBackground = new Button();
			Controls.Add(btnBackground);
			btnBackground.Name = "btnBackground";
			btnBackground.Size = new Size(75, 23);
			btnBackground.Location = new Point(3, Bounds.Bottom - btnBackground.Height);
			btnBackground.TabIndex = 6;
			btnBackground.Text = "Background";
			btnBackground.UseVisualStyleBackColor = true;
			btnBackground.Click += btnBackgound_Clicked;

			btnBgReset = new Button();
			Controls.Add(btnBgReset);
			btnBgReset.Enabled = false;
			btnBgReset.Name = "btnBgReset";
			btnBgReset.Size = new Size(45, 23);
			btnBgReset.Location = new Point(btnBackground.Location.X, btnBackground.Location.Y - btnBgReset.Height - 1);
			btnBgReset.TabIndex = 7;
			btnBgReset.Text = "Reset";
			btnBgReset.UseVisualStyleBackColor = true;
			btnBgReset.Click += btnBgReset_Clicked;

			btnAddFrame = new Button();
			Controls.Add(btnAddFrame);
			btnAddFrame.Name = "btnAddFrame";
			btnAddFrame.Size = new Size(23, 23);
			btnAddFrame.Location = new Point(cbFrameNames.Location.X - 25, cbFrameNames.Location.Y);
			btnAddFrame.TabIndex = 8;
			btnAddFrame.Text = "+";
			btnAddFrame.UseVisualStyleBackColor = true;
			btnAddFrame.Click += btnAddFrame_Clicked;

			btnRemoveFrame = new Button();
			Controls.Add(btnRemoveFrame);
			btnRemoveFrame.Name = "btnRemoveFrame";
			btnRemoveFrame.Size = new Size(23, 23);
			btnRemoveFrame.Location = new Point(cbFrameNames.Location.X - 25, cbFrameNames.Location.Y);
			btnRemoveFrame.TabIndex = 8;
			btnRemoveFrame.Text = "-";
			btnRemoveFrame.UseVisualStyleBackColor = true;
			btnRemoveFrame.Enabled = false;
			btnRemoveFrame.Click += btnRemoveFrame_Clicked;

			bgColor = Color.Black;
			frameDefaultColor = Color.FromArgb(127, Color.Magenta);
			penGrid = new Pen(frameDefaultColor, 1);
			penList = penGrid;
			penName = new Pen(Color.FromArgb(127, Color.Yellow), 1);
			penAlias = new Pen(Color.FromArgb(127, Color.Cyan), 1);
			frameEditColor = Color.Silver;
			frameControlBoxPen = new Pen(frameEditColor, 1);

			Translation = new int[] { 0, 0 };
			LastMovePos = new int[] { 0, 0 };

			LastTransform = new Matrix();
		}

		void btnAddFrame_Clicked(object sender, EventArgs e)
		{
			AddFrameForm aff = new AddFrameForm();
			if (WorkingFrameItem == null)
			{
				aff.InitAll();
			}
			else
			{
				aff.InitForFrame(WorkingFrameItem);
			}

			DialogResult dr = aff.ShowDialog();
			if (dr == DialogResult.OK)
			{
				if (aff.FrameType == Globals.FrameSource_Name)
				{
					Globals.WorkingFrames.SetFrameGridName(aff.NameOf, aff.FrameName);
				}
				else if (aff.FrameType == Globals.FrameSource_List)
				{
					Rectangle size = aff.FrameSize;
					Globals.WorkingFrames.AddFrameListItem(aff.FrameName, size.X, size.Y, size.Width, size.Height);
				}
				else if (aff.FrameType == Globals.FrameSource_Alias)
				{
					Globals.WorkingFrames.AddAlias(aff.FrameName, aff.AliasOf);
				}

				UpdateFrameShowButtons(true);
				Invalidate();
			}
		}

		void RemoveFrame(_frameName rf)
		{
			if (rf != null)
			{
				if (Globals.WorkingFrames != null) Globals.WorkingFrames.RemoveFrame(rf);
				Invalidate();
			}
		}

		void btnRemoveFrame_Clicked(object sender, EventArgs e)
		{
			if (WorkingFrameItem == null)
			{
				btnRemoveFrame.Enabled = false;
				return;
			}

			List<_frameName> fns;
			DialogResult dr;
			_frameName curFrame = WorkingFrameItem.names[cbFrameNames.SelectedIndex];
			if (curFrame.source == Globals.FrameSource_Grid)
			{
				// not normally able to delete default frames. only solution is to copy all default frames to the frameList set and then remove the frameGrid
			}
			else
			{
				fns = Globals.WorkingFrames.GetAliasesFor(curFrame.name);
				bool bDelete = false;
				if (fns.Count > 0)
				{
					dr = MessageBox.Show("Deleting the frame '" + curFrame.name + "' will delete " + fns.Count + " aliases. Do you want to move them to a different frame instead?", "Dependancy Check", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (dr == DialogResult.Yes)
					{
						// build exclude list
						List<string> excludes = new List<string>();
						excludes.Add(curFrame.name);
						foreach (_frameName fn in fns)
							excludes.Add(fn.name);
						FrameSelectForm fsf = new FrameSelectForm();
						fsf.InitFor(Globals.WorkingFrames, excludes);
						dr = fsf.ShowDialog();
						if (dr == DialogResult.OK)
						{
							string nn = fsf.Value;
							if (nn != null)
							{
								foreach (_frameName fn in fns)
								{
									fn.aliasof = nn;
									WorkingFrameItem.RemoveName(fn.name);
									_frameItem fi = Globals.WorkingFrames.ListFrameItems.Find(f => f.names.Exists(n => n.name == nn));
									if (fi != null) fi.names.Add(fn);
									Globals.WorkingFrames.aliases[fn.name] = nn;
								}

								bDelete = true;
							}
						}
					}
					else if (dr == DialogResult.No)
					{
						foreach (_frameName fn in fns)
							RemoveFrame(fn);

						bDelete = true;
					}
				}
				else
				{
					dr = MessageBox.Show("Are you sure you want to delete the frame '" + curFrame.name + "'?", "Deletion Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.Yes) bDelete = true;
				}

				if (bDelete)
				{
					RemoveFrame(curFrame);

					WorkingFrameItem = null;
					cbFrameNames.Items.Clear();

					Invalidate();
				}
			}
		}

		void vsbZoom_ValueChanged(object o, EventArgs e)
		{
			ZoomIndex = ZoomLevels.Length - 1 - vsbZoom.Value;
			Invalidate();
		}

		void btnBackgound_Clicked(object o, EventArgs e)
		{
			DialogResult dr = OFD.ShowDialog();
			if (dr == DialogResult.OK)
			{
				Image tai = Globals.WorkingFrames.AltImg;
				Globals.WorkingFrames.AltImg = null;
				try
				{
					Image img = Image.FromFile(OFD.FileName);
					Globals.WorkingFrames.AltImg = img.Clone() as Image;
					img.Dispose();
					if (tai != null)
					{
						tai.Dispose();
						tai = null;
					}

					btnBgReset.Enabled = true;
				}
				catch
				{
					if (Globals.WorkingFrames.AltImg == null)
					{
						Globals.WorkingFrames.AltImg = tai;
					}

					btnBgReset.Enabled = Globals.WorkingFrames.AltImg != null;
				}

				Invalidate();
			}
		}

		void btnBgReset_Clicked(object o, EventArgs e)
		{
			if (Globals.WorkingFrames.AltImg != null)
			{
				Globals.WorkingFrames.AltImg.Dispose();
				Globals.WorkingFrames.AltImg = null;
			}

			btnBgReset.Enabled = false;

			Invalidate();
		}

		void FrameShowFilterChanged(object o, EventArgs e)
		{
			byte flag = Globals.FrameSource_None;
			bool bOn = false;

			if (o == cbShowGrid)
			{
				flag = Globals.FrameSource_Grid;
				bOn = cbShowGrid.Checked;
			}
			else if (o == cbShowList)
			{
				flag = Globals.FrameSource_List;
				bOn = cbShowList.Checked;
			}
			else if (o == cbShowNames)
			{
				flag = Globals.FrameSource_Name;
				bOn = cbShowNames.Checked;
			}
			else if (o == cbShowAliases)
			{
				flag = Globals.FrameSource_Alias;
				bOn = cbShowAliases.Checked;
			}

			if (bOn) ValidFramesFlag |= flag;
			else
			{
				if ((ValidFramesFlag & flag) > 0) ValidFramesFlag -= flag;
			}

			Invalidate();
		}

		void RecalcAreaCenter(RectangleF vb)
		{
			AreaCenter = new int[]
			{
				(int)(vb.Left + vb.Right) / 2,
				(int)(vb.Top + vb.Bottom) / 2
			};
		}

		protected override void OnResize(EventArgs eventargs)
		{
			AreaCenter = null;

			vsbZoom.Location = new Point(Bounds.Right - vsbZoom.Width - 1, Bounds.Bottom - vsbZoom.Height - 1);
			cbFrameNames.Location = new Point(vsbZoom.Location.X - cbFrameNames.Width - 1, Bounds.Bottom - cbFrameNames.Height - 1);
			btnBackground.Location = new Point(btnBackground.Location.X, Bounds.Bottom - btnBackground.Height - 3);
			btnBgReset.Location = new Point(btnBackground.Location.X, btnBackground.Location.Y - btnBgReset.Height - 1);
			btnRemoveFrame.Location = new Point(cbFrameNames.Location.X - btnRemoveFrame.Width - 1, cbFrameNames.Location.Y);
			btnAddFrame.Location = new Point(btnRemoveFrame.Location.X - btnAddFrame.Width - 1, btnRemoveFrame.Location.Y);

			base.OnResize(eventargs);
		}

		public void SetBackgroundColor(Color newbg)
		{
			bgColor = newbg;
		}

		public void ResetView()
		{
			Translation[0] = Translation[1] = 0;
			vsbZoom.Value = 0;
		}

		public void EndMode()
		{
			Cursor = Cursors.Default;
			EditMode = EEditMode.EM_None;
		}

		public void UpdateFrameShowButtons(bool bShow)
		{
			cbShowGrid.Visible = bShow;
			cbShowList.Visible = bShow;
			cbShowNames.Visible = bShow;
			cbShowAliases.Visible = bShow;

			if (!bShow)
			{
				ValidFramesFlag = Globals.FrameSource_None;
			}
			else if (Globals.WorkingFrames == null)
			{
				cbShowGrid.Enabled = false;
				cbShowList.Enabled = false;
				cbShowNames.Enabled = false;
				cbShowAliases.Enabled = false;
			}
			else
			{
				ValidFramesFlag = Globals.FrameSource_None;
				cbShowGrid.Checked = cbShowGrid.Enabled = Globals.WorkingFrames.frameGrid != null;
				if (cbShowGrid.Checked) ValidFramesFlag |= Globals.FrameSource_Grid;
				cbShowList.Checked = cbShowList.Enabled = Globals.WorkingFrames.frameList != null;
				if (cbShowList.Checked) ValidFramesFlag |= Globals.FrameSource_List;
				cbShowNames.Checked = cbShowNames.Enabled = cbShowGrid.Enabled && ((Globals.WorkingFrames.frameGrid.names != null) && (Globals.WorkingFrames.frameGrid.names.Count > 0));
				if (cbShowNames.Checked) ValidFramesFlag |= Globals.FrameSource_Name;
				cbShowAliases.Checked = cbShowAliases.Enabled = Globals.WorkingFrames.aliases != null;
				if (cbShowAliases.Checked) ValidFramesFlag |= Globals.FrameSource_Alias;
			}
		}

		public void InitForFrame()
		{
			UpdateFrameShowButtons(true);
			btnBgReset.Enabled = Globals.WorkingFrames.AltImg != null;
		}

		protected override void OnLostFocus(EventArgs e)
		{
			// cancel whatever operation we're in the middle of
			EndMode();
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			if (Globals.WorkingFrames != null)
			{
				Matrix IT = LastTransform.Clone();
				IT.Invert();
				Point[] p = new Point[] { new Point(e.X, e.Y) };
				IT.TransformPoints(p);
				p[0].X -= LastImageOffset.X;
				p[0].Y -= LastImageOffset.Y;
				WorkingFrameItem = Globals.WorkingFrames.GetItemUnder(p[0].X, p[0].Y, ValidFramesFlag);
				cbFrameNames.Items.Clear();
				if (WorkingFrameItem != null)
				{
					string name;
					foreach (_frameName fn in WorkingFrameItem.names)
					{
						if ((fn.source & ValidFramesFlag) == 0) continue;
						name = fn.name;
						if (fn.source == Globals.FrameSource_Grid) name += " (default)";
						else if (fn.source == Globals.FrameSource_List) name += " (list)";
						else if (fn.source == Globals.FrameSource_Name) name += " (name)";
						else if (fn.source == Globals.FrameSource_Alias) name += " (alias)";
						cbFrameNames.Items.Add(name);
					}

					cbFrameNames.SelectedIndex = 0;

					btnRemoveFrame.Enabled = true;
				}
				else
				{
					cbFrameNames.Text = "";
					btnRemoveFrame.Enabled = false;
				}

				Invalidate();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			Focus();

			if (EditMode == EEditMode.EM_None)
			{
				if (e.Button == MouseButtons.Right)
				{
					Capture = true;
					EditMode = EEditMode.EM_Translate;
					LastMovePos[0] = e.X;
					LastMovePos[1] = e.Y;

					Cursor = Cursors.NoMove2D;
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.None)
			{
				if (WorkingFrameItem == null)
				{
					Matrix IT = LastTransform.Clone();
					IT.Invert();
					Point[] p = new Point[] { new Point(e.X, e.Y) };
					IT.TransformPoints(p);
					p[0].X -= LastImageOffset.X;
					p[0].Y -= LastImageOffset.Y;
					_frameItem FI = Globals.WorkingFrames.GetItemUnder(p[0].X, p[0].Y, ValidFramesFlag);
					cbFrameNames.Items.Clear();
					if (FI != null)
					{
						string name;
						foreach (_frameName fn in FI.names)
						{
							if ((fn.source & ValidFramesFlag) == 0) continue;
							name = fn.name;
							if (fn.source == Globals.FrameSource_Grid) name += " (default)";
							else if (fn.source == Globals.FrameSource_List) name += " (list)";
							else if (fn.source == Globals.FrameSource_Name) name += " (name)";
							else if (fn.source == Globals.FrameSource_Alias) name += " (alias)";
							cbFrameNames.Items.Add(name);
						}
						
						cbFrameNames.SelectedIndex = 0;
					}
					else cbFrameNames.Text = "";
				}

				return;
			}

			if (EditMode == EEditMode.EM_Translate)
			{
				Translation[0] += e.X - LastMovePos[0];
				Translation[1] += e.Y - LastMovePos[1];
				LastMovePos[0] = e.X;
				LastMovePos[1] = e.Y;

				Invalidate();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (Capture) Capture = false;

			if (EditMode == EEditMode.EM_Translate) EndMode();
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Translation[0] = Translation[1] = 0;
				Invalidate();
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				if (ZoomIndex < ZoomLevels.Length - 1)
				{
					//Translation[0] -= (e.X - AreaCenter[0]) / ZoomLevels[ZoomIndex + 1];
					//Translation[1] -= (e.Y - AreaCenter[1]) / ZoomLevels[ZoomIndex + 1];
					vsbZoom.Value--;

					Invalidate();
				}
			}
			else if (e.Delta < 0)
			{
				if (ZoomIndex > 0)
				{
					//Translation[0] += (e.X - AreaCenter[0]) / ZoomLevels[ZoomIndex - 1];
					//Translation[1] += (e.Y - AreaCenter[1]) / ZoomLevels[ZoomIndex - 1];
					vsbZoom.Value++;

					Invalidate();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// draw background color
			e.Graphics.Clear(bgColor);

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

			if (AreaCenter == null) RecalcAreaCenter(e.Graphics.VisibleClipBounds);

			e.Graphics.TranslateTransform(Translation[0] + AreaCenter[0], Translation[1] + AreaCenter[1]);
			e.Graphics.ScaleTransform(ZoomLevels[ZoomIndex], ZoomLevels[ZoomIndex]);
			LastTransform = e.Graphics.Transform;

			if (Globals.WorkingFrames != null)
			{
				int imgX = 0;
				int imgY = 0;
				int imgWidth = 0;
				int imgHeight = 0;
				Image img = Globals.WorkingFrames.AltImg != null ? Globals.WorkingFrames.AltImg : Globals.WorkingFrames.Img;
				if (img != null)
				{
					imgWidth = img.Width;
					imgHeight = img.Height;
					imgX = -imgWidth / 2;
					imgY = -imgHeight / 2;
					LastImageOffset.X = imgX;
					LastImageOffset.Y = imgY;
				}

				// render the image first
				if (img != null) e.Graphics.DrawImage(img, imgX, imgY, imgWidth, imgHeight);

				Pen p;
				foreach (_frameItem fi in Globals.WorkingFrames.ListFrameItems)
				{
					foreach (_frameName fn in fi.names)
					{
						if ((fn.source & ValidFramesFlag) == 0) continue;
						if (fn.source == Globals.FrameSource_Grid) p = penGrid;
						else if (fn.source == Globals.FrameSource_List) p = penList;
						else if (fn.source == Globals.FrameSource_Name) p = penName;
						else if (fn.source == Globals.FrameSource_Alias) p = penAlias;
						else continue;

						e.Graphics.DrawRectangle(p, fi.x + 0.5f + imgX, fi.y + 0.5f + imgY, fi.width - 1, fi.height - 1);
					}
				}

				// draw frameGrid control boxes
				if ((Globals.WorkingFrames.frameGrid != null) && ((WorkingFrameItem == null) || cbFrameNames.SelectedItem.ToString().Contains("(default)")))
				{
				}
				// draw WorkingFrameItem control boxes
				else if ((WorkingFrameItem != null) && cbFrameNames.SelectedItem.ToString().Contains("(list)"))
				{
					// upper left control box
					float x = WorkingFrameItem.x + 0.5f + imgX;
					float y = WorkingFrameItem.y + 0.5f + imgY;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// upper middle control box
					x += WorkingFrameItem.width / 2;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// upper right control box
					x += WorkingFrameItem.width / 2;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// middle left control box
					x = WorkingFrameItem.x + 0.5f + imgX;
					y += WorkingFrameItem.height / 2;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// middle right control box
					x += WorkingFrameItem.width - 1;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// lower left control box
					x = WorkingFrameItem.x + 0.5f + imgX;
					y += WorkingFrameItem.height / 2;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// lower middle control box
					x += WorkingFrameItem.width / 2;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);

					// lower right control box
					x += WorkingFrameItem.width / 2;
					e.Graphics.DrawRectangle(frameControlBoxPen, x - ControlBoxWidth / 2, y - ControlBoxWidth / 2, ControlBoxWidth, ControlBoxWidth);
				}

				img = null;
			}
			else if (Globals.WorkingAnimation != null)
			{
			}
		}
	}
}
