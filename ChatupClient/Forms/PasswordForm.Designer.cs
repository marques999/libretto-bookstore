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
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.fieldPassword = new System.Windows.Forms.TextBox();
            this.flowLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.Controls.Add(this.buttonCancel);
            this.flowLayout.Controls.Add(this.buttonConfirm);
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayout.Location = new System.Drawing.Point(0, 72);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayout.Size = new System.Drawing.Size(284, 34);
            this.flowLayout.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(145, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 24);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Location = new System.Drawing.Point(7, 5);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(132, 24);
            this.buttonConfirm.TabIndex = 10;
            this.buttonConfirm.Text = "OK";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelPrompt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fieldPassword, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.94444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.05556F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 72);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // labelPrompt
            // 
            this.labelPrompt.AutoSize = true;
            this.labelPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPrompt.Location = new System.Drawing.Point(3, 0);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(278, 40);
            this.labelPrompt.TabIndex = 0;
            this.labelPrompt.Text = "Sorry, but this room is password protected!\r\nPlease enter the password that was g" +
    "iven to you.";
            this.labelPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldPassword
            // 
            this.fieldPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPassword.Location = new System.Drawing.Point(8, 48);
            this.fieldPassword.Margin = new System.Windows.Forms.Padding(8);
            this.fieldPassword.Name = "fieldPassword";
            this.fieldPassword.PasswordChar = '*';
            this.fieldPassword.Size = new System.Drawing.Size(268, 20);
            this.fieldPassword.TabIndex = 1;
            this.fieldPassword.TextChanged += new System.EventHandler(this.fieldPassword_TextChanged);
            // 
            // PasswordForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 106);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert password";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.flowLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private FlowLayoutPanel flowLayout;
        private Button buttonCancel;
        private Button buttonConfirm;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelPrompt;
        private TextBox fieldPassword;
    }
}