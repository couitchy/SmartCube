using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x02000011 RID: 17
	public class ControlProperty : UserControl
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000B4 RID: 180 RVA: 0x0000A7D8 File Offset: 0x000089D8
		// (remove) Token: 0x060000B5 RID: 181 RVA: 0x0000A810 File Offset: 0x00008A10
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x060000B6 RID: 182 RVA: 0x0000A848 File Offset: 0x00008A48
		public ControlProperty(FrameResource res, FrameIndex index, FormGuan.FileIsChanged fileIsChanged)
		{
			this.InitializeComponent();
			this.m_res = res;
			this.m_index = index;
			this.m_fileIsChanged = fileIsChanged;
			this.HideStatus();
			this.m_dot = new ControlProperty.DotClass(this.m_index);
			this.m_line = new ControlProperty.LineClass(this.m_index);
			this.m_single = new ControlProperty.SingleClass(this.m_res, this.m_index);
			this.m_solid = new ControlProperty.SolidClass(this.m_res, this.m_index);
			this.m_bright = new ControlProperty.BrightClass();
			this.propertyGrid1.PropertyValueChanged += this.propertyGrid1_PropertyValueChanged;
			this.propertyGrid1.PropertySort = PropertySort.Categorized;
			this.propertyGrid1.ToolbarVisible = false;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000A908 File Offset: 0x00008B08
		public void ResourceUpdate()
		{
			if (this.IsValue)
			{
				try
				{
					this.ShowControl();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000A944 File Offset: 0x00008B44
		private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (!this.IsValue)
			{
				return;
			}
			switch (this.m_staus)
			{
			case FrameCartoonType.dot:
			{
				PropertyElementDot propertyElementDot = (PropertyElementDot)this.m_objBuff;
				if (propertyElementDot.indexX != this.m_dot.indexX)
				{
					if (this.m_dot.indexX == 0)
					{
						this.m_dot.StartX = 0;
						this.m_dot.EndX = 0;
					}
					else
					{
						this.m_dot.StartX = 1;
						this.m_dot.EndX = 1;
					}
					propertyElementDot.indexX = this.m_dot.indexX;
				}
				if (propertyElementDot.indexY != this.m_dot.indexY)
				{
					if (this.m_dot.indexX == 0)
					{
						this.m_dot.StartY = 0;
						this.m_dot.EndY = 0;
					}
					else
					{
						this.m_dot.StartY = 1;
						this.m_dot.EndY = 1;
					}
					propertyElementDot.indexY = this.m_dot.indexY;
				}
				if (propertyElementDot.indexZ != this.m_dot.indexZ)
				{
					if (this.m_dot.indexX == 0)
					{
						this.m_dot.StartZ = 0;
						this.m_dot.EndZ = 0;
					}
					else
					{
						this.m_dot.StartZ = 1;
						this.m_dot.EndZ = 1;
					}
					propertyElementDot.indexZ = this.m_dot.indexZ;
				}
				propertyElementDot.startX = this.m_dot.startX;
				propertyElementDot.startY = this.m_dot.startY;
				propertyElementDot.startZ = this.m_dot.startZ;
				propertyElementDot.endX = this.m_dot.endX;
				propertyElementDot.endY = this.m_dot.endY;
				propertyElementDot.endZ = this.m_dot.endZ;
				propertyElementDot.fun2 = this.m_dot.fun2;
				propertyElementDot.view = this.m_dot.view;
				break;
			}
			case FrameCartoonType.line:
			{
				PropertyElementLine propertyElementLine = (PropertyElementLine)this.m_objBuff;
				if (propertyElementLine.indexX != this.m_line.indexX)
				{
					if (this.m_line.indexX == 0)
					{
						this.m_line.StartX1 = 0;
						this.m_line.EndX1 = 0;
						this.m_line.StartX2 = 0;
						this.m_line.EndX2 = 0;
					}
					else
					{
						this.m_line.StartX1 = 1;
						this.m_line.EndX1 = 1;
						this.m_line.StartX2 = 1;
						this.m_line.EndX2 = 1;
					}
					propertyElementLine.indexX = this.m_line.indexX;
				}
				if (propertyElementLine.indexY != this.m_line.indexY)
				{
					if (this.m_line.indexY == 0)
					{
						this.m_line.StartY1 = 0;
						this.m_line.EndY1 = 0;
						this.m_line.StartY2 = 0;
						this.m_line.EndY2 = 0;
					}
					else
					{
						this.m_line.StartY1 = 1;
						this.m_line.EndY1 = 1;
						this.m_line.StartY2 = 1;
						this.m_line.EndY2 = 1;
					}
					propertyElementLine.indexY = this.m_line.indexY;
				}
				if (propertyElementLine.indexZ != this.m_line.indexZ)
				{
					if (this.m_line.indexZ == 0)
					{
						this.m_line.StartZ1 = 0;
						this.m_line.EndZ1 = 0;
						this.m_line.StartZ2 = 0;
						this.m_line.EndZ2 = 0;
					}
					else
					{
						this.m_line.StartZ1 = 1;
						this.m_line.EndZ1 = 1;
						this.m_line.StartZ2 = 1;
						this.m_line.EndZ2 = 1;
					}
					propertyElementLine.indexZ = this.m_line.indexZ;
				}
				propertyElementLine.startX1 = this.m_line.startX1;
				propertyElementLine.startY1 = this.m_line.startY1;
				propertyElementLine.startZ1 = this.m_line.startZ1;
				propertyElementLine.endX1 = this.m_line.endX1;
				propertyElementLine.endY1 = this.m_line.endY1;
				propertyElementLine.endZ1 = this.m_line.endZ1;
				propertyElementLine.startX2 = this.m_line.startX2;
				propertyElementLine.startY2 = this.m_line.startY2;
				propertyElementLine.startZ2 = this.m_line.startZ2;
				propertyElementLine.endX2 = this.m_line.endX2;
				propertyElementLine.endY2 = this.m_line.endY2;
				propertyElementLine.endZ2 = this.m_line.endZ2;
				propertyElementLine.fun2 = this.m_line.fun2;
				propertyElementLine.view = this.m_line.view;
				break;
			}
			case FrameCartoonType.pannel:
			{
				PropertyElementPannel propertyElementPannel = (PropertyElementPannel)this.m_objBuff;
				if (propertyElementPannel.indexX != this.m_single.indexX)
				{
					if (this.m_single.indexX == 0)
					{
						this.m_single.StartX = 0;
						this.m_single.EndX = 0;
					}
					else
					{
						this.m_single.StartX = 1;
						this.m_single.EndX = 1;
					}
					propertyElementPannel.indexX = this.m_single.indexX;
				}
				if (propertyElementPannel.indexY != this.m_single.indexY)
				{
					if (this.m_single.indexY == 0)
					{
						this.m_single.StartY = 0;
						this.m_single.EndY = 0;
					}
					else
					{
						this.m_single.StartY = 1;
						this.m_single.EndY = 1;
					}
					propertyElementPannel.indexY = this.m_single.indexY;
				}
				if (propertyElementPannel.indexZ != this.m_single.indexZ)
				{
					if (this.m_single.indexZ == 0)
					{
						this.m_single.StartZ = 0;
						this.m_single.EndZ = 0;
					}
					else
					{
						this.m_single.StartZ = 1;
						this.m_single.EndZ = 1;
					}
					propertyElementPannel.indexZ = this.m_single.indexZ;
				}
				if (propertyElementPannel.useIndex != this.m_single.useIndex)
				{
					this.m_single.res = 0;
					this.m_single.resIndexStart = 1;
					this.m_single.resIndexEnd = 1;
					this.m_single.Update();
					propertyElementPannel.useIndex = this.m_single.useIndex;
				}
				if (propertyElementPannel.res != this.m_single.res)
				{
					if (this.m_single.useIndex)
					{
						this.m_single.resIndexStart = 1;
						this.m_single.resIndexEnd = 1;
					}
					propertyElementPannel.res = this.m_single.res;
				}
				propertyElementPannel.startX = this.m_single.startX;
				propertyElementPannel.startY = this.m_single.startY;
				propertyElementPannel.startZ = this.m_single.startZ;
				propertyElementPannel.endX = this.m_single.endX;
				propertyElementPannel.endY = this.m_single.endY;
				propertyElementPannel.endZ = this.m_single.endZ;
				propertyElementPannel.resIndexStart = this.m_single.resIndexStart;
				propertyElementPannel.resIndexEnd = this.m_single.resIndexEnd;
				propertyElementPannel.fun1 = this.m_single.fun1;
				propertyElementPannel.fun2 = this.m_single.fun2;
				propertyElementPannel.view = this.m_single.view;
				break;
			}
			case FrameCartoonType.solid:
			{
				PropertyElementSolid propertyElementSolid = (PropertyElementSolid)this.m_objBuff;
				if (propertyElementSolid.indexX != this.m_solid.indexX)
				{
					if (this.m_solid.indexX == 0)
					{
						this.m_solid.StartX = 0;
						this.m_solid.EndX = 0;
					}
					else
					{
						this.m_solid.StartX = 1;
						this.m_solid.EndX = 1;
					}
					propertyElementSolid.indexX = this.m_solid.indexX;
				}
				if (propertyElementSolid.indexY != this.m_solid.indexY)
				{
					if (this.m_solid.indexY == 0)
					{
						this.m_solid.StartY = 0;
						this.m_solid.EndY = 0;
					}
					else
					{
						this.m_solid.StartY = 1;
						this.m_solid.EndY = 1;
					}
					propertyElementSolid.indexY = this.m_solid.indexY;
				}
				if (propertyElementSolid.indexZ != this.m_solid.indexZ)
				{
					if (this.m_solid.indexZ == 0)
					{
						this.m_solid.StartZ = 0;
						this.m_solid.EndZ = 0;
					}
					else
					{
						this.m_solid.StartZ = 1;
						this.m_solid.EndZ = 1;
					}
					propertyElementSolid.indexZ = this.m_solid.indexZ;
				}
				if (propertyElementSolid.useIndex != this.m_solid.useIndex)
				{
					this.m_solid.res = 0;
					this.m_solid.resIndexStart = 1;
					this.m_solid.resIndexEnd = 1;
					this.m_solid.Update();
					propertyElementSolid.useIndex = this.m_solid.useIndex;
				}
				if (propertyElementSolid.res != this.m_solid.res)
				{
					if (this.m_solid.useIndex)
					{
						this.m_solid.resIndexStart = 1;
						this.m_solid.resIndexEnd = 1;
					}
					propertyElementSolid.res = this.m_solid.res;
				}
				propertyElementSolid.startX = this.m_solid.startX;
				propertyElementSolid.startY = this.m_solid.startY;
				propertyElementSolid.startZ = this.m_solid.startZ;
				propertyElementSolid.endX = this.m_solid.endX;
				propertyElementSolid.endY = this.m_solid.endY;
				propertyElementSolid.endZ = this.m_solid.endZ;
				propertyElementSolid.resIndexStart = this.m_solid.resIndexStart;
				propertyElementSolid.resIndexEnd = this.m_solid.resIndexEnd;
				propertyElementSolid.fun1 = this.m_solid.fun1;
				propertyElementSolid.fun2 = this.m_solid.fun2;
				propertyElementSolid.view = this.m_solid.view;
				break;
			}
			case FrameCartoonType.bright:
			{
				PropertyElementBright propertyElementBright = (PropertyElementBright)this.m_objBuff;
				propertyElementBright.startBright = this.m_bright.StartBright;
				propertyElementBright.endBright = this.m_bright.EndBright;
				break;
			}
			}
			if (this.m_fileIsChanged != null)
			{
				this.m_fileIsChanged(true);
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B369 File Offset: 0x00009569
		public void ShowStatus(FrameCartoonType type, FrameCartoonProperty obj)
		{
			this.m_staus = type;
			this.m_objBuff = obj;
			this.IsValue = true;
			this.ShowControl();
			base.Visible = true;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000B38D File Offset: 0x0000958D
		public void HideStatus()
		{
			this.IsValue = false;
			base.Visible = false;
			this.propertyGrid1.SelectedObject = null;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B3AC File Offset: 0x000095AC
		private void ShowControl()
		{
			switch (this.m_staus)
			{
			case FrameCartoonType.dot:
			{
				PropertyElementDot propertyElementDot = (PropertyElementDot)this.m_objBuff;
				this.m_dot.indexX = propertyElementDot.indexX;
				this.m_dot.indexY = propertyElementDot.indexY;
				this.m_dot.indexZ = propertyElementDot.indexZ;
				this.m_dot.startX = propertyElementDot.startX;
				this.m_dot.startY = propertyElementDot.startY;
				this.m_dot.startZ = propertyElementDot.startZ;
				this.m_dot.endX = propertyElementDot.endX;
				this.m_dot.endY = propertyElementDot.endY;
				this.m_dot.endZ = propertyElementDot.endZ;
				this.m_dot.fun2 = propertyElementDot.fun2;
				this.m_dot.view = propertyElementDot.view;
				this.m_dot.Update();
				this.propertyGrid1.SelectedObject = this.m_dot;
				return;
			}
			case FrameCartoonType.line:
			{
				PropertyElementLine propertyElementLine = (PropertyElementLine)this.m_objBuff;
				this.m_line.indexX = propertyElementLine.indexX;
				this.m_line.indexY = propertyElementLine.indexY;
				this.m_line.indexZ = propertyElementLine.indexZ;
				this.m_line.startX1 = propertyElementLine.startX1;
				this.m_line.startY1 = propertyElementLine.startY1;
				this.m_line.startZ1 = propertyElementLine.startZ1;
				this.m_line.endX1 = propertyElementLine.endX1;
				this.m_line.endY1 = propertyElementLine.endY1;
				this.m_line.endZ1 = propertyElementLine.endZ1;
				this.m_line.startX2 = propertyElementLine.startX2;
				this.m_line.startY2 = propertyElementLine.startY2;
				this.m_line.startZ2 = propertyElementLine.startZ2;
				this.m_line.endX2 = propertyElementLine.endX2;
				this.m_line.endY2 = propertyElementLine.endY2;
				this.m_line.endZ2 = propertyElementLine.endZ2;
				this.m_line.fun2 = propertyElementLine.fun2;
				this.m_line.view = propertyElementLine.view;
				this.m_line.Update();
				this.propertyGrid1.SelectedObject = this.m_line;
				return;
			}
			case FrameCartoonType.pannel:
			{
				PropertyElementPannel propertyElementPannel = (PropertyElementPannel)this.m_objBuff;
				this.m_single.indexX = propertyElementPannel.indexX;
				this.m_single.indexY = propertyElementPannel.indexY;
				this.m_single.indexZ = propertyElementPannel.indexZ;
				this.m_single.startX = propertyElementPannel.startX;
				this.m_single.startY = propertyElementPannel.startY;
				this.m_single.startZ = propertyElementPannel.startZ;
				this.m_single.endX = propertyElementPannel.endX;
				this.m_single.endY = propertyElementPannel.endY;
				this.m_single.endZ = propertyElementPannel.endZ;
				this.m_single.useIndex = propertyElementPannel.useIndex;
				this.m_single.res = propertyElementPannel.res;
				this.m_single.resIndexStart = propertyElementPannel.resIndexStart;
				this.m_single.resIndexEnd = propertyElementPannel.resIndexEnd;
				this.m_single.fun1 = propertyElementPannel.fun1;
				this.m_single.fun2 = propertyElementPannel.fun2;
				this.m_single.view = propertyElementPannel.view;
				this.m_single.Update();
				this.propertyGrid1.SelectedObject = this.m_single;
				return;
			}
			case FrameCartoonType.solid:
			{
				PropertyElementSolid propertyElementSolid = (PropertyElementSolid)this.m_objBuff;
				this.m_solid.indexX = propertyElementSolid.indexX;
				this.m_solid.indexY = propertyElementSolid.indexY;
				this.m_solid.indexZ = propertyElementSolid.indexZ;
				this.m_solid.startX = propertyElementSolid.startX;
				this.m_solid.startY = propertyElementSolid.startY;
				this.m_solid.startZ = propertyElementSolid.startZ;
				this.m_solid.endX = propertyElementSolid.endX;
				this.m_solid.endY = propertyElementSolid.endY;
				this.m_solid.endZ = propertyElementSolid.endZ;
				this.m_solid.res = propertyElementSolid.res;
				this.m_solid.fun1 = propertyElementSolid.fun1;
				this.m_solid.fun2 = propertyElementSolid.fun2;
				this.m_solid.view = propertyElementSolid.view;
				this.m_solid.Update();
				this.propertyGrid1.SelectedObject = this.m_solid;
				return;
			}
			case FrameCartoonType.bright:
			{
				PropertyElementBright propertyElementBright = (PropertyElementBright)this.m_objBuff;
				this.m_bright.StartBright = propertyElementBright.startBright;
				this.m_bright.EndBright = propertyElementBright.endBright;
				this.propertyGrid1.SelectedObject = this.m_bright;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B88C File Offset: 0x00009A8C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000B8AC File Offset: 0x00009AAC
		private void InitializeComponent()
		{
			this.propertyGrid1 = new PropertyGrid();
			base.SuspendLayout();
			this.propertyGrid1.Dock = DockStyle.Fill;
			this.propertyGrid1.Location = new Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new Size(235, 247);
			this.propertyGrid1.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoScroll = true;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Controls.Add(this.propertyGrid1);
			base.Name = "ControlProperty";
			base.Size = new Size(235, 247);
			base.ResumeLayout(false);
		}

		// Token: 0x0400005D RID: 93
		private FrameCartoonType m_staus;

		// Token: 0x0400005E RID: 94
		private bool IsValue;

		// Token: 0x0400005F RID: 95
		private FrameCartoonProperty m_objBuff;

		// Token: 0x04000060 RID: 96
		private FrameResource m_res;

		// Token: 0x04000061 RID: 97
		private FrameIndex m_index;

		// Token: 0x04000063 RID: 99
		private ControlProperty.DotClass m_dot;

		// Token: 0x04000064 RID: 100
		private ControlProperty.LineClass m_line;

		// Token: 0x04000065 RID: 101
		private ControlProperty.SingleClass m_single;

		// Token: 0x04000066 RID: 102
		private ControlProperty.SolidClass m_solid;

		// Token: 0x04000067 RID: 103
		private ControlProperty.BrightClass m_bright;

		// Token: 0x04000068 RID: 104
		private IContainer components;

		// Token: 0x04000069 RID: 105
		private PropertyGrid propertyGrid1;

		// Token: 0x02000012 RID: 18
		private class BrightClass
		{
			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060000BF RID: 191 RVA: 0x0000B992 File Offset: 0x00009B92
			// (set) Token: 0x060000BE RID: 190 RVA: 0x0000B980 File Offset: 0x00009B80
			[Category("Brightness property")]
			[Description("Bright value of start")]
			public int StartBright
			{
				get
				{
					return this.startValue;
				}
				set
				{
					if (value >= 0 && value <= 100)
					{
						this.startValue = value;
					}
				}
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000B9AC File Offset: 0x00009BAC
			// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000B99A File Offset: 0x00009B9A
			[Description("Bright value of end")]
			[Category("Brightness property")]
			public int EndBright
			{
				get
				{
					return this.endValue;
				}
				set
				{
					if (value >= 0 && value <= 100)
					{
						this.endValue = value;
					}
				}
			}

			// Token: 0x0400006A RID: 106
			private int startValue;

			// Token: 0x0400006B RID: 107
			private int endValue;
		}

		// Token: 0x02000013 RID: 19
		private class DotClass
		{
			// Token: 0x060000C3 RID: 195 RVA: 0x0000B9BC File Offset: 0x00009BBC
			public DotClass(FrameIndex index)
			{
				this.m_index = index;
				this.Update();
			}

			// Token: 0x060000C4 RID: 196 RVA: 0x0000B9DC File Offset: 0x00009BDC
			public void Update()
			{
				this.strBuffX.Clear();
				this.strBuffX.Add("Not use index talbe");
				foreach (ResourceIndex resourceIndex in this.m_index.m_indexNumber)
				{
					this.strBuffX.Add(resourceIndex.name);
				}
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000BA5C File Offset: 0x00009C5C
			// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000BA6F File Offset: 0x00009C6F
			[Category("Location X")]
			[TypeConverter(typeof(ControlProperty.DotClass.MeterAddressConverter))]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_X
			{
				get
				{
					return this.strBuffX[this.indexX];
				}
				set
				{
					this.indexX = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x060000C7 RID: 199 RVA: 0x0000BA83 File Offset: 0x00009C83
			private bool GetValue(int index, int value)
			{
				if (index == 0)
				{
					if (value <= 7 && value >= -7)
					{
						return true;
					}
				}
				else if (value > 0 && value <= this.m_index.m_indexNumber[index - 1].m_element.Count)
				{
					return true;
				}
				return false;
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000BAD2 File Offset: 0x00009CD2
			// (set) Token: 0x060000C8 RID: 200 RVA: 0x0000BABA File Offset: 0x00009CBA
			[Description("")]
			[Category("Location X")]
			public int StartX
			{
				get
				{
					return this.startX;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.startX = value;
					}
				}
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060000CB RID: 203 RVA: 0x0000BAF2 File Offset: 0x00009CF2
			// (set) Token: 0x060000CA RID: 202 RVA: 0x0000BADA File Offset: 0x00009CDA
			[Category("Location X")]
			public int EndX
			{
				get
				{
					return this.endX;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.endX = value;
					}
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000CC RID: 204 RVA: 0x0000BAFA File Offset: 0x00009CFA
			// (set) Token: 0x060000CD RID: 205 RVA: 0x0000BB0D File Offset: 0x00009D0D
			[TypeConverter(typeof(ControlProperty.DotClass.MeterAddressConverter))]
			[Category("Location Y")]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_Y
			{
				get
				{
					return this.strBuffX[this.indexY];
				}
				set
				{
					this.indexY = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000CF RID: 207 RVA: 0x0000BB39 File Offset: 0x00009D39
			// (set) Token: 0x060000CE RID: 206 RVA: 0x0000BB21 File Offset: 0x00009D21
			[Category("Location Y")]
			public int StartY
			{
				get
				{
					return this.startY;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.startY = value;
					}
				}
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000BB59 File Offset: 0x00009D59
			// (set) Token: 0x060000D0 RID: 208 RVA: 0x0000BB41 File Offset: 0x00009D41
			[Category("Location Y")]
			public int EndY
			{
				get
				{
					return this.endY;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.endY = value;
					}
				}
			}

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060000D2 RID: 210 RVA: 0x0000BB61 File Offset: 0x00009D61
			// (set) Token: 0x060000D3 RID: 211 RVA: 0x0000BB74 File Offset: 0x00009D74
			[Category("Location Z")]
			[Description("Using the index table, the following values for the index number")]
			[TypeConverter(typeof(ControlProperty.DotClass.MeterAddressConverter))]
			public string UseIndexTable_Z
			{
				get
				{
					return this.strBuffX[this.indexZ];
				}
				set
				{
					this.indexZ = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000BBA0 File Offset: 0x00009DA0
			// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000BB88 File Offset: 0x00009D88
			[Category("Location Z")]
			public int StartZ
			{
				get
				{
					return this.startZ;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.startZ = value;
					}
				}
			}

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000BBC0 File Offset: 0x00009DC0
			// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000BBA8 File Offset: 0x00009DA8
			[Category("Location Z")]
			public int EndZ
			{
				get
				{
					return this.endZ;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.endZ = value;
					}
				}
			}

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000BBC8 File Offset: 0x00009DC8
			// (set) Token: 0x060000D9 RID: 217 RVA: 0x0000BBD0 File Offset: 0x00009DD0
			[Description("X, Y, Z reference surface")]
			[Category("Property")]
			public ControlProperty.DotClass.viewEnum Angle_of_view
			{
				get
				{
					return (ControlProperty.DotClass.viewEnum)this.view;
				}
				set
				{
					this.view = (FrameView)value;
				}
			}

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000DA RID: 218 RVA: 0x0000BBD9 File Offset: 0x00009DD9
			// (set) Token: 0x060000DB RID: 219 RVA: 0x0000BBE1 File Offset: 0x00009DE1
			[Category("Property")]
			[Description("Display mode")]
			public ControlProperty.DotClass.funEnum DisplayMode
			{
				get
				{
					return (ControlProperty.DotClass.funEnum)this.fun2;
				}
				set
				{
					this.fun2 = (PaintMode)value;
				}
			}

			// Token: 0x0400006C RID: 108
			private FrameIndex m_index;

			// Token: 0x0400006D RID: 109
			public int indexX;

			// Token: 0x0400006E RID: 110
			public int indexY;

			// Token: 0x0400006F RID: 111
			public int indexZ;

			// Token: 0x04000070 RID: 112
			public int startX;

			// Token: 0x04000071 RID: 113
			public int startY;

			// Token: 0x04000072 RID: 114
			public int startZ;

			// Token: 0x04000073 RID: 115
			public int endX;

			// Token: 0x04000074 RID: 116
			public int endY;

			// Token: 0x04000075 RID: 117
			public int endZ;

			// Token: 0x04000076 RID: 118
			public List<string> strBuffX = new List<string>();

			// Token: 0x04000077 RID: 119
			public PaintMode fun2;

			// Token: 0x04000078 RID: 120
			public FrameView view;

			// Token: 0x02000014 RID: 20
			public class MeterAddressConverter : StringConverter
			{
				// Token: 0x060000DC RID: 220 RVA: 0x0000BBEA File Offset: 0x00009DEA
				public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
				{
					return true;
				}

				// Token: 0x060000DD RID: 221 RVA: 0x0000BBED File Offset: 0x00009DED
				public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
				{
					return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.DotClass).strBuffX);
				}

				// Token: 0x060000DE RID: 222 RVA: 0x0000BC04 File Offset: 0x00009E04
				public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
				{
					return true;
				}
			}

			// Token: 0x02000015 RID: 21
			public enum viewEnum
			{
				// Token: 0x0400007A RID: 122
				FrontView,
				// Token: 0x0400007B RID: 123
				TopView,
				// Token: 0x0400007C RID: 124
				LeftView
			}

			// Token: 0x02000016 RID: 22
			public enum funEnum
			{
				// Token: 0x0400007E RID: 126
				Set,
				// Token: 0x0400007F RID: 127
				Clr,
				// Token: 0x04000080 RID: 128
				Not
			}
		}

		// Token: 0x02000017 RID: 23
		private class LineClass
		{
			// Token: 0x060000E0 RID: 224 RVA: 0x0000BC0F File Offset: 0x00009E0F
			public LineClass(FrameIndex index)
			{
				this.m_index = index;
				this.Update();
			}

			// Token: 0x060000E1 RID: 225 RVA: 0x0000BC30 File Offset: 0x00009E30
			public void Update()
			{
				this.strBuffX.Clear();
				this.strBuffX.Add("Not use index talbe");
				foreach (ResourceIndex resourceIndex in this.m_index.m_indexNumber)
				{
					this.strBuffX.Add(resourceIndex.name);
				}
			}

			// Token: 0x060000E2 RID: 226 RVA: 0x0000BCB0 File Offset: 0x00009EB0
			private bool GetValue(int index, int value)
			{
				if (index == 0)
				{
					if (value <= 15 && value >= -15)
					{
						return true;
					}
				}
				else if (value > 0 && value <= this.m_index.m_indexNumber[index - 1].m_element.Count)
				{
					return true;
				}
				return false;
			}

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000BCE8 File Offset: 0x00009EE8
			// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000BCFB File Offset: 0x00009EFB
			[TypeConverter(typeof(ControlProperty.LineClass.MeterAddressConverter))]
			[Category("Location X")]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_X
			{
				get
				{
					return this.strBuffX[this.indexX];
				}
				set
				{
					this.indexX = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000BD27 File Offset: 0x00009F27
			// (set) Token: 0x060000E5 RID: 229 RVA: 0x0000BD0F File Offset: 0x00009F0F
			[Category("Location X")]
			[Description("Line start X")]
			public int StartX1
			{
				get
				{
					return this.startX1;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.startX1 = value;
					}
				}
			}

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000E8 RID: 232 RVA: 0x0000BD47 File Offset: 0x00009F47
			// (set) Token: 0x060000E7 RID: 231 RVA: 0x0000BD2F File Offset: 0x00009F2F
			[Category("Location X")]
			[Description("Line end X")]
			public int StartX2
			{
				get
				{
					return this.startX2;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.startX2 = value;
					}
				}
			}

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000EA RID: 234 RVA: 0x0000BD67 File Offset: 0x00009F67
			// (set) Token: 0x060000E9 RID: 233 RVA: 0x0000BD4F File Offset: 0x00009F4F
			[Description("Line start X")]
			[Category("Location X")]
			public int EndX1
			{
				get
				{
					return this.endX1;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.endX1 = value;
					}
				}
			}

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060000EC RID: 236 RVA: 0x0000BD87 File Offset: 0x00009F87
			// (set) Token: 0x060000EB RID: 235 RVA: 0x0000BD6F File Offset: 0x00009F6F
			[Category("Location X")]
			[Description("Line end X")]
			public int EndX2
			{
				get
				{
					return this.endX2;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.endX2 = value;
					}
				}
			}

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060000ED RID: 237 RVA: 0x0000BD8F File Offset: 0x00009F8F
			// (set) Token: 0x060000EE RID: 238 RVA: 0x0000BDA2 File Offset: 0x00009FA2
			[Description("Using the index table, the following values for the index number")]
			[Category("Location Y")]
			[TypeConverter(typeof(ControlProperty.LineClass.MeterAddressConverter))]
			public string UseIndexTable_Y
			{
				get
				{
					return this.strBuffX[this.indexY];
				}
				set
				{
					this.indexY = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x060000F0 RID: 240 RVA: 0x0000BDCE File Offset: 0x00009FCE
			// (set) Token: 0x060000EF RID: 239 RVA: 0x0000BDB6 File Offset: 0x00009FB6
			[Category("Location Y")]
			[Description("Line start Y")]
			public int StartY1
			{
				get
				{
					return this.startY1;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.startY1 = value;
					}
				}
			}

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060000F2 RID: 242 RVA: 0x0000BDEE File Offset: 0x00009FEE
			// (set) Token: 0x060000F1 RID: 241 RVA: 0x0000BDD6 File Offset: 0x00009FD6
			[Description("Line end Y")]
			[Category("Location Y")]
			public int StartY2
			{
				get
				{
					return this.startY2;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.startY2 = value;
					}
				}
			}

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000BE0E File Offset: 0x0000A00E
			// (set) Token: 0x060000F3 RID: 243 RVA: 0x0000BDF6 File Offset: 0x00009FF6
			[Description("Line start Y")]
			[Category("Location Y")]
			public int EndY1
			{
				get
				{
					return this.endY1;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.endY1 = value;
					}
				}
			}

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000BE2E File Offset: 0x0000A02E
			// (set) Token: 0x060000F5 RID: 245 RVA: 0x0000BE16 File Offset: 0x0000A016
			[Description("Line end Y")]
			[Category("Location Y")]
			public int EndY2
			{
				get
				{
					return this.endY2;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.endY2 = value;
					}
				}
			}

			// Token: 0x17000039 RID: 57
			// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000BE36 File Offset: 0x0000A036
			// (set) Token: 0x060000F8 RID: 248 RVA: 0x0000BE49 File Offset: 0x0000A049
			[Category("Location Z")]
			[TypeConverter(typeof(ControlProperty.LineClass.MeterAddressConverter))]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_Z
			{
				get
				{
					return this.strBuffX[this.indexZ];
				}
				set
				{
					this.indexZ = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060000FA RID: 250 RVA: 0x0000BE75 File Offset: 0x0000A075
			// (set) Token: 0x060000F9 RID: 249 RVA: 0x0000BE5D File Offset: 0x0000A05D
			[Category("Location Z")]
			[Description("Line start Z")]
			public int StartZ1
			{
				get
				{
					return this.startZ1;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.startZ1 = value;
					}
				}
			}

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060000FC RID: 252 RVA: 0x0000BE95 File Offset: 0x0000A095
			// (set) Token: 0x060000FB RID: 251 RVA: 0x0000BE7D File Offset: 0x0000A07D
			[Description("Line end Z")]
			[Category("Location Z")]
			public int StartZ2
			{
				get
				{
					return this.startZ2;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.startZ2 = value;
					}
				}
			}

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060000FE RID: 254 RVA: 0x0000BEB5 File Offset: 0x0000A0B5
			// (set) Token: 0x060000FD RID: 253 RVA: 0x0000BE9D File Offset: 0x0000A09D
			[Description("Line start Z")]
			[Category("Location Z")]
			public int EndZ1
			{
				get
				{
					return this.endZ1;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.endZ1 = value;
					}
				}
			}

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x06000100 RID: 256 RVA: 0x0000BED5 File Offset: 0x0000A0D5
			// (set) Token: 0x060000FF RID: 255 RVA: 0x0000BEBD File Offset: 0x0000A0BD
			[Category("Location Z")]
			[Description("Line end Z")]
			public int EndZ2
			{
				get
				{
					return this.endZ2;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.endZ2 = value;
					}
				}
			}

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x06000101 RID: 257 RVA: 0x0000BEDD File Offset: 0x0000A0DD
			// (set) Token: 0x06000102 RID: 258 RVA: 0x0000BEE5 File Offset: 0x0000A0E5
			[Category("Property")]
			[Description("X, Y, Z reference surface")]
			public ControlProperty.LineClass.viewEnum Angle_of_view
			{
				get
				{
					return (ControlProperty.LineClass.viewEnum)this.view;
				}
				set
				{
					this.view = (FrameView)value;
				}
			}

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x06000103 RID: 259 RVA: 0x0000BEEE File Offset: 0x0000A0EE
			// (set) Token: 0x06000104 RID: 260 RVA: 0x0000BEF6 File Offset: 0x0000A0F6
			[Category("Property")]
			[Description("Display mode")]
			public ControlProperty.LineClass.funEnum DisplayMode
			{
				get
				{
					return (ControlProperty.LineClass.funEnum)this.fun2;
				}
				set
				{
					this.fun2 = (PaintMode)value;
				}
			}

			// Token: 0x04000081 RID: 129
			private FrameIndex m_index;

			// Token: 0x04000082 RID: 130
			public int indexX;

			// Token: 0x04000083 RID: 131
			public int indexY;

			// Token: 0x04000084 RID: 132
			public int indexZ;

			// Token: 0x04000085 RID: 133
			public int startX1;

			// Token: 0x04000086 RID: 134
			public int startY1;

			// Token: 0x04000087 RID: 135
			public int startZ1;

			// Token: 0x04000088 RID: 136
			public int endX1;

			// Token: 0x04000089 RID: 137
			public int endY1;

			// Token: 0x0400008A RID: 138
			public int endZ1;

			// Token: 0x0400008B RID: 139
			public int startX2;

			// Token: 0x0400008C RID: 140
			public int startY2;

			// Token: 0x0400008D RID: 141
			public int startZ2;

			// Token: 0x0400008E RID: 142
			public int endX2;

			// Token: 0x0400008F RID: 143
			public int endY2;

			// Token: 0x04000090 RID: 144
			public int endZ2;

			// Token: 0x04000091 RID: 145
			public List<string> strBuffX = new List<string>();

			// Token: 0x04000092 RID: 146
			public PaintMode fun2;

			// Token: 0x04000093 RID: 147
			public FrameView view;

			// Token: 0x02000018 RID: 24
			public class MeterAddressConverter : StringConverter
			{
				// Token: 0x06000105 RID: 261 RVA: 0x0000BEFF File Offset: 0x0000A0FF
				public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
				{
					return true;
				}

				// Token: 0x06000106 RID: 262 RVA: 0x0000BF02 File Offset: 0x0000A102
				public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
				{
					return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.LineClass).strBuffX);
				}

				// Token: 0x06000107 RID: 263 RVA: 0x0000BF19 File Offset: 0x0000A119
				public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
				{
					return true;
				}
			}

			// Token: 0x02000019 RID: 25
			public enum viewEnum
			{
				// Token: 0x04000095 RID: 149
				FrontView,
				// Token: 0x04000096 RID: 150
				TopView,
				// Token: 0x04000097 RID: 151
				LeftView
			}

			// Token: 0x0200001A RID: 26
			public enum funEnum
			{
				// Token: 0x04000099 RID: 153
				Set,
				// Token: 0x0400009A RID: 154
				Clr,
				// Token: 0x0400009B RID: 155
				Not
			}
		}

		// Token: 0x0200001B RID: 27
		private class SingleClass
		{
			// Token: 0x06000109 RID: 265 RVA: 0x0000BF24 File Offset: 0x0000A124
			public SingleClass(FrameResource res, FrameIndex index)
			{
				this.m_res = res;
				this.m_index = index;
				this.Update();
			}

			// Token: 0x0600010A RID: 266 RVA: 0x0000BF64 File Offset: 0x0000A164
			public void Update()
			{
				this.strBuffX.Clear();
				this.strBuffX.Add("Not use index talbe");
				foreach (ResourceIndex resourceIndex in this.m_index.m_indexNumber)
				{
					this.strBuffX.Add(resourceIndex.name);
				}
				this.strBuff2.Clear();
				this.strBuff2.Add("Null");
				if (this.useIndex)
				{
					using (List<ResourceIndex>.Enumerator enumerator2 = this.m_index.m_indexSingle.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							ResourceIndex resourceIndex2 = enumerator2.Current;
							this.strBuff2.Add(resourceIndex2.name);
						}
						return;
					}
				}
				foreach (ResourceSingle resourceSingle in this.m_res.m_resSingle)
				{
					this.strBuff2.Add(resourceSingle.name);
				}
			}

			// Token: 0x0600010B RID: 267 RVA: 0x0000C0A8 File Offset: 0x0000A2A8
			private bool GetValue(int index, int value)
			{
				if (index == 0)
				{
					if (value <= 7 && value >= -7)
					{
						return true;
					}
				}
				else if (value > 0 && value <= this.m_index.m_indexNumber[index - 1].m_element.Count)
				{
					return true;
				}
				return false;
			}

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x0600010C RID: 268 RVA: 0x0000C0DF File Offset: 0x0000A2DF
			// (set) Token: 0x0600010D RID: 269 RVA: 0x0000C0F2 File Offset: 0x0000A2F2
			[Category("Location X")]
			[Description("Using the index table, the following values for the index number")]
			[TypeConverter(typeof(ControlProperty.SingleClass.MeterAddressConverter))]
			public string UseIndexTable_X
			{
				get
				{
					return this.strBuffX[this.indexX];
				}
				set
				{
					this.indexX = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x0600010F RID: 271 RVA: 0x0000C11E File Offset: 0x0000A31E
			// (set) Token: 0x0600010E RID: 270 RVA: 0x0000C106 File Offset: 0x0000A306
			[Category("Location X")]
			[Description("")]
			public int StartX
			{
				get
				{
					return this.startX;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.startX = value;
					}
				}
			}

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x06000111 RID: 273 RVA: 0x0000C13E File Offset: 0x0000A33E
			// (set) Token: 0x06000110 RID: 272 RVA: 0x0000C126 File Offset: 0x0000A326
			[Category("Location X")]
			public int EndX
			{
				get
				{
					return this.endX;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.endX = value;
					}
				}
			}

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x06000112 RID: 274 RVA: 0x0000C146 File Offset: 0x0000A346
			// (set) Token: 0x06000113 RID: 275 RVA: 0x0000C159 File Offset: 0x0000A359
			[TypeConverter(typeof(ControlProperty.SingleClass.MeterAddressConverter))]
			[Description("Using the index table, the following values for the index number")]
			[Category("Location Y")]
			public string UseIndexTable_Y
			{
				get
				{
					return this.strBuffX[this.indexY];
				}
				set
				{
					this.indexY = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x06000115 RID: 277 RVA: 0x0000C185 File Offset: 0x0000A385
			// (set) Token: 0x06000114 RID: 276 RVA: 0x0000C16D File Offset: 0x0000A36D
			[Category("Location Y")]
			public int StartY
			{
				get
				{
					return this.startY;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.startY = value;
					}
				}
			}

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x06000117 RID: 279 RVA: 0x0000C1A5 File Offset: 0x0000A3A5
			// (set) Token: 0x06000116 RID: 278 RVA: 0x0000C18D File Offset: 0x0000A38D
			[Category("Location Y")]
			public int EndY
			{
				get
				{
					return this.endY;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.endY = value;
					}
				}
			}

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x06000118 RID: 280 RVA: 0x0000C1AD File Offset: 0x0000A3AD
			// (set) Token: 0x06000119 RID: 281 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
			[Category("Location Z")]
			[Description("Using the index table, the following values for the index number")]
			[TypeConverter(typeof(ControlProperty.SingleClass.MeterAddressConverter))]
			public string UseIndexTable_Z
			{
				get
				{
					return this.strBuffX[this.indexZ];
				}
				set
				{
					this.indexZ = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x0600011B RID: 283 RVA: 0x0000C1EC File Offset: 0x0000A3EC
			// (set) Token: 0x0600011A RID: 282 RVA: 0x0000C1D4 File Offset: 0x0000A3D4
			[Category("Location Z")]
			public int StartZ
			{
				get
				{
					return this.startZ;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.startZ = value;
					}
				}
			}

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x0600011D RID: 285 RVA: 0x0000C20C File Offset: 0x0000A40C
			// (set) Token: 0x0600011C RID: 284 RVA: 0x0000C1F4 File Offset: 0x0000A3F4
			[Category("Location Z")]
			public int EndZ
			{
				get
				{
					return this.endZ;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.endZ = value;
					}
				}
			}

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x0600011E RID: 286 RVA: 0x0000C214 File Offset: 0x0000A414
			// (set) Token: 0x0600011F RID: 287 RVA: 0x0000C221 File Offset: 0x0000A421
			[Description("Using the index table, resource using the index table;Do not use the index table, using the graphical resources")]
			[Category("Resource")]
			public ControlProperty.SingleClass.useIndexEnum UseIndexTable
			{
				get
				{
					if (!this.useIndex)
					{
						return ControlProperty.SingleClass.useIndexEnum.No;
					}
					return ControlProperty.SingleClass.useIndexEnum.Yes;
				}
				set
				{
					this.useIndex = value == ControlProperty.SingleClass.useIndexEnum.Yes;
				}
			}

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x06000120 RID: 288 RVA: 0x0000C231 File Offset: 0x0000A431
			// (set) Token: 0x06000121 RID: 289 RVA: 0x0000C244 File Offset: 0x0000A444
			[Category("Resource")]
			[TypeConverter(typeof(ControlProperty.SingleClass.MeterAddressConverter2))]
			public string ResourceName
			{
				get
				{
					return this.strBuff2[this.res];
				}
				set
				{
					this.res = this.strBuff2.IndexOf(value);
				}
			}

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x06000122 RID: 290 RVA: 0x0000C258 File Offset: 0x0000A458
			// (set) Token: 0x06000123 RID: 291 RVA: 0x0000C260 File Offset: 0x0000A460
			[Category("Resource")]
			[Description("Do not use the index table, the value is invalid")]
			public int StartIndex
			{
				get
				{
					return this.resIndexStart;
				}
				set
				{
					if (this.useIndex && this.res != 0 && value > 0 && value <= this.m_index.m_indexSingle[this.res - 1].m_element.Count)
					{
						this.resIndexStart = value;
					}
				}
			}

			// Token: 0x1700004C RID: 76
			// (get) Token: 0x06000124 RID: 292 RVA: 0x0000C2AD File Offset: 0x0000A4AD
			// (set) Token: 0x06000125 RID: 293 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
			[Description("Do not use the index table, the value is invalid")]
			[Category("Resource")]
			public int EndIndex
			{
				get
				{
					return this.resIndexEnd;
				}
				set
				{
					if (this.useIndex && this.res != 0 && value > 0 && value <= this.m_index.m_indexSingle[this.res - 1].m_element.Count)
					{
						this.resIndexEnd = value;
					}
				}
			}

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x06000126 RID: 294 RVA: 0x0000C305 File Offset: 0x0000A505
			// (set) Token: 0x06000127 RID: 295 RVA: 0x0000C30D File Offset: 0x0000A50D
			[Category("Property")]
			[Description("X, Y, Z reference surface")]
			public ControlProperty.SingleClass.viewEnum Angle_of_view
			{
				get
				{
					return (ControlProperty.SingleClass.viewEnum)this.view;
				}
				set
				{
					this.view = (FrameView)value;
				}
			}

			// Token: 0x1700004E RID: 78
			// (get) Token: 0x06000128 RID: 296 RVA: 0x0000C316 File Offset: 0x0000A516
			// (set) Token: 0x06000129 RID: 297 RVA: 0x0000C31E File Offset: 0x0000A51E
			[Category("Property")]
			[Description("Display mode")]
			public ControlProperty.SingleClass.Fun2Enum DisplayMode
			{
				get
				{
					return (ControlProperty.SingleClass.Fun2Enum)this.fun2;
				}
				set
				{
					this.fun2 = (PaintMode)value;
				}
			}

			// Token: 0x1700004F RID: 79
			// (get) Token: 0x0600012A RID: 298 RVA: 0x0000C327 File Offset: 0x0000A527
			// (set) Token: 0x0600012B RID: 299 RVA: 0x0000C32F File Offset: 0x0000A52F
			[Description("Display function")]
			[Category("Property")]
			public ControlProperty.SingleClass.Fun1Enum Function
			{
				get
				{
					return (ControlProperty.SingleClass.Fun1Enum)this.fun1;
				}
				set
				{
					this.fun1 = (PaintFun)value;
				}
			}

			// Token: 0x0400009C RID: 156
			private FrameResource m_res;

			// Token: 0x0400009D RID: 157
			private FrameIndex m_index;

			// Token: 0x0400009E RID: 158
			public int indexX;

			// Token: 0x0400009F RID: 159
			public int indexY;

			// Token: 0x040000A0 RID: 160
			public int indexZ;

			// Token: 0x040000A1 RID: 161
			public int startX;

			// Token: 0x040000A2 RID: 162
			public int startY;

			// Token: 0x040000A3 RID: 163
			public int startZ;

			// Token: 0x040000A4 RID: 164
			public int endX;

			// Token: 0x040000A5 RID: 165
			public int endY;

			// Token: 0x040000A6 RID: 166
			public int endZ;

			// Token: 0x040000A7 RID: 167
			public bool useIndex;

			// Token: 0x040000A8 RID: 168
			public int res;

			// Token: 0x040000A9 RID: 169
			public int resIndexStart = 1;

			// Token: 0x040000AA RID: 170
			public int resIndexEnd = 1;

			// Token: 0x040000AB RID: 171
			public List<string> strBuffX = new List<string>();

			// Token: 0x040000AC RID: 172
			public List<string> strBuff2 = new List<string>();

			// Token: 0x040000AD RID: 173
			public PaintMode fun2;

			// Token: 0x040000AE RID: 174
			public PaintFun fun1;

			// Token: 0x040000AF RID: 175
			public FrameView view;

			// Token: 0x0200001C RID: 28
			public class MeterAddressConverter : StringConverter
			{
				// Token: 0x0600012C RID: 300 RVA: 0x0000C338 File Offset: 0x0000A538
				public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
				{
					return true;
				}

				// Token: 0x0600012D RID: 301 RVA: 0x0000C33B File Offset: 0x0000A53B
				public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
				{
					return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SingleClass).strBuffX);
				}

				// Token: 0x0600012E RID: 302 RVA: 0x0000C352 File Offset: 0x0000A552
				public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
				{
					return true;
				}
			}

			// Token: 0x0200001D RID: 29
			public enum useIndexEnum
			{
				// Token: 0x040000B1 RID: 177
				No,
				// Token: 0x040000B2 RID: 178
				Yes
			}

			// Token: 0x0200001E RID: 30
			public class MeterAddressConverter2 : StringConverter
			{
				// Token: 0x06000130 RID: 304 RVA: 0x0000C35D File Offset: 0x0000A55D
				public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
				{
					return true;
				}

				// Token: 0x06000131 RID: 305 RVA: 0x0000C360 File Offset: 0x0000A560
				public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
				{
					return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SingleClass).strBuff2);
				}

				// Token: 0x06000132 RID: 306 RVA: 0x0000C377 File Offset: 0x0000A577
				public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
				{
					return true;
				}
			}

			// Token: 0x0200001F RID: 31
			public enum viewEnum
			{
				// Token: 0x040000B4 RID: 180
				FrontView,
				// Token: 0x040000B5 RID: 181
				TopView,
				// Token: 0x040000B6 RID: 182
				LeftView
			}

			// Token: 0x02000020 RID: 32
			public enum Fun1Enum
			{
				// Token: 0x040000B8 RID: 184
				Null,
				// Token: 0x040000B9 RID: 185
				Rotate90,
				// Token: 0x040000BA RID: 186
				Rotate180,
				// Token: 0x040000BB RID: 187
				Rotate270,
				// Token: 0x040000BC RID: 188
				AboutMirror,
				// Token: 0x040000BD RID: 189
				UpDownMirror
			}

			// Token: 0x02000021 RID: 33
			public enum Fun2Enum
			{
				// Token: 0x040000BF RID: 191
				Set,
				// Token: 0x040000C0 RID: 192
				Clr,
				// Token: 0x040000C1 RID: 193
				Not,
				// Token: 0x040000C2 RID: 194
				Copy
			}
		}

		// Token: 0x02000022 RID: 34
		private class SolidClass
		{
			// Token: 0x06000134 RID: 308 RVA: 0x0000C382 File Offset: 0x0000A582
			public SolidClass(FrameResource res, FrameIndex index)
			{
				this.m_res = res;
				this.m_index = index;
				this.Update();
			}

			// Token: 0x06000135 RID: 309 RVA: 0x0000C3C4 File Offset: 0x0000A5C4
			public void Update()
			{
				this.strBuffX.Clear();
				this.strBuffX.Add("Not use index talbe");
				foreach (ResourceIndex resourceIndex in this.m_index.m_indexNumber)
				{
					this.strBuffX.Add(resourceIndex.name);
				}
				this.strBuff2.Clear();
				this.strBuff2.Add("Null");
				if (this.useIndex)
				{
					using (List<ResourceIndex>.Enumerator enumerator2 = this.m_index.m_indexSolid.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							ResourceIndex resourceIndex2 = enumerator2.Current;
							this.strBuff2.Add(resourceIndex2.name);
						}
						return;
					}
				}
				foreach (ResourceSolid resourceSolid in this.m_res.m_resSolid)
				{
					this.strBuff2.Add(resourceSolid.name);
				}
			}

			// Token: 0x06000136 RID: 310 RVA: 0x0000C508 File Offset: 0x0000A708
			private bool GetValue(int index, int value)
			{
				if (index == 0)
				{
					if (value <= 7 && value >= -7)
					{
						return true;
					}
				}
				else if (value > 0 && value <= this.m_index.m_indexNumber[index - 1].m_element.Count)
				{
					return true;
				}
				return false;
			}

			// Token: 0x17000050 RID: 80
			// (get) Token: 0x06000137 RID: 311 RVA: 0x0000C53F File Offset: 0x0000A73F
			// (set) Token: 0x06000138 RID: 312 RVA: 0x0000C552 File Offset: 0x0000A752
			[TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter))]
			[Category("Location X")]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_X
			{
				get
				{
					return this.strBuffX[this.indexX];
				}
				set
				{
					this.indexX = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000051 RID: 81
			// (get) Token: 0x0600013A RID: 314 RVA: 0x0000C57E File Offset: 0x0000A77E
			// (set) Token: 0x06000139 RID: 313 RVA: 0x0000C566 File Offset: 0x0000A766
			[Description("")]
			[Category("Location X")]
			public int StartX
			{
				get
				{
					return this.startX;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.startX = value;
					}
				}
			}

			// Token: 0x17000052 RID: 82
			// (get) Token: 0x0600013C RID: 316 RVA: 0x0000C59E File Offset: 0x0000A79E
			// (set) Token: 0x0600013B RID: 315 RVA: 0x0000C586 File Offset: 0x0000A786
			[Category("Location X")]
			public int EndX
			{
				get
				{
					return this.endX;
				}
				set
				{
					if (this.GetValue(this.indexX, value))
					{
						this.endX = value;
					}
				}
			}

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x0600013D RID: 317 RVA: 0x0000C5A6 File Offset: 0x0000A7A6
			// (set) Token: 0x0600013E RID: 318 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
			[TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter))]
			[Category("Location Y")]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_Y
			{
				get
				{
					return this.strBuffX[this.indexY];
				}
				set
				{
					this.indexY = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x06000140 RID: 320 RVA: 0x0000C5E5 File Offset: 0x0000A7E5
			// (set) Token: 0x0600013F RID: 319 RVA: 0x0000C5CD File Offset: 0x0000A7CD
			[Category("Location Y")]
			public int StartY
			{
				get
				{
					return this.startY;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.startY = value;
					}
				}
			}

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x06000142 RID: 322 RVA: 0x0000C605 File Offset: 0x0000A805
			// (set) Token: 0x06000141 RID: 321 RVA: 0x0000C5ED File Offset: 0x0000A7ED
			[Category("Location Y")]
			public int EndY
			{
				get
				{
					return this.endY;
				}
				set
				{
					if (this.GetValue(this.indexY, value))
					{
						this.endY = value;
					}
				}
			}

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x06000143 RID: 323 RVA: 0x0000C60D File Offset: 0x0000A80D
			// (set) Token: 0x06000144 RID: 324 RVA: 0x0000C620 File Offset: 0x0000A820
			[TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter))]
			[Category("Location Z")]
			[Description("Using the index table, the following values for the index number")]
			public string UseIndexTable_Z
			{
				get
				{
					return this.strBuffX[this.indexZ];
				}
				set
				{
					this.indexZ = this.strBuffX.IndexOf(value);
				}
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x06000146 RID: 326 RVA: 0x0000C64C File Offset: 0x0000A84C
			// (set) Token: 0x06000145 RID: 325 RVA: 0x0000C634 File Offset: 0x0000A834
			[Category("Location Z")]
			public int StartZ
			{
				get
				{
					return this.startZ;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.startZ = value;
					}
				}
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x06000148 RID: 328 RVA: 0x0000C66C File Offset: 0x0000A86C
			// (set) Token: 0x06000147 RID: 327 RVA: 0x0000C654 File Offset: 0x0000A854
			[Category("Location Z")]
			public int EndZ
			{
				get
				{
					return this.endZ;
				}
				set
				{
					if (this.GetValue(this.indexZ, value))
					{
						this.endZ = value;
					}
				}
			}

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x06000149 RID: 329 RVA: 0x0000C674 File Offset: 0x0000A874
			// (set) Token: 0x0600014A RID: 330 RVA: 0x0000C681 File Offset: 0x0000A881
			[Category("Resource")]
			[Description("Using the index table, resource using the index table;Do not use the index table, using the graphical resources")]
			public ControlProperty.SolidClass.useIndexEnum UseIndexTable
			{
				get
				{
					if (!this.useIndex)
					{
						return ControlProperty.SolidClass.useIndexEnum.No;
					}
					return ControlProperty.SolidClass.useIndexEnum.Yes;
				}
				set
				{
					this.useIndex = value == ControlProperty.SolidClass.useIndexEnum.Yes;
				}
			}

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x0600014B RID: 331 RVA: 0x0000C691 File Offset: 0x0000A891
			// (set) Token: 0x0600014C RID: 332 RVA: 0x0000C6A4 File Offset: 0x0000A8A4
			[TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter2))]
			[Category("Resource")]
			public string ResourceName
			{
				get
				{
					return this.strBuff2[this.res];
				}
				set
				{
					this.res = this.strBuff2.IndexOf(value);
				}
			}

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x0600014D RID: 333 RVA: 0x0000C6B8 File Offset: 0x0000A8B8
			// (set) Token: 0x0600014E RID: 334 RVA: 0x0000C6C0 File Offset: 0x0000A8C0
			[Description("Do not use the index table, the value is invalid")]
			[Category("Resource")]
			public int StartIndex
			{
				get
				{
					return this.resIndexStart;
				}
				set
				{
					if (this.useIndex && this.res != 0 && value > 0 && value <= this.m_index.m_indexSolid[this.res - 1].m_element.Count)
					{
						this.resIndexStart = value;
					}
				}
			}

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600014F RID: 335 RVA: 0x0000C70D File Offset: 0x0000A90D
			// (set) Token: 0x06000150 RID: 336 RVA: 0x0000C718 File Offset: 0x0000A918
			[Description("Do not use the index table, the value is invalid")]
			[Category("Resource")]
			public int EndIndex
			{
				get
				{
					return this.resIndexEnd;
				}
				set
				{
					if (this.useIndex && this.res != 0 && value > 0 && value <= this.m_index.m_indexSolid[this.res - 1].m_element.Count)
					{
						this.resIndexEnd = value;
					}
				}
			}

			// Token: 0x1700005D RID: 93
			// (get) Token: 0x06000151 RID: 337 RVA: 0x0000C765 File Offset: 0x0000A965
			// (set) Token: 0x06000152 RID: 338 RVA: 0x0000C76D File Offset: 0x0000A96D
			[Category("Property")]
			[Description("X, Y, Z reference surface")]
			public ControlProperty.SolidClass.viewEnum Angle_of_view
			{
				get
				{
					return (ControlProperty.SolidClass.viewEnum)this.view;
				}
				set
				{
					this.view = (FrameView)value;
				}
			}

			// Token: 0x1700005E RID: 94
			// (get) Token: 0x06000153 RID: 339 RVA: 0x0000C776 File Offset: 0x0000A976
			// (set) Token: 0x06000154 RID: 340 RVA: 0x0000C77E File Offset: 0x0000A97E
			[Category("Property")]
			[Description("Display mode")]
			public ControlProperty.SolidClass.Fun2Enum DisplayMode
			{
				get
				{
					return (ControlProperty.SolidClass.Fun2Enum)this.fun2;
				}
				set
				{
					this.fun2 = (PaintMode)value;
				}
			}

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x06000155 RID: 341 RVA: 0x0000C787 File Offset: 0x0000A987
			// (set) Token: 0x06000156 RID: 342 RVA: 0x0000C78F File Offset: 0x0000A98F
			[Description("Display function")]
			[Category("Property")]
			public ControlProperty.SolidClass.Fun1Enum Function
			{
				get
				{
					return (ControlProperty.SolidClass.Fun1Enum)this.fun1;
				}
				set
				{
					this.fun1 = (PaintFun)value;
				}
			}

			// Token: 0x040000C3 RID: 195
			private FrameResource m_res;

			// Token: 0x040000C4 RID: 196
			private FrameIndex m_index;

			// Token: 0x040000C5 RID: 197
			public int indexX;

			// Token: 0x040000C6 RID: 198
			public int indexY;

			// Token: 0x040000C7 RID: 199
			public int indexZ;

			// Token: 0x040000C8 RID: 200
			public int startX;

			// Token: 0x040000C9 RID: 201
			public int startY;

			// Token: 0x040000CA RID: 202
			public int startZ;

			// Token: 0x040000CB RID: 203
			public int endX;

			// Token: 0x040000CC RID: 204
			public int endY;

			// Token: 0x040000CD RID: 205
			public int endZ;

			// Token: 0x040000CE RID: 206
			public bool useIndex;

			// Token: 0x040000CF RID: 207
			public int res;

			// Token: 0x040000D0 RID: 208
			public int resIndexStart = 1;

			// Token: 0x040000D1 RID: 209
			public int resIndexEnd = 1;

			// Token: 0x040000D2 RID: 210
			public List<string> strBuffX = new List<string>();

			// Token: 0x040000D3 RID: 211
			public List<string> strBuff2 = new List<string>();

			// Token: 0x040000D4 RID: 212
			public PaintMode fun2;

			// Token: 0x040000D5 RID: 213
			public PaintFun fun1;

			// Token: 0x040000D6 RID: 214
			public FrameView view;

			// Token: 0x02000023 RID: 35
			public class MeterAddressConverter : StringConverter
			{
				// Token: 0x06000157 RID: 343 RVA: 0x0000C798 File Offset: 0x0000A998
				public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
				{
					return true;
				}

				// Token: 0x06000158 RID: 344 RVA: 0x0000C79B File Offset: 0x0000A99B
				public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
				{
					return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SolidClass).strBuffX);
				}

				// Token: 0x06000159 RID: 345 RVA: 0x0000C7B2 File Offset: 0x0000A9B2
				public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
				{
					return true;
				}
			}

			// Token: 0x02000024 RID: 36
			public enum useIndexEnum
			{
				// Token: 0x040000D8 RID: 216
				No,
				// Token: 0x040000D9 RID: 217
				Yes
			}

			// Token: 0x02000025 RID: 37
			public class MeterAddressConverter2 : StringConverter
			{
				// Token: 0x0600015B RID: 347 RVA: 0x0000C7BD File Offset: 0x0000A9BD
				public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
				{
					return true;
				}

				// Token: 0x0600015C RID: 348 RVA: 0x0000C7C0 File Offset: 0x0000A9C0
				public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
				{
					return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SolidClass).strBuff2);
				}

				// Token: 0x0600015D RID: 349 RVA: 0x0000C7D7 File Offset: 0x0000A9D7
				public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
				{
					return true;
				}
			}

			// Token: 0x02000026 RID: 38
			public enum viewEnum
			{
				// Token: 0x040000DB RID: 219
				FrontView,
				// Token: 0x040000DC RID: 220
				TopView,
				// Token: 0x040000DD RID: 221
				LeftView
			}

			// Token: 0x02000027 RID: 39
			public enum Fun1Enum
			{
				// Token: 0x040000DF RID: 223
				Null,
				// Token: 0x040000E0 RID: 224
				Rotate90,
				// Token: 0x040000E1 RID: 225
				Rotate180,
				// Token: 0x040000E2 RID: 226
				Rotate270,
				// Token: 0x040000E3 RID: 227
				AboutMirror,
				// Token: 0x040000E4 RID: 228
				UpDownMirror
			}

			// Token: 0x02000028 RID: 40
			public enum Fun2Enum
			{
				// Token: 0x040000E6 RID: 230
				Set,
				// Token: 0x040000E7 RID: 231
				Clr,
				// Token: 0x040000E8 RID: 232
				Not,
				// Token: 0x040000E9 RID: 233
				Copy
			}
		}
	}
}
