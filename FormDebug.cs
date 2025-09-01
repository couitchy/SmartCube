using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x02000035 RID: 53
	public partial class FormDebug : Forms
	{
		// Token: 0x060001CD RID: 461 RVA: 0x00011347 File Offset: 0x0000F547
		private void FormInit(AllResource res)
		{
			this.InitializeComponent();
			this.m_res = res;
			this.m_dx = new DX9();
			this.m_dx.InitializeGraphics(this);
			this.m_dx.SetBright(100);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0001137B File Offset: 0x0000F57B
		public FormDebug(AllResource res)
		{
			this.FormInit(res);
			this.StartDebug();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00011390 File Offset: 0x0000F590
		public FormDebug(AllResource res, FrameCartoonGroup group)
		{
			this.FormInit(res);
			this.m_group = group;
			this.StartDebug();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000113AC File Offset: 0x0000F5AC
		public FormDebug(AllResource res, FrameCartoonControl control)
		{
			this.FormInit(res);
			this.m_control = control;
			this.StartDebug();
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000113C8 File Offset: 0x0000F5C8
		private void StartDebug()
		{
			if (this.m_thread == null || !this.m_thread.IsAlive)
			{
				this.m_thread = new Thread(new ThreadStart(this.ThreadFunction));
				this.m_thread.IsBackground = true;
				this.m_thread.Start();
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00011418 File Offset: 0x0000F618
		private void ThreadFunction()
		{
			byte[] array = new byte[64];
			int num = Environment.TickCount;
			if (this.m_group != null)
			{
				for (;;)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = 0;
					}
					byte b = 100;
					this.m_dx.SetBright(b);
					FrameCartoonGroup group = this.m_group;
					int num2 = 0;
					while ((long)num2 < (long)((ulong)group.frameCount))
					{
						ClassCalc.SingleFrameToDX(array, group, this.m_res.m_res, this.m_res.m_index, num2, this.m_dx);
						int num3 = (int)(group.delay * this.m_res.m_head.defaultSpeed);
						while (Environment.TickCount - num < num3)
						{
							Thread.Sleep(2);
						}
						num = Environment.TickCount;
						num2++;
					}
				}
			}
			else
			{
				if (this.m_control != null)
				{
					for (;;)
					{
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = 0;
						}
						byte b = 100;
						this.m_dx.SetBright(b);
						FrameCartoonControl control = this.m_control;
						using (List<FrameCartoonGroup>.Enumerator enumerator = control.groups.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								FrameCartoonGroup frameCartoonGroup = enumerator.Current;
								int num4 = 0;
								while ((long)num4 < (long)((ulong)frameCartoonGroup.loopCount))
								{
									int num5 = 0;
									while ((long)num5 < (long)((ulong)frameCartoonGroup.frameCount))
									{
										ClassCalc.SingleFrameToDX(array, frameCartoonGroup, this.m_res.m_res, this.m_res.m_index, num5, this.m_dx);
										int num6 = (int)(frameCartoonGroup.delay * this.m_res.m_head.defaultSpeed);
										while (Environment.TickCount - num < num6)
										{
											Thread.Sleep(2);
										}
										num = Environment.TickCount;
										num5++;
									}
									num4++;
								}
							}
							continue;
						}
						break;
					}
				}
				for (;;)
				{
					for (int k = 0; k < array.Length; k++)
					{
						array[k] = 0;
					}
					byte b = 100;
					this.m_dx.SetBright(b);
					foreach (FrameCartoonControl frameCartoonControl in this.m_res.m_control.m_cartoon)
					{
						int num7 = 0;
						while ((long)num7 < (long)((ulong)frameCartoonControl.loopCount))
						{
							foreach (FrameCartoonGroup frameCartoonGroup2 in frameCartoonControl.groups)
							{
								int num8 = 0;
								while ((long)num8 < (long)((ulong)frameCartoonGroup2.loopCount))
								{
									int num9 = 0;
									while ((long)num9 < (long)((ulong)frameCartoonGroup2.frameCount))
									{
										ClassCalc.SingleFrameToDX(array, frameCartoonGroup2, this.m_res.m_res, this.m_res.m_index, num9, this.m_dx);
										int num10 = (int)(frameCartoonGroup2.delay * this.m_res.m_head.defaultSpeed);
										while (Environment.TickCount - num < num10)
										{
											Thread.Sleep(2);
										}
										num = Environment.TickCount;
										num9++;
									}
									num8++;
								}
							}
							num7++;
						}
						Thread.Sleep(2);
					}
				}
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00011780 File Offset: 0x0000F980
		private void FormDebug_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.m_thread.Abort();
		}

		// Token: 0x04000154 RID: 340
		private AllResource m_res;

		// Token: 0x04000155 RID: 341
		private Thread m_thread;

		// Token: 0x04000156 RID: 342
		private DX9 m_dx;

		// Token: 0x04000157 RID: 343
		private FrameCartoonGroup m_group;

		// Token: 0x04000158 RID: 344
		private FrameCartoonControl m_control;
	}
}
