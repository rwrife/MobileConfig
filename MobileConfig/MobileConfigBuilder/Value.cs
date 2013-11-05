using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileConfigBuilder
{
    public partial class Value : Form
    {
        private MobileConfig.Value _value;
		private MobileConfig.Question _question;

        public Value(MobileConfig.Question q, MobileConfig.Value v)
        {
            InitializeComponent();

            _value = v;
			_question = q;
			
			BindRegValues();

            NameText.Text = v.Name;
            ValueText.Text = v.value;
            DefaultValue.Text = v.DefaultValue;
        }

		private void BindRegValues()
		{
			RegValues.Items.Clear();
			RegValues.DisplayMember = "FriendlyName";
			RegValues.ValueMember = "ID";
			if (_question.RegValues != null)
				foreach (MobileConfig.RegValue rv in _question.RegValues)
					RegValues.Items.Add(rv);

			if(_value.RegValues != null)
				foreach (MobileConfig.RegValue rv in _value.RegValues)
				{
					for (int i = 0; i < RegValues.Items.Count; i++)
					{
						if (((MobileConfig.RegValue)RegValues.Items[i]).ID == rv.ID)
							RegValues.SetItemChecked(i, true);
					}
				}
		}

        public MobileConfig.Value value
        {
            get { return _value; }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _value = null;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _value.Name = NameText.Text;
            _value.DefaultValue = DefaultValue.Text;
            _value.value = ValueText.Text;

			List<MobileConfig.RegValue> checkedItems = new List<MobileConfig.RegValue>();
			for (int i = 0; i < RegValues.Items.Count; i++)
				if (RegValues.GetItemChecked(i))
					checkedItems.Add((MobileConfig.RegValue)RegValues.Items[i]);

			_value.RegValues = checkedItems.ToArray();

            this.Close();
        }

		private void AddVButton_Click(object sender, EventArgs e)
        {
            MobileConfig.RegValue r = new MobileConfig.RegValue();
			r.QuestionID = _question.ID;
            RegValue rvForm = new RegValue(r);
            rvForm.ShowDialog();
			if (rvForm.Value != null)
			{
				if (_value.RegValues == null)
				{
					_value.RegValues = new MobileConfig.RegValue[1];
					_value.RegValues[0] = rvForm.Value;
				}
				else
				{
					List<MobileConfig.RegValue> newList = new List<MobileConfig.RegValue>();
					newList.AddRange(_value.RegValues);
					newList.Add(rvForm.Value);
					_value.RegValues = newList.ToArray();
				}

				if (_question.RegValues == null)
				{
					_question.RegValues = new MobileConfig.RegValue[1];
					_question.RegValues[0] = rvForm.Value;
				}
				else
				{
					List<MobileConfig.RegValue> newList = new List<MobileConfig.RegValue>();
					newList.AddRange(_question.RegValues);
					newList.Add(rvForm.Value);
					_question.RegValues = newList.ToArray();
				}
			}
			BindRegValues();
        }

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (RegValues.SelectedItem != null)
			{
				RegValue rvForm = new RegValue((MobileConfig.RegValue)RegValues.SelectedItem);
				rvForm.ShowDialog();
				if (rvForm.Value != null)
				{
					for(int i =0;i<_question.RegValues.Length;i++)
					{
						MobileConfig.RegValue rv = _question.RegValues[i];
						if (rv.ID == rvForm.Value.ID)
						{
							_question.RegValues[i] = rvForm.Value;
							break;
						}
					}

					for (int i = 0; i < _value.RegValues.Length; i++)
					{
						MobileConfig.RegValue rv = _value.RegValues[i];
						if (rv.ID == rvForm.Value.ID)
						{
							_value.RegValues[i] = rvForm.Value;
							break;
						}
					}

				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_question.RegValues != null && RegValues.SelectedItem != null)
			{
				if (_question.RegValues.Length == 1)
					_question.RegValues = null;
				else
				{
					List<MobileConfig.RegValue> newList = new List<MobileConfig.RegValue>();
					newList.AddRange(_question.RegValues);
					newList.Remove((MobileConfig.RegValue)RegValues.SelectedItem);
					_question.RegValues = newList.ToArray();
				}
			}
			if (_value.RegValues != null && RegValues.SelectedItem != null)
			{
				List<MobileConfig.RegValue> newList = new List<MobileConfig.RegValue>();
				newList.AddRange(_value.RegValues);
				if(newList.Contains((MobileConfig.RegValue)RegValues.SelectedItem))
				{
					newList.Remove((MobileConfig.RegValue)RegValues.SelectedItem);
					if (newList.Count == 0)
						_value.RegValues = null;
					else
						_value.RegValues = newList.ToArray();
				}
			}
			BindRegValues();
		}
    }
}