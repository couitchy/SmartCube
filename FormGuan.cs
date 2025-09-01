using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Guan
{
	// Token: 0x02000037 RID: 55
	public partial class FormGuan : Forms
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060001D9 RID: 473 RVA: 0x0001199C File Offset: 0x0000FB9C
		// (remove) Token: 0x060001DA RID: 474 RVA: 0x000119D4 File Offset: 0x0000FBD4
		public event FormGuan.FileIsChanged m_fileIsChanged;

		// Token: 0x060001DB RID: 475 RVA: 0x00011A09 File Offset: 0x0000FC09
		private void FormInit()
		{
			this.InitializeComponent();
			this.Text = Config.Title;
			this.FormGuan_m_fileIsChanged(false);
			this.m_fileIsChanged += this.FormGuan_m_fileIsChanged;
			this.ControlInit();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00011A3B File Offset: 0x0000FC3B
		public FormGuan()
		{
			this.FormInit();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00011A78 File Offset: 0x0000FC78
		public FormGuan(string path)
		{
			this.FormInit();
			this.m_path = path;
			if (this.LoadFile(false))
			{
				this.UpdateAllControl();
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00011AD4 File Offset: 0x0000FCD4
		private void FormGuan_m_fileIsChanged(bool flag)
		{
			if (flag)
			{
				if (this.fileIsChanged != flag)
				{
					this.fileIsChanged = flag;
					this.Text = Config.Title + "*";
					return;
				}
			}
			else if (this.fileIsChanged != flag)
			{
				this.fileIsChanged = flag;
				this.Text = Config.Title;
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00011B28 File Offset: 0x0000FD28
		private void ControlInit()
		{
			ControlDX controlDX = new ControlDX(this.panelPreview);
			this.panelPreview.Controls.Add(controlDX);
			this.m_dx1.InitializeGraphics(controlDX);
			this.m_dx1.SetBright(100);
			this.m_edit = new ControlEdit(this.m_dx1, this.m_res, this.m_fileIsChanged);
			this.m_edit.Location = new Point(5, 10);
			this.splitContainer3.Panel2.Controls.Add(this.m_edit);
			this.m_resourceTree = new ReSourceTree(this.m_res.m_res, this.treeViewResource, this.m_edit, this.m_fileIsChanged);
			this.m_indexTree = new IndexTree1(this.m_res.m_index, this.treeViewIndex, this.m_edit, this.m_fileIsChanged);
			this.m_controlTree = new CartoonTree(this.m_res, this.m_res.m_control, this.treeViewCartoon, this.m_edit, this.m_fileIsChanged);
			this.compileToolStripMenuItem.Enabled = Config.enableOutput;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00011C45 File Offset: 0x0000FE45
		private void UpdateAllControl()
		{
			this.m_resourceTree.UpdateList();
			this.m_indexTree.UpdateList();
			this.m_controlTree.UpdateList();
			this.m_edit.CloseAll();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00011C74 File Offset: 0x0000FE74
		private bool LoadFile(bool selectFile)
		{
			try
			{
				if (selectFile || this.m_path == "")
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.InitialDirectory = Environment.CurrentDirectory;
					openFileDialog.Filter = string.Format("Project(*.{0})|*.{0}", Config.FileSuffix);
					DialogResult dialogResult = openFileDialog.ShowDialog();
					if (dialogResult != DialogResult.OK)
					{
						return false;
					}
					this.m_path = openFileDialog.FileName;
				}
				FileStream fileStream = new FileStream(this.m_path, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				AllResource allResource = binaryFormatter.Deserialize(fileStream) as AllResource;
				this.m_res.Clear();
				try
				{
					if (allResource.m_head.version > 1024)
					{
						MessageBox.Show("File version error!");
						return false;
					}
					this.m_res.m_head = allResource.m_head;
					if (allResource.m_head.version < 1024)
					{
						this.m_res.m_head.version = 1024;
					}
					this.m_res.m_control.m_cartoon = allResource.m_control.m_cartoon;
					this.m_res.m_res.m_resSingle = allResource.m_res.m_resSingle;
					this.m_res.m_res.m_resSolid = allResource.m_res.m_resSolid;
					this.m_res.m_index.m_indexSingle = allResource.m_index.m_indexSingle;
					this.m_res.m_index.m_indexSolid = allResource.m_index.m_indexSolid;
					this.m_res.m_index.m_indexNumber = allResource.m_index.m_indexNumber;
				}
				catch (Exception ex)
				{
					fileStream.Close();
					MessageBox.Show(ex.ToString());
					return false;
				}
				fileStream.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.ToString());
				return false;
			}
			return true;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00011E84 File Offset: 0x00010084
		private bool SaveFile(bool selectFile)
		{
			try
			{
				if (selectFile || this.m_path == "")
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
					saveFileDialog.Filter = string.Format("Project(*.{0})|*.{0}", Config.FileSuffix);
					DialogResult dialogResult = saveFileDialog.ShowDialog();
					if (dialogResult != DialogResult.OK)
					{
						return false;
					}
					this.m_path = saveFileDialog.FileName;
				}
				FileStream fileStream = new FileStream(this.m_path, FileMode.OpenOrCreate);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, this.m_res);
				fileStream.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00011F2C File Offset: 0x0001012C
		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			if (toolStripMenuItem.Equals(this.newToolStripMenuItem))
			{
				if (this.fileIsChanged)
				{
					DialogResult dialogResult = MessageBox.Show("Project has been modified, do I have to save and close the first?", "Warning", MessageBoxButtons.YesNoCancel);
					if (dialogResult == DialogResult.Yes)
					{
						if (!this.SaveFile(false))
						{
							MessageBox.Show("Save file failed!");
							return;
						}
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(false);
							return;
						}
					}
					else if (dialogResult == DialogResult.No)
					{
						this.m_path = "";
						this.m_res.Clear();
						this.UpdateAllControl();
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(false);
							return;
						}
					}
				}
				else
				{
					this.m_path = "";
					this.m_res.Clear();
					this.UpdateAllControl();
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(false);
						return;
					}
				}
			}
			else if (toolStripMenuItem.Equals(this.openToolStripMenuItem))
			{
				if (this.fileIsChanged)
				{
					DialogResult dialogResult2 = MessageBox.Show("Project has been modified, do I have to save and close the first?", "Warning", MessageBoxButtons.YesNoCancel);
					if (dialogResult2 == DialogResult.Yes)
					{
						if (!this.SaveFile(false))
						{
							MessageBox.Show("Save file failed!");
							return;
						}
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(false);
							return;
						}
					}
					else if (dialogResult2 == DialogResult.No)
					{
						if (!this.LoadFile(true))
						{
							MessageBox.Show("Save file failed!");
							return;
						}
						this.UpdateAllControl();
						if (this.m_fileIsChanged != null)
						{
							this.m_fileIsChanged(false);
							return;
						}
					}
				}
				else
				{
					if (!this.LoadFile(true))
					{
						MessageBox.Show("Open file failed!");
						return;
					}
					this.UpdateAllControl();
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(false);
						return;
					}
				}
			}
			else if (toolStripMenuItem.Equals(this.saveToolStripMenuItem))
			{
				if (!this.SaveFile(false))
				{
					MessageBox.Show("Save file failed!");
					return;
				}
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(false);
					return;
				}
			}
			else if (toolStripMenuItem.Equals(this.saveAsToolStripMenuItem))
			{
				if (!this.SaveFile(true))
				{
					MessageBox.Show("Save file failed!");
					return;
				}
				if (this.m_fileIsChanged != null)
				{
					this.m_fileIsChanged(false);
					return;
				}
			}
			else
			{
				if (toolStripMenuItem.Equals(this.compileToolStripMenuItem))
				{
					ClassHex classHex = new ClassHex(this.m_head, this.m_res);
					string text;
					bool flag = classHex.IsChangeOK(this.m_head.GetBit(AllResourceHead.bitValue.OutPutCFile), out text);
					MessageBox.Show(text, flag ? "Succeed" : "Failure");
					return;
				}
				if (toolStripMenuItem.Equals(this.exitToolStripMenuItem))
				{
					base.Close();
					return;
				}
				if (toolStripMenuItem.Equals(this.debugToolStripMenuItem))
				{
					FormDebug formDebug = new FormDebug(this.m_res);
					formDebug.ShowDialog();
					return;
				}
				if (toolStripMenuItem.Equals(this.debugConfigToolStripMenuItem))
				{
					FormConfig formConfig = new FormConfig(this.m_head, this.m_res.m_head, this.m_fileIsChanged);
					formConfig.ShowDialog();
					return;
				}
				if (toolStripMenuItem.Equals(this.InstructionsToolStripMenuItem))
				{
					FormDescription formDescription = new FormDescription();
					formDescription.ShowDialog();
					return;
				}
				if (toolStripMenuItem.Equals(this.aboutUsToolStripMenuItem))
				{
					FormAbout formAbout = new FormAbout();
					formAbout.ShowDialog();
				}
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00012241 File Offset: 0x00010441
		private void FormGuan_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Link;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001224C File Offset: 0x0001044C
		private void FormGuan_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string text = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
				this.m_path = text;
				if (this.LoadFile(false))
				{
					this.UpdateAllControl();
					if (this.m_fileIsChanged != null)
					{
						this.m_fileIsChanged(false);
					}
				}
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000122B8 File Offset: 0x000104B8
		private void FormGuan_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.fileIsChanged)
			{
				DialogResult dialogResult = MessageBox.Show("Project has been modified, do I have to save to exit the first?", "Warning", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					if (!this.SaveFile(false))
					{
						MessageBox.Show("Save file failed!");
						e.Cancel = true;
						return;
					}
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		// Token: 0x0400015D RID: 349
		private DX9 m_dx1 = new DX9();

		// Token: 0x0400015E RID: 350
		private AllResourceHead m_head = new AllResourceHead();

		// Token: 0x0400015F RID: 351
		private AllResource m_res = new AllResource();

		// Token: 0x04000160 RID: 352
		private ReSourceTree m_resourceTree;

		// Token: 0x04000161 RID: 353
		private IndexTree1 m_indexTree;

		// Token: 0x04000162 RID: 354
		private CartoonTree m_controlTree;

		// Token: 0x04000163 RID: 355
		private ControlEdit m_edit;

		// Token: 0x04000164 RID: 356
		private string m_path = "";

		// Token: 0x04000165 RID: 357
		private bool fileIsChanged;

		// Token: 0x02000038 RID: 56
		// (Invoke) Token: 0x060001EA RID: 490
		public delegate void FileIsChanged(bool flag);
	}
}
