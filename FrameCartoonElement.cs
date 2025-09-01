using System;
using System.Collections.Generic;

namespace Guan
{
	[Serializable]
	public class FrameCartoonElement
	{
		public string name = "";

		public FrameCartoonType m_type;

		public List<FrameCartoonProperty> property = new List<FrameCartoonProperty>();
	}
}
