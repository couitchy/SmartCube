using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlSingleDZ : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public ControlSingleDZ(DX9 dx, bool mono, ControlEdit parent, ControlEdit.ListClass list, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.m_dx = dx;
            this.m_isMonochrome = mono;
            this.m_parent = parent;
            this.m_list = list;
            this.m_fileIsChanged = fileIsChanged;
            this.m_dz.m_dataChanged += this.m_dz_m_dataChanged;
            base.Paint += this.ControlSingleDZ_Paint;
            this.HideControl();
        }

        private void ControlSingleDZ_Paint(object sender, PaintEventArgs e)
        {
            this.UpdateDX();
        }

        private void m_dz_m_dataChanged()
        {
            ClassCalc.BufferSingleToDX(this.datBuff8, this.m_dx, this.m_isMonochrome, 0, FrameView.front, PaintMode.Copy);
            this.m_dx.OnPaint();
            if (this.m_fileIsChanged != null)
            {
                this.m_fileIsChanged(true);
            }
        }

        public void ShowControl(ResourceSingle res)
        {
            this.m_res = res;
            this.datBuff8 = this.m_res.buff;
            this.m_dx.SetBright(100);
            this.m_dx.ClrBuffer();
            ClassCalc.BufferSingleToDX(this.datBuff8, this.m_dx, this.m_isMonochrome, 0, FrameView.front, PaintMode.Copy);
            this.m_dx.OnPaint();
            this.m_dz.ShowControl(this.datBuff8);
            base.Visible = true;
        }

        public void UpdateDX()
        {
            this.m_dx.ClrBuffer();
            ClassCalc.BufferSingleToDX(this.datBuff8, this.m_dx, this.m_isMonochrome, 0, FrameView.front, PaintMode.Copy);
            this.m_dx.SetBright(100);
            this.m_dx.OnPaint();
        }

        public void HideControl()
        {
            base.Visible = false;
            this.m_res = null;
            this.datBuff8 = null;
        }

        private void InitializeComponent()
        {
            this.m_dz = new ControlDZElement();
            base.SuspendLayout();
            this.m_dz.BorderStyle = BorderStyle.FixedSingle;
            this.m_dz.Location = new Point(28, 32);
            this.m_dz.Name = "m_dz";
            this.m_dz.Size = new Size(148, 148);
            this.m_dz.TabIndex = 0;
            this.m_dz.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.m_dz);
            base.Name = "ControlSingleDZ";
            base.Size = new Size(287, 223);
            base.ResumeLayout(false);
        }

        private DX9 m_dx;

        private bool m_isMonochrome;

        private ControlEdit m_parent;

        private ResourceSingle m_res;

        private ControlEdit.ListClass m_list;

        private byte[] datBuff8;

        private ControlDZElement m_dz;
    }
}
