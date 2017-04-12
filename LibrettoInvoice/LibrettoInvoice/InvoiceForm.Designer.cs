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
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bookTitle = new System.Windows.Forms.Label();
            this.bookGuid = new System.Windows.Forms.Label();
            this.bookTitleLabel = new System.Windows.Forms.Label();
            this.bookGuidLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerGuidLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.customerGuid = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.purchaseDate = new System.Windows.Forms.Label();
            this.purchaseDateLabel = new System.Windows.Forms.Label();
            this.purchaseTotal = new System.Windows.Forms.Label();
            this.purchaseTitle = new System.Windows.Forms.Label();
            this.purchaseQuantity = new System.Windows.Forms.Label();
            this.purchaseQuantityLabel = new System.Windows.Forms.Label();
            this.purchaseTitleLabel = new System.Windows.Forms.Label();
            this.purchaseTotalLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 122);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(420, 122);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Libretto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rua Dr. Roberto Frias, s/n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Libretto.Properties.Resources.librettoPadding;
            this.pictureBox1.Location = new System.Drawing.Point(291, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel3.SetRowSpan(this.pictureBox1, 4);
            this.pictureBox1.Size = new System.Drawing.Size(126, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.45098F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.54902F));
            this.tableLayoutPanel4.Controls.Add(this.bookTitle, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.bookGuid, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.bookTitleLabel, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.bookGuidLabel, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.customerNameLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.customerGuidLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.customerGuid, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.customerName, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(7, 135);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(420, 167);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // bookTitle
            // 
            this.bookTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bookTitle.AutoSize = true;
            this.bookTitle.Location = new System.Drawing.Point(119, 145);
            this.bookTitle.Name = "bookTitle";
            this.bookTitle.Size = new System.Drawing.Size(297, 13);
            this.bookTitle.TabIndex = 14;
            this.bookTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bookGuid
            // 
            this.bookGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bookGuid.AutoSize = true;
            this.bookGuid.Location = new System.Drawing.Point(119, 116);
            this.bookGuid.Name = "bookGuid";
            this.bookGuid.Size = new System.Drawing.Size(297, 13);
            this.bookGuid.TabIndex = 13;
            this.bookGuid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bookTitleLabel
            // 
            this.bookTitleLabel.AutoSize = true;
            this.bookTitleLabel.BackColor = System.Drawing.Color.LightGray;
            this.bookTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookTitleLabel.Location = new System.Drawing.Point(1, 138);
            this.bookTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.bookTitleLabel.Name = "bookTitleLabel";
            this.bookTitleLabel.Size = new System.Drawing.Size(114, 28);
            this.bookTitleLabel.TabIndex = 10;
            this.bookTitleLabel.Text = "Title";
            this.bookTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookGuidLabel
            // 
            this.bookGuidLabel.AutoSize = true;
            this.bookGuidLabel.BackColor = System.Drawing.Color.LightGray;
            this.bookGuidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookGuidLabel.Location = new System.Drawing.Point(1, 109);
            this.bookGuidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.bookGuidLabel.Name = "bookGuidLabel";
            this.bookGuidLabel.Size = new System.Drawing.Size(114, 28);
            this.bookGuidLabel.TabIndex = 8;
            this.bookGuidLabel.Text = "Identifier";
            this.bookGuidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.BackColor = System.Drawing.Color.LightGray;
            this.customerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerNameLabel.Location = new System.Drawing.Point(1, 55);
            this.customerNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(114, 28);
            this.customerNameLabel.TabIndex = 3;
            this.customerNameLabel.Text = "Name";
            this.customerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerGuidLabel
            // 
            this.customerGuidLabel.AutoSize = true;
            this.customerGuidLabel.BackColor = System.Drawing.Color.LightGray;
            this.customerGuidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerGuidLabel.Location = new System.Drawing.Point(1, 26);
            this.customerGuidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerGuidLabel.Name = "customerGuidLabel";
            this.customerGuidLabel.Size = new System.Drawing.Size(114, 28);
            this.customerGuidLabel.TabIndex = 0;
            this.customerGuidLabel.Text = "Identifier";
            this.customerGuidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label11, 2);
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(1, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(418, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "Customer";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(1, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(418, 24);
            this.label8.TabIndex = 5;
            this.label8.Text = "Book";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerGuid
            // 
            this.customerGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customerGuid.AutoSize = true;
            this.customerGuid.Location = new System.Drawing.Point(119, 33);
            this.customerGuid.Name = "customerGuid";
            this.customerGuid.Size = new System.Drawing.Size(297, 13);
            this.customerGuid.TabIndex = 11;
            this.customerGuid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customerName
            // 
            this.customerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customerName.AutoSize = true;
            this.customerName.Location = new System.Drawing.Point(118, 62);
            this.customerName.Margin = new System.Windows.Forms.Padding(2);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(299, 13);
            this.customerName.TabIndex = 12;
            this.customerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(434, 443);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.purchaseDate, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.purchaseDateLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.purchaseTotal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.purchaseQuantity, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.purchaseQuantityLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.purchaseTitleLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.purchaseTotalLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.purchaseTitle, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 308);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 130);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // purchaseDate
            // 
            this.purchaseDate.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.purchaseDate, 3);
            this.purchaseDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseDate.Location = new System.Drawing.Point(4, 103);
            this.purchaseDate.Name = "purchaseDate";
            this.purchaseDate.Size = new System.Drawing.Size(412, 26);
            this.purchaseDate.TabIndex = 17;
            this.purchaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseDateLabel
            // 
            this.purchaseDateLabel.AutoSize = true;
            this.purchaseDateLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.purchaseDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.purchaseDateLabel, 3);
            this.purchaseDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseDateLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.purchaseDateLabel.Location = new System.Drawing.Point(1, 78);
            this.purchaseDateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseDateLabel.Name = "purchaseDateLabel";
            this.purchaseDateLabel.Size = new System.Drawing.Size(418, 24);
            this.purchaseDateLabel.TabIndex = 16;
            this.purchaseDateLabel.Text = "Date";
            this.purchaseDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseTotal
            // 
            this.purchaseTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseTotal.AutoSize = true;
            this.purchaseTotal.Location = new System.Drawing.Point(296, 57);
            this.purchaseTotal.Name = "purchaseTotal";
            this.purchaseTotal.Size = new System.Drawing.Size(120, 13);
            this.purchaseTotal.TabIndex = 15;
            this.purchaseTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseTitle
            // 
            this.purchaseTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseTitle.AutoSize = true;
            this.purchaseTitle.Location = new System.Drawing.Point(129, 57);
            this.purchaseTitle.Name = "purchaseTitle";
            this.purchaseTitle.Size = new System.Drawing.Size(160, 13);
            this.purchaseTitle.TabIndex = 13;
            this.purchaseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseQuantity
            // 
            this.purchaseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseQuantity.AutoSize = true;
            this.purchaseQuantity.Location = new System.Drawing.Point(4, 57);
            this.purchaseQuantity.Name = "purchaseQuantity";
            this.purchaseQuantity.Size = new System.Drawing.Size(118, 13);
            this.purchaseQuantity.TabIndex = 12;
            this.purchaseQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseQuantityLabel
            // 
            this.purchaseQuantityLabel.AutoSize = true;
            this.purchaseQuantityLabel.BackColor = System.Drawing.Color.LightGray;
            this.purchaseQuantityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseQuantityLabel.Location = new System.Drawing.Point(1, 26);
            this.purchaseQuantityLabel.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseQuantityLabel.Name = "purchaseQuantityLabel";
            this.purchaseQuantityLabel.Size = new System.Drawing.Size(124, 24);
            this.purchaseQuantityLabel.TabIndex = 0;
            this.purchaseQuantityLabel.Text = "Quantity";
            this.purchaseQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseTitleLabel
            // 
            this.purchaseTitleLabel.AutoSize = true;
            this.purchaseTitleLabel.BackColor = System.Drawing.Color.LightGray;
            this.purchaseTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseTitleLabel.Location = new System.Drawing.Point(126, 26);
            this.purchaseTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseTitleLabel.Name = "purchaseTitleLabel";
            this.purchaseTitleLabel.Size = new System.Drawing.Size(166, 24);
            this.purchaseTitleLabel.TabIndex = 1;
            this.purchaseTitleLabel.Text = "Status";
            this.purchaseTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseTotalLabel
            // 
            this.purchaseTotalLabel.AutoSize = true;
            this.purchaseTotalLabel.BackColor = System.Drawing.Color.LightGray;
            this.purchaseTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseTotalLabel.Location = new System.Drawing.Point(293, 26);
            this.purchaseTotalLabel.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseTotalLabel.Name = "purchaseTotalLabel";
            this.purchaseTotalLabel.Size = new System.Drawing.Size(126, 24);
            this.purchaseTotalLabel.TabIndex = 3;
            this.purchaseTotalLabel.Text = "Total";
            this.purchaseTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label17, 3);
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Gainsboro;
            this.label17.Location = new System.Drawing.Point(1, 1);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(418, 24);
            this.label17.TabIndex = 4;
            this.label17.Text = "Transaction";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(434, 443);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = Properties.Resources.librettoIcon;
            this.MaximizeBox = false;
            this.Name = "InvoiceForm";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label bookTitle;
        private System.Windows.Forms.Label bookGuid;
        private System.Windows.Forms.Label bookTitleLabel;
        private System.Windows.Forms.Label bookGuidLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerGuidLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label customerGuid;
        private System.Windows.Forms.Label customerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label purchaseQuantityLabel;
        private System.Windows.Forms.Label purchaseTitleLabel;
        private System.Windows.Forms.Label purchaseTotalLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label purchaseDateLabel;
        private System.Windows.Forms.Label purchaseTotal;
        private System.Windows.Forms.Label purchaseTitle;
        private System.Windows.Forms.Label purchaseQuantity;
        private System.Windows.Forms.Label purchaseDate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}