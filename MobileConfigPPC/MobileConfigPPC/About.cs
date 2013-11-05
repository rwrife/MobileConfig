#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private MenuItem menuItem1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label Version;
		/// <summary>
		/// Main menu for the form.
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;

		public About()
		{
			InitializeComponent();

			foreach (Control c in this.Controls)
				c.Width = this.Width;

			Version.Text = "1.0.0.1";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Version = new System.Windows.Forms.Label();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "OK";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Size = new System.Drawing.Size(152, 22);
			this.label1.Text = "MobileConfig";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 30);
			this.label2.Size = new System.Drawing.Size(152, 22);
			this.label2.Text = "Copyright 2007 Ryan Rife";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 52);
			this.label3.Size = new System.Drawing.Size(152, 22);
			this.label3.Text = "www.infinityball.com";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(3, 105);
			this.label4.Size = new System.Drawing.Size(170, 22);
			this.label4.Text = "PRERELEASE VERSION";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Version
			// 
			this.Version.Location = new System.Drawing.Point(3, 83);
			this.Version.Size = new System.Drawing.Size(170, 22);
			this.Version.Text = "www.infinityball.com";
			this.Version.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// About
			// 
			this.ClientSize = new System.Drawing.Size(176, 180);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Version);
			this.Menu = this.mainMenu1;
			this.Text = "About";

		}

		#endregion

		private void menuItem1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
