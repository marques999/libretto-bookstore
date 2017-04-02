using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class RegisterForm
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
            labelName = new Label();
            labelFullname = new Label();
            labelPassword = new Label();
            fieldName = new TextBox();
            fieldPassword = new TextBox();
            fieldUsername = new TextBox();
            buttonCancel = new Button();
            buttonConfirm = new Button();
            flowLayout = new FlowLayoutPanel();
            tableLayout = new TableLayoutPanel();
            flowLayout.SuspendLayout();
            tableLayout.SuspendLayout();
            SuspendLayout();
            //
            // flowLayout
            //
            flowLayout.Controls.Add(buttonCancel);
            flowLayout.Controls.Add(buttonConfirm);
            flowLayout.Dock = DockStyle.Bottom;
            flowLayout.FlowDirection = FlowDirection.RightToLeft;
            flowLayout.Location = new Point(0, 92);
            flowLayout.Margin = new Padding(0);
            flowLayout.Name = "flowLayout";
            flowLayout.Padding = new Padding(2);
            flowLayout.Size = new Size(284, 34);
            flowLayout.TabIndex = 8;
            //
            // buttonCancel
            //
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(145, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 24);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += new EventHandler(buttonCancel_Click);
            //
            // buttonConfirm
            //
            buttonConfirm.BackColor = SystemColors.Control;
            buttonConfirm.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Location = new Point(7, 5);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(132, 24);
            buttonConfirm.TabIndex = 6;
            buttonConfirm.Text = "Validate";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += new EventHandler(buttonConfirm_Click);
            //
            // tableLayout
            //
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayout.Controls.Add(labelName, 0, 0);
            tableLayout.Controls.Add(labelFullname, 0, 1);
            tableLayout.Controls.Add(labelPassword, 0, 2);
            tableLayout.Controls.Add(fieldUsername, 1, 0);
            tableLayout.Controls.Add(fieldPassword, 1, 2);
            tableLayout.Controls.Add(fieldName, 1, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(0, 0);
            tableLayout.Margin = new Padding(0);
            tableLayout.Name = "tableLayout";
            tableLayout.Padding = new Padding(4);
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.Size = new Size(284, 92);
            tableLayout.TabIndex = 9;
            //
            // labelName
            //
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(7, 4);
            labelName.Name = "labelName";
            labelName.Size = new Size(76, 28);
            labelName.TabIndex = 0;
            labelName.Text = "Username";
            labelName.TextAlign = ContentAlignment.MiddleRight;
            //
            // labelFullname
            //
            labelFullname.AutoSize = true;
            labelFullname.Dock = DockStyle.Fill;
            labelFullname.Location = new Point(7, 32);
            labelFullname.Name = "labelFullname";
            labelFullname.Size = new Size(76, 28);
            labelFullname.TabIndex = 2;
            labelFullname.Text = "Full Name";
            labelFullname.TextAlign = ContentAlignment.MiddleRight;
            //
            // labelPassword
            //
            labelPassword.AutoSize = true;
            labelPassword.Dock = DockStyle.Fill;
            labelPassword.Location = new Point(7, 60);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(76, 28);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Password";
            labelPassword.TextAlign = ContentAlignment.MiddleRight;
            //
            // fieldUsername
            //
            fieldUsername.Dock = DockStyle.Fill;
            fieldUsername.Location = new Point(90, 8);
            fieldUsername.Margin = new Padding(4);
            fieldUsername.Name = "fieldUsername";
            fieldUsername.Size = new Size(186, 20);
            fieldUsername.TabIndex = 1;
            fieldUsername.TextChanged += new EventHandler(fieldUsername_TextChanged);
            fieldUsername.KeyPress += new KeyPressEventHandler(fieldUsername_KeyPress);
            //
            // fieldPassword
            //
            fieldPassword.Dock = DockStyle.Fill;
            fieldPassword.Location = new Point(90, 64);
            fieldPassword.Margin = new Padding(4);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.PasswordChar = '*';
            fieldPassword.Size = new Size(186, 20);
            fieldPassword.TabIndex = 5;
            fieldPassword.TextChanged += new EventHandler(fieldPassword_TextChanged);
            fieldPassword.KeyPress += new KeyPressEventHandler(fieldPassword_KeyPress);
            //
            // fieldName
            //
            fieldName.Dock = DockStyle.Fill;
            fieldName.Location = new Point(90, 36);
            fieldName.Margin = new Padding(4);
            fieldName.Name = "fieldName";
            fieldName.Size = new Size(186, 20);
            fieldName.TabIndex = 3;
            fieldName.TextChanged += new EventHandler(fieldName_TextChanged);
            fieldName.KeyPress += new KeyPressEventHandler(fieldName_KeyPress);
            //
            // RegisterForm
            //
            AcceptButton = buttonConfirm;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 126);
            Controls.Add(tableLayout);
            Controls.Add(flowLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register user";
            Load += new EventHandler(RegisterForm_Load);
            flowLayout.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        private Label labelName;
        private Label labelFullname;
        private Label labelPassword;
        private TextBox fieldName;
        private TextBox fieldPassword;
        private TextBox fieldUsername;
        private Button buttonCancel;
        private Button buttonConfirm;
        private FlowLayoutPanel flowLayout;
        private TableLayoutPanel tableLayout;
    }
}