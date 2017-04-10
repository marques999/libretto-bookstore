﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InventoryForm
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
            buttonPanel = new FlowLayoutPanel();
            buttonRefresh = new Button();
            buttonPublish = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            booksPanel = new TableLayoutPanel();
            listView = new ListView();
            columnId = new ColumnHeader();
            columnTitle = new ColumnHeader();
            columnPrice = new ColumnHeader();
            columnStock = new ColumnHeader();
            booksLabel = new Label();
            buttonPanel.SuspendLayout();
            booksPanel.SuspendLayout();
            SuspendLayout();
            //
            // buttonPanel
            //
            buttonPanel.Controls.Add(buttonRefresh);
            buttonPanel.Controls.Add(buttonPublish);
            buttonPanel.Controls.Add(buttonUpdate);
            buttonPanel.Controls.Add(buttonDelete);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(4, 375);
            buttonPanel.Margin = new Padding(0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(616, 32);
            //
            // buttonRefresh
            //
            buttonRefresh.AutoSize = true;
            buttonRefresh.BackColor = SystemColors.Control;
            buttonRefresh.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRefresh.Location = new Point(0, 4);
            buttonRefresh.Margin = new Padding(0, 4, 2, 4);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(150, 28);
            buttonRefresh.TabIndex = 0;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.Click += new EventHandler(ButtonRefresh_Click);
            //
            // buttonPublish
            //
            buttonPublish.BackColor = SystemColors.Control;
            buttonPublish.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonPublish.FlatStyle = FlatStyle.Flat;
            buttonPublish.Location = new Point(154, 4);
            buttonPublish.Margin = new Padding(2, 4, 2, 4);
            buttonPublish.Name = "buttonPublish";
            buttonPublish.Size = new Size(151, 28);
            buttonPublish.TabIndex = 1;
            buttonPublish.Text = "Publish Book";
            buttonPublish.Click += new EventHandler(ButtonPublish_Click);
            //
            // buttonUpdate
            //
            buttonUpdate.AutoSize = true;
            buttonUpdate.BackColor = SystemColors.Control;
            buttonUpdate.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.Location = new Point(309, 4);
            buttonUpdate.Margin = new Padding(2, 4, 2, 4);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(151, 28);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.Text = "Update Book";
            buttonUpdate.Click += new EventHandler(ButtonUpdate_Click);
            //
            // buttonDelete
            //
            buttonDelete.AutoSize = true;
            buttonDelete.BackColor = SystemColors.Control;
            buttonDelete.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDelete.Location = new Point(464, 4);
            buttonDelete.Margin = new Padding(2, 4, 0, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(151, 28);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Remove Book";
            buttonDelete.Click += new EventHandler(ButtonDelete_Click);
            //
            // booksPanel
            //
            booksPanel.ColumnCount = 1;
            booksPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            booksPanel.Controls.Add(listView, 0, 1);
            booksPanel.Controls.Add(booksLabel, 0, 0);
            booksPanel.Dock = DockStyle.Fill;
            booksPanel.Location = new Point(4, 4);
            booksPanel.Name = "booksPanel";
            booksPanel.RowCount = 2;
            booksPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            booksPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            booksPanel.Size = new Size(616, 371);
            //
            // listView
            //
            listView.BackColor = Color.WhiteSmoke;
            listView.Columns.AddRange(new ColumnHeader[] { columnId, columnTitle, columnPrice, columnStock });
            listView.Dock = DockStyle.Fill;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView.LabelWrap = false;
            listView.Location = new Point(0, 24);
            listView.Margin = new Padding(0);
            listView.MultiSelect = false;
            listView.Name = "listView";
            listView.Size = new Size(616, 347);
            listView.TabIndex = 4;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            listView.MouseDoubleClick += new MouseEventHandler(BooksList_MouseDoubleClick);
            //
            // booksLabel
            //
            booksLabel.AutoSize = true;
            booksLabel.BackColor = SystemColors.ControlDarkDark;
            booksLabel.Dock = DockStyle.Fill;
            booksLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            booksLabel.ForeColor = Color.Silver;
            booksLabel.Location = new Point(0, 0);
            booksLabel.Margin = new Padding(0);
            booksLabel.Name = "booksLabel";
            booksLabel.Padding = new Padding(2);
            booksLabel.Size = new Size(616, 24);
            booksLabel.Text = "Books";
            booksLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // InventoryForm
            //
            columnId.Text = "ID";
            columnId.Width = 220;
            columnTitle.Text = "Title";
            columnTitle.Width = 240;
            columnPrice.Text = "Price";
            columnPrice.TextAlign = HorizontalAlignment.Center;
            columnPrice.Width = 72;
            columnStock.Text = "Stock";
            columnStock.TextAlign = HorizontalAlignment.Center;
            columnStock.Width = 72;
            AcceptButton = buttonRefresh;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(624, 411);
            Controls.Add(booksPanel);
            Controls.Add(buttonPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InventoryForm";
            Padding = new Padding(4);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Store Management";
            Load += new EventHandler(BookForm_Load);
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            booksPanel.ResumeLayout(false);
            booksPanel.PerformLayout();
            ResumeLayout(false);
        }

        private Label booksLabel;
        private ListView listView;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonPublish;
        private Button buttonRefresh;
        private ColumnHeader columnId;
        private ColumnHeader columnPrice;
        private ColumnHeader columnStock;
        private ColumnHeader columnTitle;
        private FlowLayoutPanel buttonPanel;
        private TableLayoutPanel booksPanel;
    }
}