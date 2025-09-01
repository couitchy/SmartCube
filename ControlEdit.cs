using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x0200000E RID: 14
	public class ControlEdit : UserControl
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000095 RID: 149 RVA: 0x00008F88 File Offset: 0x00007188
		// (remove) Token: 0x06000096 RID: 150 RVA: 0x00008FC0 File Offset: 0x000071C0
		private event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x06000097 RID: 151 RVA: 0x00008FF8 File Offset: 0x000071F8
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

		// Token: 0x06000098 RID: 152 RVA: 0x00009095 File Offset: 0x00007295
		private void buttonCloseAll_Click(object sender, EventArgs e)
		{
			this.CloseAll();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000909D File Offset: 0x0000729D
		public void CloseAll()
		{
			this.m_list.Clear();
			this.tabControlEdit.TabPages.Clear();
			this.buttonClose.Visible = false;
			this.buttonCloseAll.Visible = false;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000090D4 File Offset: 0x000072D4
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

		// Token: 0x0600009B RID: 155 RVA: 0x00009144 File Offset: 0x00007344
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

		// Token: 0x0600009C RID: 156 RVA: 0x000091A8 File Offset: 0x000073A8
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

		// Token: 0x0600009D RID: 157 RVA: 0x0000920C File Offset: 0x0000740C
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

		// Token: 0x0600009E RID: 158 RVA: 0x00009238 File Offset: 0x00007438
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

		// Token: 0x0600009F RID: 159 RVA: 0x000092F8 File Offset: 0x000074F8
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

		// Token: 0x060000A0 RID: 160 RVA: 0x0000934C File Offset: 0x0000754C
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

		// Token: 0x060000A1 RID: 161 RVA: 0x000093A0 File Offset: 0x000075A0
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

		// Token: 0x060000A2 RID: 162 RVA: 0x00009418 File Offset: 0x00007618
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

		// Token: 0x060000A3 RID: 163 RVA: 0x00009468 File Offset: 0x00007668
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

		// Token: 0x060000A4 RID: 164 RVA: 0x000094D4 File Offset: 0x000076D4
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

		// Token: 0x060000A5 RID: 165 RVA: 0x00009540 File Offset: 0x00007740
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

		// Token: 0x060000A6 RID: 166 RVA: 0x000095AC File Offset: 0x000077AC
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

		// Token: 0x060000A7 RID: 167 RVA: 0x000096DC File Offset: 0x000078DC
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

		// Token: 0x060000A8 RID: 168 RVA: 0x00009788 File Offset: 0x00007988
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

		// Token: 0x060000A9 RID: 169 RVA: 0x000097F4 File Offset: 0x000079F4
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

		// Token: 0x060000AA RID: 170 RVA: 0x00009AA0 File Offset: 0x00007CA0
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

		// Token: 0x060000AB RID: 171 RVA: 0x00009B28 File Offset: 0x00007D28
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

		// Token: 0x060000AC RID: 172 RVA: 0x00009DD4 File Offset: 0x00007FD4
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

		// Token: 0x060000AD RID: 173 RVA: 0x00009E44 File Offset: 0x00008044
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

		// Token: 0x060000AE RID: 174 RVA: 0x00009EB4 File Offset: 0x000080B4
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

		// Token: 0x060000AF RID: 175 RVA: 0x00009F1C File Offset: 0x0000811C
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

		// Token: 0x060000B0 RID: 176 RVA: 0x0000A01C File Offset: 0x0000821C
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

		// Token: 0x060000B1 RID: 177 RVA: 0x0000A5AC File Offset: 0x000087AC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000A5CC File Offset: 0x000087CC
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

		// Token: 0x04000047 RID: 71
		private List<ControlEdit.ListClass> m_list = new List<ControlEdit.ListClass>();

		// Token: 0x04000048 RID: 72
		private DX9 m_dx;

		// Token: 0x04000049 RID: 73
		private AllResource m_res = new AllResource();

		// Token: 0x0400004B RID: 75
		private IContainer components;

		// Token: 0x0400004C RID: 76
		private TabControl tabControlEdit;

		// Token: 0x0400004D RID: 77
		private Button buttonClose;

		// Token: 0x0400004E RID: 78
		private Button buttonCloseAll;

		// Token: 0x0200000F RID: 15
		public enum TableType
		{
			// Token: 0x04000050 RID: 80
			single,
			// Token: 0x04000051 RID: 81
			solid,
			// Token: 0x04000052 RID: 82
			singleIndex,
			// Token: 0x04000053 RID: 83
			solidIndex,
			// Token: 0x04000054 RID: 84
			numberIndex,
			// Token: 0x04000055 RID: 85
			cartoon,
			// Token: 0x04000056 RID: 86
			cartoonElement
		}

		// Token: 0x02000010 RID: 16
		public class ListClass
		{
			// Token: 0x04000057 RID: 87
			public string name = "";

			// Token: 0x04000058 RID: 88
			public bool IsChange;

			// Token: 0x04000059 RID: 89
			public ControlEdit.TableType m_type;

			// Token: 0x0400005A RID: 90
			public Control control;

			// Token: 0x0400005B RID: 91
			public TabPage page;

			// Token: 0x0400005C RID: 92
			public object obj;
		}
	}
}
