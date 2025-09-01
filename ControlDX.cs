using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	public class ControlDX : UserControl
	{
		public ControlDX(Control parent)
		{
			this.InitializeComponent();
			this.m_parent = parent;
			this.UpdateSize();
			this.m_parent.SizeChanged += this.m_parent_SizeChanged;
			base.SetStyle(ControlStyles.ResizeRedraw, false);
		}

		private void m_parent_SizeChanged(object sender, EventArgs e)
		{
			this.UpdateSize();
		}

		private void UpdateSize()
		{
			Size size = this.m_parent.Size;
			int num = ((size.Width > size.Height) ? size.Height : size.Width);
			base.Size = new Size(num, num);
			base.Location = new Point((size.Width - num) / 2, (size.Height - num) / 2);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}

		private Control m_parent;

		private IContainer components;
	}
}
