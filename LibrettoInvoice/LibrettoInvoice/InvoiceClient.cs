﻿using System;
using System.IO;
using System.Messaging;
using System.Windows.Forms;
using System.Xml.Serialization;

using Libretto.Messaging;
using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InvoiceClient : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly MessageQueue _invoiceQueue;

        /// <summary>
        /// 
        /// </summary>
        private readonly InvoiceCollection _invoices;

        /// <summary>
        /// 
        /// </summary>
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(InvoiceCollection));

        /// <summary>
        /// 
        /// </summary>
        private delegate void ReceiveHandler(Invoice purchaseInformation, bool fromQueue);

        /// <summary>
        /// 
        /// </summary>
        public InvoiceClient()
        {
            try
            {
                InitializeComponent();
                _invoiceQueue = MessagingCommon.InitializeInvoiceQueue();
                _invoiceQueue.ReceiveCompleted += OnReceive;
                _invoiceQueue.BeginReceive(MessagingCommon.MsmqTimeout);

                if (File.Exists(LibrettoCommon.InvoicesFilename))
                {
                    using (var reader = new FileStream(LibrettoCommon.InvoicesFilename, FileMode.Open))
                    {
                        _invoices = (InvoiceCollection)_serializer.Deserialize(reader) ?? new InvoiceCollection();
                    }

                    foreach (var invoiceInformation in _invoices.Invoices)
                    {
                        OnInsertAux(invoiceInformation, false);
                    }
                }
                else
                {
                    _invoices = new InvoiceCollection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Source, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="receiveCompletedEventArgs"></param>
        private void OnReceive(object src, ReceiveCompletedEventArgs receiveCompletedEventArgs)
        {
            try
            {
                User32.FlashWindowEx(this);
                OnInsert(_invoiceQueue.EndReceive(receiveCompletedEventArgs.AsyncResult)?.Body as Invoice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _invoiceQueue.BeginReceive(MessagingCommon.MsmqTimeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        private void OnInsert(Invoice purchaseInformation)
        {
            if (purchaseInformation == null)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(new ReceiveHandler(OnInsertAux), purchaseInformation, true);
            }
            else
            {
                OnInsertAux(purchaseInformation, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <param name="fromQueue"></param>
        private void OnInsertAux(Invoice purchaseInformation, bool fromQueue)
        {
            if (fromQueue)
            {
                _invoices.Insert(purchaseInformation);
                _invoices.Serialize(_serializer, LibrettoCommon.InvoicesFilename);
            }

            listView.Items.Add(new ListViewItem(LibrettoCommon.FormatDate(purchaseInformation.Timestamp))
            {
                SubItems =
                {
                    purchaseInformation.Identifier.ToString("B").ToUpper()
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonView.Enabled = listView.SelectedItems.Count == 1;
            buttonDelete.Enabled = listView.SelectedItems.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonView_Click(object sender, EventArgs args)
        {
            if (listView.SelectedItems.Count < 1)
            {
                return;
            }

            var itemIndex = listView.SelectedItems[0].Index;

            if (itemIndex >= 0 && itemIndex < _invoices.Count)
            {
                new InvoiceForm(_invoices[itemIndex]).ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonDelete_Click(object sender, EventArgs args)
        {
            if (listView.SelectedItems.Count < 1)
            {
                return;
            }

            foreach (ListViewItem listItem in listView.SelectedItems)
            {
                _invoices.Remove(listItem.Index);
                listView.Items.Remove(listItem);
            }

            _invoices.Serialize(_serializer, LibrettoCommon.InvoicesFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonExit_Click(object sender, EventArgs args)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ListView_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ListView_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            ButtonView_Click(sender, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void InvoiceClient_Load(object sender, EventArgs args)
        {
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InvoiceClient());
        }
    }
}