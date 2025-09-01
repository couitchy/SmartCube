using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Guan
{
    public partial class FormGuan : Forms
    {
        public event FormGuan.FileIsChanged m_fileIsChanged;

        private void FormInit()
        {
            this.InitializeComponent();
            this.Text = Config.Title;
            this.FormGuan_m_fileIsChanged(false);
            this.m_fileIsChanged += this.FormGuan_m_fileIsChanged;
        }

        public FormGuan()
        {
            this.FormInit();
        }

        public FormGuan(string path)
        {
            this.FormInit();
            this.m_path = path;
            if (this.LoadFile(false))
            {
                this.UpdateAllControl();
            }
        }

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

        private void UpdateAllControl()
        {
            this.m_resourceTree.UpdateList();
            this.m_indexTree.UpdateList();
            this.m_controlTree.UpdateList();
            this.m_edit.CloseAll();
        }

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

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            if (toolStripMenuItem.Equals(this.newToolStripMenuItem))
            {
                if (this.fileIsChanged)
                {
                    DialogResult dialogResult = MessageBox.Show("Project has been modified, do I have to save it first?", "Warning", MessageBoxButtons.YesNoCancel);
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
                    DialogResult dialogResult2 = MessageBox.Show("Project has been modified, do I have to save it first?", "Warning", MessageBoxButtons.YesNoCancel);
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
                    MessageBox.Show(text, flag ? "Success" : "Failure");
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

        private void FormGuan_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

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

        private void FormGuan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.fileIsChanged)
            {
                DialogResult dialogResult = MessageBox.Show("Project has been modified, do I have to save it first?", "Warning", MessageBoxButtons.YesNoCancel);
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
        private void FormGuan_Load(object sender, EventArgs e)
        {
            m_dx1 = new DX9();
            m_head = new AllResourceHead();
            m_res = new AllResource();
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

        private DX9 m_dx1;

        private AllResourceHead m_head;

        private AllResource m_res;

        private ReSourceTree m_resourceTree;

        private IndexTree1 m_indexTree;

        private CartoonTree m_controlTree;

        private ControlEdit m_edit;

        private string m_path = "";

        private bool fileIsChanged;

        public delegate void FileIsChanged(bool flag);

    }
}
