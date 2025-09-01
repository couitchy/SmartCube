using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x02000034 RID: 52
	public partial class FormConfig : Forms
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060001C4 RID: 452 RVA: 0x00010BBC File Offset: 0x0000EDBC
		// (remove) Token: 0x060001C5 RID: 453 RVA: 0x00010BF4 File Offset: 0x0000EDF4
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x060001C6 RID: 454 RVA: 0x00010C2C File Offset: 0x0000EE2C
		public FormConfig(AllResourceHead head, FrameHead head2, FormGuan.FileIsChanged fileIsChanged)
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

		// Token: 0x060001C7 RID: 455 RVA: 0x00010DC4 File Offset: 0x0000EFC4
		private void checkBoxKey_CheckedChanged(object sender, EventArgs e)
		{
			if (this.m_fileIsChanged != null)
			{
				this.m_fileIsChanged(true);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00010DDA File Offset: 0x0000EFDA
		private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.m_fileIsChanged != null)
			{
				this.m_fileIsChanged(true);
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00010DF0 File Offset: 0x0000EFF0
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

		// Token: 0x060001CA RID: 458 RVA: 0x00010E94 File Offset: 0x0000F094
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

		// Token: 0x04000146 RID: 326
		private AllResourceHead m_head;

		// Token: 0x04000147 RID: 327
		private FrameHead m_head2;

		// Token: 0x04000148 RID: 328
		private readonly string passwordString = "fan19893d";

		// Token: 0x0400014A RID: 330
		private int m_count;

		// Token: 0x0400014B RID: 331
		private bool IsEnable;
	}
}
