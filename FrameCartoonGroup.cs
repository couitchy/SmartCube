using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x02000050 RID: 80
	[Serializable]
	public class FrameCartoonGroup
	{
		// Token: 0x040001FC RID: 508
		public string name = "";

		// Token: 0x040001FD RID: 509
		public uint frameCount;

		// Token: 0x040001FE RID: 510
		public uint delay = 100U;

		// Token: 0x040001FF RID: 511
		public uint loopCount = 1U;

		// Token: 0x04000200 RID: 512
		public bool cleanDisplay = true;

		// Token: 0x04000201 RID: 513
		public List<FrameCartoonElement> ele = new List<FrameCartoonElement>();
	}
}
