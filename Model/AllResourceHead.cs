using System;

namespace Guan
{
    public class AllResourceHead
    {
        public bool GetBit(AllResourceHead.bitValue bit)
        {
            return bit < (AllResourceHead.bitValue)24 && (this.config & 4278190080U) == 436207616U && ((ulong)this.config & (ulong)(1L << (int)(bit & (AllResourceHead.bitValue)31))) != 0UL;
        }

        public uint config;

        public enum bitValue
        {
            DisableDislay,
            TestMode,
            DisableJTAG = 8,
            OutPutCFile = 16
        }
    }
}
