using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public class FrameResource
	{
		// Token: 0x06000224 RID: 548 RVA: 0x000152E0 File Offset: 0x000134E0
		public void Clear()
		{
			this.m_resSingle.Clear();
			this.m_resSolid.Clear();
		}

		// Token: 0x04000205 RID: 517
		public List<ResourceSingle> m_resSingle = new List<ResourceSingle>();

		// Token: 0x04000206 RID: 518
		public List<ResourceSolid> m_resSolid = new List<ResourceSolid>();
	}
}
