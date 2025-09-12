using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlDZElement : UserControl
    {
        public event ControlDZElement.DataChanged m_dataChanged;

        public event ControlDZElement.MouseWheelChangedEvent m_wheel;

        public void ShowControl(byte[] buff8)
        {
            this.datBuff = null;
            this.datBuff = buff8;
            this.OnPaint();
            base.Visible = true;
        }

        public void HideControl()
        {
            base.Visible = false;
        }

        public ControlDZElement()
        {
            this.InitializeComponent();
            this.InitLeds();
            this.m_menu.Items.Add("Clear");
            this.m_menu.Items.Add("Display all");
            this.m_menu.Items.Add("Display inverse");
            this.m_menu.Items.Add("Copy (Ctrl+C)");
            this.m_menu.Items.Add("Paste (Ctrl+V)");
            this.m_menu.Items.Add("Clockwise rotation");
            this.m_menu.Items.Add("Anticlockwise rotation");
            this.m_menu.Items.Add("Left/right mirror");
            this.m_menu.Items.Add("Up/down mirror");
            this.m_menu.ItemClicked += this.m_menu_ItemClicked;
            base.MouseWheel += this.ControlDZElement_MouseWheel;
            this.HideControl();
            base.MouseHover += this.ControlDZElement_MouseHover;
        }

        private void ControlDZElement_MouseHover(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                base.Focus();
            }
        }

        private void ControlDZElement_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && this.m_wheel != null)
            {
                this.m_wheel(e.Delta);
            }
        }

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

        private void OnSize()
        {
            base.Size = new Size(this.rects[0, 7].Right + 4, this.rects[0, 0].Bottom + 4);
        }

        public void OnPaint()
        {
            if (base.Visible)
            {
                this.OnPaint(base.CreateGraphics());
            }
        }

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

        private void UserControlSingleDZ_Paint(object sender, PaintEventArgs e)
        {
            this.OnPaint(e.Graphics);
        }

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

        private void UserControlSingleDZ_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                this.IsCtrlKey = false;
            }
        }

        private void UserControlSingleDZ_Resize(object sender, EventArgs e)
        {
            this.OnSize();
        }

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

        private void UserControlSingleDZ_MouseMove(object sender, MouseEventArgs e)
        {
            this.SetPoint(e.Location);
        }

        private void UserControlSingleDZ_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsButtonDown = false;
            base.Capture = false;
            if (this.IsChange && this.m_dataChanged != null)
            {
                this.m_dataChanged();
            }
        }

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

        private void CCWRote90()
        {
            ClassCalc.BufferSingleRote270(this.datBuff);
            this.OnPaint();
            if (this.m_dataChanged != null)
            {
                this.m_dataChanged();
            }
        }

        private void CWRote90()
        {
            ClassCalc.BufferSingleRote90(this.datBuff);
            this.OnPaint();
            if (this.m_dataChanged != null)
            {
                this.m_dataChanged();
            }
        }

        private void Copy()
        {
            Clipboard.SetData(Config.DZElementCopyString, this.datBuff);
        }

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

        private void LeftRightMirror()
        {
            ClassCalc.BufferLeftRightMirror(this.datBuff);
            this.OnPaint();
            if (this.m_dataChanged != null)
            {
                this.m_dataChanged();
            }
        }

        private void UpDownMirror()
        {
            ClassCalc.BufferUpDownMirror(this.datBuff);
            this.OnPaint();
            if (this.m_dataChanged != null)
            {
                this.m_dataChanged();
            }
        }

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
                this.LeftRightMirror();
                return;
            }
            if (e.ClickedItem.Equals(this.m_menu.Items[8]))
            {
                this.UpDownMirror();
            }
        }

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

        private ContextMenuStrip m_menu = new ContextMenuStrip();

        private byte[] datBuff = new byte[8];

        private Rectangle[,] rects = new Rectangle[8, 8];

        private readonly Color colorfalse = Color.FromArgb(160, 160, 160);

        private readonly Color colortrue = Color.Red;

        private bool IsCtrlKey;

        private bool IsButtonDown;

        private bool IsChange;

        public delegate void DataChanged();

        public delegate void MouseWheelChangedEvent(int value);
    }
}
