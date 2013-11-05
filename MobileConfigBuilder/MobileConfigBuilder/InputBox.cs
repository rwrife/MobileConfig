using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileConfigBuilder
{
    public partial class InputBox : Form
    {
        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public InputBox(string Title, string Prompt)
        {
            InitializeComponent();
            Text = Title;
            label1.Text = Prompt;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.Close();
        }
    }
}