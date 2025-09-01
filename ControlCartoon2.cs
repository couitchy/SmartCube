using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlCartoon2 : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public ControlCartoon2(FrameCartoonGroup group, FrameResource res, FrameIndex resIndex, DX9 dx, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.m_group = group;
            this.m_res = res;
            this.m_resIndex = resIndex;
            this.m_dx = dx;
            this.m_fileIsChanged = fileIsChanged;
            this.m_timershaft.SetEvent(this.m_fileIsChanged);
            this.m_timershaft.SetElement(group.ele);
            this.m_timershaft.UpdateFrameCount(this.m_group.frameCount);
            this.textBoxFrameCount.Text = this.m_group.frameCount.ToString();
            this.textBoxDelay.Text = this.m_group.delay.ToString();
            this.textBoxCount.Text = this.m_group.loopCount.ToString();
            this.checkBoxClean.Checked = this.m_group.cleanDisplay;
            this.textBoxFrameCount.KeyPress += this.textBoxFrameCount_KeyPress;
            this.textBoxFrameCount.LostFocus += this.textBoxFrameCount_LostFocus;
            this.textBoxDelay.KeyPress += this.textBoxDelay_KeyPress;
            this.textBoxDelay.LostFocus += this.textBoxDelay_LostFocus;
            this.textBoxCount.KeyPress += this.textBoxCount_KeyPress;
            this.textBoxCount.LostFocus += this.textBoxCount_LostFocus;
            this.checkBoxClean.CheckedChanged += this.checkBoxClean_CheckedChanged;
            this.m_Property = new ControlProperty(this.m_res, this.m_resIndex, this.m_fileIsChanged);
            this.panelPro.Controls.Add(this.m_Property);
            this.m_Property.Dock = DockStyle.Fill;
            this.m_timershaft.m_elementChanged += this.m_timershaft_m_elementChanged;
            this.m_timershaft.m_indexChanged += this.m_timershaft_m_indexChanged;
        }

        private void GetLoopValue()
        {
            try
            {
                uint num = uint.Parse(this.textBoxCount.Text);
                if (this.m_group.loopCount != num)
                {
                    this.m_group.loopCount = num;
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                    }
                }
            }
            catch
            {
                this.textBoxCount.Text = this.m_group.loopCount.ToString();
            }
        }

        private void textBoxCount_LostFocus(object sender, EventArgs e)
        {
            this.GetLoopValue();
        }

        private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ClassCalc.TextBoxKeyPress(0, 1000, this.textBoxCount, e))
            {
                this.GetLoopValue();
            }
        }

        private void m_timershaft_m_indexChanged(int index)
        {
            ClassCalc.SingleFrameToDX(this.m_group, this.m_res, this.m_resIndex, index, this.m_dx);
        }

        private void m_timershaft_m_elementChanged(FrameCartoonType type, FrameCartoonProperty obj)
        {
            if (obj != null)
            {
                this.m_Property.ShowStatus(type, obj);
                return;
            }
            this.m_Property.HideStatus();
        }

        private void checkBoxClean_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_group.cleanDisplay != this.checkBoxClean.Checked)
            {
                this.m_group.cleanDisplay = this.checkBoxClean.Checked;
                if (this.m_fileIsChanged != null)
                {
                    this.m_fileIsChanged(true);
                }
            }
        }

        private void textBoxDelay_LostFocus(object sender, EventArgs e)
        {
            this.UpdateDelay();
        }

        private void textBoxDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ClassCalc.TextBoxKeyPress(5, 5000, this.textBoxDelay, e))
            {
                this.UpdateDelay();
            }
        }

        private void UpdateDelay()
        {
            try
            {
                uint num = uint.Parse(this.textBoxDelay.Text);
                if (this.m_group.delay != num)
                {
                    this.m_group.delay = num;
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                    }
                }
            }
            catch
            {
                this.textBoxDelay.Text = this.m_group.delay.ToString();
            }
        }

        private void textBoxFrameCount_LostFocus(object sender, EventArgs e)
        {
            this.UpdateCount();
        }

        private void UpdateCount()
        {
            try
            {
                uint num = uint.Parse(this.textBoxFrameCount.Text);
                if (this.m_group.frameCount != num)
                {
                    this.m_group.frameCount = num;
                    this.m_timershaft.UpdateFrameCount(this.m_group.frameCount);
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                    }
                }
            }
            catch
            {
                this.textBoxFrameCount.Text = this.m_group.frameCount.ToString();
            }
        }

        private void textBoxFrameCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ClassCalc.TextBoxKeyPress(0, 5000, this.textBoxFrameCount, e))
            {
                this.UpdateCount();
            }
        }

        public void ResourceRename()
        {
            this.m_Property.ResourceUpdate();
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
            this.labelFrameCount = new Label();
            this.textBoxFrameCount = new TextBox();
            this.labelFrameInterval = new Label();
            this.textBoxDelay = new TextBox();
            this.checkBoxClean = new CheckBox();
            this.panelPro = new Panel();
            this.textBoxCount = new TextBox();
            this.labelLoopCount = new Label();
            this.label4 = new Label();
            this.m_timershaft = new ControlTimershaft();
            base.SuspendLayout();
            this.labelFrameCount.AutoSize = true;
            this.labelFrameCount.Location = new Point(9, 11);
            this.labelFrameCount.Name = "labelFrameCount";
            this.labelFrameCount.Size = new Size(35, 12);
            this.labelFrameCount.TabIndex = 1;
            this.labelFrameCount.Text = "Frame:";
            this.textBoxFrameCount.Location = new Point(48, 6);
            this.textBoxFrameCount.Name = "textBoxFrameCount";
            this.textBoxFrameCount.Size = new Size(49, 21);
            this.textBoxFrameCount.TabIndex = 2;
            this.textBoxFrameCount.TextAlign = HorizontalAlignment.Right;
            this.labelFrameInterval.AutoSize = true;
            this.labelFrameInterval.Location = new Point(105, 11);
            this.labelFrameInterval.Name = "labelFrameInterval";
            this.labelFrameInterval.Size = new Size(47, 12);
            this.labelFrameInterval.TabIndex = 1;
            this.labelFrameInterval.Text = "Interval:";
            this.textBoxDelay.Location = new Point(155, 6);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new Size(36, 21);
            this.textBoxDelay.TabIndex = 2;
            this.textBoxDelay.TextAlign = HorizontalAlignment.Right;
            this.checkBoxClean.AutoSize = true;
            this.checkBoxClean.Location = new Point(362, 8);
            this.checkBoxClean.Name = "checkBoxClean";
            this.checkBoxClean.Size = new Size(132, 16);
            this.checkBoxClean.TabIndex = 3;
            this.checkBoxClean.Text = "Clean";
            this.checkBoxClean.UseVisualStyleBackColor = true;
            this.panelPro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.panelPro.Location = new Point(345, 33);
            this.panelPro.Name = "panelPro";
            this.panelPro.Size = new Size(209, 193);
            this.panelPro.TabIndex = 4;
            this.textBoxCount.Location = new Point(306, 6);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new Size(38, 21);
            this.textBoxCount.TabIndex = 6;
            this.textBoxCount.TextAlign = HorizontalAlignment.Right;
            this.labelLoopCount.AutoSize = true;
            this.labelLoopCount.Location = new Point(243, 11);
            this.labelLoopCount.Name = "labelLoopCount";
            this.labelLoopCount.Size = new Size(59, 12);
            this.labelLoopCount.TabIndex = 5;
            this.labelLoopCount.Text = "Loop count:";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("SimSun", 9f);
            this.label4.Location = new Point(194, 11);
            this.label4.Name = "label4";
            this.label4.Size = new Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "(ms)";
            this.m_timershaft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.m_timershaft.BorderStyle = BorderStyle.FixedSingle;
            this.m_timershaft.Cursor = Cursors.Default;
            this.m_timershaft.Location = new Point(3, 33);
            this.m_timershaft.Name = "m_timershaft";
            this.m_timershaft.Size = new Size(340, 193);
            this.m_timershaft.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            base.Controls.Add(this.textBoxCount);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.labelLoopCount);
            base.Controls.Add(this.panelPro);
            base.Controls.Add(this.checkBoxClean);
            base.Controls.Add(this.textBoxDelay);
            base.Controls.Add(this.labelFrameInterval);
            base.Controls.Add(this.textBoxFrameCount);
            base.Controls.Add(this.labelFrameCount);
            base.Controls.Add(this.m_timershaft);
            base.Name = "ControlCartoon2";
            base.Size = new Size(557, 228);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private FrameCartoonGroup m_group;

        private FrameResource m_res;

        private FrameIndex m_resIndex;

        private DX9 m_dx;

        private ControlProperty m_Property;

        private IContainer components;

        private ControlTimershaft m_timershaft;

        private Label labelFrameCount;

        private TextBox textBoxFrameCount;

        private Label labelFrameInterval;

        private TextBox textBoxDelay;

        private CheckBox checkBoxClean;

        private Panel panelPro;

        private TextBox textBoxCount;

        private Label labelLoopCount;

        private Label label4;
    }
}
