using System;

namespace Guan
{
	// Token: 0x02000055 RID: 85
	public class AllResourceHead
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00015384 File Offset: 0x00013584
		public bool GetBit(AllResourceHead.bitValue bit)
		{
			return bit < (AllResourceHead.bitValue)24 && (this.config & 4278190080U) == 436207616U && ((ulong)this.config & (ulong)(1L << (int)(bit & (AllResourceHead.bitValue)31))) != 0UL;
		}

		// Token: 0x0400020B RID: 523
		public uint config;

		// Token: 0x02000056 RID: 86
		public enum bitValue
		{
			// Token: 0x0400020D RID: 525
			DisableDislay,
			// Token: 0x0400020E RID: 526
			TestMode,
			// Token: 0x0400020F RID: 527
			DisableJTAG = 8,
			// Token: 0x04000210 RID: 528
			OutPutCFile = 16
		}
	}
}
