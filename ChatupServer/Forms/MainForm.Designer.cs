namespace ChatupNET.Forms
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Room 0 (1/3)", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Room 1 (2/3)", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Room 2 (1/3)", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Room 3 (3/3)", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("jabst1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("somouco");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.staticUsers = new System.Windows.Forms.Label();
            this.staticAddress = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.staticStatus = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelAddres = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(8, 8);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(609, 425);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(609, 131);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(601, 105);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.90669F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.09331F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.staticUsers, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.staticAddress, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelStatus, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.staticStatus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonStart, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRestart, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonExit, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelAddres, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(595, 99);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(109, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(373, 33);
            this.label7.TabIndex = 13;
            this.label7.Text = "0 active, 2 inactive";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // staticUsers
            // 
            this.staticUsers.AutoSize = true;
            this.staticUsers.BackColor = System.Drawing.Color.Gainsboro;
            this.staticUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staticUsers.Location = new System.Drawing.Point(4, 70);
            this.staticUsers.Margin = new System.Windows.Forms.Padding(4);
            this.staticUsers.Name = "staticUsers";
            this.staticUsers.Size = new System.Drawing.Size(98, 25);
            this.staticUsers.TabIndex = 11;
            this.staticUsers.Text = "Users";
            this.staticUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // staticAddress
            // 
            this.staticAddress.AutoSize = true;
            this.staticAddress.BackColor = System.Drawing.Color.Gainsboro;
            this.staticAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staticAddress.Location = new System.Drawing.Point(4, 37);
            this.staticAddress.Margin = new System.Windows.Forms.Padding(4);
            this.staticAddress.Name = "staticAddress";
            this.staticAddress.Size = new System.Drawing.Size(98, 25);
            this.staticAddress.TabIndex = 10;
            this.staticAddress.Text = "Address";
            this.staticAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelStatus.Location = new System.Drawing.Point(110, 4);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(371, 25);
            this.labelStatus.TabIndex = 9;
            this.labelStatus.Text = "Running";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // staticStatus
            // 
            this.staticStatus.AutoSize = true;
            this.staticStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.staticStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staticStatus.Location = new System.Drawing.Point(4, 4);
            this.staticStatus.Margin = new System.Windows.Forms.Padding(4);
            this.staticStatus.Name = "staticStatus";
            this.staticStatus.Size = new System.Drawing.Size(98, 25);
            this.staticStatus.TabIndex = 6;
            this.staticStatus.Text = "Status";
            this.staticStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Location = new System.Drawing.Point(488, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(104, 27);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRestart.Enabled = false;
            this.buttonRestart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Location = new System.Drawing.Point(488, 36);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(104, 27);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(488, 69);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(104, 27);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelAddres
            // 
            this.labelAddres.AutoSize = true;
            this.labelAddres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAddres.Location = new System.Drawing.Point(109, 33);
            this.labelAddres.Name = "labelAddres";
            this.labelAddres.Size = new System.Drawing.Size(373, 33);
            this.labelAddres.TabIndex = 12;
            this.labelAddres.Text = "127.0.0.1:12480";
            this.labelAddres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(601, 105);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 99);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(300, 3);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(300, 42);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(609, 290);
            this.splitContainer2.SplitterDistance = 374;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(374, 290);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chatrooms";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(8, 21);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Room 0 (1/3)";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Node1";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Node4";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Room 1 (2/3)";
            treeNode6.Name = "Node2";
            treeNode6.Text = "Node2";
            treeNode7.Name = "Node2";
            treeNode7.Text = "Room 2 (1/3)";
            treeNode8.Name = "Node5";
            treeNode8.Text = "Node5";
            treeNode9.Name = "Node6";
            treeNode9.Text = "Node6";
            treeNode10.Name = "Node7";
            treeNode10.Text = "Node7";
            treeNode11.Name = "Node3";
            treeNode11.Text = "Room 3 (3/3)";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5,
            treeNode7,
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(358, 261);
            this.treeView1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox2.Size = new System.Drawing.Size(231, 290);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Users";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(8, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(215, 261);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Active";
            this.columnHeader2.Width = 79;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 441);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chatup.NET Server";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label staticStatus;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label staticUsers;
        private System.Windows.Forms.Label staticAddress;
        private System.Windows.Forms.Label labelAddres;
        private System.Windows.Forms.Label label7;
    }
}

