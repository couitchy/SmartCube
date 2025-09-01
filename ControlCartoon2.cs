using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200000D RID: 13
	public class ControlCartoon2 : UserControl
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000083 RID: 131 RVA: 0x00008524 File Offset: 0x00006724
		// (remove) Token: 0x06000084 RID: 132 RVA: 0x0000855C File Offset: 0x0000675C
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x06000085 RID: 133 RVA: 0x00008594 File Offset: 0x00006794
		public ControlCartoon2(FrameCartoonGroup group, FrameResource res, FrameIndex resIndex, DX9 dx, FormGuan.FileIsChanged fileIsChanged)
		{
			this.InitializeComponent();
			this.Dock = DockStyle.Fill;
			this.m_group = group;
			this.m_res = res;
			this.m_resIndex = resIndex;
			this.m_dx = dx;
			this.m_fileIsChanged = fileIsChanged;
			this.m_timershaft.SetEvent(this.m_fileIsChanged);
			this.m_timershaft.SetElement(group.ele);
			this.m_timershaft.UpdateFrameCount(this.m_group.frameCount);
			this.textBoxFrameCount.Text = this.m_group.frameCount.ToString();
			this.textBoxDelay.Text = this.m_group.delay.ToString();
			this.textBoxCount.Text = this.m_group.loopCount.ToString();
			this.checkBoxClean.Checked = this.m_group.cleanDisplay;
			this.textBoxFrameCount.KeyPress += this.textBoxFrameCount_KeyPress;
			this.textBoxFrameCount.LostFocus += this.textBoxFrameCount_LostFocus;
			this.textBoxDelay.KeyPress += this.textBoxDelay_KeyPress;
			this.textBoxDelay.LostFocus += this.textBoxDelay_LostFocus;
			this.textBoxCount.KeyPress += this.textBoxCount_KeyPress;
			this.textBoxCount.LostFocus += this.textBoxCount_LostFocus;
			this.checkBoxClean.CheckedChanged += this.checkBoxClean_CheckedChanged;
			this.m_Property = new ControlProperty(this.m_res, this.m_resIndex, this.m_fileIsChanged);
			this.panelPro.Controls.Add(this.m_Property);
			this.m_Property.Dock = DockStyle.Fill;
			this.m_timershaft.m_elementChanged += this.m_timershaft_m_elementChanged;
			this.m_timershaft.m_indexChanged += this.m_timershaft_m_indexChanged;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00008788 File Offset: 0x00006988
		private void GetLoopValue()
		{
			try
			{
				uint num = uint.Parse(this.textBoxCount.Text);
				if (this.m_group.loopCount != num)
				{
					this.m_group.loopCount = num;
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
				}
			}
			catch
			{
				this.textBoxCount.Text = this.m_group.loopCount.ToString();
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00008804 File Offset: 0x00006A04
		private void textBoxCount_LostFocus(object sender, EventArgs e)
		{
			this.GetLoopValue();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000880C File Offset: 0x00006A0C
		private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (ClassCalc.TextBoxKeyPress(0, 1000, this.textBoxCount, e))
			{
				this.GetLoopValue();
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00008828 File Offset: 0x00006A28
		private void m_timershaft_m_indexChanged(int index)
		{
			ClassCalc.SingleFrameToDX(this.m_group, this.m_res, this.m_resIndex, index, this.m_dx);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00008848 File Offset: 0x00006A48
		private void m_timershaft_m_elementChanged(FrameCartoonType type, FrameCartoonProperty obj)
		{
			if (obj != null)
			{
				this.m_Property.ShowStatus(type, obj);
				return;
			}
			this.m_Property.HideStatus();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00008868 File Offset: 0x00006A68
		private void checkBoxClean_CheckedChanged(object sender, EventArgs e)
		{
			if (this.m_group.cleanDisplay != this.checkBoxClean.Checked)
			{
				this.m_group.cleanDisplay = this.checkBoxClean.Checked;
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000088B7 File Offset: 0x00006AB7
		private void textBoxDelay_LostFocus(object sender, EventArgs e)
		{
			this.UpdateDelay();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000088BF File Offset: 0x00006ABF
		private void textBoxDelay_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (ClassCalc.TextBoxKeyPress(5, 5000, this.textBoxDelay, e))
			{
				this.UpdateDelay();
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000088DC File Offset: 0x00006ADC
		private void UpdateDelay()
		{
			try
			{
				uint num = uint.Parse(this.textBoxDelay.Text);
				if (this.m_group.delay != num)
				{
					this.m_group.delay = num;
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
				}
			}
			catch
			{
				this.textBoxDelay.Text = this.m_group.delay.ToString();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00008958 File Offset: 0x00006B58
		private void textBoxFrameCount_LostFocus(object sender, EventArgs e)
		{
			this.UpdateCount();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00008960 File Offset: 0x00006B60
		private void UpdateCount()
		{
			try
			{
				uint num = uint.Parse(this.textBoxFrameCount.Text);
				if (this.m_group.frameCount != num)
				{
					this.m_group.frameCount = num;
					this.m_timershaft.UpdateFrameCount(this.m_group.frameCount);
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
				}
			}
			catch
			{
				this.textBoxFrameCount.Text = this.m_group.frameCount.ToString();
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000089F4 File Offset: 0x00006BF4
		private void textBoxFrameCount_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (ClassCalc.TextBoxKeyPress(0, 5000, this.textBoxFrameCount, e))
			{
				this.UpdateCount();
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00008A10 File Offset: 0x00006C10
		public void ResourceRename()
		{
			this.m_Property.ResourceUpdate();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00008A1D File Offset: 0x00006C1D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00008A3C File Offset: 0x00006C3C
		private void InitializeComponent()
		{
			this.labelFrameCount = new Label();
			this.textBoxFrameCount = new TextBox();
			this.labelFrameInterval = new Label();
			this.textBoxDelay = new TextBox();
			this.checkBoxClean = new CheckBox();
			this.panelPro = new Panel();
			this.textBoxCount = new TextBox();
			this.labelLoopCount = new Label();
			this.label4 = new Label();
			this.m_timershaft = new ControlTimershaft();
			base.SuspendLayout();
			this.labelFrameCount.AutoSize = true;
			this.labelFrameCount.Location = new Point(9, 11);
			this.labelFrameCount.Name = "labelFrameCount";
			this.labelFrameCount.Size = new Size(35, 12);
			this.labelFrameCount.TabIndex = 1;
			this.labelFrameCount.Text = "Frame:";
			this.textBoxFrameCount.Location = new Point(48, 6);
			this.textBoxFrameCount.Name = "textBoxFrameCount";
			this.textBoxFrameCount.Size = new Size(49, 21);
			this.textBoxFrameCount.TabIndex = 2;
			this.textBoxFrameCount.TextAlign = HorizontalAlignment.Right;
			this.labelFrameInterval.AutoSize = true;
			this.labelFrameInterval.Location = new Point(105, 11);
			this.labelFrameInterval.Name = "labelFrameInterval";
			this.labelFrameInterval.Size = new Size(47, 12);
			this.labelFrameInterval.TabIndex = 1;
			this.labelFrameInterval.Text = "Interval:";
			this.textBoxDelay.Location = new Point(155, 6);
			this.textBoxDelay.Name = "textBoxDelay";
			this.textBoxDelay.Size = new Size(36, 21);
			this.textBoxDelay.TabIndex = 2;
			this.textBoxDelay.TextAlign = HorizontalAlignment.Right;
			this.checkBoxClean.AutoSize = true;
			this.checkBoxClean.Location = new Point(362, 8);
			this.checkBoxClean.Name = "checkBoxClean";
			this.checkBoxClean.Size = new Size(132, 16);
			this.checkBoxClean.TabIndex = 3;
			this.checkBoxClean.Text = "Clean";
			this.checkBoxClean.UseVisualStyleBackColor = true;
			this.panelPro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			this.panelPro.Location = new Point(345, 33);
			this.panelPro.Name = "panelPro";
			this.panelPro.Size = new Size(209, 193);
			this.panelPro.TabIndex = 4;
			this.textBoxCount.Location = new Point(306, 6);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new Size(38, 21);
			this.textBoxCount.TabIndex = 6;
			this.textBoxCount.TextAlign = HorizontalAlignment.Right;
			this.labelLoopCount.AutoSize = true;
			this.labelLoopCount.Location = new Point(243, 11);
			this.labelLoopCount.Name = "labelLoopCount";
			this.labelLoopCount.Size = new Size(59, 12);
			this.labelLoopCount.TabIndex = 5;
			this.labelLoopCount.Text = "Loop count:";
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SimSun", 9f);
			this.label4.Location = new Point(194, 11);
			this.label4.Name = "label4";
			this.label4.Size = new Size(29, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "(ms)";
			this.m_timershaft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.m_timershaft.BorderStyle = BorderStyle.FixedSingle;
			this.m_timershaft.Cursor = Cursors.Default;
			this.m_timershaft.Location = new Point(3, 33);
			this.m_timershaft.Name = "m_timershaft";
			this.m_timershaft.Size = new Size(340, 193);
			this.m_timershaft.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoSize = true;
			base.Controls.Add(this.textBoxCount);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.labelLoopCount);
			base.Controls.Add(this.panelPro);
			base.Controls.Add(this.checkBoxClean);
			base.Controls.Add(this.textBoxDelay);
			base.Controls.Add(this.labelFrameInterval);
			base.Controls.Add(this.textBoxFrameCount);
			base.Controls.Add(this.labelFrameCount);
			base.Controls.Add(this.m_timershaft);
			base.Name = "ControlCartoon2";
			base.Size = new Size(557, 228);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000036 RID: 54
		private FrameCartoonGroup m_group;

		// Token: 0x04000037 RID: 55
		private FrameResource m_res;

		// Token: 0x04000038 RID: 56
		private FrameIndex m_resIndex;

		// Token: 0x04000039 RID: 57
		private DX9 m_dx;

		// Token: 0x0400003B RID: 59
		private ControlProperty m_Property;

		// Token: 0x0400003C RID: 60
		private IContainer components;

		// Token: 0x0400003D RID: 61
		private ControlTimershaft m_timershaft;

		// Token: 0x0400003E RID: 62
		private Label labelFrameCount;

		// Token: 0x0400003F RID: 63
		private TextBox textBoxFrameCount;

		// Token: 0x04000040 RID: 64
		private Label labelFrameInterval;

		// Token: 0x04000041 RID: 65
		private TextBox textBoxDelay;

		// Token: 0x04000042 RID: 66
		private CheckBox checkBoxClean;

		// Token: 0x04000043 RID: 67
		private Panel panelPro;

		// Token: 0x04000044 RID: 68
		private TextBox textBoxCount;

		// Token: 0x04000045 RID: 69
		private Label labelLoopCount;

		// Token: 0x04000046 RID: 70
		private Label label4;
	}
}
