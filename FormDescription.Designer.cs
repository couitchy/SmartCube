namespace Guan
{
	// Token: 0x02000036 RID: 54
	public partial class FormDescription : global::Guan.Forms
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x00011895 File Offset: 0x0000FA95
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000118B4 File Offset: 0x0000FAB4
		private void InitializeComponent()
		{
			this.labelInfo = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.labelInfo.AutoSize = true;
			this.labelInfo.Location = new global::System.Drawing.Point(16, 14);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new global::System.Drawing.Size(0, 12);
			this.labelInfo.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.ClientSize = new global::System.Drawing.Size(272, 147);
			base.Controls.Add(this.labelInfo);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormDescription";
			this.Text = "Instructions";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400015A RID: 346
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.Label labelInfo;
	}
}
