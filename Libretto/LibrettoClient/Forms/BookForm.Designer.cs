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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.TableLayoutPanel();
            this.stockLabel = new System.Windows.Forms.Label();
            this.titleField = new System.Windows.Forms.TextBox();
            this.guidLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.guidField = new System.Windows.Forms.TextBox();
            this.stockPanel = new System.Windows.Forms.TableLayoutPanel();
            this.stockField = new System.Windows.Forms.NumericUpDown();
            this.unitsLabel = new System.Windows.Forms.Label();
            this.pricePanel = new System.Windows.Forms.TableLayoutPanel();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.priceField = new System.Windows.Forms.NumericUpDown();
            this.buttonPanel.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.stockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockField)).BeginInit();
            this.pricePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceField)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPanel.Controls.Add(this.buttonConfirm);
            this.buttonPanel.Controls.Add(this.buttonCancel);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 133);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(6);
            this.buttonPanel.Size = new System.Drawing.Size(284, 36);
            this.buttonPanel.TabIndex = 5;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonConfirm.Enabled = false;
            this.buttonConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Location = new System.Drawing.Point(6, 6);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(134, 24);
            this.buttonConfirm.TabIndex = 7;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(144, 6);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(134, 24);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.formPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.formPanel.ColumnCount = 2;
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.45455F));
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.54546F));
            this.formPanel.Controls.Add(this.stockLabel, 0, 3);
            this.formPanel.Controls.Add(this.titleField, 1, 1);
            this.formPanel.Controls.Add(this.guidLabel, 0, 0);
            this.formPanel.Controls.Add(this.titleLabel, 0, 1);
            this.formPanel.Controls.Add(this.priceLabel, 0, 2);
            this.formPanel.Controls.Add(this.guidField, 1, 0);
            this.formPanel.Controls.Add(this.stockPanel, 1, 3);
            this.formPanel.Controls.Add(this.pricePanel, 1, 2);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(0, 0);
            this.formPanel.Margin = new System.Windows.Forms.Padding(0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(4);
            this.formPanel.RowCount = 4;
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.formPanel.Size = new System.Drawing.Size(284, 133);
            this.formPanel.TabIndex = 6;
            // 
            // stockLabel
            // 
            this.stockLabel.AutoSize = true;
            this.stockLabel.BackColor = System.Drawing.Color.Silver;
            this.stockLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockLabel.Location = new System.Drawing.Point(5, 98);
            this.stockLabel.Margin = new System.Windows.Forms.Padding(0);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(47, 30);
            this.stockLabel.TabIndex = 5;
            this.stockLabel.Text = "Stock";
            this.stockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleField
            // 
            this.titleField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.titleField.Location = new System.Drawing.Point(57, 41);
            this.titleField.Margin = new System.Windows.Forms.Padding(4);
            this.titleField.Name = "titleField";
            this.titleField.Size = new System.Drawing.Size(218, 20);
            this.titleField.TabIndex = 0;
            this.titleField.TextChanged += new System.EventHandler(this.TitleField_TextChanged);
            // 
            // guidLabel
            // 
            this.guidLabel.AutoSize = true;
            this.guidLabel.BackColor = System.Drawing.Color.Silver;
            this.guidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guidLabel.Location = new System.Drawing.Point(5, 5);
            this.guidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.guidLabel.Name = "guidLabel";
            this.guidLabel.Size = new System.Drawing.Size(47, 30);
            this.guidLabel.TabIndex = 2;
            this.guidLabel.Text = "GUID";
            this.guidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Silver;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Location = new System.Drawing.Point(5, 36);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(47, 30);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.BackColor = System.Drawing.Color.Silver;
            this.priceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceLabel.Location = new System.Drawing.Point(5, 67);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(47, 30);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guidField
            // 
            this.guidField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guidField.Enabled = false;
            this.guidField.Location = new System.Drawing.Point(57, 10);
            this.guidField.Margin = new System.Windows.Forms.Padding(4);
            this.guidField.Name = "guidField";
            this.guidField.ReadOnly = true;
            this.guidField.Size = new System.Drawing.Size(218, 20);
            this.guidField.TabIndex = 1;
            // 
            // stockPanel
            // 
            this.stockPanel.ColumnCount = 2;
            this.stockPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.54546F));
            this.stockPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.45455F));
            this.stockPanel.Controls.Add(this.stockField, 0, 0);
            this.stockPanel.Controls.Add(this.unitsLabel, 1, 0);
            this.stockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockPanel.Location = new System.Drawing.Point(56, 101);
            this.stockPanel.Name = "stockPanel";
            this.stockPanel.RowCount = 1;
            this.stockPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.stockPanel.Size = new System.Drawing.Size(220, 24);
            this.stockPanel.TabIndex = 7;
            // 
            // stockField
            // 
            this.stockField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockField.Location = new System.Drawing.Point(2, 2);
            this.stockField.Margin = new System.Windows.Forms.Padding(2);
            this.stockField.Name = "stockField";
            this.stockField.Size = new System.Drawing.Size(181, 20);
            this.stockField.TabIndex = 6;
            // 
            // unitsLabel
            // 
            this.unitsLabel.AutoSize = true;
            this.unitsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsLabel.Location = new System.Drawing.Point(188, 0);
            this.unitsLabel.Name = "unitsLabel";
            this.unitsLabel.Size = new System.Drawing.Size(29, 24);
            this.unitsLabel.TabIndex = 5;
            this.unitsLabel.Text = "Un";
            this.unitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pricePanel
            // 
            this.pricePanel.ColumnCount = 2;
            this.pricePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.54546F));
            this.pricePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.45455F));
            this.pricePanel.Controls.Add(this.currencyLabel, 0, 0);
            this.pricePanel.Controls.Add(this.priceField, 0, 0);
            this.pricePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pricePanel.Location = new System.Drawing.Point(56, 70);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.RowCount = 1;
            this.pricePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pricePanel.Size = new System.Drawing.Size(220, 24);
            this.pricePanel.TabIndex = 8;
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyLabel.Location = new System.Drawing.Point(188, 0);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(29, 24);
            this.currencyLabel.TabIndex = 10;
            this.currencyLabel.Text = "€";
            this.currencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priceField
            // 
            this.priceField.DecimalPlaces = 2;
            this.priceField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceField.Location = new System.Drawing.Point(2, 2);
            this.priceField.Margin = new System.Windows.Forms.Padding(2);
            this.priceField.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.priceField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.priceField.Name = "priceField";
            this.priceField.Size = new System.Drawing.Size(181, 20);
            this.priceField.TabIndex = 9;
            this.priceField.ThousandsSeparator = true;
            this.priceField.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // BookForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 169);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publish Book";
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.stockPanel.ResumeLayout(false);
            this.stockPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockField)).EndInit();
            this.pricePanel.ResumeLayout(false);
            this.pricePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel formPanel;
        private System.Windows.Forms.Label stockLabel;
        private System.Windows.Forms.TextBox titleField;
        private System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox guidField;
        private System.Windows.Forms.TableLayoutPanel stockPanel;
        private System.Windows.Forms.NumericUpDown stockField;
        private System.Windows.Forms.Label unitsLabel;
        private System.Windows.Forms.TableLayoutPanel pricePanel;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.NumericUpDown priceField;
    }
}