using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MobileConfig
{
    public class Value: ConfigBase, ConfigInterface
    {
        public const string TableName = "Value";

        private string _valueid;
        private string _name;
        private string _value;
        private string _defaultvalue;
        private string _questionid;
		private RegValue[] _regvalues;
		private string _regvalueids;

        public Value()
        {
        }

        public Value(DataSet Data, string ID)
        {            
            _masterDS = Data;
            Open(ID);
        }

        public override string ID
        {
            get { return _valueid; }
            set { _valueid = value; }
        }

        public string QuestionID
        {
            get { return _questionid; }
            set { _questionid = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string DefaultValue
        {
            get { return _defaultvalue; }
            set { _defaultvalue = value; }

        }

		public RegValue[] RegValues
		{
			get
			{
				if (_regvalues != null)
					return _regvalues;

				if (_regvalueids != null && _regvalueids != "" && _masterDS != null)
				{
					DataTable dt = _masterDS.Tables[MobileConfig.RegValue.TableName];
					if (dt != null)
					{
						DataRow[] rows = dt.Select("RegValueID In ('" + _regvalueids.Replace(",", "','") + "')");
						if (rows.Length > 0)
						{
							_regvalues = new RegValue[rows.Length];
							for (int i = 0; i < rows.Length; i++)
							{
								_regvalues[i] = new RegValue(_masterDS, rows[i]["RegValueID"].ToString());
							}
						}
					}
					return _regvalues;
				}
				else
					return null;				
			}
			set { _regvalues = value; }
		}

		public string RegValueIDs
		{
			get
			{
				if (RegValues != null)
				{
					string newVals = "";
					foreach (RegValue rv in RegValues)
						newVals += (newVals.Length > 0 ? "," : "") + rv.ID;
					_regvalueids = newVals;
					return _regvalueids;
				}
				else
					return null;				
			}
			set
			{
				_regvalueids = value;
			}
		}

        public new static DataTable TableSpec()
        {
            DataTable dt = new DataTable();
            dt.TableName = TableName;
            dt.Columns.Add("ValueID", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("CValue", Type.GetType("System.String"));
            dt.Columns.Add("DefaultValue", Type.GetType("System.String"));
            dt.Columns.Add("QuestionID", Type.GetType("System.String"));
			dt.Columns.Add("RegValueIDs", Type.GetType("System.String"));
            return dt;
        }

        public object[] Data
        {
            get
            {
                object[] retData = new object[6];
                retData[0] = ID;
                retData[1] = (Name != "" ? Name : null);
                retData[2] = (value != "" ? value : null);
                retData[3] = (DefaultValue != ""? DefaultValue : null);
                retData[4] = QuestionID;
				retData[5] = RegValueIDs;
                return retData;
            }            
        }

        public override void Open(string ID)
        {
            base.Open(ID);

            if (_masterDS.Tables[TableName] != null)
            {
                DataTable dt = _masterDS.Tables[TableName];
                DataRow[] dr = dt.Select("ValueID = '" + ID + "'");
                if (dr.Length > 0)                
                    OpenFromDataRow(dr[0]);                
            }
        }

        public void OpenFromDataRow(DataRow dr)
        {
            if (dr["ValueID"] != DBNull.Value)
                ID = dr["ValueID"].ToString();
            if(dr["QuestionID"] != DBNull.Value)
                QuestionID = dr["QuestionID"].ToString();
            if (dr["Name"] != DBNull.Value)
                Name = dr["Name"].ToString();
            if (dr.Table.Columns.Contains("CValue") &&  dr["CValue"] != DBNull.Value)
                value = dr["CValue"].ToString();
			if (dr.Table.Columns.Contains("Value") && dr["Value"] != DBNull.Value)
				value = dr["Value"].ToString();
            if (dr.Table.Columns.Contains("DefaultValue") && dr["DefaultValue"] != DBNull.Value)
                DefaultValue = dr["DefaultValue"].ToString();
			if (dr.Table.Columns.Contains("RegValueIDs") && dr["RegValueIDs"] != DBNull.Value)
				_regvalueids = dr["RegValueIDs"].ToString();
        }
    }
}
