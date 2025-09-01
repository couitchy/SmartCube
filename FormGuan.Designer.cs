namespace Guan
{
	// Token: 0x02000037 RID: 55
	public partial class FormGuan : global::Guan.Forms
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00012309 File Offset: 0x00010509
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00012328 File Offset: 0x00010528
		private void InitializeComponent()
		{
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new global::System.Windows.Forms.SplitContainer();
			this.splitContainer4 = new global::System.Windows.Forms.SplitContainer();
			this.groupBoxCartoon = new global::System.Windows.Forms.GroupBox();
			this.treeViewCartoon = new global::System.Windows.Forms.TreeView();
			this.groupBoxPre = new global::System.Windows.Forms.GroupBox();
			this.panelPreview = new global::System.Windows.Forms.Panel();
			this.splitContainer2 = new global::System.Windows.Forms.SplitContainer();
			this.groupBoxGra = new global::System.Windows.Forms.GroupBox();
			this.treeViewResource = new global::System.Windows.Forms.TreeView();
			this.groupBoxIndex = new global::System.Windows.Forms.GroupBox();
			this.treeViewIndex = new global::System.Windows.Forms.TreeView();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.compileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.functionToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.debugConfigToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.InstructionsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.aboutUsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
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
			base.SuspendLayout();
			this.splitContainer1.BackColor = global::System.Drawing.SystemColors.ControlLightLight;
			this.splitContainer1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new global::System.Drawing.Size(785, 637);
			this.splitContainer1.SplitterDistance = 609;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.splitContainer3.BackColor = global::System.Drawing.SystemColors.ControlLightLight;
			this.splitContainer3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer3.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer3.Location = new global::System.Drawing.Point(0, -2);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
			this.splitContainer3.Size = new global::System.Drawing.Size(610, 639);
			this.splitContainer3.SplitterDistance = 375;
			this.splitContainer3.TabIndex = 3;
			this.splitContainer4.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.splitContainer4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer4.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer4.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Panel1.Controls.Add(this.groupBoxCartoon);
			this.splitContainer4.Panel2.Controls.Add(this.groupBoxPre);
			this.splitContainer4.Size = new global::System.Drawing.Size(612, 380);
			this.splitContainer4.SplitterDistance = 170;
			this.splitContainer4.TabIndex = 0;
			this.groupBoxCartoon.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBoxCartoon.Controls.Add(this.treeViewCartoon);
			this.groupBoxCartoon.Location = new global::System.Drawing.Point(3, 3);
			this.groupBoxCartoon.Name = "groupBoxCartoon";
			this.groupBoxCartoon.Size = new global::System.Drawing.Size(162, 367);
			this.groupBoxCartoon.TabIndex = 0;
			this.groupBoxCartoon.TabStop = false;
			this.groupBoxCartoon.Text = "Cartoon";
			this.treeViewCartoon.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.treeViewCartoon.Location = new global::System.Drawing.Point(6, 20);
			this.treeViewCartoon.Name = "treeViewCartoon";
			this.treeViewCartoon.Size = new global::System.Drawing.Size(150, 341);
			this.treeViewCartoon.TabIndex = 0;
			this.groupBoxPre.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBoxPre.Controls.Add(this.panelPreview);
			this.groupBoxPre.Location = new global::System.Drawing.Point(5, 3);
			this.groupBoxPre.Name = "groupBoxPre";
			this.groupBoxPre.Size = new global::System.Drawing.Size(423, 367);
			this.groupBoxPre.TabIndex = 0;
			this.groupBoxPre.TabStop = false;
			this.groupBoxPre.Text = "Preview";
			this.panelPreview.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.panelPreview.BackColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.panelPreview.Location = new global::System.Drawing.Point(6, 21);
			this.panelPreview.Name = "panelPreview";
			this.panelPreview.Size = new global::System.Drawing.Size(411, 334);
			this.panelPreview.TabIndex = 0;
			this.splitContainer2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer2.Panel1.AutoScroll = true;
			this.splitContainer2.Panel1.Controls.Add(this.groupBoxGra);
			this.splitContainer2.Panel2.Controls.Add(this.groupBoxIndex);
			this.splitContainer2.Size = new global::System.Drawing.Size(172, 637);
			this.splitContainer2.SplitterDistance = 325;
			this.splitContainer2.TabIndex = 0;
			this.groupBoxGra.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBoxGra.Controls.Add(this.treeViewResource);
			this.groupBoxGra.Location = new global::System.Drawing.Point(1, 5);
			this.groupBoxGra.Name = "groupBoxGra";
			this.groupBoxGra.Size = new global::System.Drawing.Size(168, 315);
			this.groupBoxGra.TabIndex = 0;
			this.groupBoxGra.TabStop = false;
			this.groupBoxGra.Text = "Resource list";
			this.treeViewResource.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.treeViewResource.Location = new global::System.Drawing.Point(6, 21);
			this.treeViewResource.Name = "treeViewResource";
			this.treeViewResource.Size = new global::System.Drawing.Size(150, 286);
			this.treeViewResource.TabIndex = 0;
			this.groupBoxIndex.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBoxIndex.Controls.Add(this.treeViewIndex);
			this.groupBoxIndex.Location = new global::System.Drawing.Point(1, 3);
			this.groupBoxIndex.Name = "groupBoxIndex";
			this.groupBoxIndex.Size = new global::System.Drawing.Size(168, 300);
			this.groupBoxIndex.TabIndex = 1;
			this.groupBoxIndex.TabStop = false;
			this.groupBoxIndex.Text = "Index table list";
			this.treeViewIndex.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.treeViewIndex.Location = new global::System.Drawing.Point(6, 20);
			this.treeViewIndex.Name = "treeViewIndex";
			this.treeViewIndex.Size = new global::System.Drawing.Size(150, 274);
			this.treeViewIndex.TabIndex = 0;
			this.menuStrip1.BackColor = global::System.Drawing.SystemColors.Control;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem, this.functionToolStripMenuItem, this.configToolStripMenuItem, this.helpToolStripMenuItem });
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(785, 25);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			this.fileToolStripMenuItem.BackColor = global::System.Drawing.SystemColors.Control;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.newToolStripMenuItem, this.openToolStripMenuItem, this.saveToolStripMenuItem, this.saveAsToolStripMenuItem, this.compileToolStripMenuItem, this.exitToolStripMenuItem });
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(44, 21);
			this.fileToolStripMenuItem.Text = "File";
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.saveAsToolStripMenuItem.Text = "Save as";
			this.saveAsToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
			this.compileToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.compileToolStripMenuItem.Text = "Compile";
			this.compileToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.functionToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.debugToolStripMenuItem });
			this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
			this.functionToolStripMenuItem.Size = new global::System.Drawing.Size(44, 21);
			this.functionToolStripMenuItem.Text = "Debug";
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new global::System.Drawing.Size(148, 22);
			this.debugToolStripMenuItem.Text = "Run";
			this.debugToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.configToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.debugConfigToolStripMenuItem });
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new global::System.Drawing.Size(44, 21);
			this.configToolStripMenuItem.Text = "Config";
			this.debugConfigToolStripMenuItem.Name = "debugConfigToolStripMenuItem";
			this.debugConfigToolStripMenuItem.Size = new global::System.Drawing.Size(124, 22);
			this.debugConfigToolStripMenuItem.Text = "Debug config";
			this.debugConfigToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.helpToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.InstructionsToolStripMenuItem, this.aboutUsToolStripMenuItem });
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new global::System.Drawing.Size(44, 21);
			this.helpToolStripMenuItem.Text = "Help";
			this.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem";
			this.InstructionsToolStripMenuItem.Size = new global::System.Drawing.Size(124, 22);
			this.InstructionsToolStripMenuItem.Text = "Instructions";
			this.InstructionsToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
			this.aboutUsToolStripMenuItem.Size = new global::System.Drawing.Size(124, 22);
			this.aboutUsToolStripMenuItem.Text = "About us";
			this.aboutUsToolStripMenuItem.Click += new global::System.EventHandler(this.ToolStripMenuItem_Click);
			this.AllowDrop = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Control;
			base.ClientSize = new global::System.Drawing.Size(785, 662);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.menuStrip1);
			base.IsMdiContainer = true;
			base.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new global::System.Drawing.Size(600, 500);
			base.Name = "FormGuan";
			this.Text = "Guan";
			base.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.FormGuan_DragDrop);
			base.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.FormGuan_DragEnter);
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormGuan_FormClosing);
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
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000166 RID: 358
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.SplitContainer splitContainer2;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.GroupBox groupBoxGra;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.GroupBox groupBoxIndex;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.SplitContainer splitContainer3;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.SplitContainer splitContainer4;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.GroupBox groupBoxPre;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.GroupBox groupBoxCartoon;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Panel panelPreview;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.TreeView treeViewResource;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.TreeView treeViewIndex;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.TreeView treeViewCartoon;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.ToolStripMenuItem InstructionsToolStripMenuItem;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.ToolStripMenuItem debugConfigToolStripMenuItem;
	}
}
