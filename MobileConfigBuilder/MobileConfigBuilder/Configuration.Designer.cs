namespace MobileConfigBuilder
{
    partial class Configuration
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
			this.ConfigTree = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.AddGroup = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ConfigTree
			// 
			this.ConfigTree.ContextMenuStrip = this.contextMenuStrip1;
			this.ConfigTree.ImageIndex = 0;
			this.ConfigTree.ImageList = this.imageList1;
			this.ConfigTree.Location = new System.Drawing.Point(12, 12);
			this.ConfigTree.Name = "ConfigTree";
			this.ConfigTree.SelectedImageIndex = 0;
			this.ConfigTree.Size = new System.Drawing.Size(317, 262);
			this.ConfigTree.TabIndex = 0;
			this.toolTip1.SetToolTip(this.ConfigTree, "Double-click on an item to open or edit the selected item.");
			this.ConfigTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ConfigTree_NodeMouseDoubleClick);
			this.ConfigTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConfigTree_AfterSelect);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(136, 48);
			// 
			// addConfigToolStripMenuItem
			// 
			this.addConfigToolStripMenuItem.Enabled = false;
			this.addConfigToolStripMenuItem.Name = "addConfigToolStripMenuItem";
			this.addConfigToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.addConfigToolStripMenuItem.Text = "Add Config";
			this.addConfigToolStripMenuItem.Click += new System.EventHandler(this.addConfigToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Folder");
			this.imageList1.Images.SetKeyName(1, "Config");
			// 
			// AddGroup
			// 
			this.AddGroup.Location = new System.Drawing.Point(13, 281);
			this.AddGroup.Name = "AddGroup";
			this.AddGroup.Size = new System.Drawing.Size(75, 23);
			this.AddGroup.TabIndex = 1;
			this.AddGroup.Text = "Add Group";
			this.AddGroup.UseVisualStyleBackColor = true;
			this.AddGroup.Click += new System.EventHandler(this.AddGroup_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(95, 281);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Add Config";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(253, 281);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 3;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipTitle = "Open/Edit";
			// 
			// Configuration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(341, 313);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.AddGroup);
			this.Controls.Add(this.ConfigTree);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Configuration";
			this.Text = "MobileConfig Builder";
			this.Load += new System.EventHandler(this.Configuration_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ConfigTree;
        private System.Windows.Forms.Button AddGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolTip toolTip1;
    }
}

