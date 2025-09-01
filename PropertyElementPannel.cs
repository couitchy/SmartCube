using System;

namespace Guan
{
	// Token: 0x0200004B RID: 75
	[Serializable]
	public class PropertyElementPannel : FrameCartoonProperty
	{
		// Token: 0x040001D1 RID: 465
		public int indexX;

		// Token: 0x040001D2 RID: 466
		public int indexY;

		// Token: 0x040001D3 RID: 467
		public int indexZ;

		// Token: 0x040001D4 RID: 468
		public int startX;

		// Token: 0x040001D5 RID: 469
		public int startY;

		// Token: 0x040001D6 RID: 470
		public int startZ;

		// Token: 0x040001D7 RID: 471
		public int endX;

		// Token: 0x040001D8 RID: 472
		public int endY;

		// Token: 0x040001D9 RID: 473
		public int endZ;

		// Token: 0x040001DA RID: 474
		public bool useIndex;

		// Token: 0x040001DB RID: 475
		public int res;

		// Token: 0x040001DC RID: 476
		public int resIndexStart = 1;

		// Token: 0x040001DD RID: 477
		public int resIndexEnd = 1;

		// Token: 0x040001DE RID: 478
		public PaintFun fun1;

		// Token: 0x040001DF RID: 479
		public PaintMode fun2;

		// Token: 0x040001E0 RID: 480
		public FrameView view;
	}
}
