#region Using directives

using System;
using System.Data;
using System.Collections;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for Configurations.
	/// </summary>
	public class Configurations: ArrayList
	{
		private DataSet cfgDs;

		public Configurations()
		{
			cfgDs = BuildDataSet();
		}

		private string XMLFileName
		{
			get
			{
				return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "\\" + "mobileconfig.xml";
			}
		}

		public void BuildSampleData()
		{
			DataSet ds = cfgDs;
			
			object[] dataRow = new object[3];
			dataRow[0] = 1;
			dataRow[1] = "Glyph Cache";
			dataRow[2] = "Sets the amount of memory dedicated to caching graphics information.  The more memory allocated to caching then the less the system will have to reload icons and graphics.";
			ds.Tables["Config"].Rows.Add(dataRow);

			dataRow = new object[3];
			dataRow[0] = 2;
			dataRow[1] = "FAT File Cache";
			dataRow[2] = "Sets the amount of memory dedicated to caching file system information.";
			ds.Tables["Config"].Rows.Add(dataRow);

			dataRow = new object[4];
			dataRow[0] = 1;
			dataRow[1] = 1;
			dataRow[2] = "Glyph Cache Size";
			dataRow[3] = 2;
			ds.Tables["Question"].Rows.Add(dataRow);

			dataRow = new object[4];
			dataRow[0] = 2;
			dataRow[1] = 2;
			dataRow[2] = "FAT File Cache Size";
			dataRow[3] = null;
			ds.Tables["Question"].Rows.Add(dataRow);

			dataRow = new object[3];
			dataRow[0] = 1;
			dataRow[1] = 1;
			dataRow[2] = "4MB";
			ds.Tables["Value"].Rows.Add(dataRow);

			dataRow[0] = 2;
			dataRow[1] = 1;
			dataRow[2] = "8MB (default)";
			ds.Tables["Value"].Rows.Add(dataRow);

			dataRow[0] = 3;
			dataRow[1] = 1;
			dataRow[2] = "16MB";
			ds.Tables["Value"].Rows.Add(dataRow);

			dataRow[0] = 4;
			dataRow[1] = 1;
			dataRow[2] = "32MB";
			ds.Tables["Value"].Rows.Add(dataRow);

			dataRow = new object[3];
			dataRow[0] = 5;
			dataRow[1] = 2;
			dataRow[2] = null;
			ds.Tables["Value"].Rows.Add(dataRow);

			dataRow = new object[6];
			dataRow[0] = 1;
			dataRow[1] = "HKEY_LOCAL_MACHINE";
			dataRow[2] = "\\SYSTEM\\GDI\\GLYPHCACHE";
			dataRow[3] = "limit";
			dataRow[4] = "4096";
			dataRow[5] = 1;
			ds.Tables["RegValue"].Rows.Add(dataRow);

			dataRow[0] = 2;
			dataRow[1] = "HKEY_LOCAL_MACHINE";
			dataRow[2] = "\\SYSTEM\\GDI\\GLYPHCACHE";
			dataRow[3] = "limit";
			dataRow[4] = "8192";
			dataRow[5] = 1;
			ds.Tables["RegValue"].Rows.Add(dataRow);

			dataRow[0] = 3;
			dataRow[1] = "HKEY_LOCAL_MACHINE";
			dataRow[2] = "\\SYSTEM\\GDI\\GLYPHCACHE";
			dataRow[3] = "limit";
			dataRow[4] = "16384";
			dataRow[5] = 1;
			ds.Tables["RegValue"].Rows.Add(dataRow);

			dataRow[0] = 4;
			dataRow[1] = "HKEY_LOCAL_MACHINE";
			dataRow[2] = "\\SYSTEM\\GDI\\GLYPHCACHE";
			dataRow[3] = "limit";
			dataRow[4] = "32768";
			dataRow[5] = 1;
			ds.Tables["RegValue"].Rows.Add(dataRow);

			dataRow[0] = 5;
			dataRow[1] = "HKEY_LOCAL_MACHINE";
			dataRow[2] = "\\System\\StorageManager\\FATFS";
			dataRow[3] = "CacheSize";
			dataRow[4] = null;
			dataRow[5] = 1;
			ds.Tables["RegValue"].Rows.Add(dataRow);

			ds.WriteXml(XMLFileName);
		}

		private bool LoadDataSet()
		{
			try
			{
				cfgDs.ReadXml(XMLFileName);
				return true;
			}
			catch(System.Exception ex)
			{
				return false;
			}			
		}

		private DataSet BuildDataSet()
		{
			DataSet ds = new DataSet("MobileConfig");
			ds.Tables.Add("Setting");
			ds.Tables.Add("Config");
			ds.Tables.Add("Question");
			ds.Tables.Add("Value");
			ds.Tables.Add("RegValue");

			//settings table
			ds.Tables["Setting"].Columns.Add("Name", Type.GetType("System.String"));
			ds.Tables["Setting"].Columns.Add("Value", Type.GetType("System.String"));
			
			//config table
			ds.Tables["Config"].Columns.Add("ConfigID", Type.GetType("System.Int16"));
			ds.Tables["Config"].Columns.Add("Name", Type.GetType("System.String"));
			ds.Tables["Config"].Columns.Add("Description", Type.GetType("System.String"));

			//question table
			ds.Tables["Question"].Columns.Add("QuestionID", Type.GetType("System.Int16"));
			ds.Tables["Question"].Columns.Add("ConfigID", Type.GetType("System.Int16"));
			ds.Tables["Question"].Columns.Add("Name", Type.GetType("System.String"));
			ds.Tables["Question"].Columns.Add("DefaultValue", Type.GetType("System.Int16"));
			ds.Tables["Question"].Columns.Add("SelectedRegValue", Type.GetType("System.Int16"));			
			//ds.Relations.Add( new DataRelation("ConfigQuestions", ds.Tables["Config"].Columns["ConfigID"], ds.Tables["Question"].Columns["ConfigID"]));			

			//value table
			ds.Tables["Value"].Columns.Add("ValueID", Type.GetType("System.Int16"));
			ds.Tables["Value"].Columns.Add("QuestionID", Type.GetType("System.Int16"));			
			ds.Tables["Value"].Columns.Add("Name", Type.GetType("System.String"));
			ds.Tables["Value"].Columns.Add("Value", Type.GetType("System.String"));
			ds.Tables["Value"].Columns.Add("RegValues", Type.GetType("System.String"));
			//ds.Relations.Add(new DataRelation("QuestionValues", ds.Tables["Question"].Columns["QuestionID"], ds.Tables["Value"].Columns["QuestionID"]));
			//ds.Relations.Add(new DataRelation("ConfigQuestions", ds.Tables["Value"].Columns["ValueID"], ds.Tables["Question"].Columns["DefaultValueID"]));

			//regvalue table
			ds.Tables["RegValue"].Columns.Add("RegValueID", Type.GetType("System.Int16"));
			ds.Tables["RegValue"].Columns.Add("Key", Type.GetType("System.String"));
			ds.Tables["RegValue"].Columns.Add("SubKey", Type.GetType("System.String"));
			ds.Tables["RegValue"].Columns.Add("Name", Type.GetType("System.String"));
			ds.Tables["RegValue"].Columns.Add("Value", Type.GetType("System.String"));
			ds.Tables["RegValue"].Columns.Add("Type", Type.GetType("System.Int16"));
			//ds.Relations.Add(new DataRelation("ValueRegValues", ds.Tables["Value"].Columns["ValueID"], ds.Tables["RegValue"].Columns["ValueID"]));

			return ds;
		}

		public void Open()
		{
			if (LoadDataSet())
			{
				foreach(DataRow dr in cfgDs.Tables["Config"].Rows)
				{
					Configuration cfg = new Configuration(cfgDs);
					cfg.Open(dr);
					this.Add(cfg);
				}
			}
		}

		public RegValue OpenRegValue(int RegValueID)
		{
			DataRow[] regVals = cfgDs.Tables["RegValue"].Select("RegValueID = " + RegValueID.ToString());
			if(regVals != null && regVals.Length > 0)
			{
				RegValue rv = new RegValue(cfgDs);
				rv.Open(regVals[0]);
				return rv;
			}else
				return null;
		}
	}
}
