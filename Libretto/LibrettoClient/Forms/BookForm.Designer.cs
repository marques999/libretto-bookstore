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
    internal sealed partial class BookForm
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
            buttonPanel = new Panel();
            buttonConfirm = new FlatButton();
            buttonCancel = new FlatButton();
            formPanel = new TableLayoutPanel();
            stockLabel = new FlatLabel();
            titleField = new TextBox();
            guidLabel = new FlatLabel();
            titleLabel = new FlatLabel();
            priceLabel = new FlatLabel();
            guidField = new TextBox();
            stockPanel = new TableLayoutPanel();
            stockField = new NumericUpDown();
            unitsLabel = new FlatBadge();
            pricePanel = new TableLayoutPanel();
            currencyLabel = new FlatBadge();
            priceField = new NumericUpDown();
            buttonPanel.SuspendLayout();
            formPanel.SuspendLayout();
            stockPanel.SuspendLayout();
            stockField.BeginInit();
            pricePanel.SuspendLayout();
            priceField.BeginInit();
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
            buttonConfirm.DialogResult = DialogResult.OK;
            buttonConfirm.Dock = DockStyle.Left;
            buttonConfirm.Location = new Point(6, 6);
            buttonConfirm.Margin = new Padding(0);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(134, 24);
            buttonConfirm.TabIndex = 0;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.Click += new EventHandler(ButtonConfirm_Click);
            //
            // buttonCancel
            //
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Dock = DockStyle.Right;
            buttonCancel.Location = new Point(144, 6);
            buttonCancel.Margin = new Padding(0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(134, 24);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
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
            guidLabel.Location = new Point(5, 5);
            guidLabel.Name = "guidLabel";
            guidLabel.Size = new Size(50, 30);
            guidLabel.Text = "GUID";
            //
            // priceLabel
            //
            priceLabel.Location = new Point(5, 67);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(50, 30);
            priceLabel.Text = "Price";
            //
            // stockLabel
            //
            stockLabel.Location = new Point(5, 98);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(50, 30);
            stockLabel.Text = "Stock";
            //
            // titleLabel
            //
            titleLabel.Location = new Point(5, 36);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(50, 30);
            titleLabel.Text = "Title";
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
            unitsLabel.Location = new Point(188, 0);
            unitsLabel.Name = "unitsLabel";
            unitsLabel.Size = new Size(26, 24);
            unitsLabel.Text = "Un";
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
            currencyLabel.Location = new Point(188, 0);
            currencyLabel.Name = "currencyLabel";
            currencyLabel.Size = new Size(26, 24);
            currencyLabel.Text = "€";
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
            CancelButton = buttonCancel;
            ClientSize = new Size(284, 169);
            Controls.Add(formPanel);
            Controls.Add(buttonPanel);
            Name = "BookForm";
            Text = "Publish Book";
            Load += new EventHandler(BookForm_Load);
            buttonPanel.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            stockPanel.ResumeLayout(false);
            stockPanel.PerformLayout();
            stockField.EndInit();
            pricePanel.ResumeLayout(false);
            pricePanel.PerformLayout();
            priceField.EndInit();
            ResumeLayout(false);
        }

        private Panel buttonPanel;
        private FlatButton buttonConfirm;
        private FlatButton buttonCancel;
        private FlatLabel guidLabel;
        private FlatLabel priceLabel;
        private FlatLabel stockLabel;
        private FlatLabel titleLabel;
        private FlatBadge unitsLabel;
        private FlatBadge currencyLabel;
        private TextBox guidField;
        private TextBox titleField;
        private NumericUpDown priceField;
        private NumericUpDown stockField;
        private TableLayoutPanel formPanel;
        private TableLayoutPanel pricePanel;
        private TableLayoutPanel stockPanel;
    }
}