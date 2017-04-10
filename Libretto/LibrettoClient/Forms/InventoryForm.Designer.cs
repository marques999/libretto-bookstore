namespace Libretto.Forms
{
    partial class InventoryForm
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
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonPublish = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.Controls.Add(this.buttonRefresh);
            this.flowLayout.Controls.Add(this.buttonPublish);
            this.flowLayout.Controls.Add(this.buttonUpdate);
            this.flowLayout.Controls.Add(this.buttonDelete);
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayout.Location = new System.Drawing.Point(4, 375);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(616, 32);
            this.flowLayout.TabIndex = 12;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.AutoSize = true;
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRefresh.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(0, 4);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(0, 4, 2, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(150, 28);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh (F5)";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // buttonPublish
            // 
            this.buttonPublish.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPublish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPublish.Location = new System.Drawing.Point(154, 4);
            this.buttonPublish.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(151, 28);
            this.buttonPublish.TabIndex = 6;
            this.buttonPublish.Text = "Publish Book";
            this.buttonPublish.UseVisualStyleBackColor = false;
            this.buttonPublish.Click += new System.EventHandler(this.ButtonPublish_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AutoSize = true;
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Location = new System.Drawing.Point(309, 4);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(151, 28);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Update Book";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(464, 4);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(151, 28);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Remove Book";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 371);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnTitle,
            this.columnPrice,
            this.columnStock});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 24);
            this.listView.Margin = new System.Windows.Forms.Padding(0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(616, 347);
            this.listView.TabIndex = 12;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BooksList_MouseDoubleClick);
            // 
            // columnId
            // 
            this.columnId.Text = "ID";
            this.columnId.Width = 220;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            this.columnTitle.Width = 240;
            // 
            // columnPrice
            // 
            this.columnPrice.Text = "Price";
            this.columnPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnPrice.Width = 72;
            // 
            // columnStock
            // 
            this.columnStock.Text = "Stock";
            this.columnStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStock.Width = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(616, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Books";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(624, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Store Management";
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.flowLayout.ResumeLayout(false);
            this.flowLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnStock;
        private System.Windows.Forms.Label label1;
    }
}