using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Guan
{
	// Token: 0x02000031 RID: 49
	public class DX9
	{
		// Token: 0x060001AE RID: 430 RVA: 0x0000FE28 File Offset: 0x0000E028
		public void SetBright(byte bright)
		{
			if (bright >= 100)
			{
				this.m_colorTrue = Color.FromArgb(255, 255, 0, 0);
			}
			else if (bright == 0)
			{
				this.m_colorTrue = Color.FromArgb(255, 0, 0, 0);
			}
			else
			{
				this.m_colorTrue = Color.FromArgb(255, (int)(byte.MaxValue * bright / 100), 0, 0);
			}
			this.m_bigMaterial.Diffuse = this.m_colorTrue;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000FE98 File Offset: 0x0000E098
		public void SetPoint(int x, int y, int z, bool flag)
		{
			int num = z * 64 + y * 8 + x;
			this.IsOnFlag[num] = flag;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000FEBC File Offset: 0x0000E0BC
		public void SetPointNot(int x, int y, int z)
		{
			int num = z * 64 + y * 8 + x;
			this.IsOnFlag[num] = !this.IsOnFlag[num];
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
		public bool GetPoint(int x, int y, int z)
		{
			int num = z * 64 + y * 8 + x;
			return this.IsOnFlag[num];
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000FF08 File Offset: 0x0000E108
		public void ClrBuffer()
		{
			for (int i = 0; i < 512; i++)
			{
				this.IsOnFlag[i] = false;
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000FF30 File Offset: 0x0000E130
		public bool InitializeGraphics(Control control)
		{
			bool flag;
			try
			{
				this.m_parent = control;
				this.device = new Device(0, DeviceType.Hardware, control, CreateFlags.SoftwareVertexProcessing, new PresentParameters[]
				{
					new PresentParameters
					{
						Windowed = true,
						SwapEffect = SwapEffect.Discard,
						AutoDepthStencilFormat = DepthFormat.D16,
						EnableAutoDepthStencil = true
					}
				});
				this.device.RenderState.ZBufferEnable = true;
				for (int i = 0; i < 512; i++)
				{
					this.IsOnFlag[i] = false;
				}
				this.m_bigMaterial.Diffuse = this.m_colorTrue;
				this.m_smallMaterial.Diffuse = this.m_colorFalse;
				if (this.m_bigSphere == null)
				{
					this.m_bigSphere = Mesh.Sphere(this.device, 1f, 30, 15);
				}
				if (this.m_smallSphere == null)
				{
					this.m_smallSphere = Mesh.Sphere(this.device, 0.2f, 30, 15);
				}
				this.BuildspherePositions();
				this.device.RenderState.Lighting = true;
				this.device.RenderState.Ambient = Color.White;
				this.commonSphereMaterial.Diffuse = Color.Red;
				this.commonSphereMaterial.Ambient = Color.Black;
				this.device.RenderState.Ambient = Color.White;
				this.device.Lights[0].Type = LightType.Directional;
				this.device.Lights[0].Direction = new Vector3(0f, 0f, 1f);
				this.device.Lights[0].Range = 500f;
				this.device.Lights[0].Enabled = true;
				this.m_parent.Paint += this.m_parent_Paint;
				this.m_parent.MouseDown += this.m_parent_MouseDown;
				this.m_parent.MouseMove += this.m_parent_MouseMove;
				this.m_parent.MouseUp += this.m_parent_MouseUp;
				this.m_parent.MouseWheel += this.m_parent_MouseWheel;
				this.m_parent.Resize += this.m_parent_Resize;
				this.lastSize = this.m_parent.Size;
				flag = true;
			}
			catch (DirectXException)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000101B4 File Offset: 0x0000E3B4
		private void m_parent_Resize(object sender, EventArgs e)
		{
			this.device.Lights[0].Enabled = true;
			if (this.lastSize.Width >= this.m_parent.Size.Width && this.lastSize.Height >= this.m_parent.Size.Height)
			{
				this.OnPaint();
			}
			this.lastSize = this.m_parent.Size;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00010230 File Offset: 0x0000E430
		private void m_parent_MouseWheel(object sender, MouseEventArgs e)
		{
			this.m_wheel += (float)(0.01 * (double)e.Delta);
			if (this.m_wheel > -35f)
			{
				this.m_wheel = -35f;
			}
			else if (this.m_wheel < -80f)
			{
				this.m_wheel = -80f;
			}
			this.OnPaint();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00010294 File Offset: 0x0000E494
		private void m_parent_MouseUp(object sender, MouseEventArgs e)
		{
			this.IsDown = false;
			this.m_parent.Capture = false;
			this.lastX = this.xx;
			this.lastY = this.yy;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000102C4 File Offset: 0x0000E4C4
		private void m_parent_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.IsDown)
			{
				this.xx = (float)(0.01 * (double)(e.X - this.m_downX) + (double)this.lastX);
				if ((double)this.xx > 1.0)
				{
					this.xx = 1f;
				}
				else if ((double)this.xx < -1.0)
				{
					this.xx = -1f;
				}
				this.yy = (float)(0.01 * (double)(e.Y - this.m_downY) + (double)this.lastY);
				if ((double)this.yy > 1.0)
				{
					this.yy = 1f;
				}
				else if ((double)this.yy < -1.0)
				{
					this.yy = -1f;
				}
				this.OnPaint();
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000103B8 File Offset: 0x0000E5B8
		private void m_parent_MouseDown(object sender, MouseEventArgs e)
		{
			this.m_parent.Focus();
			if (e.Button == MouseButtons.Left)
			{
				this.m_downX = e.X;
				this.m_downY = e.Y;
				this.IsDown = true;
				this.m_parent.Capture = true;
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00010409 File Offset: 0x0000E609
		private void m_parent_Paint(object sender, PaintEventArgs e)
		{
			this.OnPaint();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00010414 File Offset: 0x0000E614
		private void BuildspherePositions()
		{
			if (this.spherePositions == null)
			{
				this.spherePositions = new Matrix[512];
				for (int i = 0; i < this.spherePositions.Length; i++)
				{
					this.spherePositions[i] = Matrix.Translation((float)(-12.0 + 3.0 * (double)(i % 64 % 8)), (float)(-12.0 + 3.0 * (double)(i % 64 / 8)), (float)(-12.0 + 3.0 * (double)(i / 64)));
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000104B8 File Offset: 0x0000E6B8
		private void SetupCamera()
		{
			float num = 0.7853982f;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 200f;
			this.device.Transform.Projection = Matrix.PerspectiveFovLH(num, num2, num3, num4);
			Vector3 vector = new Vector3(0f, 0f, this.m_wheel);
			Vector3 vector2 = new Vector3(0f, 0f, 0f);
			Vector3 vector3 = new Vector3(0f, 1f, 0f);
			this.device.Transform.View = Matrix.LookAtLH(vector, vector2, vector3);
			this.device.RenderState.FillMode = FillMode.Solid;
			this.device.RenderState.CullMode = Cull.CounterClockwise;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00010578 File Offset: 0x0000E778
		public void OnPaint()
		{
			if (this.m_parent.Visible)
			{
				try
				{
					if (this.m_parent.Width > 0 && this.m_parent.Height > 0)
					{
						this.device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.DarkSeaGreen, 1f, 0);
						this.SetupCamera();
						this.device.BeginScene();
						this.RendScene();
						this.device.EndScene();
						this.device.Present();
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0001060C File Offset: 0x0000E80C
		private void RendScene()
		{
			for (int i = 0; i < 512; i++)
			{
				this.SetWorldTransform(this.spherePositions[i].M41, this.spherePositions[i].M42, this.spherePositions[i].M43);
				if (this.IsOnFlag[i])
				{
					this.device.Material = this.m_bigMaterial;
					this.m_bigSphere.DrawSubset(0);
				}
				else
				{
					this.device.Material = this.m_smallMaterial;
					this.m_smallSphere.DrawSubset(0);
				}
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000106B0 File Offset: 0x0000E8B0
		private void SetWorldTransform(float x, float y, float z)
		{
			Vector3 vector = new Vector3(0f, -1f, 0f);
			Vector3 vector2 = new Vector3(-1f, 0f, 0f);
			Matrix matrix = Matrix.Translation(x, y, z) * Matrix.RotationAxis(vector, this.xx) * Matrix.Translation(0f, 0f, 0f);
			matrix = matrix * Matrix.RotationAxis(vector2, this.yy) * Matrix.Translation(0f, 0f, 0f);
			this.device.Transform.World = matrix;
		}

		// Token: 0x0400012B RID: 299
		private const int sphereNumber = 512;

		// Token: 0x0400012C RID: 300
		private Device device;

		// Token: 0x0400012D RID: 301
		private Mesh m_bigSphere;

		// Token: 0x0400012E RID: 302
		private Mesh m_smallSphere;

		// Token: 0x0400012F RID: 303
		private Matrix[] spherePositions;

		// Token: 0x04000130 RID: 304
		private Control m_parent;

		// Token: 0x04000131 RID: 305
		private Material m_bigMaterial = new Material();

		// Token: 0x04000132 RID: 306
		private Material m_smallMaterial = new Material();

		// Token: 0x04000133 RID: 307
		private Material commonSphereMaterial = new Material();

		// Token: 0x04000134 RID: 308
		private bool[] IsOnFlag = new bool[512];

		// Token: 0x04000135 RID: 309
		private Size lastSize;

		// Token: 0x04000136 RID: 310
		private Color m_colorTrue = Color.Black;

		// Token: 0x04000137 RID: 311
		private readonly Color m_colorFalse = Color.Black;

		// Token: 0x04000138 RID: 312
		private int m_downX;

		// Token: 0x04000139 RID: 313
		private int m_downY;

		// Token: 0x0400013A RID: 314
		private bool IsDown;

		// Token: 0x0400013B RID: 315
		private float xx;

		// Token: 0x0400013C RID: 316
		private float yy;

		// Token: 0x0400013D RID: 317
		private float lastX;

		// Token: 0x0400013E RID: 318
		private float lastY;

		// Token: 0x0400013F RID: 319
		private float m_wheel = -60f;
	}
}
