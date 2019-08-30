namespace XSDDigitalToXML
{
    partial class Mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XMLTOXSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VilateMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BeHindToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabControlView = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelDiagram = new XSDDigitalToXML.DiagramControlContainer();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.listViewElements = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlElement = new System.Windows.Forms.TabControl();
            this.tabPageElementAttibutes = new System.Windows.Forms.TabPage();
            this.listViewAttributes = new System.Windows.Forms.ListView();
            this.columnHeaderAttributesName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAttributesType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAttributesUse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAttributesDefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageElement = new System.Windows.Forms.TabPage();
            this.propertyGridSchemaObject = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlView)).BeginInit();
            this.tabControlView.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.tabControlElement.SuspendLayout();
            this.tabPageElementAttibutes.SuspendLayout();
            this.tabPageElement.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.NextPageToolStripMenuItem,
            this.BeHindToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.XMLTOXSDToolStripMenuItem,
            this.VilateMLToolStripMenuItem,
            this.ExportToolStripMenuItem,
            this.printToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FileToolStripMenuItem.Text = "开始";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem.Text = "打开文件";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // XMLTOXSDToolStripMenuItem
            // 
            this.XMLTOXSDToolStripMenuItem.Name = "XMLTOXSDToolStripMenuItem";
            this.XMLTOXSDToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.XMLTOXSDToolStripMenuItem.Text = "XML转XSD";
            this.XMLTOXSDToolStripMenuItem.Click += new System.EventHandler(this.XMLTOXSDToolStripMenuItem_Click);
            // 
            // VilateMLToolStripMenuItem
            // 
            this.VilateMLToolStripMenuItem.Name = "VilateMLToolStripMenuItem";
            this.VilateMLToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.VilateMLToolStripMenuItem.Text = "校验XML";
            this.VilateMLToolStripMenuItem.Click += new System.EventHandler(this.VilateMLToolStripMenuItem_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ExportToolStripMenuItem.Text = "导出";
            this.ExportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.printToolStripMenuItem.Text = "打印";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.QuitToolStripMenuItem.Text = "退出";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // NextPageToolStripMenuItem
            // 
            this.NextPageToolStripMenuItem.Name = "NextPageToolStripMenuItem";
            this.NextPageToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.NextPageToolStripMenuItem.Text = "下一项";
            this.NextPageToolStripMenuItem.Click += new System.EventHandler(this.NextPageToolStripMenuItem_Click);
            // 
            // BeHindToolStripMenuItem1
            // 
            this.BeHindToolStripMenuItem1.Name = "BeHindToolStripMenuItem1";
            this.BeHindToolStripMenuItem1.Size = new System.Drawing.Size(56, 21);
            this.BeHindToolStripMenuItem1.Text = "上一项";
            this.BeHindToolStripMenuItem1.Click += new System.EventHandler(this.BeHindToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem1.Text = "帮助";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tabControlView);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(912, 573);
            this.splitContainerControl1.SplitterPosition = 642;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tabControlView
            // 
            this.tabControlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlView.Location = new System.Drawing.Point(0, 0);
            this.tabControlView.Name = "tabControlView";
            this.tabControlView.SelectedTabPage = this.xtraTabPage1;
            this.tabControlView.Size = new System.Drawing.Size(642, 573);
            this.tabControlView.TabIndex = 0;
            this.tabControlView.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            this.tabControlView.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.tabControlView_Selected);
            this.tabControlView.Click += new System.EventHandler(this.tabControlView_Click);
            this.tabControlView.Enter += new System.EventHandler(this.tabControlView_Enter);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelDiagram);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(640, 545);
            this.xtraTabPage1.Text = "文件";
            // 
            // panelDiagram
            // 
            this.panelDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDiagram.Location = new System.Drawing.Point(0, 0);
            this.panelDiagram.Name = "panelDiagram";
            this.panelDiagram.Size = new System.Drawing.Size(640, 545);
            this.panelDiagram.TabIndex = 0;
            this.panelDiagram.VirtualPoint = new System.Drawing.Point(0, 0);
            this.panelDiagram.VirtualSize = new System.Drawing.Size(10, 10);
            this.panelDiagram.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDiagram_DragDrop);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.IsSplitterFixed = true;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.listViewElements);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.tabControlElement);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(258, 573);
            this.splitContainerControl2.SplitterPosition = 265;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // listViewElements
            // 
            this.listViewElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewElements.FullRowSelect = true;
            this.listViewElements.GridLines = true;
            this.listViewElements.HideSelection = false;
            this.listViewElements.LabelEdit = true;
            this.listViewElements.Location = new System.Drawing.Point(0, 0);
            this.listViewElements.MultiSelect = false;
            this.listViewElements.Name = "listViewElements";
            this.listViewElements.Size = new System.Drawing.Size(258, 265);
            this.listViewElements.TabIndex = 5;
            this.listViewElements.UseCompatibleStateImageBehavior = false;
            this.listViewElements.View = System.Windows.Forms.View.Details;
            this.listViewElements.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewElements_AfterLabelEdit);
            this.listViewElements.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewElements_ColumnClick);
            this.listViewElements.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewElements_ItemDrag);
            this.listViewElements.Click += new System.EventHandler(this.listViewElements_Click);
            this.listViewElements.DoubleClick += new System.EventHandler(this.listViewElements_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 89;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型";
            this.columnHeader2.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "命名空间";
            this.columnHeader3.Width = 79;
            // 
            // tabControlElement
            // 
            this.tabControlElement.Controls.Add(this.tabPageElementAttibutes);
            this.tabControlElement.Controls.Add(this.tabPageElement);
            this.tabControlElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlElement.Location = new System.Drawing.Point(0, 0);
            this.tabControlElement.Name = "tabControlElement";
            this.tabControlElement.SelectedIndex = 0;
            this.tabControlElement.Size = new System.Drawing.Size(258, 296);
            this.tabControlElement.TabIndex = 9;
            // 
            // tabPageElementAttibutes
            // 
            this.tabPageElementAttibutes.Controls.Add(this.listViewAttributes);
            this.tabPageElementAttibutes.Location = new System.Drawing.Point(4, 23);
            this.tabPageElementAttibutes.Name = "tabPageElementAttibutes";
            this.tabPageElementAttibutes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageElementAttibutes.Size = new System.Drawing.Size(250, 269);
            this.tabPageElementAttibutes.TabIndex = 0;
            this.tabPageElementAttibutes.Text = "属性";
            this.tabPageElementAttibutes.UseVisualStyleBackColor = true;
            // 
            // listViewAttributes
            // 
            this.listViewAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAttributesName,
            this.columnHeaderAttributesType,
            this.columnHeaderAttributesUse,
            this.columnHeaderAttributesDefault});
            this.listViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAttributes.FullRowSelect = true;
            this.listViewAttributes.GridLines = true;
            this.listViewAttributes.LabelEdit = true;
            this.listViewAttributes.Location = new System.Drawing.Point(3, 3);
            this.listViewAttributes.MultiSelect = false;
            this.listViewAttributes.Name = "listViewAttributes";
            this.listViewAttributes.Size = new System.Drawing.Size(244, 263);
            this.listViewAttributes.TabIndex = 0;
            this.listViewAttributes.UseCompatibleStateImageBehavior = false;
            this.listViewAttributes.View = System.Windows.Forms.View.Details;
            this.listViewAttributes.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewAttributes_AfterLabelEdit);
            this.listViewAttributes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewAttributes_ColumnClick);
            this.listViewAttributes.SelectedIndexChanged += new System.EventHandler(this.listViewAttributes_SelectedIndexChanged);
            // 
            // columnHeaderAttributesName
            // 
            this.columnHeaderAttributesName.Text = "名字";
            // 
            // columnHeaderAttributesType
            // 
            this.columnHeaderAttributesType.Text = "类型";
            // 
            // columnHeaderAttributesUse
            // 
            this.columnHeaderAttributesUse.DisplayIndex = 3;
            this.columnHeaderAttributesUse.Text = "作用";
            // 
            // columnHeaderAttributesDefault
            // 
            this.columnHeaderAttributesDefault.DisplayIndex = 2;
            this.columnHeaderAttributesDefault.Text = "默认值";
            // 
            // tabPageElement
            // 
            this.tabPageElement.Controls.Add(this.propertyGridSchemaObject);
            this.tabPageElement.Location = new System.Drawing.Point(4, 23);
            this.tabPageElement.Name = "tabPageElement";
            this.tabPageElement.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageElement.Size = new System.Drawing.Size(250, 269);
            this.tabPageElement.TabIndex = 1;
            this.tabPageElement.Text = "元素";
            this.tabPageElement.UseVisualStyleBackColor = true;
            // 
            // propertyGridSchemaObject
            // 
            this.propertyGridSchemaObject.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGridSchemaObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSchemaObject.HelpVisible = false;
            this.propertyGridSchemaObject.Location = new System.Drawing.Point(3, 3);
            this.propertyGridSchemaObject.Name = "propertyGridSchemaObject";
            this.propertyGridSchemaObject.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGridSchemaObject.Size = new System.Drawing.Size(244, 263);
            this.propertyGridSchemaObject.TabIndex = 0;
            this.propertyGridSchemaObject.ToolbarVisible = false;
            // 
            // Mainform
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 598);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XSDDigitalToXML";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Mainform_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Mainform_DragEnter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Mainform_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlView)).EndInit();
            this.tabControlView.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.tabControlElement.ResumeLayout(false);
            this.tabPageElementAttibutes.ResumeLayout(false);
            this.tabPageElement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XMLTOXSDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VilateMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NextPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BeHindToolStripMenuItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl tabControlView;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private System.Windows.Forms.ListView listViewElements;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabControl tabControlElement;
        private System.Windows.Forms.TabPage tabPageElementAttibutes;
        private System.Windows.Forms.ListView listViewAttributes;
        private System.Windows.Forms.ColumnHeader columnHeaderAttributesName;
        private System.Windows.Forms.ColumnHeader columnHeaderAttributesType;
        private System.Windows.Forms.ColumnHeader columnHeaderAttributesUse;
        private System.Windows.Forms.ColumnHeader columnHeaderAttributesDefault;
        private System.Windows.Forms.TabPage tabPageElement;
        private System.Windows.Forms.PropertyGrid propertyGridSchemaObject;
        private DiagramControlContainer panelDiagram;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

