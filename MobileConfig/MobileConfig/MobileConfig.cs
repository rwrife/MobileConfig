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
		/// <summary>
		/// Main menu for the form.
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;
		private MenuItem menuItem5;
		private MenuItem menuItem6;
		private TreeView ConfigTree;
		
		private Group[] _groups = null;
		private Config[] _configs = null;
		private ImageList imageList1;
		private System.Data.DataSet _masterDS;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MobileConfig));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.ConfigTree = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList();
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
			// ConfigTree
			// 
			this.ConfigTree.Font = new System.Drawing.Font("Segoe Condensed", 9F, System.Drawing.FontStyle.Regular);
			this.ConfigTree.ImageIndex = 0;
			this.ConfigTree.ImageList = this.imageList1;
			this.ConfigTree.Location = new System.Drawing.Point(0, 0);
			this.ConfigTree.SelectedImageIndex = 0;
			this.ConfigTree.Size = new System.Drawing.Size(352, 180);
			this.ConfigTree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigTree_KeyPress);
			this.imageList1.Images.Clear();
			this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
			this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
			// 
			// MobileConfig
			// 
			this.ClientSize = new System.Drawing.Size(176, 180);
			this.Controls.Add(this.ConfigTree);
			this.Menu = this.mainMenu1;
			this.Text = "MobileConfig";
			this.GotFocus += new System.EventHandler(this.MobileConfig_GotFocus);
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
			ConfigTree.Width = this.ClientSize.Width;
			ConfigTree.Height = this.ClientSize.Height;
			LoadData();
			BindTree();
			ConfigTree.BringToFront();
		}

		private void LoadData()
		{
			_masterDS = new DataSet();
			if (System.IO.File.Exists(XMLFileName))
				_masterDS.ReadXml(XMLFileName);

			if (_masterDS.Tables[Group.TableName] != null)
			{
				_groups = new Group[_masterDS.Tables[Group.TableName].Rows.Count];
				for(int i =0;i<_masterDS.Tables[Group.TableName].Rows.Count;i++)				
					_groups[i] = new Group(_masterDS, _masterDS.Tables[Group.TableName].Rows[i]["GroupID"].ToString());				
			}

			if (_masterDS.Tables[Config.TableName] != null)
			{
				_configs = new Config[_masterDS.Tables[Config.TableName].Rows.Count];
				for (int i = 0; i < _masterDS.Tables[Config.TableName].Rows.Count; i++)
					_configs[i] = new Config(_masterDS, _masterDS.Tables[Config.TableName].Rows[i]["ConfigID"].ToString());
			}
		}

		public void BindTree()
		{
			ConfigTree.Nodes.Clear();
			if(_groups != null)
			foreach (Group g in _groups)
			{
				GroupNode node = new GroupNode();
				node.Tag = g.ID;
				node.Text = g.Name;
				node.ImageIndex = 1;
				node.SelectedImageIndex = 1;
				ConfigTree.Nodes.Add(node);
			}

			if(_configs != null)
			foreach (Config c in _configs)
			{
				TreeNode node = new TreeNode();
				node.Tag = c.ID;
				node.Text = c.Name;
				node.ImageIndex = 0;
				node.SelectedImageIndex = 0;
				if (c.GroupID == "")
					ConfigTree.Nodes.Add(node);
				else
				{
					TreeNode gNode = FindTreeNode(c.GroupID);
					if (gNode != null)
						gNode.Nodes.Add(node);
					else
					{
						c.GroupID = "";
						ConfigTree.Nodes.Add(node);
					}
				}
			}
		}

		private TreeNode FindTreeNode(string NodeTag)
		{
			foreach (TreeNode n in ConfigTree.Nodes)
				if (n.Tag.ToString() == NodeTag)
					return n;

			return null;
		}

		private void menuItem4_Click(object sender, EventArgs e)
		{
			About aboutForm = new About();
			aboutForm.ShowDialog();
		}

		private string XMLFileName
		{
			get
			{
				return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "\\" + "mobileconfig.xml";
			}
		}

		private void OpenSelNode()
		{
			if (!(ConfigTree.SelectedNode is GroupNode) && ConfigTree.SelectedNode != null)
			{
				foreach (Config c in _configs)
					if (c.ID == ConfigTree.SelectedNode.Tag)
					{
						ConfigForm cfgForm = new ConfigForm(c);
						cfgForm.ShowDialog();
					}
			}
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			OpenSelNode();
		}

		private void ActionList_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
			{
				OpenSelNode();
			}
		}

		private void menuItem3_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			Cursor.Show();
			try
			{
				string downloadURL = "http://www.infinityball.com/GetFile.aspx?FileID=66";
				object downUrlReg = GetRegKeyValue(RegistryImpl.RootKey.HKEY_LOCAL_MACHINE, "Software\\MobileConfig", "DownloadURL1", "http://www.infinityball.com/GetFile.aspx?FileID=66");
				if(downUrlReg != null)
					downloadURL = downUrlReg.ToString();
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

					LoadData();
					BindTree();
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

		private void MobileConfig_GotFocus(object sender, EventArgs e)
		{
			ConfigTree.BringToFront();
		}

		private void ConfigTree_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
				OpenSelNode();
		}
	}
}

