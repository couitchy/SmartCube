using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200002A RID: 42
	public class ControlSingleDZ : UserControl
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000177 RID: 375 RVA: 0x0000D6DC File Offset: 0x0000B8DC
		// (remove) Token: 0x06000178 RID: 376 RVA: 0x0000D714 File Offset: 0x0000B914
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x06000179 RID: 377 RVA: 0x0000D74C File Offset: 0x0000B94C
		public ControlSingleDZ(DX9 dx, ControlEdit parent, ControlEdit.ListClass list, FormGuan.FileIsChanged fileIsChanged)
		{
			this.InitializeComponent();
			this.m_dx = dx;
			this.m_parent = parent;
			this.m_list = list;
			this.m_fileIsChanged = fileIsChanged;
			this.m_dz.m_dataChanged += this.m_dz_m_dataChanged;
			base.Paint += this.ControlSingleDZ_Paint;
			this.HideControl();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000D7B1 File Offset: 0x0000B9B1
		private void ControlSingleDZ_Paint(object sender, PaintEventArgs e)
		{
			this.UpdateDX();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000D7B9 File Offset: 0x0000B9B9
		private void m_dz_m_dataChanged()
		{
			ClassCalc.BufferSingleToDX(this.datBuff8, this.m_dx, 0, FrameView.font, PaintMode.Copy);
			this.m_dx.OnPaint();
			if (this.m_fileIsChanged != null)
			{
				this.m_fileIsChanged(true);
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000D7F0 File Offset: 0x0000B9F0
		public void ShowControl(ResourceSingle res)
		{
			this.m_res = res;
			this.datBuff8 = this.m_res.buff;
			this.m_dx.SetBright(100);
			this.m_dx.ClrBuffer();
			ClassCalc.BufferSingleToDX(this.datBuff8, this.m_dx, 0, FrameView.font, PaintMode.Copy);
			this.m_dx.OnPaint();
			this.m_dz.ShowControl(this.datBuff8);
			base.Visible = true;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000D864 File Offset: 0x0000BA64
		public void UpdateDX()
		{
			this.m_dx.ClrBuffer();
			ClassCalc.BufferSingleToDX(this.datBuff8, this.m_dx, 0, FrameView.font, PaintMode.Copy);
			this.m_dx.SetBright(100);
			this.m_dx.OnPaint();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000D89D File Offset: 0x0000BA9D
		public void HideControl()
		{
			base.Visible = false;
			this.m_res = null;
			this.datBuff8 = null;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000D8D4 File Offset: 0x0000BAD4
		private void InitializeComponent()
		{
			this.m_dz = new ControlDZElement();
			base.SuspendLayout();
			this.m_dz.BorderStyle = BorderStyle.FixedSingle;
			this.m_dz.Location = new Point(28, 32);
			this.m_dz.Name = "m_dz";
			this.m_dz.Size = new Size(148, 148);
			this.m_dz.TabIndex = 0;
			this.m_dz.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_dz);
			base.Name = "ControlSingleDZ";
			base.Size = new Size(287, 223);
			base.ResumeLayout(false);
		}

		// Token: 0x040000F9 RID: 249
		private DX9 m_dx;

		// Token: 0x040000FA RID: 250
		private ControlEdit m_parent;

		// Token: 0x040000FB RID: 251
		private ResourceSingle m_res;

		// Token: 0x040000FC RID: 252
		private ControlEdit.ListClass m_list;

		// Token: 0x040000FE RID: 254
		private byte[] datBuff8;

		// Token: 0x040000FF RID: 255
		private IContainer components;

		// Token: 0x04000100 RID: 256
		private ControlDZElement m_dz;
	}
}
