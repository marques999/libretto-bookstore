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
    internal partial class InvoiceForm
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
            invoiceTitle = new Label();
            invoiceCustomer = new Label();
            invoiceTitleLabel = new FlatLabel();
            invoiceCustomerLabel = new FlatLabel();
            invoiceIdentifierLabel = new FlatLabel();
            invoiceLabel = new Label();
            invoiceIdentifier = new Label();
            formPanel2 = new TableLayoutPanel();
            purchaseDate = new Label();
            purchaseDateLabel = new Label();
            purchaseTotal = new Label();
            purchaseQuantity = new Label();
            purchaseQuantityLabel = new FlatLabel();
            purchaseTitleLabel = new FlatLabel();
            purchaseTotalLabel = new FlatLabel();
            purchaseLabel = new Label();
            purchaseTitle = new Label();
            mainPanel = new TableLayoutPanel();
            headerPanel = new TableLayoutPanel();
            headerPostal = new Label();
            headerCompany = new Label();
            headerLocation = new Label();
            pictureBox = new PictureBox();
            formPanel1.SuspendLayout();
            formPanel2.SuspendLayout();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((ISupportInitialize)(pictureBox)).BeginInit();
            SuspendLayout();
            //
            // formPanel1
            //
            formPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            formPanel1.ColumnCount = 2;
            formPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            formPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            formPanel1.Controls.Add(invoiceTitle, 1, 3);
            formPanel1.Controls.Add(invoiceCustomer, 1, 2);
            formPanel1.Controls.Add(invoiceTitleLabel, 0, 3);
            formPanel1.Controls.Add(invoiceCustomerLabel, 0, 2);
            formPanel1.Controls.Add(invoiceIdentifierLabel, 0, 1);
            formPanel1.Controls.Add(invoiceLabel, 0, 0);
            formPanel1.Controls.Add(invoiceIdentifier, 1, 1);
            formPanel1.Dock = DockStyle.Top;
            formPanel1.Location = new Point(7, 103);
            formPanel1.Name = "formPanel1";
            formPanel1.RowCount = 4;
            formPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            formPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            formPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            formPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            formPanel1.Size = new Size(420, 122);
            //
            // invoiceTitle
            //
            invoiceTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            invoiceTitle.AutoSize = true;
            invoiceTitle.Location = new Point(109, 99);
            invoiceTitle.Name = "invoiceTitle";
            invoiceTitle.Size = new Size(307, 13);
            invoiceTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // invoiceCustomer
            //
            invoiceCustomer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            invoiceCustomer.AutoSize = true;
            invoiceCustomer.Location = new Point(109, 67);
            invoiceCustomer.Name = "invoiceCustomer";
            invoiceCustomer.Size = new Size(307, 13);
            invoiceCustomer.TextAlign = ContentAlignment.MiddleLeft;
            //
            // invoiceTitleLabel
            //
            invoiceTitleLabel.Location = new Point(1, 90);
            invoiceTitleLabel.Name = "invoiceTitleLabel";
            invoiceTitleLabel.Size = new Size(104, 31);
            invoiceTitleLabel.Text = "Book";
            //
            // invoiceCustomerLabel
            //
            invoiceCustomerLabel.Location = new Point(1, 58);
            invoiceCustomerLabel.Name = "invoiceCustomerLabel";
            invoiceCustomerLabel.Size = new Size(104, 31);
            invoiceCustomerLabel.Text = "Customer";
            //
            // invoiceIdentifierLabel
            //
            invoiceIdentifierLabel.Location = new Point(1, 26);
            invoiceIdentifierLabel.Name = "invoiceIdentifierLabel";
            invoiceIdentifierLabel.Size = new Size(104, 31);
            invoiceIdentifierLabel.Text = "Identifier";
            //
            // invoiceLabel
            //
            invoiceLabel.AutoSize = true;
            invoiceLabel.BackColor = SystemColors.ControlDark;
            invoiceLabel.BorderStyle = BorderStyle.FixedSingle;
            formPanel1.SetColumnSpan(invoiceLabel, 2);
            invoiceLabel.Dock = DockStyle.Fill;
            invoiceLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            invoiceLabel.ForeColor = Color.Gainsboro;
            invoiceLabel.Location = new Point(1, 1);
            invoiceLabel.Margin = new Padding(0);
            invoiceLabel.Name = "invoiceLabel";
            invoiceLabel.Size = new Size(418, 24);
            invoiceLabel.Text = "Invoice";
            invoiceLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // invoiceIdentifier
            //
            invoiceIdentifier.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            invoiceIdentifier.AutoSize = true;
            invoiceIdentifier.Location = new Point(108, 35);
            invoiceIdentifier.Name = "invoiceIdentifier";
            invoiceIdentifier.Size = new Size(309, 13);
            invoiceIdentifier.TextAlign = ContentAlignment.MiddleLeft;
            //
            // formPanel2
            //
            formPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            formPanel2.ColumnCount = 3;
            formPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            formPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            formPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            formPanel2.Controls.Add(purchaseDate, 0, 4);
            formPanel2.Controls.Add(purchaseDateLabel, 0, 3);
            formPanel2.Controls.Add(purchaseTotal, 2, 2);
            formPanel2.Controls.Add(purchaseQuantity, 0, 2);
            formPanel2.Controls.Add(purchaseQuantityLabel, 0, 1);
            formPanel2.Controls.Add(purchaseTitleLabel, 1, 1);
            formPanel2.Controls.Add(purchaseTotalLabel, 2, 1);
            formPanel2.Controls.Add(purchaseLabel, 0, 0);
            formPanel2.Controls.Add(purchaseTitle, 1, 2);
            formPanel2.Dock = DockStyle.Top;
            formPanel2.Location = new Point(7, 231);
            formPanel2.Name = "formPanel2";
            formPanel2.RowCount = 5;
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            formPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            formPanel2.Size = new Size(420, 130);
            //
            // purchaseDate
            //
            purchaseDate.AutoSize = true;
            formPanel2.SetColumnSpan(purchaseDate, 3);
            purchaseDate.Dock = DockStyle.Fill;
            purchaseDate.Location = new Point(4, 103);
            purchaseDate.Name = "purchaseDate";
            purchaseDate.Size = new Size(412, 26);
            purchaseDate.TextAlign = ContentAlignment.MiddleCenter;
            //
            // purchaseDateLabel
            //
            purchaseDateLabel.AutoSize = true;
            purchaseDateLabel.BackColor = SystemColors.ControlDark;
            purchaseDateLabel.BorderStyle = BorderStyle.FixedSingle;
            formPanel2.SetColumnSpan(purchaseDateLabel, 3);
            purchaseDateLabel.Dock = DockStyle.Fill;
            purchaseDateLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            purchaseDateLabel.ForeColor = Color.Gainsboro;
            purchaseDateLabel.Location = new Point(1, 78);
            purchaseDateLabel.Margin = new Padding(0);
            purchaseDateLabel.Name = "purchaseDateLabel";
            purchaseDateLabel.Size = new Size(418, 24);
            purchaseDateLabel.Text = "Date";
            purchaseDateLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // purchaseTotal
            //
            purchaseTotal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            purchaseTotal.AutoSize = true;
            purchaseTotal.Location = new Point(296, 57);
            purchaseTotal.Name = "purchaseTotal";
            purchaseTotal.Size = new Size(120, 13);
            purchaseTotal.TextAlign = ContentAlignment.MiddleCenter;
            //
            // purchaseQuantity
            //
            purchaseQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            purchaseQuantity.AutoSize = true;
            purchaseQuantity.Location = new Point(4, 57);
            purchaseQuantity.Name = "purchaseQuantity";
            purchaseQuantity.Size = new Size(118, 13);
            purchaseQuantity.TextAlign = ContentAlignment.MiddleCenter;
            //
            // purchaseQuantityLabel
            //
            purchaseQuantityLabel.Location = new Point(1, 26);
            purchaseQuantityLabel.Name = "purchaseQuantityLabel";
            purchaseQuantityLabel.Size = new Size(124, 24);
            purchaseQuantityLabel.Text = "Quantity";
            //
            // purchaseTitleLabel
            //
            purchaseTitleLabel.Location = new Point(126, 26);
            purchaseTitleLabel.Name = "purchaseTitleLabel";
            purchaseTitleLabel.Size = new Size(166, 24);
            purchaseTitleLabel.Text = "Status";
            //
            // purchaseTotalLabel
            //
            purchaseTotalLabel.Location = new Point(293, 26);
            purchaseTotalLabel.Name = "purchaseTotalLabel";
            purchaseTotalLabel.Size = new Size(126, 24);
            purchaseTotalLabel.Text = "Total";
            //
            // purchaseLabel
            //
            purchaseLabel.AutoSize = true;
            purchaseLabel.BackColor = SystemColors.ControlDark;
            purchaseLabel.BorderStyle = BorderStyle.FixedSingle;
            formPanel2.SetColumnSpan(purchaseLabel, 3);
            purchaseLabel.Dock = DockStyle.Fill;
            purchaseLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            purchaseLabel.ForeColor = Color.Gainsboro;
            purchaseLabel.Location = new Point(1, 1);
            purchaseLabel.Margin = new Padding(0);
            purchaseLabel.Name = "purchaseLabel";
            purchaseLabel.Size = new Size(418, 24);
            purchaseLabel.Text = "Transaction";
            purchaseLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // purchaseTitle
            //
            purchaseTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            purchaseTitle.AutoSize = true;
            purchaseTitle.Location = new Point(129, 57);
            purchaseTitle.Name = "purchaseTitle";
            purchaseTitle.Size = new Size(160, 13);
            purchaseTitle.Text = "Purchased";
            purchaseTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // mainPanel
            //
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainPanel.Controls.Add(headerPanel, 0, 0);
            mainPanel.Controls.Add(formPanel2, 0, 2);
            mainPanel.Controls.Add(formPanel1, 0, 1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(4);
            mainPanel.RowCount = 3;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainPanel.Size = new Size(434, 368);
            //
            // headerPanel
            //
            headerPanel.ColumnCount = 2;
            headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            headerPanel.Controls.Add(headerPostal, 0, 2);
            headerPanel.Controls.Add(headerCompany, 0, 0);
            headerPanel.Controls.Add(headerLocation, 0, 1);
            headerPanel.Controls.Add(pictureBox, 1, 0);
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.Location = new Point(7, 7);
            headerPanel.Name = "headerPanel";
            headerPanel.RowCount = 3;
            headerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            headerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            headerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            headerPanel.Size = new Size(420, 90);
            //
            // headerPostal
            //
            headerPostal.AutoSize = true;
            headerPostal.Dock = DockStyle.Fill;
            headerPostal.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerPostal.Location = new Point(3, 60);
            headerPostal.Name = "headerPostal";
            headerPostal.Size = new Size(318, 30);
            headerPostal.Text = "4200-391 Porto";
            //
            // headerCompany
            //
            headerCompany.AutoSize = true;
            headerCompany.Dock = DockStyle.Fill;
            headerCompany.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerCompany.Location = new Point(3, 0);
            headerCompany.Name = "headerCompany";
            headerCompany.Size = new Size(318, 30);
            headerCompany.Text = "Libretto";
            headerCompany.TextAlign = ContentAlignment.MiddleLeft;
            //
            // headerLocation
            //
            headerLocation.AutoSize = true;
            headerLocation.Dock = DockStyle.Fill;
            headerLocation.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLocation.Location = new Point(3, 30);
            headerLocation.Name = "headerLocation";
            headerLocation.Size = new Size(318, 30);
            headerLocation.Text = "Rua Dr. Roberto Frias, s/n";
            headerLocation.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pictureBox
            //
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = Resources.librettoPadding;
            pictureBox.Location = new Point(327, 3);
            pictureBox.Name = "pictureBox";
            headerPanel.SetRowSpan(pictureBox, 3);
            pictureBox.Size = new Size(90, 84);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            //
            // InvoiceForm
            //
            ClientSize = new Size(434, 368);
            Controls.Add(mainPanel);
            Name = "InvoiceForm";
            Text = "View Invoice";
            formPanel1.ResumeLayout(false);
            formPanel1.PerformLayout();
            formPanel2.ResumeLayout(false);
            formPanel2.PerformLayout();
            mainPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((ISupportInitialize)(pictureBox)).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel formPanel1;
        private Label invoiceTitle;
        private Label invoiceCustomer;
        private FlatLabel invoiceTitleLabel;
        private FlatLabel invoiceCustomerLabel;
        private FlatLabel invoiceIdentifierLabel;
        private Label invoiceLabel;
        private Label invoiceIdentifier;
        private TableLayoutPanel formPanel2;
        private Label purchaseDate;
        private Label purchaseDateLabel;
        private Label purchaseTotal;
        private Label purchaseQuantity;
        private FlatLabel purchaseQuantityLabel;
        private FlatLabel purchaseTitleLabel;
        private FlatLabel purchaseTotalLabel;
        private Label purchaseLabel;
        private Label purchaseTitle;
        private TableLayoutPanel mainPanel;
        private TableLayoutPanel headerPanel;
        private Label headerPostal;
        private Label headerCompany;
        private Label headerLocation;
        private PictureBox pictureBox;
    }
}