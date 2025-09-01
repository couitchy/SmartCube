using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Guan
{
    public class DX9
    {
        public void SetBright(byte bright)
        {
            if (bright >= 100)
            {
                this.m_colorRed = Color.FromArgb(255, 255, 0, 0);
                this.m_colorGreen = Color.FromArgb(255, 0, 255, 0);
                this.m_colorBlue = Color.FromArgb(255, 0, 0, 255);
            }
            else if (bright == 0)
            {
                this.m_colorRed = Color.FromArgb(255, 0, 0, 0);
                this.m_colorGreen = Color.FromArgb(255, 0, 0, 0);
                this.m_colorBlue = Color.FromArgb(255, 0, 0, 0);
            }
            else
            {
                int val = (int)(byte.MaxValue * bright / 100);
                this.m_colorRed = Color.FromArgb(255, val, 0, 0);
                this.m_colorGreen = Color.FromArgb(255, 0, val, 0);
                this.m_colorBlue = Color.FromArgb(255, 0, 0, val);
            }
            this.m_redMaterial.Diffuse = this.m_colorRed;
            this.m_greenMaterial.Diffuse = this.m_colorGreen;
            this.m_blueMaterial.Diffuse = this.m_colorBlue;
        }

        public void SetPoint(int x, int y, int z, bool flag)
        {
            int num = z * 64 + y * 8 + x;
            this.Pixels[num] = this.FindState(x, y, z, flag);
        }

        public void SetPointNot(int x, int y, int z)
        {
            int num = z * 64 + y * 8 + x;
            this.Pixels[num] = this.FindState(x, y, z, (this.Pixels[num] == PixelState.Off));
        }

        public PixelState GetPoint(int x, int y, int z)
        {
            int num = z * 64 + y * 8 + x;
            return this.Pixels[num];
        }

        private PixelState FindState(int x, int y, int z, bool on)
        {
            if (!on)
            {
                return PixelState.Off;
            }
            else
            {
                if ( x == 0 || x == 7 || z == 0 || z == 7)
                    return PixelState.Blue;
                else if ( z % 2 != 0)
                    return PixelState.Green;
                else
                    return PixelState.Red;
            }
        }

        public void ClrBuffer()
        {
            for (int i = 0; i < 512; i++)
            {
                this.Pixels[i] = PixelState.Off;
            }
        }

        public bool InitializeGraphics(Control control)
        {
            bool flag;
            try
            {
                this.m_parent = control;
                this.device = new Device(0, DeviceType.Hardware, control, CreateFlags.MixedVertexProcessing, new PresentParameters[]
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
                    this.Pixels[i] = PixelState.Off;
                }
                this.m_redMaterial.Diffuse = this.m_colorRed;
                this.m_greenMaterial.Diffuse = this.m_colorGreen;
                this.m_blueMaterial.Diffuse = this.m_colorBlue;
                this.m_offMaterial.Diffuse = this.m_colorOff;
                if (this.m_bigRedSphere == null)
                {
                    this.m_bigRedSphere = Mesh.Sphere(this.device, 1f, 30, 15);
                }
                if (this.m_bigGreenSphere == null)
                {
                    this.m_bigGreenSphere = Mesh.Sphere(this.device, 1f, 30, 15);
                }
                if (this.m_bigBlueSphere == null)
                {
                    this.m_bigBlueSphere = Mesh.Sphere(this.device, 1f, 30, 15);
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

        private void m_parent_Resize(object sender, EventArgs e)
        {
            this.device.Lights[0].Enabled = true;
            if (this.lastSize.Width >= this.m_parent.Size.Width && this.lastSize.Height >= this.m_parent.Size.Height)
            {
                this.OnPaint();
            }
            this.lastSize = this.m_parent.Size;
        }

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

        private void m_parent_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsDown = false;
            this.m_parent.Capture = false;
            this.lastX = this.xx;
            this.lastY = this.yy;
        }

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

        private void m_parent_Paint(object sender, PaintEventArgs e)
        {
            this.OnPaint();
        }

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

        private void RendScene()
        {
            for (int i = 0; i < 512; i++)
            {
                this.SetWorldTransform(this.spherePositions[i].M41, this.spherePositions[i].M42, this.spherePositions[i].M43);
                switch (this.Pixels[i])
                {
                    case PixelState.Off:
                        this.device.Material = this.m_offMaterial;
                        this.m_smallSphere.DrawSubset(0);
                        break;
                    case PixelState.Red:
                        this.device.Material = this.m_redMaterial;
                        this.m_bigRedSphere.DrawSubset(0);
                        break;
                    case PixelState.Green:
                        this.device.Material = this.m_greenMaterial;
                        this.m_bigGreenSphere.DrawSubset(0);
                        break;
                    case PixelState.Blue:
                        this.device.Material = this.m_blueMaterial;
                        this.m_bigBlueSphere.DrawSubset(0);
                        break;
                    default: break;
                }
            }
        }

        private void SetWorldTransform(float x, float y, float z)
        {
            Vector3 vector = new Vector3(0f, -1f, 0f);
            Vector3 vector2 = new Vector3(-1f, 0f, 0f);
            Matrix matrix = Matrix.Translation(x, y, z) * Matrix.RotationAxis(vector, this.xx) * Matrix.Translation(0f, 0f, 0f);
            matrix = matrix * Matrix.RotationAxis(vector2, this.yy) * Matrix.Translation(0f, 0f, 0f);
            this.device.Transform.World = matrix;
        }

        public enum PixelState
        {
            Off,
            Blue,
            Red,
            Green
        }

        private const int sphereNumber = 512;

        private Device device;

        private Mesh m_bigRedSphere;
        private Mesh m_bigGreenSphere;
        private Mesh m_bigBlueSphere;

        private Mesh m_smallSphere;

        private Matrix[] spherePositions;

        private Control m_parent;

        private Material m_redMaterial = new Material();
        private Material m_greenMaterial = new Material();
        private Material m_blueMaterial = new Material();

        private Material m_offMaterial = new Material();

        private Material commonSphereMaterial = new Material();

        private PixelState[] Pixels = new PixelState[512];

        private Size lastSize;

        private Color m_colorRed = Color.Black;
        private Color m_colorGreen = Color.Black;
        private Color m_colorBlue = Color.Black;

        private readonly Color m_colorOff = Color.Black;

        private int m_downX;

        private int m_downY;

        private bool IsDown;

        private float xx;

        private float yy;

        private float lastX;

        private float lastY;

        private float m_wheel = -60f;
    }
}
