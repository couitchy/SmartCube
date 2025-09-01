using System;

namespace Guan
{
	// Token: 0x02000059 RID: 89
	[Serializable]
	public class AllResource
	{
		// Token: 0x06000230 RID: 560 RVA: 0x0001546B File Offset: 0x0001366B
		public void Clear()
		{
			this.m_head.Clear();
			this.m_res.Clear();
			this.m_index.Clear();
			this.m_control.Clear();
		}

		// Token: 0x0400021A RID: 538
		public FrameHead m_head = new FrameHead();

		// Token: 0x0400021B RID: 539
		public FrameResource m_res = new FrameResource();

		// Token: 0x0400021C RID: 540
		public FrameIndex m_index = new FrameIndex();

		// Token: 0x0400021D RID: 541
		public FrameControl m_control = new FrameControl();
	}
}
