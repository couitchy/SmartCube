using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x02000039 RID: 57
	public partial class FormRename : Forms
	{
		// Token: 0x060001ED RID: 493 RVA: 0x000132D4 File Offset: 0x000114D4
		public FormRename()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000132F8 File Offset: 0x000114F8
		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (this.textBox1.Text != "" && this.name != this.textBox1.Text)
			{
				this.name = this.textBox1.Text;
				base.DialogResult = DialogResult.OK;
				return;
			}
			base.DialogResult = DialogResult.No;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00013354 File Offset: 0x00011554
		private void FormRename_Load(object sender, EventArgs e)
		{
			this.textBox1.Text = this.name;
			this.Text = this.titleString;
		}

		// Token: 0x04000182 RID: 386
		public string name = "";

		// Token: 0x04000183 RID: 387
		public string titleString = "重命名";
	}
}
