using System;
using System.Collections.Generic;

namespace Guan
{
	[Serializable]
	public class FrameCartoonControl
	{
		public string name = "";

		public uint loopCount = 1U;

		public List<FrameCartoonGroup> groups = new List<FrameCartoonGroup>();
	}
}
