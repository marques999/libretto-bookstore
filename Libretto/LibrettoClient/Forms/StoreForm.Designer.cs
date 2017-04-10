using Libretto.Properties;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class StoreForm
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
            this.customerLayout = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelUntil = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.pickerFrom = new System.Windows.Forms.DateTimePicker();
            this.pickerUntil = new System.Windows.Forms.DateTimePicker();
            this.statusPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkWaiting = new System.Windows.Forms.CheckBox();
            this.checkProcessing = new System.Windows.Forms.CheckBox();
            this.checkDispatched = new System.Windows.Forms.CheckBox();
            this.customerPanel = new System.Windows.Forms.Panel();
            this.customerLabel = new System.Windows.Forms.Label();
            this.ordersLayout = new System.Windows.Forms.Panel();
            this.transactionList = new System.Windows.Forms.ListView();
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.transactionsPanel = new System.Windows.Forms.Panel();
            this.transactionsLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonManage = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.customerLayout.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.customerPanel.SuspendLayout();
            this.ordersLayout.SuspendLayout();
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
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.formPanel.Controls.Add(this.labelUntil, 2, 1);
            this.formPanel.Controls.Add(this.labelFrom, 2, 0);
            this.formPanel.Controls.Add(this.nameLabel, 0, 0);
            this.formPanel.Controls.Add(this.statusLabel, 0, 1);
            this.formPanel.Controls.Add(this.comboCustomer, 1, 0);
            this.formPanel.Controls.Add(this.pickerFrom, 3, 0);
            this.formPanel.Controls.Add(this.pickerUntil, 3, 1);
            this.formPanel.Controls.Add(this.statusPanel, 1, 1);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(4, 28);
            this.formPanel.Name = "formPanel";
            this.formPanel.RowCount = 2;
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.Size = new System.Drawing.Size(696, 68);
            this.formPanel.TabIndex = 1;
            // 
            // labelUntil
            // 
            this.labelUntil.AutoSize = true;
            this.labelUntil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUntil.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelUntil.Location = new System.Drawing.Point(329, 34);
            this.labelUntil.Name = "labelUntil";
            this.labelUntil.Size = new System.Drawing.Size(44, 33);
            this.labelUntil.TabIndex = 11;
            this.labelUntil.Text = "Until";
            this.labelUntil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrom.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelFrom.Location = new System.Drawing.Point(329, 1);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(44, 32);
            this.labelFrom.TabIndex = 10;
            this.labelFrom.Text = "From";
            this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.nameLabel.Location = new System.Drawing.Point(4, 1);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 32);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.statusLabel.Location = new System.Drawing.Point(4, 34);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 33);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCustomer
            // 
            this.comboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCustomer.FormattingEnabled = true;
            this.comboCustomer.ItemHeight = 13;
            this.comboCustomer.Location = new System.Drawing.Point(58, 7);
            this.comboCustomer.Margin = new System.Windows.Forms.Padding(6);
            this.comboCustomer.MaxDropDownItems = 20;
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(261, 21);
            this.comboCustomer.TabIndex = 5;
            this.comboCustomer.SelectedIndexChanged += new System.EventHandler(this.ComboCustomer_SelectedIndexChanged);
            // 
            // pickerFrom
            // 
            this.pickerFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickerFrom.Location = new System.Drawing.Point(383, 7);
            this.pickerFrom.Margin = new System.Windows.Forms.Padding(6);
            this.pickerFrom.Name = "pickerFrom";
            this.pickerFrom.ShowCheckBox = true;
            this.pickerFrom.Size = new System.Drawing.Size(306, 20);
            this.pickerFrom.TabIndex = 8;
            this.pickerFrom.ValueChanged += new System.EventHandler(this.DateFromPicker_ValueChanged);
            // 
            // pickerUntil
            // 
            this.pickerUntil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickerUntil.Location = new System.Drawing.Point(383, 40);
            this.pickerUntil.Margin = new System.Windows.Forms.Padding(6);
            this.pickerUntil.Name = "pickerUntil";
            this.pickerUntil.ShowCheckBox = true;
            this.pickerUntil.Size = new System.Drawing.Size(306, 20);
            this.pickerUntil.TabIndex = 9;
            this.pickerUntil.ValueChanged += new System.EventHandler(this.DateUntilPicker_ValueChanged);
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
            this.statusPanel.Size = new System.Drawing.Size(261, 21);
            this.statusPanel.TabIndex = 12;
            // 
            // checkWaiting
            // 
            this.checkWaiting.AutoSize = true;
            this.checkWaiting.Checked = true;
            this.checkWaiting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkWaiting.Location = new System.Drawing.Point(3, 3);
            this.checkWaiting.Name = "checkWaiting";
            this.checkWaiting.Size = new System.Drawing.Size(62, 17);
            this.checkWaiting.TabIndex = 0;
            this.checkWaiting.Text = "Waiting";
            this.checkWaiting.UseVisualStyleBackColor = true;
            this.checkWaiting.CheckedChanged += new System.EventHandler(this.CheckWaiting_CheckedChanged);
            // 
            // checkProcessing
            // 
            this.checkProcessing.AutoSize = true;
            this.checkProcessing.Checked = true;
            this.checkProcessing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkProcessing.Location = new System.Drawing.Point(71, 3);
            this.checkProcessing.Name = "checkProcessing";
            this.checkProcessing.Size = new System.Drawing.Size(78, 17);
            this.checkProcessing.TabIndex = 1;
            this.checkProcessing.Text = "Processing";
            this.checkProcessing.UseVisualStyleBackColor = true;
            this.checkProcessing.CheckedChanged += new System.EventHandler(this.CheckProcessing_CheckedChanged);
            // 
            // checkDispatched
            // 
            this.checkDispatched.AutoSize = true;
            this.checkDispatched.Checked = true;
            this.checkDispatched.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDispatched.Location = new System.Drawing.Point(155, 3);
            this.checkDispatched.Name = "checkDispatched";
            this.checkDispatched.Size = new System.Drawing.Size(80, 17);
            this.checkDispatched.TabIndex = 2;
            this.checkDispatched.Text = "Dispatched";
            this.checkDispatched.UseVisualStyleBackColor = true;
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
            this.customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.ForeColor = System.Drawing.Color.Silver;
            this.customerLabel.Location = new System.Drawing.Point(7, 5);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(2);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(59, 13);
            this.customerLabel.TabIndex = 8;
            this.customerLabel.Text = "Customer";
            this.customerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ordersLayout
            // 
            this.ordersLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ordersLayout.Controls.Add(this.transactionList);
            this.ordersLayout.Controls.Add(this.transactionsPanel);
            this.ordersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersLayout.Location = new System.Drawing.Point(0, 96);
            this.ordersLayout.Name = "ordersLayout";
            this.ordersLayout.Padding = new System.Windows.Forms.Padding(4);
            this.ordersLayout.Size = new System.Drawing.Size(704, 422);
            this.ordersLayout.TabIndex = 2;
            // 
            // transactionList
            // 
            this.transactionList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.transactionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDate,
            this.columnTitle,
            this.columnCustomer,
            this.columnQuantity,
            this.columnTotal,
            this.columnStatus});
            this.transactionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionList.FullRowSelect = true;
            this.transactionList.GridLines = true;
            this.transactionList.LabelWrap = false;
            this.transactionList.Location = new System.Drawing.Point(4, 28);
            this.transactionList.Name = "transactionList";
            this.transactionList.Size = new System.Drawing.Size(696, 390);
            this.transactionList.TabIndex = 2;
            this.transactionList.UseCompatibleStateImageBehavior = false;
            this.transactionList.View = System.Windows.Forms.View.Details;
            this.transactionList.SelectedIndexChanged += new System.EventHandler(this.OrderList_SelectedIndexChanged);
            this.transactionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OrdersList_DoubleClicked);
            // 
            // columnDate
            // 
            this.columnDate.Text = "Date";
            this.columnDate.Width = 100;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            this.columnTitle.Width = 200;
            // 
            // columnCustomer
            // 
            this.columnCustomer.Text = "Customer";
            this.columnCustomer.Width = 150;
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
            this.columnStatus.Width = 96;
            // 
            // transactionsPanel
            // 
            this.transactionsPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.transactionsPanel.Controls.Add(this.transactionsLabel);
            this.transactionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionsPanel.Location = new System.Drawing.Point(4, 4);
            this.transactionsPanel.Name = "transactionsPanel";
            this.transactionsPanel.Size = new System.Drawing.Size(696, 24);
            this.transactionsPanel.TabIndex = 1;
            // 
            // transactionsLabel
            // 
            this.transactionsLabel.AutoSize = true;
            this.transactionsLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.transactionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsLabel.ForeColor = System.Drawing.Color.Silver;
            this.transactionsLabel.Location = new System.Drawing.Point(7, 5);
            this.transactionsLabel.Margin = new System.Windows.Forms.Padding(2);
            this.transactionsLabel.Name = "transactionsLabel";
            this.transactionsLabel.Size = new System.Drawing.Size(80, 13);
            this.transactionsLabel.TabIndex = 8;
            this.transactionsLabel.Text = "Transactions";
            this.transactionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonPanel.Controls.Add(this.buttonLayout);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 518);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(4);
            this.buttonPanel.Size = new System.Drawing.Size(704, 41);
            this.buttonPanel.TabIndex = 0;
            // 
            // buttonLayout
            // 
            this.buttonLayout.Controls.Add(this.buttonRegister);
            this.buttonLayout.Controls.Add(this.buttonOrder);
            this.buttonLayout.Controls.Add(this.buttonUpdate);
            this.buttonLayout.Controls.Add(this.buttonDelete);
            this.buttonLayout.Controls.Add(this.buttonManage);
            this.buttonLayout.Controls.Add(this.buttonLogout);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.Location = new System.Drawing.Point(4, 4);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Size = new System.Drawing.Size(696, 33);
            this.buttonLayout.TabIndex = 0;
            // 
            // buttonRegister
            // 
            this.buttonRegister.AutoSize = true;
            this.buttonRegister.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRegister.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Location = new System.Drawing.Point(0, 3);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(120, 28);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "Register Purchase";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // buttonOrder
            // 
            this.buttonOrder.AutoSize = true;
            this.buttonOrder.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrder.Location = new System.Drawing.Point(124, 3);
            this.buttonOrder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(120, 28);
            this.buttonOrder.TabIndex = 5;
            this.buttonOrder.Text = "Place Order";
            this.buttonOrder.UseVisualStyleBackColor = false;
            this.buttonOrder.Click += new System.EventHandler(this.ButtonOrder_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Location = new System.Drawing.Point(248, 3);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(105, 28);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(357, 3);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(105, 28);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonManage
            // 
            this.buttonManage.AutoSize = true;
            this.buttonManage.BackColor = System.Drawing.SystemColors.Control;
            this.buttonManage.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManage.Location = new System.Drawing.Point(466, 3);
            this.buttonManage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonManage.Name = "buttonManage";
            this.buttonManage.Size = new System.Drawing.Size(120, 28);
            this.buttonManage.TabIndex = 8;
            this.buttonManage.Text = "Manage Books";
            this.buttonManage.UseVisualStyleBackColor = false;
            this.buttonManage.Click += new System.EventHandler(this.ButtonManage_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.AutoSize = true;
            this.buttonLogout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLogout.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(590, 3);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(105, 28);
            this.buttonLogout.TabIndex = 9;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 559);
            this.Controls.Add(this.ordersLayout);
            this.Controls.Add(this.customerLayout);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Libretto.Properties.Resources.librettoIcon;
            this.MaximizeBox = false;
            this.Name = "StoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libretto Bookstore";
            this.Load += new System.EventHandler(this.StoreForm_Load);
            this.customerLayout.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.customerPanel.ResumeLayout(false);
            this.customerPanel.PerformLayout();
            this.ordersLayout.ResumeLayout(false);
            this.transactionsPanel.ResumeLayout(false);
            this.transactionsPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonLayout.ResumeLayout(false);
            this.buttonLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel customerLayout;
        private System.Windows.Forms.Panel customerPanel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TableLayoutPanel formPanel;
        private System.Windows.Forms.Label labelUntil;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker pickerFrom;
        private System.Windows.Forms.DateTimePicker pickerUntil;
        private System.Windows.Forms.Panel ordersLayout;
        private System.Windows.Forms.Panel transactionsPanel;
        private System.Windows.Forms.Label transactionsLabel;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnCustomer;
        private System.Windows.Forms.ListView transactionList;
        private System.Windows.Forms.ColumnHeader columnQuantity;
        private System.Windows.Forms.ColumnHeader columnTotal;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.FlowLayoutPanel statusPanel;
        private System.Windows.Forms.CheckBox checkWaiting;
        private System.Windows.Forms.CheckBox checkProcessing;
        private System.Windows.Forms.CheckBox checkDispatched;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonLayout;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonManage;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonRegister;
    }
}