#region Using directives

using System;
using System.Data;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for Value.
	/// </summary>
	public class Value
	{
		private DataSet cfgDs;
		private int _valueid;
		private string _name = null;
		public string DefaultValue = null;
		public RegValue[] _regValues;
		public string RegIDs;

		public RegValue[] RegValues
		{
			get
			{
				if (_regValues == null || _regValues.Length == 0)
				{
					DataRow[] regVals = cfgDs.Tables["RegValue"].Select("RegValueID In (" + RegIDs + ")");

					int rCount = regVals.Length;

					if (rCount > 0)
					{
						_regValues = new RegValue[rCount];
						for (int i = 0; i < rCount; i++)
						{
							_regValues[i] = new RegValue(cfgDs);
							_regValues[i].Open(regVals[i]);
						}
					}
				}
				return _regValues;
			}
			set
			{
				_regValues = value;
			}
		}

		public int ValueID
		{
			get { return _valueid; }
			set { _valueid = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Value(DataSet ConfigDB)
		{
			cfgDs = ConfigDB;
		}

		public void Open(DataRow dr)
		{
			if(dr["Name"] != DBNull.Value)
				_name = dr["Name"].ToString();
			_valueid = Convert.ToInt32(dr["ValueID"]);
			if (dr["Value"] != DBNull.Value)
				DefaultValue = dr["Value"].ToString();
			RegIDs = dr["RegValues"].ToString();
		}
	}
}
