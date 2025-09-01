using System;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	internal class CartoonTree
	{
		private event FormGuan.FileIsChanged m_fileIsChanged;

		public CartoonTree(AllResource res, FrameControl control, TreeView tree, ControlEdit edit, FormGuan.FileIsChanged fileIsChanged)
		{
			this.m_res = res;
			this.m_control = control;
			this.m_tree = tree;
			this.m_edit = edit;
			this.m_fileIsChanged = fileIsChanged;
			this.m_tree.AllowDrop = true;
			this.m_tree.ExpandAll();
			this.m_tree.ItemDrag += this.m_tree_ItemDrag;
			this.m_tree.DragEnter += this.m_tree_DragEnter;
			this.m_tree.DragDrop += this.m_tree_DragDrop;
			this.m_tree.DragOver += this.m_tree_DragOver;
			this.m_tree.MouseDown += this.m_tree_MouseDown;
			this.m_tree.DoubleClick += this.m_tree_DoubleClick;
			this.m_tree.KeyDown += this.m_tree_KeyDown;
			this.m_menu.Items.Add("Add " + Config.CartoonGroup);
			this.m_menu.Items.Add("Add " + Config.CartoonElement);
			this.m_menu.Items.Add("Rename");
			this.m_menu.Items.Add("Delete");
			this.m_menu.Items.Add("Up(U)");
			this.m_menu.Items.Add("Down(D)");
			this.m_menu.Items.Add("Copy(CTRL+C)");
			this.m_menu.Items.Add("Paste(CTRL+V)");
			this.m_menu.Items.Add("Run");
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
					return;
				}
			}
			else
			{
				if (e.KeyCode == Keys.U)
				{
					this.UpList();
					return;
				}
				if (e.KeyCode == Keys.D)
				{
					this.DownList();
				}
			}
		}

		private void m_tree_DragOver(object sender, DragEventArgs e)
		{
			TreeView treeView = (TreeView)sender;
			TreeNode nodeAt = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
			if (nodeAt != null)
			{
				treeView.SelectedNode = nodeAt;
			}
		}

		private void m_tree_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.m_tree.DoDragDrop(e.Item, DragDropEffects.Move);
			}
		}

		private void m_tree_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNode)))
			{
				TreeNode treeNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
				Point point = this.m_tree.PointToClient(new Point(e.X, e.Y));
				TreeNode nodeAt = this.m_tree.GetNodeAt(point);
				if (treeNode != null && nodeAt != null && treeNode != nodeAt)
				{
					try
					{
						if (treeNode.Parent != null)
						{
							int num = this.m_tree.Nodes.IndexOf(treeNode.Parent);
							int num2 = this.m_tree.Nodes[num].Nodes.IndexOf(treeNode);
							if (nodeAt.Parent != null)
							{
								int num3 = this.m_tree.Nodes.IndexOf(nodeAt.Parent);
								int num4 = this.m_tree.Nodes[num3].Nodes.IndexOf(nodeAt);
								FrameCartoonGroup frameCartoonGroup = this.m_control.m_cartoon[num].groups[num2];
								this.m_control.m_cartoon[num].groups.RemoveAt(num2);
								this.m_control.m_cartoon[num3].groups.Insert(num4, frameCartoonGroup);
								TreeNode treeNode2 = this.m_tree.Nodes[num].Nodes[num2];
								this.m_tree.Nodes[num].Nodes.RemoveAt(num2);
								this.m_tree.Nodes[num3].Nodes.Insert(num4, treeNode2);
								if (this.m_fileIsChanged != null)
								{
									this.m_fileIsChanged(true);
								}
							}
							else
							{
								int num5 = this.m_tree.Nodes.IndexOf(nodeAt);
								FrameCartoonGroup frameCartoonGroup2 = this.m_control.m_cartoon[num].groups[num2];
								this.m_control.m_cartoon[num].groups.RemoveAt(num2);
								this.m_control.m_cartoon[num5].groups.Insert(0, frameCartoonGroup2);
								TreeNode treeNode3 = this.m_tree.Nodes[num].Nodes[num2];
								this.m_tree.Nodes[num].Nodes.RemoveAt(num2);
								this.m_tree.Nodes[num5].Nodes.Insert(0, treeNode3);
								if (this.m_fileIsChanged != null)
								{
									this.m_fileIsChanged(true);
								}
							}
						}
						else
						{
							try
							{
								int num6 = this.m_tree.Nodes.IndexOf(treeNode);
								int num7;
								if (nodeAt.Parent != null)
								{
									num7 = this.m_tree.Nodes.IndexOf(nodeAt.Parent);
								}
								else
								{
									num7 = this.m_tree.Nodes.IndexOf(nodeAt);
								}
								if (num6 != num7)
								{
									FrameCartoonControl frameCartoonControl = this.m_control.m_cartoon[num6];
									this.m_control.m_cartoon.RemoveAt(num6);
									this.m_control.m_cartoon.Insert(num7, frameCartoonControl);
									TreeNode treeNode4 = this.m_tree.Nodes[num6];
									this.m_tree.Nodes.RemoveAt(num6);
									this.m_tree.Nodes.Insert(num7, treeNode4);
									if (this.m_fileIsChanged != null)
									{
										this.m_fileIsChanged(true);
									}
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.ToString());
							}
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.ToString());
					}
				}
			}
		}

		private void m_tree_DragEnter(object sender, DragEventArgs e)
		{
			object data = e.Data.GetData(typeof(TreeNode));
			if (data != null)
			{
				e.Effect = DragDropEffects.Move;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		public void UpdateList()
		{
			this.m_tree.Nodes.Clear();
			int num = 0;
			foreach (FrameCartoonControl frameCartoonControl in this.m_control.m_cartoon)
			{
				this.m_tree.Nodes.Add(frameCartoonControl.name);
				foreach (FrameCartoonGroup frameCartoonGroup in frameCartoonControl.groups)
				{
					this.m_tree.Nodes[num].Nodes.Add(frameCartoonGroup.name);
				}
				num++;
			}
		}

		private void m_tree_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.m_tree.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Parent != null)
				{
					int num = this.m_tree.Nodes.IndexOf(selectedNode.Parent);
					int num2 = this.m_tree.Nodes[num].Nodes.IndexOf(selectedNode);
					this.m_edit.ShowCartoonElement(this.m_control.m_cartoon[num].groups[num2]);
					return;
				}
				int num3 = this.m_tree.Nodes.IndexOf(selectedNode);
				if (num3 < this.m_control.m_cartoon.Count)
				{
					this.m_edit.ShowCartoon(this.m_control.m_cartoon[num3]);
				}
			}
		}

		private void m_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Equals(this.m_menu.Items[0]))
			{
				FrameCartoonControl frameCartoonControl = new FrameCartoonControl();
				frameCartoonControl.name = Config.CartoonGroup;
				this.m_control.m_cartoon.Add(frameCartoonControl);
				this.m_tree.Nodes.Add(frameCartoonControl.name);
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
					return;
				}
			}
			else if (e.ClickedItem.Equals(this.m_menu.Items[1]))
			{
				TreeNode treeNode = this.m_tree.SelectedNode;
				if (treeNode != null)
				{
					if (treeNode.Parent != null)
					{
						treeNode = treeNode.Parent;
					}
					FrameCartoonGroup frameCartoonGroup = new FrameCartoonGroup();
					frameCartoonGroup.name = Config.CartoonElement;
					int num = this.m_tree.Nodes.IndexOf(treeNode);
					this.m_control.m_cartoon[num].groups.Add(frameCartoonGroup);
					treeNode.Nodes.Add(frameCartoonGroup.name);
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(true);
						return;
					}
				}
			}
			else if (e.ClickedItem.Equals(this.m_menu.Items[2]))
			{
				TreeNode selectedNode = this.m_tree.SelectedNode;
				if (selectedNode != null)
				{
					if (selectedNode.Parent != null)
					{
						int num2 = this.m_tree.Nodes.IndexOf(selectedNode.Parent);
						int num3 = this.m_tree.Nodes[num2].Nodes.IndexOf(selectedNode);
						FormRename formRename = new FormRename();
						formRename.name = selectedNode.Text;
						DialogResult dialogResult = formRename.ShowDialog();
						if (dialogResult == DialogResult.OK)
						{
							string name = formRename.name;
							this.m_edit.ChangeName(this.m_control.m_cartoon[num2].groups[num3], name);
							selectedNode.Text = name;
							this.m_control.m_cartoon[num2].groups[num3].name = name;
							if (this.m_fileIsChanged != null)
							{
								this.m_fileIsChanged(true);
								return;
							}
						}
					}
					else
					{
						int num4 = this.m_tree.Nodes.IndexOf(selectedNode);
						FormRename formRename2 = new FormRename();
						formRename2.name = selectedNode.Text;
						DialogResult dialogResult2 = formRename2.ShowDialog();
						if (dialogResult2 == DialogResult.OK)
						{
							string name2 = formRename2.name;
							this.m_edit.ChangeName(this.m_control.m_cartoon[num4], name2);
							selectedNode.Text = name2;
							this.m_control.m_cartoon[num4].name = name2;
							if (this.m_fileIsChanged != null)
							{
								this.m_fileIsChanged(true);
								return;
							}
						}
					}
				}
			}
			else if (e.ClickedItem.Equals(this.m_menu.Items[3]))
			{
				TreeNode selectedNode2 = this.m_tree.SelectedNode;
				if (selectedNode2 != null)
				{
					if (selectedNode2.Parent != null)
					{
						int num5 = this.m_tree.Nodes.IndexOf(selectedNode2.Parent);
						int num6 = this.m_tree.Nodes[num5].Nodes.IndexOf(selectedNode2);
						this.m_edit.DeleteObj(this.m_control.m_cartoon[num5].groups[num6]);
						this.m_control.m_cartoon[num5].groups.RemoveAt(num6);
						this.m_tree.Nodes[num5].Nodes.Remove(selectedNode2);
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(true);
							return;
						}
					}
					else
					{
						int num7 = this.m_tree.Nodes.IndexOf(selectedNode2);
						this.m_edit.DeleteObj(this.m_control.m_cartoon[num7]);
						foreach (FrameCartoonGroup frameCartoonGroup2 in this.m_control.m_cartoon[num7].groups)
						{
							this.m_edit.DeleteObj(frameCartoonGroup2);
						}
						this.m_control.m_cartoon.RemoveAt(num7);
						this.m_tree.Nodes.Remove(selectedNode2);
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(true);
							return;
						}
					}
				}
			}
			else
			{
				if (e.ClickedItem.Equals(this.m_menu.Items[4]))
				{
					this.UpList();
					return;
				}
				if (e.ClickedItem.Equals(this.m_menu.Items[5]))
				{
					this.DownList();
					return;
				}
				if (e.ClickedItem.Equals(this.m_menu.Items[6]))
				{
					this.Copy();
					return;
				}
				if (e.ClickedItem.Equals(this.m_menu.Items[7]))
				{
					this.Paste();
					return;
				}
				if (e.ClickedItem.Equals(this.m_menu.Items[8]))
				{
					this.DebugList();
				}
			}
		}

		private void DebugList()
		{
			TreeNode selectedNode = this.m_tree.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Parent != null)
				{
					int num = this.m_tree.Nodes.IndexOf(selectedNode.Parent);
					int num2 = this.m_tree.Nodes[num].Nodes.IndexOf(selectedNode);
					if (num2 >= 0)
					{
						FrameCartoonGroup frameCartoonGroup = this.m_control.m_cartoon[num].groups[num2];
						FormDebug formDebug = new FormDebug(this.m_res, frameCartoonGroup);
						formDebug.ShowDialog();
						return;
					}
				}
				else
				{
					int num3 = this.m_tree.Nodes.IndexOf(selectedNode);
					if (num3 >= 0)
					{
						FrameCartoonControl frameCartoonControl = this.m_control.m_cartoon[num3];
						FormDebug formDebug2 = new FormDebug(this.m_res, frameCartoonControl);
						formDebug2.ShowDialog();
					}
				}
			}
		}

		private void UpList()
		{
			TreeNode treeNode = this.m_tree.SelectedNode;
			if (treeNode != null)
			{
				if (treeNode.Parent != null)
				{
					int num = this.m_tree.Nodes.IndexOf(treeNode.Parent);
					int num2 = this.m_tree.Nodes[num].Nodes.IndexOf(treeNode);
					if (num2 > 0)
					{
						FrameCartoonGroup frameCartoonGroup = this.m_control.m_cartoon[num].groups[num2];
						treeNode = this.m_tree.Nodes[num].Nodes[num2];
						this.m_control.m_cartoon[num].groups.RemoveAt(num2);
						this.m_tree.Nodes[num].Nodes.RemoveAt(num2);
						this.m_control.m_cartoon[num].groups.Insert(num2 - 1, frameCartoonGroup);
						this.m_tree.Nodes[num].Nodes.Insert(num2 - 1, treeNode);
						this.m_tree.SelectedNode = treeNode;
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(true);
							return;
						}
					}
				}
				else
				{
					int num3 = this.m_tree.Nodes.IndexOf(treeNode);
					if (num3 > 0)
					{
						FrameCartoonControl frameCartoonControl = this.m_control.m_cartoon[num3];
						treeNode = this.m_tree.Nodes[num3];
						this.m_control.m_cartoon.RemoveAt(num3);
						this.m_tree.Nodes.RemoveAt(num3);
						this.m_control.m_cartoon.Insert(num3 - 1, frameCartoonControl);
						this.m_tree.Nodes.Insert(num3 - 1, treeNode);
						this.m_tree.SelectedNode = treeNode;
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(true);
						}
					}
				}
			}
		}

		private void DownList()
		{
			TreeNode treeNode = this.m_tree.SelectedNode;
			if (treeNode != null)
			{
				if (treeNode.Parent != null)
				{
					int num = this.m_tree.Nodes.IndexOf(treeNode.Parent);
					int num2 = this.m_tree.Nodes[num].Nodes.IndexOf(treeNode);
					if (num2 >= 0 && num2 < this.m_control.m_cartoon[num].groups.Count - 1)
					{
						FrameCartoonGroup frameCartoonGroup = this.m_control.m_cartoon[num].groups[num2];
						treeNode = this.m_tree.Nodes[num].Nodes[num2];
						this.m_control.m_cartoon[num].groups.RemoveAt(num2);
						this.m_tree.Nodes[num].Nodes.RemoveAt(num2);
						this.m_control.m_cartoon[num].groups.Insert(num2 + 1, frameCartoonGroup);
						this.m_tree.Nodes[num].Nodes.Insert(num2 + 1, treeNode);
						this.m_tree.SelectedNode = treeNode;
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(true);
							return;
						}
					}
				}
				else
				{
					int num3 = this.m_tree.Nodes.IndexOf(treeNode);
					if (num3 >= 0 && num3 < this.m_control.m_cartoon.Count - 1)
					{
						FrameCartoonControl frameCartoonControl = this.m_control.m_cartoon[num3];
						treeNode = this.m_tree.Nodes[num3];
						this.m_control.m_cartoon.RemoveAt(num3);
						this.m_tree.Nodes.RemoveAt(num3);
						this.m_control.m_cartoon.Insert(num3 + 1, frameCartoonControl);
						this.m_tree.Nodes.Insert(num3 + 1, treeNode);
						this.m_tree.SelectedNode = treeNode;
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(true);
						}
					}
				}
			}
		}

		private void Copy()
		{
			TreeNode selectedNode = this.m_tree.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Parent != null)
				{
					int num = this.m_tree.Nodes.IndexOf(selectedNode.Parent);
					int num2 = this.m_tree.Nodes[num].Nodes.IndexOf(selectedNode);
					if (num2 >= 0)
					{
						FrameCartoonGroup frameCartoonGroup = this.m_control.m_cartoon[num].groups[num2];
						Clipboard.SetData(Config.GroupCopyString, frameCartoonGroup);
						return;
					}
				}
				else
				{
					int num3 = this.m_tree.Nodes.IndexOf(selectedNode);
					if (num3 >= 0)
					{
						FrameCartoonControl frameCartoonControl = this.m_control.m_cartoon[num3];
						Clipboard.SetData(Config.ControlCopyString, frameCartoonControl);
					}
				}
			}
		}

		private void Paste()
		{
			object obj = Clipboard.GetData(Config.ControlCopyString);
			if (obj != null)
			{
				FrameCartoonControl frameCartoonControl = (FrameCartoonControl)obj;
				this.m_control.m_cartoon.Add(frameCartoonControl);
				TreeNode treeNode = this.m_tree.Nodes.Add(frameCartoonControl.name);
				foreach (FrameCartoonGroup frameCartoonGroup in frameCartoonControl.groups)
				{
					treeNode.Nodes.Add(frameCartoonGroup.name);
				}
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(true);
					return;
				}
			}
			else
			{
				obj = Clipboard.GetData(Config.GroupCopyString);
				if (obj != null)
				{
					FrameCartoonGroup frameCartoonGroup2 = (FrameCartoonGroup)obj;
					TreeNode selectedNode = this.m_tree.SelectedNode;
					if (selectedNode != null && selectedNode.Parent != null)
					{
						int num = this.m_tree.Nodes.IndexOf(selectedNode.Parent);
						if (num >= 0)
						{
							this.m_control.m_cartoon[num].groups.Add(frameCartoonGroup2);
							selectedNode.Parent.Nodes.Add(frameCartoonGroup2.name);
							if (this.m_fileIsChanged != null)
							{
								this.m_fileIsChanged(true);
							}
						}
					}
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
					this.m_menu.Items[3].Enabled = true;
					this.m_menu.Items[2].Enabled = true;
					this.m_menu.Items[1].Enabled = true;
					this.m_menu.Items[6].Enabled = true;
					this.m_menu.Items[7].Enabled = true;
					this.m_menu.Items[8].Enabled = true;
				}
				else
				{
					this.m_menu.Items[3].Enabled = false;
					this.m_menu.Items[2].Enabled = false;
					this.m_menu.Items[1].Enabled = false;
					this.m_menu.Items[6].Enabled = false;
					this.m_menu.Items[7].Enabled = false;
					this.m_menu.Items[8].Enabled = false;
				}
				this.m_menu.Show(this.m_tree.PointToScreen(e.Location));
			}
		}

		private FrameControl m_control;

		private TreeView m_tree;

		private ControlEdit m_edit;

		private ContextMenuStrip m_menu = new ContextMenuStrip();

		private AllResource m_res;
	}
}
