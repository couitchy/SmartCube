using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	public partial class FormAbout : Forms
	{
		public FormAbout()
		{
			this.InitializeComponent();
		}

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
