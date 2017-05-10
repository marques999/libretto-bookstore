using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Libretto.Forms;
using Libretto.Properties;

namespace Libretto
{
    /// <summary>
    ///
    /// </summary>
    internal partial class WarehouseClient
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
            this.filterLayout = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filterTitleLabel = new Libretto.Forms.FlatLabel();
            this.filterTitle = new System.Windows.Forms.ComboBox();
            this.filterDateFrom = new Libretto.Forms.FlatLabel();
            this.filterDateUntil = new Libretto.Forms.FlatLabel();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.dateUntilPicker = new System.Windows.Forms.DateTimePicker();
            this.filterStatusLabel = new Libretto.Forms.FlatLabel();
            this.filterStatusPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkPending = new System.Windows.Forms.CheckBox();
            this.checkDispatched = new System.Windows.Forms.CheckBox();
            this.checkCancelled = new System.Windows.Forms.CheckBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterLabel = new Libretto.Forms.FlatHeader();
            this.transactionsLayout = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.transactionsPanel = new System.Windows.Forms.Panel();
            this.transactionsLabel = new Libretto.Forms.FlatHeader();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonRefresh = new Libretto.Forms.FlatButton();
            this.buttonLogout = new Libretto.Forms.FlatButton();
            this.buttonSatisfy = new Libretto.Forms.FlatButton();
            this.filterLayout.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.filterStatusPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.transactionsLayout.SuspendLayout();
            this.transactionsPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterLayout
            // 
            this.filterLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.filterLayout.Controls.Add(this.formPanel);
            this.filterLayout.Controls.Add(this.filterPanel);
            this.filterLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterLayout.Location = new System.Drawing.Point(0, 0);
            this.filterLayout.Name = "filterLayout";
            this.filterLayout.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.filterLayout.Size = new System.Drawing.Size(704, 96);
            this.filterLayout.TabIndex = 1;
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.Silver;
            this.formPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.formPanel.ColumnCount = 4;
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.formPanel.Controls.Add(this.filterTitleLabel, 0, 0);
            this.formPanel.Controls.Add(this.filterTitle, 1, 0);
            this.formPanel.Controls.Add(this.filterDateFrom, 2, 0);
            this.formPanel.Controls.Add(this.filterDateUntil, 2, 1);
            this.formPanel.Controls.Add(this.dateFromPicker, 3, 0);
            this.formPanel.Controls.Add(this.dateUntilPicker, 3, 1);
            this.formPanel.Controls.Add(this.filterStatusLabel, 0, 1);
            this.formPanel.Controls.Add(this.filterStatusPanel, 1, 1);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(4, 28);
            this.formPanel.Name = "formPanel";
            this.formPanel.RowCount = 2;
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.Size = new System.Drawing.Size(696, 68);
            this.formPanel.TabIndex = 0;
            // 
            // filterTitleLabel
            // 
            this.filterTitleLabel.AutoSize = true;
            this.filterTitleLabel.BackColor = System.Drawing.Color.Silver;
            this.filterTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filterTitleLabel.Location = new System.Drawing.Point(1, 1);
            this.filterTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.filterTitleLabel.Name = "filterTitleLabel";
            this.filterTitleLabel.Size = new System.Drawing.Size(50, 32);
            this.filterTitleLabel.TabIndex = 0;
            this.filterTitleLabel.Text = "Title";
            this.filterTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filterTitle
            // 
            this.filterTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTitle.Location = new System.Drawing.Point(58, 7);
            this.filterTitle.Margin = new System.Windows.Forms.Padding(6);
            this.filterTitle.Name = "filterTitle";
            this.filterTitle.Size = new System.Drawing.Size(259, 21);
            this.filterTitle.TabIndex = 3;
            this.filterTitle.SelectedIndexChanged += new System.EventHandler(this.ComboCustomer_SelectedIndexChanged);
            // 
            // filterDateFrom
            // 
            this.filterDateFrom.AutoSize = true;
            this.filterDateFrom.BackColor = System.Drawing.Color.Silver;
            this.filterDateFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterDateFrom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filterDateFrom.Location = new System.Drawing.Point(324, 1);
            this.filterDateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.filterDateFrom.Name = "filterDateFrom";
            this.filterDateFrom.Size = new System.Drawing.Size(50, 32);
            this.filterDateFrom.TabIndex = 4;
            this.filterDateFrom.Text = "From";
            this.filterDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filterDateUntil
            // 
            this.filterDateUntil.AutoSize = true;
            this.filterDateUntil.BackColor = System.Drawing.Color.Silver;
            this.filterDateUntil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterDateUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterDateUntil.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filterDateUntil.Location = new System.Drawing.Point(324, 34);
            this.filterDateUntil.Margin = new System.Windows.Forms.Padding(0);
            this.filterDateUntil.Name = "filterDateUntil";
            this.filterDateUntil.Size = new System.Drawing.Size(50, 33);
            this.filterDateUntil.TabIndex = 5;
            this.filterDateUntil.Text = "Until";
            this.filterDateUntil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFromPicker
            // 
            this.dateFromPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromPicker.Location = new System.Drawing.Point(381, 7);
            this.dateFromPicker.Margin = new System.Windows.Forms.Padding(6);
            this.dateFromPicker.Name = "dateFromPicker";
            this.dateFromPicker.ShowCheckBox = true;
            this.dateFromPicker.Size = new System.Drawing.Size(308, 20);
            this.dateFromPicker.TabIndex = 7;
            this.dateFromPicker.ValueChanged += new System.EventHandler(this.DateFromPicker_ValueChanged);
            // 
            // dateUntilPicker
            // 
            this.dateUntilPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateUntilPicker.Location = new System.Drawing.Point(381, 40);
            this.dateUntilPicker.Margin = new System.Windows.Forms.Padding(6);
            this.dateUntilPicker.Name = "dateUntilPicker";
            this.dateUntilPicker.ShowCheckBox = true;
            this.dateUntilPicker.Size = new System.Drawing.Size(308, 20);
            this.dateUntilPicker.TabIndex = 8;
            this.dateUntilPicker.ValueChanged += new System.EventHandler(this.DateToPicker_ValueChanged);
            // 
            // filterStatusLabel
            // 
            this.filterStatusLabel.AutoSize = true;
            this.filterStatusLabel.BackColor = System.Drawing.Color.Silver;
            this.filterStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filterStatusLabel.Location = new System.Drawing.Point(1, 34);
            this.filterStatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.filterStatusLabel.Name = "filterStatusLabel";
            this.filterStatusLabel.Size = new System.Drawing.Size(50, 33);
            this.filterStatusLabel.TabIndex = 9;
            this.filterStatusLabel.Text = "Status";
            this.filterStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filterStatusPanel
            // 
            this.filterStatusPanel.Controls.Add(this.checkPending);
            this.filterStatusPanel.Controls.Add(this.checkDispatched);
            this.filterStatusPanel.Controls.Add(this.checkCancelled);
            this.filterStatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterStatusPanel.Location = new System.Drawing.Point(58, 40);
            this.filterStatusPanel.Margin = new System.Windows.Forms.Padding(6);
            this.filterStatusPanel.Name = "filterStatusPanel";
            this.filterStatusPanel.Size = new System.Drawing.Size(259, 21);
            this.filterStatusPanel.TabIndex = 10;
            // 
            // checkPending
            // 
            this.checkPending.AutoSize = true;
            this.checkPending.Location = new System.Drawing.Point(3, 3);
            this.checkPending.Name = "checkPending";
            this.checkPending.Size = new System.Drawing.Size(65, 17);
            this.checkPending.TabIndex = 4;
            this.checkPending.Text = "Pending";
            this.checkPending.CheckedChanged += new System.EventHandler(this.CheckPending_CheckedChanged);
            // 
            // checkDispatched
            // 
            this.checkDispatched.AutoSize = true;
            this.checkDispatched.Location = new System.Drawing.Point(74, 3);
            this.checkDispatched.Name = "checkDispatched";
            this.checkDispatched.Size = new System.Drawing.Size(80, 17);
            this.checkDispatched.TabIndex = 5;
            this.checkDispatched.Text = "Dispatched";
            this.checkDispatched.CheckedChanged += new System.EventHandler(this.CheckDispatched_CheckedChanged);
            // 
            // checkCancelled
            // 
            this.checkCancelled.AutoSize = true;
            this.checkCancelled.Location = new System.Drawing.Point(160, 3);
            this.checkCancelled.Name = "checkCancelled";
            this.checkCancelled.Size = new System.Drawing.Size(73, 17);
            this.checkCancelled.TabIndex = 6;
            this.checkCancelled.Text = "Cancelled";
            this.checkCancelled.CheckedChanged += new System.EventHandler(this.CheckCancelled_CheckedChanged);
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(4, 4);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(696, 24);
            this.filterPanel.TabIndex = 1;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.ForeColor = System.Drawing.Color.Silver;
            this.filterLabel.Location = new System.Drawing.Point(5, 5);
            this.filterLabel.Margin = new System.Windows.Forms.Padding(2);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(35, 13);
            this.filterLabel.TabIndex = 0;
            this.filterLabel.Text = "Filter";
            this.filterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transactionsLayout
            // 
            this.transactionsLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.transactionsLayout.Controls.Add(this.listView);
            this.transactionsLayout.Controls.Add(this.transactionsPanel);
            this.transactionsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsLayout.Location = new System.Drawing.Point(0, 96);
            this.transactionsLayout.Name = "transactionsLayout";
            this.transactionsLayout.Padding = new System.Windows.Forms.Padding(4);
            this.transactionsLayout.Size = new System.Drawing.Size(704, 427);
            this.transactionsLayout.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDate,
            this.columnTitle,
            this.columnQuantity,
            this.columnTotal,
            this.columnStatus,
            this.columnLast});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(4, 28);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(696, 395);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_DoubleClicked);
            // 
            // columnDate
            // 
            this.columnDate.Text = "Date Issued";
            this.columnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDate.Width = 100;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            this.columnTitle.Width = 268;
            // 
            // columnQuantity
            // 
            this.columnQuantity.Text = "Quantity";
            this.columnQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnQuantity.Width = 64;
            // 
            // columnTotal
            // 
            this.columnTotal.Text = "Total";
            this.columnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnTotal.Width = 80;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStatus.Width = 80;
            // 
            // columnLast
            // 
            this.columnLast.Text = "Last Update";
            this.columnLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLast.Width = 100;
            // 
            // transactionsPanel
            // 
            this.transactionsPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.transactionsPanel.Controls.Add(this.transactionsLabel);
            this.transactionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionsPanel.Location = new System.Drawing.Point(4, 4);
            this.transactionsPanel.Name = "transactionsPanel";
            this.transactionsPanel.Size = new System.Drawing.Size(696, 24);
            this.transactionsPanel.TabIndex = 8;
            // 
            // transactionsLabel
            // 
            this.transactionsLabel.AutoSize = true;
            this.transactionsLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.transactionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsLabel.ForeColor = System.Drawing.Color.Silver;
            this.transactionsLabel.Location = new System.Drawing.Point(5, 5);
            this.transactionsLabel.Margin = new System.Windows.Forms.Padding(2);
            this.transactionsLabel.Name = "transactionsLabel";
            this.transactionsLabel.Size = new System.Drawing.Size(44, 13);
            this.transactionsLabel.TabIndex = 0;
            this.transactionsLabel.Text = "Orders";
            this.transactionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPanel.Controls.Add(this.buttonRefresh);
            this.buttonPanel.Controls.Add(this.buttonLogout);
            this.buttonPanel.Controls.Add(this.buttonSatisfy);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 523);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.buttonPanel.Size = new System.Drawing.Size(704, 36);
            this.buttonPanel.TabIndex = 2;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.AutoSize = true;
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Location = new System.Drawing.Point(144, 0);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(416, 32);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.AutoSize = true;
            this.buttonLogout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(560, 0);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(140, 32);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // buttonSatisfy
            // 
            this.buttonSatisfy.AutoSize = true;
            this.buttonSatisfy.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSatisfy.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSatisfy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSatisfy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSatisfy.Location = new System.Drawing.Point(4, 0);
            this.buttonSatisfy.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.buttonSatisfy.Name = "buttonSatisfy";
            this.buttonSatisfy.Size = new System.Drawing.Size(140, 32);
            this.buttonSatisfy.TabIndex = 0;
            this.buttonSatisfy.Text = "Satisfy Order";
            this.buttonSatisfy.UseVisualStyleBackColor = false;
            this.buttonSatisfy.Click += new System.EventHandler(this.ButtonSatisfy_Click);
            // 
            // WarehouseClient
            // 
            this.AcceptButton = this.buttonSatisfy;
            this.CancelButton = this.buttonLogout;
            this.ClientSize = new System.Drawing.Size(704, 559);
            this.Controls.Add(this.transactionsLayout);
            this.Controls.Add(this.filterLayout);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Libretto.Properties.Resources.librettoIcon;
            this.MaximizeBox = false;
            this.Name = "WarehouseClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libretto Warehouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WarehouseForm_FormClosing);
            this.Load += new System.EventHandler(this.WarehouseClient_Load);
            this.filterLayout.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.filterStatusPanel.ResumeLayout(false);
            this.filterStatusPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.transactionsLayout.ResumeLayout(false);
            this.transactionsPanel.ResumeLayout(false);
            this.transactionsPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel filterLayout;
        private Panel filterPanel;
        private FlatHeader filterLabel;
        private FlatLabel filterStatusLabel;
        private ComboBox filterTitle;
        private FlatLabel filterTitleLabel;
        private TableLayoutPanel formPanel;
        private FlatLabel filterDateUntil;
        private FlatLabel filterDateFrom;
        private DateTimePicker dateFromPicker;
        private DateTimePicker dateUntilPicker;
        private Panel transactionsLayout;
        private Panel transactionsPanel;
        private FlatHeader transactionsLabel;
        private ColumnHeader columnDate;
        private ColumnHeader columnTitle;
        private ColumnHeader columnLast;
        private ListView listView;
        private ColumnHeader columnQuantity;
        private ColumnHeader columnTotal;
        private ColumnHeader columnStatus;
        private FlowLayoutPanel filterStatusPanel;
        private CheckBox checkPending;
        private CheckBox checkDispatched;
        private CheckBox checkCancelled;
        private Panel buttonPanel;
        private FlatButton buttonLogout;
        private FlatButton buttonSatisfy;
        private FlatButton buttonRefresh;
    }
}