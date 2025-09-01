using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	public partial class FormRename : Forms
	{
		public FormRename()
		{
			this.InitializeComponent();
		}

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

		private void FormRename_Load(object sender, EventArgs e)
		{
			this.textBox1.Text = this.name;
			this.Text = this.titleString;
		}

		public string name = "";

		public string titleString = "重命名";
	}
}
