using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlProperty : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

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

        public void ShowStatus(FrameCartoonType type, FrameCartoonProperty obj)
        {
            this.m_staus = type;
            this.m_objBuff = obj;
            this.IsValue = true;
            this.ShowControl();
            base.Visible = true;
        }

        public void HideStatus()
        {
            this.IsValue = false;
            base.Visible = false;
            this.propertyGrid1.SelectedObject = null;
        }

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

        private FrameCartoonType m_staus;

        private bool IsValue;

        private FrameCartoonProperty m_objBuff;

        private FrameResource m_res;

        private FrameIndex m_index;

        private ControlProperty.DotClass m_dot;

        private ControlProperty.LineClass m_line;

        private ControlProperty.SingleClass m_single;

        private ControlProperty.SolidClass m_solid;

        private ControlProperty.BrightClass m_bright;

        private PropertyGrid propertyGrid1;

        private class BrightClass
        {
            [Category("Brightness property")]
            [Description("Brightness value start")]
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

            [Category("Brightness property")]
            [Description("Brightness value end")]
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

            private int startValue;

            private int endValue;
        }

        private class DotClass
        {
            public DotClass(FrameIndex index)
            {
                this.m_index = index;
                this.Update();
            }

            public void Update()
            {
                this.strBuffX.Clear();
                this.strBuffX.Add("Index table not in use");
                foreach (ResourceIndex resourceIndex in this.m_index.m_indexNumber)
                {
                    this.strBuffX.Add(resourceIndex.name);
                }
            }

            [Category("Location X")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.DotClass.MeterAddressConverter))]
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

            [Category("Location Y")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.DotClass.MeterAddressConverter))]
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

            [Category("Location Z")]
            [Description("Using the index table, following value as index")]
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

            [Category("Property")]
            [Description("X, Y, Z reference surface")]
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

            private FrameIndex m_index;

            public int indexX;

            public int indexY;

            public int indexZ;

            public int startX;

            public int startY;

            public int startZ;

            public int endX;

            public int endY;

            public int endZ;

            public List<string> strBuffX = new List<string>();

            public PaintMode fun2;

            public FrameView view;

            public class MeterAddressConverter : StringConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }

                public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.DotClass).strBuffX);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
            }

            public enum viewEnum
            {
                FrontView,
                TopView,
                LeftView
            }

            public enum funEnum
            {
                Set,
                Clr,
                Not
            }
        }

        private class LineClass
        {
            public LineClass(FrameIndex index)
            {
                this.m_index = index;
                this.Update();
            }

            public void Update()
            {
                this.strBuffX.Clear();
                this.strBuffX.Add("Index table not in use");
                foreach (ResourceIndex resourceIndex in this.m_index.m_indexNumber)
                {
                    this.strBuffX.Add(resourceIndex.name);
                }
            }

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

            [Category("Location X")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.LineClass.MeterAddressConverter))]
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

            [Category("Location Y")]
            [Description("Using the index table, following value as index")]
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

            [Category("Location Y")]
            [Description("Line end Y")]
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

            [Category("Location Y")]
            [Description("Line start Y")]
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

            [Category("Location Y")]
            [Description("Line end Y")]
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

            [Category("Location Z")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.LineClass.MeterAddressConverter))]
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

            [Category("Location Z")]
            [Description("Line end Z")]
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

            [Category("Location Z")]
            [Description("Line start Z")]
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

            private FrameIndex m_index;

            public int indexX;

            public int indexY;

            public int indexZ;

            public int startX1;

            public int startY1;

            public int startZ1;

            public int endX1;

            public int endY1;

            public int endZ1;

            public int startX2;

            public int startY2;

            public int startZ2;

            public int endX2;

            public int endY2;

            public int endZ2;

            public List<string> strBuffX = new List<string>();

            public PaintMode fun2;

            public FrameView view;

            public class MeterAddressConverter : StringConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }

                public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.LineClass).strBuffX);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
            }

            public enum viewEnum
            {
                FrontView,
                TopView,
                LeftView
            }

            public enum funEnum
            {
                Set,
                Clr,
                Not
            }
        }

        private class SingleClass
        {
            public SingleClass(FrameResource res, FrameIndex index)
            {
                this.m_res = res;
                this.m_index = index;
                this.Update();
            }

            public void Update()
            {
                this.strBuffX.Clear();
                this.strBuffX.Add("Index table not in use");
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

            [Category("Location X")]
            [Description("Using the index table, following value as index")]
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

            [Category("Location Y")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.SingleClass.MeterAddressConverter))]
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

            [Category("Location Z")]
            [Description("Using the index table, following value as index")]
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

            [Category("Resource")]
            [Description("Use the index table or use the graphical resources")]
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

            [Category("Resource")]
            [Description("Do not use the index table, invalid value")]
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

            [Category("Resource")]
            [Description("Do not use the index table, invalid value")]
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

            [Category("Property")]
            [Description("Display function")]
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

            private FrameResource m_res;

            private FrameIndex m_index;

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

            public List<string> strBuffX = new List<string>();

            public List<string> strBuff2 = new List<string>();

            public PaintMode fun2;

            public PaintFun fun1;

            public FrameView view;

            public class MeterAddressConverter : StringConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }

                public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SingleClass).strBuffX);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
            }

            public enum useIndexEnum
            {
                No,
                Yes
            }

            public class MeterAddressConverter2 : StringConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }

                public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SingleClass).strBuff2);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
            }

            public enum viewEnum
            {
                FrontView,
                TopView,
                LeftView
            }

            public enum Fun1Enum
            {
                Null,
                Rotate90,
                Rotate180,
                Rotate270,
                AboutMirror,
                UpDownMirror
            }

            public enum Fun2Enum
            {
                Set,
                Clr,
                Not,
                Copy
            }
        }

        private class SolidClass
        {
            public SolidClass(FrameResource res, FrameIndex index)
            {
                this.m_res = res;
                this.m_index = index;
                this.Update();
            }

            public void Update()
            {
                this.strBuffX.Clear();
                this.strBuffX.Add("Index table not in use");
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

            [Category("Location X")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter))]
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

            [Category("Location Y")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter))]
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

            [Category("Location Z")]
            [Description("Using the index table, following value as index")]
            [TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter))]
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

            [Category("Resource")]
            [Description("Use the index table or use the graphical resources")]
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

            [Category("Resource")]
            [TypeConverter(typeof(ControlProperty.SolidClass.MeterAddressConverter2))]
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

            [Category("Resource")]
            [Description("Do not use the index table, invalid value")]
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

            [Category("Resource")]
            [Description("Do not use the index table, invalid value")]
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

            [Category("Property")]
            [Description("Display function")]
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

            private FrameResource m_res;

            private FrameIndex m_index;

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

            public List<string> strBuffX = new List<string>();

            public List<string> strBuff2 = new List<string>();

            public PaintMode fun2;

            public PaintFun fun1;

            public FrameView view;

            public class MeterAddressConverter : StringConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }

                public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SolidClass).strBuffX);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
            }

            public enum useIndexEnum
            {
                No,
                Yes
            }

            public class MeterAddressConverter2 : StringConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }

                public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    return new TypeConverter.StandardValuesCollection((context.Instance as ControlProperty.SolidClass).strBuff2);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
            }

            public enum viewEnum
            {
                FrontView,
                TopView,
                LeftView
            }

            public enum Fun1Enum
            {
                Null,
                Rotate90,
                Rotate180,
                Rotate270,
                AboutMirror,
                UpDownMirror
            }

            public enum Fun2Enum
            {
                Set,
                Clr,
                Not,
                Copy
            }
        }
    }
}
