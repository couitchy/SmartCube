using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Guan.Properties
{
	// Token: 0x0200003C RID: 60
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x06000201 RID: 513 RVA: 0x000144A4 File Offset: 0x000126A4
		internal Resources()
		{
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000144AC File Offset: 0x000126AC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Guan.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000203 RID: 515 RVA: 0x000144EB File Offset: 0x000126EB
		// (set) Token: 0x06000204 RID: 516 RVA: 0x000144F2 File Offset: 0x000126F2
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000205 RID: 517 RVA: 0x000144FA File Offset: 0x000126FA
		internal static string Head
		{
			get
			{
				return Resources.ResourceManager.GetString("Head", Resources.resourceCulture);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00014510 File Offset: 0x00012710
		internal static string Instructions
		{
			get
			{
				return Resources.ResourceManager.GetString("Instructions", Resources.resourceCulture);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00014526 File Offset: 0x00012726
		internal static string Instructions_en
		{
			get
			{
				return Resources.ResourceManager.GetString("Instructions_en", Resources.resourceCulture);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0001453C File Offset: 0x0001273C
		internal static string Tail
		{
			get
			{
				return Resources.ResourceManager.GetString("Tail", Resources.resourceCulture);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00014554 File Offset: 0x00012754
		internal static Icon 光立方
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("光立方", Resources.resourceCulture);
				return (Icon)@object;
			}
		}

		// Token: 0x0400018D RID: 397
		private static ResourceManager resourceMan;

		// Token: 0x0400018E RID: 398
		private static CultureInfo resourceCulture;
	}
}
