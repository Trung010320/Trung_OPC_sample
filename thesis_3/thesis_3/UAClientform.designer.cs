
namespace thesis_3
{
    partial class UAClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OPCTabControl = new System.Windows.Forms.TabControl();
            this.Connect_tp = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Connect_bt = new System.Windows.Forms.Button();
            this.password_tbx = new System.Windows.Forms.TextBox();
            this.Username_tbx = new System.Windows.Forms.TextBox();
            this.userPw_rdbtn = new System.Windows.Forms.RadioButton();
            this.anonymous_rdBtn = new System.Windows.Forms.RadioButton();
            this.endpoints_lv = new System.Windows.Forms.ListView();
            this.Endpoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GetEndPoint_bt = new System.Windows.Forms.Button();
            this.discoveryURL_tb = new System.Windows.Forms.TextBox();
            this.Browse_tp = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.CopyNode_btn = new System.Windows.Forms.Button();
            this.DesCriptionGridView1 = new System.Windows.Forms.DataGridView();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeTreeView = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.ReadWrite_tp = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WriteValue_tbx = new System.Windows.Forms.TextBox();
            this.WriteID_tbx = new System.Windows.Forms.TextBox();
            this.ReadValue_tbx = new System.Windows.Forms.TextBox();
            this.ReadID_tbx = new System.Windows.Forms.TextBox();
            this.Writebtn = new System.Windows.Forms.Button();
            this.Readbtn = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.OPCTabControl.SuspendLayout();
            this.Connect_tp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Browse_tp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DesCriptionGridView1)).BeginInit();
            this.ReadWrite_tp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OPCTabControl
            // 
            this.OPCTabControl.Controls.Add(this.Connect_tp);
            this.OPCTabControl.Controls.Add(this.Browse_tp);
            this.OPCTabControl.Controls.Add(this.ReadWrite_tp);
            this.OPCTabControl.Controls.Add(this.tabPage4);
            this.OPCTabControl.Location = new System.Drawing.Point(1, 0);
            this.OPCTabControl.Name = "OPCTabControl";
            this.OPCTabControl.SelectedIndex = 0;
            this.OPCTabControl.Size = new System.Drawing.Size(969, 560);
            this.OPCTabControl.TabIndex = 0;
            // 
            // Connect_tp
            // 
            this.Connect_tp.Controls.Add(this.label1);
            this.Connect_tp.Controls.Add(this.groupBox1);
            this.Connect_tp.Controls.Add(this.endpoints_lv);
            this.Connect_tp.Controls.Add(this.GetEndPoint_bt);
            this.Connect_tp.Controls.Add(this.discoveryURL_tb);
            this.Connect_tp.Location = new System.Drawing.Point(4, 25);
            this.Connect_tp.Name = "Connect_tp";
            this.Connect_tp.Padding = new System.Windows.Forms.Padding(3);
            this.Connect_tp.Size = new System.Drawing.Size(961, 531);
            this.Connect_tp.TabIndex = 0;
            this.Connect_tp.Text = "Connect";
            this.Connect_tp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Get all avaliable EndPoint of server\'s URL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Connect_bt);
            this.groupBox1.Controls.Add(this.password_tbx);
            this.groupBox1.Controls.Add(this.Username_tbx);
            this.groupBox1.Controls.Add(this.userPw_rdbtn);
            this.groupBox1.Controls.Add(this.anonymous_rdBtn);
            this.groupBox1.Location = new System.Drawing.Point(8, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Authentication";
            // 
            // Connect_bt
            // 
            this.Connect_bt.Location = new System.Drawing.Point(6, 179);
            this.Connect_bt.Name = "Connect_bt";
            this.Connect_bt.Size = new System.Drawing.Size(291, 23);
            this.Connect_bt.TabIndex = 2;
            this.Connect_bt.Text = "Connect to selected EndPoint";
            this.Connect_bt.UseVisualStyleBackColor = true;
            this.Connect_bt.Click += new System.EventHandler(this.Connect_bt_Click);
            // 
            // password_tbx
            // 
            this.password_tbx.Enabled = false;
            this.password_tbx.Location = new System.Drawing.Point(6, 134);
            this.password_tbx.Name = "password_tbx";
            this.password_tbx.Size = new System.Drawing.Size(291, 22);
            this.password_tbx.TabIndex = 15;
            this.password_tbx.Text = "Password";
            this.password_tbx.UseSystemPasswordChar = true;
            // 
            // Username_tbx
            // 
            this.Username_tbx.Enabled = false;
            this.Username_tbx.Location = new System.Drawing.Point(6, 96);
            this.Username_tbx.Name = "Username_tbx";
            this.Username_tbx.Size = new System.Drawing.Size(291, 22);
            this.Username_tbx.TabIndex = 15;
            this.Username_tbx.Text = "Username";
            // 
            // userPw_rdbtn
            // 
            this.userPw_rdbtn.AutoSize = true;
            this.userPw_rdbtn.Location = new System.Drawing.Point(6, 58);
            this.userPw_rdbtn.Name = "userPw_rdbtn";
            this.userPw_rdbtn.Size = new System.Drawing.Size(159, 21);
            this.userPw_rdbtn.TabIndex = 0;
            this.userPw_rdbtn.Text = "Username/Password";
            this.userPw_rdbtn.UseVisualStyleBackColor = true;
            this.userPw_rdbtn.CheckedChanged += new System.EventHandler(this.userPw_rdbtn_CheckedChanged);
            // 
            // anonymous_rdBtn
            // 
            this.anonymous_rdBtn.AutoSize = true;
            this.anonymous_rdBtn.Checked = true;
            this.anonymous_rdBtn.Location = new System.Drawing.Point(7, 31);
            this.anonymous_rdBtn.Name = "anonymous_rdBtn";
            this.anonymous_rdBtn.Size = new System.Drawing.Size(103, 21);
            this.anonymous_rdBtn.TabIndex = 0;
            this.anonymous_rdBtn.TabStop = true;
            this.anonymous_rdBtn.Text = "Anonymous";
            this.anonymous_rdBtn.UseVisualStyleBackColor = true;
            this.anonymous_rdBtn.CheckedChanged += new System.EventHandler(this.anonymous_rdBtn_CheckedChanged);
            // 
            // endpoints_lv
            // 
            this.endpoints_lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endpoints_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Endpoint});
            this.endpoints_lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.endpoints_lv.HideSelection = false;
            this.endpoints_lv.Location = new System.Drawing.Point(4, 62);
            this.endpoints_lv.Margin = new System.Windows.Forms.Padding(4);
            this.endpoints_lv.MultiSelect = false;
            this.endpoints_lv.Name = "endpoints_lv";
            this.endpoints_lv.Size = new System.Drawing.Size(950, 221);
            this.endpoints_lv.TabIndex = 4;
            this.endpoints_lv.UseCompatibleStateImageBehavior = false;
            this.endpoints_lv.View = System.Windows.Forms.View.Details;
            this.endpoints_lv.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.endpoints_lv_ItemSelectionChanged);
            // 
            // Endpoint
            // 
            this.Endpoint.Text = "Endpoints";
            this.Endpoint.Width = 700;
            // 
            // GetEndPoint_bt
            // 
            this.GetEndPoint_bt.Location = new System.Drawing.Point(764, 33);
            this.GetEndPoint_bt.Name = "GetEndPoint_bt";
            this.GetEndPoint_bt.Size = new System.Drawing.Size(166, 23);
            this.GetEndPoint_bt.TabIndex = 1;
            this.GetEndPoint_bt.Text = "Get EndPoint";
            this.GetEndPoint_bt.UseVisualStyleBackColor = true;
            this.GetEndPoint_bt.Click += new System.EventHandler(this.GetEndPoint_bt_Click);
            // 
            // discoveryURL_tb
            // 
            this.discoveryURL_tb.Location = new System.Drawing.Point(5, 33);
            this.discoveryURL_tb.Name = "discoveryURL_tb";
            this.discoveryURL_tb.Size = new System.Drawing.Size(739, 22);
            this.discoveryURL_tb.TabIndex = 11;
            this.discoveryURL_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.discoveryURL_tb_KeyDown);
            // 
            // Browse_tp
            // 
            this.Browse_tp.Controls.Add(this.label3);
            this.Browse_tp.Controls.Add(this.CopyNode_btn);
            this.Browse_tp.Controls.Add(this.DesCriptionGridView1);
            this.Browse_tp.Controls.Add(this.NodeTreeView);
            this.Browse_tp.Controls.Add(this.label2);
            this.Browse_tp.Location = new System.Drawing.Point(4, 25);
            this.Browse_tp.Name = "Browse_tp";
            this.Browse_tp.Padding = new System.Windows.Forms.Padding(3);
            this.Browse_tp.Size = new System.Drawing.Size(961, 531);
            this.Browse_tp.TabIndex = 1;
            this.Browse_tp.Text = "Browse Node";
            this.Browse_tp.UseVisualStyleBackColor = true;
            this.Browse_tp.Enter += new System.EventHandler(this.Browse_tp_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(453, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select Node\'s Information";
            // 
            // CopyNode_btn
            // 
            this.CopyNode_btn.Location = new System.Drawing.Point(779, 6);
            this.CopyNode_btn.Name = "CopyNode_btn";
            this.CopyNode_btn.Size = new System.Drawing.Size(170, 26);
            this.CopyNode_btn.TabIndex = 3;
            this.CopyNode_btn.Text = "Copy Node ID";
            this.CopyNode_btn.UseVisualStyleBackColor = true;
            this.CopyNode_btn.Click += new System.EventHandler(this.CopyNode_btn_Click);
            // 
            // DesCriptionGridView1
            // 
            this.DesCriptionGridView1.AllowUserToAddRows = false;
            this.DesCriptionGridView1.AllowUserToDeleteRows = false;
            this.DesCriptionGridView1.AllowUserToResizeRows = false;
            this.DesCriptionGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DesCriptionGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DesCriptionGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DesCriptionGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DesCriptionGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Attribute,
            this.Value});
            this.DesCriptionGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DesCriptionGridView1.Location = new System.Drawing.Point(456, 33);
            this.DesCriptionGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.DesCriptionGridView1.Name = "DesCriptionGridView1";
            this.DesCriptionGridView1.ReadOnly = true;
            this.DesCriptionGridView1.RowHeadersVisible = false;
            this.DesCriptionGridView1.RowHeadersWidth = 51;
            this.DesCriptionGridView1.RowTemplate.Height = 24;
            this.DesCriptionGridView1.Size = new System.Drawing.Size(494, 492);
            this.DesCriptionGridView1.TabIndex = 2;
            // 
            // Attribute
            // 
            this.Attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attribute.DefaultCellStyle = dataGridViewCellStyle1;
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.MinimumWidth = 6;
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // NodeTreeView
            // 
            this.NodeTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NodeTreeView.Location = new System.Drawing.Point(4, 33);
            this.NodeTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.NodeTreeView.Name = "NodeTreeView";
            this.NodeTreeView.Size = new System.Drawing.Size(446, 492);
            this.NodeTreeView.TabIndex = 1;
            this.NodeTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.NodeTreeView_BeforeExpand);
            this.NodeTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.NodeTreeView_BeforeSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Browse server\'s nodes";
            // 
            // ReadWrite_tp
            // 
            this.ReadWrite_tp.Controls.Add(this.groupBox2);
            this.ReadWrite_tp.Location = new System.Drawing.Point(4, 25);
            this.ReadWrite_tp.Name = "ReadWrite_tp";
            this.ReadWrite_tp.Padding = new System.Windows.Forms.Padding(3);
            this.ReadWrite_tp.Size = new System.Drawing.Size(961, 531);
            this.ReadWrite_tp.TabIndex = 2;
            this.ReadWrite_tp.Text = "Read/Write";
            this.ReadWrite_tp.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.WriteValue_tbx);
            this.groupBox2.Controls.Add(this.WriteID_tbx);
            this.groupBox2.Controls.Add(this.ReadValue_tbx);
            this.groupBox2.Controls.Add(this.ReadID_tbx);
            this.groupBox2.Controls.Add(this.Writebtn);
            this.groupBox2.Controls.Add(this.Readbtn);
            this.groupBox2.Location = new System.Drawing.Point(0, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(950, 270);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read/Write";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Write value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Read value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Node ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Node ID";
            // 
            // WriteValue_tbx
            // 
            this.WriteValue_tbx.Location = new System.Drawing.Point(397, 123);
            this.WriteValue_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.WriteValue_tbx.Name = "WriteValue_tbx";
            this.WriteValue_tbx.Size = new System.Drawing.Size(507, 22);
            this.WriteValue_tbx.TabIndex = 2;
            // 
            // WriteID_tbx
            // 
            this.WriteID_tbx.Location = new System.Drawing.Point(151, 123);
            this.WriteID_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.WriteID_tbx.Name = "WriteID_tbx";
            this.WriteID_tbx.Size = new System.Drawing.Size(196, 22);
            this.WriteID_tbx.TabIndex = 2;
            // 
            // ReadValue_tbx
            // 
            this.ReadValue_tbx.Location = new System.Drawing.Point(397, 49);
            this.ReadValue_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.ReadValue_tbx.Name = "ReadValue_tbx";
            this.ReadValue_tbx.ReadOnly = true;
            this.ReadValue_tbx.Size = new System.Drawing.Size(507, 22);
            this.ReadValue_tbx.TabIndex = 2;
            // 
            // ReadID_tbx
            // 
            this.ReadID_tbx.Location = new System.Drawing.Point(151, 49);
            this.ReadID_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.ReadID_tbx.Name = "ReadID_tbx";
            this.ReadID_tbx.Size = new System.Drawing.Size(196, 22);
            this.ReadID_tbx.TabIndex = 2;
            // 
            // Writebtn
            // 
            this.Writebtn.Location = new System.Drawing.Point(8, 123);
            this.Writebtn.Margin = new System.Windows.Forms.Padding(4);
            this.Writebtn.Name = "Writebtn";
            this.Writebtn.Size = new System.Drawing.Size(110, 22);
            this.Writebtn.TabIndex = 1;
            this.Writebtn.Text = "Write";
            this.Writebtn.UseVisualStyleBackColor = true;
            // 
            // Readbtn
            // 
            this.Readbtn.Location = new System.Drawing.Point(8, 49);
            this.Readbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Readbtn.Name = "Readbtn";
            this.Readbtn.Size = new System.Drawing.Size(110, 22);
            this.Readbtn.TabIndex = 0;
            this.Readbtn.Text = "Read";
            this.Readbtn.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(961, 531);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // UAClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 555);
            this.Controls.Add(this.OPCTabControl);
            this.Name = "UAClientForm";
            this.Text = "OPC UA Client";
            this.OPCTabControl.ResumeLayout(false);
            this.Connect_tp.ResumeLayout(false);
            this.Connect_tp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Browse_tp.ResumeLayout(false);
            this.Browse_tp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DesCriptionGridView1)).EndInit();
            this.ReadWrite_tp.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl OPCTabControl;
        private System.Windows.Forms.TabPage Connect_tp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Connect_bt;
        private System.Windows.Forms.TextBox password_tbx;
        private System.Windows.Forms.TextBox Username_tbx;
        private System.Windows.Forms.RadioButton userPw_rdbtn;
        private System.Windows.Forms.RadioButton anonymous_rdBtn;
        private System.Windows.Forms.ListView endpoints_lv;
        private System.Windows.Forms.Button GetEndPoint_bt;
        private System.Windows.Forms.TextBox discoveryURL_tb;
        private System.Windows.Forms.TabPage Browse_tp;
        private System.Windows.Forms.TabPage ReadWrite_tp;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ColumnHeader Endpoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CopyNode_btn;
        private System.Windows.Forms.DataGridView DesCriptionGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TreeView NodeTreeView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WriteValue_tbx;
        private System.Windows.Forms.TextBox WriteID_tbx;
        private System.Windows.Forms.TextBox ReadValue_tbx;
        private System.Windows.Forms.TextBox ReadID_tbx;
        private System.Windows.Forms.Button Writebtn;
        private System.Windows.Forms.Button Readbtn;
    }
}

