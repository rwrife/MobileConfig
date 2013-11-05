using System;
using System.Data;

namespace MobileConfig
{
    public interface ConfigInterface
    {      
        object[] Data
        {
            get;
        }

        void OpenFromDataRow(DataRow dr);
    }
}
