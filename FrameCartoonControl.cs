using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x02000051 RID: 81
	[Serializable]
	public class FrameCartoonControl
	{
		// Token: 0x04000202 RID: 514
		public string name = "";

		// Token: 0x04000203 RID: 515
		public uint loopCount = 1U;

		// Token: 0x04000204 RID: 516
		public List<FrameCartoonGroup> groups = new List<FrameCartoonGroup>();
	}
}
