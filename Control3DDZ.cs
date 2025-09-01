using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class Control3DDZ : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public Control3DDZ(DX9 dx, ControlEdit parent, ControlEdit.ListClass list, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.m_dx = dx;
            this.m_parent = parent;
            this.m_list = list;
            this.m_fileIsChanged = fileIsChanged;
            base.Paint += this.Control3DDZ_Paint;
            this.HideControl();
        }

        private void Control3DDZ_Paint(object sender, PaintEventArgs e)
        {
            this.UpdateDX();
        }

        public void ShowControl(ResourceSolid res)
        {
            this.m_res = res;
            this.datBuff64 = this.m_res.buff;
            ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffFront, this.frontIndex, FrameView.front);
            ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffTop, this.topIndex, FrameView.top);
            ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffLeft, this.leftIndex, FrameView.left);
            this.m_dzFront.ShowControl(this.datBuffFront);
            this.m_dzTop.ShowControl(this.datBuffTop);
            this.m_dzLeft.ShowControl(this.datBuffLeft);
            this.m_dzFront.m_dataChanged += this.m_dzFont_m_dataChanged;
            this.m_dzTop.m_dataChanged += this.m_dzTop_m_dataChanged;
            this.m_dzLeft.m_dataChanged += this.m_dzLeft_m_dataChanged;
            this.m_dzFront.m_wheel += this.m_dzFont_m_wheel;
            this.m_dzTop.m_wheel += this.m_dzTop_m_wheel;
            this.m_dzLeft.m_wheel += this.m_dzLeft_m_wheel;
            base.Visible = true;
        }

        public void UpdateDX()
        {
            ClassCalc.Buffer3DToDX(this.datBuff64, this.m_dx);
            this.m_dx.SetBright(100);
            this.m_dx.OnPaint();
        }

        private void m_dzFont_m_wheel(int value)
        {
            int num = this.vScrollBarFront.Value - value / 100;
            if (num < 0)
            {
                num = 0;
            }
            else if (num > 7)
            {
                num = 7;
            }
            this.vScrollBarFront.Value = num;
        }

        private void m_dzLeft_m_wheel(int value)
        {
            int num = this.vScrollBarLeft.Value - value / 100;
            if (num < 0)
            {
                num = 0;
            }
            else if (num > 7)
            {
                num = 7;
            }
            this.vScrollBarLeft.Value = num;
        }

        private void m_dzTop_m_wheel(int value)
        {
            int num = this.vScrollBarTop.Value - value / 100;
            if (num < 0)
            {
                num = 0;
            }
            else if (num > 7)
            {
                num = 7;
            }
            this.vScrollBarTop.Value = num;
        }

        private void m_dzLeft_m_dataChanged()
        {
            ClassCalc.BufferSingleToBuffer3D(this.datBuff64, this.datBuffLeft, this.leftIndex, FrameView.left);
            ClassCalc.BufferSingleToDX(this.datBuffLeft, this.m_dx, this.leftIndex, FrameView.left, PaintMode.Copy);
            this.UpdateTop();
            this.UpdateFont();
            this.m_dx.OnPaint();
            if (this.m_fileIsChanged != null)
            {
                this.m_fileIsChanged(true);
            }
        }

        private void m_dzTop_m_dataChanged()
        {
            ClassCalc.BufferSingleToBuffer3D(this.datBuff64, this.datBuffTop, this.topIndex, FrameView.top);
            ClassCalc.BufferSingleToDX(this.datBuffTop, this.m_dx, this.topIndex, FrameView.top, PaintMode.Copy);
            this.UpdateFont();
            this.UpdateLeft();
            this.m_dx.OnPaint();
            if (this.m_fileIsChanged != null)
            {
                this.m_fileIsChanged(true);
            }
        }

        private void m_dzFont_m_dataChanged()
        {
            ClassCalc.BufferSingleToBuffer3D(this.datBuff64, this.datBuffFront, this.frontIndex, FrameView.front);
            ClassCalc.BufferSingleToDX(this.datBuffFront, this.m_dx, this.frontIndex, FrameView.front, PaintMode.Copy);
            this.UpdateTop();
            this.UpdateLeft();
            this.m_dx.OnPaint();
            if (this.m_fileIsChanged != null)
            {
                this.m_fileIsChanged(true);
            }
        }

        public void HideControl()
        {
            base.Visible = false;
            this.datBuff64 = null;
        }

        private void UpdateFont()
        {
            ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffFront, this.frontIndex, FrameView.front);
            this.m_dzFront.OnPaint();
        }

        private void UpdateTop()
        {
            ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffTop, this.topIndex, FrameView.top);
            this.m_dzTop.OnPaint();
        }

        private void UpdateLeft()
        {
            ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffLeft, this.leftIndex, FrameView.left);
            this.m_dzLeft.OnPaint();
        }

        private void vScrollBarFont_ValueChanged(object sender, EventArgs e)
        {
            this.frontIndex = this.vScrollBarFront.Value;
            this.labelFront.Text = string.Format("Front view: {0}", this.frontIndex + 1);
            this.UpdateFont();
        }

        private void vScrollBarTop_ValueChanged(object sender, EventArgs e)
        {
            this.topIndex = this.vScrollBarTop.Value;
            this.labelTop.Text = string.Format("Top view: {0}", this.topIndex + 1);
            this.UpdateTop();
        }

        private void vScrollBarLeft_ValueChanged(object sender, EventArgs e)
        {
            this.leftIndex = this.vScrollBarLeft.Value;
            this.labelLeft.Text = string.Format("Left view: {0}", this.leftIndex + 1);
            this.UpdateLeft();
        }

        private void InitializeComponent()
        {
            this.vScrollBarFront = new VScrollBar();
            this.vScrollBarTop = new VScrollBar();
            this.vScrollBarLeft = new VScrollBar();
            this.labelFront = new Label();
            this.labelTop = new Label();
            this.labelLeft = new Label();
            this.m_dzFront = new ControlDZElement();
            this.m_dzTop = new ControlDZElement();
            this.m_dzLeft = new ControlDZElement();
            base.SuspendLayout();
            this.vScrollBarFront.LargeChange = 1;
            this.vScrollBarFront.Location = new Point(164, 28);
            this.vScrollBarFront.Maximum = 7;
            this.vScrollBarFront.Name = "vScrollBarFont";
            this.vScrollBarFront.Size = new Size(22, 148);
            this.vScrollBarFront.TabIndex = 5;
            this.vScrollBarFront.ValueChanged += this.vScrollBarFont_ValueChanged;
            this.vScrollBarTop.LargeChange = 1;
            this.vScrollBarTop.Location = new Point(351, 28);
            this.vScrollBarTop.Maximum = 7;
            this.vScrollBarTop.Name = "vScrollBarTop";
            this.vScrollBarTop.Size = new Size(22, 148);
            this.vScrollBarTop.TabIndex = 5;
            this.vScrollBarTop.ValueChanged += this.vScrollBarTop_ValueChanged;
            this.vScrollBarLeft.LargeChange = 1;
            this.vScrollBarLeft.Location = new Point(535, 28);
            this.vScrollBarLeft.Maximum = 7;
            this.vScrollBarLeft.Name = "vScrollBarLeft";
            this.vScrollBarLeft.Size = new Size(22, 148);
            this.vScrollBarLeft.TabIndex = 5;
            this.vScrollBarLeft.ValueChanged += this.vScrollBarLeft_ValueChanged;
            this.labelFront.AutoSize = true;
            this.labelFront.Location = new Point(29, 188);
            this.labelFront.Name = "labelFont";
            this.labelFront.Size = new Size(95, 12);
            this.labelFront.TabIndex = 3;
            this.labelFront.Text = "Front view: 1";
            this.labelTop.AutoSize = true;
            this.labelTop.Location = new Point(218, 188);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new Size(95, 12);
            this.labelTop.TabIndex = 3;
            this.labelTop.Text = "Top view: 1";
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new Point(401, 188);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new Size(95, 12);
            this.labelLeft.TabIndex = 3;
            this.labelLeft.Text = "Left view: 1";
            this.m_dzFront.BorderStyle = BorderStyle.FixedSingle;
            this.m_dzFront.Location = new Point(13, 28);
            this.m_dzFront.Name = "m_dzFont";
            this.m_dzFront.Size = new Size(148, 148);
            this.m_dzFront.TabIndex = 0;
            this.m_dzFront.Visible = false;
            this.m_dzTop.BorderStyle = BorderStyle.FixedSingle;
            this.m_dzTop.Location = new Point(200, 28);
            this.m_dzTop.Name = "m_dzTop";
            this.m_dzTop.Size = new Size(148, 148);
            this.m_dzTop.TabIndex = 1;
            this.m_dzTop.Visible = false;
            this.m_dzLeft.BorderStyle = BorderStyle.FixedSingle;
            this.m_dzLeft.Location = new Point(384, 28);
            this.m_dzLeft.Name = "m_dzLeft";
            this.m_dzLeft.Size = new Size(148, 148);
            this.m_dzLeft.TabIndex = 2;
            this.m_dzLeft.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.vScrollBarLeft);
            base.Controls.Add(this.vScrollBarTop);
            base.Controls.Add(this.vScrollBarFront);
            base.Controls.Add(this.labelLeft);
            base.Controls.Add(this.labelTop);
            base.Controls.Add(this.labelFront);
            base.Controls.Add(this.m_dzFront);
            base.Controls.Add(this.m_dzTop);
            base.Controls.Add(this.m_dzLeft);
            base.Name = "Control3DDZ";
            base.Size = new Size(571, 207);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private DX9 m_dx;

        private ResourceSolid m_res;

        private ControlEdit m_parent;

        private ControlEdit.ListClass m_list;

        private byte[] datBuff64;

        private byte[] datBuffFront = new byte[8];

        private byte[] datBuffTop = new byte[8];

        private byte[] datBuffLeft = new byte[8];

        private int frontIndex;

        private int topIndex;

        private int leftIndex;

        private ControlDZElement m_dzFront;

        private ControlDZElement m_dzTop;

        private ControlDZElement m_dzLeft;

        private VScrollBar vScrollBarFront;

        private VScrollBar vScrollBarTop;

        private VScrollBar vScrollBarLeft;

        private Label labelFront;

        private Label labelTop;

        private Label labelLeft;
    }
}
