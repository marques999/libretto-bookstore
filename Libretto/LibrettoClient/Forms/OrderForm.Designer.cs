using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Libretto.Controls;

namespace Libretto.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal sealed partial class OrderForm
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
            formPanel1 = new TableLayoutPanel();
            bookPanel = new TableLayoutPanel();
            bookStockLabel = new FlatLabel();
            bookGuidLabel = new FlatLabel();
            bookTitleLabel = new FlatLabel();
            bookPriceLabel = new FlatLabel();
            bookGuid = new TextBox();
            bookTitle = new ComboBox();
            bookPricePanel = new TableLayoutPanel();
            currencyLabel1 = new FlatBadge();
            bookPrice = new Label();
            bookStockPanel = new TableLayoutPanel();
            unitLabel1 = new FlatBadge();
            bookStock = new Label();
            customerPanel = new TableLayoutPanel();
            customerNamePanel = new FlowLayoutPanel();
            customerName = new ComboBox();
            customerNameButton = new Button();
            customerLocationLabel = new FlatLabel();
            customerGuidLabel = new FlatLabel();
            customerNameLabel = new FlatLabel();
            customerEmailLabel = new FlatLabel();
            customerGuid = new TextBox();
            customerEmail = new Label();
            customerLocation = new Label();
            customerLabel = new FlatHeader();
            bookLabel = new FlatHeader();
            formPanel2 = new TableLayoutPanel();
            orderPanel = new TableLayoutPanel();
            statusLabel = new FlatLabel();
            orderQuantityLabel = new FlatLabel();
            orderTotalPanel = new TableLayoutPanel();
            currencyLabel2 = new FlatBadge();
            orderTotal = new Label();
            orderTotalLabel = new FlatLabel();
            orderQuantityPanel = new TableLayoutPanel();
            unitLabel2 = new FlatBadge();
            orderQuantityInfo = new Label();
            orderQuantity = new TrackBar();
            statusPanel = new FlowLayoutPanel();
            statusWaiting = new RadioButton();
            statusProcessing = new RadioButton();
            statusDispatched = new RadioButton();
            buttonPanel = new FlowLayoutPanel();
            buttonCancel = new FlatButton();
            buttonConfirm = new FlatButton();
            orderLabel = new FlatHeader();
            formPanel1.SuspendLayout();
            bookPanel.SuspendLayout();
            bookPricePanel.SuspendLayout();
            bookStockPanel.SuspendLayout();
            customerPanel.SuspendLayout();
            customerNamePanel.SuspendLayout();
            formPanel2.SuspendLayout();
            orderPanel.SuspendLayout();
            orderTotalPanel.SuspendLayout();
            orderQuantityPanel.SuspendLayout();
            orderQuantity.BeginInit();
            statusPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            //
            // formPanel1
            //
            formPanel1.BackColor = SystemColors.ControlDark;
            formPanel1.ColumnCount = 2;
            formPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formPanel1.Controls.Add(customerLabel, 0, 0);
            formPanel1.Controls.Add(customerPanel, 0, 1);
            formPanel1.Controls.Add(bookLabel, 1, 0);
            formPanel1.Controls.Add(bookPanel, 1, 1);
            formPanel1.Dock = DockStyle.Top;
            formPanel1.Location = new Point(0, 0);
            formPanel1.Name = "formPanel1";
            formPanel1.RowCount = 2;
            formPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            formPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formPanel1.Size = new Size(624, 160);
            //
            // bookPanel
            //
            bookPanel.BackColor = Color.Gainsboro;
            bookPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            bookPanel.ColumnCount = 2;
            bookPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            bookPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bookPanel.Controls.Add(bookGuidLabel, 0, 0);
            bookPanel.Controls.Add(bookGuid, 1, 0);
            bookPanel.Controls.Add(bookTitleLabel, 0, 1);
            bookPanel.Controls.Add(bookTitle, 1, 1);
            bookPanel.Controls.Add(bookPriceLabel, 0, 2);
            bookPanel.Controls.Add(bookPricePanel, 1, 2);
            bookPanel.Controls.Add(bookStockLabel, 0, 3);
            bookPanel.Controls.Add(bookStockPanel, 1, 3);
            bookPanel.Dock = DockStyle.Fill;
            bookPanel.Location = new Point(312, 27);
            bookPanel.Margin = new Padding(0);
            bookPanel.Name = "bookPanel";
            bookPanel.Padding = new Padding(2, 4, 4, 4);
            bookPanel.RowCount = 4;
            bookPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            bookPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            bookPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            bookPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            bookPanel.Size = new Size(312, 133);
            //
            // bookStockLabel
            //
            bookStockLabel.Location = new Point(3, 98);
            bookStockLabel.Name = "bookStockLabel";
            bookStockLabel.Size = new Size(60, 30);
            bookStockLabel.Text = "Stock";
            //
            // bookGuidLabel
            //
            bookGuidLabel.Location = new Point(3, 5);
            bookGuidLabel.Name = "bookGuidLabel";
            bookGuidLabel.Size = new Size(60, 30);
            bookGuidLabel.Text = "GUID";
            //
            // bookTitleLabel
            //
            bookTitleLabel.Location = new Point(3, 36);
            bookTitleLabel.Name = "bookTitleLabel";
            bookTitleLabel.Size = new Size(60, 30);
            bookTitleLabel.Text = "Title";
            //
            // bookPriceLabel
            //
            bookPriceLabel.Location = new Point(3, 67);
            bookPriceLabel.Name = "bookPriceLabel";
            bookPriceLabel.Size = new Size(60, 30);
            bookPriceLabel.Text = "Price";
            //
            // bookGuid
            //
            bookGuid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bookGuid.Enabled = false;
            bookGuid.Location = new Point(68, 10);
            bookGuid.Margin = new Padding(4);
            bookGuid.Name = "bookGuid";
            bookGuid.ReadOnly = true;
            bookGuid.ShortcutsEnabled = false;
            bookGuid.Size = new Size(235, 20);
            //
            // bookTitle
            //
            bookTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bookTitle.Location = new Point(68, 40);
            bookTitle.Margin = new Padding(4);
            bookTitle.Name = "bookTitle";
            bookTitle.Size = new Size(235, 21);
            bookTitle.TabIndex = 4;
            bookTitle.SelectedIndexChanged += new EventHandler(BookTitle_SelectedIndexChanged);
            //
            // bookPricePanel
            //
            bookPricePanel.ColumnCount = 2;
            bookPricePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bookPricePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            bookPricePanel.Controls.Add(bookPrice, 0, 0);
            bookPricePanel.Controls.Add(currencyLabel1, 1, 0);
            bookPricePanel.Dock = DockStyle.Fill;
            bookPricePanel.Location = new Point(67, 70);
            bookPricePanel.Name = "bookPricePanel";
            bookPricePanel.RowCount = 1;
            bookPricePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bookPricePanel.Size = new Size(237, 24);
            //
            // currencyLabel1
            //
            currencyLabel1.Location = new Point(208, 0);
            currencyLabel1.Name = "currencyLabel1";
            currencyLabel1.Size = new Size(26, 24);
            currencyLabel1.Text = "€";
            //
            // bookPrice
            //
            bookPrice.Dock = DockStyle.Fill;
            bookPrice.Location = new Point(3, 0);
            bookPrice.Name = "bookPrice";
            bookPrice.Size = new Size(199, 24);
            bookPrice.Text = "0,00";
            bookPrice.TextAlign = ContentAlignment.MiddleRight;
            //
            // bookStockPanel
            //
            bookStockPanel.ColumnCount = 2;
            bookStockPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bookStockPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            bookStockPanel.Controls.Add(bookStock, 0, 0);
            bookStockPanel.Controls.Add(unitLabel1, 1, 0);
            bookStockPanel.Dock = DockStyle.Fill;
            bookStockPanel.Location = new Point(67, 101);
            bookStockPanel.Name = "bookStockPanel";
            bookStockPanel.RowCount = 1;
            bookStockPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bookStockPanel.Size = new Size(237, 24);
            //
            // unitLabel1
            //
            unitLabel1.Location = new Point(208, 0);
            unitLabel1.Name = "unitLabel1";
            unitLabel1.Size = new Size(26, 24);
            unitLabel1.Text = "Un";
            //
            // bookStock
            //
            bookStock.Dock = DockStyle.Fill;
            bookStock.Location = new Point(3, 0);
            bookStock.Name = "bookStock";
            bookStock.Size = new Size(199, 24);
            bookStock.Text = "0";
            bookStock.TextAlign = ContentAlignment.MiddleRight;
            //
            // customerPanel
            //
            customerPanel.BackColor = Color.Gainsboro;
            customerPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            customerPanel.ColumnCount = 2;
            customerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            customerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            customerPanel.Controls.Add(customerGuidLabel, 0, 0);
            customerPanel.Controls.Add(customerGuid, 1, 0);
            customerPanel.Controls.Add(customerNameLabel, 0, 1);
            customerPanel.Controls.Add(customerNamePanel, 1, 1);
            customerPanel.Controls.Add(customerEmailLabel, 0, 2);
            customerPanel.Controls.Add(customerEmail, 1, 2);
            customerPanel.Controls.Add(customerLocationLabel, 0, 3);
            customerPanel.Controls.Add(customerLocation, 1, 3);
            customerPanel.Dock = DockStyle.Fill;
            customerPanel.Location = new Point(0, 27);
            customerPanel.Margin = new Padding(0);
            customerPanel.Name = "customerPanel";
            customerPanel.Padding = new Padding(4, 4, 2, 4);
            customerPanel.RowCount = 4;
            customerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            customerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            customerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            customerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            customerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            customerPanel.Size = new Size(312, 133);
            //
            // customerEmail
            //
            customerEmail.Dock = DockStyle.Fill;
            customerEmail.Location = new Point(70, 71);
            customerEmail.Margin = new Padding(4);
            customerEmail.Name = "customerEmail";
            customerEmail.Size = new Size(235, 22);
            customerEmail.TextAlign = ContentAlignment.MiddleLeft;
            //
            // customerEmailLabel
            //
            customerEmailLabel.Location = new Point(5, 67);
            customerEmailLabel.Name = "customerEmailLabel";
            customerEmailLabel.Size = new Size(60, 30);
            customerEmailLabel.Text = "E-mail";
            //
            // customerGuid
            //
            customerGuid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            customerGuid.BorderStyle = BorderStyle.FixedSingle;
            customerGuid.Enabled = false;
            customerGuid.Location = new Point(70, 10);
            customerGuid.Margin = new Padding(4);
            customerGuid.Name = "customerGuid";
            customerGuid.ReadOnly = true;
            customerGuid.Size = new Size(235, 20);
            //
            // customerGuidLabel
            //
            customerGuidLabel.Location = new Point(5, 5);
            customerGuidLabel.Name = "customerGuidLabel";
            customerGuidLabel.Size = new Size(60, 30);
            customerGuidLabel.Text = "GUID";
            //
            // customerLocation
            //
            customerLocation.Dock = DockStyle.Fill;
            customerLocation.Location = new Point(70, 102);
            customerLocation.Margin = new Padding(4);
            customerLocation.Name = "customerLocation";
            customerLocation.Size = new Size(235, 22);
            customerLocation.TextAlign = ContentAlignment.MiddleLeft;
            //
            // customerLocationLabel
            //
            customerLocationLabel.Location = new Point(5, 98);
            customerLocationLabel.Name = "customerLocationLabel";
            customerLocationLabel.Size = new Size(60, 30);
            customerLocationLabel.Text = "Location";
            //
            // customerName
            //
            customerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            customerName.DropDownStyle = ComboBoxStyle.DropDownList;
            customerName.Location = new Point(0, 1);
            customerName.Margin = new Padding(0);
            customerName.Name = "customerName";
            customerName.Size = new Size(205, 21);
            customerName.TabIndex = 2;
            customerName.SelectedIndexChanged += new EventHandler(CustomerName_SelectedIndexChanged);
            //
            // customerNameButton
            //
            customerNameButton.Location = new Point(205, 0);
            customerNameButton.Margin = new Padding(0);
            customerNameButton.Name = "customerNameButton";
            customerNameButton.Size = new Size(32, 23);
            customerNameButton.TabIndex = 3;
            customerNameButton.Text = "...";
            customerNameButton.Click += new EventHandler(CustomerNameButton_Click);
            //
            // customerNameLabel
            //
            customerNameLabel.Location = new Point(5, 36);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new Size(60, 30);
            customerNameLabel.Text = "Name";
            //
            // customerNamePanel
            //
            customerNamePanel.Controls.Add(customerName);
            customerNamePanel.Controls.Add(customerNameButton);
            customerNamePanel.Dock = DockStyle.Fill;
            customerNamePanel.Location = new Point(69, 39);
            customerNamePanel.Name = "customerNamePanel";
            customerNamePanel.Size = new Size(237, 24);
            //
            // customerLabel
            //
            customerLabel.Location = new Point(2, 2);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(308, 23);
            customerLabel.Text = "Customer";
            //
            // bookLabel
            //
            bookLabel.Location = new Point(314, 2);
            bookLabel.Name = "bookLabel";
            bookLabel.Size = new Size(308, 23);
            bookLabel.Text = "Book";
            //
            // formPanel2
            //
            formPanel2.BackColor = SystemColors.ControlDark;
            formPanel2.ColumnCount = 1;
            formPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formPanel2.Controls.Add(orderLabel, 0, 0);
            formPanel2.Controls.Add(orderPanel, 0, 1);
            formPanel2.Controls.Add(buttonPanel, 0, 2);
            formPanel2.Dock = DockStyle.Fill;
            formPanel2.Location = new Point(0, 160);
            formPanel2.Name = "formPanel2";
            formPanel2.RowCount = 3;
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            formPanel2.Size = new Size(624, 221);
            //
            // orderPanel
            //
            orderPanel.BackColor = Color.Gainsboro;
            orderPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            orderPanel.ColumnCount = 2;
            orderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            orderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            orderPanel.Controls.Add(orderQuantityLabel, 0, 0);
            orderPanel.Controls.Add(orderQuantityPanel, 1, 0);
            orderPanel.Controls.Add(orderTotalLabel, 0, 1);
            orderPanel.Controls.Add(orderTotalPanel, 1, 1);
            orderPanel.Controls.Add(statusLabel, 0, 2);
            orderPanel.Controls.Add(statusPanel, 1, 2);
            orderPanel.Dock = DockStyle.Fill;
            orderPanel.Location = new Point(0, 27);
            orderPanel.Margin = new Padding(0);
            orderPanel.Name = "orderPanel";
            orderPanel.Padding = new Padding(4);
            orderPanel.RowCount = 3;
            orderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            orderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            orderPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            orderPanel.Size = new Size(624, 160);
            //
            // statusLabel
            //
            statusLabel.Location = new Point(5, 79);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(60, 76);
            statusLabel.Text = "Status";
            //
            // orderTotalPanel
            //
            orderTotalPanel.ColumnCount = 2;
            orderTotalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            orderTotalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            orderTotalPanel.Controls.Add(currencyLabel2, 1, 0);
            orderTotalPanel.Controls.Add(orderTotal, 0, 0);
            orderTotalPanel.Dock = DockStyle.Fill;
            orderTotalPanel.Location = new Point(69, 45);
            orderTotalPanel.Name = "orderTotalPanel";
            orderTotalPanel.RowCount = 1;
            orderTotalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            orderTotalPanel.Size = new Size(547, 30);
            //
            // currencyLabel2
            //
            currencyLabel2.Location = new Point(518, 0);
            currencyLabel2.Name = "currencyLabel2";
            currencyLabel2.Size = new Size(26, 30);
            currencyLabel2.Text = "€";
            //
            // orderTotal
            //
            orderTotal.AutoSize = true;
            orderTotal.Dock = DockStyle.Fill;
            orderTotal.Location = new Point(3, 0);
            orderTotal.Name = "orderTotal";
            orderTotal.Size = new Size(509, 30);
            orderTotal.Text = "0,00";
            orderTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // orderTotalLabel
            //
            orderTotalLabel.Location = new Point(5, 42);
            orderTotalLabel.Name = "orderTotalLabel";
            orderTotalLabel.Size = new Size(60, 36);
            orderTotalLabel.Text = "Total";
            //
            // orderQuantity
            //
            orderQuantity.Dock = DockStyle.Fill;
            orderQuantity.Location = new Point(3, 3);
            orderQuantity.Maximum = 100;
            orderQuantity.Minimum = 1;
            orderQuantity.Name = "orderQuantity";
            orderQuantity.Size = new Size(461, 24);
            orderQuantity.TabIndex = 5;
            orderQuantity.TickStyle = TickStyle.None;
            orderQuantity.Value = 1;
            orderQuantity.Scroll += new EventHandler(OrderQuantity_Scroll);
            //
            // orderQuantityInfo
            //
            orderQuantityInfo.Dock = DockStyle.Fill;
            orderQuantityInfo.Location = new Point(470, 0);
            orderQuantityInfo.Name = "orderQuantityInfo";
            orderQuantityInfo.Size = new Size(42, 30);
            orderQuantityInfo.Text = "1";
            orderQuantityInfo.TextAlign = ContentAlignment.MiddleRight;
            //
            // orderQuantityLabel
            //
            orderQuantityLabel.Location = new Point(5, 5);
            orderQuantityLabel.Name = "orderQuantityLabel";
            orderQuantityLabel.Size = new Size(60, 36);
            orderQuantityLabel.Text = "Quantity";
            //
            // orderQuantityPanel
            //
            orderQuantityPanel.ColumnCount = 3;
            orderQuantityPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            orderQuantityPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            orderQuantityPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            orderQuantityPanel.Controls.Add(unitLabel2, 0, 0);
            orderQuantityPanel.Controls.Add(orderQuantityInfo, 0, 0);
            orderQuantityPanel.Controls.Add(orderQuantity, 0, 0);
            orderQuantityPanel.Dock = DockStyle.Fill;
            orderQuantityPanel.Location = new Point(69, 8);
            orderQuantityPanel.Name = "orderQuantityPanel";
            orderQuantityPanel.RowCount = 1;
            orderQuantityPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            orderQuantityPanel.Size = new Size(547, 30);
            //
            // unitLabel2
            //
            unitLabel2.Location = new Point(518, 0);
            unitLabel2.Name = "unitLabel2";
            unitLabel2.Size = new Size(26, 30);
            unitLabel2.Text = "Un";
            //
            // statusPanel
            //
            statusPanel.Controls.Add(statusWaiting);
            statusPanel.Controls.Add(statusProcessing);
            statusPanel.Controls.Add(statusDispatched);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.FlowDirection = FlowDirection.TopDown;
            statusPanel.Location = new Point(69, 82);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(547, 70);
            //
            // statusWaiting
            //
            statusWaiting.Location = new Point(3, 3);
            statusWaiting.Name = "statusWaiting";
            statusWaiting.Size = new Size(113, 17);
            statusWaiting.TabIndex = 6;
            statusWaiting.Text = "Waiting Expedition";
            statusWaiting.CheckedChanged += new EventHandler(StatusWaiting_CheckedChanged);
            //
            // statusProcessing
            //
            statusProcessing.Checked = true;
            statusProcessing.Location = new Point(3, 26);
            statusProcessing.Name = "statusProcessing";
            statusProcessing.Size = new Size(106, 17);
            statusProcessing.TabIndex = 7;
            statusProcessing.Text = "Waiting Dispatch";
            statusProcessing.CheckedChanged += new EventHandler(StatusProcessing_CheckedChanged);
            //
            // statusDispatched
            //
            statusDispatched.Location = new Point(3, 49);
            statusDispatched.Name = "statusDispatched";
            statusDispatched.Size = new Size(114, 17);
            statusDispatched.TabIndex = 8;
            statusDispatched.Text = "Dispatch Complete";
            statusDispatched.CheckedChanged += new EventHandler(StatusDispatched_CheckedChanged);
            //
            // buttonPanel
            //
            buttonPanel.BackColor = SystemColors.ControlDark;
            buttonPanel.Controls.Add(buttonCancel);
            buttonPanel.Controls.Add(buttonConfirm);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonPanel.Location = new Point(0, 187);
            buttonPanel.Margin = new Padding(0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(2);
            buttonPanel.Size = new Size(624, 34);
            //
            // buttonCancel
            //
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(492, 5);
            buttonCancel.Margin = new Padding(2, 3, 0, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(128, 24);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += new EventHandler(ButtonCancel_Click);
            //
            // buttonConfirm
            //
            buttonConfirm.DialogResult = DialogResult.Cancel;
            buttonConfirm.Location = new Point(360, 5);
            buttonConfirm.Margin = new Padding(0, 3, 2, 3);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(128, 24);
            buttonConfirm.TabIndex = 0;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.Click += new EventHandler(ButtonConfirm_Click);
            //
            // orderLabel
            //
            orderLabel.Location = new Point(2, 2);
            orderLabel.Name = "orderLabel";
            orderLabel.Size = new Size(620, 23);
            orderLabel.Text = "Order";
            //
            // OrderForm
            //
            AcceptButton = buttonConfirm;
            CancelButton = buttonCancel;
            ClientSize = new Size(624, 381);
            Controls.Add(formPanel2);
            Controls.Add(formPanel1);
            Name = "OrderForm";
            Text = "Place Order";
            Load += new EventHandler(OrderForm_Load);
            formPanel1.ResumeLayout(false);
            formPanel1.PerformLayout();
            bookPanel.ResumeLayout(false);
            bookPanel.PerformLayout();
            bookPricePanel.ResumeLayout(false);
            bookPricePanel.PerformLayout();
            bookStockPanel.ResumeLayout(false);
            bookStockPanel.PerformLayout();
            customerPanel.ResumeLayout(false);
            customerPanel.PerformLayout();
            customerNamePanel.ResumeLayout(false);
            formPanel2.ResumeLayout(false);
            formPanel2.PerformLayout();
            orderPanel.ResumeLayout(false);
            orderPanel.PerformLayout();
            orderTotalPanel.ResumeLayout(false);
            orderTotalPanel.PerformLayout();
            orderQuantityPanel.ResumeLayout(false);
            orderQuantityPanel.PerformLayout();
            orderQuantity.EndInit();
            statusPanel.ResumeLayout(false);
            statusPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel formPanel1;
        private FlatHeader customerLabel;
        private FlatHeader bookLabel;
        private TableLayoutPanel customerPanel;
        private FlatLabel customerLocationLabel;
        private FlatLabel customerGuidLabel;
        private FlatLabel customerNameLabel;
        private FlatLabel customerEmailLabel;
        private TextBox customerGuid;
        private TableLayoutPanel bookPanel;
        private FlatLabel bookGuidLabel;
        private FlatLabel bookTitleLabel;
        private FlatLabel bookStockLabel;
        private FlatLabel bookPriceLabel;
        private TextBox bookGuid;
        private TableLayoutPanel bookStockPanel;
        private FlatBadge unitLabel1;
        private TableLayoutPanel bookPricePanel;
        private FlatBadge currencyLabel1;
        private Label bookStock;
        private Label bookPrice;
        private ComboBox bookTitle;
        private Label customerEmail;
        private Label customerLocation;
        private TableLayoutPanel formPanel2;
        private FlatHeader orderLabel;
        private TableLayoutPanel orderPanel;
        private TableLayoutPanel orderTotalPanel;
        private FlatBadge currencyLabel2;
        private Label orderTotal;
        private FlatLabel orderTotalLabel;
        private FlatLabel orderQuantityLabel;
        private TableLayoutPanel orderQuantityPanel;
        private FlatBadge unitLabel2;
        private Label orderQuantityInfo;
        private TrackBar orderQuantity;
        private FlatLabel statusLabel;
        private FlowLayoutPanel statusPanel;
        private RadioButton statusWaiting;
        private RadioButton statusProcessing;
        private RadioButton statusDispatched;
        private FlowLayoutPanel buttonPanel;
        private FlatButton buttonCancel;
        private FlatButton buttonConfirm;
        private FlowLayoutPanel customerNamePanel;
        private ComboBox customerName;
        private Button customerNameButton;
    }
}