namespace Guan
{
    public partial class FormGuan : global::Guan.Forms
    {
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBoxCartoon = new System.Windows.Forms.GroupBox();
            this.treeViewCartoon = new System.Windows.Forms.TreeView();
            this.groupBoxPre = new System.Windows.Forms.GroupBox();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxGra = new System.Windows.Forms.GroupBox();
            this.treeViewResource = new System.Windows.Forms.TreeView();
            this.groupBoxIndex = new System.Windows.Forms.GroupBox();
            this.treeViewIndex = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBoxCartoon.SuspendLayout();
            this.groupBoxPre.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxGra.SuspendLayout();
            this.groupBoxIndex.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 693);
            this.splitContainer1.SplitterDistance = 609;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, -2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(610, 695);
            this.splitContainer3.SplitterDistance = 431;
            this.splitContainer3.TabIndex = 3;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBoxCartoon);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBoxPre);
            this.splitContainer4.Size = new System.Drawing.Size(612, 437);
            this.splitContainer4.SplitterDistance = 170;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBoxCartoon
            // 
            this.groupBoxCartoon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCartoon.Controls.Add(this.treeViewCartoon);
            this.groupBoxCartoon.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCartoon.Name = "groupBoxCartoon";
            this.groupBoxCartoon.Size = new System.Drawing.Size(162, 423);
            this.groupBoxCartoon.TabIndex = 0;
            this.groupBoxCartoon.TabStop = false;
            this.groupBoxCartoon.Text = "Cartoon";
            // 
            // treeViewCartoon
            // 
            this.treeViewCartoon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewCartoon.Location = new System.Drawing.Point(6, 22);
            this.treeViewCartoon.Name = "treeViewCartoon";
            this.treeViewCartoon.Size = new System.Drawing.Size(150, 394);
            this.treeViewCartoon.TabIndex = 0;
            // 
            // groupBoxPre
            // 
            this.groupBoxPre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPre.Controls.Add(this.panelPreview);
            this.groupBoxPre.Location = new System.Drawing.Point(5, 3);
            this.groupBoxPre.Name = "groupBoxPre";
            this.groupBoxPre.Size = new System.Drawing.Size(423, 423);
            this.groupBoxPre.TabIndex = 0;
            this.groupBoxPre.TabStop = false;
            this.groupBoxPre.Text = "Preview";
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelPreview.Location = new System.Drawing.Point(6, 23);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(411, 387);
            this.panelPreview.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxGra);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxIndex);
            this.splitContainer2.Size = new System.Drawing.Size(172, 693);
            this.splitContainer2.SplitterDistance = 353;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxGra
            // 
            this.groupBoxGra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGra.Controls.Add(this.treeViewResource);
            this.groupBoxGra.Location = new System.Drawing.Point(1, 5);
            this.groupBoxGra.Name = "groupBoxGra";
            this.groupBoxGra.Size = new System.Drawing.Size(168, 342);
            this.groupBoxGra.TabIndex = 0;
            this.groupBoxGra.TabStop = false;
            this.groupBoxGra.Text = "Resource list";
            // 
            // treeViewResource
            // 
            this.treeViewResource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewResource.Location = new System.Drawing.Point(6, 23);
            this.treeViewResource.Name = "treeViewResource";
            this.treeViewResource.Size = new System.Drawing.Size(150, 310);
            this.treeViewResource.TabIndex = 0;
            // 
            // groupBoxIndex
            // 
            this.groupBoxIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxIndex.Controls.Add(this.treeViewIndex);
            this.groupBoxIndex.Location = new System.Drawing.Point(1, 3);
            this.groupBoxIndex.Name = "groupBoxIndex";
            this.groupBoxIndex.Size = new System.Drawing.Size(168, 327);
            this.groupBoxIndex.TabIndex = 1;
            this.groupBoxIndex.TabStop = false;
            this.groupBoxIndex.Text = "Index table list";
            // 
            // treeViewIndex
            // 
            this.treeViewIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewIndex.Location = new System.Drawing.Point(6, 22);
            this.treeViewIndex.Name = "treeViewIndex";
            this.treeViewIndex.Size = new System.Drawing.Size(150, 298);
            this.treeViewIndex.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.functionToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.compileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.functionToolStripMenuItem.Text = "Debug";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.debugToolStripMenuItem.Text = "Run";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareConfigToolStripMenuItem,
            this.hardwareConfigToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // softwareConfigToolStripMenuItem
            // 
            this.softwareConfigToolStripMenuItem.Name = "softwareConfigToolStripMenuItem";
            this.softwareConfigToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.softwareConfigToolStripMenuItem.Text = "Software config";
            this.softwareConfigToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // hardwareConfigToolStripMenuItem
            // 
            this.hardwareConfigToolStripMenuItem.Name = "hardwareConfigToolStripMenuItem";
            this.hardwareConfigToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.hardwareConfigToolStripMenuItem.Text = "Hardware config";
            this.hardwareConfigToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionsToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // InstructionsToolStripMenuItem
            // 
            this.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem";
            this.InstructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.InstructionsToolStripMenuItem.Text = "Instructions";
            this.InstructionsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // FormGuan
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(785, 717);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 538);
            this.Name = "FormGuan";
            this.Text = "Guan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGuan_FormClosing);
            this.Load += new System.EventHandler(this.FormGuan_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormGuan_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormGuan_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.groupBoxCartoon.ResumeLayout(false);
            this.groupBoxPre.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxGra.ResumeLayout(false);
            this.groupBoxIndex.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private global::System.Windows.Forms.SplitContainer splitContainer1;

        private global::System.Windows.Forms.SplitContainer splitContainer2;

        private global::System.Windows.Forms.GroupBox groupBoxGra;

        private global::System.Windows.Forms.GroupBox groupBoxIndex;

        private global::System.Windows.Forms.MenuStrip menuStrip1;

        private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private global::System.Windows.Forms.SplitContainer splitContainer3;

        private global::System.Windows.Forms.SplitContainer splitContainer4;

        private global::System.Windows.Forms.GroupBox groupBoxPre;

        private global::System.Windows.Forms.GroupBox groupBoxCartoon;

        private global::System.Windows.Forms.Panel panelPreview;

        private global::System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

        private global::System.Windows.Forms.TreeView treeViewResource;

        private global::System.Windows.Forms.TreeView treeViewIndex;

        private global::System.Windows.Forms.TreeView treeViewCartoon;

        private global::System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem InstructionsToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem softwareConfigToolStripMenuItem;

        private global::System.Windows.Forms.ToolStripMenuItem hardwareConfigToolStripMenuItem;
    }
}
