using System;

namespace Guan
{
	[Serializable]
	public class PropertyElementSolid : FrameCartoonProperty
	{
		public int indexX;

		public int indexY;

		public int indexZ;

		public int startX;

		public int startY;

		public int startZ;

		public int endX;

		public int endY;

		public int endZ;

		public bool useIndex;

		public int res;

		public int resIndexStart = 1;

		public int resIndexEnd = 1;

		public PaintFun fun1;

		public PaintMode fun2;

		public FrameView view;
	}
}
