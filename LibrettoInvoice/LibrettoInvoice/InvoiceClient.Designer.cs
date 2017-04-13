using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Libretto.Forms;
using Libretto.Properties;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InvoiceClient
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(InvoiceClient));
            components = new Container();
            buttonView = new FlatButton();
            buttonDelete = new FlatButton();
            buttonExit = new FlatButton();
            transactionsLayout = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            notifyIcon = new NotifyIcon(components);
            listView = new ListView();
            transactionsLayout.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            //
            // buttonView
            //
            buttonView.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonView.Location = new Point(0, 4);
            buttonView.Margin = new Padding(0, 4, 2, 4);
            buttonView.Name = "buttonView";
            buttonView.Size = new Size(128, 32);
            buttonView.TabIndex = 0;
            buttonView.Text = "View";
            buttonView.Click += new EventHandler(ButtonView_Click);
            //
            // buttonDelete
            //
            buttonDelete.Location = new Point(132, 4);
            buttonDelete.Margin = new Padding(2, 4, 2, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(131, 32);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "Delete";
            buttonDelete.Click += new EventHandler(ButtonDelete_Click);
            //
            // buttonExit
            //
            buttonExit.DialogResult = DialogResult.Cancel;
            buttonExit.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExit.Location = new Point(267, 4);
            buttonExit.Margin = new Padding(2, 4, 0, 4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(128, 32);
            buttonExit.TabIndex = 2;
            buttonExit.Text = "Exit";
            buttonExit.Click += new EventHandler(ButtonExit_Click);
            //
            // transactionsLayout
            //
            transactionsLayout.BackColor = SystemColors.ControlDark;
            transactionsLayout.Controls.Add(flowLayoutPanel1);
            transactionsLayout.Controls.Add(listView);
            transactionsLayout.Dock = DockStyle.Fill;
            transactionsLayout.Location = new Point(0, 0);
            transactionsLayout.Name = "transactionsLayout";
            transactionsLayout.Padding = new Padding(4);
            transactionsLayout.Size = new Size(404, 461);
            //
            // flowLayoutPanel1
            //
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(buttonView);
            flowLayoutPanel1.Controls.Add(buttonDelete);
            flowLayoutPanel1.Controls.Add(buttonExit);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(4, 421);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(396, 36);
            //
            // listView
            //
            listView.BackColor = SystemColors.ControlLight;
            listView.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader
                {
                    Text = "Date", Width = 100
                },
                new ColumnHeader
                {
                    Text = "Identifier", Width = 290
                }
            });
            listView.Dock = DockStyle.Fill;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(4, 4);
            listView.Name = "listView";
            listView.Size = new Size(396, 453);
            listView.TabIndex = 3;
            listView.View = View.Details;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            listView.MouseDoubleClick += new MouseEventHandler(ListView_MouseDoubleClick);
            //
            // InvoiceClient
            //
            AcceptButton = buttonView;
            ClientSize = new Size(404, 461);
            Controls.Add(transactionsLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.librettoIcon;
            MaximizeBox = false;
            Name = "InvoiceClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Libretto Invoices";
            Load += new EventHandler(InvoiceClient_Load);
            notifyIcon.Text = Text;
            notifyIcon.Visible = true;
            notifyIcon.Icon = Resources.librettoIcon;
            transactionsLayout.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private ListView listView;
        private NotifyIcon notifyIcon;
        private FlatButton buttonView;
        private FlatButton buttonExit;
        private FlatButton buttonDelete;
        private Panel transactionsLayout;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}