namespace MobileConfigBuilder
{
    partial class RegValue
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
			this.ValueText = new System.Windows.Forms.TextBox();
			this.SubKey = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.NameText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Types = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Actions = new System.Windows.Forms.ComboBox();
			this.Keys = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// ValueText
			// 
			this.ValueText.Location = new System.Drawing.Point(12, 150);
			this.ValueText.Name = "ValueText";
			this.ValueText.Size = new System.Drawing.Size(257, 20);
			this.ValueText.TabIndex = 42;
			// 
			// SubKey
			// 
			this.SubKey.Location = new System.Drawing.Point(12, 70);
			this.SubKey.Name = "SubKey";
			this.SubKey.Size = new System.Drawing.Size(258, 20);
			this.SubKey.TabIndex = 41;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(166, 13);
			this.label3.TabIndex = 40;
			this.label3.Text = "Value (Leave blank for user input)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 39;
			this.label2.Text = "Sub Key";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(116, 277);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 35;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(197, 277);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 34;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Key";
			// 
			// NameText
			// 
			this.NameText.Location = new System.Drawing.Point(13, 110);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(257, 20);
			this.NameText.TabIndex = 44;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 43;
			this.label4.Text = "Name";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 177);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 45;
			this.label5.Text = "Data Type";
			// 
			// Types
			// 
			this.Types.FormattingEnabled = true;
			this.Types.Items.AddRange(new object[] {
            "DWORD (Number)",
            "String",
            "Binary (Byte Array)"});
			this.Types.Location = new System.Drawing.Point(12, 194);
			this.Types.Name = "Types";
			this.Types.Size = new System.Drawing.Size(257, 21);
			this.Types.TabIndex = 46;
			this.Types.Text = "DWORD (Number)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 222);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 47;
			this.label6.Text = "Action";
			// 
			// Actions
			// 
			this.Actions.FormattingEnabled = true;
			this.Actions.Items.AddRange(new object[] {
            "Add/Update Value",
            "Delete Value"});
			this.Actions.Location = new System.Drawing.Point(13, 239);
			this.Actions.Name = "Actions";
			this.Actions.Size = new System.Drawing.Size(256, 21);
			this.Actions.TabIndex = 48;
			this.Actions.Text = "Add/Update Action";
			// 
			// Keys
			// 
			this.Keys.FormattingEnabled = true;
			this.Keys.Location = new System.Drawing.Point(15, 26);
			this.Keys.Name = "Keys";
			this.Keys.Size = new System.Drawing.Size(254, 21);
			this.Keys.TabIndex = 49;
			// 
			// RegValue
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(284, 312);
			this.Controls.Add(this.Keys);
			this.Controls.Add(this.Actions);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.Types);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.NameText);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ValueText);
			this.Controls.Add(this.SubKey);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RegValue";
			this.Text = "RegValue";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ValueText;
        private System.Windows.Forms.TextBox SubKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Types;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Actions;
        private System.Windows.Forms.ComboBox Keys;
    }
}