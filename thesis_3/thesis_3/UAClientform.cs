using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace thesis_3
{
    public partial class UAClientForm : Form
    {
        private Session msession;
        private UAClientHelper myClientHelper;
        private EndpointDescription mSlelectedEndPoint;
        private UAClientCertForm myCertform;
        private ReferenceDescriptionCollection myReferenceDescriptionCollection;
        

        public UAClientForm()
        {
            InitializeComponent();
            myClientHelper = new UAClientHelper();
            Browse_tp.Enabled = false;
            ReadWrite_tp.Enabled = false;




        }

        #region User Interaction handler

        private void GetEndPoint_bt_Click(object sender, EventArgs e)
        {
            bool foundEP = false;
            endpoints_lv.Items.Clear();
            string discoveryURL = discoveryURL_tb.Text;
            try
            {
                ApplicationDescriptionCollection servers = myClientHelper.FindServers(discoveryURL);
                foreach (ApplicationDescription ad in servers)
                {
                    foreach (string url in ad.DiscoveryUrls)
                    {
                        try
                        {
                            EndpointDescriptionCollection endpoints = myClientHelper.Endpoint(url);
                            Console.WriteLine("0");
                            foundEP = foundEP || endpoints.Count > 0;
                            foreach (EndpointDescription ep in endpoints)
                            {
                                // delete header
                                string securityPolicy = ep.SecurityPolicyUri.Remove(0, 42);
                                string key = "[" + ad.ApplicationName + "]" + "[" + ep.SecurityMode + "]"+"["+ securityPolicy +"]" + "[" + ep.EndpointUrl + "]";
                                if (!endpoints_lv.Items.ContainsKey(key))
                                {
                                    endpoints_lv.Items.Add(key, key, 0).Tag = ep;
                                }
                            }
                        }
                        catch (ServiceResultException sre)
                        {
                            // cannot Reach the endpoint
                            MessageBox.Show(sre.Message, "Error");
                            Console.WriteLine("0.5");
                        }
                        if (!foundEP)
                        {
                            MessageBox.Show("Cannot find any EndPoints", "Error");
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                myCertform = null;
                MessageBox.Show(ex.Message, "Error");
            }


        }
        private void Connect_bt_Click(object sender, EventArgs e)
        {
            
            if (msession != null && !msession.Disposed)
            {
                
                myClientHelper.Disconnect();
                msession = myClientHelper.Session;
                

            }
            else
            {
                try
                {
                    Console.WriteLine("1");
                    // mandatory event 
                    myClientHelper.Alivenotification += new KeepAliveEventHandler(Noti_keepALive);
                    Console.WriteLine("2");
                    myClientHelper.certificateValidationEventHandler += new CertificateValidationEventHandler(noti_servercert);
                    Console.WriteLine("3");
                    if(mSlelectedEndPoint != null)
                    {
                        Console.WriteLine("4");
                        // call connect
                        myClientHelper.Connect(mSlelectedEndPoint, userPw_rdbtn.Checked, Username_tbx.Text, password_tbx.Text).Wait();
                        Console.WriteLine("5");
                        msession = myClientHelper.Session;
                        // UI setting 
                        Connect_bt.Text = "Disconnect from the selected endpoint";
                        Browse_tp.Enabled = true;
                        ReadWrite_tp.Enabled = true;                        


                    }
                    else
                    {
                        MessageBox.Show("Plese connect to endpoint first", "Error");
                        return;

                    }
                }
                catch(Exception ex)
                {
                    myCertform = null;
                    MessageBox.Show(ex.InnerException.Message, "Error");
                }
            }
            
        }
        
        

        private void discoveryURL_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                GetEndPoint_bt_Click(this, new EventArgs());
            }
        }

        private void endpoints_lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            mSlelectedEndPoint = (EndpointDescription)e.Item.Tag;
        }

        private void anonymous_rdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (anonymous_rdBtn.Checked)
            {
                Username_tbx.Enabled = false;
                password_tbx.Enabled = false;
            }
        }

        private void userPw_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (userPw_rdbtn.Checked)
            {
                Username_tbx.Enabled = true;
                password_tbx.Enabled = true;

            }
        }


        private void NodeTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DesCriptionGridView1.Rows.Clear();
            try
            {
                ReferenceDescription refDes = (ReferenceDescription)e.Node.Tag;
                Node node = myClientHelper.ReadNode(refDes.NodeId.ToString());
                VariableNode variableNode = new VariableNode();
                string[] row1 = new string[] { "Node ID", refDes.NodeId.ToString() };
                string[] row2 = new string[] { "NameSpace Index", refDes.NodeId.NamespaceIndex.ToString() };
                string[] row3 = new string[] { "Identifier Type", refDes.NodeId.IdType.ToString() };
                string[] row4 = new string[] { "Identifier", refDes.NodeId.Identifier.ToString() };
                string[] row5 = new string[] { "Browse Name", refDes.BrowseName.ToString() };
                string[] row6 = new string[] { "Display Name", refDes.DisplayName.ToString() };
                string[] row7 = new string[] { "Node Class", refDes.NodeClass.ToString() };
                string[] row8 = new string[] { "Discription", "null" };
                try { row8 = new string[] { "Discription", node.Description.ToString() }; }
                catch { row8 = new string[] { "Description", "null" }; }
                string typeDefinition = "";
                if ((NodeId) refDes.TypeDefinition.NamespaceIndex == 0)
                {
                    typeDefinition = refDes.TypeDefinition.ToString();
                }
                else
                {
                    typeDefinition = "Struct/UDT:" + refDes.TypeDefinition.ToString();
                }
                string[] row9 = new string[] { "Type Definition", typeDefinition };
                if (node.NodeClass == NodeClass.Variable)
                {
                    variableNode = (VariableNode)node.DataLock;
                    List<NodeId> nodeIds = new List<NodeId>();
                    IList<string> displayNames = new List<string>();
                    IList<ServiceResult> errors = new List<ServiceResult>();
                    NodeId nodeid = new NodeId(variableNode.DataType);
                    nodeIds.Add(nodeid);
                    msession.ReadDisplayName(nodeIds, out displayNames, out errors);
                    string[] row10 = new string[] { "Data Type", displayNames[0] };
                    object[] row = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9 };
                    foreach ( string[] rowArray in row)
                    {
                        DesCriptionGridView1.Rows.Add(rowArray);
                    }
                    
                }
                else
                {
                    object[] row = new object[] { row1, row2, row3, row4, row5, row6, row7, row8 };
                    foreach (string[] rowArray in row)
                    {
                        DesCriptionGridView1.Rows.Add(rowArray);
                    }
                }
                DesCriptionGridView1.ClearSelection();

            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void CopyNode_btn_Click(object sender, EventArgs e)
        {
            if(DesCriptionGridView1.Rows.Count != 0)
            {
                try
                {
                    foreach(DataGridViewRow row in DesCriptionGridView1.Rows)
                    {
                        if(row.Cells[0].Value.Equals("Node ID"))
                        {
                            Clipboard.SetText(row.Cells[1].ToString());
                            break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Plese select the node in the tree view");
            }
        }
        private void NodeTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            ReferenceDescriptionCollection referenceDescriptionsCollection;
            ReferenceDescription refDes = (ReferenceDescription)e.Node.Tag;
            try
            {
                referenceDescriptionsCollection = myClientHelper.BrowseNode(refDes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            foreach(ReferenceDescription tempRefDesc in referenceDescriptionsCollection)
            {
                if (tempRefDesc.ReferenceTypeId != ReferenceTypeIds.HasNotifier)
                {
                    e.Node.Nodes.Add(tempRefDesc.DisplayName.ToString()).Tag = tempRefDesc;
                }
            }
        }
        private void Browse_tp_Enter(object sender, EventArgs e)
        {
            if(myReferenceDescriptionCollection == null)
            {
                try
                {
                    myReferenceDescriptionCollection = myClientHelper.BrowseRoot();
                    foreach(ReferenceDescription refDes in myReferenceDescriptionCollection)
                    {
                        NodeTreeView.Nodes.Add(refDes.DisplayName.ToString()).Tag = refDes;
                        foreach(TreeNode nodes in NodeTreeView.Nodes)
                        {
                            nodes.Nodes.Add("");
                        }
                    }
                }
                catch( Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        #endregion
        #region Client event handler
        private void Noti_keepALive(ISession session, KeepAliveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new KeepAliveEventHandler(Noti_keepALive), session, e);
                return;

            }
            // check event for disscard session
            try
            {
                if (!object.ReferenceEquals(session, msession))
                {
                    return;
                }
                // check the disconnection session
                if (!ServiceResult.IsGood(e.Status))
                {

                    msession.Reconnect();

                }

            }
            catch
            {

                MessageBox.Show("Connect to OPC UA server lost", "Error");
            }
        }

        private void noti_servercert(CertificateValidator certval, CertificateValidationEventArgs e)
        {
            // handle cert evnet 
            // accept cert manually move it to folder 
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CertificateValidationEventHandler(noti_servercert), certval, e);
            }
            try
            {
                // create a cert in store
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                // search for cert in sore
                X509CertificateCollection certificatescol = store.Certificates.Find(X509FindType.FindByThumbprint, e.Certificate.Thumbprint, true);
                store.Close();
                if (certificatescol.Capacity > 0)
                {
                    e.Accept = true;
                }
                else
                {
                    if (!e.Accept & myCertform == null)
                    {
                        myCertform = new UAClientCertForm(e);
                        myCertform.ShowDialog();

                    }
                }
            }
            catch
            {

            }
        }
        #endregion
        #region Private method
        private void ResetUI()
        {

        }


        #endregion


    }
}
