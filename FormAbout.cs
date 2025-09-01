using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x02000033 RID: 51
	public partial class FormAbout : Forms
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x0001076C File Offset: 0x0000E96C
		public FormAbout()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0001077C File Offset: 0x0000E97C
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel linkLabel = (LinkLabel)sender;
			string text = linkLabel.Text;
			try
			{
				Process.Start(text);
			}
			catch (Win32Exception ex)
			{
				if (ex.ErrorCode == -2147467259)
				{
					MessageBox.Show(ex.Message);
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
		}
	}
}
