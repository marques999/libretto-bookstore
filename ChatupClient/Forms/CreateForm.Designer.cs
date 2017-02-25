using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET
{
    partial class CreateForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fieldPassword = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.fieldName = new System.Windows.Forms.TextBox();
            this.fieldCapacity = new System.Windows.Forms.ComboBox();
            this.flowLayout.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.Controls.Add(this.buttonCancel);
            this.flowLayout.Controls.Add(this.buttonConfirm);
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayout.Location = new System.Drawing.Point(0, 92);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayout.Size = new System.Drawing.Size(284, 34);
            this.flowLayout.TabIndex = 2;
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
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayout.Controls.Add(this.fieldPassword, 1, 1);
            this.tableLayout.Controls.Add(this.labelName, 0, 0);
            this.tableLayout.Controls.Add(this.labelPassword, 0, 1);
            this.tableLayout.Controls.Add(this.labelCapacity, 0, 2);
            this.tableLayout.Controls.Add(this.fieldName, 1, 0);
            this.tableLayout.Controls.Add(this.fieldCapacity, 1, 2);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayout.RowCount = 3;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayout.Size = new System.Drawing.Size(284, 92);
            this.tableLayout.TabIndex = 3;
            // 
            // fieldPassword
            // 
            this.fieldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldPassword.Location = new System.Drawing.Point(90, 36);
            this.fieldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.fieldPassword.Name = "fieldPassword";
            this.fieldPassword.Size = new System.Drawing.Size(186, 20);
            this.fieldPassword.TabIndex = 4;
            this.fieldPassword.TextChanged += new System.EventHandler(this.fieldPassword_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(7, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 28);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Location = new System.Drawing.Point(7, 32);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(76, 28);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCapacity.Location = new System.Drawing.Point(7, 60);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(76, 28);
            this.labelCapacity.TabIndex = 2;
            this.labelCapacity.Text = "Capacity";
            this.labelCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fieldName
            // 
            this.fieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldName.Location = new System.Drawing.Point(90, 8);
            this.fieldName.Margin = new System.Windows.Forms.Padding(4);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(186, 20);
            this.fieldName.TabIndex = 3;
            this.fieldName.TextChanged += new System.EventHandler(this.fieldName_TextChanged);
            // 
            // fieldCapacity
            // 
            this.fieldCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldCapacity.FormattingEnabled = true;
            this.fieldCapacity.Items.AddRange(new object[] {
            "Unrestricted",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.fieldCapacity.Location = new System.Drawing.Point(89, 63);
            this.fieldCapacity.Name = "fieldCapacity";
            this.fieldCapacity.Size = new System.Drawing.Size(188, 21);
            this.fieldCapacity.TabIndex = 5;
            this.fieldCapacity.Text = "Unrestricted";
            // 
            // CreateForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 126);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.flowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert room";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.flowLayout.ResumeLayout(false);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        private FlowLayoutPanel flowLayout;
        private TableLayoutPanel tableLayout;
        private Label labelName;
        private Label labelPassword;
        private Label labelCapacity;
        private TextBox fieldPassword;
        private TextBox fieldName;
        private ComboBox fieldCapacity;
        private Button buttonCancel;
        private Button buttonConfirm;
    }
}