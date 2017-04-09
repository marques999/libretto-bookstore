using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class PasswordForm
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
            labelPassword = new Label();
            buttonCancel = new Button();
            buttonConfirm = new Button();
            fieldPassword = new TextBox();
            flowLayout = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            //
            // flowLayout
            //
            flowLayout.Controls.Add(buttonCancel);
            flowLayout.Controls.Add(buttonConfirm);
            flowLayout.Dock = DockStyle.Bottom;
            flowLayout.FlowDirection = FlowDirection.RightToLeft;
            flowLayout.Location = new Point(0, 72);
            flowLayout.Margin = new Padding(0);
            flowLayout.Name = "flowLayout";
            flowLayout.Padding = new Padding(2);
            flowLayout.Size = new Size(284, 34);
            //
            // buttonCancel
            //
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(145, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 24);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += new EventHandler(ButtonCancel_Click);
            //
            // buttonConfirm
            //
            buttonConfirm.BackColor = SystemColors.Control;
            buttonConfirm.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Location = new Point(7, 5);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(132, 24);
            buttonConfirm.TabIndex = 1;
            buttonConfirm.Text = "OK";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += new EventHandler(ButtonConfirm_Click);
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(labelPassword, 0, 0);
            tableLayoutPanel1.Controls.Add(fieldPassword, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.94444F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.05556F));
            tableLayoutPanel1.Size = new Size(284, 72);
            //
            // labelPrompt
            //
            labelPassword.AutoSize = true;
            labelPassword.Dock = DockStyle.Fill;
            labelPassword.Location = new Point(3, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(278, 40);
            labelPassword.Text = "Sorry, but this room is password protected!\r\nPlease enter the password that was given to you.";
            labelPassword.TextAlign = ContentAlignment.MiddleCenter;
            //
            // fieldPassword
            //
            fieldPassword.Dock = DockStyle.Fill;
            fieldPassword.Location = new Point(8, 48);
            fieldPassword.Margin = new Padding(8);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.PasswordChar = '*';
            fieldPassword.Size = new Size(268, 20);
            fieldPassword.TabIndex = 0;
            fieldPassword.TextChanged += new EventHandler(FieldPassword_TextChanged);
            fieldPassword.KeyPress += new KeyPressEventHandler(FieldPassword_KeyPress);
            //
            // PasswordForm
            //
            AcceptButton = buttonConfirm;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 106);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Insert password";
            Load += new EventHandler(PasswordForm_Load);
            flowLayout.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private Label labelPassword;
        private Button buttonCancel;
        private Button buttonConfirm;
        private TextBox fieldPassword;
        private FlowLayoutPanel flowLayout;
        private TableLayoutPanel tableLayoutPanel1;
    }
}