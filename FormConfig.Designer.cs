namespace Guan
{
	// Token: 0x02000034 RID: 52
	public partial class FormConfig : global::Guan.Forms
	{
		// Token: 0x060001CB RID: 459 RVA: 0x00010F1C File Offset: 0x0000F11C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00010F3C File Offset: 0x0000F13C
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBoxConfig = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.comboBoxSpeed = new global::System.Windows.Forms.ComboBox();
			this.checkBoxKey = new global::System.Windows.Forms.CheckBox();
			this.checkBoxAD = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(26, 17);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(47, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Config word:";
			this.textBoxConfig.Location = new global::System.Drawing.Point(88, 13);
			this.textBoxConfig.Name = "textBoxConfig";
			this.textBoxConfig.Size = new global::System.Drawing.Size(75, 21);
			this.textBoxConfig.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(14, 46);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(209, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "(only for us about the value of \r\nsoftware testing, cannot be modified)";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(17, 95);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(65, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "Speed：";
			this.comboBoxSpeed.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSpeed.FormattingEnabled = true;
			this.comboBoxSpeed.Location = new global::System.Drawing.Point(93, 92);
			this.comboBoxSpeed.Name = "comboBoxSpeed";
			this.comboBoxSpeed.Size = new global::System.Drawing.Size(59, 20);
			this.comboBoxSpeed.TabIndex = 4;
			this.checkBoxKey.AutoSize = true;
			this.checkBoxKey.Location = new global::System.Drawing.Point(19, 128);
			this.checkBoxKey.Name = "checkBoxKey";
			this.checkBoxKey.Size = new global::System.Drawing.Size(72, 16);
			this.checkBoxKey.TabIndex = 6;
			this.checkBoxKey.Text = "Enable Key";
			this.checkBoxKey.UseVisualStyleBackColor = true;
			this.checkBoxKey.Visible = false;
			this.checkBoxAD.AutoSize = true;
			this.checkBoxAD.Location = new global::System.Drawing.Point(97, 128);
			this.checkBoxAD.Name = "checkBoxAD";
			this.checkBoxAD.Size = new global::System.Drawing.Size(96, 16);
			this.checkBoxAD.TabIndex = 6;
			this.checkBoxAD.Text = "Enable Voice";
			this.checkBoxAD.UseVisualStyleBackColor = true;
			this.checkBoxAD.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.ClientSize = new global::System.Drawing.Size(242, 169);
			base.Controls.Add(this.checkBoxAD);
			base.Controls.Add(this.checkBoxKey);
			base.Controls.Add(this.comboBoxSpeed);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBoxConfig);
			base.Controls.Add(this.label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormConfig";
			this.Text = "Config";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400014C RID: 332
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400014D RID: 333
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.TextBox textBoxConfig;

		// Token: 0x0400014F RID: 335
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000150 RID: 336
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.ComboBox comboBoxSpeed;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.CheckBox checkBoxKey;

		// Token: 0x04000153 RID: 339
		private global::System.Windows.Forms.CheckBox checkBoxAD;
	}
}
