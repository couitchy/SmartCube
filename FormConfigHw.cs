namespace Guan
{
    public partial class FormConfigHw : Forms
    {
        public FormConfigHw(AllResource res)
        {
            this.InitializeComponent();
            this.m_res = res;
            this.radioButtonMono.Checked = this.m_res.m_isMonochrome;
            this.radioButtonMulti.Checked = !this.m_res.m_isMonochrome;
        }

        private void radioButtonMono_CheckedChanged(object sender, System.EventArgs e)
        {
            this.m_res.m_isMonochrome = radioButtonMono.Checked;
        }

        private void radioButtonMulti_CheckedChanged(object sender, System.EventArgs e)
        {
            this.m_res.m_isMonochrome = !radioButtonMulti.Checked;
        }

        private AllResource m_res;
    }
}
