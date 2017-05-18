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
            filterLayout = new Panel();
            formPanel = new TableLayoutPanel();
            filterTitleLabel = new FlatLabel();
            filterTitle = new ComboBox();
            filterDateFrom = new FlatLabel();
            filterDateUntil = new FlatLabel();
            dateFromPicker = new DateTimePicker();
            dateUntilPicker = new DateTimePicker();
            filterPanel = new Panel();
            filterLabel = new Libretto.Forms.FlatHeader();
            transactionsLayout = new Panel();
            listView = new ListView();
            columnDate = new ColumnHeader();
            columnTitle = new ColumnHeader();
            columnQuantity = new ColumnHeader();
            columnTotal = new ColumnHeader();
            columnLast = new ColumnHeader();
            transactionsPanel = new Panel();
            transactionsLabel = new FlatHeader();
            buttonPanel = new Panel();
            buttonRefresh = new FlatButton();
            buttonLogout = new FlatButton();
            buttonSatisfy = new FlatButton();
            filterLayout.SuspendLayout();
            formPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            transactionsLayout.SuspendLayout();
            transactionsPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // filterLayout
            // 
            filterLayout.BackColor = SystemColors.ControlDark;
            filterLayout.Controls.Add(formPanel);
            filterLayout.Controls.Add(filterPanel);
            filterLayout.Dock = DockStyle.Top;
            filterLayout.Location = new Point(0, 0);
            filterLayout.Name = "filterLayout";
            filterLayout.Padding = new Padding(4, 4, 4, 0);
            filterLayout.Size = new Size(704, 96);
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
            formPanel.Controls.Add(filterTitleLabel, 0, 0);
            formPanel.Controls.Add(filterTitle, 1, 0);
            formPanel.Controls.Add(filterDateFrom, 2, 0);
            formPanel.Controls.Add(filterDateUntil, 2, 1);
            formPanel.Controls.Add(dateFromPicker, 3, 0);
            formPanel.Controls.Add(dateUntilPicker, 3, 1);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(4, 28);
            formPanel.Name = "formPanel";
            formPanel.RowCount = 2;
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            formPanel.Size = new Size(696, 68);
            // 
            // filterTitleLabel
            // 
            filterTitleLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterTitleLabel.ForeColor = SystemColors.ControlLightLight;
            filterTitleLabel.Location = new Point(1, 1);
            filterTitleLabel.Name = "filterTitleLabel";
            filterTitleLabel.Size = new Size(50, 32);
            filterTitleLabel.Text = "Title";
            // 
            // filterTitle
            // 
            filterTitle.Dock = DockStyle.Fill;
            filterTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            filterTitle.Location = new Point(58, 7);
            filterTitle.Margin = new Padding(6);
            filterTitle.Name = "filterTitle";
            filterTitle.Size = new Size(259, 21);
            filterTitle.TabIndex = 3;
            filterTitle.SelectedIndexChanged += new System.EventHandler(ComboCustomer_SelectedIndexChanged);
            // 
            // filterDateFrom
            // 
            filterDateFrom.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterDateFrom.ForeColor = SystemColors.ControlLightLight;
            filterDateFrom.Location = new Point(324, 1);
            filterDateFrom.Name = "filterDateFrom";
            filterDateFrom.Size = new Size(50, 32);
            filterDateFrom.Text = "From";
            // 
            // filterDateUntil
            // 
            filterDateUntil.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterDateUntil.ForeColor = SystemColors.ControlLightLight;
            filterDateUntil.Location = new Point(324, 34);
            filterDateUntil.Name = "filterDateUntil";
            filterDateUntil.Size = new Size(50, 33);
            filterDateUntil.Text = "Until";
            // 
            // dateFromPicker
            // 
            dateFromPicker.Dock = DockStyle.Fill;
            dateFromPicker.Location = new Point(381, 7);
            dateFromPicker.Margin = new Padding(6);
            dateFromPicker.Name = "dateFromPicker";
            dateFromPicker.ShowCheckBox = true;
            dateFromPicker.Size = new Size(308, 20);
            dateFromPicker.TabIndex = 7;
            dateFromPicker.ValueChanged += new System.EventHandler(DateFromPicker_ValueChanged);
            // 
            // dateUntilPicker
            // 
            dateUntilPicker.Dock = DockStyle.Fill;
            dateUntilPicker.Location = new Point(381, 40);
            dateUntilPicker.Margin = new Padding(6);
            dateUntilPicker.Name = "dateUntilPicker";
            dateUntilPicker.ShowCheckBox = true;
            dateUntilPicker.Size = new Size(308, 20);
            dateUntilPicker.TabIndex = 8;
            dateUntilPicker.ValueChanged += new System.EventHandler(DateToPicker_ValueChanged);
            // 
            // filterPanel
            // 
            filterPanel.BackColor = SystemColors.ControlDarkDark;
            filterPanel.Controls.Add(filterLabel);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(4, 4);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(696, 24);
            // 
            // filterLabel
            // 
            filterLabel.Dock = DockStyle.None;
            filterLabel.Location = new Point(4, 5);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(35, 13);
            filterLabel.Text = "Filter";
            // 
            // transactionsLayout
            // 
            transactionsLayout.BackColor = SystemColors.ControlDark;
            transactionsLayout.Controls.Add(listView);
            transactionsLayout.Controls.Add(transactionsPanel);
            transactionsLayout.Dock = DockStyle.Fill;
            transactionsLayout.Location = new Point(0, 96);
            transactionsLayout.Name = "transactionsLayout";
            transactionsLayout.Padding = new Padding(4);
            transactionsLayout.Size = new Size(704, 427);
            // 
            // listView
            // 
            listView.BackColor = SystemColors.ControlLight;
            listView.Columns.AddRange(new ColumnHeader[] { columnDate, columnTitle, columnQuantity, columnTotal, columnLast});
            listView.Dock = DockStyle.Fill;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(4, 28);
            listView.MultiSelect = false;
            listView.Name = "listView";
            listView.Size = new Size(696, 395);
            listView.TabIndex = 7;
            listView.View = View.Details;
            listView.SelectedIndexChanged += new System.EventHandler(ListView_SelectedIndexChanged);
            listView.MouseDoubleClick += new MouseEventHandler(ListView_DoubleClicked);
            // 
            // columnDate
            // 
            columnDate.Text = "Date Issued";
            columnDate.TextAlign = HorizontalAlignment.Center;
            columnDate.Width = 100;
            columnTitle.Text = "Title";
            columnTitle.Width = 268;
            columnQuantity.Text = "Quantity";
            columnQuantity.TextAlign = HorizontalAlignment.Center;
            columnQuantity.Width = 64;
            columnTotal.Text = "Total";
            columnTotal.TextAlign = HorizontalAlignment.Center;
            columnTotal.Width = 80;
            columnLast.Text = "Last Update";
            columnLast.TextAlign = HorizontalAlignment.Center;
            columnLast.Width = 100;
            // 
            // transactionsPanel
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
            transactionsLabel.Size = new Size(44, 13);
            transactionsLabel.Text = "Orders";
            // 
            // buttonPanel
            // 
            buttonPanel.BackColor = Color.DarkGray;
            buttonPanel.Controls.Add(buttonRefresh);
            buttonPanel.Controls.Add(buttonLogout);
            buttonPanel.Controls.Add(buttonSatisfy);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 523);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(4, 0, 4, 4);
            buttonPanel.Size = new Size(704, 36);
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(144, 0);
            buttonRefresh.Margin = new Padding(2, 3, 2, 3);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(416, 32);
            buttonRefresh.TabIndex = 1;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.Click += new System.EventHandler(ButtonRefresh_Click);
            // 
            // buttonLogout
            // 
            buttonLogout.DialogResult = DialogResult.Cancel;
            buttonLogout.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonLogout.Location = new Point(560, 0);
            buttonLogout.Margin = new Padding(2, 3, 0, 3);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(140, 32);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Exit";
            buttonLogout.Click += new System.EventHandler(ButtonLogout_Click);
            // 
            // buttonSatisfy
            // 
            buttonSatisfy.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonSatisfy.Location = new Point(4, 0);
            buttonSatisfy.Margin = new Padding(0, 3, 2, 3);
            buttonSatisfy.Name = "buttonSatisfy";
            buttonSatisfy.Size = new Size(140, 32);
            buttonSatisfy.TabIndex = 0;
            buttonSatisfy.Text = "Satisfy Order";
            buttonSatisfy.Click += new EventHandler(ButtonSatisfy_Click);
            // 
            // WarehouseClient
            // 
            AcceptButton = buttonSatisfy;
            CancelButton = buttonLogout;
            ClientSize = new Size(704, 559);
            Controls.Add(transactionsLayout);
            Controls.Add(filterLayout);
            Controls.Add(buttonPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.librettoIcon;
            MaximizeBox = false;
            Name = "WarehouseClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Libretto Warehouse";
            FormClosing += new FormClosingEventHandler(WarehouseForm_FormClosing);
            Load += new System.EventHandler(WarehouseClient_Load);
            filterLayout.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            transactionsLayout.ResumeLayout(false);
            transactionsPanel.ResumeLayout(false);
            transactionsPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            ResumeLayout(false);
        }

        private Panel filterLayout;
        private Panel filterPanel;
        private FlatHeader filterLabel;
        private Panel transactionsLayout;
        private Panel transactionsPanel;
        private FlatHeader transactionsLabel;
        private ColumnHeader columnDate;
        private ColumnHeader columnTitle;
        private ColumnHeader columnLast;
        private ListView listView;
        private ColumnHeader columnQuantity;
        private ColumnHeader columnTotal;
        private Panel buttonPanel;
        private FlatButton buttonLogout;
        private FlatButton buttonSatisfy;
        private FlatButton buttonRefresh;
        private TableLayoutPanel formPanel;
        private FlatLabel filterTitleLabel;
        private ComboBox filterTitle;
        private FlatLabel filterDateFrom;
        private FlatLabel filterDateUntil;
        private DateTimePicker dateFromPicker;
        private DateTimePicker dateUntilPicker;
    }
}