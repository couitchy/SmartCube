using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class ResourceIndex
	{
		// Token: 0x0600021A RID: 538 RVA: 0x000151EF File Offset: 0x000133EF
		public ResourceIndex()
		{
			this.m_element.Add(new FrameIndexElement());
		}

		// Token: 0x040001A1 RID: 417
		public string name = "";

		// Token: 0x040001A2 RID: 418
		public List<FrameIndexElement> m_element = new List<FrameIndexElement>();
	}
}
