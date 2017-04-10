namespace Libretto.Forms
{
    partial class PurchaseForm
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.itemLayout = new System.Windows.Forms.TableLayoutPanel();
            this.itemStockLabel = new System.Windows.Forms.Label();
            this.itemGuidLabel = new System.Windows.Forms.Label();
            this.itemDescriptionLabel = new System.Windows.Forms.Label();
            this.itemPriceLabel = new System.Windows.Forms.Label();
            this.itemGuid = new System.Windows.Forms.TextBox();
            this.itemDescription = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel1 = new System.Windows.Forms.Label();
            this.itemPrice = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.unitLabel1 = new System.Windows.Forms.Label();
            this.itemStock = new System.Windows.Forms.Label();
            this.customerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.customerLocationLabel = new System.Windows.Forms.Label();
            this.customerGuidLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerEmailLabel = new System.Windows.Forms.Label();
            this.customerGuid = new System.Windows.Forms.TextBox();
            this.customerEmail = new System.Windows.Forms.Label();
            this.customerLocation = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.customerName = new System.Windows.Forms.ComboBox();
            this.customerNameButton = new System.Windows.Forms.Button();
            this.customerLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.purchaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.purchaseQuantityLabel = new System.Windows.Forms.Label();
            this.purchaseTotalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel2 = new System.Windows.Forms.Label();
            this.purchaseTotal = new System.Windows.Forms.Label();
            this.purchaseTotalLabel = new System.Windows.Forms.Label();
            this.purchaseQuantityLayout = new System.Windows.Forms.TableLayoutPanel();
            this.unitLabel2 = new System.Windows.Forms.Label();
            this.purchaseQuantityInfo = new System.Windows.Forms.Label();
            this.purchaseQuantity = new System.Windows.Forms.TrackBar();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.purchaseLabel = new System.Windows.Forms.Label();
            this.tableLayout.SuspendLayout();
            this.itemLayout.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.customerLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.purchaseLayout.SuspendLayout();
            this.purchaseTotalLayout.SuspendLayout();
            this.purchaseQuantityLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseQuantity)).BeginInit();
            this.buttonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.itemLayout, 1, 1);
            this.tableLayout.Controls.Add(this.customerLayout, 0, 1);
            this.tableLayout.Controls.Add(this.customerLabel, 0, 0);
            this.tableLayout.Controls.Add(this.itemLabel, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(624, 160);
            this.tableLayout.TabIndex = 10;
            // 
            // itemLayout
            // 
            this.itemLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.itemLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.itemLayout.ColumnCount = 2;
            this.itemLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.itemLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemLayout.Controls.Add(this.itemStockLabel, 0, 3);
            this.itemLayout.Controls.Add(this.itemGuidLabel, 0, 0);
            this.itemLayout.Controls.Add(this.itemDescriptionLabel, 0, 1);
            this.itemLayout.Controls.Add(this.itemPriceLabel, 0, 2);
            this.itemLayout.Controls.Add(this.itemGuid, 1, 0);
            this.itemLayout.Controls.Add(this.itemDescription, 1, 1);
            this.itemLayout.Controls.Add(this.tableLayoutPanel5, 1, 2);
            this.itemLayout.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.itemLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemLayout.Location = new System.Drawing.Point(312, 27);
            this.itemLayout.Margin = new System.Windows.Forms.Padding(0);
            this.itemLayout.Name = "itemLayout";
            this.itemLayout.Padding = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.itemLayout.RowCount = 4;
            this.itemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemLayout.Size = new System.Drawing.Size(312, 133);
            this.itemLayout.TabIndex = 7;
            // 
            // itemStockLabel
            // 
            this.itemStockLabel.AutoSize = true;
            this.itemStockLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.itemStockLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemStockLabel.Location = new System.Drawing.Point(3, 98);
            this.itemStockLabel.Margin = new System.Windows.Forms.Padding(0);
            this.itemStockLabel.Name = "itemStockLabel";
            this.itemStockLabel.Size = new System.Drawing.Size(60, 30);
            this.itemStockLabel.TabIndex = 5;
            this.itemStockLabel.Text = "Stock";
            this.itemStockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemGuidLabel
            // 
            this.itemGuidLabel.AutoSize = true;
            this.itemGuidLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.itemGuidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGuidLabel.Location = new System.Drawing.Point(3, 5);
            this.itemGuidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.itemGuidLabel.Name = "itemGuidLabel";
            this.itemGuidLabel.Size = new System.Drawing.Size(60, 30);
            this.itemGuidLabel.TabIndex = 2;
            this.itemGuidLabel.Text = "GUID";
            this.itemGuidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemDescriptionLabel
            // 
            this.itemDescriptionLabel.AutoSize = true;
            this.itemDescriptionLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.itemDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDescriptionLabel.Location = new System.Drawing.Point(3, 36);
            this.itemDescriptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.itemDescriptionLabel.Name = "itemDescriptionLabel";
            this.itemDescriptionLabel.Size = new System.Drawing.Size(60, 30);
            this.itemDescriptionLabel.TabIndex = 3;
            this.itemDescriptionLabel.Text = "Title";
            this.itemDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemPriceLabel
            // 
            this.itemPriceLabel.AutoSize = true;
            this.itemPriceLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.itemPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPriceLabel.Location = new System.Drawing.Point(3, 67);
            this.itemPriceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.itemPriceLabel.Name = "itemPriceLabel";
            this.itemPriceLabel.Size = new System.Drawing.Size(60, 30);
            this.itemPriceLabel.TabIndex = 4;
            this.itemPriceLabel.Text = "Price";
            this.itemPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemGuid
            // 
            this.itemGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.itemGuid.Enabled = false;
            this.itemGuid.Location = new System.Drawing.Point(68, 10);
            this.itemGuid.Margin = new System.Windows.Forms.Padding(4);
            this.itemGuid.Name = "itemGuid";
            this.itemGuid.ReadOnly = true;
            this.itemGuid.ShortcutsEnabled = false;
            this.itemGuid.Size = new System.Drawing.Size(235, 20);
            this.itemGuid.TabIndex = 1;
            // 
            // itemDescription
            // 
            this.itemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.itemDescription.FormattingEnabled = true;
            this.itemDescription.Location = new System.Drawing.Point(68, 40);
            this.itemDescription.Margin = new System.Windows.Forms.Padding(4);
            this.itemDescription.Name = "itemDescription";
            this.itemDescription.Size = new System.Drawing.Size(235, 21);
            this.itemDescription.TabIndex = 9;
            this.itemDescription.SelectedIndexChanged += new System.EventHandler(this.ComboBooks_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Controls.Add(this.currencyLabel1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.itemPrice, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(67, 70);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(237, 24);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // currencyLabel1
            // 
            this.currencyLabel1.AutoSize = true;
            this.currencyLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currencyLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyLabel1.Location = new System.Drawing.Point(208, 0);
            this.currencyLabel1.Name = "currencyLabel1";
            this.currencyLabel1.Size = new System.Drawing.Size(26, 24);
            this.currencyLabel1.TabIndex = 11;
            this.currencyLabel1.Text = "€";
            this.currencyLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemPrice
            // 
            this.itemPrice.AutoSize = true;
            this.itemPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPrice.Location = new System.Drawing.Point(3, 0);
            this.itemPrice.Name = "itemPrice";
            this.itemPrice.Size = new System.Drawing.Size(199, 24);
            this.itemPrice.TabIndex = 12;
            this.itemPrice.Text = "0,00";
            this.itemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.Controls.Add(this.unitLabel1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.itemStock, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(67, 101);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(237, 24);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // unitLabel1
            // 
            this.unitLabel1.AutoSize = true;
            this.unitLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel1.Location = new System.Drawing.Point(208, 0);
            this.unitLabel1.Name = "unitLabel1";
            this.unitLabel1.Size = new System.Drawing.Size(26, 24);
            this.unitLabel1.TabIndex = 5;
            this.unitLabel1.Text = "Un";
            this.unitLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemStock
            // 
            this.itemStock.AutoSize = true;
            this.itemStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemStock.Location = new System.Drawing.Point(3, 0);
            this.itemStock.Name = "itemStock";
            this.itemStock.Size = new System.Drawing.Size(199, 24);
            this.itemStock.TabIndex = 6;
            this.itemStock.Text = "0";
            this.itemStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // customerLayout
            // 
            this.customerLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.customerLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.customerLayout.ColumnCount = 2;
            this.customerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.customerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customerLayout.Controls.Add(this.customerLocationLabel, 0, 3);
            this.customerLayout.Controls.Add(this.customerGuidLabel, 0, 0);
            this.customerLayout.Controls.Add(this.customerNameLabel, 0, 1);
            this.customerLayout.Controls.Add(this.customerEmailLabel, 0, 2);
            this.customerLayout.Controls.Add(this.customerGuid, 1, 0);
            this.customerLayout.Controls.Add(this.customerEmail, 1, 2);
            this.customerLayout.Controls.Add(this.customerLocation, 1, 3);
            this.customerLayout.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.customerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLayout.Location = new System.Drawing.Point(0, 27);
            this.customerLayout.Margin = new System.Windows.Forms.Padding(0);
            this.customerLayout.Name = "customerLayout";
            this.customerLayout.Padding = new System.Windows.Forms.Padding(4, 4, 2, 4);
            this.customerLayout.RowCount = 4;
            this.customerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerLayout.Size = new System.Drawing.Size(312, 133);
            this.customerLayout.TabIndex = 6;
            // 
            // customerLocationLabel
            // 
            this.customerLocationLabel.AutoSize = true;
            this.customerLocationLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerLocationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLocationLabel.Location = new System.Drawing.Point(5, 98);
            this.customerLocationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerLocationLabel.Name = "customerLocationLabel";
            this.customerLocationLabel.Size = new System.Drawing.Size(60, 30);
            this.customerLocationLabel.TabIndex = 5;
            this.customerLocationLabel.Text = "Location";
            this.customerLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerGuidLabel
            // 
            this.customerGuidLabel.AutoSize = true;
            this.customerGuidLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerGuidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerGuidLabel.Location = new System.Drawing.Point(5, 5);
            this.customerGuidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerGuidLabel.Name = "customerGuidLabel";
            this.customerGuidLabel.Size = new System.Drawing.Size(60, 30);
            this.customerGuidLabel.TabIndex = 2;
            this.customerGuidLabel.Text = "GUID";
            this.customerGuidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerNameLabel.Location = new System.Drawing.Point(5, 36);
            this.customerNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(60, 30);
            this.customerNameLabel.TabIndex = 3;
            this.customerNameLabel.Text = "Name";
            this.customerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerEmailLabel
            // 
            this.customerEmailLabel.AutoSize = true;
            this.customerEmailLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.customerEmailLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerEmailLabel.Location = new System.Drawing.Point(5, 67);
            this.customerEmailLabel.Margin = new System.Windows.Forms.Padding(0);
            this.customerEmailLabel.Name = "customerEmailLabel";
            this.customerEmailLabel.Size = new System.Drawing.Size(60, 30);
            this.customerEmailLabel.TabIndex = 4;
            this.customerEmailLabel.Text = "E-mail";
            this.customerEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerGuid
            // 
            this.customerGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customerGuid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerGuid.Enabled = false;
            this.customerGuid.Location = new System.Drawing.Point(70, 10);
            this.customerGuid.Margin = new System.Windows.Forms.Padding(4);
            this.customerGuid.Name = "customerGuid";
            this.customerGuid.ReadOnly = true;
            this.customerGuid.ShortcutsEnabled = false;
            this.customerGuid.Size = new System.Drawing.Size(235, 20);
            this.customerGuid.TabIndex = 1;
            // 
            // customerEmail
            // 
            this.customerEmail.AutoSize = true;
            this.customerEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerEmail.Location = new System.Drawing.Point(70, 71);
            this.customerEmail.Margin = new System.Windows.Forms.Padding(4);
            this.customerEmail.Name = "customerEmail";
            this.customerEmail.Size = new System.Drawing.Size(235, 22);
            this.customerEmail.TabIndex = 10;
            this.customerEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customerLocation
            // 
            this.customerLocation.AutoSize = true;
            this.customerLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLocation.Location = new System.Drawing.Point(70, 102);
            this.customerLocation.Margin = new System.Windows.Forms.Padding(4);
            this.customerLocation.Name = "customerLocation";
            this.customerLocation.Size = new System.Drawing.Size(235, 22);
            this.customerLocation.TabIndex = 11;
            this.customerLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.customerName);
            this.flowLayoutPanel1.Controls.Add(this.customerNameButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(69, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(237, 24);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // customerName
            // 
            this.customerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customerName.FormattingEnabled = true;
            this.customerName.Location = new System.Drawing.Point(0, 1);
            this.customerName.Margin = new System.Windows.Forms.Padding(0);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(205, 21);
            this.customerName.TabIndex = 11;
            this.customerName.SelectedIndexChanged += new System.EventHandler(this.CustomerName_SelectedIndexChanged);
            // 
            // customerNameButton
            // 
            this.customerNameButton.Location = new System.Drawing.Point(205, 0);
            this.customerNameButton.Margin = new System.Windows.Forms.Padding(0);
            this.customerNameButton.Name = "customerNameButton";
            this.customerNameButton.Size = new System.Drawing.Size(32, 23);
            this.customerNameButton.TabIndex = 12;
            this.customerNameButton.Text = "...";
            this.customerNameButton.UseVisualStyleBackColor = true;
            this.customerNameButton.Click += new System.EventHandler(this.CustomerNameButton_Click);
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.ForeColor = System.Drawing.Color.Silver;
            this.customerLabel.Location = new System.Drawing.Point(2, 2);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(2);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(308, 23);
            this.customerLabel.TabIndex = 4;
            this.customerLabel.Text = "Customer";
            this.customerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.itemLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemLabel.ForeColor = System.Drawing.Color.Silver;
            this.itemLabel.Location = new System.Drawing.Point(314, 2);
            this.itemLabel.Margin = new System.Windows.Forms.Padding(2);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(308, 23);
            this.itemLabel.TabIndex = 5;
            this.itemLabel.Text = "Book";
            this.itemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.purchaseLayout, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonLayout, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.purchaseLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 160);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 143);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // purchaseLayout
            // 
            this.purchaseLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.purchaseLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.purchaseLayout.ColumnCount = 2;
            this.purchaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.purchaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseLayout.Controls.Add(this.purchaseQuantityLabel, 0, 0);
            this.purchaseLayout.Controls.Add(this.purchaseTotalLayout, 1, 1);
            this.purchaseLayout.Controls.Add(this.purchaseTotalLabel, 0, 1);
            this.purchaseLayout.Controls.Add(this.purchaseQuantityLayout, 1, 0);
            this.purchaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseLayout.Location = new System.Drawing.Point(0, 27);
            this.purchaseLayout.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseLayout.Name = "purchaseLayout";
            this.purchaseLayout.Padding = new System.Windows.Forms.Padding(4);
            this.purchaseLayout.RowCount = 2;
            this.purchaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.purchaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.purchaseLayout.Size = new System.Drawing.Size(624, 82);
            this.purchaseLayout.TabIndex = 9;
            // 
            // purchaseQuantityLabel
            // 
            this.purchaseQuantityLabel.AutoSize = true;
            this.purchaseQuantityLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.purchaseQuantityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseQuantityLabel.Location = new System.Drawing.Point(5, 5);
            this.purchaseQuantityLabel.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseQuantityLabel.Name = "purchaseQuantityLabel";
            this.purchaseQuantityLabel.Size = new System.Drawing.Size(60, 35);
            this.purchaseQuantityLabel.TabIndex = 22;
            this.purchaseQuantityLabel.Text = "Quantity";
            this.purchaseQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseTotalLayout
            // 
            this.purchaseTotalLayout.ColumnCount = 2;
            this.purchaseTotalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseTotalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.purchaseTotalLayout.Controls.Add(this.currencyLabel2, 1, 0);
            this.purchaseTotalLayout.Controls.Add(this.purchaseTotal, 0, 0);
            this.purchaseTotalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseTotalLayout.Location = new System.Drawing.Point(69, 44);
            this.purchaseTotalLayout.Name = "purchaseTotalLayout";
            this.purchaseTotalLayout.RowCount = 1;
            this.purchaseTotalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseTotalLayout.Size = new System.Drawing.Size(547, 30);
            this.purchaseTotalLayout.TabIndex = 21;
            // 
            // currencyLabel2
            // 
            this.currencyLabel2.AutoSize = true;
            this.currencyLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currencyLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyLabel2.Location = new System.Drawing.Point(518, 0);
            this.currencyLabel2.Name = "currencyLabel2";
            this.currencyLabel2.Size = new System.Drawing.Size(26, 30);
            this.currencyLabel2.TabIndex = 11;
            this.currencyLabel2.Text = "€";
            this.currencyLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseTotal
            // 
            this.purchaseTotal.AutoSize = true;
            this.purchaseTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseTotal.Location = new System.Drawing.Point(3, 0);
            this.purchaseTotal.Name = "purchaseTotal";
            this.purchaseTotal.Size = new System.Drawing.Size(509, 30);
            this.purchaseTotal.TabIndex = 12;
            this.purchaseTotal.Text = "0,00";
            this.purchaseTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchaseTotalLabel
            // 
            this.purchaseTotalLabel.AutoSize = true;
            this.purchaseTotalLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.purchaseTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseTotalLabel.Location = new System.Drawing.Point(5, 41);
            this.purchaseTotalLabel.Margin = new System.Windows.Forms.Padding(0);
            this.purchaseTotalLabel.Name = "purchaseTotalLabel";
            this.purchaseTotalLabel.Size = new System.Drawing.Size(60, 36);
            this.purchaseTotalLabel.TabIndex = 19;
            this.purchaseTotalLabel.Text = "Total";
            this.purchaseTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseQuantityLayout
            // 
            this.purchaseQuantityLayout.ColumnCount = 3;
            this.purchaseQuantityLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseQuantityLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.purchaseQuantityLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.purchaseQuantityLayout.Controls.Add(this.unitLabel2, 0, 0);
            this.purchaseQuantityLayout.Controls.Add(this.purchaseQuantityInfo, 0, 0);
            this.purchaseQuantityLayout.Controls.Add(this.purchaseQuantity, 0, 0);
            this.purchaseQuantityLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseQuantityLayout.Location = new System.Drawing.Point(69, 8);
            this.purchaseQuantityLayout.Name = "purchaseQuantityLayout";
            this.purchaseQuantityLayout.RowCount = 1;
            this.purchaseQuantityLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseQuantityLayout.Size = new System.Drawing.Size(547, 29);
            this.purchaseQuantityLayout.TabIndex = 7;
            // 
            // unitLabel2
            // 
            this.unitLabel2.AutoSize = true;
            this.unitLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel2.Location = new System.Drawing.Point(518, 0);
            this.unitLabel2.Name = "unitLabel2";
            this.unitLabel2.Size = new System.Drawing.Size(26, 29);
            this.unitLabel2.TabIndex = 18;
            this.unitLabel2.Text = "Un";
            this.unitLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchaseQuantityInfo
            // 
            this.purchaseQuantityInfo.AutoSize = true;
            this.purchaseQuantityInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseQuantityInfo.Location = new System.Drawing.Point(470, 0);
            this.purchaseQuantityInfo.Name = "purchaseQuantityInfo";
            this.purchaseQuantityInfo.Size = new System.Drawing.Size(42, 29);
            this.purchaseQuantityInfo.TabIndex = 17;
            this.purchaseQuantityInfo.Text = "1";
            this.purchaseQuantityInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchaseQuantity
            // 
            this.purchaseQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseQuantity.Location = new System.Drawing.Point(3, 3);
            this.purchaseQuantity.Minimum = 1;
            this.purchaseQuantity.Name = "purchaseQuantity";
            this.purchaseQuantity.Size = new System.Drawing.Size(461, 23);
            this.purchaseQuantity.TabIndex = 16;
            this.purchaseQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.purchaseQuantity.Value = 1;
            this.purchaseQuantity.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonLayout.Controls.Add(this.buttonCancel);
            this.buttonLayout.Controls.Add(this.buttonConfirm);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonLayout.Location = new System.Drawing.Point(0, 109);
            this.buttonLayout.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Padding = new System.Windows.Forms.Padding(2);
            this.buttonLayout.Size = new System.Drawing.Size(624, 34);
            this.buttonLayout.TabIndex = 8;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(492, 5);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(128, 24);
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
            this.buttonConfirm.Location = new System.Drawing.Point(360, 5);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(128, 24);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // purchaseLabel
            // 
            this.purchaseLabel.AutoSize = true;
            this.purchaseLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.purchaseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseLabel.ForeColor = System.Drawing.Color.Silver;
            this.purchaseLabel.Location = new System.Drawing.Point(2, 2);
            this.purchaseLabel.Margin = new System.Windows.Forms.Padding(2);
            this.purchaseLabel.Name = "purchaseLabel";
            this.purchaseLabel.Size = new System.Drawing.Size(620, 23);
            this.purchaseLabel.TabIndex = 5;
            this.purchaseLabel.Text = "Purchase";
            this.purchaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PurchaseForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(624, 303);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Purchase";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.itemLayout.ResumeLayout(false);
            this.itemLayout.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.customerLayout.ResumeLayout(false);
            this.customerLayout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.purchaseLayout.ResumeLayout(false);
            this.purchaseLayout.PerformLayout();
            this.purchaseTotalLayout.ResumeLayout(false);
            this.purchaseTotalLayout.PerformLayout();
            this.purchaseQuantityLayout.ResumeLayout(false);
            this.purchaseQuantityLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseQuantity)).EndInit();
            this.buttonLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.TableLayoutPanel customerLayout;
        private System.Windows.Forms.Label customerLocationLabel;
        private System.Windows.Forms.Label customerGuidLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerEmailLabel;
        private System.Windows.Forms.TextBox customerGuid;
        private System.Windows.Forms.TableLayoutPanel itemLayout;
        private System.Windows.Forms.Label itemGuidLabel;
        private System.Windows.Forms.Label itemDescriptionLabel;
        private System.Windows.Forms.TextBox itemGuid;
        private System.Windows.Forms.Label itemStockLabel;
        private System.Windows.Forms.Label itemPriceLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label unitLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label currencyLabel1;
        private System.Windows.Forms.Label itemStock;
        private System.Windows.Forms.Label itemPrice;
        private System.Windows.Forms.ComboBox itemDescription;
        private System.Windows.Forms.Label customerEmail;
        private System.Windows.Forms.Label customerLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label purchaseLabel;
        private System.Windows.Forms.TableLayoutPanel purchaseLayout;
        private System.Windows.Forms.TableLayoutPanel purchaseTotalLayout;
        private System.Windows.Forms.Label currencyLabel2;
        private System.Windows.Forms.Label purchaseTotal;
        private System.Windows.Forms.Label purchaseTotalLabel;
        private System.Windows.Forms.Label purchaseQuantityLabel;
        private System.Windows.Forms.TableLayoutPanel purchaseQuantityLayout;
        private System.Windows.Forms.Label unitLabel2;
        private System.Windows.Forms.Label purchaseQuantityInfo;
        private System.Windows.Forms.TrackBar purchaseQuantity;
        private System.Windows.Forms.FlowLayoutPanel buttonLayout;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox customerName;
        private System.Windows.Forms.Button customerNameButton;
    }
}