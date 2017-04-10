namespace LibrettoClient
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelEmail = new System.Windows.Forms.Label();
            this.fieldEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.fieldPassword = new System.Windows.Forms.TextBox();
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.fieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fieldLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(8, 0);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(268, 27);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "E-mail";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldEmail
            // 
            this.fieldEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldEmail.Location = new System.Drawing.Point(8, 35);
            this.fieldEmail.Margin = new System.Windows.Forms.Padding(8);
            this.fieldEmail.Name = "fieldEmail";
            this.fieldEmail.Size = new System.Drawing.Size(268, 20);
            this.fieldEmail.TabIndex = 0;
            this.fieldEmail.Text = "dmarques@libretto.pt";
            this.fieldEmail.TextChanged += new System.EventHandler(this.FieldEmail_TextChanged);
            this.fieldEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldEmail_KeyPress);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(8, 62);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(268, 27);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldPassword
            // 
            this.fieldPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPassword.Location = new System.Drawing.Point(8, 97);
            this.fieldPassword.Margin = new System.Windows.Forms.Padding(8);
            this.fieldPassword.Name = "fieldPassword";
            this.fieldPassword.PasswordChar = '*';
            this.fieldPassword.Size = new System.Drawing.Size(268, 20);
            this.fieldPassword.TabIndex = 1;
            this.fieldPassword.Text = "14191091";
            this.fieldPassword.TextChanged += new System.EventHandler(this.FieldPassword_TextChanged);
            this.fieldPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldPassword_KeyPress);
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfigure.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigure.Location = new System.Drawing.Point(145, 7);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(132, 26);
            this.buttonConfigure.TabIndex = 4;
            this.buttonConfigure.Text = "Configure";
            this.buttonConfigure.UseVisualStyleBackColor = false;
            this.buttonConfigure.Click += new System.EventHandler(this.ButtonConfigure_Click);
            // 
            // buttonValidate
            // 
            this.buttonValidate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonValidate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonValidate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValidate.Location = new System.Drawing.Point(7, 7);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(132, 26);
            this.buttonValidate.TabIndex = 2;
            this.buttonValidate.Text = "Validate";
            this.buttonValidate.UseVisualStyleBackColor = false;
            this.buttonValidate.Click += new System.EventHandler(this.ButtonValidate_Click);
            // 
            // layoutFields
            // 
            this.fieldLayout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fieldLayout.ColumnCount = 1;
            this.fieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fieldLayout.Controls.Add(this.labelEmail, 0, 0);
            this.fieldLayout.Controls.Add(this.fieldEmail, 0, 1);
            this.fieldLayout.Controls.Add(this.labelPassword, 0, 2);
            this.fieldLayout.Controls.Add(this.fieldPassword, 0, 3);
            this.fieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldLayout.Location = new System.Drawing.Point(0, 242);
            this.fieldLayout.Name = "fieldLayout";
            this.fieldLayout.RowCount = 4;
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.fieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.fieldLayout.Size = new System.Drawing.Size(284, 129);
            this.fieldLayout.TabIndex = 3;
            // 
            // layoutButtons
            // 
            this.buttonLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonLayout.ColumnCount = 2;
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayout.Controls.Add(this.buttonConfigure, 1, 0);
            this.buttonLayout.Controls.Add(this.buttonValidate, 0, 0);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLayout.Location = new System.Drawing.Point(0, 371);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Padding = new System.Windows.Forms.Padding(4);
            this.buttonLayout.RowCount = 1;
            this.buttonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayout.Size = new System.Drawing.Size(284, 40);
            this.buttonLayout.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(284, 242);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.fieldLayout);
            this.Controls.Add(this.buttonLayout);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentication";
            this.fieldLayout.ResumeLayout(false);
            this.fieldLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox fieldEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox fieldPassword;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.TableLayoutPanel fieldLayout;
        private System.Windows.Forms.TableLayoutPanel buttonLayout;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}