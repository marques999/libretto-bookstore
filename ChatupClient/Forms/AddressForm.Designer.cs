using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using IPAddressControlLib;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
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
            fieldPort = new TextBox();
            labelPassword = new Label();
            buttonCancel = new Button();
            buttonConfirm = new Button();
            flowLayout = new FlowLayoutPanel();
            tableLayout = new TableLayoutPanel();
            fieldAddress = new IPAddressControl();
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
            flowLayout.Location = new Point(0, 71);
            flowLayout.Margin = new Padding(0);
            flowLayout.Name = "flowLayout";
            flowLayout.Padding = new Padding(2);
            flowLayout.Size = new Size(284, 34);
            flowLayout.TabIndex = 3;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(145, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 24);
            buttonCancel.TabIndex = 9;
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
            buttonConfirm.TabIndex = 10;
            buttonConfirm.Text = "Apply";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += new EventHandler(buttonConfirm_Click);
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayout.Controls.Add(fieldAddress, 1, 0);
            tableLayout.Controls.Add(fieldPort, 1, 1);
            tableLayout.Controls.Add(labelName, 0, 0);
            tableLayout.Controls.Add(labelPassword, 0, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(0, 0);
            tableLayout.Margin = new Padding(0);
            tableLayout.Name = "tableLayout";
            tableLayout.Padding = new Padding(4);
            tableLayout.RowCount = 2;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.Size = new Size(284, 71);
            tableLayout.TabIndex = 12;
            // 
            // fieldAddress
            // 
            fieldAddress.AllowInternalTab = false;
            fieldAddress.AutoHeight = true;
            fieldAddress.BackColor = SystemColors.Window;
            fieldAddress.BorderStyle = BorderStyle.Fixed3D;
            fieldAddress.Cursor = Cursors.IBeam;
            fieldAddress.Dock = DockStyle.Fill;
            fieldAddress.Location = new Point(90, 8);
            fieldAddress.Margin = new Padding(4);
            fieldAddress.MinimumSize = new Size(87, 20);
            fieldAddress.Name = "fieldAddress";
            fieldAddress.ReadOnly = false;
            fieldAddress.Size = new Size(186, 20);
            fieldAddress.TabIndex = 13;
            fieldAddress.Text = "...";
            fieldAddress.TextChanged += new EventHandler(fieldName_TextChanged);
            // 
            // fieldPort
            // 
            fieldPort.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fieldPort.Location = new Point(90, 41);
            fieldPort.Margin = new Padding(4);
            fieldPort.Name = "fieldPort";
            fieldPort.Size = new Size(186, 20);
            fieldPort.TabIndex = 4;
            fieldPort.TextChanged += new EventHandler(fieldPassword_TextChanged);
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(7, 4);
            labelName.Name = "labelName";
            labelName.Size = new Size(76, 31);
            labelName.TabIndex = 0;
            labelName.Text = "Address";
            labelName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Dock = DockStyle.Fill;
            labelPassword.Location = new Point(7, 35);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(76, 32);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Port";
            labelPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AddressForm
            // 
            AcceptButton = buttonConfirm;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 105);
            Controls.Add(tableLayout);
            Controls.Add(flowLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddressForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configure address";
            Load += new EventHandler(RegisterForm_Load);
            flowLayout.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        private Label labelName;
        private TextBox fieldPort;
        private Label labelPassword;
        private Button buttonCancel;
        private Button buttonConfirm;
        private FlowLayoutPanel flowLayout;
        private TableLayoutPanel tableLayout;
        private IPAddressControl fieldAddress;
    }
}