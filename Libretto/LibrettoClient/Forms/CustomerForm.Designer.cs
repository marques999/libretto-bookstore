using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class CustomerForm
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
            formPanel = new TableLayoutPanel();
            locationLabel = new Label();
            nameField = new TextBox();
            guidLabel = new Label();
            nameLabel = new Label();
            emailLabel = new Label();
            guidField = new TextBox();
            emailField = new TextBox();
            locationField = new TextBox();
            buttonPanel = new Panel();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            formPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
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
            formPanel.Controls.Add(nameLabel, 0, 1);
            formPanel.Controls.Add(nameField, 1, 1);
            formPanel.Controls.Add(emailLabel, 0, 2);
            formPanel.Controls.Add(emailField, 1, 2);
            formPanel.Controls.Add(locationLabel, 0, 3);
            formPanel.Controls.Add(locationField, 1, 3);
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
            // locationLabel
            //
            locationLabel.AutoSize = true;
            locationLabel.BackColor = Color.Silver;
            locationLabel.Dock = DockStyle.Fill;
            locationLabel.Location = new Point(5, 98);
            locationLabel.Margin = new Padding(0);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(50, 30);
            locationLabel.Text = "Location";
            locationLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // nameField
            //
            nameField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameField.Location = new Point(60, 41);
            nameField.Margin = new Padding(4);
            nameField.Name = "nameField";
            nameField.Size = new Size(215, 20);
            nameField.TabIndex = 2;
            nameField.TextChanged += new EventHandler(NameField_TextChanged);
            nameField.KeyPress += new KeyPressEventHandler(NameField_KeyPress);
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
            // nameLabel
            //
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.Silver;
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Location = new Point(5, 36);
            nameLabel.Margin = new Padding(0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 30);
            nameLabel.Text = "Name";
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // emailLabel
            //
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Silver;
            emailLabel.Dock = DockStyle.Fill;
            emailLabel.Location = new Point(5, 67);
            emailLabel.Margin = new Padding(0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 30);
            emailLabel.Text = "E-mail";
            emailLabel.TextAlign = ContentAlignment.MiddleCenter;
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
            // emailField
            //
            emailField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            emailField.Location = new Point(60, 72);
            emailField.Margin = new Padding(4);
            emailField.Name = "emailField";
            emailField.Size = new Size(215, 20);
            emailField.TabIndex = 3;
            emailField.TextChanged += new EventHandler(EmailField_TextChanged);
            emailField.KeyPress += new KeyPressEventHandler(EmailField_KeyPress);
            //
            // locationField
            //
            locationField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            locationField.Location = new Point(60, 103);
            locationField.Margin = new Padding(4);
            locationField.Name = "locationField";
            locationField.Size = new Size(215, 20);
            locationField.TabIndex = 4;
            locationField.TextChanged += new EventHandler(LocationField_TextChanged);
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
            buttonConfirm.DialogResult = DialogResult.Cancel;
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
            // CustomerForm
            //
            AcceptButton = buttonConfirm;
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(284, 169);
            Controls.Add(formPanel);
            Controls.Add(buttonPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register Customer";
            Load += new EventHandler(CustomerForm_Load);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label guidLabel;
        private Label nameLabel;
        private Label emailLabel;
        private Label locationLabel;
        private TextBox guidField;
        private TextBox nameField;
        private TextBox emailField;
        private TextBox locationField;
        private Panel buttonPanel;
        private Button buttonConfirm;
        private Button buttonCancel;
        private TableLayoutPanel formPanel;
    }
}