using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET.Rooms
{
    /// <summary>
    ///
    /// </summary>
    abstract partial class AbstractRoom
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AbstractRoom));
            listBox1 = new ListBox();
            textBox2 = new TextBox();
            buttonValidate = new Button();
            richTextBox1 = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            //
            // buttonValidate
            //
            buttonValidate.BackColor = SystemColors.ControlLight;
            buttonValidate.Dock = DockStyle.Fill;
            buttonValidate.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonValidate.FlatStyle = FlatStyle.Flat;
            buttonValidate.Location = new Point(395, 352);
            buttonValidate.Name = "buttonValidate";
            buttonValidate.Size = new Size(134, 24);
            buttonValidate.TabIndex = 1;
            buttonValidate.Text = "Send";
            buttonValidate.UseVisualStyleBackColor = false;
            buttonValidate.Click += new EventHandler(buttonValidate_Click);
            //
            // textBox2
            //
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(5, 352);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(384, 23);
            textBox2.TabIndex = 19;
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            //
            // richTextBox1
            //
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(5, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(384, 341);
            richTextBox1.TabIndex = 21;
            richTextBox1.Text = "";
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.71663F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.28337F));
            tableLayoutPanel1.Controls.Add(buttonValidate, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(listBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(2);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.26804F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.731959F));
            tableLayoutPanel1.Size = new Size(534, 381);
            tableLayoutPanel1.TabIndex = 22;
            //
            // listBox1
            //
            listBox1.BackColor = SystemColors.ControlLight;
            listBox1.Dock = DockStyle.Fill;
            listBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.DimGray;
            listBox1.FormattingEnabled = true;
            listBox1.IntegralHeight = false;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(395, 5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(134, 341);
            listBox1.TabIndex = 18;
            //
            // AbstractRoom
            //
            AcceptButton = buttonValidate;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 381);
            Controls.Add(tableLayoutPanel1);
            Icon = ((Icon)(resources.GetObject("$this.Icon")));
            Name = "AbstractRoom";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Default [1/1]";
            FormClosing += new FormClosingEventHandler(AbstractRoom_FormClosing);
            Load += new EventHandler(RoomForm_Load);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private ListBox listBox1;
        private TextBox textBox2;
        private Button buttonValidate;
        private RichTextBox richTextBox1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}