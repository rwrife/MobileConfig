using System;
using System.Data;

namespace MobileConfig
{
    public class RegValue: ConfigBase, ConfigInterface
    {
		public const string TableName = "RegValue";

		private string _regvalueid;
        private string _key;
        private string _subkey;
        private string _name;
        private string _value;
        private string _type;
        private string _action;
		private string _questionid;

        public RegValue()
        {
        }

        public RegValue(DataSet Data, string ID)
        {            
            _masterDS = Data;
            Open(ID);
        }

		public override string ID
		{
			get { return _regvalueid; }
			set { _regvalueid = value; }
		}

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string SubKey
        {
            get { return _subkey; }
            set { _subkey = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

		public string FriendlyName
		{
			get
			{
				return Name + (Value != null && Value != "" ? " = " + Value : "");
			}
		}

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

		public string QuestionID
		{
			get { return _questionid; }
			set { _questionid = value; }
		}

		public new static DataTable TableSpec()
		{
			DataTable dt = new DataTable();
			dt.TableName = TableName;
			dt.Columns.Add("RegValueID", Type.GetType("System.String"));
			dt.Columns.Add("Key", Type.GetType("System.String"));
			dt.Columns.Add("SubKey", Type.GetType("System.String"));
			dt.Columns.Add("Name", Type.GetType("System.String"));
			dt.Columns.Add("RValue", Type.GetType("System.String"));
			dt.Columns.Add("Type", Type.GetType("System.String"));
			dt.Columns.Add("Action", Type.GetType("System.String"));
			dt.Columns.Add("QuestionID", Type.GetType("System.String"));
			return dt;
		}

		public object[] Data
		{
			get
			{
				object[] retData = new object[8];
				retData[0] = ID;
				retData[1] = Key;
				retData[2] = (SubKey != "" ? SubKey : null);
				retData[3] = (Name != "" ? Name : null);
				retData[4] = (Value != "" ? Value : null);
				retData[5] = type;
				retData[6] = Action;
				retData[7] = QuestionID;
				return retData;
			}
		}

		public override void Open(string ID)
		{
			base.Open(ID);

			if (_masterDS.Tables[TableName] != null)
			{
				DataTable dt = _masterDS.Tables[TableName];
				DataRow[] dr = dt.Select("RegValueID = '" + ID + "'");
				if (dr.Length > 0)
					OpenFromDataRow(dr[0]);
			}
		}

		public void OpenFromDataRow(DataRow dr)
		{
			if (dr["RegValueID"] != DBNull.Value)
				ID = dr["RegValueID"].ToString();
			if (dr.Table.Columns.Contains("Name") && dr["Name"] != DBNull.Value)
				Name = dr["Name"].ToString();
			if (dr["Key"] != DBNull.Value)
				Key = dr["Key"].ToString();
			if (dr.Table.Columns.Contains("SubKey") && dr["SubKey"] != DBNull.Value)
				SubKey = dr["SubKey"].ToString();
			if (dr.Table.Columns.Contains("Value") && dr["Value"] != DBNull.Value)
				Value = dr["Value"].ToString();
			if (dr.Table.Columns.Contains("RValue") && dr["RValue"] != DBNull.Value)
				Value = dr["RValue"].ToString();
			if (dr["Type"] != DBNull.Value)
				type = dr["Type"].ToString();
			if (dr["Action"] != DBNull.Value)
				Action = dr["Action"].ToString();
			if (dr["QuestionID"] != DBNull.Value)
				QuestionID = dr["QuestionID"].ToString();
		}

    }
}
