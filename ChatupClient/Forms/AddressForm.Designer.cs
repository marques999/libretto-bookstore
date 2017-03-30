using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using IPAddressControlLib;

namespace ChatupNET.Forms
{
    internal partial class AddressForm
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fieldAddress = new IPAddressControlLib.IPAddressControl();
            this.fieldPort = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
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
            this.flowLayout.Location = new System.Drawing.Point(0, 71);
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
            this.buttonConfirm.Text = "Apply";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayout.Controls.Add(this.fieldAddress, 1, 0);
            this.tableLayout.Controls.Add(this.fieldPort, 1, 1);
            this.tableLayout.Controls.Add(this.labelName, 0, 0);
            this.tableLayout.Controls.Add(this.labelPassword, 0, 1);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Size = new System.Drawing.Size(284, 71);
            this.tableLayout.TabIndex = 12;
            // 
            // fieldAddress
            // 
            this.fieldAddress.AllowInternalTab = false;
            this.fieldAddress.AutoHeight = true;
            this.fieldAddress.BackColor = System.Drawing.SystemColors.Window;
            this.fieldAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fieldAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fieldAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldAddress.Location = new System.Drawing.Point(90, 8);
            this.fieldAddress.Margin = new System.Windows.Forms.Padding(4);
            this.fieldAddress.MinimumSize = new System.Drawing.Size(87, 20);
            this.fieldAddress.Name = "fieldAddress";
            this.fieldAddress.ReadOnly = false;
            this.fieldAddress.Size = new System.Drawing.Size(186, 20);
            this.fieldAddress.TabIndex = 13;
            this.fieldAddress.Text = "...";
            this.fieldAddress.TextChanged += new System.EventHandler(this.fieldName_TextChanged);
            // 
            // fieldPort
            // 
            this.fieldPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldPort.Location = new System.Drawing.Point(90, 41);
            this.fieldPort.Margin = new System.Windows.Forms.Padding(4);
            this.fieldPort.Name = "fieldPort";
            this.fieldPort.Size = new System.Drawing.Size(186, 20);
            this.fieldPort.TabIndex = 4;
            this.fieldPort.TextChanged += new System.EventHandler(this.fieldPassword_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(7, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 31);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Address";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Location = new System.Drawing.Point(7, 35);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(76, 32);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Port";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddressForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 105);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.flowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure address";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.flowLayout.ResumeLayout(false);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        private FlowLayoutPanel flowLayout;
        private Button buttonCancel;
        private Button buttonConfirm;
        private TableLayoutPanel tableLayout;
        private TextBox fieldPort;
        private Label labelName;
        private Label labelPassword;
        private IPAddressControl fieldAddress;
    }
}