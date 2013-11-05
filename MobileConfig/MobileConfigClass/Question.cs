using System;
using System.Data;

namespace MobileConfig
{
    public class Question: ConfigBase, ConfigInterface
    {
        public const string TableName = "Question";

        private string _questionid;
        private string _description;
        private string _configid;
        private Value[] _values = null;
        private Value _defaultvalue = null;
		private string _defaultvalueid = "";
		private RegValue[] _regvalues;
		private RegValue _selregvalue = null;
		private string _selregvalueid = "";

        public Question()
        {
        }

        public Question(DataSet Data, string ID)
        {            
            _masterDS = Data;
            Open(ID);
        }

        public override string ID
        {
            get { return _questionid; }
            set { _questionid = value; }
        }

        public string ConfigID
        {
            get { return _configid; }
            set { _configid = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Value[] Values
        {
            get {                           
                if (_values == null && _masterDS != null)
                {
                    DataTable dt = _masterDS.Tables[MobileConfig.Value.TableName];
                    if (dt != null)
                    {
                        DataRow[] rows = dt.Select("QuestionID = '" + ID + "'");
                        if (rows.Length > 0)
                        {
                            _values = new Value[rows.Length];
                            for (int i = 0; i < rows.Length; i++)
                            {
                                _values[i] = new Value(_masterDS, rows[i]["ValueID"].ToString());
                            }
                        }
                    }
                }                   
                return _values; 
            }
            set { _values = value; }
        }

        public Value DefaultValue
        {
            get
            {

                return _defaultvalue;
            }
            set
            {
                _defaultvalue = value;
            }
        }

		public RegValue[] RegValues
		{
			get
			{return _regvalues;}
			set { _regvalues = value; }
		}

		public RegValue SelectRegValue
		{
			get
			{return _selregvalue;}
			set
			{_selregvalue = value;}
		}

        public new static DataTable TableSpec()
        {
            DataTable dt = new DataTable();
            dt.TableName = TableName;
            dt.Columns.Add("QuestionID", Type.GetType("System.String"));
            dt.Columns.Add("Desc", Type.GetType("System.String"));
            dt.Columns.Add("ConfigID", Type.GetType("System.String"));
            dt.Columns.Add("DefaultValueID", Type.GetType("System.String"));
			dt.Columns.Add("SelectRegValue", Type.GetType("System.String"));			
            return dt;
        }

        public object[] Data
        {
            get
            {
                object[] retData = new object[5];
                retData[0] = ID;
                retData[1] = Description;
                retData[2] = ConfigID;
                retData[3] = (DefaultValue != null ? DefaultValue.ID : null);
				retData[4] = (SelectRegValue != null ? SelectRegValue.ID : null);
                return retData;
            }            
        }

        public override void Open(string ID)
        {
            base.Open(ID);

            if (_masterDS.Tables[TableName] != null)
            {
                DataTable dt = _masterDS.Tables[TableName];
                DataRow[] dr = dt.Select("QuestionID = '" + ID + "'");
                if (dr.Length > 0)                
                    OpenFromDataRow(dr[0]);                
            }
        }

        public void OpenFromDataRow(DataRow dr)
        {
            if (dr["QuestionID"] != DBNull.Value)
                ID = dr["QuestionID"].ToString();
            if(dr["ConfigID"] != DBNull.Value)
                ConfigID = dr["ConfigID"].ToString();
            if (dr["Desc"] != DBNull.Value)
                Description = dr["Desc"].ToString();
			if (dr.Table.Columns.Contains("SelectRegValue") && dr["SelectRegValue"] != DBNull.Value && dr["SelectRegValue"].ToString() != "")
				_selregvalueid = dr["SelectRegValue"].ToString();
			if (dr.Table.Columns.Contains("DefaultValueID") && dr["DefaultValueID"] != DBNull.Value && dr["DefaultValueID"].ToString() != "")
				_defaultvalueid = dr["DefaultValueID"].ToString();

			if (_masterDS != null)
			{
				DataTable dt = _masterDS.Tables[MobileConfig.RegValue.TableName];
				if (dt != null)
				{
					DataRow[] rows = dt.Select("QuestionID = '" + ID + "'");
					if (rows.Length > 0)
					{
						_regvalues = new RegValue[rows.Length];
						for (int i = 0; i < rows.Length; i++)
						{
							_regvalues[i] = new RegValue(_masterDS, rows[i]["RegValueID"].ToString());
						}
					}
				}
			}

			if (_selregvalue == null && _masterDS != null && _selregvalueid != "")
				_selregvalue = new RegValue(_masterDS, _selregvalueid);

			if (_defaultvalue == null && _masterDS != null && _defaultvalueid != "")
				_defaultvalue = new Value(_masterDS, _defaultvalueid);			
        }
    }
}
