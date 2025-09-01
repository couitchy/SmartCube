using System;
using System.Collections.Generic;

namespace Guan
{
	[Serializable]
	public class FrameIndex
	{
		public void Clear()
		{
			this.m_indexNumber.Clear();
			this.m_indexSingle.Clear();
			this.m_indexSolid.Clear();
		}

		public List<ResourceIndex> m_indexSingle = new List<ResourceIndex>();

		public List<ResourceIndex> m_indexSolid = new List<ResourceIndex>();

		public List<ResourceIndex> m_indexNumber = new List<ResourceIndex>();
	}
}
