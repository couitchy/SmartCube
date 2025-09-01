using System;
using System.Collections.Generic;

namespace Guan
{
	[Serializable]
	public class FrameControl
	{
		public void Clear()
		{
			this.m_cartoon.Clear();
		}

		public List<FrameCartoonControl> m_cartoon = new List<FrameCartoonControl>();
	}
}
