namespace MobileConfigBuilder
{
    partial class Question
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.AddVButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.Values = new System.Windows.Forms.ListBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.DefaultValue = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SelectedValue = new System.Windows.Forms.ComboBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Description";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 21);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(259, 20);
			this.textBox1.TabIndex = 1;
			// 
			// AddVButton
			// 
			this.AddVButton.Location = new System.Drawing.Point(173, 255);
			this.AddVButton.Name = "AddVButton";
			this.AddVButton.Size = new System.Drawing.Size(98, 23);
			this.AddVButton.TabIndex = 15;
			this.AddVButton.Text = "Add Value";
			this.AddVButton.UseVisualStyleBackColor = true;
			this.AddVButton.Click += new System.EventHandler(this.AddVButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 137);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Values";
			// 
			// Values
			// 
			this.Values.FormattingEnabled = true;
			this.Values.Location = new System.Drawing.Point(13, 153);
			this.Values.Name = "Values";
			this.Values.Size = new System.Drawing.Size(259, 95);
			this.Values.TabIndex = 13;
			this.toolTip1.SetToolTip(this.Values, "Double-click on a value to open or edit the value.");
			this.Values.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Values_MouseDoubleClick);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(117, 293);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 12;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(198, 293);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 11;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Default Value";
			// 
			// DefaultValue
			// 
			this.DefaultValue.FormattingEnabled = true;
			this.DefaultValue.Location = new System.Drawing.Point(13, 65);
			this.DefaultValue.Name = "DefaultValue";
			this.DefaultValue.Size = new System.Drawing.Size(259, 21);
			this.DefaultValue.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Selected Value (Reg Value to Query)";
			// 
			// SelectedValue
			// 
			this.SelectedValue.FormattingEnabled = true;
			this.SelectedValue.Location = new System.Drawing.Point(13, 110);
			this.SelectedValue.Name = "SelectedValue";
			this.SelectedValue.Size = new System.Drawing.Size(259, 21);
			this.SelectedValue.TabIndex = 19;
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
			// toolTip1
			// 
			this.toolTip1.ToolTipTitle = "Open/Edit";
			// 
			// Question
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(284, 327);
			this.Controls.Add(this.SelectedValue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.DefaultValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AddVButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Values);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Question";
			this.Text = "Question";
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AddVButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Values;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DefaultValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SelectedValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip1;
    }
}