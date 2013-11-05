using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MobileConfig
{
    public class Group: ConfigBase, ConfigInterface
    {
        public const string TableName = "Group";

        private string _groupid;
        private string _name;

        public Group()
        {
        }

        public Group(DataSet Data, string ID)
        {            
            _masterDS = Data;
            Open(ID);
        }

        public override string ID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public new static DataTable TableSpec()
        {
            DataTable dt = new DataTable();
            dt.TableName = TableName;
            dt.Columns.Add("GroupID", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            return dt;
        }

        public object[] Data
        {
            get
            {
                object[] retData = new object[2];
                retData[0] = ID;
                retData[1] = Name;                
                return retData;
            }            
        }

        public override void Open(string ID)
        {
            base.Open(ID);

            if (_masterDS.Tables[TableName] != null)
            {
                DataTable dt = _masterDS.Tables[TableName];
                DataRow[] dr = dt.Select("GroupID = '" + ID + "'");
                if (dr.Length > 0)                
                    OpenFromDataRow(dr[0]);                
            }
        }

        public void OpenFromDataRow(DataRow dr)
        {
            if(dr["GroupID"] != DBNull.Value)
                ID = dr["GroupID"].ToString();
            if (dr["Name"] != DBNull.Value)
                Name = dr["Name"].ToString();
        }
    }
}
