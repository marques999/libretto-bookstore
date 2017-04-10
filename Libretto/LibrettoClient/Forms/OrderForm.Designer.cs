namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class OrderForm
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
            this.tableLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.itemLayout = new System.Windows.Forms.TableLayoutPanel();
            this.itemStockLabel = new System.Windows.Forms.Label();
            this.itemGuidLabel = new System.Windows.Forms.Label();
            this.itemDescriptionLabel = new System.Windows.Forms.Label();
            this.itemPriceLabel = new System.Windows.Forms.Label();
            this.itemGuid = new System.Windows.Forms.TextBox();
            this.itemDescription = new System.Windows.Forms.ComboBox();
            this.itemPriceLayout = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel1 = new System.Windows.Forms.Label();
            this.itemPrice = new System.Windows.Forms.Label();
            this.itemStockLayout = new System.Windows.Forms.TableLayoutPanel();
            this.unitLabel1 = new System.Windows.Forms.Label();
            this.itemStock = new System.Windows.Forms.Label();
            this.customerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.customerNamePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.customerName = new System.Windows.Forms.ComboBox();
            this.customerNameButton = new System.Windows.Forms.Button();
            this.customerLocationLabel = new System.Windows.Forms.Label();
            this.customerGuidLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerEmailLabel = new System.Windows.Forms.Label();
            this.customerGuid = new System.Windows.Forms.TextBox();
            this.customerEmail = new System.Windows.Forms.Label();
            this.customerLocation = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.tableLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.orderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.orderQuantityLabel = new System.Windows.Forms.Label();
            this.orderTotalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel2 = new System.Windows.Forms.Label();
            this.orderTotal = new System.Windows.Forms.Label();
            this.orderTotalLabel = new System.Windows.Forms.Label();
            this.orderQuantityLayout = new System.Windows.Forms.TableLayoutPanel();
            this.unitLabel2 = new System.Windows.Forms.Label();
            this.orderQuantityInfo = new System.Windows.Forms.Label();
            this.orderQuantity = new System.Windows.Forms.TrackBar();
            this.statusLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.statusWaiting = new System.Windows.Forms.RadioButton();
            this.statusProcessing = new System.Windows.Forms.RadioButton();
            this.statusDispatched = new System.Windows.Forms.RadioButton();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.orderLabel = new System.Windows.Forms.Label();
            this.tableLayout1.SuspendLayout();
            this.itemLayout.SuspendLayout();
            this.itemPriceLayout.SuspendLayout();
            this.itemStockLayout.SuspendLayout();
            this.customerLayout.SuspendLayout();
            this.customerNamePanel.SuspendLayout();
            this.tableLayout2.SuspendLayout();
            this.orderLayout.SuspendLayout();
            this.orderTotalLayout.SuspendLayout();
            this.orderQuantityLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantity)).BeginInit();
            this.statusLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout1
            // 
            this.tableLayout1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayout1.ColumnCount = 2;
            this.tableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout1.Controls.Add(this.itemLayout, 1, 1);
            this.tableLayout1.Controls.Add(this.customerLayout, 0, 1);
            this.tableLayout1.Controls.Add(this.customerLabel, 0, 0);
            this.tableLayout1.Controls.Add(this.itemLabel, 1, 0);
            this.tableLayout1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayout1.Location = new System.Drawing.Point(0, 0);
            this.tableLayout1.Name = "tableLayout1";
            this.tableLayout1.RowCount = 2;
            this.tableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout1.Size = new System.Drawing.Size(624, 160);
            this.tableLayout1.TabIndex = 10;
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
            this.itemLayout.Controls.Add(this.itemPriceLayout, 1, 2);
            this.itemLayout.Controls.Add(this.itemStockLayout, 1, 3);
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
            // itemPriceLayout
            // 
            this.itemPriceLayout.ColumnCount = 2;
            this.itemPriceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemPriceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.itemPriceLayout.Controls.Add(this.currencyLabel1, 1, 0);
            this.itemPriceLayout.Controls.Add(this.itemPrice, 0, 0);
            this.itemPriceLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPriceLayout.Location = new System.Drawing.Point(67, 70);
            this.itemPriceLayout.Name = "itemPriceLayout";
            this.itemPriceLayout.RowCount = 1;
            this.itemPriceLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemPriceLayout.Size = new System.Drawing.Size(237, 24);
            this.itemPriceLayout.TabIndex = 8;
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
            // itemStockLayout
            // 
            this.itemStockLayout.ColumnCount = 2;
            this.itemStockLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemStockLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.itemStockLayout.Controls.Add(this.unitLabel1, 1, 0);
            this.itemStockLayout.Controls.Add(this.itemStock, 0, 0);
            this.itemStockLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemStockLayout.Location = new System.Drawing.Point(67, 101);
            this.itemStockLayout.Name = "itemStockLayout";
            this.itemStockLayout.RowCount = 1;
            this.itemStockLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemStockLayout.Size = new System.Drawing.Size(237, 24);
            this.itemStockLayout.TabIndex = 7;
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
            this.customerLayout.Controls.Add(this.customerNamePanel, 1, 1);
            this.customerLayout.Controls.Add(this.customerLocationLabel, 0, 3);
            this.customerLayout.Controls.Add(this.customerGuidLabel, 0, 0);
            this.customerLayout.Controls.Add(this.customerNameLabel, 0, 1);
            this.customerLayout.Controls.Add(this.customerEmailLabel, 0, 2);
            this.customerLayout.Controls.Add(this.customerGuid, 1, 0);
            this.customerLayout.Controls.Add(this.customerEmail, 1, 2);
            this.customerLayout.Controls.Add(this.customerLocation, 1, 3);
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
            this.customerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customerLayout.Size = new System.Drawing.Size(312, 133);
            this.customerLayout.TabIndex = 6;
            // 
            // customerNamePanel
            // 
            this.customerNamePanel.Controls.Add(this.customerName);
            this.customerNamePanel.Controls.Add(this.customerNameButton);
            this.customerNamePanel.Location = new System.Drawing.Point(69, 39);
            this.customerNamePanel.Name = "customerNamePanel";
            this.customerNamePanel.Size = new System.Drawing.Size(237, 24);
            this.customerNamePanel.TabIndex = 13;
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
            // tableLayout2
            // 
            this.tableLayout2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayout2.ColumnCount = 1;
            this.tableLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout2.Controls.Add(this.orderLayout, 0, 1);
            this.tableLayout2.Controls.Add(this.buttonLayout, 0, 1);
            this.tableLayout2.Controls.Add(this.orderLabel, 0, 0);
            this.tableLayout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout2.Location = new System.Drawing.Point(0, 160);
            this.tableLayout2.Name = "tableLayout2";
            this.tableLayout2.RowCount = 2;
            this.tableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayout2.Size = new System.Drawing.Size(624, 221);
            this.tableLayout2.TabIndex = 11;
            // 
            // orderLayout
            // 
            this.orderLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.orderLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.orderLayout.ColumnCount = 2;
            this.orderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.orderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderLayout.Controls.Add(this.statusLabel, 0, 2);
            this.orderLayout.Controls.Add(this.orderQuantityLabel, 0, 0);
            this.orderLayout.Controls.Add(this.orderTotalLayout, 1, 1);
            this.orderLayout.Controls.Add(this.orderTotalLabel, 0, 1);
            this.orderLayout.Controls.Add(this.orderQuantityLayout, 1, 0);
            this.orderLayout.Controls.Add(this.statusLayout, 1, 2);
            this.orderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderLayout.Location = new System.Drawing.Point(0, 27);
            this.orderLayout.Margin = new System.Windows.Forms.Padding(0);
            this.orderLayout.Name = "orderLayout";
            this.orderLayout.Padding = new System.Windows.Forms.Padding(4);
            this.orderLayout.RowCount = 3;
            this.orderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.orderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.orderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderLayout.Size = new System.Drawing.Size(624, 160);
            this.orderLayout.TabIndex = 9;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Location = new System.Drawing.Point(5, 79);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(60, 76);
            this.statusLabel.TabIndex = 23;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orderQuantityLabel
            // 
            this.orderQuantityLabel.AutoSize = true;
            this.orderQuantityLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.orderQuantityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderQuantityLabel.Location = new System.Drawing.Point(5, 5);
            this.orderQuantityLabel.Margin = new System.Windows.Forms.Padding(0);
            this.orderQuantityLabel.Name = "orderQuantityLabel";
            this.orderQuantityLabel.Size = new System.Drawing.Size(60, 36);
            this.orderQuantityLabel.TabIndex = 22;
            this.orderQuantityLabel.Text = "Quantity";
            this.orderQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orderTotalLayout
            // 
            this.orderTotalLayout.ColumnCount = 2;
            this.orderTotalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderTotalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.orderTotalLayout.Controls.Add(this.currencyLabel2, 1, 0);
            this.orderTotalLayout.Controls.Add(this.orderTotal, 0, 0);
            this.orderTotalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderTotalLayout.Location = new System.Drawing.Point(69, 45);
            this.orderTotalLayout.Name = "orderTotalLayout";
            this.orderTotalLayout.RowCount = 1;
            this.orderTotalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderTotalLayout.Size = new System.Drawing.Size(547, 30);
            this.orderTotalLayout.TabIndex = 21;
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
            // orderTotal
            // 
            this.orderTotal.AutoSize = true;
            this.orderTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderTotal.Location = new System.Drawing.Point(3, 0);
            this.orderTotal.Name = "orderTotal";
            this.orderTotal.Size = new System.Drawing.Size(509, 30);
            this.orderTotal.TabIndex = 12;
            this.orderTotal.Text = "0,00";
            this.orderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // orderTotalLabel
            // 
            this.orderTotalLabel.AutoSize = true;
            this.orderTotalLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.orderTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderTotalLabel.Location = new System.Drawing.Point(5, 42);
            this.orderTotalLabel.Margin = new System.Windows.Forms.Padding(0);
            this.orderTotalLabel.Name = "orderTotalLabel";
            this.orderTotalLabel.Size = new System.Drawing.Size(60, 36);
            this.orderTotalLabel.TabIndex = 19;
            this.orderTotalLabel.Text = "Total";
            this.orderTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orderQuantityLayout
            // 
            this.orderQuantityLayout.ColumnCount = 3;
            this.orderQuantityLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderQuantityLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.orderQuantityLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.orderQuantityLayout.Controls.Add(this.unitLabel2, 0, 0);
            this.orderQuantityLayout.Controls.Add(this.orderQuantityInfo, 0, 0);
            this.orderQuantityLayout.Controls.Add(this.orderQuantity, 0, 0);
            this.orderQuantityLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderQuantityLayout.Location = new System.Drawing.Point(69, 8);
            this.orderQuantityLayout.Name = "orderQuantityLayout";
            this.orderQuantityLayout.RowCount = 1;
            this.orderQuantityLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderQuantityLayout.Size = new System.Drawing.Size(547, 30);
            this.orderQuantityLayout.TabIndex = 7;
            // 
            // unitLabel2
            // 
            this.unitLabel2.AutoSize = true;
            this.unitLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel2.Location = new System.Drawing.Point(518, 0);
            this.unitLabel2.Name = "unitLabel2";
            this.unitLabel2.Size = new System.Drawing.Size(26, 30);
            this.unitLabel2.TabIndex = 18;
            this.unitLabel2.Text = "Un";
            this.unitLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orderQuantityInfo
            // 
            this.orderQuantityInfo.AutoSize = true;
            this.orderQuantityInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderQuantityInfo.Location = new System.Drawing.Point(470, 0);
            this.orderQuantityInfo.Name = "orderQuantityInfo";
            this.orderQuantityInfo.Size = new System.Drawing.Size(42, 30);
            this.orderQuantityInfo.TabIndex = 17;
            this.orderQuantityInfo.Text = "1";
            this.orderQuantityInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // orderQuantity
            // 
            this.orderQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderQuantity.Location = new System.Drawing.Point(3, 3);
            this.orderQuantity.Maximum = 100;
            this.orderQuantity.Minimum = 1;
            this.orderQuantity.Name = "orderQuantity";
            this.orderQuantity.Size = new System.Drawing.Size(461, 24);
            this.orderQuantity.TabIndex = 16;
            this.orderQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.orderQuantity.Value = 1;
            this.orderQuantity.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // statusLayout
            // 
            this.statusLayout.Controls.Add(this.statusWaiting);
            this.statusLayout.Controls.Add(this.statusProcessing);
            this.statusLayout.Controls.Add(this.statusDispatched);
            this.statusLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.statusLayout.Location = new System.Drawing.Point(69, 82);
            this.statusLayout.Name = "statusLayout";
            this.statusLayout.Size = new System.Drawing.Size(547, 70);
            this.statusLayout.TabIndex = 24;
            // 
            // statusWaiting
            // 
            this.statusWaiting.AutoSize = true;
            this.statusWaiting.Location = new System.Drawing.Point(3, 3);
            this.statusWaiting.Name = "statusWaiting";
            this.statusWaiting.Size = new System.Drawing.Size(113, 17);
            this.statusWaiting.TabIndex = 25;
            this.statusWaiting.Text = "Waiting Expedition";
            this.statusWaiting.UseVisualStyleBackColor = true;
            this.statusWaiting.CheckedChanged += new System.EventHandler(this.RadioWaiting_CheckedChanged);
            // 
            // statusProcessing
            // 
            this.statusProcessing.AutoSize = true;
            this.statusProcessing.Checked = true;
            this.statusProcessing.Location = new System.Drawing.Point(3, 26);
            this.statusProcessing.Name = "statusProcessing";
            this.statusProcessing.Size = new System.Drawing.Size(106, 17);
            this.statusProcessing.TabIndex = 26;
            this.statusProcessing.TabStop = true;
            this.statusProcessing.Text = "Waiting Dispatch";
            this.statusProcessing.UseVisualStyleBackColor = true;
            this.statusProcessing.CheckedChanged += new System.EventHandler(this.RadioProcessing_CheckedChanged);
            // 
            // statusDispatched
            // 
            this.statusDispatched.AutoSize = true;
            this.statusDispatched.Location = new System.Drawing.Point(3, 49);
            this.statusDispatched.Name = "statusDispatched";
            this.statusDispatched.Size = new System.Drawing.Size(114, 17);
            this.statusDispatched.TabIndex = 27;
            this.statusDispatched.Text = "Dispatch Complete";
            this.statusDispatched.UseVisualStyleBackColor = true;
            this.statusDispatched.CheckedChanged += new System.EventHandler(this.RadioDispatched_CheckedChanged);
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
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.tableLayout2);
            this.Controls.Add(this.tableLayout1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Place Order";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tableLayout1.ResumeLayout(false);
            this.tableLayout1.PerformLayout();
            this.itemLayout.ResumeLayout(false);
            this.itemLayout.PerformLayout();
            this.itemPriceLayout.ResumeLayout(false);
            this.itemPriceLayout.PerformLayout();
            this.itemStockLayout.ResumeLayout(false);
            this.itemStockLayout.PerformLayout();
            this.customerLayout.ResumeLayout(false);
            this.customerLayout.PerformLayout();
            this.customerNamePanel.ResumeLayout(false);
            this.tableLayout2.ResumeLayout(false);
            this.tableLayout2.PerformLayout();
            this.orderLayout.ResumeLayout(false);
            this.orderLayout.PerformLayout();
            this.orderTotalLayout.ResumeLayout(false);
            this.orderTotalLayout.PerformLayout();
            this.orderQuantityLayout.ResumeLayout(false);
            this.orderQuantityLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantity)).EndInit();
            this.statusLayout.ResumeLayout(false);
            this.statusLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayout1;
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
        private System.Windows.Forms.TableLayoutPanel itemStockLayout;
        private System.Windows.Forms.Label unitLabel1;
        private System.Windows.Forms.TableLayoutPanel itemPriceLayout;
        private System.Windows.Forms.Label currencyLabel1;
        private System.Windows.Forms.Label itemStock;
        private System.Windows.Forms.Label itemPrice;
        private System.Windows.Forms.ComboBox itemDescription;
        private System.Windows.Forms.Label customerEmail;
        private System.Windows.Forms.Label customerLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayout2;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.TableLayoutPanel orderLayout;
        private System.Windows.Forms.TableLayoutPanel orderTotalLayout;
        private System.Windows.Forms.Label currencyLabel2;
        private System.Windows.Forms.Label orderTotal;
        private System.Windows.Forms.Label orderTotalLabel;
        private System.Windows.Forms.Label orderQuantityLabel;
        private System.Windows.Forms.TableLayoutPanel orderQuantityLayout;
        private System.Windows.Forms.Label unitLabel2;
        private System.Windows.Forms.Label orderQuantityInfo;
        private System.Windows.Forms.TrackBar orderQuantity;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.FlowLayoutPanel statusLayout;
        private System.Windows.Forms.RadioButton statusWaiting;
        private System.Windows.Forms.RadioButton statusProcessing;
        private System.Windows.Forms.RadioButton statusDispatched;
        private System.Windows.Forms.FlowLayoutPanel buttonLayout;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.FlowLayoutPanel customerNamePanel;
        private System.Windows.Forms.ComboBox customerName;
        private System.Windows.Forms.Button customerNameButton;
    }
}