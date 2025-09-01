namespace Guan
{
	public partial class FormDebug : global::Guan.Forms
	{
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
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Guan.FormDebug));
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(570, 425);
			base.Name = "FormDebug";
			this.Text = "Debug";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormDebug_FormClosing);
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;
	}
}
