using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Libretto.Controls;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LoginForm));
            emailLabel = new Label();
            emailField = new TextBox();
            passwordLabel = new Label();
            passwordField = new TextBox();
            buttonCancel = new FlatButton();
            buttonValidate = new FlatButton();
            formPanel = new TableLayoutPanel();
            buttonPanel = new TableLayoutPanel();
            pictureBox = new PictureBox();
            formPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            ((ISupportInitialize)(pictureBox)).BeginInit();
            SuspendLayout();
            //
            // emailLabel
            //
            emailLabel.BackColor = Color.LightGray;
            emailLabel.BorderStyle = BorderStyle.FixedSingle;
            emailLabel.Dock = DockStyle.Fill;
            emailLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(8, 0);
            emailLabel.Margin = new Padding(8, 0, 8, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(268, 27);
            emailLabel.Text = "E-mail";
            emailLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // emailField
            //
            emailField.Dock = DockStyle.Fill;
            emailField.Location = new Point(8, 35);
            emailField.Margin = new Padding(8);
            emailField.Name = "emailField";
            emailField.Size = new Size(268, 20);
            emailField.TabIndex = 2;
            emailField.Text = "admin@libretto.pt";
            emailField.TextChanged += new EventHandler(FieldEmail_TextChanged);
            emailField.KeyPress += new KeyPressEventHandler(FieldEmail_KeyPress);
            //
            // passwordLabel
            //
            passwordLabel.BackColor = Color.LightGray;
            passwordLabel.BorderStyle = BorderStyle.FixedSingle;
            passwordLabel.Dock = DockStyle.Fill;
            passwordLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(8, 62);
            passwordLabel.Margin = new Padding(8, 0, 8, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(268, 27);
            passwordLabel.Text = "Password";
            passwordLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // passwordField
            //
            passwordField.Dock = DockStyle.Fill;
            passwordField.Location = new Point(8, 97);
            passwordField.Margin = new Padding(8);
            passwordField.Name = "passwordField";
            passwordField.PasswordChar = '*';
            passwordField.Size = new Size(268, 20);
            passwordField.TabIndex = 3;
            passwordField.Text = "changemeplease";
            passwordField.TextChanged += new EventHandler(FieldPassword_TextChanged);
            passwordField.KeyPress += new KeyPressEventHandler(FieldPassword_KeyPress);
            //
            // buttonCancel
            //
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(145, 7);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 26);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += new EventHandler(ButtonCancel_Click);
            //
            // buttonValidate
            //
            buttonValidate.Location = new Point(7, 7);
            buttonValidate.Name = "buttonValidate";
            buttonValidate.Size = new Size(132, 26);
            buttonValidate.TabIndex = 0;
            buttonValidate.Text = "Validate";
            buttonValidate.Click += new EventHandler(ButtonValidate_Click);
            //
            // formPanel
            //
            formPanel.ColumnCount = 1;
            formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formPanel.Controls.Add(emailLabel, 0, 0);
            formPanel.Controls.Add(emailField, 0, 1);
            formPanel.Controls.Add(passwordLabel, 0, 2);
            formPanel.Controls.Add(passwordField, 0, 3);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(0, 242);
            formPanel.Name = "formPanel";
            formPanel.RowCount = 4;
            formPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            formPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            formPanel.Size = new Size(284, 129);
            //
            // buttonPanel
            //
            buttonPanel.BackColor = Color.DarkGray;
            buttonPanel.ColumnCount = 2;
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonPanel.Controls.Add(buttonValidate, 0, 0);
            buttonPanel.Controls.Add(buttonCancel, 1, 0);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 371);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(4);
            buttonPanel.RowCount = 1;
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonPanel.Size = new Size(284, 40);
            //
            // pictureBox
            //
            pictureBox.Dock = DockStyle.Top;
            pictureBox.Image = ((Image)(resources.GetObject("pictureBox.Image")));
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(284, 242);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            //
            // LoginForm
            //
            AcceptButton = buttonValidate;
            CancelButton = buttonCancel;
            ClientSize = new Size(284, 411);
            Controls.Add(formPanel);
            Controls.Add(buttonPanel);
            Controls.Add(pictureBox);
            Icon = Resources.librettoIcon;
            Name = "LoginForm";
            ShowIcon = true;
            ShowInTaskbar = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Libretto Bookstore";
            Load += new EventHandler(LoginForm_Load);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ((ISupportInitialize)(pictureBox)).EndInit();
            ResumeLayout(false);
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