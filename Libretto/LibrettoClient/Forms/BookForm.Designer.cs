using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class BookForm
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
            if (disposing && (components != null))
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
            buttonPanel = new Panel();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            formPanel = new TableLayoutPanel();
            stockLabel = new Label();
            titleField = new TextBox();
            guidLabel = new Label();
            titleLabel = new Label();
            priceLabel = new Label();
            guidField = new TextBox();
            stockPanel = new TableLayoutPanel();
            stockField = new NumericUpDown();
            unitsLabel = new Label();
            pricePanel = new TableLayoutPanel();
            currencyLabel = new Label();
            priceField = new NumericUpDown();
            buttonPanel.SuspendLayout();
            formPanel.SuspendLayout();
            stockPanel.SuspendLayout();
            ((ISupportInitialize)(stockField)).BeginInit();
            pricePanel.SuspendLayout();
            ((ISupportInitialize)(priceField)).BeginInit();
            SuspendLayout();
            //
            // buttonPanel
            //
            buttonPanel.BackColor = Color.DarkGray;
            buttonPanel.Controls.Add(buttonConfirm);
            buttonPanel.Controls.Add(buttonCancel);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 133);
            buttonPanel.Margin = new Padding(0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(6);
            buttonPanel.Size = new Size(284, 36);
            //
            // buttonConfirm
            //
            buttonConfirm.BackColor = SystemColors.Control;
            buttonConfirm.Dock = DockStyle.Left;
            buttonConfirm.Enabled = false;
            buttonConfirm.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Location = new Point(6, 6);
            buttonConfirm.Margin = new Padding(0);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(134, 24);
            buttonConfirm.TabIndex = 0;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += new EventHandler(ButtonConfirm_Click);
            //
            // buttonCancel
            //
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Dock = DockStyle.Right;
            buttonCancel.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(144, 6);
            buttonCancel.Margin = new Padding(0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(134, 24);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += new EventHandler(ButtonCancel_Click);
            //
            // formPanel
            //
            formPanel.BackColor = Color.Gainsboro;
            formPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            formPanel.ColumnCount = 2;
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formPanel.Controls.Add(guidLabel, 0, 0);
            formPanel.Controls.Add(guidField, 1, 0);
            formPanel.Controls.Add(titleLabel, 0, 1);
            formPanel.Controls.Add(titleField, 1, 1);
            formPanel.Controls.Add(priceLabel, 0, 2);
            formPanel.Controls.Add(pricePanel, 1, 2);
            formPanel.Controls.Add(stockLabel, 0, 3);
            formPanel.Controls.Add(stockPanel, 1, 3);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(0, 0);
            formPanel.Margin = new Padding(0);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(4);
            formPanel.RowCount = 4;
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            formPanel.Size = new Size(284, 133);
            //
            // stockLabel
            //
            stockLabel.AutoSize = true;
            stockLabel.BackColor = Color.Silver;
            stockLabel.Dock = DockStyle.Fill;
            stockLabel.Location = new Point(5, 98);
            stockLabel.Margin = new Padding(0);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(50, 30);
            stockLabel.Text = "Stock";
            stockLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // titleField
            //
            titleField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            titleField.Location = new Point(60, 41);
            titleField.Margin = new Padding(4);
            titleField.Name = "titleField";
            titleField.Size = new Size(215, 20);
            titleField.TabIndex = 2;
            titleField.TextChanged += new EventHandler(TitleField_TextChanged);
            //
            // guidLabel
            //
            guidLabel.AutoSize = true;
            guidLabel.BackColor = Color.Silver;
            guidLabel.Dock = DockStyle.Fill;
            guidLabel.Location = new Point(5, 5);
            guidLabel.Margin = new Padding(0);
            guidLabel.Name = "guidLabel";
            guidLabel.Size = new Size(50, 30);
            guidLabel.Text = "GUID";
            guidLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // titleLabel
            //
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Silver;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Location = new Point(5, 36);
            titleLabel.Margin = new Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(50, 30);
            titleLabel.Text = "Title";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // priceLabel
            //
            priceLabel.AutoSize = true;
            priceLabel.BackColor = Color.Silver;
            priceLabel.Dock = DockStyle.Fill;
            priceLabel.Location = new Point(5, 67);
            priceLabel.Margin = new Padding(0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(50, 30);
            priceLabel.Text = "Price";
            priceLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // guidField
            //
            guidField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            guidField.Enabled = false;
            guidField.Location = new Point(60, 10);
            guidField.Margin = new Padding(4);
            guidField.Name = "guidField";
            guidField.ReadOnly = true;
            guidField.Size = new Size(215, 20);
            //
            // stockPanel
            //
            stockPanel.ColumnCount = 2;
            stockPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            stockPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            stockPanel.Controls.Add(stockField, 0, 0);
            stockPanel.Controls.Add(unitsLabel, 1, 0);
            stockPanel.Dock = DockStyle.Fill;
            stockPanel.Location = new Point(59, 101);
            stockPanel.Name = "stockPanel";
            stockPanel.RowCount = 1;
            stockPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            stockPanel.Size = new Size(217, 24);
            //
            // stockField
            //
            stockField.Dock = DockStyle.Fill;
            stockField.Location = new Point(2, 2);
            stockField.Margin = new Padding(2);
            stockField.Name = "stockField";
            stockField.Size = new Size(181, 20);
            stockField.TabIndex = 4;
            //
            // unitsLabel
            //
            unitsLabel.AutoSize = true;
            unitsLabel.Dock = DockStyle.Fill;
            unitsLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unitsLabel.Location = new Point(188, 0);
            unitsLabel.Name = "unitsLabel";
            unitsLabel.Size = new Size(26, 24);
            unitsLabel.Text = "Un";
            unitsLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pricePanel
            //
            pricePanel.ColumnCount = 2;
            pricePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pricePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            pricePanel.Controls.Add(currencyLabel, 0, 0);
            pricePanel.Controls.Add(priceField, 0, 0);
            pricePanel.Dock = DockStyle.Fill;
            pricePanel.Location = new Point(59, 70);
            pricePanel.Name = "pricePanel";
            pricePanel.RowCount = 1;
            pricePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pricePanel.Size = new Size(217, 24);
            //
            // currencyLabel
            //
            currencyLabel.AutoSize = true;
            currencyLabel.Dock = DockStyle.Fill;
            currencyLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currencyLabel.Location = new Point(188, 0);
            currencyLabel.Name = "currencyLabel";
            currencyLabel.Size = new Size(26, 24);
            currencyLabel.Text = "€";
            currencyLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // priceField
            //
            priceField.DecimalPlaces = 2;
            priceField.Dock = DockStyle.Fill;
            priceField.Location = new Point(2, 2);
            priceField.Margin = new Padding(2);
            priceField.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceField.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            priceField.Name = "priceField";
            priceField.Size = new Size(181, 20);
            priceField.TabIndex = 3;
            priceField.ThousandsSeparator = true;
            priceField.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            //
            // BookForm
            //
            AcceptButton = buttonConfirm;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(284, 169);
            Controls.Add(formPanel);
            Controls.Add(buttonPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Publish Book";
            Load += new EventHandler(BookForm_Load);
            buttonPanel.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            stockPanel.ResumeLayout(false);
            stockPanel.PerformLayout();
            ((ISupportInitialize)(stockField)).EndInit();
            pricePanel.ResumeLayout(false);
            pricePanel.PerformLayout();
            ((ISupportInitialize)(priceField)).EndInit();
            ResumeLayout(false);
        }

        private Panel buttonPanel;
        private Button buttonConfirm;
        private Button buttonCancel;
        private Label guidLabel;
        private Label priceLabel;
        private Label stockLabel;
        private Label titleLabel;
        private Label unitsLabel;
        private Label currencyLabel;
        private TextBox guidField;
        private TextBox titleField;
        private NumericUpDown priceField;
        private NumericUpDown stockField;
        private TableLayoutPanel formPanel;
        private TableLayoutPanel pricePanel;
        private TableLayoutPanel stockPanel;
    }
}