namespace Guan
{
    public partial class FormConfigHw : global::Guan.Forms
    {
        private void InitializeComponent()
        {
            this.radioButtonMono = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonMulti = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButtonMono
            // 
            this.radioButtonMono.AutoSize = true;
            this.radioButtonMono.Checked = true;
            this.radioButtonMono.Location = new System.Drawing.Point(51, 60);
            this.radioButtonMono.Name = "radioButtonMono";
            this.radioButtonMono.Size = new System.Drawing.Size(87, 17);
            this.radioButtonMono.TabIndex = 0;
            this.radioButtonMono.TabStop = true;
            this.radioButtonMono.Text = "Monochrome";
            this.radioButtonMono.UseVisualStyleBackColor = true;
            this.radioButtonMono.CheckedChanged += new System.EventHandler(this.radioButtonMono_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LED cube type:";
            // 
            // radioButtonMulti
            // 
            this.radioButtonMulti.AutoSize = true;
            this.radioButtonMulti.Location = new System.Drawing.Point(51, 83);
            this.radioButtonMulti.Name = "radioButtonMulti";
            this.radioButtonMulti.Size = new System.Drawing.Size(70, 17);
            this.radioButtonMulti.TabIndex = 2;
            this.radioButtonMulti.Text = "Multicolor";
            this.radioButtonMulti.UseVisualStyleBackColor = true;
            this.radioButtonMulti.CheckedChanged += new System.EventHandler(this.radioButtonMulti_CheckedChanged);
            // 
            // FormConfigHw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(242, 183);
            this.Controls.Add(this.radioButtonMulti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonMono);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigHw";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.RadioButton radioButtonMono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonMulti;
    }
}
