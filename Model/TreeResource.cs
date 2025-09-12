using System;
using System.Windows.Forms;

namespace Guan
{
    internal class TreeResource
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public TreeResource(FrameResource res, TreeView tree, ControlEdit edit, FormGuan.FileIsChanged fileIsChanged)
        {
            this.m_res = res;
            this.m_tree = tree;
            this.m_edit = edit;
            this.m_fileIsChanged = fileIsChanged;
            this.m_tree.Nodes.Add(Config.GraphPanel);
            this.m_tree.Nodes.Add(Config.GraphSolid);
            this.m_tree.MouseDown += this.m_tree_MouseDown;
            this.m_tree.DoubleClick += this.m_tree_DoubleClick;
            this.m_tree.KeyDown += this.m_tree_KeyDown;
            this.m_menu.Items.Add("Add");
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
            foreach (ResourceSingle resourceSingle in this.m_res.m_resSingle)
            {
                this.m_tree.Nodes[0].Nodes.Add(resourceSingle.name);
            }
            this.m_tree.Nodes[1].Nodes.Clear();
            foreach (ResourceSolid resourceSolid in this.m_res.m_resSolid)
            {
                this.m_tree.Nodes[1].Nodes.Add(resourceSolid.name);
            }
        }

        private void m_tree_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.m_tree.SelectedNode;
            if (selectedNode.Parent != null)
            {
                TreeNode parent = selectedNode.Parent;
                ResourceType resourceType = ResourceType.singleGraph;
                for (int i = 0; i < this.m_tree.Nodes.Count; i++)
                {
                    if (parent.Equals(this.m_tree.Nodes[i]))
                    {
                        resourceType = (ResourceType)i;
                    }
                }
                int num = parent.Nodes.IndexOf(selectedNode);
                if (resourceType == ResourceType.singleGraph)
                {
                    this.m_edit.ShowSingeGraph(this.m_res.m_resSingle[num]);
                    return;
                }
                if (resourceType == ResourceType.solidGraph)
                {
                    this.m_edit.ShowSolidGraph(this.m_res.m_resSolid[num]);
                }
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
                    if (selectedNode.Parent == null)
                    {
                        this.m_menu.Items[2].Enabled = false;
                        this.m_menu.Items[1].Enabled = false;
                        this.m_menu.Items[3].Enabled = false;
                        this.m_menu.Items[4].Enabled = false;
                        this.m_menu.Show(this.m_tree.PointToScreen(e.Location));
                        return;
                    }
                    this.m_menu.Items[2].Enabled = true;
                    this.m_menu.Items[1].Enabled = true;
                    this.m_menu.Items[3].Enabled = true;
                    this.m_menu.Items[4].Enabled = true;
                    this.m_menu.Show(this.m_tree.PointToScreen(e.Location));
                }
            }
        }

        private void m_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
            ResourceType resourceType = ResourceType.singleGraph;
            for (int i = 0; i < this.m_tree.Nodes.Count; i++)
            {
                if (treeNode.Equals(this.m_tree.Nodes[i]))
                {
                    resourceType = (ResourceType)i;
                }
            }
            if (e.ClickedItem.Equals(this.m_menu.Items[0]))
            {
                if (resourceType == ResourceType.singleGraph)
                {
                    if (this.m_res.m_resSingle.Count >= Config.MaxGraph)
                    {
                        MessageBox.Show(Config.SourceOut);
                        return;
                    }
                    int num = 1;
                    string text;
                    for (;;)
                    {
                        text = "Graph" + num;
                        if (this.m_edit.FindNameByResourceSingle(text) == null)
                        {
                            break;
                        }
                        num++;
                    }
                    ResourceSingle resourceSingle = new ResourceSingle();
                    resourceSingle.name = text;
                    this.m_res.m_resSingle.Add(resourceSingle);
                    treeNode.Nodes.Add(text);
                    this.m_edit.UpdateProperty();
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                        return;
                    }
                }
                else if (resourceType == ResourceType.solidGraph)
                {
                    if (this.m_res.m_resSolid.Count >= Config.MaxGraph)
                    {
                        MessageBox.Show(Config.SourceOut);
                        return;
                    }
                    int num2 = 1;
                    string text2;
                    for (;;)
                    {
                        text2 = "Graph" + num2;
                        if (this.m_edit.FindNameByResourceSolid(text2) == null)
                        {
                            break;
                        }
                        num2++;
                    }
                    ResourceSolid resourceSolid = new ResourceSolid();
                    resourceSolid.name = text2;
                    this.m_res.m_resSolid.Add(resourceSolid);
                    treeNode.Nodes.Add(text2);
                    this.m_edit.UpdateProperty();
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                        return;
                    }
                }
            }
            else if (e.ClickedItem.Equals(this.m_menu.Items[1]))
            {
                if (selectedNode.Parent != null)
                {
                    int num3 = treeNode.Nodes.IndexOf(selectedNode);
                    FormRename formRename = new FormRename();
                    formRename.name = selectedNode.Text;
                    DialogResult dialogResult = formRename.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        string name = formRename.name;
                        if (resourceType == ResourceType.singleGraph)
                        {
                            if (this.m_edit.FindNameByResourceSingle(name) != null)
                            {
                                MessageBox.Show(Config.RenameFailed);
                                return;
                            }
                            this.m_res.m_resSingle[num3].name = name;
                            selectedNode.Text = name;
                            this.m_edit.ResourceRename(this.m_res.m_resSingle[num3], name);
                            this.m_edit.UpdateProperty();
                            if (this.m_fileIsChanged != null)
                            {
                                this.m_fileIsChanged(true);
                                return;
                            }
                        }
                        else if (resourceType == ResourceType.solidGraph)
                        {
                            if (this.m_edit.FindNameByResourceSolid(name) != null)
                            {
                                MessageBox.Show(Config.RenameFailed);
                                return;
                            }
                            this.m_res.m_resSolid[num3].name = name;
                            selectedNode.Text = name;
                            this.m_edit.ResourceRename(this.m_res.m_resSolid[num3], name);
                            this.m_edit.UpdateProperty();
                            if (this.m_fileIsChanged != null)
                            {
                                this.m_fileIsChanged(true);
                                return;
                            }
                        }
                    }
                }
            }
            else if (e.ClickedItem.Equals(this.m_menu.Items[2]))
            {
                if (selectedNode.Parent != null)
                {
                    int num4 = treeNode.Nodes.IndexOf(selectedNode);
                    if (resourceType == ResourceType.singleGraph)
                    {
                        this.m_edit.ResourceDelete(this.m_res.m_resSingle[num4]);
                        this.m_edit.DeleteObj(this.m_res.m_resSingle[num4]);
                        this.m_res.m_resSingle.RemoveAt(num4);
                        this.m_edit.UpdateIndexTable(FrameIndexType.single);
                    }
                    else if (resourceType == ResourceType.solidGraph)
                    {
                        this.m_edit.ResourceDelete(this.m_res.m_resSolid[num4]);
                        this.m_edit.DeleteObj(this.m_res.m_resSolid[num4]);
                        this.m_res.m_resSolid.RemoveAt(num4);
                        this.m_edit.UpdateIndexTable(FrameIndexType.solid);
                    }
                    treeNode.Nodes.RemoveAt(num4);
                    this.m_edit.UpdateProperty();
                    Clipboard.Clear();
                    if (this.m_fileIsChanged != null)
                    {
                        this.m_fileIsChanged(true);
                        return;
                    }
                }
            }
            else
            {
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
            ResourceType resourceType = ResourceType.singleGraph;
            for (int i = 0; i < this.m_tree.Nodes.Count; i++)
            {
                if (treeNode.Equals(this.m_tree.Nodes[i]))
                {
                    resourceType = (ResourceType)i;
                }
            }
            if (selectedNode.Parent != null)
            {
                int num = treeNode.Nodes.IndexOf(selectedNode);
                if (resourceType == ResourceType.singleGraph)
                {
                    Clipboard.SetData(Config.SingleCopyString, this.m_res.m_resSingle[num]);
                    return;
                }
                if (resourceType == ResourceType.solidGraph)
                {
                    Clipboard.SetData(Config.SolidCopyString, this.m_res.m_resSolid[num]);
                }
            }
        }

        private void Paste()
        {
            try
            {
                object obj = Clipboard.GetData(Config.SingleCopyString);
                if (obj != null)
                {
                    ResourceSingle resourceSingle = (ResourceSingle)obj;
                    if (this.m_res.m_resSingle.Count < Config.MaxGraph)
                    {
                        int num = 1;
                        string text;
                        for (;;)
                        {
                            text = resourceSingle.name + num;
                            if (this.m_edit.FindNameByResourceSingle(text) == null)
                            {
                                break;
                            }
                            num++;
                        }
                        resourceSingle.name = text;
                        this.m_res.m_resSingle.Add(resourceSingle);
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
                    obj = Clipboard.GetData(Config.SolidCopyString);
                    if (obj != null)
                    {
                        ResourceSolid resourceSolid = (ResourceSolid)obj;
                        if (this.m_res.m_resSolid.Count < Config.MaxGraph)
                        {
                            int num2 = 1;
                            string text2;
                            for (;;)
                            {
                                text2 = resourceSolid.name + num2;
                                if (this.m_edit.FindNameByResourceSolid(text2) == null)
                                {
                                    break;
                                }
                                num2++;
                            }
                            resourceSolid.name = text2;
                            this.m_res.m_resSolid.Add(resourceSolid);
                            this.m_tree.Nodes[1].Nodes.Add(text2);
                            this.m_edit.UpdateProperty();
                            if (this.m_fileIsChanged != null)
                            {
                                this.m_fileIsChanged(true);
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

        private FrameResource m_res;

        private TreeView m_tree;

        private ControlEdit m_edit;

        private ContextMenuStrip m_menu = new ContextMenuStrip();
    }
}
