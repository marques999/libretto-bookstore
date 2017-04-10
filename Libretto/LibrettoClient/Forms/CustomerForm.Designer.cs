namespace Libretto.Forms
{
    partial class CustomerForm
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
            this.formPanel = new System.Windows.Forms.TableLayoutPanel();
            this.locationLabel = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.guidLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.guidField = new System.Windows.Forms.TextBox();
            this.emailField = new System.Windows.Forms.TextBox();
            this.locationField = new System.Windows.Forms.TextBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.formPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.formPanel.ColumnCount = 2;
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formPanel.Controls.Add(this.locationLabel, 0, 3);
            this.formPanel.Controls.Add(this.nameField, 1, 1);
            this.formPanel.Controls.Add(this.guidLabel, 0, 0);
            this.formPanel.Controls.Add(this.nameLabel, 0, 1);
            this.formPanel.Controls.Add(this.emailLabel, 0, 2);
            this.formPanel.Controls.Add(this.guidField, 1, 0);
            this.formPanel.Controls.Add(this.emailField, 1, 2);
            this.formPanel.Controls.Add(this.locationField, 1, 3);
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
            this.formPanel.TabIndex = 8;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.BackColor = System.Drawing.Color.Silver;
            this.locationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationLabel.Location = new System.Drawing.Point(5, 98);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(50, 30);
            this.locationLabel.TabIndex = 12;
            this.locationLabel.Text = "Location";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameField
            // 
            this.nameField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameField.Location = new System.Drawing.Point(60, 41);
            this.nameField.Margin = new System.Windows.Forms.Padding(4);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(215, 20);
            this.nameField.TabIndex = 0;
            this.nameField.TextChanged += new System.EventHandler(this.NameField_TextChanged);
            this.nameField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameField_KeyPress);
            // 
            // guidLabel
            // 
            this.guidLabel.AutoSize = true;
            this.guidLabel.BackColor = System.Drawing.Color.Silver;
            this.guidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guidLabel.Location = new System.Drawing.Point(5, 5);
            this.guidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.guidLabel.Name = "guidLabel";
            this.guidLabel.Size = new System.Drawing.Size(50, 30);
            this.guidLabel.TabIndex = 2;
            this.guidLabel.Text = "GUID";
            this.guidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Silver;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(5, 36);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(50, 30);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.Silver;
            this.emailLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailLabel.Location = new System.Drawing.Point(5, 67);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(50, 30);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "E-mail";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guidField
            // 
            this.guidField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guidField.Enabled = false;
            this.guidField.Location = new System.Drawing.Point(60, 10);
            this.guidField.Margin = new System.Windows.Forms.Padding(4);
            this.guidField.Name = "guidField";
            this.guidField.ReadOnly = true;
            this.guidField.Size = new System.Drawing.Size(215, 20);
            this.guidField.TabIndex = 1;
            // 
            // emailField
            // 
            this.emailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.emailField.Location = new System.Drawing.Point(60, 72);
            this.emailField.Margin = new System.Windows.Forms.Padding(4);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(215, 20);
            this.emailField.TabIndex = 10;
            this.emailField.TextChanged += new System.EventHandler(this.EmailField_TextChanged);
            // 
            // locationField
            // 
            this.locationField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.locationField.Location = new System.Drawing.Point(60, 103);
            this.locationField.Margin = new System.Windows.Forms.Padding(4);
            this.locationField.Name = "locationField";
            this.locationField.Size = new System.Drawing.Size(215, 20);
            this.locationField.TabIndex = 14;
            this.locationField.TextChanged += new System.EventHandler(this.LocationField_TextChanged);
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
            this.buttonPanel.TabIndex = 7;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // CustomerForm
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
            this.Name = "CustomerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Customer";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formPanel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox guidField;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.TextBox locationField;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}