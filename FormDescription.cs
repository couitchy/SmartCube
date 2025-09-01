using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guan.Properties;

namespace Guan
{
    public partial class FormDescription : Forms
    {
        public FormDescription()
        {
            this.InitializeComponent();
            this.labelInfo.Location = new Point(20, 10);
            this.labelInfo.Text = Resources.Instructions_en;
            base.Width = this.labelInfo.Width + 50;
            base.Height = this.labelInfo.Height + 80;
        }
    }
}
