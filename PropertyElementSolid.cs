using System;

namespace Guan
{
	// Token: 0x0200004C RID: 76
	[Serializable]
	public class PropertyElementSolid : FrameCartoonProperty
	{
		// Token: 0x040001E1 RID: 481
		public int indexX;

		// Token: 0x040001E2 RID: 482
		public int indexY;

		// Token: 0x040001E3 RID: 483
		public int indexZ;

		// Token: 0x040001E4 RID: 484
		public int startX;

		// Token: 0x040001E5 RID: 485
		public int startY;

		// Token: 0x040001E6 RID: 486
		public int startZ;

		// Token: 0x040001E7 RID: 487
		public int endX;

		// Token: 0x040001E8 RID: 488
		public int endY;

		// Token: 0x040001E9 RID: 489
		public int endZ;

		// Token: 0x040001EA RID: 490
		public bool useIndex;

		// Token: 0x040001EB RID: 491
		public int res;

		// Token: 0x040001EC RID: 492
		public int resIndexStart = 1;

		// Token: 0x040001ED RID: 493
		public int resIndexEnd = 1;

		// Token: 0x040001EE RID: 494
		public PaintFun fun1;

		// Token: 0x040001EF RID: 495
		public PaintMode fun2;

		// Token: 0x040001F0 RID: 496
		public FrameView view;
	}
}
