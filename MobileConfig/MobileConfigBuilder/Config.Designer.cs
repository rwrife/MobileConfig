namespace MobileConfigBuilder
{
    partial class Config
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
			this.label1 = new System.Windows.Forms.Label();
			this.ConfigName = new System.Windows.Forms.TextBox();
			this.Desc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ExtDesc = new System.Windows.Forms.TextBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.Questions = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label4 = new System.Windows.Forms.Label();
			this.AddQButton = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// ConfigName
			// 
			this.ConfigName.Location = new System.Drawing.Point(13, 30);
			this.ConfigName.Name = "ConfigName";
			this.ConfigName.Size = new System.Drawing.Size(259, 20);
			this.ConfigName.TabIndex = 1;
			// 
			// Desc
			// 
			this.Desc.Location = new System.Drawing.Point(13, 69);
			this.Desc.Name = "Desc";
			this.Desc.Size = new System.Drawing.Size(259, 20);
			this.Desc.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Description";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Extended Description";
			// 
			// ExtDesc
			// 
			this.ExtDesc.Location = new System.Drawing.Point(13, 109);
			this.ExtDesc.Multiline = true;
			this.ExtDesc.Name = "ExtDesc";
			this.ExtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ExtDesc.Size = new System.Drawing.Size(259, 60);
			this.ExtDesc.TabIndex = 5;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(197, 328);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 6;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(116, 328);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// Questions
			// 
			this.Questions.ContextMenuStrip = this.contextMenuStrip1;
			this.Questions.FormattingEnabled = true;
			this.Questions.Location = new System.Drawing.Point(12, 188);
			this.Questions.Name = "Questions";
			this.Questions.Size = new System.Drawing.Size(259, 95);
			this.Questions.TabIndex = 8;
			this.toolTip1.SetToolTip(this.Questions, "Double-click on a question to open or edit the question.");
			this.Questions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Questions_MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 172);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Questions";
			// 
			// AddQButton
			// 
			this.AddQButton.Location = new System.Drawing.Point(172, 290);
			this.AddQButton.Name = "AddQButton";
			this.AddQButton.Size = new System.Drawing.Size(98, 23);
			this.AddQButton.TabIndex = 10;
			this.AddQButton.Text = "Add Question";
			this.AddQButton.UseVisualStyleBackColor = true;
			this.AddQButton.Click += new System.EventHandler(this.AddQButton_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipTitle = "Open/Edit";
			// 
			// Config
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 363);
			this.Controls.Add(this.AddQButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Questions);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.ExtDesc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Desc);
			this.Controls.Add(this.ConfigName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Config";
			this.Text = "Config";
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConfigName;
        private System.Windows.Forms.TextBox Desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ExtDesc;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox Questions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddQButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip1;
    }
}