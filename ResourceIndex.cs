using System;
using System.Collections.Generic;

namespace Guan
{
	[Serializable]
	public class ResourceIndex
	{
		public ResourceIndex()
		{
			this.m_element.Add(new FrameIndexElement());
		}

		public string name = "";

		public List<FrameIndexElement> m_element = new List<FrameIndexElement>();
	}
}
