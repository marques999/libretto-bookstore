using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Libretto.Properties;

namespace Libretto.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal sealed partial class StoreForm
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
            customerLayout = new Panel();
            formPanel = new TableLayoutPanel();
            customerNameLabel = new FlatLabel();
            customerName = new ComboBox();
            dateFromLabel = new FlatLabel();
            dateToLabel = new FlatLabel();
            dateFromPicker = new DateTimePicker();
            dateToPicker = new DateTimePicker();
            statusLabel = new FlatLabel();
            statusPanel = new FlowLayoutPanel();
            checkWaiting = new CheckBox();
            checkPending = new CheckBox();
            checkDispatched = new CheckBox();
            customerPanel = new Panel();
            customerLabel = new FlatHeader();
            transactionsLayout = new Panel();
            transactionList = new ListView();
            columnDate = new ColumnHeader();
            columnTitle = new ColumnHeader();
            columnCustomer = new ColumnHeader();
            columnQuantity = new ColumnHeader();
            columnTotal = new ColumnHeader();
            columnStatus = new ColumnHeader();
            transactionsPanel = new Panel();
            transactionsLabel = new FlatHeader();
            buttonPanel = new Panel();
            buttonLayout = new FlowLayoutPanel();
            buttonRegister = new FlatButton();
            buttonOrder = new FlatButton();
            buttonCancel = new FlatButton();
            buttonDelete = new FlatButton();
            buttonManage = new FlatButton();
            buttonLogout = new FlatButton();
            customerLayout.SuspendLayout();
            formPanel.SuspendLayout();
            statusPanel.SuspendLayout();
            customerPanel.SuspendLayout();
            transactionsLayout.SuspendLayout();
            transactionsPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            buttonLayout.SuspendLayout();
            SuspendLayout();
            //
            // customerLayout
            //
            customerLayout.BackColor = SystemColors.ControlDark;
            customerLayout.Controls.Add(formPanel);
            customerLayout.Controls.Add(customerPanel);
            customerLayout.Dock = DockStyle.Top;
            customerLayout.Location = new Point(0, 0);
            customerLayout.Name = "customerLayout";
            customerLayout.Padding = new Padding(4, 4, 4, 0);
            customerLayout.Size = new Size(704, 96);
            //
            // formPanel
            //
            formPanel.BackColor = Color.Silver;
            formPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            formPanel.ColumnCount = 4;
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            formPanel.Controls.Add(customerNameLabel, 0, 0);
            formPanel.Controls.Add(customerName, 1, 0);
            formPanel.Controls.Add(dateFromLabel, 2, 0);
            formPanel.Controls.Add(dateToLabel, 2, 1);
            formPanel.Controls.Add(dateFromPicker, 3, 0);
            formPanel.Controls.Add(dateToPicker, 3, 1);
            formPanel.Controls.Add(statusLabel, 0, 1);
            formPanel.Controls.Add(statusPanel, 1, 1);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(4, 28);
            formPanel.Name = "formPanel";
            formPanel.RowCount = 2;
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            formPanel.Size = new Size(696, 68);
            //
            // customerNameLabel
            //
            customerNameLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customerNameLabel.ForeColor = SystemColors.ControlLightLight;
            customerNameLabel.Location = new Point(4, 1);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new Size(44, 32);
            customerNameLabel.Text = "Name";
            //
            // customerName
            //
            customerName.Dock = DockStyle.Fill;
            customerName.DropDownStyle = ComboBoxStyle.DropDownList;
            customerName.Location = new Point(58, 7);
            customerName.Margin = new Padding(6);
            customerName.Name = "customerName";
            customerName.Size = new Size(259, 21);
            customerName.TabIndex = 6;
            customerName.SelectedIndexChanged += new EventHandler(ComboCustomer_SelectedIndexChanged);
            //
            // dateFromLabel
            //
            dateFromLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateFromLabel.ForeColor = SystemColors.ControlLightLight;
            dateFromLabel.Location = new Point(327, 1);
            dateFromLabel.Name = "dateFromLabel";
            dateFromLabel.Size = new Size(44, 32);
            dateFromLabel.Text = "From";
            //
            // dateToLabel
            //
            dateToLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateToLabel.ForeColor = SystemColors.ControlLightLight;
            dateToLabel.Location = new Point(327, 34);
            dateToLabel.Name = "dateToLabel";
            dateToLabel.Size = new Size(44, 33);
            dateToLabel.Text = "Until";
            //
            // dateFromPicker
            //
            dateFromPicker.Dock = DockStyle.Fill;
            dateFromPicker.Location = new Point(381, 7);
            dateFromPicker.Margin = new Padding(6);
            dateFromPicker.Name = "dateFromPicker";
            dateFromPicker.ShowCheckBox = true;
            dateFromPicker.Size = new Size(308, 20);
            dateFromPicker.TabIndex = 10;
            dateFromPicker.ValueChanged += new EventHandler(PickerFrom_ValueChanged);
            //
            // dateToPicker
            //
            dateToPicker.Dock = DockStyle.Fill;
            dateToPicker.Location = new Point(381, 40);
            dateToPicker.Margin = new Padding(6);
            dateToPicker.Name = "dateToPicker";
            dateToPicker.ShowCheckBox = true;
            dateToPicker.Size = new Size(308, 20);
            dateToPicker.TabIndex = 11;
            dateToPicker.ValueChanged += new EventHandler(PickerUntil_ValueChanged);
            //
            // statusLabel
            //
            statusLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = SystemColors.ControlLightLight;
            statusLabel.Location = new Point(4, 5);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(44, 33);
            statusLabel.Text = "Status";
            //
            // statusPanel
            //
            statusPanel.Controls.Add(checkWaiting);
            statusPanel.Controls.Add(checkPending);
            statusPanel.Controls.Add(checkDispatched);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.Location = new Point(58, 40);
            statusPanel.Margin = new Padding(6);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(259, 21);
            //
            // checkWaiting
            //
            checkWaiting.Checked = true;
            checkWaiting.CheckState = CheckState.Checked;
            checkWaiting.Location = new Point(3, 3);
            checkWaiting.Name = "checkWaiting";
            checkWaiting.Size = new Size(62, 17);
            checkWaiting.TabIndex = 7;
            checkWaiting.Text = "Waiting";
            checkWaiting.CheckedChanged += new EventHandler(CheckWaiting_CheckedChanged);
            //
            // checkProcessing
            //
            checkPending.Checked = true;
            checkPending.CheckState = CheckState.Checked;
            checkPending.Location = new Point(71, 3);
            checkPending.Name = "checkPending";
            checkPending.Size = new Size(78, 17);
            checkPending.TabIndex = 8;
            checkPending.Text = "Pending";
            checkPending.CheckedChanged += new EventHandler(CheckProcessing_CheckedChanged);
            //
            // checkDispatched
            //
            checkDispatched.Checked = true;
            checkDispatched.CheckState = CheckState.Checked;
            checkDispatched.Location = new Point(155, 3);
            checkDispatched.Name = "checkDispatched";
            checkDispatched.Size = new Size(80, 17);
            checkDispatched.TabIndex = 9;
            checkDispatched.Text = "Dispatched";
            checkDispatched.CheckedChanged += new EventHandler(CheckDispatched_CheckedChanged);
            //
            // customerPanel
            //
            customerPanel.BackColor = SystemColors.ControlDarkDark;
            customerPanel.Controls.Add(customerLabel);
            customerPanel.Dock = DockStyle.Top;
            customerPanel.Location = new Point(4, 4);
            customerPanel.Name = "customerPanel";
            customerPanel.Size = new Size(696, 24);
            //
            // customerLabel
            //
            customerLabel.Dock = DockStyle.None;
            customerLabel.Location = new Point(7, 5);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(59, 13);
            customerLabel.Text = "Customer";
            //
            // transactionsLayout
            //
            transactionsLayout.BackColor = SystemColors.ControlDark;
            transactionsLayout.Controls.Add(transactionList);
            transactionsLayout.Controls.Add(transactionsPanel);
            transactionsLayout.Dock = DockStyle.Fill;
            transactionsLayout.Location = new Point(0, 96);
            transactionsLayout.Name = "transactionsLayout";
            transactionsLayout.Padding = new Padding(4);
            transactionsLayout.Size = new Size(704, 422);
            //
            // transactionList
            //
            transactionList.BackColor = SystemColors.ControlLight;
            transactionList.Columns.AddRange(new ColumnHeader[] { columnDate, columnTitle, columnCustomer, columnQuantity, columnTotal, columnStatus });
            transactionList.Dock = DockStyle.Fill;
            transactionList.FullRowSelect = true;
            transactionList.GridLines = true;
            transactionList.Location = new Point(4, 28);
            transactionList.Name = "transactionList";
            transactionList.Size = new Size(696, 390);
            transactionList.TabIndex = 12;
            transactionList.View = View.Details;
            transactionList.SelectedIndexChanged += new EventHandler(OrderList_SelectedIndexChanged);
            transactionList.MouseDoubleClick += new MouseEventHandler(OrdersList_DoubleClicked);
            //
            // columnDate
            //
            columnDate.Text = "Date";
            columnDate.Width = 100;
            columnTitle.Text = "Title";
            columnTitle.Width = 182;
            columnCustomer.Text = "Customer";
            columnCustomer.Width = 130;
            columnQuantity.Text = "Quantity";
            columnQuantity.TextAlign = HorizontalAlignment.Center;
            columnQuantity.Width = 60;
            columnTotal.Text = "Total";
            columnTotal.TextAlign = HorizontalAlignment.Center;
            columnTotal.Width = 80;
            columnStatus.Text = "Status";
            columnStatus.TextAlign = HorizontalAlignment.Center;
            columnStatus.Width = 140;
            //
            // ordersPanel
            //
            transactionsPanel.BackColor = SystemColors.ControlDarkDark;
            transactionsPanel.Controls.Add(transactionsLabel);
            transactionsPanel.Dock = DockStyle.Top;
            transactionsPanel.Location = new Point(4, 4);
            transactionsPanel.Name = "transactionsPanel";
            transactionsPanel.Size = new Size(696, 24);
            //
            // transactionsLabel
            //
            transactionsLabel.Dock = DockStyle.None;
            transactionsLabel.Location = new Point(4, 5);
            transactionsLabel.Name = "transactionsLabel";
            transactionsLabel.Size = new Size(80, 13);
            transactionsLabel.Text = "Transactions";
            //
            // buttonPanel
            //
            buttonPanel.BackColor = Color.Gray;
            buttonPanel.Controls.Add(buttonLayout);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 518);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(4);
            buttonPanel.Size = new Size(704, 41);
            //
            // buttonLayout
            //
            buttonLayout.Controls.Add(buttonRegister);
            buttonLayout.Controls.Add(buttonOrder);
            buttonLayout.Controls.Add(buttonCancel);
            buttonLayout.Controls.Add(buttonDelete);
            buttonLayout.Controls.Add(buttonManage);
            buttonLayout.Controls.Add(buttonLogout);
            buttonLayout.Dock = DockStyle.Fill;
            buttonLayout.Location = new Point(4, 4);
            buttonLayout.Name = "buttonLayout";
            buttonLayout.Size = new Size(696, 33);
            //
            // buttonRegister
            //
            buttonRegister.Location = new Point(0, 3);
            buttonRegister.Margin = new Padding(0, 3, 2, 3);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(120, 28);
            buttonRegister.TabIndex = 0;
            buttonRegister.Text = "Register Purchase";
            buttonRegister.Click += new EventHandler(ButtonRegister_Click);
            //
            // buttonOrder
            //
            buttonOrder.Location = new Point(124, 3);
            buttonOrder.Margin = new Padding(2, 3, 2, 3);
            buttonOrder.Name = "buttonOrder";
            buttonOrder.Size = new Size(120, 28);
            buttonOrder.TabIndex = 1;
            buttonOrder.Text = "Place Order";
            buttonOrder.Click += new EventHandler(ButtonOrder_Click);
            //
            // buttonCancel
            //
            buttonCancel.Location = new Point(248, 3);
            buttonCancel.Margin = new Padding(2, 3, 2, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(105, 28);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel Order";
            buttonCancel.Click += new EventHandler(ButtonCancel_Click);
            //
            // buttonDelete
            //
            buttonDelete.Location = new Point(357, 3);
            buttonDelete.Margin = new Padding(2, 3, 2, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(105, 28);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete";
            buttonDelete.Click += new EventHandler(ButtonDelete_Click);
            //
            // buttonManage
            //
            buttonManage.Location = new Point(466, 3);
            buttonManage.Margin = new Padding(2, 3, 2, 3);
            buttonManage.Name = "buttonManage";
            buttonManage.Size = new Size(120, 28);
            buttonManage.TabIndex = 4;
            buttonManage.Text = "Manage Books";
            buttonManage.Click += new EventHandler(ButtonManage_Click);
            //
            // buttonLogout
            //
            buttonLogout.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogout.Location = new Point(590, 3);
            buttonLogout.Margin = new Padding(2, 3, 0, 3);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(105, 28);
            buttonLogout.TabIndex = 5;
            buttonLogout.Text = "Logout";
            buttonLogout.Click += new EventHandler(ButtonLogout_Click);
            //
            // StoreForm
            //
            AcceptButton = buttonRegister;
            ClientSize = new Size(704, 559);
            Controls.Add(transactionsLayout);
            Controls.Add(customerLayout);
            Controls.Add(buttonPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.librettoIcon;
            MaximizeBox = false;
            Name = "StoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Libretto Bookstore";
            FormClosed += new FormClosedEventHandler(StoreForm_FormClosed);
            Load += new EventHandler(StoreForm_Load);
            customerLayout.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            statusPanel.ResumeLayout(false);
            customerPanel.ResumeLayout(false);
            customerPanel.PerformLayout();
            transactionsLayout.ResumeLayout(false);
            transactionsPanel.ResumeLayout(false);
            transactionsPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            buttonLayout.ResumeLayout(false);
            buttonLayout.PerformLayout();
            ResumeLayout(false);
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
        private FlowLayoutPanel statusPanel;
        private CheckBox checkWaiting;
        private CheckBox checkPending;
        private CheckBox checkDispatched;
        private Panel buttonPanel;
        private FlowLayoutPanel buttonLayout;
        private FlatButton buttonOrder;
        private FlatButton buttonCancel;
        private FlatButton buttonDelete;
        private FlatButton buttonManage;
        private FlatButton buttonLogout;
        private ListView transactionList;
        private ColumnHeader columnDate;
        private ColumnHeader columnTitle;
        private FlatButton buttonRegister;
        private ColumnHeader columnCustomer;
        private ColumnHeader columnQuantity;
        private ColumnHeader columnTotal;
        private ColumnHeader columnStatus;
    }
}