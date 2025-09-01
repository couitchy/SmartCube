using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x02000054 RID: 84
	[Serializable]
	public class FrameControl
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00015362 File Offset: 0x00013562
		public void Clear()
		{
			this.m_cartoon.Clear();
		}

		// Token: 0x0400020A RID: 522
		public List<FrameCartoonControl> m_cartoon = new List<FrameCartoonControl>();
	}
}
