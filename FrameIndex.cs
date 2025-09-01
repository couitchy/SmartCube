using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x02000053 RID: 83
	[Serializable]
	public class FrameIndex
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00015316 File Offset: 0x00013516
		public void Clear()
		{
			this.m_indexNumber.Clear();
			this.m_indexSingle.Clear();
			this.m_indexSolid.Clear();
		}

		// Token: 0x04000207 RID: 519
		public List<ResourceIndex> m_indexSingle = new List<ResourceIndex>();

		// Token: 0x04000208 RID: 520
		public List<ResourceIndex> m_indexSolid = new List<ResourceIndex>();

		// Token: 0x04000209 RID: 521
		public List<ResourceIndex> m_indexNumber = new List<ResourceIndex>();
	}
}
