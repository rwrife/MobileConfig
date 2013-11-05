using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileConfigBuilder
{
    public partial class RegValue : Form
    {
        public List<ListItem> _keys = new List<ListItem>();
        public List<ListItem> _types = new List<ListItem>();
        public List<ListItem> _actions = new List<ListItem>();

        private MobileConfig.RegValue _regvalue;

        public RegValue(MobileConfig.RegValue r)
        {
            InitializeComponent();

            _regvalue = r;

            _keys.Add(new ListItem("hklm", "HKEY_LOCAL_MACHINE"));
            _keys.Add(new ListItem("hkcu", "HKEY_CURRENT_USER"));

            _types.Add(new ListItem("0", "DWORD (Number)"));
            _types.Add(new ListItem("1", "String"));
            _types.Add(new ListItem("2", "Binary (Byte Array)"));

            _actions.Add(new ListItem("0", "Add/Update Value"));
            _actions.Add(new ListItem("1", "Delete Value"));

            BindLists();

			SubKey.Text = _regvalue.SubKey;
			NameText.Text = _regvalue.Name;
			ValueText.Text = _regvalue.Value;
			for (int i = 0; i < Keys.Items.Count; i++)
				if (((ListItem)Keys.Items[i]).Key == _regvalue.Key)
					Keys.SelectedIndex = i;
			for (int i = 0; i < Types.Items.Count; i++)
				if (((ListItem)Types.Items[i]).Key == _regvalue.type)
					Types.SelectedIndex = i;
			for (int i = 0; i < Actions.Items.Count; i++)
				if (((ListItem)Actions.Items[i]).Key == _regvalue.Action)
					Actions.SelectedIndex = i;
        }

        private void BindLists()
        {
            Keys.Items.Clear();
            Actions.Items.Clear();
            Types.Items.Clear();

            Keys.DisplayMember = "Value";
            Keys.ValueMember = "Key";

            Actions.DisplayMember = "Value";
            Actions.ValueMember = "Key";

            Types.DisplayMember = "Value";
            Types.ValueMember = "Key";

            foreach (ListItem li in _keys)
                Keys.Items.Add(li);

            foreach(ListItem li in _types)
                Types.Items.Add(li);

            foreach (ListItem li in _actions)
                Actions.Items.Add(li);

            Keys.SelectedIndex = 0;
            Actions.SelectedIndex = 0;
            Types.SelectedIndex = 0;
        }

		public MobileConfig.RegValue Value
		{
			get { return _regvalue; }
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			_regvalue = null;
			this.Close();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			_regvalue.Name = NameText.Text;
			_regvalue.SubKey = SubKey.Text;
			_regvalue.Key = ((ListItem)Keys.SelectedItem).Key;
			_regvalue.Action = ((ListItem)Actions.SelectedItem).Key;
			_regvalue.type = ((ListItem)Types.SelectedItem).Key;
			_regvalue.Value = ValueText.Text;
			this.Close();
		}


    }

	public class ListItem
	{
		private string _key;
		private string _value;

		public ListItem(string key, string value)
		{
			_key = key;
			_value = value;
		}

		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}

		public string Value
		{
			get { return _value; }
			set { _value = value; }
		}
	}
}