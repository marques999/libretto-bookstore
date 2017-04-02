using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class InviteForm
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
            if (disposing && components != null)
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
            ListViewGroup listViewGroup1 = new ListViewGroup("Public", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Private", HorizontalAlignment.Left);
            label1 = new Label();
            panel1 = new Panel();
            roomsList = new ListView();
            buttonCancel = new Button();
            buttonInvite = new Button();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(roomsList, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(8, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.90393F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.09607F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(344, 264);
            tableLayoutPanel1.TabIndex = 0;
            //
            // roomsList
            //
            roomsList.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            roomsList.Dock = DockStyle.Fill;
            roomsList.FullRowSelect = true;
            roomsList.GridLines = true;
            listViewGroup1.Header = "Public";
            listViewGroup1.Name = "Public";
            listViewGroup2.Header = "Private";
            listViewGroup2.Name = "Private";
            roomsList.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2 });
            roomsList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            roomsList.Location = new Point(3, 44);
            roomsList.MultiSelect = false;
            roomsList.Name = "roomsList";
            roomsList.Size = new Size(338, 182);
            roomsList.TabIndex = 1;
            roomsList.UseCompatibleStateImageBehavior = false;
            roomsList.View = View.Details;
            roomsList.DoubleClick += new EventHandler(roomsList_DoubleClick);
            //
            // columnHeader3
            //
            columnHeader3.Text = "Name";
            columnHeader3.Width = 225;
            //
            // columnHeader4
            //
            columnHeader4.Text = "Capacity";
            columnHeader4.Width = 90;
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
            label1.Size = new Size(340, 37);
            label1.TabIndex = 7;
            label1.Text = "Rooms";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panel1
            //
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(buttonInvite);
            panel1.Controls.Add(buttonCancel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 29);
            panel1.TabIndex = 6;
            //
            // buttonInvite
            //
            buttonInvite.Dock = DockStyle.Fill;
            buttonInvite.Location = new Point(0, 0);
            buttonInvite.Name = "buttonInvite";
            buttonInvite.Size = new Size(242, 29);
            buttonInvite.TabIndex = 2;
            buttonInvite.Text = "Invite";
            buttonInvite.UseVisualStyleBackColor = true;
            buttonInvite.Click += new EventHandler(buttonInvite_Click);
            //
            // buttonCancel
            //
            buttonCancel.Dock = DockStyle.Right;
            buttonCancel.Location = new Point(242, 0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 29);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += new EventHandler(buttonCancel_Click);
            //
            // InviteForm
            //
            AcceptButton = buttonInvite;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(360, 280);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InviteForm";
            Padding = new Padding(8);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Invite";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label label1;
        private Panel panel1;
        private ListView roomsList;
        private Button buttonCancel;
        private Button buttonInvite;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TableLayoutPanel tableLayoutPanel1;
    }
}