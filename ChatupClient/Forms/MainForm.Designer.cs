using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class MainForm
    {
        /// <summary>
        /// 
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup3 = new ListViewGroup("Public", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("Private", HorizontalAlignment.Left);
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            buttonMessage = new Button();
            buttonInvite = new Button();
            roomsList = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            usersList = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            buttonJoin = new Button();
            buttonDelete = new Button();
            buttonNew = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelUser = new Label();
            buttonLogout = new Button();
            ((ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new Size(564, 381);
            splitContainer1.SplitterDistance = 326;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 2);
            tableLayoutPanel1.Controls.Add(roomsList, 0, 1);
            tableLayoutPanel1.Controls.Add(usersList, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85.71429F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(564, 326);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(285, 294);
            panel2.Name = "panel2";
            panel2.Size = new Size(276, 29);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonMessage);
            panel3.Controls.Add(buttonInvite);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(276, 29);
            panel3.TabIndex = 0;
            // 
            // buttonMessage
            // 
            buttonMessage.Dock = DockStyle.Fill;
            buttonMessage.Location = new Point(75, 0);
            buttonMessage.Name = "buttonMessage";
            buttonMessage.Size = new Size(201, 29);
            buttonMessage.TabIndex = 12;
            buttonMessage.Text = "Private Message";
            buttonMessage.UseVisualStyleBackColor = true;
            buttonMessage.Click += new EventHandler(buttonMessage_Click);
            // 
            // buttonInvite
            // 
            buttonInvite.Dock = DockStyle.Left;
            buttonInvite.Location = new Point(0, 0);
            buttonInvite.Name = "buttonInvite";
            buttonInvite.Size = new Size(75, 29);
            buttonInvite.TabIndex = 11;
            buttonInvite.Text = "Invite";
            buttonInvite.UseVisualStyleBackColor = true;
            buttonInvite.Click += new EventHandler(buttonInvite_Click);
            // 
            // roomsList
            // 
            roomsList.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            roomsList.Dock = DockStyle.Fill;
            roomsList.FullRowSelect = true;
            roomsList.GridLines = true;
            listViewGroup3.Header = "Public";
            listViewGroup3.Name = "Public";
            listViewGroup4.Header = "Private";
            listViewGroup4.Name = "Private";
            roomsList.Groups.AddRange(new ListViewGroup[] { listViewGroup3, listViewGroup4 });
            roomsList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            roomsList.LabelWrap = false;
            roomsList.Location = new Point(3, 44);
            roomsList.MultiSelect = false;
            roomsList.Name = "roomsList";
            roomsList.Size = new Size(276, 244);
            roomsList.TabIndex = 4;
            roomsList.UseCompatibleStateImageBehavior = false;
            roomsList.View = View.Details;
            roomsList.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
            roomsList.MouseDoubleClick += new MouseEventHandler(roomsList_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Name";
            columnHeader3.Width = 194;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Capacity";
            columnHeader4.Width = 78;
            // 
            // usersList
            // 
            usersList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            usersList.Dock = DockStyle.Fill;
            usersList.FullRowSelect = true;
            usersList.GridLines = true;
            usersList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            usersList.LabelWrap = false;
            usersList.Location = new Point(285, 44);
            usersList.MultiSelect = false;
            usersList.Name = "usersList";
            usersList.ShowGroups = false;
            usersList.Size = new Size(276, 244);
            usersList.TabIndex = 3;
            usersList.UseCompatibleStateImageBehavior = false;
            usersList.View = View.Details;
            usersList.SelectedIndexChanged += new EventHandler(listView2_SelectedIndexChanged);
            usersList.MouseDoubleClick += new MouseEventHandler(usersList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Username";
            columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Status";
            columnHeader2.Width = 177;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(2, 2);
            label1.Margin = new Padding(2);
            label1.Name = "label1";
            label1.Size = new Size(278, 37);
            label1.TabIndex = 0;
            label1.Text = "Rooms";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(284, 2);
            label2.Margin = new Padding(2);
            label2.Name = "label2";
            label2.Size = new Size(278, 37);
            label2.TabIndex = 1;
            label2.Text = "Peers";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonJoin);
            panel1.Controls.Add(buttonDelete);
            panel1.Controls.Add(buttonNew);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 294);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 29);
            panel1.TabIndex = 5;
            // 
            // buttonJoin
            // 
            buttonJoin.Dock = DockStyle.Fill;
            buttonJoin.Location = new Point(75, 0);
            buttonJoin.Name = "buttonJoin";
            buttonJoin.Size = new Size(126, 29);
            buttonJoin.TabIndex = 3;
            buttonJoin.Text = "Join";
            buttonJoin.UseVisualStyleBackColor = true;
            buttonJoin.Click += new EventHandler(buttonJoin_Click);
            // 
            // buttonDelete
            // 
            buttonDelete.Dock = DockStyle.Right;
            buttonDelete.Location = new Point(201, 0);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 29);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += new EventHandler(buttonDelete_Click);
            // 
            // buttonNew
            // 
            buttonNew.Dock = DockStyle.Left;
            buttonNew.Location = new Point(0, 0);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 29);
            buttonNew.TabIndex = 0;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += new EventHandler(buttonNew_Click);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(labelUser, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonLogout, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel2.Size = new Size(564, 51);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.BackColor = SystemColors.ControlDarkDark;
            labelUser.Dock = DockStyle.Fill;
            labelUser.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUser.ForeColor = Color.Silver;
            labelUser.Location = new Point(2, 2);
            labelUser.Margin = new Padding(2);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(278, 47);
            labelUser.TabIndex = 1;
            labelUser.Text = "User: guest";
            labelUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            buttonLogout.Dock = DockStyle.Fill;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Location = new Point(285, 3);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(276, 45);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Log Out";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += new EventHandler(buttonLogout_Click);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(564, 381);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = ((Icon)(resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chatup.NET";
            Load += new EventHandler(MainForm_Load);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ListView roomsList;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ListView usersList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelUser;
        private Button buttonLogout;
        private Panel panel2;
        private Panel panel1;
        private Button buttonNew;
        private Button buttonDelete;
        private Button buttonJoin;
        private Panel panel3;
        private Button buttonMessage;
        private Button buttonInvite;
    }
}