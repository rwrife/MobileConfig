using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileConfigBuilder
{
    public partial class Configuration : Form
    {
        private DataSet _masterDS;
        private List<MobileConfig.Group> _groups = new List<MobileConfig.Group>();
        private List<MobileConfig.Config> _configs = new List<MobileConfig.Config>();
       
        public Configuration()
        {
            InitializeComponent();
        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("New Group", "Group Name");
            ib.ShowDialog();
            string groupName = ib.Value;

            if (groupName != "")
            {
                MobileConfig.Group g = new MobileConfig.Group();
                g.Name = groupName;
                _groups.Add(g);
                BindTree();
            }            
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            LoadData();
            BindTree();
        }

        private void LoadData()
        {
            _masterDS = new DataSet();
            if(System.IO.File.Exists("mobileconfig.xml"))
                _masterDS.ReadXml("mobileconfig.xml");

            if(_masterDS.Tables[MobileConfig.Group.TableName] != null)
                foreach (DataRow dr in _masterDS.Tables[MobileConfig.Group.TableName].Rows)
                {
                    MobileConfig.Group g = new MobileConfig.Group(_masterDS, dr["GroupID"].ToString());
                    _groups.Add(g);
                }

            if (_masterDS.Tables[MobileConfig.Config.TableName] != null)
                foreach (DataRow dr in _masterDS.Tables[MobileConfig.Config.TableName].Rows)
                {
                    MobileConfig.Config c = new MobileConfig.Config(_masterDS, dr["ConfigID"].ToString());
                    _configs.Add(c);
                }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _masterDS = new DataSet();
            if (_masterDS != null)
            {
				_masterDS.DataSetName = "MobileConfig";
                if (MobileConfig.Group.TableSpec() != null)
                {
                    _masterDS.Tables.Add(MobileConfig.Group.TableSpec());
                    foreach (MobileConfig.Group g in _groups)
                        _masterDS.Tables[MobileConfig.Group.TableName].Rows.Add(g.Data);
                }

                if (MobileConfig.Config.TableSpec() != null)
                {
                    _masterDS.Tables.Add(MobileConfig.Config.TableSpec());
                    
                    //need checks on these tables, but they get called later on in for-loops so they have to be in place
                    _masterDS.Tables.Add(MobileConfig.Question.TableSpec());
                    _masterDS.Tables.Add(MobileConfig.Value.TableSpec());
					_masterDS.Tables.Add(MobileConfig.RegValue.TableSpec());

                    foreach (MobileConfig.Config c in _configs)
                    {
                        _masterDS.Tables[MobileConfig.Config.TableName].Rows.Add(c.Data);
                        
                        if(c.Questions != null)
                            foreach (MobileConfig.Question q in c.Questions)
                            {
                                _masterDS.Tables[MobileConfig.Question.TableName].Rows.Add(q.Data);

                                if(q.Values != null)
                                    foreach (MobileConfig.Value v in q.Values)
                                    {
                                        _masterDS.Tables[MobileConfig.Value.TableName].Rows.Add(v.Data);
                                    }

								if (q.RegValues != null)
									foreach (MobileConfig.RegValue rv in q.RegValues)
										_masterDS.Tables[MobileConfig.RegValue.TableName].Rows.Add(rv.Data);

                            }
                    }
                }
            
                _masterDS.WriteXml("mobileconfig.xml");
            }
        }

        public void BindTree()
        {
            ConfigTree.Nodes.Clear();
            foreach (MobileConfig.Group g in _groups)
            {
                GroupNode node = new GroupNode();
                node.Name = g.ID;
                node.Text = g.Name;
                node.ImageKey = "Folder";                   
                ConfigTree.Nodes.Add(node);                
            }

            foreach (MobileConfig.Config c in _configs)
            {
                TreeNode node = new TreeNode();
                node.Name = c.ID;
                node.Text = c.Name;
                node.ImageKey = "Config";
                node.SelectedImageKey = "Config";
                if (c.GroupID == "")
                    ConfigTree.Nodes.Add(node);
                else
                {
                    TreeNode[] gNode = ConfigTree.Nodes.Find(c.GroupID, false);                    
                    if (gNode.Length > 0 && gNode[0] != null)
                        gNode[0].Nodes.Add(node);
                    else
                    {
                        c.GroupID = "";
                        ConfigTree.Nodes.Add(node);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MobileConfig.Config c = new MobileConfig.Config();

            Config cform = new Config(c);
            cform.ShowDialog();

            if (cform.Value != null)
            {
                _configs.Add(cform.Value);
                BindTree();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigTree.SelectedNode is GroupNode)
            {
                for (int i = 0; i < _groups.Count; i++)
                    if (_groups[i].ID == ConfigTree.SelectedNode.Name)
                    {
                        _groups.RemoveAt(i);
                        break;
                    }
            }
            else
            {
                for (int i = 0; i < _configs.Count; i++)
                    if (_configs[i].ID == ConfigTree.SelectedNode.Name)
                    {
                        _configs.RemoveAt(i);
                        break;
                    }
            }
            BindTree();
        }

        private void addConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MobileConfig.Config c = new MobileConfig.Config();

            if (ConfigTree.SelectedNode != null && ConfigTree.SelectedNode is GroupNode)
            {
                c.GroupID = ConfigTree.SelectedNode.Name;
            }

            Config cform = new Config(c);
            cform.ShowDialog();

            if (cform.Value != null)
            {
                _configs.Add(cform.Value);
                BindTree();
            }
        }

        private void ConfigTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ConfigTree.SelectedNode is GroupNode)
                contextMenuStrip1.Items[0].Enabled = true;
            else
                contextMenuStrip1.Items[0].Enabled = false;
        }

        private void ConfigTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (ConfigTree.SelectedNode == null) return;
            if (ConfigTree.SelectedNode is GroupNode)
            {
                foreach (MobileConfig.Group g in _groups)
                {
                    if (g.ID == ConfigTree.SelectedNode.Name)
                    {
                        InputBox ib = new InputBox("Change Group Name", "Group Name");
                        ib.Value = g.Name;
                        ib.ShowDialog();                        
                        if (ib.Value != "")
                            g.Name = ib.Value;   
                        break;
                    }
                }
            }
            else
            {
                MobileConfig.Config changedConfig = null;
                MobileConfig.Config selectedConfig = null;
                foreach(MobileConfig.Config c in _configs)
                {
                    if(c.ID == ConfigTree.SelectedNode.Name)
                    {
                        selectedConfig = c;
                        Config cForm = new Config(c);
                        cForm.ShowDialog();
                        if (cForm.Value != null)
                            changedConfig = cForm.Value;
                        break;
                    }
                }
                if (changedConfig != null && selectedConfig != null)
                    selectedConfig = changedConfig;
            }
            BindTree();
        }
    }
}