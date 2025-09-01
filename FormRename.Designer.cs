namespace Guan
{
	// Token: 0x02000039 RID: 57
	public partial class FormRename : global::Guan.Forms
	{
		// Token: 0x060001F0 RID: 496 RVA: 0x00013373 File Offset: 0x00011573
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00013394 File Offset: 0x00011594
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Guan.FormRename));
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.buttonOK = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.textBox1.Location = new global::System.Drawing.Point(72, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(96, 21);
			this.textBox1.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(11, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(41, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			this.buttonOK.Location = new global::System.Drawing.Point(187, 11);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new global::System.Drawing.Size(60, 21);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new global::System.EventHandler(this.buttonOK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.ClientSize = new global::System.Drawing.Size(261, 44);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormRename";
			this.Text = "Rename";
			base.Load += new global::System.EventHandler(this.FormRename_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000184 RID: 388
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.Button buttonOK;
	}
}
