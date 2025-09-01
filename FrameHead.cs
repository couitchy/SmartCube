using System;

namespace Guan
{
	// Token: 0x02000057 RID: 87
	[Serializable]
	public class FrameHead
	{
		// Token: 0x0600022C RID: 556 RVA: 0x000153CC File Offset: 0x000135CC
		public void SetConfigWord(FrameHead.bitValue bit, bool flag)
		{
			if (bit < (FrameHead.bitValue)32)
			{
				if (flag)
				{
					this.configWord |= 1U << (int)bit;
					return;
				}
				this.configWord &= ~(1U << (int)bit);
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0001540C File Offset: 0x0001360C
		public bool GetConfigWord(FrameHead.bitValue bit)
		{
			return bit < (FrameHead.bitValue)32 && ((ulong)this.configWord & (ulong)(1L << (int)(bit & (FrameHead.bitValue)31))) != 0UL;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00015436 File Offset: 0x00013636
		public void Clear()
		{
			this.defaultSpeed = 1U;
			this.version = 1024;
			this.configWord = 0U;
		}

		// Token: 0x04000211 RID: 529
		public const uint headWord = 2769809749U;

		// Token: 0x04000212 RID: 530
		public const ushort ThisVersion = 1024;

		// Token: 0x04000213 RID: 531
		public const ushort ThisDate = 1029;

		// Token: 0x04000214 RID: 532
		public ushort version = 1024;

		// Token: 0x04000215 RID: 533
		public uint defaultSpeed = 1U;

		// Token: 0x04000216 RID: 534
		public uint configWord;

		// Token: 0x02000058 RID: 88
		public enum bitValue
		{
			// Token: 0x04000218 RID: 536
			key,
			// Token: 0x04000219 RID: 537
			ad
		}
	}
}
