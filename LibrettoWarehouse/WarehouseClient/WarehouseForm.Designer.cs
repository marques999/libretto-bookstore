using System.ComponentModel;
using System.Windows.Forms;

using Libretto.Forms;
using Libretto.Properties;

namespace Libretto
{
    /// <summary>
    ///
    /// </summary>
    internal partial class WarehouseForm
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
            this.customerLayout = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customerNameLabel = new Libretto.Forms.FlatLabel();
            this.customerName = new System.Windows.Forms.ComboBox();
            this.dateFromLabel = new Libretto.Forms.FlatLabel();
            this.dateToLabel = new Libretto.Forms.FlatLabel();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.dateToPicker = new System.Windows.Forms.DateTimePicker();
            this.statusLabel = new Libretto.Forms.FlatLabel();
            this.statusPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkWaiting = new System.Windows.Forms.CheckBox();
            this.checkProcessing = new System.Windows.Forms.CheckBox();
            this.checkDispatched = new System.Windows.Forms.CheckBox();
            this.customerPanel = new System.Windows.Forms.Panel();
            this.customerLabel = new Libretto.Forms.FlatHeader();
            this.transactionsLayout = new System.Windows.Forms.Panel();
            this.transactionList = new System.Windows.Forms.ListView();
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.transactionsPanel = new System.Windows.Forms.Panel();
            this.transactionsLabel = new Libretto.Forms.FlatHeader();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLogout = new Libretto.Forms.FlatButton();
            this.buttonUpdate = new Libretto.Forms.FlatButton();
            this.buttonManage = new Libretto.Forms.FlatButton();
            this.customerLayout.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.customerPanel.SuspendLayout();
            this.transactionsLayout.SuspendLayout();
            this.transactionsPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerLayout
            // 
            this.customerLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.customerLayout.Controls.Add(this.formPanel);
            this.customerLayout.Controls.Add(this.customerPanel);
            this.customerLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.customerLayout.Location = new System.Drawing.Point(0, 0);
            this.customerLayout.Name = "customerLayout";
            this.customerLayout.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.customerLayout.Size = new System.Drawing.Size(704, 96);
            this.customerLayout.TabIndex = 1;
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
            this.formPanel.Controls.Add(this.customerNameLabel, 0, 0);
            this.formPanel.Controls.Add(this.customerName, 1, 0);
            this.formPanel.Controls.Add(this.dateFromLabel, 2, 0);
            this.formPanel.Controls.Add(this.dateToLabel, 2, 1);
            this.formPanel.Controls.Add(this.dateFromPicker, 3, 0);
            this.formPanel.Controls.Add(this.dateToPicker, 3, 1);
            this.formPanel.Controls.Add(this.statusLabel, 0, 1);
            this.formPanel.Controls.Add(this.statusPanel, 1, 1);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(4, 28);
            this.formPanel.Name = "formPanel";
            this.formPanel.RowCount = 2;
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.Size = new System.Drawing.Size(696, 68);
            this.formPanel.TabIndex = 0;
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.BackColor = System.Drawing.Color.Silver;
            this.customerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customerNameLabel.Location = new System.Drawing.Point(1, 1);
            this.customerNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(50, 32);
            this.customerNameLabel.TabIndex = 0;
            this.customerNameLabel.Text = "Title";
            this.customerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerName
            // 
            this.customerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerName.Location = new System.Drawing.Point(58, 7);
            this.customerName.Margin = new System.Windows.Forms.Padding(6);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(259, 21);
            this.customerName.TabIndex = 6;
            this.customerName.SelectedIndexChanged += new System.EventHandler(this.ComboCustomer_SelectedIndexChanged);
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.BackColor = System.Drawing.Color.Silver;
            this.dateFromLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFromLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dateFromLabel.Location = new System.Drawing.Point(324, 1);
            this.dateFromLabel.Margin = new System.Windows.Forms.Padding(0);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(50, 32);
            this.dateFromLabel.TabIndex = 7;
            this.dateFromLabel.Text = "From";
            this.dateFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateToLabel
            // 
            this.dateToLabel.AutoSize = true;
            this.dateToLabel.BackColor = System.Drawing.Color.Silver;
            this.dateToLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateToLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dateToLabel.Location = new System.Drawing.Point(324, 34);
            this.dateToLabel.Margin = new System.Windows.Forms.Padding(0);
            this.dateToLabel.Name = "dateToLabel";
            this.dateToLabel.Size = new System.Drawing.Size(50, 33);
            this.dateToLabel.TabIndex = 8;
            this.dateToLabel.Text = "Until";
            this.dateToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFromPicker
            // 
            this.dateFromPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromPicker.Location = new System.Drawing.Point(381, 7);
            this.dateFromPicker.Margin = new System.Windows.Forms.Padding(6);
            this.dateFromPicker.Name = "dateFromPicker";
            this.dateFromPicker.ShowCheckBox = true;
            this.dateFromPicker.Size = new System.Drawing.Size(308, 20);
            this.dateFromPicker.TabIndex = 10;
            this.dateFromPicker.ValueChanged += new System.EventHandler(this.PickerFrom_ValueChanged);
            // 
            // dateToPicker
            // 
            this.dateToPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToPicker.Location = new System.Drawing.Point(381, 40);
            this.dateToPicker.Margin = new System.Windows.Forms.Padding(6);
            this.dateToPicker.Name = "dateToPicker";
            this.dateToPicker.ShowCheckBox = true;
            this.dateToPicker.Size = new System.Drawing.Size(308, 20);
            this.dateToPicker.TabIndex = 11;
            this.dateToPicker.ValueChanged += new System.EventHandler(this.PickerUntil_ValueChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Silver;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusLabel.Location = new System.Drawing.Point(1, 34);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 33);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusPanel
            // 
            this.statusPanel.Controls.Add(this.checkWaiting);
            this.statusPanel.Controls.Add(this.checkProcessing);
            this.statusPanel.Controls.Add(this.checkDispatched);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(58, 40);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(6);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(259, 21);
            this.statusPanel.TabIndex = 13;
            // 
            // checkWaiting
            // 
            this.checkWaiting.Checked = true;
            this.checkWaiting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkWaiting.Location = new System.Drawing.Point(3, 3);
            this.checkWaiting.Name = "checkWaiting";
            this.checkWaiting.Size = new System.Drawing.Size(62, 17);
            this.checkWaiting.TabIndex = 7;
            this.checkWaiting.Text = "Waiting";
            this.checkWaiting.CheckedChanged += new System.EventHandler(this.CheckWaiting_CheckedChanged);
            // 
            // checkProcessing
            // 
            this.checkProcessing.Checked = true;
            this.checkProcessing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkProcessing.Location = new System.Drawing.Point(71, 3);
            this.checkProcessing.Name = "checkProcessing";
            this.checkProcessing.Size = new System.Drawing.Size(78, 17);
            this.checkProcessing.TabIndex = 8;
            this.checkProcessing.Text = "Processing";
            this.checkProcessing.CheckedChanged += new System.EventHandler(this.CheckProcessing_CheckedChanged);
            // 
            // checkDispatched
            // 
            this.checkDispatched.Checked = true;
            this.checkDispatched.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDispatched.Location = new System.Drawing.Point(155, 3);
            this.checkDispatched.Name = "checkDispatched";
            this.checkDispatched.Size = new System.Drawing.Size(80, 17);
            this.checkDispatched.TabIndex = 9;
            this.checkDispatched.Text = "Dispatched";
            this.checkDispatched.CheckedChanged += new System.EventHandler(this.CheckDispatched_CheckedChanged);
            // 
            // customerPanel
            // 
            this.customerPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customerPanel.Controls.Add(this.customerLabel);
            this.customerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customerPanel.Location = new System.Drawing.Point(4, 4);
            this.customerPanel.Name = "customerPanel";
            this.customerPanel.Size = new System.Drawing.Size(696, 24);
            this.customerPanel.TabIndex = 1;
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.ForeColor = System.Drawing.Color.Silver;
            this.customerLabel.Location = new System.Drawing.Point(0, 0);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(2);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(42, 13);
            this.customerLabel.TabIndex = 0;
            this.customerLabel.Text = "Books";
            this.customerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transactionsLayout
            // 
            this.transactionsLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.transactionsLayout.Controls.Add(this.transactionList);
            this.transactionsLayout.Controls.Add(this.transactionsPanel);
            this.transactionsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsLayout.Location = new System.Drawing.Point(0, 96);
            this.transactionsLayout.Name = "transactionsLayout";
            this.transactionsLayout.Padding = new System.Windows.Forms.Padding(4);
            this.transactionsLayout.Size = new System.Drawing.Size(704, 422);
            this.transactionsLayout.TabIndex = 0;
            // 
            // transactionList
            // 
            this.transactionList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.transactionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnQuantity,
            this.columnTitle,
            this.columnDate,
            this.columnStatus,
            this.columnLast,
            this.columnTotal});
            this.transactionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionList.FullRowSelect = true;
            this.transactionList.GridLines = true;
            this.transactionList.Location = new System.Drawing.Point(4, 28);
            this.transactionList.Name = "transactionList";
            this.transactionList.Size = new System.Drawing.Size(696, 390);
            this.transactionList.TabIndex = 12;
            this.transactionList.UseCompatibleStateImageBehavior = false;
            this.transactionList.View = System.Windows.Forms.View.Details;
            this.transactionList.SelectedIndexChanged += new System.EventHandler(this.OrderList_SelectedIndexChanged);
            this.transactionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OrdersList_DoubleClicked);
            // 
            // columnQuantity
            // 
            this.columnQuantity.Text = "Quantity";
            this.columnQuantity.Width = 64;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            this.columnTitle.Width = 240;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Order Date";
            this.columnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDate.Width = 100;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStatus.Width = 96;
            // 
            // columnLast
            // 
            this.columnLast.Text = "Last Update";
            this.columnLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLast.Width = 100;
            // 
            // columnTotal
            // 
            this.columnTotal.Text = "Total";
            this.columnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnTotal.Width = 80;
            // 
            // transactionsPanel
            // 
            this.transactionsPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.transactionsPanel.Controls.Add(this.transactionsLabel);
            this.transactionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionsPanel.Location = new System.Drawing.Point(4, 4);
            this.transactionsPanel.Name = "transactionsPanel";
            this.transactionsPanel.Size = new System.Drawing.Size(696, 24);
            this.transactionsPanel.TabIndex = 13;
            // 
            // transactionsLabel
            // 
            this.transactionsLabel.AutoSize = true;
            this.transactionsLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.transactionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsLabel.ForeColor = System.Drawing.Color.Silver;
            this.transactionsLabel.Location = new System.Drawing.Point(0, 0);
            this.transactionsLabel.Margin = new System.Windows.Forms.Padding(2);
            this.transactionsLabel.Name = "transactionsLabel";
            this.transactionsLabel.Size = new System.Drawing.Size(44, 13);
            this.transactionsLabel.TabIndex = 0;
            this.transactionsLabel.Text = "Orders";
            this.transactionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.Gray;
            this.buttonPanel.Controls.Add(this.buttonLayout);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 518);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(4);
            this.buttonPanel.Size = new System.Drawing.Size(704, 41);
            this.buttonPanel.TabIndex = 2;
            // 
            // buttonLayout
            // 
            this.buttonLayout.Controls.Add(this.buttonLogout);
            this.buttonLayout.Controls.Add(this.buttonUpdate);
            this.buttonLayout.Controls.Add(this.buttonManage);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonLayout.Location = new System.Drawing.Point(4, 4);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Size = new System.Drawing.Size(696, 33);
            this.buttonLayout.TabIndex = 0;
            // 
            // buttonLogout
            // 
            this.buttonLogout.AutoSize = true;
            this.buttonLogout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(591, 3);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(105, 28);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AutoSize = true;
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Location = new System.Drawing.Point(467, 3);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(120, 28);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update Order";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonManage
            // 
            this.buttonManage.AutoSize = true;
            this.buttonManage.BackColor = System.Drawing.SystemColors.Control;
            this.buttonManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManage.Location = new System.Drawing.Point(345, 3);
            this.buttonManage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonManage.Name = "buttonManage";
            this.buttonManage.Size = new System.Drawing.Size(120, 28);
            this.buttonManage.TabIndex = 4;
            this.buttonManage.Text = "Manage Books";
            this.buttonManage.UseVisualStyleBackColor = false;
            this.buttonManage.Click += new System.EventHandler(this.ButtonManage_Click);
            // 
            // WarehouseForm
            // 
            this.AcceptButton = this.buttonUpdate;
            this.ClientSize = new System.Drawing.Size(704, 559);
            this.Controls.Add(this.transactionsLayout);
            this.Controls.Add(this.customerLayout);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Libretto.Properties.Resources.librettoIcon;
            this.MaximizeBox = false;
            this.Name = "WarehouseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libretto Warehouse";
            this.Load += new System.EventHandler(this.WarehouseClient_Load);
            this.customerLayout.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.customerPanel.ResumeLayout(false);
            this.customerPanel.PerformLayout();
            this.transactionsLayout.ResumeLayout(false);
            this.transactionsPanel.ResumeLayout(false);
            this.transactionsPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonLayout.ResumeLayout(false);
            this.buttonLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel customerLayout;
        private Panel customerPanel;
        private FlatHeader customerLabel;
        private FlatLabel statusLabel;
        private ComboBox customerName;
        private FlatLabel customerNameLabel;
        private TableLayoutPanel formPanel;
        private FlatLabel dateToLabel;
        private FlatLabel dateFromLabel;
        private DateTimePicker dateFromPicker;
        private DateTimePicker dateToPicker;
        private Panel transactionsLayout;
        private Panel transactionsPanel;
        private FlatHeader transactionsLabel;
        private ColumnHeader columnDate;
        private ColumnHeader columnTitle;
        private ColumnHeader columnLast;
        private ListView transactionList;
        private ColumnHeader columnQuantity;
        private ColumnHeader columnTotal;
        private ColumnHeader columnStatus;
        private FlowLayoutPanel statusPanel;
        private CheckBox checkWaiting;
        private CheckBox checkProcessing;
        private CheckBox checkDispatched;
        private Panel buttonPanel;
        private FlowLayoutPanel buttonLayout;
        private FlatButton buttonManage;
        private FlatButton buttonLogout;
        private FlatButton buttonUpdate;
    }
}