using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200000B RID: 11
	public class Control3DDZ : UserControl
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000066 RID: 102 RVA: 0x000077A0 File Offset: 0x000059A0
		// (remove) Token: 0x06000067 RID: 103 RVA: 0x000077D8 File Offset: 0x000059D8
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x06000068 RID: 104 RVA: 0x00007810 File Offset: 0x00005A10
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

		// Token: 0x06000069 RID: 105 RVA: 0x00007882 File Offset: 0x00005A82
		private void Control3DDZ_Paint(object sender, PaintEventArgs e)
		{
			this.UpdateDX();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000788C File Offset: 0x00005A8C
		public void ShowControl(ResourceSolid res)
		{
			this.m_res = res;
			this.datBuff64 = this.m_res.buff;
			ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffFont, this.fontIndex, FrameView.font);
			ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffTop, this.topIndex, FrameView.top);
			ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffLeft, this.leftIndex, FrameView.left);
			this.m_dzFont.ShowControl(this.datBuffFont);
			this.m_dzTop.ShowControl(this.datBuffTop);
			this.m_dzLeft.ShowControl(this.datBuffLeft);
			this.m_dzFont.m_dataChanged += this.m_dzFont_m_dataChanged;
			this.m_dzTop.m_dataChanged += this.m_dzTop_m_dataChanged;
			this.m_dzLeft.m_dataChanged += this.m_dzLeft_m_dataChanged;
			this.m_dzFont.m_wheel += this.m_dzFont_m_wheel;
			this.m_dzTop.m_wheel += this.m_dzTop_m_wheel;
			this.m_dzLeft.m_wheel += this.m_dzLeft_m_wheel;
			base.Visible = true;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000079BD File Offset: 0x00005BBD
		public void UpdateDX()
		{
			ClassCalc.Buffer3DToDX(this.datBuff64, this.m_dx);
			this.m_dx.SetBright(100);
			this.m_dx.OnPaint();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000079E8 File Offset: 0x00005BE8
		private void m_dzFont_m_wheel(int value)
		{
			int num = this.vScrollBarFont.Value - value / 100;
			if (num < 0)
			{
				num = 0;
			}
			else if (num > 7)
			{
				num = 7;
			}
			this.vScrollBarFont.Value = num;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00007A20 File Offset: 0x00005C20
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

		// Token: 0x0600006E RID: 110 RVA: 0x00007A58 File Offset: 0x00005C58
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

		// Token: 0x0600006F RID: 111 RVA: 0x00007A90 File Offset: 0x00005C90
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

		// Token: 0x06000070 RID: 112 RVA: 0x00007AFC File Offset: 0x00005CFC
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

		// Token: 0x06000071 RID: 113 RVA: 0x00007B68 File Offset: 0x00005D68
		private void m_dzFont_m_dataChanged()
		{
			ClassCalc.BufferSingleToBuffer3D(this.datBuff64, this.datBuffFont, this.fontIndex, FrameView.font);
			ClassCalc.BufferSingleToDX(this.datBuffFont, this.m_dx, this.fontIndex, FrameView.font, PaintMode.Copy);
			this.UpdateTop();
			this.UpdateLeft();
			this.m_dx.OnPaint();
			if (this.m_fileIsChanged != null)
			{
				this.m_fileIsChanged(true);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007BD1 File Offset: 0x00005DD1
		public void HideControl()
		{
			base.Visible = false;
			this.datBuff64 = null;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007BE1 File Offset: 0x00005DE1
		private void UpdateFont()
		{
			ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffFont, this.fontIndex, FrameView.font);
			this.m_dzFont.OnPaint();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00007C06 File Offset: 0x00005E06
		private void UpdateTop()
		{
			ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffTop, this.topIndex, FrameView.top);
			this.m_dzTop.OnPaint();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00007C2B File Offset: 0x00005E2B
		private void UpdateLeft()
		{
			ClassCalc.Buffer3DToBufferSingle(this.datBuff64, this.datBuffLeft, this.leftIndex, FrameView.left);
			this.m_dzLeft.OnPaint();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00007C50 File Offset: 0x00005E50
		private void vScrollBarFont_ValueChanged(object sender, EventArgs e)
		{
			this.fontIndex = this.vScrollBarFont.Value;
			this.labelFont.Text = string.Format("Front view: {0}", this.fontIndex + 1);
			this.UpdateFont();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00007C8B File Offset: 0x00005E8B
		private void vScrollBarTop_ValueChanged(object sender, EventArgs e)
		{
			this.topIndex = this.vScrollBarTop.Value;
			this.labelTop.Text = string.Format("Top view: {0}", this.topIndex + 1);
			this.UpdateTop();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007CC6 File Offset: 0x00005EC6
		private void vScrollBarLeft_ValueChanged(object sender, EventArgs e)
		{
			this.leftIndex = this.vScrollBarLeft.Value;
			this.labelLeft.Text = string.Format("Left view: {0}", this.leftIndex + 1);
			this.UpdateLeft();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00007D01 File Offset: 0x00005F01
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00007D20 File Offset: 0x00005F20
		private void InitializeComponent()
		{
			this.vScrollBarFont = new VScrollBar();
			this.vScrollBarTop = new VScrollBar();
			this.vScrollBarLeft = new VScrollBar();
			this.labelFont = new Label();
			this.labelTop = new Label();
			this.labelLeft = new Label();
			this.m_dzFont = new ControlDZElement();
			this.m_dzTop = new ControlDZElement();
			this.m_dzLeft = new ControlDZElement();
			base.SuspendLayout();
			this.vScrollBarFont.LargeChange = 1;
			this.vScrollBarFont.Location = new Point(164, 28);
			this.vScrollBarFont.Maximum = 7;
			this.vScrollBarFont.Name = "vScrollBarFont";
			this.vScrollBarFont.Size = new Size(22, 148);
			this.vScrollBarFont.TabIndex = 5;
			this.vScrollBarFont.ValueChanged += this.vScrollBarFont_ValueChanged;
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
			this.labelFont.AutoSize = true;
			this.labelFont.Location = new Point(29, 188);
			this.labelFont.Name = "labelFont";
			this.labelFont.Size = new Size(95, 12);
			this.labelFont.TabIndex = 3;
			this.labelFont.Text = "Front view: 1";
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
			this.m_dzFont.BorderStyle = BorderStyle.FixedSingle;
			this.m_dzFont.Location = new Point(13, 28);
			this.m_dzFont.Name = "m_dzFont";
			this.m_dzFont.Size = new Size(148, 148);
			this.m_dzFont.TabIndex = 0;
			this.m_dzFont.Visible = false;
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
			base.Controls.Add(this.vScrollBarFont);
			base.Controls.Add(this.labelLeft);
			base.Controls.Add(this.labelTop);
			base.Controls.Add(this.labelFont);
			base.Controls.Add(this.m_dzFont);
			base.Controls.Add(this.m_dzTop);
			base.Controls.Add(this.m_dzLeft);
			base.Name = "Control3DDZ";
			base.Size = new Size(571, 207);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400001B RID: 27
		private DX9 m_dx;

		// Token: 0x0400001C RID: 28
		private ResourceSolid m_res;

		// Token: 0x0400001D RID: 29
		private ControlEdit m_parent;

		// Token: 0x0400001E RID: 30
		private ControlEdit.ListClass m_list;

		// Token: 0x04000020 RID: 32
		private byte[] datBuff64;

		// Token: 0x04000021 RID: 33
		private byte[] datBuffFont = new byte[8];

		// Token: 0x04000022 RID: 34
		private byte[] datBuffTop = new byte[8];

		// Token: 0x04000023 RID: 35
		private byte[] datBuffLeft = new byte[8];

		// Token: 0x04000024 RID: 36
		private int fontIndex;

		// Token: 0x04000025 RID: 37
		private int topIndex;

		// Token: 0x04000026 RID: 38
		private int leftIndex;

		// Token: 0x04000027 RID: 39
		private IContainer components;

		// Token: 0x04000028 RID: 40
		private ControlDZElement m_dzFont;

		// Token: 0x04000029 RID: 41
		private ControlDZElement m_dzTop;

		// Token: 0x0400002A RID: 42
		private ControlDZElement m_dzLeft;

		// Token: 0x0400002B RID: 43
		private VScrollBar vScrollBarFont;

		// Token: 0x0400002C RID: 44
		private VScrollBar vScrollBarTop;

		// Token: 0x0400002D RID: 45
		private VScrollBar vScrollBarLeft;

		// Token: 0x0400002E RID: 46
		private Label labelFont;

		// Token: 0x0400002F RID: 47
		private Label labelTop;

		// Token: 0x04000030 RID: 48
		private Label labelLeft;
	}
}
