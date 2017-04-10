namespace Libretto.Forms
{
    partial class OrderForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bookStockLabel = new System.Windows.Forms.Label();
            this.bookIdLabel = new System.Windows.Forms.Label();
            this.bookTitleLabel = new System.Windows.Forms.Label();
            this.bookPriceLabel = new System.Windows.Forms.Label();
            this.bookIdField = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.fieldStock = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.fieldPrice = new System.Windows.Forms.Label();
            this.comboBooks = new System.Windows.Forms.ComboBox();
            this.customerLabel = new System.Windows.Forms.TableLayoutPanel();
            this.customerLocationLabel = new System.Windows.Forms.Label();
            this.customerGuidLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerEmailLabel = new System.Windows.Forms.Label();
            this.customerGuidField = new System.Windows.Forms.TextBox();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.customerEmailField = new System.Windows.Forms.Label();
            this.customerLocationField = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bookLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.fieldTotal = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.fieldQuantity = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.statusLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.orderLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.customerLabel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.statusLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.customerLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bookLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 160);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.45455F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.54545F));
            this.tableLayoutPanel3.Controls.Add(this.bookStockLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.bookIdLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.bookTitleLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.bookPriceLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.bookIdField, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBooks, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(312, 27);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(312, 133);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // bookStockLabel
            // 
            this.bookStockLabel.AutoSize = true;
            this.bookStockLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bookStockLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookStockLabel.Location = new System.Drawing.Point(8, 98);
            this.bookStockLabel.Name = "bookStockLabel";
            this.bookStockLabel.Size = new System.Drawing.Size(46, 30);
            this.bookStockLabel.TabIndex = 5;
            this.bookStockLabel.Text = "Stock";
            this.bookStockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookIdLabel
            // 
            this.bookIdLabel.AutoSize = true;
            this.bookIdLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bookIdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookIdLabel.Location = new System.Drawing.Point(8, 5);
            this.bookIdLabel.Name = "bookIdLabel";
            this.bookIdLabel.Size = new System.Drawing.Size(46, 30);
            this.bookIdLabel.TabIndex = 2;
            this.bookIdLabel.Text = "GUID";
            this.bookIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookTitleLabel
            // 
            this.bookTitleLabel.AutoSize = true;
            this.bookTitleLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bookTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookTitleLabel.Location = new System.Drawing.Point(8, 36);
            this.bookTitleLabel.Name = "bookTitleLabel";
            this.bookTitleLabel.Size = new System.Drawing.Size(46, 30);
            this.bookTitleLabel.TabIndex = 3;
            this.bookTitleLabel.Text = "Title";
            this.bookTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookPriceLabel
            // 
            this.bookPriceLabel.AutoSize = true;
            this.bookPriceLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bookPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookPriceLabel.Location = new System.Drawing.Point(8, 67);
            this.bookPriceLabel.Name = "bookPriceLabel";
            this.bookPriceLabel.Size = new System.Drawing.Size(46, 30);
            this.bookPriceLabel.TabIndex = 4;
            this.bookPriceLabel.Text = "Price";
            this.bookPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookIdField
            // 
            this.bookIdField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bookIdField.Enabled = false;
            this.bookIdField.Location = new System.Drawing.Point(62, 10);
            this.bookIdField.Margin = new System.Windows.Forms.Padding(4);
            this.bookIdField.Name = "bookIdField";
            this.bookIdField.ReadOnly = true;
            this.bookIdField.Size = new System.Drawing.Size(241, 20);
            this.bookIdField.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.fieldStock, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(61, 101);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(243, 24);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(214, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Un";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldStock
            // 
            this.fieldStock.AutoSize = true;
            this.fieldStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldStock.Location = new System.Drawing.Point(3, 0);
            this.fieldStock.Name = "fieldStock";
            this.fieldStock.Size = new System.Drawing.Size(205, 24);
            this.fieldStock.TabIndex = 6;
            this.fieldStock.Text = "0";
            this.fieldStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.fieldPrice, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(61, 70);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(243, 24);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(214, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "€";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldPrice
            // 
            this.fieldPrice.AutoSize = true;
            this.fieldPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPrice.Location = new System.Drawing.Point(3, 0);
            this.fieldPrice.Name = "fieldPrice";
            this.fieldPrice.Size = new System.Drawing.Size(205, 24);
            this.fieldPrice.TabIndex = 12;
            this.fieldPrice.Text = "0,00";
            this.fieldPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBooks
            // 
            this.comboBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBooks.FormattingEnabled = true;
            this.comboBooks.Location = new System.Drawing.Point(61, 39);
            this.comboBooks.Name = "comboBooks";
            this.comboBooks.Size = new System.Drawing.Size(243, 21);
            this.comboBooks.TabIndex = 9;
            this.comboBooks.SelectedIndexChanged += new System.EventHandler(this.ComboBooks_SelectedIndexChanged);
            // 
            // customerLabel
            // 
            this.customerLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.customerLabel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.customerLabel.ColumnCount = 2;
            this.customerLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.customerLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.customerLabel.Controls.Add(this.customerLocationLabel, 0, 3);
            this.customerLabel.Controls.Add(this.customerGuidLabel, 0, 0);
            this.customerLabel.Controls.Add(this.customerNameLabel, 0, 1);
            this.customerLabel.Controls.Add(this.customerEmailLabel, 0, 2);
            this.customerLabel.Controls.Add(this.customerGuidField, 1, 0);
            this.customerLabel.Controls.Add(this.customerCombo, 1, 1);
            this.customerLabel.Controls.Add(this.customerEmailField, 1, 2);
            this.customerLabel.Controls.Add(this.customerLocationField, 1, 3);
            this.customerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLabel.Location = new System.Drawing.Point(0, 27);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Padding = new System.Windows.Forms.Padding(4);
            this.customerLabel.RowCount = 4;
            this.customerLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLabel.Size = new System.Drawing.Size(312, 133);
            this.customerLabel.TabIndex = 6;
            // 
            // customerLocationLabel
            // 
            this.customerLocationLabel.AutoSize = true;
            this.customerLocationLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerLocationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLocationLabel.Location = new System.Drawing.Point(8, 98);
            this.customerLocationLabel.Name = "customerLocationLabel";
            this.customerLocationLabel.Size = new System.Drawing.Size(54, 30);
            this.customerLocationLabel.TabIndex = 5;
            this.customerLocationLabel.Text = "Location";
            this.customerLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerGuidLabel
            // 
            this.customerGuidLabel.AutoSize = true;
            this.customerGuidLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerGuidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerGuidLabel.Location = new System.Drawing.Point(8, 5);
            this.customerGuidLabel.Name = "customerGuidLabel";
            this.customerGuidLabel.Size = new System.Drawing.Size(54, 30);
            this.customerGuidLabel.TabIndex = 2;
            this.customerGuidLabel.Text = "GUID";
            this.customerGuidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerNameLabel.Location = new System.Drawing.Point(8, 36);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(54, 30);
            this.customerNameLabel.TabIndex = 3;
            this.customerNameLabel.Text = "Name";
            this.customerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerEmailLabel
            // 
            this.customerEmailLabel.AutoSize = true;
            this.customerEmailLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerEmailLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerEmailLabel.Location = new System.Drawing.Point(8, 67);
            this.customerEmailLabel.Name = "customerEmailLabel";
            this.customerEmailLabel.Size = new System.Drawing.Size(54, 30);
            this.customerEmailLabel.TabIndex = 4;
            this.customerEmailLabel.Text = "E-mail";
            this.customerEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerGuidField
            // 
            this.customerGuidField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customerGuidField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerGuidField.Enabled = false;
            this.customerGuidField.Location = new System.Drawing.Point(70, 10);
            this.customerGuidField.Margin = new System.Windows.Forms.Padding(4);
            this.customerGuidField.Name = "customerGuidField";
            this.customerGuidField.ReadOnly = true;
            this.customerGuidField.Size = new System.Drawing.Size(233, 20);
            this.customerGuidField.TabIndex = 1;
            // 
            // customerCombo
            // 
            this.customerCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(69, 39);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(235, 21);
            this.customerCombo.TabIndex = 9;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.ComboCustomers_SelectedIndexChanged);
            // 
            // customerEmailField
            // 
            this.customerEmailField.AutoSize = true;
            this.customerEmailField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerEmailField.Location = new System.Drawing.Point(69, 67);
            this.customerEmailField.Name = "customerEmailField";
            this.customerEmailField.Size = new System.Drawing.Size(235, 30);
            this.customerEmailField.TabIndex = 10;
            this.customerEmailField.Text = "Dummy";
            this.customerEmailField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customerLocationField
            // 
            this.customerLocationField.AutoSize = true;
            this.customerLocationField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLocationField.Location = new System.Drawing.Point(69, 98);
            this.customerLocationField.Name = "customerLocationField";
            this.customerLocationField.Size = new System.Drawing.Size(235, 30);
            this.customerLocationField.TabIndex = 11;
            this.customerLocationField.Text = "Dummy";
            this.customerLocationField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookLabel
            // 
            this.bookLabel.AutoSize = true;
            this.bookLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bookLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookLabel.ForeColor = System.Drawing.Color.Silver;
            this.bookLabel.Location = new System.Drawing.Point(314, 2);
            this.bookLabel.Margin = new System.Windows.Forms.Padding(2);
            this.bookLabel.Name = "bookLabel";
            this.bookLabel.Size = new System.Drawing.Size(308, 23);
            this.bookLabel.TabIndex = 5;
            this.bookLabel.Text = "Book";
            this.bookLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonLayout, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.orderLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 160);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 221);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.statusLabel, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel9, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.statusLayout, 1, 2);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(624, 160);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Location = new System.Drawing.Point(8, 79);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(46, 76);
            this.statusLabel.TabIndex = 23;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(8, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 36);
            this.label11.TabIndex = 22;
            this.label11.Text = "Quantity";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel9.Controls.Add(this.label22, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.fieldTotal, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(61, 45);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(555, 30);
            this.tableLayoutPanel9.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(526, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 30);
            this.label22.TabIndex = 11;
            this.label22.Text = "€";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldTotal
            // 
            this.fieldTotal.AutoSize = true;
            this.fieldTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldTotal.Location = new System.Drawing.Point(3, 0);
            this.fieldTotal.Name = "fieldTotal";
            this.fieldTotal.Size = new System.Drawing.Size(517, 30);
            this.fieldTotal.TabIndex = 12;
            this.fieldTotal.Text = "0,00";
            this.fieldTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(8, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 36);
            this.label16.TabIndex = 19;
            this.label16.Text = "Total";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel7.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.fieldQuantity, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.trackBar1, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(61, 8);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(555, 30);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(526, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 30);
            this.label17.TabIndex = 18;
            this.label17.Text = "Un";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldQuantity
            // 
            this.fieldQuantity.AutoSize = true;
            this.fieldQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldQuantity.Location = new System.Drawing.Point(478, 0);
            this.fieldQuantity.Name = "fieldQuantity";
            this.fieldQuantity.Size = new System.Drawing.Size(42, 30);
            this.fieldQuantity.TabIndex = 17;
            this.fieldQuantity.Text = "1";
            this.fieldQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(469, 24);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // statusLayout
            // 
            this.statusLayout.Controls.Add(this.radioButton1);
            this.statusLayout.Controls.Add(this.radioButton2);
            this.statusLayout.Controls.Add(this.radioButton3);
            this.statusLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.statusLayout.Location = new System.Drawing.Point(61, 82);
            this.statusLayout.Name = "statusLayout";
            this.statusLayout.Size = new System.Drawing.Size(555, 70);
            this.statusLayout.TabIndex = 24;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(113, 17);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.Text = "Waiting Expedition";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 17);
            this.radioButton2.TabIndex = 26;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Waiting Dispatch";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 49);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(114, 17);
            this.radioButton3.TabIndex = 27;
            this.radioButton3.Text = "Dispatch Complete";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonLayout.Controls.Add(this.buttonCancel);
            this.buttonLayout.Controls.Add(this.buttonConfirm);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonLayout.Location = new System.Drawing.Point(0, 187);
            this.buttonLayout.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Padding = new System.Windows.Forms.Padding(2);
            this.buttonLayout.Size = new System.Drawing.Size(624, 34);
            this.buttonLayout.TabIndex = 8;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(485, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 24);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConfirm.Enabled = false;
            this.buttonConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Location = new System.Drawing.Point(347, 5);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(132, 24);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.orderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderLabel.ForeColor = System.Drawing.Color.Silver;
            this.orderLabel.Location = new System.Drawing.Point(2, 2);
            this.orderLabel.Margin = new System.Windows.Forms.Padding(2);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(620, 23);
            this.orderLabel.TabIndex = 5;
            this.orderLabel.Text = "Order";
            this.orderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Place Order";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.customerLabel.ResumeLayout(false);
            this.customerLabel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.statusLayout.ResumeLayout(false);
            this.statusLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bookLabel;
        private System.Windows.Forms.TableLayoutPanel customerLabel;
        private System.Windows.Forms.Label customerLocationLabel;
        private System.Windows.Forms.Label customerGuidLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerEmailLabel;
        private System.Windows.Forms.TextBox customerGuidField;
        private System.Windows.Forms.ComboBox customerCombo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label bookIdLabel;
        private System.Windows.Forms.Label bookTitleLabel;
        private System.Windows.Forms.TextBox bookIdField;
        private System.Windows.Forms.Label bookStockLabel;
        private System.Windows.Forms.Label bookPriceLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label fieldStock;
        private System.Windows.Forms.Label fieldPrice;
        private System.Windows.Forms.ComboBox comboBooks;
        private System.Windows.Forms.Label customerEmailField;
        private System.Windows.Forms.Label customerLocationField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label fieldTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label fieldQuantity;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.FlowLayoutPanel statusLayout;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.FlowLayoutPanel buttonLayout;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
    }
}