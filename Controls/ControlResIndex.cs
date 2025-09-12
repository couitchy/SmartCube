using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guan
{
    public class ControlResIndex : UserControl
    {
        private event FormGuan.FileIsChanged m_fileIsChanged;

        public ControlResIndex(FrameIndexType type, ControlEdit edit, ResourceIndex res, FrameResource resList, FormGuan.FileIsChanged fileIsChanged)
        {
            this.InitializeComponent();
            this.m_type = type;
            this.m_edit = edit;
            this.m_res = res;
            this.m_resList = resList;
            this.m_fileIsChanged = fileIsChanged;
            this.Dock = DockStyle.Fill;
            if (this.m_type == FrameIndexType.number)
            {
                this.m_textbox = new TextBox();
                this.m_textbox.TextAlign = HorizontalAlignment.Right;
                this.m_textbox.Hide();
                this.m_textbox.KeyPress += this.m_textbox_KeyPress;
                this.m_textbox.LostFocus += this.m_textbox_LostFocus;
                this.listView1.Controls.Add(this.m_textbox);
            }
            else
            {
                this.m_combobox = new ComboBox();
                this.m_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                this.m_combobox.Hide();
                this.m_combobox.SelectedIndexChanged += this.m_combobox_SelectedIndexChanged;
                this.m_combobox.LostFocus += this.m_combobox_LostFocus;
                this.listView1.Controls.Add(this.m_combobox);
            }
            this.m_buttonAdd = new Button();
            this.m_buttonAdd.Text = "+";
            this.m_buttonAdd.Width = 30;
            this.m_buttonAdd.Hide();
            this.m_buttonAdd.Click += this.m_buttonAdd_Click;
            this.m_buttonAdd.LostFocus += this.m_buttonAdd_LostFocus;
            this.listView1.Controls.Add(this.m_buttonAdd);
            this.m_buttonSub = new Button();
            this.m_buttonSub.Text = "-";
            this.m_buttonSub.Width = 30;
            this.m_buttonSub.Hide();
            this.m_buttonSub.Click += this.m_buttonSub_Click;
            this.m_buttonSub.LostFocus += this.m_buttonSub_LostFocus;
            this.listView1.Controls.Add(this.m_buttonSub);
            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(1, 20);
            this.listView1.SmallImageList = imageList;
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "Index";
            columnHeader.Width = 40;
            columnHeader.TextAlign = HorizontalAlignment.Left;
            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Value";
            columnHeader2.Width = 60;
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Operation";
            columnHeader3.Width = 200;
            columnHeader3.TextAlign = HorizontalAlignment.Left;
            this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader, columnHeader2, columnHeader3 });
            this.RefListView();
        }

        private void m_combobox_LostFocus(object sender, EventArgs e)
        {
            this.HideControls();
        }

        private void RefListView()
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            if (this.m_type == FrameIndexType.single)
            {
                for (int i = 0; i < this.m_res.m_element.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = (i + 1).ToString();
                    string text = "Null";
                    int index = this.m_res.m_element[i].index;
                    if (index > 0 && index <= this.m_resList.m_resSingle.Count)
                    {
                        text = this.m_resList.m_resSingle[index - 1].name;
                    }
                    listViewItem.SubItems.Add(text);
                    this.listView1.Items.Add(listViewItem);
                }
            }
            else if (this.m_type == FrameIndexType.solid)
            {
                for (int j = 0; j < this.m_res.m_element.Count; j++)
                {
                    ListViewItem listViewItem2 = new ListViewItem();
                    listViewItem2.Text = (j + 1).ToString();
                    string text2 = "Null";
                    int index2 = this.m_res.m_element[j].index;
                    if (index2 > 0 && index2 <= this.m_resList.m_resSolid.Count)
                    {
                        text2 = this.m_resList.m_resSolid[index2 - 1].name;
                    }
                    listViewItem2.SubItems.Add(text2);
                    this.listView1.Items.Add(listViewItem2);
                }
            }
            else
            {
                for (int k = 0; k < this.m_res.m_element.Count; k++)
                {
                    ListViewItem listViewItem3 = new ListViewItem();
                    listViewItem3.Text = (k + 1).ToString();
                    listViewItem3.SubItems.Add(this.m_res.m_element[k].index.ToString());
                    this.listView1.Items.Add(listViewItem3);
                }
            }
            this.listView1.EndUpdate();
        }

        private void m_buttonAdd_LostFocus(object sender, EventArgs e)
        {
            this.HideControls();
        }

        private void m_buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.elementSelectIndex >= 0 && this.m_res.m_element.Count < Config.MaxIndexElement)
            {
                this.m_res.m_element.Insert(this.elementSelectIndex, new FrameIndexElement());
                this.RefListView();
                this.listView1.Focus();
                if (this.m_fileIsChanged != null)
                {
                    this.m_fileIsChanged(true);
                }
            }
        }

        private void m_buttonSub_LostFocus(object sender, EventArgs e)
        {
            this.HideControls();
        }

        private void DeleteElement()
        {
            this.m_edit.ResourceIndexDelete(this.m_type, this.m_res);
        }

        private void m_buttonSub_Click(object sender, EventArgs e)
        {
            if (this.elementSelectIndex >= 0)
            {
                this.m_res.m_element.RemoveAt(this.elementSelectIndex);
                this.RefListView();
                this.listView1.Focus();
                this.DeleteElement();
                if (this.m_fileIsChanged != null)
                {
                    this.m_fileIsChanged(true);
                }
            }
        }

        private void GetTextboxValue()
        {
            if (this.m_type == FrameIndexType.number)
            {
                try
                {
                    int num = int.Parse(this.m_textbox.Text);
                    if (this.m_res.m_element[this.elementSelectIndex].index != num)
                    {
                        this.m_res.m_element[this.elementSelectIndex].index = num;
                        if (this.m_fileIsChanged != null)
                        {
                            this.m_fileIsChanged(true);
                        }
                    }
                }
                catch
                {
                    this.m_textbox.Text = this.m_res.m_element[this.elementSelectIndex].index.ToString();
                }
            }
        }

        private void m_textbox_LostFocus(object sender, EventArgs e)
        {
            if (this.elementSelectIndex >= 0)
            {
                this.GetTextboxValue();
                this.m_res.m_element[this.elementSelectIndex].index = int.Parse(this.m_textbox.Text);
                this.listView1.Items[this.elementSelectIndex].SubItems[1].Text = this.m_textbox.Text;
            }
            this.HideControls();
        }

        private void m_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ClassCalc.TextBoxKeyPress(-15, 15, (TextBox)sender, e))
            {
                this.GetTextboxValue();
            }
        }

        private void m_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.elementSelectIndex >= 0)
            {
                this.m_res.m_element[this.elementSelectIndex].index = this.m_combobox.SelectedIndex;
                this.RefListView();
                this.m_combobox.Focus();
                if (this.m_fileIsChanged != null)
                {
                    this.m_fileIsChanged(true);
                }
            }
        }

        public void ResourceRename(ResourceSingle res, string newName)
        {
            if (this.m_type == FrameIndexType.single)
            {
                this.RefListView();
            }
        }

        public void ResourceRename(ResourceSolid res, string newName)
        {
            if (this.m_type == FrameIndexType.solid)
            {
                this.RefListView();
            }
        }

        public void ResourceDelete()
        {
            this.RefListView();
        }

        private void ShowControls(Rectangle rect)
        {
            if (this.m_type == FrameIndexType.number)
            {
                this.m_textbox.Width = rect.Width;
                this.m_textbox.Height = rect.Height;
                this.m_textbox.Location = new Point(rect.X, rect.Y);
                this.m_textbox.Text = this.m_res.m_element[this.elementSelectIndex].index.ToString();
                this.m_buttonAdd.Height = rect.Height;
                this.m_buttonAdd.Location = new Point(rect.Right + 10, rect.Y);
                this.m_buttonSub.Height = rect.Height;
                this.m_buttonSub.Location = new Point(rect.Right + 10 + this.m_buttonAdd.Width, rect.Y);
                this.m_textbox.Show();
                this.m_buttonAdd.Show();
                if (this.m_res.m_element.Count > 1)
                {
                    this.m_buttonSub.Show();
                }
                this.m_textbox.Focus();
            }
            else
            {
                this.m_combobox.Width = rect.Width;
                this.m_combobox.Height = rect.Height;
                this.m_combobox.Location = new Point(rect.X, rect.Y);
                this.m_combobox.Items.Clear();
                this.m_combobox.Items.Add("Null");
                if (this.m_type == FrameIndexType.single)
                {
                    using (List<ResourceSingle>.Enumerator enumerator = this.m_resList.m_resSingle.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            ResourceSingle resourceSingle = enumerator.Current;
                            this.m_combobox.Items.Add(resourceSingle.name);
                        }
                        goto IL_023F;
                    }
                }
                if (this.m_type == FrameIndexType.solid)
                {
                    foreach (ResourceSolid resourceSolid in this.m_resList.m_resSolid)
                    {
                        this.m_combobox.Items.Add(resourceSolid.name);
                    }
                }
                IL_023F:
                this.m_combobox.SelectedIndex = this.m_res.m_element[this.elementSelectIndex].index;
                this.m_buttonAdd.Height = rect.Height;
                this.m_buttonAdd.Location = new Point(rect.Right + 10, rect.Y);
                this.m_buttonSub.Height = rect.Height;
                this.m_buttonSub.Location = new Point(rect.Right + 10 + this.m_buttonAdd.Width, rect.Y);
                this.m_combobox.Show();
                this.m_buttonAdd.Show();
                if (this.m_res.m_element.Count > 1)
                {
                    this.m_buttonSub.Show();
                }
                this.m_combobox.Focus();
            }
            this.selectFlag = true;
        }

        private void HideControls()
        {
            if (this.m_type == FrameIndexType.number)
            {
                if (!this.m_textbox.Focused && !this.m_buttonAdd.Focused && !this.m_buttonSub.Focused)
                {
                    this.m_textbox.Hide();
                    this.m_buttonAdd.Hide();
                    this.m_buttonSub.Hide();
                }
            }
            else if (!this.m_combobox.Focused && !this.m_buttonAdd.Focused && !this.m_buttonSub.Focused)
            {
                this.m_combobox.Hide();
                this.m_buttonAdd.Hide();
                this.m_buttonSub.Hide();
            }
            this.selectFlag = false;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.selectFlag)
            {
                return;
            }
            ListView.SelectedListViewItemCollection selectedItems = this.listView1.SelectedItems;
            if (selectedItems != null)
            {
                ListViewItem listViewItem = selectedItems[0];
                this.elementSelectIndex = this.listView1.Items.IndexOf(listViewItem);
                if (this.elementSelectIndex != -1)
                {
                    try
                    {
                        Rectangle bounds = listViewItem.SubItems[1].Bounds;
                        this.ShowControls(bounds);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            if (this.m_res.m_element.Count < Config.MaxIndexElement)
            {
                this.m_res.m_element.Add(new FrameIndexElement());
                this.RefListView();
                if (this.m_fileIsChanged != null)
                {
                    this.m_fileIsChanged(true);
                }
            }
        }

        private void InitializeComponent()
        {
            this.listView1 = new ListView();
            this.buttonAddNew = new Button();
            base.SuspendLayout();
            this.listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new Point(19, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(248, 163);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += this.listView1_DoubleClick;
            this.listView1.Click += this.listView1_Click;
            this.buttonAddNew.Location = new Point(19, 189);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new Size(61, 30);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "New";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += this.buttonAddNew_Click;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.buttonAddNew);
            base.Controls.Add(this.listView1);
            base.Name = "ControlResIndex";
            base.Size = new Size(348, 227);
            base.ResumeLayout(false);
        }

        private FrameIndexType m_type;

        private ResourceIndex m_res;

        private FrameResource m_resList;

        private ControlEdit m_edit;

        private Label m_label = new Label();

        private TextBox m_textbox;

        private ComboBox m_combobox;

        private Button m_buttonAdd;

        private Button m_buttonSub;

        private int elementSelectIndex = -1;

        private bool selectFlag;

        private ListView listView1;

        private Button buttonAddNew;
    }
}
