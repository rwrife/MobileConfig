#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	public class MobileConfig : System.Windows.Forms.Form
	{
		private MenuItem menuItem1;
		private MenuItem menuItem2;
		private MenuItem menuItem3;
		private MenuItem menuItem4;
		private ListView ActionList;
		/// <summary>
		/// Main menu for the form.
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;
		private MenuItem menuItem5;
		private MenuItem menuItem6;
		Configurations cfgs = new Configurations();

		public MobileConfig()
		{
			InitializeComponent();
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
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.ActionList = new System.Windows.Forms.ListView();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "Open";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.MenuItems.Add(this.menuItem3);
			this.menuItem2.MenuItems.Add(this.menuItem5);
			this.menuItem2.MenuItems.Add(this.menuItem4);
			this.menuItem2.MenuItems.Add(this.menuItem6);
			this.menuItem2.Text = "Menu";
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Online Update";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "Soft Reset";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Text = "About";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "Exit";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// ActionList
			// 
			this.ActionList.Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Bold);
			this.ActionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.ActionList.Location = new System.Drawing.Point(0, 0);
			this.ActionList.Size = new System.Drawing.Size(240, 268);
			this.ActionList.View = System.Windows.Forms.View.List;
			this.ActionList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionList_KeyDown);
			// 
			// MobileConfig
			// 
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.ActionList);
			this.Menu = this.mainMenu1;
			this.Text = "MobileConfig";
			this.Load += new System.EventHandler(this.MobileConfig_Load);

		}

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			Application.Run(new MobileConfig());
		}

		private void MobileConfig_Load(object sender, EventArgs e)
		{
			ActionList.Width = this.ClientSize.Width;
			ActionList.Height = this.ClientSize.Height;
			LoadConfigs();
		}

		private void LoadConfigs()
		{
			cfgs = new Configurations();
			cfgs.Open();
			ActionList.Items.Clear();

			foreach (Configuration cfg in cfgs)
			{
				ActionListItem ali = new ActionListItem();
				ali.Text = cfg.Name;
				ali.DataID = ActionList.Items.Count + 1;
				ActionList.Items.Add(ali);
			}
		}

		private void menuItem4_Click(object sender, EventArgs e)
		{
			About aboutForm = new About();
			aboutForm.ShowDialog();
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			if (ActionList.SelectedIndices.Count > 0)
			{
				int actionId = ((ActionListItem)ActionList.Items[ActionList.SelectedIndices[0]]).DataID;
				if (actionId > 0)
				{
					Config cfgForm = new Config(cfgs, (Configuration) cfgs[actionId-1]);
					cfgForm.Show();
				}
			}
		}

		private void ActionList_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
			{
				if (ActionList.SelectedIndices.Count > 0)
				{
					int actionId = ((ActionListItem)ActionList.Items[ActionList.SelectedIndices[0]]).DataID;
					if (actionId > 0)
					{
						Config cfgForm = new Config(cfgs, (Configuration)cfgs[actionId - 1]);
						cfgForm.Show();
					}
				}
			}
		}

		private void menuItem3_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			Cursor.Show();
			try
			{
				string downloadURL = "http://www.infinityball.com/GetFile.aspx?FileID=60";
				string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "\\" + "mobileconfig.xml";

				if (downloadURL != null)
				{
					string content = "";
					System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(downloadURL);
					System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
					System.IO.StreamReader rdr = new System.IO.StreamReader(res.GetResponseStream());
					content = rdr.ReadToEnd();
					rdr.Close();
					res.Close();

					System.IO.StreamWriter sw = System.IO.File.CreateText(fileName);
					sw.Write(content);
					sw.Close();

					LoadConfigs();
				}
			}
			catch
			{
			}
			Cursor.Current = Cursors.Default;
			Cursor.Hide();		
		}

		private object GetRegKeyValue(RegistryImpl.RootKey RootKey, string SubKey, string Value, object DefaultValue)
		{
			RegistryKey rk = Registry.UnknownKey(RootKey);
			string[] Subs = SubKey.Split('\\');
			foreach (string Sub in Subs)
			{
				bool found = false;
				foreach (string keyName in rk.GetSubKeyNames())
					if (keyName.ToLower() == Sub.ToLower())
						found = true;

				if (!found)
					return null;
				else
					rk = rk.OpenSubKey(Sub);
			}
			return rk.GetValue(Value, DefaultValue);
		}

		private void menuItem6_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}



		public const uint FILE_DEVICE_HAL = 0x00000101;
		public const uint METHOD_BUFFERED = 0;
		public const uint FILE_ANY_ACCESS = 0;

		public uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
		{
			return ((DeviceType << 16) | (Access << 14) | (Function << 2) | Method);
		}

		[DllImport("Coredll.dll")]
		public extern static uint KernelIoControl
		(
			uint dwIoControlCode,
			IntPtr lpInBuf,
			uint nInBufSize,
			IntPtr lpOutBuf,
			uint nOutBufSize,
			ref uint lpBytesReturned
		);

		uint ResetPocketPC()
		{
			uint bytesReturned = 0;
			uint IOCTL_HAL_REBOOT = CTL_CODE(FILE_DEVICE_HAL, 15, 
			  METHOD_BUFFERED, FILE_ANY_ACCESS);
			return KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, 
			  IntPtr.Zero, 0, ref bytesReturned);
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure you want to soft reset your device?", "Reset Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				ResetPocketPC();			
		}
	}
}

