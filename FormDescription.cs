using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guan.Properties;

namespace Guan
{
	// Token: 0x02000036 RID: 54
	public partial class FormDescription : Forms
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x00011830 File Offset: 0x0000FA30
		public FormDescription()
		{
			this.InitializeComponent();
			this.labelInfo.Location = new Point(20, 10);
			this.labelInfo.Text = Resources.Instructions_en;
			base.Width = this.labelInfo.Width + 50;
			base.Height = this.labelInfo.Height + 80;
		}
	}
}
