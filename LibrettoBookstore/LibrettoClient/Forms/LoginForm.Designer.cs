using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Libretto.Properties;

namespace Libretto.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailField = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.buttonCancel = new Libretto.Forms.FlatButton();
            this.buttonValidate = new Libretto.Forms.FlatButton();
            this.formPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.formPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.LightGray;
            this.emailLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailLabel.Location = new System.Drawing.Point(8, 0);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(268, 27);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E-mail";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailField
            // 
            this.emailField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailField.Location = new System.Drawing.Point(8, 35);
            this.emailField.Margin = new System.Windows.Forms.Padding(8);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(268, 20);
            this.emailField.TabIndex = 2;
            this.emailField.Text = "admin@libretto.pt";
            this.emailField.TextChanged += new System.EventHandler(this.FieldEmail_TextChanged);
            this.emailField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldEmail_KeyPress);
            // 
            // passwordLabel
            // 
            this.passwordLabel.BackColor = System.Drawing.Color.LightGray;
            this.passwordLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordLabel.Location = new System.Drawing.Point(8, 62);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(268, 27);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordField
            // 
            this.passwordField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordField.Location = new System.Drawing.Point(8, 97);
            this.passwordField.Margin = new System.Windows.Forms.Padding(8);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(268, 20);
            this.passwordField.TabIndex = 3;
            this.passwordField.Text = "changemeplease";
            this.passwordField.TextChanged += new System.EventHandler(this.FieldPassword_TextChanged);
            this.passwordField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldPassword_KeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(145, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 26);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonValidate
            // 
            this.buttonValidate.AutoSize = true;
            this.buttonValidate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValidate.Location = new System.Drawing.Point(7, 7);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(132, 26);
            this.buttonValidate.TabIndex = 0;
            this.buttonValidate.Text = "Validate";
            this.buttonValidate.UseVisualStyleBackColor = false;
            this.buttonValidate.Click += new System.EventHandler(this.ButtonValidate_Click);
            // 
            // formPanel
            // 
            this.formPanel.ColumnCount = 1;
            this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formPanel.Controls.Add(this.emailLabel, 0, 0);
            this.formPanel.Controls.Add(this.emailField, 0, 1);
            this.formPanel.Controls.Add(this.passwordLabel, 0, 2);
            this.formPanel.Controls.Add(this.passwordField, 0, 3);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(0, 242);
            this.formPanel.Name = "formPanel";
            this.formPanel.RowCount = 4;
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.formPanel.Size = new System.Drawing.Size(284, 129);
            this.formPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPanel.ColumnCount = 2;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Controls.Add(this.buttonValidate, 0, 0);
            this.buttonPanel.Controls.Add(this.buttonCancel, 1, 0);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 371);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(4);
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Size = new System.Drawing.Size(284, 40);
            this.buttonPanel.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(284, 242);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.pictureBox);
            this.Icon = global::Libretto.Properties.Resources.librettoIcon;
            this.Name = "LoginForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libretto Bookstore";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        private Label emailLabel;
        private TextBox emailField;
        private Label passwordLabel;
        private TextBox passwordField;
        private FlatButton buttonCancel;
        private FlatButton buttonValidate;
        private TableLayoutPanel formPanel;
        private TableLayoutPanel buttonPanel;
        private PictureBox pictureBox;
    }
}