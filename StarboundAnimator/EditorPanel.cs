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
		int ZoomIndex;
		Color bgColor;
		int[] AreaCenter;
		int[] Translation;
		int[] LastMovePos;

		Color frameColor;
		Pen framePen;

		VScrollBar vsbZoom;

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

			bgColor = Color.Black;
			frameColor = Color.FromArgb(127, Color.Magenta);
			framePen = new Pen(frameColor, 1);

			Translation = new int[] { 0, 0 };
			LastMovePos = new int[] { 0, 0 };
		}

		void vsbZoom_ValueChanged(object o, EventArgs e)
		{
			ZoomIndex = ZoomLevels.Length - 1 - vsbZoom.Value;
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

			vsbZoom.Location = new Point(Bounds.Right - vsbZoom.Width, Bounds.Bottom - vsbZoom.Height);

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

		protected override void OnLostFocus(EventArgs e)
		{
			// cancel whatever operation we're in the middle of
			EndMode();
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
			if (e.Button == MouseButtons.None) return;

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
				}
			}
			else if (e.Delta < 0)
			{
				if (ZoomIndex > 0)
				{
					//Translation[0] += (e.X - AreaCenter[0]) / ZoomLevels[ZoomIndex - 1];
					//Translation[1] += (e.Y - AreaCenter[1]) / ZoomLevels[ZoomIndex - 1];
					vsbZoom.Value++;
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

			if (Globals.WorkingFrames != null)
			{
				int AreaX = 0;
				int AreaY = 0;
				int AreaWidth = 0;
				int AreaHeight = 0;
				Image img = Globals.WorkingFrames.Img;
				if (img != null)
				{
					AreaWidth = img.Width;
					AreaHeight = img.Height;
					AreaX = -AreaWidth / 2;
					AreaY = -AreaHeight / 2;
				}

				// render the image first
				if (img != null) e.Graphics.DrawImage(img, AreaX, AreaY, AreaWidth, AreaHeight);

				foreach (KeyValuePair<string, _frameItem> frame in Globals.WorkingFrames.FrameItems)
				{
					e.Graphics.DrawRectangle(framePen, frame.Value.x + 0.5f + AreaX, frame.Value.y + 0.5f + AreaY, frame.Value.width - 1, frame.Value.height - 1);
				}

				img = null;
			}
			else if (Globals.WorkingAnimation != null)
			{
			}
		}
	}
}
