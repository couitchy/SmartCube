using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Guan
{
    public partial class FormConfigSw : Forms
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public FormConfigSw(AllResourceHead head, FrameHead head2, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.m_head = head;
            this.m_head2 = head2;
            this.m_fileIsChanged = fileIsChanged;
            this.textBoxConfig.Text = string.Format("{0:X8}", this.m_head.config);
            this.textBoxConfig.ReadOnly = true;
            this.textBoxConfig.KeyPress += this.textBoxConfig_KeyPress;
            this.comboBoxSpeed.Items.Add("Full");
            for (int i = 2; i < 11; i++)
            {
                this.comboBoxSpeed.Items.Add("1/" + i);
            }
            if (this.m_head2.defaultSpeed <= 0U || this.m_head2.defaultSpeed > 10U)
            {
                this.m_head2.defaultSpeed = 1U;
            }
            this.comboBoxSpeed.SelectedIndex = (int)(this.m_head2.defaultSpeed - 1U);
            this.checkBoxKey.Checked = this.m_head2.GetConfigWord(FrameHead.bitValue.key);
            this.checkBoxAD.Checked = this.m_head2.GetConfigWord(FrameHead.bitValue.ad);
            if (Config.EnableEnhanced)
            {
                this.checkBoxKey.Visible = true;
                this.checkBoxAD.Visible = true;
            }
            this.comboBoxSpeed.SelectedIndexChanged += this.comboBoxSpeed_SelectedIndexChanged;
            this.checkBoxKey.CheckedChanged += this.checkBoxKey_CheckedChanged;
            this.checkBoxAD.CheckedChanged += this.checkBoxKey_CheckedChanged;
        }

        private void checkBoxKey_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_fileIsChanged != null)
            {
                this.m_fileIsChanged(true);
            }
        }

        private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_fileIsChanged != null)
            {
                this.m_fileIsChanged(true);
            }
        }

        private void textBoxConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.IsEnable)
            {
                return;
            }
            if (this.m_count < this.passwordString.Length)
            {
                if (!(this.passwordString.Substring(this.m_count, 1) == e.KeyChar.ToString()))
                {
                    this.m_count = 0;
                    return;
                }
                this.m_count++;
                if (this.m_count == this.passwordString.Length)
                {
                    this.m_count = 0;
                    this.textBoxConfig.ReadOnly = false;
                    this.IsEnable = true;
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                this.m_count = 0;
            }
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.m_head.config = uint.Parse(this.textBoxConfig.Text, NumberStyles.HexNumber);
            }
            catch
            {
            }
            this.m_head2.defaultSpeed = (uint)(this.comboBoxSpeed.SelectedIndex + 1);
            this.m_head2.SetConfigWord(FrameHead.bitValue.key, this.checkBoxKey.Checked);
            this.m_head2.SetConfigWord(FrameHead.bitValue.ad, this.checkBoxAD.Checked);
        }

        private AllResourceHead m_head;

        private FrameHead m_head2;

        private readonly string passwordString = "fan19893d";

        private int m_count;

        private bool IsEnable;
    }
}
