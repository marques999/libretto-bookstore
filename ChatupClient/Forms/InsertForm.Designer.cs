﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    partial class InsertForm
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
            flowLayout = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonConfirm = new Button();
            tableLayout = new TableLayoutPanel();
            fieldPassword = new TextBox();
            labelName = new Label();
            labelPassword = new Label();
            labelCapacity = new Label();
            fieldName = new TextBox();
            fieldCapacity = new NumericUpDown();
            flowLayout.SuspendLayout();
            tableLayout.SuspendLayout();
            ((ISupportInitialize)(fieldCapacity)).BeginInit();
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
            flowLayout.TabIndex = 2;
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
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += new EventHandler(buttonConfirm_Click);
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayout.Controls.Add(fieldPassword, 1, 1);
            tableLayout.Controls.Add(labelName, 0, 0);
            tableLayout.Controls.Add(labelPassword, 0, 1);
            tableLayout.Controls.Add(labelCapacity, 0, 2);
            tableLayout.Controls.Add(fieldName, 1, 0);
            tableLayout.Controls.Add(fieldCapacity, 1, 2);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(0, 0);
            tableLayout.Margin = new Padding(0);
            tableLayout.Name = "tableLayout";
            tableLayout.Padding = new Padding(4);
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayout.Size = new Size(284, 92);
            tableLayout.TabIndex = 3;
            // 
            // fieldPassword
            // 
            fieldPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fieldPassword.Location = new Point(90, 36);
            fieldPassword.Margin = new Padding(4);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.Size = new Size(186, 20);
            fieldPassword.TabIndex = 4;
            fieldPassword.TextChanged += new EventHandler(fieldPassword_TextChanged);
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(7, 4);
            labelName.Name = "labelName";
            labelName.Size = new Size(76, 28);
            labelName.TabIndex = 0;
            labelName.Text = "Name";
            labelName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Dock = DockStyle.Fill;
            labelPassword.Location = new Point(7, 32);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(76, 28);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Password";
            labelPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelCapacity
            // 
            labelCapacity.AutoSize = true;
            labelCapacity.Dock = DockStyle.Fill;
            labelCapacity.Location = new Point(7, 60);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(76, 28);
            labelCapacity.TabIndex = 2;
            labelCapacity.Text = "Capacity";
            labelCapacity.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldName
            // 
            fieldName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fieldName.Location = new Point(90, 8);
            fieldName.Margin = new Padding(4);
            fieldName.Name = "fieldName";
            fieldName.Size = new Size(186, 20);
            fieldName.TabIndex = 3;
            fieldName.TextChanged += new EventHandler(fieldName_TextChanged);
            // 
            // fieldCapacity
            // 
            fieldCapacity.Dock = DockStyle.Fill;
            fieldCapacity.Location = new Point(90, 64);
            fieldCapacity.Margin = new Padding(4);
            fieldCapacity.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            fieldCapacity.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            fieldCapacity.Name = "fieldCapacity";
            fieldCapacity.Size = new Size(186, 20);
            fieldCapacity.TabIndex = 5;
            fieldCapacity.Value = new decimal(new int[] { 4, 0, 0, 0 });
            AcceptButton = buttonConfirm;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 126);
            Controls.Add(tableLayout);
            Controls.Add(flowLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InsertForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Insert room";
            TopMost = true;
            Load += new EventHandler(CreateForm_Load);
            flowLayout.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ((ISupportInitialize)(fieldCapacity)).EndInit();
            ResumeLayout(false);
        }

        private FlowLayoutPanel flowLayout;
        private TableLayoutPanel tableLayout;
        private Label labelName;
        private Label labelPassword;
        private Label labelCapacity;
        private TextBox fieldPassword;
        private TextBox fieldName;
        private Button buttonCancel;
        private Button buttonConfirm;
        private NumericUpDown fieldCapacity;
    }
}