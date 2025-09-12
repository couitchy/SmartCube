using System;
using System.Windows.Forms;

namespace Guan
{
    internal class TreeIndex
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public TreeIndex(FrameIndex res, TreeView tree, ControlEdit edit, FormGuan.FileIsChanged fileIsChanged)
        {
            this.m_res = res;
            this.m_tree = tree;
            this.m_edit = edit;
            this.m_fileIsChanged = fileIsChanged;
            this.m_tree.Nodes.Add(Config.IndexPanel);
            this.m_tree.Nodes.Add(Config.IndexSolid);
            this.m_tree.Nodes.Add(Config.IndexValue);
            this.m_tree.MouseDown += this.m_tree_MouseDown;
            this.m_tree.DoubleClick += this.m_tree_DoubleClick;
            this.m_tree.KeyDown += this.m_tree_KeyDown;
            this.m_menu.Items.Add("Add index tables");
            this.m_menu.Items.Add("Rename");
            this.m_menu.Items.Add("Delete");
            this.m_menu.Items.Add("Copy(CTRL+C)");
            this.m_menu.Items.Add("Paste(CTRL+V)");
            this.m_menu.ItemClicked += this.m_menu_ItemClicked;
        }

        private void m_tree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    this.Copy();
                    return;
                }
                if (e.KeyCode == Keys.V)
                {
                    this.Paste();
                }
            }
        }

        public void UpdateList()
        {
            this.m_tree.Nodes[0].Nodes.Clear();
            for (int i = 0; i < this.m_res.m_indexSingle.Count; i++)
            {
                this.m_tree.Nodes[0].Nodes.Add(this.m_res.m_indexSingle[i].name);
            }
            this.m_tree.Nodes[1].Nodes.Clear();
            for (int j = 0; j < this.m_res.m_indexSolid.Count; j++)
            {
                this.m_tree.Nodes[1].Nodes.Add(this.m_res.m_indexSolid[j].name);
            }
            this.m_tree.Nodes[2].Nodes.Clear();
            for (int k = 0; k < this.m_res.m_indexNumber.Count; k++)
            {
                this.m_tree.Nodes[2].Nodes.Add(this.m_res.m_indexNumber[k].name);
            }
        }

        private void m_tree_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.m_tree.SelectedNode;
            if (selectedNode != null && selectedNode.Parent != null)
            {
                FrameIndexType frameIndexType = FrameIndexType.single;
                if (this.m_tree.Nodes[1].Equals(selectedNode.Parent))
                {
                    frameIndexType = FrameIndexType.solid;
                }
                else if (this.m_tree.Nodes[2].Equals(selectedNode.Parent))
                {
                    frameIndexType = FrameIndexType.number;
                }
                ResourceIndex resourceIndex = this.m_edit.FindNameByResourceIndex(selectedNode.Text, frameIndexType);
                this.m_edit.ShowIndex(resourceIndex, frameIndexType);
            }
        }

        private void NodeAdd(ResourceIndex res, FrameIndexType thisType)
        {
            switch (thisType)
            {
            case FrameIndexType.single:
                this.m_res.m_indexSingle.Add(res);
                this.m_tree.Nodes[0].Nodes.Add(res.name);
                return;
            case FrameIndexType.solid:
                this.m_res.m_indexSolid.Add(res);
                this.m_tree.Nodes[1].Nodes.Add(res.name);
                return;
            case FrameIndexType.number:
                this.m_res.m_indexNumber.Add(res);
                this.m_tree.Nodes[2].Nodes.Add(res.name);
                return;
            default:
                return;
            }
        }

        private void Fun_Add()
        {
            TreeNode selectedNode = this.m_tree.SelectedNode;
            if (selectedNode != null)
            {
                FrameIndexType frameIndexType = FrameIndexType.single;
                if (selectedNode.Parent != null)
                {
                    if (this.m_tree.Nodes[1].Equals(selectedNode.Parent))
                    {
                        frameIndexType = FrameIndexType.solid;
                    }
                    else if (this.m_tree.Nodes[2].Equals(selectedNode.Parent))
                    {
                        frameIndexType = FrameIndexType.number;
                    }
                }
                else if (this.m_tree.Nodes[1].Equals(selectedNode))
                {
                    frameIndexType = FrameIndexType.solid;
                }
                else if (this.m_tree.Nodes[2].Equals(selectedNode))
                {
                    frameIndexType = FrameIndexType.number;
                }
                switch (frameIndexType)
                {
                case FrameIndexType.single:
                    if (this.m_res.m_indexSingle.Count >= Config.MaxIndexTable)
                    {
                        MessageBox.Show(Config.SourceOut);
                        return;
                    }
                    break;
                case FrameIndexType.solid:
                    if (this.m_res.m_indexSolid.Count >= Config.MaxIndexTable)
                    {
                        MessageBox.Show(Config.SourceOut);
                        return;
                    }
                    break;
                case FrameIndexType.number:
                    if (this.m_res.m_indexNumber.Count >= Config.MaxIndexTable)
                    {
                        MessageBox.Show(Config.SourceOut);
                        return;
                    }
                    break;
                }
                int num = 1;
                string text;
                for (;;)
                {
                    text = "Table" + num;
                    if (this.m_edit.FindNameByResourceIndex(text, frameIndexType) == null)
                    {
                        break;
                    }
                    num++;
                }
                this.NodeAdd(new ResourceIndex
                {
                    name = text
                }, frameIndexType);
                if (this.m_fileIsChanged != null)
                {
                    this.m_fileIsChanged(true);
                    return;
                }
            }
        }

        private void Fun_Rename()
        {
            TreeNode selectedNode = this.m_tree.SelectedNode;
            if (selectedNode != null && selectedNode.Parent != null)
            {
                FrameIndexType frameIndexType = FrameIndexType.single;
                if (this.m_tree.Nodes[1].Equals(selectedNode.Parent))
                {
                    frameIndexType = FrameIndexType.solid;
                }
                else if (this.m_tree.Nodes[2].Equals(selectedNode.Parent))
                {
                    frameIndexType = FrameIndexType.number;
                }
                ResourceIndex resourceIndex = this.m_edit.FindNameByResourceIndex(selectedNode.Text, frameIndexType);
                if (resourceIndex != null)
                {
                    FormRename formRename = new FormRename();
                    formRename.name = selectedNode.Text;
                    DialogResult dialogResult = formRename.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        string name = formRename.name;
                        if (this.m_edit.FindNameByResourceIndex(name, frameIndexType) == null)
                        {
                            resourceIndex.name = name;
                            selectedNode.Text = name;
                            this.m_edit.ChangeName(resourceIndex, name);
                            this.m_edit.UpdateProperty();
                            if (this.m_fileIsChanged != null)
                            {
                                this.m_fileIsChanged(true);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(Config.RenameFailed);
                        }
                    }
                }
            }
        }

        private void Fun_Delete()
        {
            TreeNode selectedNode = this.m_tree.SelectedNode;
            if (selectedNode != null && selectedNode.Parent != null)
            {
                FrameIndexType frameIndexType = FrameIndexType.single;
                if (this.m_tree.Nodes[1].Equals(selectedNode.Parent))
                {
                    frameIndexType = FrameIndexType.solid;
                }
                else if (this.m_tree.Nodes[2].Equals(selectedNode.Parent))
                {
                    frameIndexType = FrameIndexType.number;
                }
                ResourceIndex resourceIndex = this.m_edit.FindNameByResourceIndex(selectedNode.Text, frameIndexType);
                if (resourceIndex != null)
                {
                    if (frameIndexType == FrameIndexType.single)
                    {
                        int num = this.m_res.m_indexSingle.IndexOf(resourceIndex);
                        this.m_edit.ResourceIndexDelete(frameIndexType, num);
                        this.m_res.m_indexSingle.Remove(resourceIndex);
                    }
                    else if (frameIndexType == FrameIndexType.solid)
                    {
                        int num2 = this.m_res.m_indexSolid.IndexOf(resourceIndex);
                        this.m_edit.ResourceIndexDelete(frameIndexType, num2);
                        this.m_res.m_indexSolid.Remove(resourceIndex);
                    }
                    else if (frameIndexType == FrameIndexType.number)
                    {
                        int num3 = this.m_res.m_indexNumber.IndexOf(resourceIndex);
                        this.m_edit.ResourceIndexDelete(frameIndexType, num3);
                        this.m_res.m_indexNumber.Remove(resourceIndex);
                    }
                    this.m_edit.DeleteObj(resourceIndex);
                    this.m_edit.UpdateProperty();
                    selectedNode.Parent.Nodes.Remove(selectedNode);
                    Clipboard.Clear();
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                    }
                }
            }
        }

        private void Copy()
        {
            TreeNode selectedNode = this.m_tree.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }
            TreeNode treeNode;
            if (selectedNode.Parent != null)
            {
                treeNode = selectedNode.Parent;
            }
            else
            {
                treeNode = selectedNode;
            }
            int num = 0;
            for (int i = 0; i < this.m_tree.Nodes.Count; i++)
            {
                if (treeNode.Equals(this.m_tree.Nodes[i]))
                {
                    num = i;
                }
            }
            if (selectedNode.Parent != null)
            {
                int num2 = treeNode.Nodes.IndexOf(selectedNode);
                if (num == 0)
                {
                    Clipboard.SetData(Config.SingleIndexCopyString, this.m_res.m_indexSingle[num2]);
                    return;
                }
                if (num == 1)
                {
                    Clipboard.SetData(Config.SolidIndexCopyString, this.m_res.m_indexSolid[num2]);
                    return;
                }
                if (num == 2)
                {
                    Clipboard.SetData(Config.NumberIndexCopyString, this.m_res.m_indexNumber[num2]);
                }
            }
        }

        private void Paste()
        {
            try
            {
                object obj = Clipboard.GetData(Config.SingleIndexCopyString);
                if (obj != null)
                {
                    ResourceIndex resourceIndex = (ResourceIndex)obj;
                    if (this.m_res.m_indexSingle.Count < Config.MaxIndexTable)
                    {
                        int num = 1;
                        string text;
                        for (;;)
                        {
                            text = resourceIndex.name + num;
                            bool flag = true;
                            foreach (ResourceIndex resourceIndex2 in this.m_res.m_indexSingle)
                            {
                                if (resourceIndex2.name == text)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                            num++;
                        }
                        resourceIndex.name = text;
                        this.m_res.m_indexSingle.Add(resourceIndex);
                        this.m_tree.Nodes[0].Nodes.Add(text);
                        this.m_edit.UpdateProperty();
                        if (this.m_fileIsChanged != null)
                        {
                            this.m_fileIsChanged(true);
                        }
                    }
                }
                else
                {
                    obj = Clipboard.GetData(Config.SolidIndexCopyString);
                    if (obj != null)
                    {
                        ResourceIndex resourceIndex3 = (ResourceIndex)obj;
                        if (this.m_res.m_indexSolid.Count < Config.MaxIndexTable)
                        {
                            int num2 = 1;
                            string text2;
                            for (;;)
                            {
                                text2 = resourceIndex3.name + num2;
                                bool flag2 = true;
                                foreach (ResourceIndex resourceIndex4 in this.m_res.m_indexSolid)
                                {
                                    if (resourceIndex4.name == text2)
                                    {
                                        flag2 = false;
                                        break;
                                    }
                                }
                                if (flag2)
                                {
                                    break;
                                }
                                num2++;
                            }
                            resourceIndex3.name = text2;
                            this.m_res.m_indexSolid.Add(resourceIndex3);
                            this.m_tree.Nodes[1].Nodes.Add(text2);
                            this.m_edit.UpdateProperty();
                            if (this.m_fileIsChanged != null)
                            {
                                this.m_fileIsChanged(true);
                            }
                        }
                    }
                    else
                    {
                        obj = Clipboard.GetData(Config.NumberIndexCopyString);
                        if (obj != null)
                        {
                            ResourceIndex resourceIndex5 = (ResourceIndex)obj;
                            if (this.m_res.m_indexNumber.Count < 127)
                            {
                                int num3 = 1;
                                string text3;
                                for (;;)
                                {
                                    text3 = resourceIndex5.name + num3;
                                    bool flag3 = true;
                                    foreach (ResourceIndex resourceIndex6 in this.m_res.m_indexNumber)
                                    {
                                        if (resourceIndex6.name == text3)
                                        {
                                            flag3 = false;
                                            break;
                                        }
                                    }
                                    if (flag3)
                                    {
                                        break;
                                    }
                                    num3++;
                                }
                                resourceIndex5.name = text3;
                                this.m_res.m_indexNumber.Add(resourceIndex5);
                                this.m_tree.Nodes[2].Nodes.Add(text3);
                                this.m_edit.UpdateProperty();
                                if (this.m_fileIsChanged != null)
                                {
                                    this.m_fileIsChanged(true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void m_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.m_menu.Hide();
            if (e.ClickedItem.Equals(this.m_menu.Items[0]))
            {
                this.Fun_Add();
                return;
            }
            if (e.ClickedItem.Equals(this.m_menu.Items[1]))
            {
                this.Fun_Rename();
                return;
            }
            if (e.ClickedItem.Equals(this.m_menu.Items[2]))
            {
                this.Fun_Delete();
                return;
            }
            if (e.ClickedItem.Equals(this.m_menu.Items[3]))
            {
                this.Copy();
                return;
            }
            if (e.ClickedItem.Equals(this.m_menu.Items[4]))
            {
                this.Paste();
            }
        }

        private void m_tree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeAt = this.m_tree.GetNodeAt(e.X, e.Y);
            this.m_tree.SelectedNode = nodeAt;
            if (e.Button == MouseButtons.Right)
            {
                TreeNode selectedNode = this.m_tree.SelectedNode;
                if (selectedNode != null)
                {
                    if (selectedNode.Parent != null)
                    {
                        this.m_menu.Items[1].Enabled = true;
                        this.m_menu.Items[2].Enabled = true;
                        this.m_menu.Items[3].Enabled = true;
                        this.m_menu.Items[4].Enabled = true;
                    }
                    else
                    {
                        this.m_menu.Items[1].Enabled = false;
                        this.m_menu.Items[2].Enabled = false;
                        this.m_menu.Items[3].Enabled = false;
                        this.m_menu.Items[4].Enabled = false;
                    }
                    this.m_menu.Show(this.m_tree.PointToScreen(e.Location));
                }
            }
        }

        private FrameIndex m_res;

        private TreeView m_tree;

        private ControlEdit m_edit;

        private ContextMenuStrip m_menu = new ContextMenuStrip();
    }
}
