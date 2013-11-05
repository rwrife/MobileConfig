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
	/// Summary description for Config.
	/// </summary>
	public class Config : System.Windows.Forms.Form
	{
		private MenuItem menuItem1;
		private MenuItem menuItem2;		
		
		private Label[] Question;
		private ComboBox[] Values;
		private TextBox[] Value;
		/// <summary>
		/// Main menu for the form.
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;
		private Label Description;

		private Configuration cfg;
		private Configurations cfgs;

		public Config(Configurations configs, Configuration config)
		{
			cfgs = configs;
			cfg = config;
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
			this.Description = new System.Windows.Forms.Label();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "Apply";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "Cancel";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// Description
			// 
			this.Description.Font = new System.Drawing.Font("Segoe Condensed", 9F, System.Drawing.FontStyle.Regular);
			this.Description.Location = new System.Drawing.Point(3, 3);
			this.Description.Size = new System.Drawing.Size(314, 60);
			this.Description.Text = "MobileConfig";
			// 
			// Config
			// 
			this.ClientSize = new System.Drawing.Size(176, 180);
			this.Controls.Add(this.Description);
			this.Menu = this.mainMenu1;
			this.Text = "Config";
			this.Load += new System.EventHandler(this.Config_Load);

		}

		#endregion

		private void menuItem2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Config_Load(object sender, EventArgs e)
		{			
			this.Text = cfg.Name;
			Description.Width = this.Width - 8;
			this.Description.Text = cfg.Description;

			if (cfg.Questions != null)
			{
				Question = new Label[cfg.Questions.Length];
				Values = new ComboBox[cfg.Questions.Length];
				Value = new TextBox[cfg.Questions.Length];

				int qNum = 0;
				int lastTop = this.Description.Top + this.Description.Height + 4;

				foreach (Question q in cfg.Questions)
				{
					Question[qNum] = new Label();
					Question[qNum].Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Bold);
					Question[qNum].Location = new System.Drawing.Point(4, lastTop);
					Question[qNum].Size = new System.Drawing.Size(this.Width-8, 20);
					this.Controls.Add(Question[qNum]);

					Values[qNum] = new ComboBox();
					Values[qNum].DisplayMember = "Name";
					Values[qNum].ValueMember = "ValueID";
					Values[qNum].Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Regular);
					Values[qNum].Location = new System.Drawing.Point(4, lastTop+24);
					Values[qNum].Size = new System.Drawing.Size(this.Width - 8, 22);
					Values[qNum].Capture = true;
					this.Controls.Add(Values[qNum]);

					Value[qNum] = new TextBox();
					Value[qNum].Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Regular);
					Value[qNum].Location = new System.Drawing.Point(4, lastTop + 24);
					Value[qNum].Size = new System.Drawing.Size(this.Width - 8, 22);
					this.Controls.Add(Value[qNum]);
					
					Question[qNum].Text = q.Name;
					if (q.Values != null && q.Values.Length > 0)
					{
						if (q.Values.Length == 1)
						{
							Values[qNum].Visible = false;
							Value[qNum].Visible = true;
							Value[0].BringToFront();

							if (q.Values[0].RegValues[0].Value != null)
								Value[qNum].Text = q.Values[0].RegValues[0].Value;
							else if (q.Values[0].DefaultValue != null)
								Value[qNum].Text = q.Values[0].DefaultValue;
							else
							{
								RegValue rv = q.Values[0].RegValues[0];
								Value[qNum].Text = Registry.UnknownKey(rv.RootKey).OpenSubKey(rv.SubKey).GetValue(rv.Name).ToString();								
							}
						}
						
						if (q.Values.Length > 1)
						{
							Values[qNum].Visible = true;
							Value[qNum].Visible = false;
							Values[0].BringToFront();
							foreach (Value v in q.Values)
							{
								Values[qNum].Items.Add(v);

								if (v.ValueID == q.DefaultValue)
									Values[qNum].SelectedItem = v;
							}	
					
							if(q.SelectedRegValue > 0)
							{
								RegValue rv = cfgs.OpenRegValue(q.SelectedRegValue);
								if(rv != null)
								{
									object selVal = GetRegKeyValue(rv.RootKey, rv.SubKey, rv.Name, rv.Value);
									if(selVal != null)
									{
										foreach(Value v in Values[qNum].Items)
										{
											if(v.DefaultValue != null && v.DefaultValue.ToLower() == selVal.ToString().ToLower())
											{
												Values[qNum].SelectedItem = v;
												break;
											}
										}
									}
								}
							}
						}

					}
					qNum++;
					lastTop += 46;					
				}
			}

		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			int qNum = 0;
			if(cfg != null && cfg.Questions != null)
			{
				foreach (Question q in cfg.Questions)
				{
					if(q.Values != null)
					{
						if (q.Values.Length == 1)
						{
							foreach (RegValue rv in q.Values[0].RegValues)
							{
								if(rv.Value == null)
									rv.Value = Value[qNum].Text;

								if (rv.Type == 1)
								{
									try
									{
										int outVal = Convert.ToInt32(Value[qNum].Text);
										rv.Value = outVal.ToString();
									}
									catch
									{
										MessageBox.Show("A numeric value is required!");
										return;
									}
								}									
								
								if (rv.Value != null)
								{
									if (rv.Type == 1)
										SetRegKeyValue(rv.RootKey, rv.SubKey, rv.Name, Convert.ToInt32(rv.Value));
									if (rv.Type == 2)
										SetRegKeyValue(rv.RootKey, rv.SubKey, rv.Name, rv.Value);
								}
							}
						}

						if (q.Values.Length > 1)
						{
							Value selV = (Value) Values[qNum].SelectedItem;
							if (selV.RegValues != null)
							{
								foreach (RegValue rv in selV.RegValues)
								{
									if (rv.Value == null && selV.DefaultValue != null)
										rv.Value = selV.DefaultValue;

									if (rv.Value != null)
									{
										if (rv.Type == 1)
											SetRegKeyValue(rv.RootKey, rv.SubKey, rv.Name, Convert.ToInt32(rv.Value));
										if (rv.Type == 2)
											SetRegKeyValue(rv.RootKey, rv.SubKey, rv.Name, rv.Value);
									}
									
									
								}
							}
						}
					}
					qNum++;
				}
			}
			Close();
		}

		private void SetRegKeyValue(RegistryImpl.RootKey RootKey, string SubKey, string Value, object Data)
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
					rk = rk.CreateSubKey(Sub);				
				else
					rk = rk.OpenSubKey(Sub);
			}
			rk.SetValue(Value, Data);
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
	}
}
