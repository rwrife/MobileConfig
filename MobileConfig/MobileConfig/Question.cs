#region Using directives

using System;
using System.Data;
using System.Collections;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for Question.
	/// </summary>
	public class Question
	{
		private DataSet cfgDs;
		public string Name;
		private Value[] _values;
		public int DefaultValue = 0;
		public int QuestionID;
		public int SelectedRegValue = 0;

		public Question(DataSet ConfigDB)
		{
			cfgDs = ConfigDB;
		}

		public Value[] Values
		{
			get
			{
				if (_values == null || _values.Length == 0)
				{
					DataRow[] vals = cfgDs.Tables["Value"].Select("QuestionID = " + QuestionID.ToString());
					int vCount = vals.Length;
					if (vCount > 0)
					{
						_values = new Value[vCount];
						for (int i = 0; i < vCount; i++)
						{
							_values[i] = new Value(cfgDs);
							_values[i].Open(vals[i]);
						}
					}
				}
				return _values;
			}
			set
			{
				_values = value;
			}
		}

		public void Open(DataRow dr)
		{			
			Name = dr["Name"].ToString();
			QuestionID = Convert.ToInt32(dr["QuestionID"]);
			if(dr["DefaultValue"] != DBNull.Value)
				DefaultValue = Convert.ToInt32(dr["DefaultValue"]);
			if (dr["SelectedRegValue"] != DBNull.Value)
				SelectedRegValue = Convert.ToInt32(dr["SelectedRegValue"]);				
		}
	}
}
