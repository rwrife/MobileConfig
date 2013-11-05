using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileConfigBuilder
{
    public partial class Config : Form
    {
        private MobileConfig.Config _config;

        public MobileConfig.Config Value
        {
            get { return _config; }
        }
       
        public Config(MobileConfig.Config c)
        {
            InitializeComponent();
            _config = c;

            ConfigName.Text = c.Name;
            Desc.Text = c.Description;
            ExtDesc.Text = c.ExDescription;
            BindQuestions();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _config.Name = ConfigName.Text;
            _config.Description = Desc.Text;
            _config.ExDescription = ExtDesc.Text;
            
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _config = null;
            this.Close();
        }

        private void BindQuestions()
        {
            Questions.Items.Clear();
            Questions.DisplayMember = "Description";
            Questions.ValueMember = "ID";
            if(_config.Questions != null)
            {
                foreach (MobileConfig.Question q in _config.Questions)
                    Questions.Items.Add(q);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Questions.SelectedItem != null)
            {
                if(Questions.Items.Count == 1)
                {
                    _config.Questions = null;
                    BindQuestions();
                    return;
                }

                for(int i = 0;i<_config.Questions.Length;i++)
                {
                    if (_config.Questions[i].ID == ((MobileConfig.Question)Questions.SelectedItem).ID)
                    {
                        MobileConfig.Question[] newArray = new MobileConfig.Question[_config.Questions.Length - 1];
                        for(int j = 0;j<i;j++)                        
                            newArray[j] = _config.Questions[j];
                        
                        for (int j = i + 1; j < _config.Questions.Length; j++)                        
                            newArray[j - 1] = _config.Questions[j];
                        BindQuestions();
                        break;
                    }
                }
            }
        }

        private void AddQButton_Click(object sender, EventArgs e)
        {
            MobileConfig.Question q = new MobileConfig.Question();
            q.ConfigID = _config.ID;
            Question qForm = new Question(q);
            qForm.ShowDialog();
            if (qForm.Value != null)
            {
                if (_config.Questions != null)
                {
                    MobileConfig.Question[] newArray = new MobileConfig.Question[_config.Questions.Length + 1];
                    for (int i = 0; i < _config.Questions.Length; i++)
                    {
                        newArray[i] = _config.Questions[i];
                    }
                    _config.Questions = newArray;
                }
                else
                    _config.Questions = new MobileConfig.Question[1];

                _config.Questions[_config.Questions.Length - 1] = qForm.Value;
            }
            BindQuestions();

        }

        private void Questions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Questions.SelectedItem != null)
            {
                Question qForm = new Question((MobileConfig.Question)Questions.SelectedItem);
                qForm.ShowDialog();
                if (qForm.Value != null)
                {
                    for (int i = 0; i < _config.Questions.Length; i++)
                    {
                        if (_config.Questions[i].ID == qForm.Value.ID)
                        {
                            _config.Questions[i] = qForm.Value;
                            break;
                        }
                    }
                    BindQuestions();
                }
            }
        }
    }
}