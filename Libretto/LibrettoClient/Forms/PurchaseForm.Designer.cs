namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class PurchaseForm
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
            this.itemPanel = new System.Windows.Forms.TableLayoutPanel();
            this.itemStockLabel = new System.Windows.Forms.Label();
            this.itemGuidLabel = new System.Windows.Forms.Label();
            this.itemDescriptionLabel = new System.Windows.Forms.Label();
            this.itemPriceLabel = new System.Windows.Forms.Label();
            this.itemGuid = new System.Windows.Forms.TextBox();
            this.itemDescription = new System.Windows.Forms.ComboBox();
            this.itemPricePanel = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel1 = new System.Windows.Forms.Label();
            this.itemPrice = new System.Windows.Forms.Label();
            this.itemStockPanel = new System.Windows.Forms.TableLayoutPanel();
            this.unitLabel1 = new System.Windows.Forms.Label();
            this.itemStock = new System.Windows.Forms.Label();
            this.customerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customerLocationLabel = new System.Windows.Forms.Label();
            this.customerGuidLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerEmailLabel = new System.Windows.Forms.Label();
            this.customerGuid = new System.Windows.Forms.TextBox();
            this.customerEmail = new System.Windows.Forms.Label();
            this.customerLocation = new System.Windows.Forms.Label();
            this.customerNamePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.customerName = new System.Windows.Forms.ComboBox();
            this.customerNameButton = new System.Windows.Forms.Button();
            this.customerLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.purchasePanel = new System.Windows.Forms.TableLayoutPanel();
            this.purchaseQuantityLabel = new System.Windows.Forms.Label();
            this.purchaseTotalPanel = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel2 = new System.Windows.Forms.Label();
            this.purchaseTotal = new System.Windows.Forms.Label();
            this.purchaseTotalLabel = new System.Windows.Forms.Label();
            this.purchaseQuantityPanel = new System.Windows.Forms.TableLayoutPanel();
            this.unitLabel2 = new System.Windows.Forms.Label();
            this.purchaseQuantityInfo = new System.Windows.Forms.Label();
            this.purchaseQuantity = new System.Windows.Forms.TrackBar();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.purchaseLabel = new System.Windows.Forms.Label();
            this.tableLayout.SuspendLayout();
            this.itemPanel.SuspendLayout();
            this.itemPricePanel.SuspendLayout();
            this.itemStockPanel.SuspendLayout();
            this.customerPanel.SuspendLayout();
            this.customerNamePanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.purchasePanel.SuspendLayout();
            this.purchaseTotalPanel.SuspendLayout();
            this.purchaseQuantityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseQuantity)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.itemPanel, 1, 1);
            this.tableLayout.Controls.Add(this.customerPanel, 0, 1);
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
            // itemPanel
            // 
            this.itemPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.itemPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.itemPanel.ColumnCount = 2;
            this.itemPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.itemPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemPanel.Controls.Add(this.itemStockLabel, 0, 3);
            this.itemPanel.Controls.Add(this.itemGuidLabel, 0, 0);
            this.itemPanel.Controls.Add(this.itemDescriptionLabel, 0, 1);
            this.itemPanel.Controls.Add(this.itemPriceLabel, 0, 2);
            this.itemPanel.Controls.Add(this.itemGuid, 1, 0);
            this.itemPanel.Controls.Add(this.itemDescription, 1, 1);
            this.itemPanel.Controls.Add(this.itemPricePanel, 1, 2);
            this.itemPanel.Controls.Add(this.itemStockPanel, 1, 3);
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel.Location = new System.Drawing.Point(312, 27);
            this.itemPanel.Margin = new System.Windows.Forms.Padding(0);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Padding = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.itemPanel.RowCount = 4;
            this.itemPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemPanel.Size = new System.Drawing.Size(312, 133);
            this.itemPanel.TabIndex = 7;
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
            // itemPricePanel
            // 
            this.itemPricePanel.ColumnCount = 2;
            this.itemPricePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemPricePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.itemPricePanel.Controls.Add(this.currencyLabel1, 1, 0);
            this.itemPricePanel.Controls.Add(this.itemPrice, 0, 0);
            this.itemPricePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPricePanel.Location = new System.Drawing.Point(67, 70);
            this.itemPricePanel.Name = "itemPricePanel";
            this.itemPricePanel.RowCount = 1;
            this.itemPricePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemPricePanel.Size = new System.Drawing.Size(237, 24);
            this.itemPricePanel.TabIndex = 8;
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
            // itemStockPanel
            // 
            this.itemStockPanel.ColumnCount = 2;
            this.itemStockPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemStockPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.itemStockPanel.Controls.Add(this.unitLabel1, 1, 0);
            this.itemStockPanel.Controls.Add(this.itemStock, 0, 0);
            this.itemStockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemStockPanel.Location = new System.Drawing.Point(67, 101);
            this.itemStockPanel.Name = "itemStockPanel";
            this.itemStockPanel.RowCount = 1;
            this.itemStockPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemStockPanel.Size = new System.Drawing.Size(237, 24);
            this.itemStockPanel.TabIndex = 7;
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
            // customerPanel
            // 
            this.customerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.customerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.customerPanel.ColumnCount = 2;
            this.customerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.customerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customerPanel.Controls.Add(this.customerLocationLabel, 0, 3);
            this.customerPanel.Controls.Add(this.customerGuidLabel, 0, 0);
            this.customerPanel.Controls.Add(this.customerNameLabel, 0, 1);
            this.customerPanel.Controls.Add(this.customerEmailLabel, 0, 2);
            this.customerPanel.Controls.Add(this.customerGuid, 1, 0);
            this.customerPanel.Controls.Add(this.customerEmail, 1, 2);
            this.customerPanel.Controls.Add(this.customerLocation, 1, 3);
            this.customerPanel.Controls.Add(this.customerNamePanel, 1, 1);
            this.customerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerPanel.Location = new System.Drawing.Point(0, 27);
            this.customerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.customerPanel.Name = "customerPanel";
            this.customerPanel.Padding = new System.Windows.Forms.Padding(4, 4, 2, 4);
            this.customerPanel.RowCount = 4;
            this.customerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customerPanel.Size = new System.Drawing.Size(312, 133);
            this.customerPanel.TabIndex = 6;
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
            // customerNamePanel
            // 
            this.customerNamePanel.Controls.Add(this.customerName);
            this.customerNamePanel.Controls.Add(this.customerNameButton);
            this.customerNamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerNamePanel.Location = new System.Drawing.Point(69, 39);
            this.customerNamePanel.Name = "customerNamePanel";
            this.customerNamePanel.Size = new System.Drawing.Size(237, 24);
            this.customerNamePanel.TabIndex = 12;
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
            this.tableLayoutPanel2.Controls.Add(this.purchasePanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonPanel, 0, 1);
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
            // purchasePanel
            // 
            this.purchasePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.purchasePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.purchasePanel.ColumnCount = 2;
            this.purchasePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.purchasePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchasePanel.Controls.Add(this.purchaseQuantityLabel, 0, 0);
            this.purchasePanel.Controls.Add(this.purchaseTotalPanel, 1, 1);
            this.purchasePanel.Controls.Add(this.purchaseTotalLabel, 0, 1);
            this.purchasePanel.Controls.Add(this.purchaseQuantityPanel, 1, 0);
            this.purchasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchasePanel.Location = new System.Drawing.Point(0, 27);
            this.purchasePanel.Margin = new System.Windows.Forms.Padding(0);
            this.purchasePanel.Name = "purchasePanel";
            this.purchasePanel.Padding = new System.Windows.Forms.Padding(4);
            this.purchasePanel.RowCount = 2;
            this.purchasePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.purchasePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.purchasePanel.Size = new System.Drawing.Size(624, 82);
            this.purchasePanel.TabIndex = 9;
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
            // purchaseTotalPanel
            // 
            this.purchaseTotalPanel.ColumnCount = 2;
            this.purchaseTotalPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseTotalPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.purchaseTotalPanel.Controls.Add(this.currencyLabel2, 1, 0);
            this.purchaseTotalPanel.Controls.Add(this.purchaseTotal, 0, 0);
            this.purchaseTotalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseTotalPanel.Location = new System.Drawing.Point(69, 44);
            this.purchaseTotalPanel.Name = "purchaseTotalPanel";
            this.purchaseTotalPanel.RowCount = 1;
            this.purchaseTotalPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseTotalPanel.Size = new System.Drawing.Size(547, 30);
            this.purchaseTotalPanel.TabIndex = 21;
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
            // purchaseQuantityPanel
            // 
            this.purchaseQuantityPanel.ColumnCount = 3;
            this.purchaseQuantityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseQuantityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.purchaseQuantityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.purchaseQuantityPanel.Controls.Add(this.unitLabel2, 0, 0);
            this.purchaseQuantityPanel.Controls.Add(this.purchaseQuantityInfo, 0, 0);
            this.purchaseQuantityPanel.Controls.Add(this.purchaseQuantity, 0, 0);
            this.purchaseQuantityPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseQuantityPanel.Location = new System.Drawing.Point(69, 8);
            this.purchaseQuantityPanel.Name = "purchaseQuantityPanel";
            this.purchaseQuantityPanel.RowCount = 1;
            this.purchaseQuantityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.purchaseQuantityPanel.Size = new System.Drawing.Size(547, 29);
            this.purchaseQuantityPanel.TabIndex = 7;
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
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonPanel.Controls.Add(this.buttonCancel);
            this.buttonPanel.Controls.Add(this.buttonConfirm);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonPanel.Location = new System.Drawing.Point(0, 109);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(2);
            this.buttonPanel.Size = new System.Drawing.Size(624, 34);
            this.buttonPanel.TabIndex = 8;
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
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
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
            this.itemPanel.ResumeLayout(false);
            this.itemPanel.PerformLayout();
            this.itemPricePanel.ResumeLayout(false);
            this.itemPricePanel.PerformLayout();
            this.itemStockPanel.ResumeLayout(false);
            this.itemStockPanel.PerformLayout();
            this.customerPanel.ResumeLayout(false);
            this.customerPanel.PerformLayout();
            this.customerNamePanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.purchasePanel.ResumeLayout(false);
            this.purchasePanel.PerformLayout();
            this.purchaseTotalPanel.ResumeLayout(false);
            this.purchaseTotalPanel.PerformLayout();
            this.purchaseQuantityPanel.ResumeLayout(false);
            this.purchaseQuantityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseQuantity)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.TableLayoutPanel customerPanel;
        private System.Windows.Forms.Label customerLocationLabel;
        private System.Windows.Forms.Label customerGuidLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerEmailLabel;
        private System.Windows.Forms.TextBox customerGuid;
        private System.Windows.Forms.TableLayoutPanel itemPanel;
        private System.Windows.Forms.Label itemGuidLabel;
        private System.Windows.Forms.Label itemDescriptionLabel;
        private System.Windows.Forms.TextBox itemGuid;
        private System.Windows.Forms.Label itemStockLabel;
        private System.Windows.Forms.Label itemPriceLabel;
        private System.Windows.Forms.TableLayoutPanel itemStockPanel;
        private System.Windows.Forms.Label unitLabel1;
        private System.Windows.Forms.TableLayoutPanel itemPricePanel;
        private System.Windows.Forms.Label currencyLabel1;
        private System.Windows.Forms.Label itemStock;
        private System.Windows.Forms.Label itemPrice;
        private System.Windows.Forms.ComboBox itemDescription;
        private System.Windows.Forms.Label customerEmail;
        private System.Windows.Forms.Label customerLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label purchaseLabel;
        private System.Windows.Forms.TableLayoutPanel purchasePanel;
        private System.Windows.Forms.TableLayoutPanel purchaseTotalPanel;
        private System.Windows.Forms.Label currencyLabel2;
        private System.Windows.Forms.Label purchaseTotal;
        private System.Windows.Forms.Label purchaseTotalLabel;
        private System.Windows.Forms.Label purchaseQuantityLabel;
        private System.Windows.Forms.TableLayoutPanel purchaseQuantityPanel;
        private System.Windows.Forms.Label unitLabel2;
        private System.Windows.Forms.Label purchaseQuantityInfo;
        private System.Windows.Forms.TrackBar purchaseQuantity;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.FlowLayoutPanel customerNamePanel;
        private System.Windows.Forms.ComboBox customerName;
        private System.Windows.Forms.Button customerNameButton;
    }
}