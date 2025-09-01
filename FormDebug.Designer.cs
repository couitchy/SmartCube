namespace Guan
{
	// Token: 0x02000035 RID: 53
	public partial class FormDebug : global::Guan.Forms
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x0001178D File Offset: 0x0000F98D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000117AC File Offset: 0x0000F9AC
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

		// Token: 0x04000159 RID: 345
		private global::System.ComponentModel.IContainer components;
	}
}
