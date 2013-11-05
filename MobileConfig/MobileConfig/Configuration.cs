#region Using directives

using System;
using System.Data;

#endregion

namespace MobileConfig
{
	/// <summary>
	/// Summary description for Configuration.
	/// </summary>
	public class Configuration
	{
		private DataSet cfgDs;
		public string Description;
		public string Name;
		public int ConfigID;
		private Question[] _questions;

		public Configuration(DataSet ConfigDB)
		{
			cfgDs = ConfigDB;
		}

		public Question[] Questions
		{
			get{
				if (_questions == null || _questions.Length == 0)
				{
					DataRow[] qs = cfgDs.Tables["Question"].Select("ConfigID = " + ConfigID.ToString());
					int qCount = qs.Length;
					if (qCount > 0)
					{
						_questions = new Question[qCount];
						for (int i = 0; i < qCount; i++)
						{
							_questions[i] = new Question(cfgDs);
							_questions[i].Open(qs[i]);
						}
					}
				}
				return _questions;
			}
			set{
				_questions = value;
			}
		}

		public void Open(DataRow dr)
		{
			ConfigID = Convert.ToInt16(dr["ConfigID"].ToString());
			Name = dr["Name"].ToString();
			Description = dr["Description"].ToString();
		}

		
	}
}
