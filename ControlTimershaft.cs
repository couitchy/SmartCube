using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	public class ControlTimershaft : UserControl
	{
		public event ControlTimershaft.SelectElementChanged m_elementChanged;

		public event ControlTimershaft.SelectIndexChanged m_indexChanged;

		private event FormGuan.FileIsChanged m_fileIsChanged;

		public ControlTimershaft()
		{
			this.InitializeComponent();
			this.GetThisSize();
			this.m_menuLeft.Items.Add("Add " + Config.OperationDot);
			this.m_menuLeft.Items.Add("Add " + Config.OperationLine);
			this.m_menuLeft.Items.Add("Add " + Config.OperationPannel);
			this.m_menuLeft.Items.Add("Add " + Config.OperationSolid);
			this.m_menuLeft.Items.Add("Add " + Config.OperationBright);
			this.m_menuLeft.Items.Add("Up");
			this.m_menuLeft.Items.Add("Down");
			this.m_menuLeft.Items.Add("Delete");
			this.m_menuLeft.ItemClicked += this.m_menuLeft_ItemClicked;
			this.m_menuRight.Items.Add("Insert");
			this.m_menuRight.Items.Add("Delete");
			this.m_menuRight.ItemClicked += this.m_menuRight_ItemClicked;
			base.MouseWheel += this.ControlTimershaft_MouseWheel;
		}

		private void ControlTimershaft_MouseWheel(object sender, MouseEventArgs e)
		{
			try
			{
				if ((e.Delta >= 10 || e.Delta < -10) && this.vScrollBar1.Value >= this.vScrollBar1.Minimum && this.vScrollBar1.Value <= this.vScrollBar1.Maximum - this.vScrollBar1.LargeChange + 1)
				{
					int num = this.vScrollBar1.Value - e.Delta / 10;
					if (num < this.vScrollBar1.Minimum)
					{
						num = this.vScrollBar1.Minimum;
					}
					else if (num > this.vScrollBar1.Maximum - this.vScrollBar1.LargeChange + 1)
					{
						num = this.vScrollBar1.Maximum - this.vScrollBar1.LargeChange + 1;
					}
					this.vScrollBar1.Value = num;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void SetEvent(FormGuan.FileIsChanged fileIsChanged)
		{
			this.m_fileIsChanged = fileIsChanged;
		}

		public void SetElement(List<FrameCartoonElement> list)
		{
			this.m_element = null;
			this.m_element = list;
		}

		public void UpdateFrameCount(uint count)
		{
			if (count >= 0U && this.MaxFrameNum != count)
			{
				this.MaxFrameNum = count;
				this.RightTopSelectIndex = -1;
				int count2 = this.m_element.Count;
				for (int i = 0; i < count2; i++)
				{
					int num = this.m_element[i].property.Count;
					for (int j = 0; j < num; j++)
					{
						FrameCartoonProperty frameCartoonProperty = this.m_element[i].property[j];
						if (frameCartoonProperty.lenth == 0)
						{
							this.m_element[i].property.RemoveAt(j);
							j--;
							num--;
						}
						else if ((long)(frameCartoonProperty.startIndex + frameCartoonProperty.lenth) > (long)((ulong)this.MaxFrameNum))
						{
							if ((long)frameCartoonProperty.startIndex >= (long)((ulong)this.MaxFrameNum))
							{
								this.m_element[i].property.RemoveAt(j);
								j--;
								num--;
							}
							else
							{
								frameCartoonProperty.lenth = (int)(this.MaxFrameNum - (uint)frameCartoonProperty.startIndex);
							}
						}
					}
				}
				this.m_selectStatus.m_status = ControlTimershaft.SelectElement.status.nostatus;
				if (this.m_elementChanged != null)
				{
					this.m_elementChanged(FrameCartoonType.dot, null);
				}
				this.UpdateFrame();
			}
		}

		public void UpdateFrame()
		{
			if (base.Visible)
			{
				this.OnPaint();
			}
		}

		private void m_menuRight_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Equals(this.m_menuRight.Items[0]))
			{
				if (this.m_selectRight.eleNum < this.m_element.Count)
				{
					FrameCartoonProperty frameCartoonProperty;
					switch (this.m_element[this.m_selectRight.eleNum].m_type)
					{
					case FrameCartoonType.dot:
						frameCartoonProperty = new PropertyElementDot();
						break;
					case FrameCartoonType.line:
						frameCartoonProperty = new PropertyElementLine();
						break;
					case FrameCartoonType.pannel:
						frameCartoonProperty = new PropertyElementPannel();
						break;
					case FrameCartoonType.solid:
						frameCartoonProperty = new PropertyElementSolid();
						break;
					case FrameCartoonType.bright:
						frameCartoonProperty = new PropertyElementBright();
						break;
					default:
						return;
					}
					frameCartoonProperty.lenth = 1;
					frameCartoonProperty.startIndex = this.m_selectRight.index;
					this.m_element[this.m_selectRight.eleNum].property.Insert(this.m_selectRight.proNum, frameCartoonProperty);
					if (this.m_selectStatus.m_status == ControlTimershaft.SelectElement.status.select && this.m_selectStatus.eleNum == this.m_selectRight.eleNum && this.m_selectStatus.proNum >= this.m_selectRight.proNum)
					{
						this.m_selectStatus.proNum = this.m_selectStatus.proNum + 1;
					}
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
					this.OnPaint();
					return;
				}
			}
			else if (e.ClickedItem.Equals(this.m_menuRight.Items[1]) && this.m_selectRight.eleNum < this.m_element.Count && this.m_selectRight.proNum < this.m_element[this.m_selectRight.eleNum].property.Count)
			{
				this.m_element[this.m_selectRight.eleNum].property.RemoveAt(this.m_selectRight.proNum);
				if (this.m_selectStatus.m_status == ControlTimershaft.SelectElement.status.select && this.m_selectStatus.eleNum == this.m_selectRight.eleNum && this.m_selectStatus.proNum == this.m_selectRight.proNum)
				{
					this.m_selectRight.m_status = ControlTimershaft.SelectElement.status.nostatus;
				}
				this.m_selectStatus.m_status = ControlTimershaft.SelectElement.status.nostatus;
				if (this.m_elementChanged != null)
				{
					this.m_elementChanged(FrameCartoonType.dot, null);
				}
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
			}
		}

		private void m_menuLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Equals(this.m_menuLeft.Items[0]))
			{
				FrameCartoonElement frameCartoonElement = new FrameCartoonElement();
				frameCartoonElement.m_type = FrameCartoonType.dot;
				frameCartoonElement.name = Config.OperationDot;
				this.m_element.Add(frameCartoonElement);
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menuLeft.Items[1]))
			{
				FrameCartoonElement frameCartoonElement2 = new FrameCartoonElement();
				frameCartoonElement2.m_type = FrameCartoonType.line;
				frameCartoonElement2.name = Config.OperationLine;
				this.m_element.Add(frameCartoonElement2);
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menuLeft.Items[2]))
			{
				FrameCartoonElement frameCartoonElement3 = new FrameCartoonElement();
				frameCartoonElement3.m_type = FrameCartoonType.pannel;
				frameCartoonElement3.name = Config.OperationPannel;
				this.m_element.Add(frameCartoonElement3);
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menuLeft.Items[3]))
			{
				FrameCartoonElement frameCartoonElement4 = new FrameCartoonElement();
				frameCartoonElement4.m_type = FrameCartoonType.solid;
				frameCartoonElement4.name = Config.OperationSolid;
				this.m_element.Add(frameCartoonElement4);
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menuLeft.Items[4]))
			{
				foreach (FrameCartoonElement frameCartoonElement5 in this.m_element)
				{
					if (frameCartoonElement5.m_type == FrameCartoonType.bright)
					{
						return;
					}
				}
				FrameCartoonElement frameCartoonElement6 = new FrameCartoonElement();
				frameCartoonElement6.m_type = FrameCartoonType.bright;
				frameCartoonElement6.name = Config.OperationBright;
				this.m_element.Add(frameCartoonElement6);
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
				return;
			}
			if (e.ClickedItem.Equals(this.m_menuLeft.Items[5]))
			{
				if (this.LeftSelectIndex != -1 && this.LeftSelectIndex != 0)
				{
					FrameCartoonElement frameCartoonElement7 = this.m_element[this.LeftSelectIndex];
					this.m_element.RemoveAt(this.LeftSelectIndex);
					this.LeftSelectIndex--;
					this.m_element.Insert(this.LeftSelectIndex, frameCartoonElement7);
					this.m_selectStatus.m_status = ControlTimershaft.SelectElement.status.nostatus;
					if (this.m_elementChanged != null)
					{
						this.m_elementChanged(FrameCartoonType.dot, null);
					}
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
					this.OnPaint();
					return;
				}
			}
			else if (e.ClickedItem.Equals(this.m_menuLeft.Items[6]))
			{
				if (this.LeftSelectIndex != -1 && this.LeftSelectIndex != this.m_element.Count - 1)
				{
					FrameCartoonElement frameCartoonElement8 = this.m_element[this.LeftSelectIndex];
					this.m_element.RemoveAt(this.LeftSelectIndex);
					this.LeftSelectIndex++;
					this.m_element.Insert(this.LeftSelectIndex, frameCartoonElement8);
					this.m_selectStatus.m_status = ControlTimershaft.SelectElement.status.nostatus;
					if (this.m_elementChanged != null)
					{
						this.m_elementChanged(FrameCartoonType.dot, null);
					}
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
					this.OnPaint();
					return;
				}
			}
			else if (e.ClickedItem.Equals(this.m_menuLeft.Items[7]) && this.LeftSelectIndex != -1 && this.m_element.Count > this.LeftSelectIndex)
			{
				this.m_element.RemoveAt(this.LeftSelectIndex);
				this.LeftSelectIndex = -1;
				this.m_selectStatus.m_status = ControlTimershaft.SelectElement.status.nostatus;
				if (this.m_elementChanged != null)
				{
					this.m_elementChanged(FrameCartoonType.dot, null);
				}
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
				this.OnPaint();
			}
		}

		private int GetRightCenter(int index)
		{
			return this.LeftLinePosition + 8 * index;
		}

		private int GetLeftTextTop(int index)
		{
			return 20 + index * 20;
		}

		private Rectangle GetLeftTextRect(int index, int width)
		{
			return new Rectangle
			{
				X = 0,
				Y = this.GetLeftTextTop(index),
				Width = width + 1,
				Height = 20
			};
		}

		private Size GetMaxSize()
		{
			Size size = default(Size);
			this.startY = 0;
			size.Width = (int)((long)this.LeftLinePosition + (long)((ulong)(this.MaxFrameNum * 8U)) + 25L);
			size.Height = this.GetLeftTextTop(this.m_element.Count);
			return size;
		}

		private void UpdateScrollBar(Size size)
		{
			if (this.ThisSize.Width >= size.Width)
			{
				this.hScrollBar1.Enabled = false;
				this.hScrollBar1.Value = 0;
			}
			else
			{
				this.hScrollBar1.Enabled = true;
				this.hScrollBar1.Maximum = size.Width;
				this.hScrollBar1.LargeChange = this.ThisSize.Width;
			}
			if (this.ThisSize.Height >= size.Height)
			{
				this.vScrollBar1.Enabled = false;
				this.vScrollBar1.Value = 0;
			}
			else
			{
				this.vScrollBar1.Enabled = true;
				this.vScrollBar1.Maximum = size.Height;
				this.vScrollBar1.LargeChange = this.ThisSize.Height;
			}
			this.startX = this.hScrollBar1.Value;
			this.startY = this.vScrollBar1.Value;
		}

		private void GetThisSize()
		{
			this.ThisSize = base.Size;
			this.ThisSize.Width = this.ThisSize.Width - this.vScrollBar1.Width;
			this.ThisSize.Height = this.ThisSize.Height - this.hScrollBar1.Height;
		}

		private void OnPaint()
		{
			Graphics graphics = base.CreateGraphics();
			PaintEventArgs paintEventArgs = new PaintEventArgs(graphics, default(Rectangle));
			this.ControlTimershaft_Paint(this, paintEventArgs);
		}

		private void ControlTimershaft_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				this.GetThisSize();
				Size maxSize = this.GetMaxSize();
				if (maxSize.Width > 0 && maxSize.Height > 0 && this.ThisSize.Width > 0 && this.ThisSize.Height > 0)
				{
					this.UpdateScrollBar(maxSize);
					Graphics graphics = e.Graphics;
					Bitmap bitmap = new Bitmap(this.ThisSize.Width, this.ThisSize.Height);
					Graphics graphics2 = Graphics.FromImage(bitmap);
					StringFormat stringFormat = new StringFormat();
					stringFormat.Alignment = StringAlignment.Center;
					graphics2.FillRectangle(Brushes.White, new Rectangle(-this.startX, -this.startY, this.LeftLinePosition, this.ThisSize.Height + this.startY));
					int count = this.m_element.Count;
					for (int i = 0; i < count; i++)
					{
						Rectangle leftTextRect = this.GetLeftTextRect(i, (int)graphics.MeasureString(this.m_element[i].name, this.m_font).Width);
						leftTextRect.X -= this.startX;
						leftTextRect.Y -= this.startY;
						if (i == this.LeftSelectIndex)
						{
							graphics2.FillRectangle(Brushes.Green, leftTextRect);
						}
						graphics2.DrawString(this.m_element[i].name, this.m_font, Brushes.Black, leftTextRect, stringFormat);
					}
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(this.LeftLinePosition - this.startX, -this.startY, this.ThisSize.Width - this.LeftLinePosition + this.startX, this.ThisSize.Height + this.startY));
					for (int j = 0; j < count; j++)
					{
						int num = this.GetLeftTextTop(j + 1) - this.startY;
						graphics2.DrawLine(Pens.Black, this.LeftLinePosition - this.startX, num, this.ThisSize.Width + this.startX, num);
						int count2 = this.m_element[j].property.Count;
						for (int k = 0; k < count2; k++)
						{
							FrameCartoonProperty frameCartoonProperty = this.m_element[j].property[k];
							Rectangle rectangle = new Rectangle(frameCartoonProperty.startIndex * 8 + this.LeftLinePosition - this.startX, this.GetLeftTextTop(j) - this.startY, frameCartoonProperty.lenth * 8, 20);
							if (this.m_selectStatus.m_status == ControlTimershaft.SelectElement.status.select && this.m_selectStatus.eleNum == j && this.m_selectStatus.proNum == k)
							{
								graphics2.FillRectangle(Brushes.DarkGoldenrod, rectangle);
							}
							else
							{
								graphics2.FillRectangle(Brushes.Yellow, rectangle);
							}
							graphics2.DrawRectangle(Pens.DarkGreen, rectangle);
						}
					}
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(220, 220, 220)), new Rectangle(0, 0, this.ThisSize.Width, 20));
					if (this.RightTopSelectIndex >= 0)
					{
						Rectangle rightRect = this.GetRightRect(this.RightTopSelectIndex);
						rightRect.X -= this.startX;
						rightRect.Y -= this.startY;
						graphics2.FillRectangle(Brushes.Red, rightRect);
						int num2 = rightRect.Left + rightRect.Width / 2;
						graphics2.DrawLine(Pens.Red, new Point(num2, 0), new Point(num2, this.ThisSize.Height));
					}
					graphics2.DrawString("Operation", this.m_font, Brushes.Black, new Rectangle(-this.startX, 0, 50, 20), stringFormat);
					graphics2.DrawLine(Pens.Black, this.LeftLinePosition - this.startX, 20, this.ThisSize.Width, 20);
					int num3 = 1;
					while ((long)num3 <= (long)((ulong)this.MaxFrameNum))
					{
						int num4 = this.GetRightCenter(num3) - this.startX;
						if (num3 % 10 == 0)
						{
							graphics2.DrawLine(Pens.Black, num4, 14, num4, 20);
							SizeF sizeF = graphics.MeasureString(num3.ToString(), this.m_fontNum);
							Rectangle rectangle2 = new Rectangle(num4 - (int)sizeF.Width / 2, 0, (int)sizeF.Width + 1, 14);
							graphics2.DrawString(num3.ToString(), this.m_fontNum, Brushes.Black, rectangle2, stringFormat);
						}
						else if (num3 % 5 == 0)
						{
							graphics2.DrawLine(Pens.Black, num4, 16, num4, 20);
						}
						else
						{
							graphics2.DrawLine(Pens.Black, num4, 18, num4, 20);
						}
						num3++;
					}
					if (this.m_movingStatus != ControlTimershaft.MovingStatus.Split)
					{
						graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200)), 4f), this.LeftLinePosition - this.startX, -this.startY, this.LeftLinePosition - this.startX, this.ThisSize.Height + this.startY);
					}
					else
					{
						graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150)), 4f), this.LeftLinePosition - this.startX, -this.startY, this.LeftLinePosition - this.startX, this.ThisSize.Height + this.startY);
					}
					graphics.DrawImage(bitmap, new Point(0, 0));
					graphics2.Dispose();
					graphics.Dispose();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private int GetRightIndex(Point point)
		{
			int num = 0;
			while ((long)num <= (long)((ulong)this.MaxFrameNum))
			{
				int num2 = num * 8 + this.LeftLinePosition;
				if (point.X >= num2 - 4 && point.X <= num2 + 4)
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		private ControlTimershaft.MovingStatus PointToStatus(Point point)
		{
			if (point.X >= this.LeftLinePosition - 3 && point.X <= this.LeftLinePosition + 3)
			{
				return ControlTimershaft.MovingStatus.Split;
			}
			if (point.Y <= 20 + this.startY)
			{
				int num = 0;
				while ((long)num < (long)((ulong)this.MaxFrameNum))
				{
					if (this.GetRightRect(num).Contains(point))
					{
						this.RightTopSelectBuff = num;
						return ControlTimershaft.MovingStatus.RightTop;
					}
					num++;
				}
			}
			else
			{
				int count = this.m_element.Count;
				for (int i = 0; i < count; i++)
				{
					if (point.Y > this.GetLeftTextTop(i) && point.Y < this.GetLeftTextTop(i + 1))
					{
						this.m_selectBuff.eleNum = i;
						int count2 = this.m_element[i].property.Count;
						for (int j = 0; j < count2; j++)
						{
							this.m_selectBuff.proNum = j;
							FrameCartoonProperty frameCartoonProperty = this.m_element[i].property[j];
							if (frameCartoonProperty.lenth > 0)
							{
								int num2 = frameCartoonProperty.startIndex * 8 + this.LeftLinePosition;
								if (point.X >= num2 && point.X <= num2 + 3)
								{
									this.m_selectBuff.m_status = ControlTimershaft.SelectElement.status.left;
									return ControlTimershaft.MovingStatus.SizeChange;
								}
								int num3 = num2 + frameCartoonProperty.lenth * 8;
								if (point.X >= num3 - 3 && point.X <= num3)
								{
									this.m_selectBuff.m_status = ControlTimershaft.SelectElement.status.right;
									return ControlTimershaft.MovingStatus.SizeChange;
								}
								if (point.X > num2 && point.X < num3)
								{
									this.m_selectBuff.m_status = ControlTimershaft.SelectElement.status.select;
									this.m_selectBuff.index = this.GetRightIndex(point) - frameCartoonProperty.startIndex;
									return ControlTimershaft.MovingStatus.PositionChange;
								}
							}
						}
						break;
					}
				}
			}
			return ControlTimershaft.MovingStatus.NoMoving;
		}

		private int LeftSelect(Point point)
		{
			if (point.Y > this.startY)
			{
				Graphics graphics = base.CreateGraphics();
				int count = this.m_element.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.GetLeftTextRect(i, (int)graphics.MeasureString(this.m_element[i].name, this.m_font).Width).Contains(point))
					{
						return i;
					}
				}
			}
			return -1;
		}

		private int GetElementMax(int index1, int index2)
		{
			if (this.m_element.Count <= index1 || this.m_element[index1].property.Count <= index2)
			{
				return -1;
			}
			FrameCartoonProperty frameCartoonProperty = this.m_element[index1].property[index2];
			if (index2 == this.m_element[index1].property.Count - 1)
			{
				return (int)this.MaxFrameNum;
			}
			return this.m_element[index1].property[index2 + 1].startIndex;
		}

		private int GetElementMin(int index1, int index2)
		{
			if (this.m_element.Count <= index1 || this.m_element[index1].property.Count <= index2)
			{
				return 65535;
			}
			FrameCartoonProperty frameCartoonProperty = this.m_element[index1].property[index2];
			if (index2 == 0)
			{
				return 0;
			}
			return this.m_element[index1].property[index2 - 1].startIndex + this.m_element[index1].property[index2 - 1].lenth;
		}

		private Rectangle GetRightRect(int index)
		{
			return new Rectangle
			{
				X = this.LeftLinePosition + 8 * index + 1,
				Width = 7,
				Y = 0,
				Height = 20 + this.startY
			};
		}

		private void ControlTimershaft_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			location.X += this.startX;
			location.Y += this.startY;
			if (this.m_movingStatus != ControlTimershaft.MovingStatus.NoMoving)
			{
				if (this.m_movingStatus == ControlTimershaft.MovingStatus.Split)
				{
					if (location.X >= 50 && location.X <= 250)
					{
						this.LeftLinePosition = location.X;
						this.OnPaint();
						return;
					}
				}
				else if (this.m_movingStatus == ControlTimershaft.MovingStatus.SizeChange)
				{
					int rightIndex = this.GetRightIndex(location);
					if (rightIndex != -1 && this.m_element.Count > this.m_selectBuff.eleNum && this.m_element[this.m_selectBuff.eleNum].property.Count > this.m_selectBuff.proNum)
					{
						FrameCartoonProperty frameCartoonProperty = this.m_element[this.m_selectBuff.eleNum].property[this.m_selectBuff.proNum];
						if (this.m_selectBuff.m_status == ControlTimershaft.SelectElement.status.left)
						{
							if (rightIndex < frameCartoonProperty.startIndex)
							{
								if (rightIndex >= this.GetElementMin(this.m_selectBuff.eleNum, this.m_selectBuff.proNum))
								{
									frameCartoonProperty.lenth += frameCartoonProperty.startIndex - rightIndex;
									frameCartoonProperty.startIndex = rightIndex;
									if (this.m_fileIsChanged != null)
									{
										this.m_fileIsChanged(true);
									}
									this.OnPaint();
									return;
								}
							}
							else if (rightIndex > frameCartoonProperty.startIndex)
							{
								int num = rightIndex - frameCartoonProperty.startIndex;
								if (frameCartoonProperty.lenth > num)
								{
									frameCartoonProperty.startIndex = rightIndex;
									frameCartoonProperty.lenth -= num;
									if (this.m_fileIsChanged != null)
									{
										this.m_fileIsChanged(true);
									}
									this.OnPaint();
									return;
								}
							}
						}
						else if (this.m_selectBuff.m_status == ControlTimershaft.SelectElement.status.right)
						{
							if (rightIndex > frameCartoonProperty.startIndex + frameCartoonProperty.lenth)
							{
								if (rightIndex <= this.GetElementMax(this.m_selectBuff.eleNum, this.m_selectBuff.proNum))
								{
									frameCartoonProperty.lenth = rightIndex - frameCartoonProperty.startIndex;
									if (this.m_fileIsChanged != null)
									{
										this.m_fileIsChanged(true);
									}
									this.OnPaint();
									return;
								}
							}
							else if (rightIndex < frameCartoonProperty.startIndex + frameCartoonProperty.lenth)
							{
								int num2 = rightIndex - frameCartoonProperty.startIndex;
								if (num2 > 0)
								{
									frameCartoonProperty.lenth = num2;
									if (this.m_fileIsChanged != null)
									{
										this.m_fileIsChanged(true);
									}
									this.OnPaint();
									return;
								}
							}
						}
					}
				}
				else if (this.m_movingStatus == ControlTimershaft.MovingStatus.PositionChange)
				{
					int rightIndex2 = this.GetRightIndex(location);
					if (rightIndex2 != -1)
					{
						int num3 = rightIndex2 - this.m_selectBuff.index;
						if (num3 >= 0 && this.m_element.Count > this.m_selectBuff.eleNum && this.m_element[this.m_selectBuff.eleNum].property.Count > this.m_selectBuff.proNum)
						{
							FrameCartoonProperty frameCartoonProperty2 = this.m_element[this.m_selectBuff.eleNum].property[this.m_selectBuff.proNum];
							if (this.m_selectBuff.m_status == ControlTimershaft.SelectElement.status.select && num3 != frameCartoonProperty2.startIndex && num3 + frameCartoonProperty2.lenth <= this.GetElementMax(this.m_selectBuff.eleNum, this.m_selectBuff.proNum) && num3 >= this.GetElementMin(this.m_selectBuff.eleNum, this.m_selectBuff.proNum))
							{
								frameCartoonProperty2.startIndex = num3;
								if (this.m_fileIsChanged != null)
								{
									this.m_fileIsChanged(true);
								}
								this.OnPaint();
								return;
							}
						}
					}
				}
				else if (this.m_movingStatus == ControlTimershaft.MovingStatus.RightTop)
				{
					int num4 = 0;
					while ((long)num4 < (long)((ulong)this.MaxFrameNum))
					{
						if (this.GetRightRect(num4).Contains(location))
						{
							this.RightTopSelectIndex = num4;
							this.OnPaint();
							if (this.m_indexChanged != null)
							{
								this.m_indexChanged(this.RightTopSelectIndex);
							}
						}
						num4++;
					}
				}
				return;
			}
			ControlTimershaft.MovingStatus movingStatus = this.PointToStatus(location);
			if (movingStatus == ControlTimershaft.MovingStatus.Split || movingStatus == ControlTimershaft.MovingStatus.SizeChange)
			{
				this.Cursor = Cursors.SizeWE;
				return;
			}
			if (movingStatus == ControlTimershaft.MovingStatus.PositionChange)
			{
				this.Cursor = Cursors.VSplit;
				return;
			}
			this.Cursor = Cursors.Default;
		}

		private bool IsInList(Point point)
		{
			if (point.X > this.LeftLinePosition && point.Y > 20 + this.startY)
			{
				int count = this.m_element.Count;
				int maxFrameNum = (int)this.MaxFrameNum;
				if (point.Y < this.GetLeftTextTop(count) && point.X < this.GetRightCenter(maxFrameNum))
				{
					for (int i = 0; i < count; i++)
					{
						if (point.Y < this.GetLeftTextTop(i + 1))
						{
							int num = (point.X - this.LeftLinePosition) / 8;
							int count2 = this.m_element[i].property.Count;
							for (int j = 0; j < count2; j++)
							{
								FrameCartoonProperty frameCartoonProperty = this.m_element[i].property[j];
								if (num >= frameCartoonProperty.startIndex && num < frameCartoonProperty.startIndex + frameCartoonProperty.lenth)
								{
									this.m_selectRight.eleNum = i;
									this.m_selectRight.proNum = j;
									this.m_selectRight.m_status = ControlTimershaft.SelectElement.status.select;
									return true;
								}
							}
							this.m_selectRight.eleNum = i;
							this.m_selectRight.index = num;
							this.m_selectRight.m_status = ControlTimershaft.SelectElement.status.nostatus;
							for (int k = 0; k < count2; k++)
							{
								FrameCartoonProperty frameCartoonProperty2 = this.m_element[i].property[k];
								if (num < frameCartoonProperty2.startIndex)
								{
									this.m_selectRight.proNum = k;
									return true;
								}
							}
							this.m_selectRight.proNum = count2;
							return true;
						}
					}
				}
			}
			return false;
		}

		private void ControlTimershaft_MouseDown(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			location.X += this.startX;
			location.Y += this.startY;
			base.Focus();
			if (e.Button == MouseButtons.Left)
			{
				this.m_movingStatus = this.PointToStatus(location);
				if (this.m_movingStatus == ControlTimershaft.MovingStatus.NoMoving)
				{
					int num = this.LeftSelect(location);
					if (num != -1)
					{
						this.LeftSelectIndex = num;
						this.OnPaint();
						return;
					}
				}
				else
				{
					if (this.m_movingStatus == ControlTimershaft.MovingStatus.Split)
					{
						this.OnPaint();
						return;
					}
					if (this.m_movingStatus == ControlTimershaft.MovingStatus.RightTop)
					{
						this.RightTopSelectIndex = this.RightTopSelectBuff;
						this.OnPaint();
						if (this.m_indexChanged != null)
						{
							this.m_indexChanged(this.RightTopSelectIndex);
							return;
						}
					}
					else if (this.m_movingStatus == ControlTimershaft.MovingStatus.SizeChange || this.m_movingStatus == ControlTimershaft.MovingStatus.PositionChange)
					{
						this.m_selectStatus = this.m_selectBuff;
						this.m_selectStatus.m_status = ControlTimershaft.SelectElement.status.select;
						this.OnPaint();
						if (this.m_elementChanged != null)
						{
							this.m_elementChanged(this.m_element[this.m_selectStatus.eleNum].m_type, this.m_element[this.m_selectStatus.eleNum].property[this.m_selectStatus.proNum]);
							return;
						}
					}
				}
			}
			else if (e.Button == MouseButtons.Right && this.m_movingStatus == ControlTimershaft.MovingStatus.NoMoving)
			{
				if (location.X < this.LeftLinePosition && location.Y > 20 + this.startY)
				{
					int num2 = this.LeftSelect(location);
					if (num2 != -1)
					{
						this.LeftSelectIndex = num2;
						this.OnPaint();
					}
					if (this.LeftSelectIndex != -1)
					{
						this.m_menuLeft.Items[5].Enabled = true;
						this.m_menuLeft.Items[6].Enabled = true;
						this.m_menuLeft.Items[7].Enabled = true;
					}
					else
					{
						this.m_menuLeft.Items[5].Enabled = false;
						this.m_menuLeft.Items[6].Enabled = false;
						this.m_menuLeft.Items[7].Enabled = false;
					}
					this.m_menuLeft.Show(base.PointToScreen(e.Location));
					return;
				}
				if (this.IsInList(location))
				{
					if (this.m_selectRight.m_status == ControlTimershaft.SelectElement.status.select)
					{
						this.m_menuRight.Items[0].Enabled = false;
						this.m_menuRight.Items[1].Enabled = true;
						this.m_menuRight.Show(base.PointToScreen(e.Location));
						return;
					}
					if (this.m_selectRight.m_status == ControlTimershaft.SelectElement.status.nostatus)
					{
						this.m_menuRight.Items[0].Enabled = true;
						this.m_menuRight.Items[1].Enabled = false;
						this.m_menuRight.Show(base.PointToScreen(e.Location));
					}
				}
			}
		}

		private void ControlTimershaft_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.m_movingStatus != ControlTimershaft.MovingStatus.NoMoving || this.LeftSelectIndex != -1)
				{
					this.OnPaint();
				}
				this.m_movingStatus = ControlTimershaft.MovingStatus.NoMoving;
			}
		}

		private void hScrollBar1_ValueChanged(object sender, EventArgs e)
		{
			if (this.hScrollBar1.Enabled)
			{
				this.OnPaint();
			}
		}

		private void vScrollBar1_ValueChanged(object sender, EventArgs e)
		{
			if (this.vScrollBar1.Enabled)
			{
				this.OnPaint();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.hScrollBar1 = new HScrollBar();
			this.vScrollBar1 = new VScrollBar();
			base.SuspendLayout();
			this.hScrollBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.hScrollBar1.Enabled = false;
			this.hScrollBar1.LargeChange = 1;
			this.hScrollBar1.Location = new Point(0, 130);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new Size(430, 20);
			this.hScrollBar1.TabIndex = 0;
			this.hScrollBar1.ValueChanged += this.hScrollBar1_ValueChanged;
			this.vScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			this.vScrollBar1.Enabled = false;
			this.vScrollBar1.Location = new Point(430, 0);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new Size(20, 130);
			this.vScrollBar1.TabIndex = 1;
			this.vScrollBar1.ValueChanged += this.vScrollBar1_ValueChanged;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Controls.Add(this.vScrollBar1);
			base.Controls.Add(this.hScrollBar1);
			this.Cursor = Cursors.Default;
			base.Name = "ControlTimershaft";
			base.Size = new Size(450, 150);
			base.Paint += this.ControlTimershaft_Paint;
			base.MouseMove += this.ControlTimershaft_MouseMove;
			base.MouseDown += this.ControlTimershaft_MouseDown;
			base.MouseUp += this.ControlTimershaft_MouseUp;
			base.ResumeLayout(false);
		}

		private const int MinLeftLine = 50;

		private const int MaxLeftLine = 250;

		private const int TopLinePosition = 20;

		private const int FrameSpacing = 8;

		private ControlTimershaft.MovingStatus m_movingStatus;

		private ControlTimershaft.SelectElement m_selectBuff = default(ControlTimershaft.SelectElement);

		private ControlTimershaft.SelectElement m_selectStatus = default(ControlTimershaft.SelectElement);

		private ControlTimershaft.SelectElement m_selectRight = default(ControlTimershaft.SelectElement);

		private List<FrameCartoonElement> m_element = new List<FrameCartoonElement>();

		private Size ThisSize = default(Size);

		private int LeftLinePosition = 100;

		private int startX;

		private int startY;

		private int LeftSelectIndex = -1;

		private int RightTopSelectIndex = -1;

		private int RightTopSelectBuff = -1;

		private uint MaxFrameNum;

		private Font m_font = new Font("Arial", 12f, FontStyle.Regular);

		private Font m_fontNum = new Font("Arial", 9f, FontStyle.Regular);

		private ContextMenuStrip m_menuLeft = new ContextMenuStrip();

		private ContextMenuStrip m_menuRight = new ContextMenuStrip();

		private IContainer components;

		private HScrollBar hScrollBar1;

		private VScrollBar vScrollBar1;

		public delegate void SelectElementChanged(FrameCartoonType type, FrameCartoonProperty obj);

		public delegate void SelectIndexChanged(int index);

		private enum MovingStatus
		{
			NoMoving,
			Split,
			SizeChange,
			PositionChange,
			RightTop
		}

		private struct SelectElement
		{
			public int eleNum;

			public int proNum;

			public int index;

			public ControlTimershaft.SelectElement.status m_status;

			public enum status
			{
				nostatus,
				select,
				left,
				right
			}
		}
	}
}
