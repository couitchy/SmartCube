using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlEdit : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public ControlEdit(DX9 dx, AllResource res, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.m_dx = dx;
            this.m_res = res;
            this.m_fileIsChanged = fileIsChanged;
            this.tabControlEdit.Visible = false;
            this.buttonClose.Visible = false;
            this.buttonCloseAll.Visible = false;
            this.buttonClose.Click += this.buttonClose_Click;
            this.buttonCloseAll.Click += this.buttonCloseAll_Click;
        }

        private void buttonCloseAll_Click(object sender, EventArgs e)
        {
            this.CloseAll();
        }

        public void CloseAll()
        {
            this.m_list.Clear();
            this.tabControlEdit.TabPages.Clear();
            this.buttonClose.Visible = false;
            this.buttonCloseAll.Visible = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = this.tabControlEdit.SelectedTab;
            ControlEdit.ListClass listClass = this.IsInList(selectedTab);
            this.tabControlEdit.TabPages.Remove(selectedTab);
            this.m_list.Remove(listClass);
            if (this.m_list.Count == 0)
            {
                this.tabControlEdit.Visible = false;
                this.buttonClose.Visible = false;
                this.buttonCloseAll.Visible = false;
            }
        }

        private ControlEdit.ListClass IsInList(object obj)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.obj.Equals(obj))
                {
                    return listClass;
                }
            }
            return null;
        }

        private ControlEdit.ListClass IsInList(TabPage page)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.page.Equals(page))
                {
                    return listClass;
                }
            }
            return null;
        }

        private bool ResInList(object res)
        {
            ControlEdit.ListClass listClass = this.IsInList(res);
            if (listClass != null)
            {
                this.tabControlEdit.SelectedTab = listClass.page;
                return true;
            }
            return false;
        }

        private void AddOnePannel(Control control, ControlEdit.ListClass list)
        {
            int count = this.tabControlEdit.TabPages.Count;
            this.tabControlEdit.TabPages.Add(list.name);
            this.tabControlEdit.TabPages[count].Controls.Add(control);
            list.control = control;
            list.page = this.tabControlEdit.TabPages[count];
            this.m_list.Add(list);
            this.tabControlEdit.SelectedTab = list.page;
            if (this.m_list.Count == 1)
            {
                this.tabControlEdit.Visible = true;
                this.buttonClose.Visible = true;
                this.buttonCloseAll.Visible = true;
            }
        }

        public void ShowSingeGraph(ResourceSingle res)
        {
            if (!this.ResInList(res))
            {
                ControlEdit.ListClass listClass = new ControlEdit.ListClass();
                listClass.name = res.name;
                listClass.obj = res;
                ControlSingleDZ controlSingleDZ = new ControlSingleDZ(this.m_dx, this, listClass, this.m_fileIsChanged);
                controlSingleDZ.ShowControl(res);
                this.AddOnePannel(controlSingleDZ, listClass);
            }
        }

        public void ShowSolidGraph(ResourceSolid res)
        {
            if (!this.ResInList(res))
            {
                ControlEdit.ListClass listClass = new ControlEdit.ListClass();
                listClass.name = res.name;
                listClass.obj = res;
                Control3DDZ control3DDZ = new Control3DDZ(this.m_dx, this, listClass, this.m_fileIsChanged);
                control3DDZ.ShowControl(res);
                this.AddOnePannel(control3DDZ, listClass);
            }
        }

        public void ShowIndex(ResourceIndex res, FrameIndexType type)
        {
            if (!this.ResInList(res))
            {
                ControlEdit.ListClass listClass = new ControlEdit.ListClass();
                listClass.name = res.name;
                listClass.obj = res;
                if (type == FrameIndexType.single)
                {
                    listClass.m_type = ControlEdit.TableType.singleIndex;
                }
                else if (type == FrameIndexType.solid)
                {
                    listClass.m_type = ControlEdit.TableType.solidIndex;
                }
                else if (type == FrameIndexType.number)
                {
                    listClass.m_type = ControlEdit.TableType.numberIndex;
                }
                Control control = new ControlResIndex(type, this, res, this.m_res.m_res, this.m_fileIsChanged);
                this.AddOnePannel(control, listClass);
            }
        }

        public void ShowCartoon(FrameCartoonControl res)
        {
            if (!this.ResInList(res))
            {
                ControlEdit.ListClass listClass = new ControlEdit.ListClass();
                listClass.name = res.name;
                listClass.obj = res;
                Control control = new ControlCartoon1(res, this.m_fileIsChanged);
                listClass.m_type = ControlEdit.TableType.cartoon;
                this.AddOnePannel(control, listClass);
            }
        }

        public void ShowCartoonElement(FrameCartoonGroup res)
        {
            if (!this.ResInList(res))
            {
                ControlEdit.ListClass listClass = new ControlEdit.ListClass();
                listClass.name = res.name;
                listClass.obj = res;
                Control control = new ControlCartoon2(res, this.m_res.m_res, this.m_res.m_index, this.m_dx, this.m_fileIsChanged);
                listClass.m_type = ControlEdit.TableType.cartoonElement;
                this.AddOnePannel(control, listClass);
            }
        }

        public ResourceSingle FindNameByResourceSingle(string name)
        {
            foreach (ResourceSingle resourceSingle in this.m_res.m_res.m_resSingle)
            {
                if (resourceSingle.name == name)
                {
                    return resourceSingle;
                }
            }
            return null;
        }

        public ResourceSolid FindNameByResourceSolid(string name)
        {
            foreach (ResourceSolid resourceSolid in this.m_res.m_res.m_resSolid)
            {
                if (resourceSolid.name == name)
                {
                    return resourceSolid;
                }
            }
            return null;
        }

        public ResourceIndex FindNameByResourceIndex(string name, FrameIndexType resourceType)
        {
            if (resourceType == FrameIndexType.single)
            {
                using (List<ResourceIndex>.Enumerator enumerator = this.m_res.m_index.m_indexSingle.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ResourceIndex resourceIndex = enumerator.Current;
                        if (resourceIndex.name == name)
                        {
                            return resourceIndex;
                        }
                    }
                    goto IL_00F5;
                }
            }
            if (resourceType == FrameIndexType.solid)
            {
                using (List<ResourceIndex>.Enumerator enumerator2 = this.m_res.m_index.m_indexSolid.GetEnumerator())
                {
                    while (enumerator2.MoveNext())
                    {
                        ResourceIndex resourceIndex2 = enumerator2.Current;
                        if (resourceIndex2.name == name)
                        {
                            return resourceIndex2;
                        }
                    }
                    goto IL_00F5;
                }
            }
            if (resourceType == FrameIndexType.number)
            {
                foreach (ResourceIndex resourceIndex3 in this.m_res.m_index.m_indexNumber)
                {
                    if (resourceIndex3.name == name)
                    {
                        return resourceIndex3;
                    }
                }
            }
            IL_00F5:
            return null;
        }

        public void DeleteObj(object res)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.obj == res)
                {
                    this.tabControlEdit.TabPages.Remove(listClass.page);
                    this.m_list.Remove(listClass);
                    if (this.m_list.Count == 0)
                    {
                        this.tabControlEdit.Visible = false;
                        this.buttonClose.Visible = false;
                        this.buttonCloseAll.Visible = false;
                        break;
                    }
                    break;
                }
            }
        }

        public void ChangeName(object res, string newName)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.obj == res)
                {
                    listClass.name = newName;
                    listClass.page.Text = newName;
                    break;
                }
            }
        }

        public void ResourceDelete(ResourceSingle res)
        {
            int num = 0;
            foreach (ResourceSingle resourceSingle in this.m_res.m_res.m_resSingle)
            {
                num++;
                if (resourceSingle == res)
                {
                    foreach (ResourceIndex resourceIndex in this.m_res.m_index.m_indexSingle)
                    {
                        foreach (FrameIndexElement frameIndexElement in resourceIndex.m_element)
                        {
                            if (frameIndexElement.index == num)
                            {
                                frameIndexElement.index = 0;
                            }
                            else if (frameIndexElement.index > num)
                            {
                                frameIndexElement.index--;
                            }
                        }
                    }
                    foreach (FrameCartoonControl frameCartoonControl in this.m_res.m_control.m_cartoon)
                    {
                        foreach (FrameCartoonGroup frameCartoonGroup in frameCartoonControl.groups)
                        {
                            foreach (FrameCartoonElement frameCartoonElement in frameCartoonGroup.ele)
                            {
                                FrameCartoonType type = frameCartoonElement.m_type;
                                if (type == FrameCartoonType.pannel)
                                {
                                    int count = frameCartoonElement.property.Count;
                                    for (int i = 0; i < count; i++)
                                    {
                                        PropertyElementPannel propertyElementPannel = (PropertyElementPannel)frameCartoonElement.property[i];
                                        if (!propertyElementPannel.useIndex)
                                        {
                                            if (propertyElementPannel.res == num)
                                            {
                                                propertyElementPannel.res = 0;
                                            }
                                            else if (propertyElementPannel.res > num)
                                            {
                                                propertyElementPannel.res--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateIndexTable(FrameIndexType type)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (type == FrameIndexType.single)
                {
                    if (listClass.m_type == ControlEdit.TableType.singleIndex)
                    {
                        ((ControlResIndex)listClass.control).ResourceDelete();
                    }
                }
                else if (type == FrameIndexType.solid && listClass.m_type == ControlEdit.TableType.solidIndex)
                {
                    ((ControlResIndex)listClass.control).ResourceDelete();
                }
            }
        }

        public void ResourceDelete(ResourceSolid res)
        {
            int num = 0;
            foreach (ResourceSolid resourceSolid in this.m_res.m_res.m_resSolid)
            {
                num++;
                if (resourceSolid == res)
                {
                    foreach (ResourceIndex resourceIndex in this.m_res.m_index.m_indexSolid)
                    {
                        foreach (FrameIndexElement frameIndexElement in resourceIndex.m_element)
                        {
                            if (frameIndexElement.index == num)
                            {
                                frameIndexElement.index = 0;
                            }
                            else if (frameIndexElement.index > num)
                            {
                                frameIndexElement.index--;
                            }
                        }
                    }
                    foreach (FrameCartoonControl frameCartoonControl in this.m_res.m_control.m_cartoon)
                    {
                        foreach (FrameCartoonGroup frameCartoonGroup in frameCartoonControl.groups)
                        {
                            foreach (FrameCartoonElement frameCartoonElement in frameCartoonGroup.ele)
                            {
                                FrameCartoonType type = frameCartoonElement.m_type;
                                if (type == FrameCartoonType.solid)
                                {
                                    int count = frameCartoonElement.property.Count;
                                    for (int i = 0; i < count; i++)
                                    {
                                        PropertyElementSolid propertyElementSolid = (PropertyElementSolid)frameCartoonElement.property[i];
                                        if (!propertyElementSolid.useIndex)
                                        {
                                            if (propertyElementSolid.res == num)
                                            {
                                                propertyElementSolid.res = 0;
                                            }
                                            else if (propertyElementSolid.res > num)
                                            {
                                                propertyElementSolid.res--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ResourceRename(ResourceSingle res, string newName)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.m_type == ControlEdit.TableType.singleIndex)
                {
                    ((ControlResIndex)listClass.control).ResourceRename(res, newName);
                }
            }
            this.ChangeName(res, newName);
        }

        public void ResourceRename(ResourceSolid res, string newName)
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.m_type == ControlEdit.TableType.solidIndex)
                {
                    ((ControlResIndex)listClass.control).ResourceRename(res, newName);
                }
            }
            this.ChangeName(res, newName);
        }

        public void UpdateProperty()
        {
            foreach (ControlEdit.ListClass listClass in this.m_list)
            {
                if (listClass.m_type == ControlEdit.TableType.cartoonElement)
                {
                    ((ControlCartoon2)listClass.control).ResourceRename();
                }
            }
        }

        public void ResourceIndexDelete(FrameIndexType type, ResourceIndex res)
        {
            if (type == FrameIndexType.single)
            {
                int count = this.m_res.m_index.m_indexSingle.Count;
                for (int i = 0; i < count; i++)
                {
                    if (res == this.m_res.m_index.m_indexSingle[i])
                    {
                        this.ResourceIndexDelete(type, i);
                        this.UpdateProperty();
                        return;
                    }
                }
                return;
            }
            if (type == FrameIndexType.solid)
            {
                int count2 = this.m_res.m_index.m_indexSolid.Count;
                for (int j = 0; j < count2; j++)
                {
                    if (res == this.m_res.m_index.m_indexSolid[j])
                    {
                        this.ResourceIndexDelete(type, j);
                        this.UpdateProperty();
                        return;
                    }
                }
                return;
            }
            if (type == FrameIndexType.number)
            {
                int count3 = this.m_res.m_index.m_indexNumber.Count;
                for (int k = 0; k < count3; k++)
                {
                    if (res == this.m_res.m_index.m_indexNumber[k])
                    {
                        this.ResourceIndexDelete(type, k);
                        this.UpdateProperty();
                        return;
                    }
                }
            }
        }

        public void ResourceIndexDelete(FrameIndexType type, int index)
        {
            index++;
            foreach (FrameCartoonControl frameCartoonControl in this.m_res.m_control.m_cartoon)
            {
                foreach (FrameCartoonGroup frameCartoonGroup in frameCartoonControl.groups)
                {
                    foreach (FrameCartoonElement frameCartoonElement in frameCartoonGroup.ele)
                    {
                        FrameCartoonType type2 = frameCartoonElement.m_type;
                        int count = frameCartoonElement.property.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (type2 == FrameCartoonType.dot)
                            {
                                PropertyElementDot propertyElementDot = (PropertyElementDot)frameCartoonElement.property[i];
                                if (type == FrameIndexType.number)
                                {
                                    if (propertyElementDot.indexX == index)
                                    {
                                        propertyElementDot.indexX = 0;
                                        propertyElementDot.startX = 0;
                                        propertyElementDot.endX = 0;
                                    }
                                    else if (propertyElementDot.indexX > index)
                                    {
                                        propertyElementDot.indexX--;
                                    }
                                    if (propertyElementDot.indexY == index)
                                    {
                                        propertyElementDot.indexY = 0;
                                        propertyElementDot.startY = 0;
                                        propertyElementDot.endY = 0;
                                    }
                                    else if (propertyElementDot.indexY > index)
                                    {
                                        propertyElementDot.indexY--;
                                    }
                                    if (propertyElementDot.indexZ == index)
                                    {
                                        propertyElementDot.indexZ = 0;
                                        propertyElementDot.startZ = 0;
                                        propertyElementDot.endZ = 0;
                                    }
                                    else if (propertyElementDot.indexZ > index)
                                    {
                                        propertyElementDot.indexZ--;
                                    }
                                }
                            }
                            else if (type2 == FrameCartoonType.line)
                            {
                                PropertyElementLine propertyElementLine = (PropertyElementLine)frameCartoonElement.property[i];
                                if (type == FrameIndexType.number)
                                {
                                    if (propertyElementLine.indexX == index)
                                    {
                                        propertyElementLine.indexX = 0;
                                        propertyElementLine.startX1 = 0;
                                        propertyElementLine.endX1 = 0;
                                        propertyElementLine.startX2 = 0;
                                        propertyElementLine.endX2 = 0;
                                    }
                                    else if (propertyElementLine.indexX > index)
                                    {
                                        propertyElementLine.indexX--;
                                    }
                                    if (propertyElementLine.indexY == index)
                                    {
                                        propertyElementLine.indexY = 0;
                                        propertyElementLine.startY1 = 0;
                                        propertyElementLine.endY1 = 0;
                                        propertyElementLine.startY2 = 0;
                                        propertyElementLine.endY2 = 0;
                                    }
                                    else if (propertyElementLine.indexY > index)
                                    {
                                        propertyElementLine.indexY--;
                                    }
                                    if (propertyElementLine.indexZ == index)
                                    {
                                        propertyElementLine.indexZ = 0;
                                        propertyElementLine.startZ1 = 0;
                                        propertyElementLine.endZ1 = 0;
                                        propertyElementLine.startZ2 = 0;
                                        propertyElementLine.endZ2 = 0;
                                    }
                                    else if (propertyElementLine.indexZ > index)
                                    {
                                        propertyElementLine.indexZ--;
                                    }
                                }
                            }
                            else if (type2 == FrameCartoonType.pannel)
                            {
                                PropertyElementPannel propertyElementPannel = (PropertyElementPannel)frameCartoonElement.property[i];
                                if (type == FrameIndexType.number)
                                {
                                    if (propertyElementPannel.indexX == index)
                                    {
                                        propertyElementPannel.indexX = 0;
                                        propertyElementPannel.startX = 0;
                                        propertyElementPannel.endX = 0;
                                    }
                                    else if (propertyElementPannel.indexX > index)
                                    {
                                        propertyElementPannel.indexX--;
                                    }
                                    if (propertyElementPannel.indexY == index)
                                    {
                                        propertyElementPannel.indexY = 0;
                                        propertyElementPannel.startY = 0;
                                        propertyElementPannel.endY = 0;
                                    }
                                    else if (propertyElementPannel.indexY > index)
                                    {
                                        propertyElementPannel.indexY--;
                                    }
                                    if (propertyElementPannel.indexZ == index)
                                    {
                                        propertyElementPannel.indexZ = 0;
                                        propertyElementPannel.startZ = 0;
                                        propertyElementPannel.endZ = 0;
                                    }
                                    else if (propertyElementPannel.indexZ > index)
                                    {
                                        propertyElementPannel.indexZ--;
                                    }
                                }
                                else if (type == FrameIndexType.single && propertyElementPannel.useIndex)
                                {
                                    if (propertyElementPannel.res == index)
                                    {
                                        propertyElementPannel.res = 0;
                                        propertyElementPannel.resIndexStart = 1;
                                        propertyElementPannel.resIndexEnd = 1;
                                    }
                                    else if (propertyElementPannel.res > index)
                                    {
                                        propertyElementPannel.res--;
                                    }
                                }
                            }
                            else if (type2 == FrameCartoonType.solid)
                            {
                                PropertyElementSolid propertyElementSolid = (PropertyElementSolid)frameCartoonElement.property[i];
                                if (type == FrameIndexType.number)
                                {
                                    if (propertyElementSolid.indexX == index)
                                    {
                                        propertyElementSolid.indexX = 0;
                                        propertyElementSolid.startX = 0;
                                        propertyElementSolid.endX = 0;
                                    }
                                    else if (propertyElementSolid.indexX > index)
                                    {
                                        propertyElementSolid.indexX--;
                                    }
                                    if (propertyElementSolid.indexY == index)
                                    {
                                        propertyElementSolid.indexY = 0;
                                        propertyElementSolid.startY = 0;
                                        propertyElementSolid.endY = 0;
                                    }
                                    else if (propertyElementSolid.indexY > index)
                                    {
                                        propertyElementSolid.indexY--;
                                    }
                                    if (propertyElementSolid.indexZ == index)
                                    {
                                        propertyElementSolid.indexZ = 0;
                                        propertyElementSolid.startZ = 0;
                                        propertyElementSolid.endZ = 0;
                                    }
                                    else if (propertyElementSolid.indexZ > index)
                                    {
                                        propertyElementSolid.indexZ--;
                                    }
                                }
                                else if (type == FrameIndexType.solid && propertyElementSolid.useIndex)
                                {
                                    if (propertyElementSolid.res == index)
                                    {
                                        propertyElementSolid.res = 0;
                                        propertyElementSolid.resIndexStart = 1;
                                        propertyElementSolid.resIndexEnd = 1;
                                    }
                                    else if (propertyElementSolid.res > index)
                                    {
                                        propertyElementSolid.res--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlEdit = new TabControl();
            this.buttonClose = new Button();
            this.buttonCloseAll = new Button();
            base.SuspendLayout();
            this.tabControlEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabControlEdit.Location = new Point(3, 3);
            this.tabControlEdit.Name = "tabControlEdit";
            this.tabControlEdit.SelectedIndex = 0;
            this.tabControlEdit.ShowToolTips = true;
            this.tabControlEdit.Size = new Size(568, 247);
            this.tabControlEdit.TabIndex = 0;
            this.buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.buttonClose.Location = new Point(545, 28);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(18, 25);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonCloseAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.buttonCloseAll.Location = new Point(469, 28);
            this.buttonCloseAll.Name = "buttonCloseAll";
            this.buttonCloseAll.Size = new Size(68, 25);
            this.buttonCloseAll.TabIndex = 2;
            this.buttonCloseAll.Text = "Close all";
            this.buttonCloseAll.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.buttonCloseAll);
            base.Controls.Add(this.buttonClose);
            base.Controls.Add(this.tabControlEdit);
            base.Name = "ControlEdit";
            base.Size = new Size(571, 250);
            base.ResumeLayout(false);
        }

        private List<ControlEdit.ListClass> m_list = new List<ControlEdit.ListClass>();

        private DX9 m_dx;

        private AllResource m_res = new AllResource();

        private IContainer components;

        private TabControl tabControlEdit;

        private Button buttonClose;

        private Button buttonCloseAll;

        public enum TableType
        {
            single,
            solid,
            singleIndex,
            solidIndex,
            numberIndex,
            cartoon,
            cartoonElement
        }

        public class ListClass
        {
            public string name = "";

            public bool IsChange;

            public ControlEdit.TableType m_type;

            public Control control;

            public TabPage page;

            public object obj;
        }
    }
}
