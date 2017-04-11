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
    internal partial class PurchaseForm
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
            customerLocationLabel = new FlatLabel();
            customerGuidLabel = new FlatLabel();
            customerNameLabel = new FlatLabel();
            customerEmailLabel = new FlatLabel();
            customerGuid = new TextBox();
            customerEmail = new Label();
            customerLocation = new Label();
            customerNamePanel = new FlowLayoutPanel();
            customerName = new ComboBox();
            customerNameButton = new Button();
            customerLabel = new FlatHeader();
            bookLabel = new FlatHeader();
            formPanel2 = new TableLayoutPanel();
            purchasePanel = new TableLayoutPanel();
            purchaseQuantityLabel = new FlatLabel();
            purchaseTotalPanel = new TableLayoutPanel();
            currencyLabel2 = new FlatBadge();
            purchaseTotal = new Label();
            purchaseTotalLabel = new FlatLabel();
            purchaseQuantityPanel = new TableLayoutPanel();
            unitLabel2 = new FlatBadge();
            purchaseQuantityInfo = new Label();
            purchaseQuantity = new TrackBar();
            buttonPanel = new FlowLayoutPanel();
            buttonCancel = new FlatButton();
            buttonConfirm = new FlatButton();
            purchaseLabel = new FlatHeader();
            formPanel1.SuspendLayout();
            bookPanel.SuspendLayout();
            bookPricePanel.SuspendLayout();
            bookStockPanel.SuspendLayout();
            customerPanel.SuspendLayout();
            customerNamePanel.SuspendLayout();
            formPanel2.SuspendLayout();
            purchasePanel.SuspendLayout();
            purchaseTotalPanel.SuspendLayout();
            purchaseQuantityPanel.SuspendLayout();
            ((ISupportInitialize)(purchaseQuantity)).BeginInit();
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
            // currencyLabel1
            //
            currencyLabel1.Location = new Point(208, 0);
            currencyLabel1.Name = "currencyLabel1";
            currencyLabel1.Size = new Size(26, 24);
            currencyLabel1.Text = "€";
            //
            // currencyLabel2
            //
            currencyLabel2.Location = new Point(518, 0);
            currencyLabel2.Name = "currencyLabel2";
            currencyLabel2.Size = new Size(26, 30);
            currencyLabel2.Text = "€";
            //
            // unitLabel1
            //
            unitLabel1.Location = new Point(208, 0);
            unitLabel1.Name = "unitLabel1";
            unitLabel1.Size = new Size(26, 24);
            unitLabel1.Text = "Un";
            //
            // unitLabel2
            //
            unitLabel2.Location = new Point(518, 0);
            unitLabel2.Name = "unitLabel2";
            unitLabel2.Size = new Size(26, 29);
            unitLabel2.Text = "Un";
            //
            // bookGuidLabel
            //
            bookGuidLabel.Location = new Point(3, 5);
            bookGuidLabel.Name = "bookGuidLabel";
            bookGuidLabel.Size = new Size(60, 30);
            bookGuidLabel.Text = "GUID";
            //
            // bookPriceLabel
            //
            bookPriceLabel.Location = new Point(3, 67);
            bookPriceLabel.Name = "bookPriceLabel";
            bookPriceLabel.Size = new Size(60, 30);
            bookPriceLabel.Text = "Price";
            //
            // bookStockLabel
            //
            bookStockLabel.Location = new Point(3, 98);
            bookStockLabel.Name = "bookStockLabel";
            bookStockLabel.Size = new Size(60, 30);
            bookStockLabel.Text = "Stock";
            //
            // bookTitleLabel
            //
            bookTitleLabel.Location = new Point(3, 36);
            bookTitleLabel.Name = "bookTitleLabel";
            bookTitleLabel.Size = new Size(60, 30);
            bookTitleLabel.Text = "Title";
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
            // bookPrice
            //
            bookPrice.Dock = DockStyle.Fill;
            bookPrice.Location = new Point(3, 0);
            bookPrice.Name = "bookPrice";
            bookPrice.Size = new Size(199, 24);
            bookPrice.Text = "0,00";
            bookPrice.TextAlign = ContentAlignment.MiddleRight;
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
            // bookTitle
            //
            bookTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bookTitle.DropDownStyle = ComboBoxStyle.DropDownList;
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
            formPanel2.Controls.Add(purchaseLabel, 0, 0);
            formPanel2.Controls.Add(purchasePanel, 0, 1);
            formPanel2.Controls.Add(buttonPanel, 0, 2);
            formPanel2.Dock = DockStyle.Fill;
            formPanel2.Location = new Point(0, 160);
            formPanel2.Name = "formPanel2";
            formPanel2.RowCount = 3;
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            formPanel2.Size = new Size(624, 143);
            //
            // purchasePanel
            //
            purchasePanel.BackColor = Color.Gainsboro;
            purchasePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            purchasePanel.ColumnCount = 2;
            purchasePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            purchasePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            purchasePanel.Controls.Add(purchaseQuantityLabel, 0, 0);
            purchasePanel.Controls.Add(purchaseQuantityPanel, 1, 0);
            purchasePanel.Controls.Add(purchaseTotalLabel, 0, 1);
            purchasePanel.Controls.Add(purchaseTotalPanel, 1, 1);
            purchasePanel.Dock = DockStyle.Fill;
            purchasePanel.Location = new Point(0, 27);
            purchasePanel.Margin = new Padding(0);
            purchasePanel.Name = "purchasePanel";
            purchasePanel.Padding = new Padding(4);
            purchasePanel.RowCount = 2;
            purchasePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            purchasePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            purchasePanel.Size = new Size(624, 82);
            //
            // purchaseQuantity
            //
            purchaseQuantity.Dock = DockStyle.Fill;
            purchaseQuantity.Location = new Point(3, 3);
            purchaseQuantity.Minimum = 1;
            purchaseQuantity.Name = "purchaseQuantity";
            purchaseQuantity.Size = new Size(461, 23);
            purchaseQuantity.TabIndex = 5;
            purchaseQuantity.TickStyle = TickStyle.None;
            purchaseQuantity.Value = 1;
            purchaseQuantity.Scroll += new EventHandler(PurchaseQuantity_Scroll);
            //
            // purchaseQuantityInfo
            //
            purchaseQuantityInfo.Dock = DockStyle.Fill;
            purchaseQuantityInfo.Location = new Point(470, 0);
            purchaseQuantityInfo.Name = "purchaseQuantityInfo";
            purchaseQuantityInfo.Size = new Size(42, 29);
            purchaseQuantityInfo.Text = "1";
            purchaseQuantityInfo.TextAlign = ContentAlignment.MiddleRight;
            //
            // purchaseQuantityLabel
            //
            purchaseQuantityLabel.Location = new Point(5, 5);
            purchaseQuantityLabel.Name = "purchaseQuantityLabel";
            purchaseQuantityLabel.Size = new Size(60, 35);
            purchaseQuantityLabel.Text = "Quantity";
            //
            // purchaseQuantityPanel
            //
            purchaseQuantityPanel.ColumnCount = 3;
            purchaseQuantityPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            purchaseQuantityPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            purchaseQuantityPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            purchaseQuantityPanel.Controls.Add(purchaseQuantity, 0, 0);
            purchaseQuantityPanel.Controls.Add(purchaseQuantityInfo, 1, 0);
            purchaseQuantityPanel.Controls.Add(unitLabel2, 2, 0);
            purchaseQuantityPanel.Dock = DockStyle.Fill;
            purchaseQuantityPanel.Location = new Point(69, 8);
            purchaseQuantityPanel.Name = "purchaseQuantityPanel";
            purchaseQuantityPanel.RowCount = 1;
            purchaseQuantityPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            purchaseQuantityPanel.Size = new Size(547, 29);
            //
            // purchaseTotal
            //
            purchaseTotal.Dock = DockStyle.Fill;
            purchaseTotal.Location = new Point(3, 0);
            purchaseTotal.Name = "purchaseTotal";
            purchaseTotal.Size = new Size(509, 30);
            purchaseTotal.Text = "0,00";
            purchaseTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // purchaseTotalLabel
            //
            purchaseTotalLabel.Location = new Point(5, 41);
            purchaseTotalLabel.Name = "purchaseTotalLabel";
            purchaseTotalLabel.Size = new Size(60, 36);
            purchaseTotalLabel.Text = "Total";
            //
            // purchaseTotalPanel
            //
            purchaseTotalPanel.ColumnCount = 2;
            purchaseTotalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            purchaseTotalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            purchaseTotalPanel.Controls.Add(purchaseTotal, 0, 0);
            purchaseTotalPanel.Controls.Add(currencyLabel2, 1, 0);
            purchaseTotalPanel.Dock = DockStyle.Fill;
            purchaseTotalPanel.Location = new Point(69, 44);
            purchaseTotalPanel.Name = "purchaseTotalPanel";
            purchaseTotalPanel.RowCount = 1;
            purchaseTotalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            purchaseTotalPanel.Size = new Size(547, 30);
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
            //
            // buttonConfirm
            //
            buttonConfirm.DialogResult = DialogResult.OK;
            buttonConfirm.Location = new Point(360, 5);
            buttonConfirm.Margin = new Padding(0, 3, 2, 3);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(128, 24);
            buttonConfirm.TabIndex = 0;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.Click += new EventHandler(ButtonConfirm_Click);
            //
            // buttonPanel
            //
            buttonPanel.BackColor = SystemColors.ControlDark;
            buttonPanel.Controls.Add(buttonCancel);
            buttonPanel.Controls.Add(buttonConfirm);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonPanel.Location = new Point(0, 109);
            buttonPanel.Margin = new Padding(0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(2);
            buttonPanel.Size = new Size(624, 34);
            //
            // purchaseLabel
            //
            purchaseLabel.Location = new Point(2, 2);
            purchaseLabel.Name = "purchaseLabel";
            purchaseLabel.Size = new Size(620, 23);
            purchaseLabel.Text = "Purchase";
            //
            // PurchaseForm
            //
            AcceptButton = buttonConfirm;
            CancelButton = buttonCancel;
            ClientSize = new Size(624, 303);
            Controls.Add(formPanel2);
            Controls.Add(formPanel1);
            Name = "PurchaseForm";
            Text = "Register Purchase";
            Load += new EventHandler(PurchaseForm_Load);
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
            purchasePanel.ResumeLayout(false);
            purchasePanel.PerformLayout();
            purchaseTotalPanel.ResumeLayout(false);
            purchaseTotalPanel.PerformLayout();
            purchaseQuantityPanel.ResumeLayout(false);
            purchaseQuantityPanel.PerformLayout();
            purchaseQuantity.EndInit();
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
        private FlatHeader purchaseLabel;
        private TableLayoutPanel purchasePanel;
        private TableLayoutPanel purchaseTotalPanel;
        private FlatBadge currencyLabel2;
        private Label purchaseTotal;
        private FlatLabel purchaseTotalLabel;
        private FlatLabel purchaseQuantityLabel;
        private TableLayoutPanel purchaseQuantityPanel;
        private FlatBadge unitLabel2;
        private Label purchaseQuantityInfo;
        private TrackBar purchaseQuantity;
        private FlowLayoutPanel buttonPanel;
        private FlatButton buttonCancel;
        private FlatButton buttonConfirm;
        private FlowLayoutPanel customerNamePanel;
        private ComboBox customerName;
        private Button customerNameButton;
    }
}