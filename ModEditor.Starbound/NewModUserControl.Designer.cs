namespace ModEditor.Starbound
{
    partial class NewModUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewModUserControl));
            this.assetsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.folderDocumentsImageList = new System.Windows.Forms.ImageList(this.components);
            this.assetsListView = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.assetsListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.assetsSplitContainer)).BeginInit();
            this.assetsSplitContainer.Panel1.SuspendLayout();
            this.assetsSplitContainer.Panel2.SuspendLayout();
            this.assetsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // assetsSplitContainer
            // 
            this.assetsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.assetsSplitContainer.Name = "assetsSplitContainer";
            // 
            // assetsSplitContainer.Panel1
            // 
            this.assetsSplitContainer.Panel1.Controls.Add(this.assetsTreeView);
            // 
            // assetsSplitContainer.Panel2
            // 
            this.assetsSplitContainer.Panel2.Controls.Add(this.assetsListView);
            this.assetsSplitContainer.Size = new System.Drawing.Size(584, 337);
            this.assetsSplitContainer.SplitterDistance = 194;
            this.assetsSplitContainer.TabIndex = 0;
            // 
            // assetsTreeView
            // 
            this.assetsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsTreeView.ImageIndex = 0;
            this.assetsTreeView.ImageList = this.folderDocumentsImageList;
            this.assetsTreeView.Location = new System.Drawing.Point(0, 0);
            this.assetsTreeView.Name = "assetsTreeView";
            this.assetsTreeView.SelectedImageIndex = 0;
            this.assetsTreeView.Size = new System.Drawing.Size(194, 337);
            this.assetsTreeView.TabIndex = 0;
            this.assetsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.assetsTreeView_NodeMouseClick);
            // 
            // folderDocumentsImageList
            // 
            this.folderDocumentsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("folderDocumentsImageList.ImageStream")));
            this.folderDocumentsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.folderDocumentsImageList.Images.SetKeyName(0, "folder close.ico");
            this.folderDocumentsImageList.Images.SetKeyName(1, "shell32-312.ico");
            this.folderDocumentsImageList.Images.SetKeyName(2, "folder open.ico");
            // 
            // assetsListView
            // 
            this.assetsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.typeColumn,
            this.lastModified});
            this.assetsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsListView.Location = new System.Drawing.Point(0, 0);
            this.assetsListView.Name = "assetsListView";
            this.assetsListView.Size = new System.Drawing.Size(386, 337);
            this.assetsListView.SmallImageList = this.folderDocumentsImageList;
            this.assetsListView.TabIndex = 0;
            this.assetsListView.UseCompatibleStateImageBehavior = false;
            this.assetsListView.View = System.Windows.Forms.View.Details;
            this.assetsListView.SelectedIndexChanged += new System.EventHandler(this.assetsListView_SelectedIndexChanged);
            this.assetsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.assetsListView_MouseClick);
            this.assetsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.assetsListView_MouseDoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            // 
            // lastModified
            // 
            this.lastModified.Text = "Last Modified";
            // 
            // assetsListViewContextMenu
            // 
            this.assetsListViewContextMenu.Name = "assetsListViewContextMenu";
            this.assetsListViewContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // NewModUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.assetsSplitContainer);
            this.Name = "NewModUserControl";
            this.Size = new System.Drawing.Size(584, 337);
            this.assetsSplitContainer.Panel1.ResumeLayout(false);
            this.assetsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assetsSplitContainer)).EndInit();
            this.assetsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer assetsSplitContainer;
        private System.Windows.Forms.TreeView assetsTreeView;
        private System.Windows.Forms.ImageList folderDocumentsImageList;
        private System.Windows.Forms.ListView assetsListView;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.ColumnHeader lastModified;
        private System.Windows.Forms.ContextMenuStrip assetsListViewContextMenu;
        // private System.Windows.Forms.TextBox textBox1;
    }
}
