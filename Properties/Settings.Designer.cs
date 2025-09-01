using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Guan.Properties
{
	// Token: 0x0200003D RID: 61
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0001457C File Offset: 0x0001277C
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400018F RID: 399
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
