using System;
using System.Collections.Generic;
using System.Text;
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
