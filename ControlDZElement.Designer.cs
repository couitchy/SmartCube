using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200005A RID: 90
	public class ControlDZElement : UserControl
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000232 RID: 562 RVA: 0x000154D0 File Offset: 0x000136D0
		// (remove) Token: 0x06000233 RID: 563 RVA: 0x00015508 File Offset: 0x00013708
		public event ControlDZElement.DataChanged m_dataChanged;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000234 RID: 564 RVA: 0x00015540 File Offset: 0x00013740
		// (remove) Token: 0x06000235 RID: 565 RVA: 0x00015578 File Offset: 0x00013778
		public event ControlDZElement.MouseWheelChangedEvent m_wheel;

		// Token: 0x06000236 RID: 566 RVA: 0x000155AD File Offset: 0x000137AD
		public void ShowControl(byte[] buff8)
		{
			this.datBuff = null;
			this.datBuff = buff8;
			this.OnPaint();
			base.Visible = true;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000155CA File Offset: 0x000137CA
		public void HideControl()
		{
			base.Visible = false;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000155D4 File Offset: 0x000137D4
		public ControlDZElement()
		{
			this.InitializeComponent();
			this.InitLeds();
			this.m_menu.Items.Add("Clear");
			this.m_menu.Items.Add("Display all");
			this.m_menu.Items.Add("Display adverse");
			this.m_menu.Items.Add("Copy(CTRL+C)");
			this.m_menu.Items.Add("Paste(CTRL+V)");
			this.m_menu.Items.Add("Clockwise rotation");
			this.m_menu.Items.Add("Reverse the clock rotation");
			this.m_menu.Items.Add("About the mirror");
			this.m_menu.Items.Add("Up and down the mirror");
			this.m_menu.ItemClicked += this.m_menu_ItemClicked;
			base.MouseWheel += this.ControlDZElement_MouseWheel;
			this.HideControl();
			base.MouseHover += this.ControlDZElement_MouseHover;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00015743 File Offset: 0x00013943
		private void ControlDZElement_MouseHover(object sender, EventArgs e)
		{
			if (!this.Focused)
			{
				base.Focus();
			}
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00015754 File Offset: 0x00013954
		private void ControlDZElement_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta != 0 && this.m_wheel != null)
			{
				this.m_wheel(e.Delta);
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00015778 File Offset: 0x00013978
		private void InitLeds()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int num = 2 + i * 18;
					int num2 = 2 + (7 - j) * 18;
					this.rects[j, i] = new Rectangle(num, num2, 16, 16);
				}
			}
			this.OnSize();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000157D0 File Offset: 0x000139D0
		private void SetPoint(Point point)
		{
			if (this.IsButtonDown)
			{
				for (int i = 0; i < 8; i++)
				{
					int j = 0;
					while (j < 8)
					{
						if (this.rects[j, i].Contains(point))
						{
							if (this.IsCtrlKey)
							{
								if (((int)this.datBuff[j] & (128 >> i)) != 0)
								{
									byte[] array = this.datBuff;
									int num = j;
									array[num] &= (byte)(~(byte)(128 >> i));
									this.IsChange = true;
									this.OnPaint();
									break;
								}
								break;
							}
							else
							{
								if (((int)this.datBuff[j] & (128 >> i)) == 0)
								{
									byte[] array2 = this.datBuff;
									int num2 = j;
									array2[num2] |= (byte)(128 >> i);
									this.IsChange = true;
									this.OnPaint();
									break;
								}
								break;
							}
						}
						else
						{
							j++;
						}
					}
				}
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000158C0 File Offset: 0x00013AC0
		private void OnSize()
		{
			base.Size = new Size(this.rects[0, 7].Right + 4, this.rects[0, 0].Bottom + 4);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000158F5 File Offset: 0x00013AF5
		public void OnPaint()
		{
			if (base.Visible)
			{
				this.OnPaint(base.CreateGraphics());
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0001590C File Offset: 0x00013B0C
		private void OnPaint(Graphics g)
		{
			try
			{
				Bitmap bitmap = new Bitmap(base.Size.Width, base.Size.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				graphics.FillRectangle(new SolidBrush(Color.White), rectangle);
				graphics.DrawLine(Pens.Red, 0, this.rects[4, 4].Bottom, base.Size.Width, this.rects[4, 4].Bottom);
				graphics.DrawLine(Pens.Red, this.rects[4, 4].Left, 0, this.rects[4, 4].Left, base.Size.Height);
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (((int)this.datBuff[j] & (128 >> i)) != 0)
						{
							Brush brush = new SolidBrush(this.colortrue);
							graphics.FillEllipse(brush, this.rects[j, i]);
						}
						else
						{
							Brush brush2 = new SolidBrush(this.colorfalse);
							graphics.FillEllipse(brush2, this.rects[j, i]);
						}
					}
				}
				g.DrawImage(bitmap, rectangle);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00015AA4 File Offset: 0x00013CA4
		private void UserControlSingleDZ_Paint(object sender, PaintEventArgs e)
		{
			this.OnPaint(e.Graphics);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00015AB2 File Offset: 0x00013CB2
		private void UserControlSingleDZ_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				this.IsCtrlKey = true;
				if (e.KeyCode == Keys.C)
				{
					this.Copy();
					return;
				}
				if (e.KeyCode == Keys.V)
				{
					this.Paste();
				}
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00015AE4 File Offset: 0x00013CE4
		private void UserControlSingleDZ_KeyUp(object sender, KeyEventArgs e)
		{
			if (!e.Control)
			{
				this.IsCtrlKey = false;
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00015AF5 File Offset: 0x00013CF5
		private void UserControlSingleDZ_Resize(object sender, EventArgs e)
		{
			this.OnSize();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00015B00 File Offset: 0x00013D00
		private void UserControlSingleDZ_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.IsButtonDown = true;
				this.IsChange = false;
				this.SetPoint(e.Location);
				base.Capture = true;
				return;
			}
			if (e.Button == MouseButtons.Right)
			{
				this.m_menu.Show(base.PointToScreen(e.Location));
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00015B60 File Offset: 0x00013D60
		private void UserControlSingleDZ_MouseMove(object sender, MouseEventArgs e)
		{
			this.SetPoint(e.Location);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00015B6E File Offset: 0x00013D6E
		private void UserControlSingleDZ_MouseUp(object sender, MouseEventArgs e)
		{
			this.IsButtonDown = false;
			base.Capture = false;
			if (this.IsChange && this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00015B9C File Offset: 0x00013D9C
		private void Clean()
		{
			for (int i = 0; i < 8; i++)
			{
				this.datBuff[i] = 0;
			}
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00015BD8 File Offset: 0x00013DD8
		private void AllSet()
		{
			for (int i = 0; i < 8; i++)
			{
				this.datBuff[i] = byte.MaxValue;
			}
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00015C18 File Offset: 0x00013E18
		private void AllNot()
		{
			for (int i = 0; i < 8; i++)
			{
				this.datBuff[i] = (byte)~this.datBuff[i];
			}
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00015C5C File Offset: 0x00013E5C
		private void CCWRote90()
		{
			ClassCalc.BufferSingleRote270(this.datBuff);
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00015C82 File Offset: 0x00013E82
		private void CWRote90()
		{
			ClassCalc.BufferSingleRote90(this.datBuff);
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00015CA8 File Offset: 0x00013EA8
		private void Copy()
		{
			Clipboard.SetData(Config.DZElementCopyString, this.datBuff);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00015CBC File Offset: 0x00013EBC
		private void Paste()
		{
			object data = Clipboard.GetData(Config.DZElementCopyString);
			if (data != null)
			{
				byte[] array = (byte[])data;
				for (int i = 0; i < 8; i++)
				{
					this.datBuff[i] = array[i];
				}
				this.OnPaint();
				if (this.m_dataChanged != null)
				{
					this.m_dataChanged();
				}
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00015D0E File Offset: 0x00013F0E
		private void AboutMirror()
		{
			ClassCalc.BufferAboutMirror(this.datBuff);
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00015D34 File Offset: 0x00013F34
		private void UpdownMirror()
		{
			ClassCalc.BufferUpdownMirror(this.datBuff);
			this.OnPaint();
			if (this.m_dataChanged != null)
			{
				this.m_dataChanged();
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00015D5C File Offset: 0x00013F5C
		private void m_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Equals(this.m_menu.Items[0]))
			{
				this.Clean();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[1]))
			{
				this.AllSet();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[2]))
			{
				this.AllNot();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[3]))
			{
				this.Copy();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[4]))
			{
				this.Paste();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[5]))
			{
				this.CWRote90();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[6]))
			{
				this.CCWRote90();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[7]))
			{
				this.AboutMirror();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menu.Items[8]))
			{
				this.UpdownMirror();
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00015EB5 File Offset: 0x000140B5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00015ED4 File Offset: 0x000140D4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Name = "ControlDZElement";
			base.Size = new Size(148, 148);
			base.Paint += this.UserControlSingleDZ_Paint;
			base.MouseMove += this.UserControlSingleDZ_MouseMove;
			base.KeyUp += this.UserControlSingleDZ_KeyUp;
			base.MouseDown += this.UserControlSingleDZ_MouseDown;
			base.Resize += this.UserControlSingleDZ_Resize;
			base.MouseUp += this.UserControlSingleDZ_MouseUp;
			base.KeyDown += this.UserControlSingleDZ_KeyDown;
			base.ResumeLayout(false);
		}

		// Token: 0x04000220 RID: 544
		private ContextMenuStrip m_menu = new ContextMenuStrip();

		// Token: 0x04000221 RID: 545
		private byte[] datBuff = new byte[8];

		// Token: 0x04000222 RID: 546
		private Rectangle[,] rects = new Rectangle[8, 8];

		// Token: 0x04000223 RID: 547
		private readonly Color colorfalse = Color.FromArgb(160, 160, 160);

		// Token: 0x04000224 RID: 548
		private readonly Color colortrue = Color.Red;

		// Token: 0x04000225 RID: 549
		private bool IsCtrlKey;

		// Token: 0x04000226 RID: 550
		private bool IsButtonDown;

		// Token: 0x04000227 RID: 551
		private bool IsChange;

		// Token: 0x04000228 RID: 552
		private IContainer components;

		// Token: 0x0200005B RID: 91
		// (Invoke) Token: 0x06000254 RID: 596
		public delegate void DataChanged();

		// Token: 0x0200005C RID: 92
		// (Invoke) Token: 0x06000258 RID: 600
		public delegate void MouseWheelChangedEvent(int value);
	}
}
