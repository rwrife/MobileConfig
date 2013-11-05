using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MobileConfig
{
    public class Config: ConfigBase, ConfigInterface
    {
        public const string TableName = "Config";

        private string _configid;
        private string _name;
        private string _description;
        private string _exdescription;
        private string _groupid;
        private Question[] _questions = null;

        public Config()
        {
        }

        public Config(DataSet Data, string ID)
        {            
            _masterDS = Data;
            Open(ID);
        }

        public override string ID
        {
            get { return _configid; }
            set { _configid = value; }
        }

        public string GroupID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ExDescription
        {
            get { return _exdescription; }
            set { _exdescription = value; }
        }

        public Question[] Questions
        {
            get {                 
                if (_questions == null && _masterDS != null)
                {
                    DataTable dt = _masterDS.Tables[MobileConfig.Question.TableName];
                    if (dt != null)
                    {
                        DataRow[] rows = dt.Select("ConfigID = '" + ID + "'");
                        if (rows.Length > 0)
                        {
                            _questions = new Question[rows.Length];
                            for (int i = 0; i < rows.Length; i++)
                            {
                                _questions[i] = new Question(_masterDS, rows[i]["QuestionID"].ToString());
                            }
                        }
                    }
                }
                return _questions;            
            }
            set { _questions = value; }
        }

        public new static DataTable TableSpec()
        {
            DataTable dt = new DataTable();
            dt.TableName = TableName;
            dt.Columns.Add("ConfigID", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Desc", Type.GetType("System.String"));
            dt.Columns.Add("ExDesc", Type.GetType("System.String"));
            dt.Columns.Add("GroupID", Type.GetType("System.String"));
            return dt;
        }

        public object[] Data
        {
            get
            {
                object[] retData = new object[5];
                retData[0] = ID;
                retData[1] = Name;
                retData[2] = (Description != "" ? Description : null);
                retData[3] = (ExDescription != "" ? ExDescription : null);
                retData[4] = GroupID;
                return retData;
            }            
        }

        public override void Open(string ID)
        {
            base.Open(ID);

            if (_masterDS.Tables[TableName] != null)
            {
                DataTable dt = _masterDS.Tables[TableName];
                DataRow[] dr = dt.Select("ConfigID = '" + ID + "'");
                if (dr.Length > 0)                
                    OpenFromDataRow(dr[0]);                
            }
        }

        public void OpenFromDataRow(DataRow dr)
        {
            if(dr["ConfigID"] != DBNull.Value)
                ID = dr["ConfigID"].ToString();
            if (dr["Name"] != DBNull.Value)
                Name = dr["Name"].ToString();
            if (dr["Desc"] != DBNull.Value)
                Description = dr["Desc"].ToString();
            if (dr["ExDesc"] != DBNull.Value)
                ExDescription = dr["ExDesc"].ToString();
            if (dr["GroupID"] != DBNull.Value)
                GroupID = dr["GroupID"].ToString();


        }
    }
}
