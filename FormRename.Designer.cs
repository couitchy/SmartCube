namespace Guan
{
    public partial class FormRename : global::Guan.Forms
    {
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

        private global::System.Windows.Forms.TextBox textBox1;

        private global::System.Windows.Forms.Label label1;

        private global::System.Windows.Forms.Button buttonOK;
    }
}
