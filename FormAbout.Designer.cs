namespace Guan
{
    public partial class FormAbout : global::Guan.Forms
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
            this.label4 = new global::System.Windows.Forms.Label();
            this.label3 = new global::System.Windows.Forms.Label();
            this.label2 = new global::System.Windows.Forms.Label();
            this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new global::System.Windows.Forms.LinkLabel();
            base.SuspendLayout();
            this.label4.AutoSize = true;
            this.label4.Font = new global::System.Drawing.Font("SimSun", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.label4.Location = new global::System.Drawing.Point(24, 37);
            this.label4.Name = "label4";
            this.label4.Size = new global::System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Web: ";
            this.label3.AutoSize = true;
            this.label3.Font = new global::System.Drawing.Font("SimSun", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.label3.Location = new global::System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new global::System.Drawing.Size(161, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "QQ:    1226388638";
            this.label2.AutoSize = true;
            this.label2.Font = new global::System.Drawing.Font("SimSun", 14f, global::System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = global::System.Drawing.Color.Blue;
            this.label2.Location = new global::System.Drawing.Point(83, 98);
            this.label2.Name = "label2";
            this.label2.Size = new global::System.Drawing.Size(160, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "乐涛工作室 出品";
            this.label2.Visible = false;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new global::System.Drawing.Point(85, 41);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new global::System.Drawing.Size(131, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.mcu999.com";
            this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new global::System.Drawing.Point(85, 62);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new global::System.Drawing.Size(173, 12);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://zylwcc2005.taobao.com";
            this.linkLabel2.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            base.ClientSize = new global::System.Drawing.Size(276, 129);
            base.Controls.Add(this.linkLabel2);
            base.Controls.Add(this.linkLabel1);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormAbout";
            this.Text = "About us";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private global::System.ComponentModel.IContainer components;

        private global::System.Windows.Forms.Label label4;

        private global::System.Windows.Forms.Label label3;

        private global::System.Windows.Forms.Label label2;

        private global::System.Windows.Forms.LinkLabel linkLabel1;

        private global::System.Windows.Forms.LinkLabel linkLabel2;
    }
}
