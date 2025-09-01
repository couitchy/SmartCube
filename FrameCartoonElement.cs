using System;
using System.Collections.Generic;

namespace Guan
{
	// Token: 0x0200004F RID: 79
	[Serializable]
	public class FrameCartoonElement
	{
		// Token: 0x040001F9 RID: 505
		public string name = "";

		// Token: 0x040001FA RID: 506
		public FrameCartoonType m_type;

		// Token: 0x040001FB RID: 507
		public List<FrameCartoonProperty> property = new List<FrameCartoonProperty>();
	}
}
