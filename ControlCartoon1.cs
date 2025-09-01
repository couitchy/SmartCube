using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200000C RID: 12
	public class ControlCartoon1 : UserControl
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600007B RID: 123 RVA: 0x00008240 File Offset: 0x00006440
		// (remove) Token: 0x0600007C RID: 124 RVA: 0x00008278 File Offset: 0x00006478
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x0600007D RID: 125 RVA: 0x000082B0 File Offset: 0x000064B0
		public ControlCartoon1(FrameCartoonControl res, FormGuan.FileIsChanged fileIsChanged)
		{
			this.InitializeComponent();
			this.m_res = res;
			this.m_fileIsChanged = fileIsChanged;
			this.textBoxCount.Text = this.m_res.loopCount.ToString();
			this.textBoxCount.KeyPress += this.textBoxCount_KeyPress;
			this.textBoxCount.LostFocus += this.textBoxCount_LostFocus;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008320 File Offset: 0x00006520
		private void textBoxCount_LostFocus(object sender, EventArgs e)
		{
			this.GetValue();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008328 File Offset: 0x00006528
		private void GetValue()
		{
			try
			{
				uint num = uint.Parse(this.textBoxCount.Text);
				if (this.m_res.loopCount != num)
				{
					this.m_res.loopCount = num;
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
					}
				}
			}
			catch
			{
				this.textBoxCount.Text = this.m_res.loopCount.ToString();
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000083A4 File Offset: 0x000065A4
		private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (ClassCalc.TextBoxKeyPress(0, 1000, this.textBoxCount, e))
			{
				this.GetValue();
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000083C0 File Offset: 0x000065C0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000083E0 File Offset: 0x000065E0
		private void InitializeComponent()
		{
			this.labelCount = new Label();
			this.textBoxCount = new TextBox();
			base.SuspendLayout();
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new Point(12, 16);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new Size(59, 12);
			this.labelCount.TabIndex = 0;
			this.labelCount.Text = "Loop count:";
			this.textBoxCount.Location = new Point(90, 14);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new Size(68, 21);
			this.textBoxCount.TabIndex = 1;
			this.textBoxCount.TextAlign = HorizontalAlignment.Right;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.textBoxCount);
			base.Controls.Add(this.labelCount);
			base.Name = "ControlCartoon1";
			base.Size = new Size(253, 55);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000031 RID: 49
		private FrameCartoonControl m_res;

		// Token: 0x04000033 RID: 51
		private IContainer components;

		// Token: 0x04000034 RID: 52
		private Label labelCount;

		// Token: 0x04000035 RID: 53
		private TextBox textBoxCount;
	}
}
