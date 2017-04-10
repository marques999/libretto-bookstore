namespace Libretto.Forms
{
    partial class BookForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutPrice = new System.Windows.Forms.TableLayoutPanel();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.fieldPrice = new System.Windows.Forms.NumericUpDown();
            this.layoutStock = new System.Windows.Forms.TableLayoutPanel();
            this.fieldStock = new System.Windows.Forms.NumericUpDown();
            this.labelUnits = new System.Windows.Forms.Label();
            this.fieldGuid = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelGuid = new System.Windows.Forms.Label();
            this.fieldTitle = new System.Windows.Forms.TextBox();
            this.labelStock = new System.Windows.Forms.Label();
            this.fieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayout.SuspendLayout();
            this.layoutPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPrice)).BeginInit();
            this.layoutStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStock)).BeginInit();
            this.fieldLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(145, 5);
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
            this.buttonConfirm.Location = new System.Drawing.Point(7, 5);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(132, 24);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonLayout.Controls.Add(this.buttonCancel);
            this.buttonLayout.Controls.Add(this.buttonConfirm);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonLayout.Location = new System.Drawing.Point(0, 133);
            this.buttonLayout.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Padding = new System.Windows.Forms.Padding(2);
            this.buttonLayout.Size = new System.Drawing.Size(284, 34);
            this.buttonLayout.TabIndex = 5;
            // 
            // layoutPrice
            // 
            this.layoutPrice.ColumnCount = 2;
            this.layoutPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.54546F));
            this.layoutPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.45455F));
            this.layoutPrice.Controls.Add(this.labelCurrency, 0, 0);
            this.layoutPrice.Controls.Add(this.fieldPrice, 0, 0);
            this.layoutPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPrice.Location = new System.Drawing.Point(56, 70);
            this.layoutPrice.Name = "layoutPrice";
            this.layoutPrice.RowCount = 1;
            this.layoutPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrice.Size = new System.Drawing.Size(220, 24);
            this.layoutPrice.TabIndex = 8;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.Location = new System.Drawing.Point(188, 0);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(29, 24);
            this.labelCurrency.TabIndex = 10;
            this.labelCurrency.Text = "€";
            this.labelCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldPrice
            // 
            this.fieldPrice.DecimalPlaces = 2;
            this.fieldPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPrice.Location = new System.Drawing.Point(2, 2);
            this.fieldPrice.Margin = new System.Windows.Forms.Padding(2);
            this.fieldPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.fieldPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.fieldPrice.Name = "fieldPrice";
            this.fieldPrice.Size = new System.Drawing.Size(181, 20);
            this.fieldPrice.TabIndex = 9;
            this.fieldPrice.ThousandsSeparator = true;
            this.fieldPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // layoutStock
            // 
            this.layoutStock.ColumnCount = 2;
            this.layoutStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.54546F));
            this.layoutStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.45455F));
            this.layoutStock.Controls.Add(this.fieldStock, 0, 0);
            this.layoutStock.Controls.Add(this.labelUnits, 1, 0);
            this.layoutStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutStock.Location = new System.Drawing.Point(56, 101);
            this.layoutStock.Name = "layoutStock";
            this.layoutStock.RowCount = 1;
            this.layoutStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutStock.Size = new System.Drawing.Size(220, 24);
            this.layoutStock.TabIndex = 7;
            // 
            // fieldStock
            // 
            this.fieldStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldStock.Location = new System.Drawing.Point(2, 2);
            this.fieldStock.Margin = new System.Windows.Forms.Padding(2);
            this.fieldStock.Name = "fieldStock";
            this.fieldStock.Size = new System.Drawing.Size(181, 20);
            this.fieldStock.TabIndex = 6;
            // 
            // labelUnits
            // 
            this.labelUnits.AutoSize = true;
            this.labelUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnits.Location = new System.Drawing.Point(188, 0);
            this.labelUnits.Name = "labelUnits";
            this.labelUnits.Size = new System.Drawing.Size(29, 24);
            this.labelUnits.TabIndex = 5;
            this.labelUnits.Text = "Un";
            this.labelUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldGuid
            // 
            this.fieldGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldGuid.Enabled = false;
            this.fieldGuid.Location = new System.Drawing.Point(57, 10);
            this.fieldGuid.Margin = new System.Windows.Forms.Padding(4);
            this.fieldGuid.Name = "fieldGuid";
            this.fieldGuid.ReadOnly = true;
            this.fieldGuid.Size = new System.Drawing.Size(218, 20);
            this.fieldGuid.TabIndex = 1;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPrice.Location = new System.Drawing.Point(8, 67);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(41, 30);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Price";
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Location = new System.Drawing.Point(8, 36);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(41, 30);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelGuid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGuid.Location = new System.Drawing.Point(8, 5);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(41, 30);
            this.labelGuid.TabIndex = 2;
            this.labelGuid.Text = "GUID";
            this.labelGuid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldTitle
            // 
            this.fieldTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldTitle.Location = new System.Drawing.Point(57, 40);
            this.fieldTitle.Margin = new System.Windows.Forms.Padding(4);
            this.fieldTitle.Name = "fieldTitle";
            this.fieldTitle.Size = new System.Drawing.Size(218, 20);
            this.fieldTitle.TabIndex = 0;
            this.fieldTitle.TextChanged += new System.EventHandler(this.FieldTitle_TextChanged);
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStock.Location = new System.Drawing.Point(8, 98);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(41, 30);
            this.labelStock.TabIndex = 5;
            this.labelStock.Text = "Stock";
            this.labelStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldLayout
            // 
            this.fieldLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.fieldLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.fieldLayout.ColumnCount = 2;
            this.fieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.45455F));
            this.fieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.54546F));
            this.fieldLayout.Controls.Add(this.labelStock, 0, 3);
            this.fieldLayout.Controls.Add(this.fieldTitle, 1, 1);
            this.fieldLayout.Controls.Add(this.labelGuid, 0, 0);
            this.fieldLayout.Controls.Add(this.labelTitle, 0, 1);
            this.fieldLayout.Controls.Add(this.labelPrice, 0, 2);
            this.fieldLayout.Controls.Add(this.fieldGuid, 1, 0);
            this.fieldLayout.Controls.Add(this.layoutStock, 1, 3);
            this.fieldLayout.Controls.Add(this.layoutPrice, 1, 2);
            this.fieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldLayout.Location = new System.Drawing.Point(0, 0);
            this.fieldLayout.Margin = new System.Windows.Forms.Padding(0);
            this.fieldLayout.Name = "fieldLayout";
            this.fieldLayout.Padding = new System.Windows.Forms.Padding(4);
            this.fieldLayout.RowCount = 4;
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.fieldLayout.Size = new System.Drawing.Size(284, 133);
            this.fieldLayout.TabIndex = 4;
            // 
            // BookForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.fieldLayout);
            this.Controls.Add(this.buttonLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publish Book";
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.buttonLayout.ResumeLayout(false);
            this.layoutPrice.ResumeLayout(false);
            this.layoutPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPrice)).EndInit();
            this.layoutStock.ResumeLayout(false);
            this.layoutStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStock)).EndInit();
            this.fieldLayout.ResumeLayout(false);
            this.fieldLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.FlowLayoutPanel buttonLayout;
        private System.Windows.Forms.TableLayoutPanel layoutPrice;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.NumericUpDown fieldPrice;
        private System.Windows.Forms.TableLayoutPanel layoutStock;
        private System.Windows.Forms.NumericUpDown fieldStock;
        private System.Windows.Forms.Label labelUnits;
        private System.Windows.Forms.TextBox fieldGuid;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox fieldTitle;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.TableLayoutPanel fieldLayout;
    }
}