namespace MobileConfigBuilder
{
    partial class Value
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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.AddVButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.NameText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DefaultValue = new System.Windows.Forms.TextBox();
			this.ValueText = new System.Windows.Forms.TextBox();
			this.RegValues = new System.Windows.Forms.CheckedListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(166, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Value (Leave blank for user input)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Default Value";
			// 
			// AddVButton
			// 
			this.AddVButton.Location = new System.Drawing.Point(172, 260);
			this.AddVButton.Name = "AddVButton";
			this.AddVButton.Size = new System.Drawing.Size(98, 23);
			this.AddVButton.TabIndex = 26;
			this.AddVButton.Text = "Add Value";
			this.AddVButton.UseVisualStyleBackColor = true;
			this.AddVButton.Click += new System.EventHandler(this.AddVButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 25;
			this.label4.Text = "Registry Values";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(116, 298);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 23;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(197, 298);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 22;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// NameText
			// 
			this.NameText.Location = new System.Drawing.Point(12, 26);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(259, 20);
			this.NameText.TabIndex = 21;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Name";
			// 
			// DefaultValue
			// 
			this.DefaultValue.Location = new System.Drawing.Point(12, 70);
			this.DefaultValue.Name = "DefaultValue";
			this.DefaultValue.Size = new System.Drawing.Size(258, 20);
			this.DefaultValue.TabIndex = 30;
			// 
			// ValueText
			// 
			this.ValueText.Location = new System.Drawing.Point(15, 115);
			this.ValueText.Name = "ValueText";
			this.ValueText.Size = new System.Drawing.Size(257, 20);
			this.ValueText.TabIndex = 31;
			// 
			// RegValues
			// 
			this.RegValues.ContextMenuStrip = this.contextMenuStrip1;
			this.RegValues.FormattingEnabled = true;
			this.RegValues.Location = new System.Drawing.Point(12, 159);
			this.RegValues.Name = "RegValues";
			this.RegValues.Size = new System.Drawing.Size(260, 94);
			this.RegValues.TabIndex = 32;
			this.toolTip1.SetToolTip(this.RegValues, "Right-click on a registry value to open or edit the value.");
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipTitle = "Open/Edit";
			// 
			// Value
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 334);
			this.Controls.Add(this.RegValues);
			this.Controls.Add(this.ValueText);
			this.Controls.Add(this.DefaultValue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AddVButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.NameText);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Value";
			this.Text = "Value";
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddVButton;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DefaultValue;
        private System.Windows.Forms.TextBox ValueText;
		private System.Windows.Forms.CheckedListBox RegValues;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip1;
    }
}