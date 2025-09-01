using System;

namespace Guan
{
	// Token: 0x02000009 RID: 9
	internal class Config
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000076BD File Offset: 0x000058BD
		public static string Title
		{
			get
			{
				return "3D*8 Leds soft(customization)";
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000076C4 File Offset: 0x000058C4
		public static uint outputStartVale
		{
			get
			{
				return 256U;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000076CB File Offset: 0x000058CB
		public static uint outputLenLimit
		{
			get
			{
				return Config.outputLenMax;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000076D2 File Offset: 0x000058D2
		public static uint outputLenMax
		{
			get
			{
				return 25856U;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000076D9 File Offset: 0x000058D9
		public static bool enableOutput
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000076DC File Offset: 0x000058DC
		public static bool DZ_Rotate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000076DF File Offset: 0x000058DF
		public static bool EnableEnhanced
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000076E2 File Offset: 0x000058E2
		public static string FileSuffix
		{
			get
			{
				return "gpro8";
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000076E9 File Offset: 0x000058E9
		public static string DZElementCopyString
		{
			get
			{
				return "DzElement8";
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000076F0 File Offset: 0x000058F0
		public static string ControlCopyString
		{
			get
			{
				return "CartoonControl8";
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000076F7 File Offset: 0x000058F7
		public static string GroupCopyString
		{
			get
			{
				return "CartoonGroup8";
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000076FE File Offset: 0x000058FE
		public static string SingleCopyString
		{
			get
			{
				return "SingleGraph8";
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00007705 File Offset: 0x00005905
		public static string SolidCopyString
		{
			get
			{
				return "SolidGraph8";
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000770C File Offset: 0x0000590C
		public static string SingleIndexCopyString
		{
			get
			{
				return "SingleIndex8";
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00007713 File Offset: 0x00005913
		public static string SolidIndexCopyString
		{
			get
			{
				return "SolidIndex8";
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000771A File Offset: 0x0000591A
		public static string NumberIndexCopyString
		{
			get
			{
				return "NumberIndex8";
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00007721 File Offset: 0x00005921
		public static int MaxGraph
		{
			get
			{
				return 255;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00007728 File Offset: 0x00005928
		public static int MaxIndexTable
		{
			get
			{
				return 127;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000772C File Offset: 0x0000592C
		public static int MaxIndexElement
		{
			get
			{
				return 255;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00007733 File Offset: 0x00005933
		public static string CartoonGroup
		{
			get
			{
				return "Cartoon Group";
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000773A File Offset: 0x0000593A
		public static string CartoonElement
		{
			get
			{
				return "Cartoon Element";
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00007741 File Offset: 0x00005941
		public static string OperationDot
		{
			get
			{
				return "Dot Operation";
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00007748 File Offset: 0x00005948
		public static string OperationLine
		{
			get
			{
				return "Line Operation";
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000774F File Offset: 0x0000594F
		public static string OperationPannel
		{
			get
			{
				return "Pannel Operation";
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00007756 File Offset: 0x00005956
		public static string OperationSolid
		{
			get
			{
				return "Solid Operation";
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000775D File Offset: 0x0000595D
		public static string OperationBright
		{
			get
			{
				return "Bright Operation";
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00007764 File Offset: 0x00005964
		public static string IndexPannel
		{
			get
			{
				return "Pannel Index";
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000776B File Offset: 0x0000596B
		public static string IndexSolid
		{
			get
			{
				return "Solid Index";
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00007772 File Offset: 0x00005972
		public static string IndexValue
		{
			get
			{
				return "Value Index";
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00007779 File Offset: 0x00005979
		public static string SourceOut
		{
			get
			{
				return "Resources for the ultra limit, can't continue to add!";
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00007780 File Offset: 0x00005980
		public static string RenameFailed
		{
			get
			{
				return "Rename fails, this name already exists!";
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00007787 File Offset: 0x00005987
		public static string GraphPannel
		{
			get
			{
				return "Pannel Graph";
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000778E File Offset: 0x0000598E
		public static string GraphSolid
		{
			get
			{
				return "Solid Graph";
			}
		}

		// Token: 0x04000014 RID: 20
		private const Config.EnumSoft SoftFlag = Config.EnumSoft.enhanced;

		// Token: 0x04000015 RID: 21
		public const uint outputLen = 25856U;

		// Token: 0x04000016 RID: 22
		private const uint outputStart = 256U;

		// Token: 0x0200000A RID: 10
		private enum EnumSoft
		{
			// Token: 0x04000018 RID: 24
			test,
			// Token: 0x04000019 RID: 25
			normal,
			// Token: 0x0400001A RID: 26
			enhanced
		}
	}
}
