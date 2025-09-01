using System;

namespace Guan
{
	[Serializable]
	public class FrameHead
	{
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

		public bool GetConfigWord(FrameHead.bitValue bit)
		{
			return bit < (FrameHead.bitValue)32 && ((ulong)this.configWord & (ulong)(1L << (int)(bit & (FrameHead.bitValue)31))) != 0UL;
		}

		public void Clear()
		{
			this.defaultSpeed = 1U;
			this.version = 1024;
			this.configWord = 0U;
		}

		public const uint headWord = 2769809749U;

		public const ushort ThisVersion = 1024;

		public const ushort ThisDate = 1029;

		public ushort version = 1024;

		public uint defaultSpeed = 1U;

		public uint configWord;

		public enum bitValue
		{
			key,
			ad
		}
	}
}
