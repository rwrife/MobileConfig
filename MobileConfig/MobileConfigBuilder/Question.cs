using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileConfigBuilder
{
    public partial class Question : Form
    {
        private MobileConfig.Question _question;

        public Question(MobileConfig.Question q)
        {
            InitializeComponent();
            _question = q;

            BindValues();
			BindRegValues();

            textBox1.Text = q.Description;
            if (_question.DefaultValue != null)
            {
                for (int i = 0; i < DefaultValue.Items.Count; i++)
                {
                    if (DefaultValue.Items[i] is MobileConfig.Value && ((MobileConfig.Value)DefaultValue.Items[i]).ID == _question.DefaultValue.ID)
                    {
                        DefaultValue.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
                DefaultValue.SelectedIndex = -1;

			if (_question.SelectRegValue != null)
			{
				for (int i = 0; i < SelectedValue.Items.Count; i++)
				{
					if (SelectedValue.Items[i] is MobileConfig.RegValue && ((MobileConfig.RegValue)SelectedValue.Items[i]).ID == _question.SelectRegValue.ID)
					{
						SelectedValue.SelectedIndex = i;
						break;
					}
				}
			}
			else
				SelectedValue.SelectedIndex = -1;
        }

        public MobileConfig.Question Value
        {
            get { return _question; }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _question = null;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _question.Description = textBox1.Text;

			if (SelectedValue.SelectedIndex > 0)
				_question.SelectRegValue = (MobileConfig.RegValue)SelectedValue.SelectedItem;
			else
				_question.SelectRegValue = null;

            if (DefaultValue.SelectedIndex > 0)
                _question.DefaultValue = (MobileConfig.Value) DefaultValue.SelectedItem;
            else
                _question.DefaultValue = null;

            this.Close();
        }

		private void BindRegValues()
		{
			SelectedValue.Items.Clear();
			SelectedValue.DisplayMember = "FriendlyName";
			SelectedValue.ValueMember = "ID";
			if (_question.RegValues != null)
				foreach (MobileConfig.RegValue rv in _question.RegValues)
					SelectedValue.Items.Add(rv);

			SelectedValue.Items.Insert(0, "");

			if (_question.SelectRegValue != null)
			{
				for (int i = 0; i < SelectedValue.Items.Count; i++)
				{
					if (SelectedValue.Items[i] is MobileConfig.RegValue && ((MobileConfig.RegValue)SelectedValue.Items[i]).ID == _question.SelectRegValue.ID)
					{
						SelectedValue.SelectedIndex = i;
						break;
					}
				}
			}
			else
				SelectedValue.SelectedIndex = 0;
		}

        private void BindValues()
        {
            if (_question.Values != null)
            {
                DefaultValue.Items.Clear();
                Values.Items.Clear();
                Values.DisplayMember = "Name";
                Values.ValueMember = "ID";
                DefaultValue.DisplayMember = "Name";
                DefaultValue.ValueMember = "ID";
                foreach (MobileConfig.Value v in _question.Values)
                {
                    Values.Items.Add(v);
                    DefaultValue.Items.Add(v);
                }
                DefaultValue.Items.Insert(0, "");
            }
        }

        private void Values_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Values.SelectedItem != null)
            {
                Value vForm = new Value(_question,(MobileConfig.Value)Values.SelectedItem);
                vForm.ShowDialog();

                if (vForm.value != null)
                {
                    MobileConfig.Value selectedValue;
                    foreach (MobileConfig.Value v in _question.Values)
                    {
                        if (v.ID == vForm.value.ID)
                        {
                            selectedValue = v;
                            break;
                        }
                    }
                    selectedValue = vForm.value;
                    BindValues();
					BindRegValues();
                }
            }
        }

        private void AddVButton_Click(object sender, EventArgs e)
        {
            MobileConfig.Value v = new MobileConfig.Value();
            Value vForm = new Value(_question,v);
            v.QuestionID = _question.ID;
            vForm.ShowDialog();
            if (vForm.value != null)
            {
                if (_question.Values == null)
                {
                    _question.Values = new MobileConfig.Value[1];
                    _question.Values[0] = vForm.value;
                }
                else
                {
                    MobileConfig.Value[] newArray = new MobileConfig.Value[_question.Values.Length + 1];
                    for (int i = 0; i < _question.Values.Length; i++)
                        newArray[i] = _question.Values[i];

                    _question.Values = newArray;
                    _question.Values[_question.Values.Length - 1] = vForm.value;
                }
                BindValues();
				BindRegValues();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Values.SelectedItem != null)
            {
                if (_question.Values.Length == 1)
                    _question.Values = null;
                else
                {
                    MobileConfig.Value[] newArray = new MobileConfig.Value[_question.Values.Length - 1];
                    bool found = false;
                    for (int i = 0; i < _question.Values.Length; i++)
                    {                       
                        if (_question.Values[i].ID != ((MobileConfig.Value)Values.SelectedItem).ID)                        
                            newArray[(found?i-1:i)] = _question.Values[i];                        
                        else
                            found = true;
                    }
                }                
            }
        }


    }
}