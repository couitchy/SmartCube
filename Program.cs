using System;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200003B RID: 59
	internal static class Program
	{
		// Token: 0x06000200 RID: 512 RVA: 0x00014479 File Offset: 0x00012679
		[STAThread]
		private static void Main(string[] str)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (str.Length > 0)
			{
				Application.Run(new FormGuan(str[0]));
				return;
			}
			Application.Run(new FormGuan());
		}
	}
}
