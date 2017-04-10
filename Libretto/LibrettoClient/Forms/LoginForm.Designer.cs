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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LoginForm));
            labelEmail = new Label();
            fieldEmail = new TextBox();
            labelPassword = new Label();
            fieldPassword = new TextBox();
            buttonCancel = new Button();
            buttonValidate = new Button();
            fieldLayout = new TableLayoutPanel();
            buttonLayout = new TableLayoutPanel();
            pictureBox = new PictureBox();
            fieldLayout.SuspendLayout();
            buttonLayout.SuspendLayout();
            ((ISupportInitialize)(pictureBox)).BeginInit();
            SuspendLayout();
            //
            // labelEmail
            //
            labelEmail.BackColor = Color.Gainsboro;
            labelEmail.BorderStyle = BorderStyle.FixedSingle;
            labelEmail.Dock = DockStyle.Fill;
            labelEmail.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEmail.Location = new Point(8, 0);
            labelEmail.Margin = new Padding(8, 0, 8, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(268, 27);
            labelEmail.Text = "E-mail";
            labelEmail.TextAlign = ContentAlignment.MiddleCenter;
            //
            // fieldEmail
            //
            fieldEmail.Dock = DockStyle.Fill;
            fieldEmail.Location = new Point(8, 35);
            fieldEmail.Margin = new Padding(8);
            fieldEmail.Name = "fieldEmail";
            fieldEmail.Size = new Size(268, 20);
            fieldEmail.TabIndex = 2;
            fieldEmail.Text = "dmarques@libretto.pt";
            fieldEmail.TextChanged += new EventHandler(FieldEmail_TextChanged);
            fieldEmail.KeyPress += new KeyPressEventHandler(FieldEmail_KeyPress);
            //
            // labelPassword
            //
            labelPassword.BackColor = Color.Gainsboro;
            labelPassword.BorderStyle = BorderStyle.FixedSingle;
            labelPassword.Dock = DockStyle.Fill;
            labelPassword.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.Location = new Point(8, 62);
            labelPassword.Margin = new Padding(8, 0, 8, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(268, 27);
            labelPassword.Text = "Password";
            labelPassword.TextAlign = ContentAlignment.MiddleCenter;
            //
            // fieldPassword
            //
            fieldPassword.Dock = DockStyle.Fill;
            fieldPassword.Location = new Point(8, 97);
            fieldPassword.Margin = new Padding(8);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.PasswordChar = '*';
            fieldPassword.Size = new Size(268, 20);
            fieldPassword.TabIndex = 3;
            fieldPassword.Text = "14191091";
            fieldPassword.TextChanged += new EventHandler(FieldPassword_TextChanged);
            fieldPassword.KeyPress += new KeyPressEventHandler(FieldPassword_KeyPress);
            //
            // buttonCancel
            //
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.FlatAppearance.BorderColor = SystemColors.ControlDark;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(145, 7);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 26);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += new EventHandler(ButtonCancel_Click);
            //
            // buttonValidate
            //
            buttonValidate.BackColor = SystemColors.Control;
            buttonValidate.Dock = DockStyle.Fill;
            buttonValidate.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonValidate.FlatStyle = FlatStyle.Flat;
            buttonValidate.Location = new Point(7, 7);
            buttonValidate.Name = "buttonValidate";
            buttonValidate.Size = new Size(132, 26);
            buttonValidate.TabIndex = 0;
            buttonValidate.Text = "Validate";
            buttonValidate.UseVisualStyleBackColor = false;
            buttonValidate.Click += new EventHandler(ButtonValidate_Click);
            //
            // fieldLayout
            //
            fieldLayout.BackColor = SystemColors.ControlLight;
            fieldLayout.ColumnCount = 1;
            fieldLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fieldLayout.Controls.Add(labelEmail, 0, 0);
            fieldLayout.Controls.Add(fieldEmail, 0, 1);
            fieldLayout.Controls.Add(labelPassword, 0, 2);
            fieldLayout.Controls.Add(fieldPassword, 0, 3);
            fieldLayout.Dock = DockStyle.Fill;
            fieldLayout.Location = new Point(0, 242);
            fieldLayout.Name = "fieldLayout";
            fieldLayout.RowCount = 4;
            fieldLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            fieldLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            fieldLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            fieldLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            fieldLayout.Size = new Size(284, 129);
            //
            // buttonLayout
            //
            buttonLayout.BackColor = SystemColors.ControlDark;
            buttonLayout.ColumnCount = 2;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.Controls.Add(buttonCancel, 1, 0);
            buttonLayout.Controls.Add(buttonValidate, 0, 0);
            buttonLayout.Dock = DockStyle.Bottom;
            buttonLayout.Location = new Point(0, 371);
            buttonLayout.Name = "buttonLayout";
            buttonLayout.Padding = new Padding(4);
            buttonLayout.RowCount = 1;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonLayout.Size = new Size(284, 40);
            //
            // pictureBox
            //
            pictureBox.BackColor = SystemColors.ControlLight;
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
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(284, 411);
            Controls.Add(fieldLayout);
            Controls.Add(buttonLayout);
            Controls.Add(pictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.librettoIcon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            ShowIcon = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Libretto Bookstore";
            Load += new EventHandler(LoginForm_Load);
            fieldLayout.ResumeLayout(false);
            fieldLayout.PerformLayout();
            buttonLayout.ResumeLayout(false);
            ((ISupportInitialize)(pictureBox)).EndInit();
            ResumeLayout(false);
        }

        private Label labelEmail;
        private TextBox fieldEmail;
        private Label labelPassword;
        private TextBox fieldPassword;
        private Button buttonCancel;
        private Button buttonValidate;
        private TableLayoutPanel fieldLayout;
        private TableLayoutPanel buttonLayout;
        private PictureBox pictureBox;
    }
}