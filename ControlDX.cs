using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200005D RID: 93
	public class ControlDX : UserControl
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00015FAF File Offset: 0x000141AF
		public ControlDX(Control parent)
		{
			this.InitializeComponent();
			this.m_parent = parent;
			this.UpdateSize();
			this.m_parent.SizeChanged += this.m_parent_SizeChanged;
			base.SetStyle(ControlStyles.ResizeRedraw, false);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00015FEA File Offset: 0x000141EA
		private void m_parent_SizeChanged(object sender, EventArgs e)
		{
			this.UpdateSize();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00015FF4 File Offset: 0x000141F4
		private void UpdateSize()
		{
			Size size = this.m_parent.Size;
			int num = ((size.Width > size.Height) ? size.Height : size.Width);
			base.Size = new Size(num, num);
			base.Location = new Point((size.Width - num) / 2, (size.Height - num) / 2);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0001605C File Offset: 0x0001425C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0001607B File Offset: 0x0001427B
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}

		// Token: 0x04000229 RID: 553
		private Control m_parent;

		// Token: 0x0400022A RID: 554
		private IContainer components;
	}
}
