using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlCartoon1 : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public ControlCartoon1(FrameCartoonControl res, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.m_res = res;
            this.m_fileIsChanged = fileIsChanged;
            this.textBoxCount.Text = this.m_res.loopCount.ToString();
            this.textBoxCount.KeyPress += this.textBoxCount_KeyPress;
            this.textBoxCount.LostFocus += this.textBoxCount_LostFocus;
        }

        private void textBoxCount_LostFocus(object sender, EventArgs e)
        {
            this.GetValue();
        }

        private void GetValue()
        {
            try
            {
                uint num = uint.Parse(this.textBoxCount.Text);
                if (this.m_res.loopCount != num)
                {
                    this.m_res.loopCount = num;
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                    }
                }
            }
            catch
            {
                this.textBoxCount.Text = this.m_res.loopCount.ToString();
            }
        }

        private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ClassCalc.TextBoxKeyPress(0, 1000, this.textBoxCount, e))
            {
                this.GetValue();
            }
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
            this.labelCount = new Label();
            this.textBoxCount = new TextBox();
            base.SuspendLayout();
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new Point(12, 16);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new Size(59, 12);
            this.labelCount.TabIndex = 0;
            this.labelCount.Text = "Loop count:";
            this.textBoxCount.Location = new Point(90, 14);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new Size(68, 21);
            this.textBoxCount.TabIndex = 1;
            this.textBoxCount.TextAlign = HorizontalAlignment.Right;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.textBoxCount);
            base.Controls.Add(this.labelCount);
            base.Name = "ControlCartoon1";
            base.Size = new Size(253, 55);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private FrameCartoonControl m_res;

        private IContainer components;

        private Label labelCount;

        private TextBox textBoxCount;
    }
}
