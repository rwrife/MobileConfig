#region Using directives

using System;
using System.Data;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for RegValue.
	/// </summary>
	public class RegValue
	{
		private DataSet cfgDs;
		public int RegValueID;
		public string Key;
		public string SubKey;
		public string Name;
		public string Value = null;
		public int Type;

		public RegistryImpl.RootKey RootKey
		{
			get
			{
				RegistryImpl.RootKey rk = RegistryImpl.RootKey.HKEY_LOCAL_MACHINE;

				switch (Key.ToLower())
				{
					case "hkey_local_machine":
						rk = RegistryImpl.RootKey.HKEY_LOCAL_MACHINE;
						break;
					case "hkey_current_user":
						rk = RegistryImpl.RootKey.HKEY_CURRENT_USER;
						break;
				}

				return rk;
			}
		}

		public RegValue(DataSet ConfigDB)
		{
			cfgDs = ConfigDB;
		}

		public void Open(DataRow dr)
		{
			RegValueID = Convert.ToInt32(dr["RegValueID"]);
			Key = dr["Key"].ToString();
			SubKey = dr["SubKey"].ToString();
			Name = dr["Name"].ToString();
			if(dr["Value"] != DBNull.Value)
				Value = dr["Value"].ToString();			
			Type = Convert.ToInt32(dr["Type"]);
		}
	}
}
