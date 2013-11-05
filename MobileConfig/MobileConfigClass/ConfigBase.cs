using System;
using System.Data;

namespace MobileConfig
{
    public abstract class ConfigBase
    {
        protected DataRow _dataRow;
        protected DataSet _masterDS;

        public ConfigBase()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            ID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +
                   DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +
                   random.Next(10, 90).ToString();
        }        

        public ConfigBase(DataSet Data, string ID)
        {            
            _masterDS = Data;
            Open(ID);
        }

        public virtual string ID
        {
            get { return "";  }
            set { }
        }

        public static DataTable TableSpec()
        {
            return null;
        }

        public virtual void Open(string ID)
        {
            if (_masterDS == null || _masterDS.Tables.Count == 0)
                return;
        }
    }
}
