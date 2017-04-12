using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Libretto.Model;
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WarehouseForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public WarehouseForm()
        {
            InitializeComponent();
            var warehouseIntermediate = new WarehouseIntermediate();
            warehouseIntermediate.OnRefreshBooks += OnRefreshBooks;
            warehouseIntermediate.OnRefreshOrders += OnRefreshOrders;
        }

        /// <summary>
        /// 
        /// </summary>
        private List<Order> _transactions = new List<Order>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<Guid, Book> _books = new Dictionary<Guid, Book>();

        /// <summary>
        /// 
        /// </summary>
        private void OnRefreshBooks()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RefreshHandler(RefreshBooks));
            }
            else
            {
                RefreshBooks();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshBooks()
        {
            _books = WarehouseClient.Warehouse.ListBooks();
            customerName.Items.Clear();
            customerName.Items.Add("");
            customerName.SelectedIndex = 0;

            if (_books.Count > 0)
            {
                customerName.Items.AddRange(_books.Values.Select(bookInformation => bookInformation.Title).ToArray<object>());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRefreshOrders()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RefreshHandler(RefreshOrders));
            }
            else
            {
                RefreshOrders();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshOrders()
        {
            _transactions = WarehouseClient.Warehouse.ListOrders();
            customerName.SelectedIndex = 0;
            transactionList.Items.Clear();
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonLogout_Click(object sender, EventArgs args)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonUpdate_Click(object sender, EventArgs args)
        {
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        /// <returns></returns>
        private static ListViewItem ParseTransaction(Transaction transactionInformation)
        {
            return new ListViewItem(LibrettoCommon.FormatDate(transactionInformation.Timestamp))
            {
                Name = LibrettoCommon.FormatGuid(transactionInformation.Identifier),
                SubItems =
                {
                    transactionInformation.BookName,
                    transactionInformation.CustomerName,
                    Convert.ToString(transactionInformation.Quantity),
                    LibrettoCommon.FormatCurrency(transactionInformation.Total),
                    transactionInformation.Status.GetDescription()
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateFilter()
        {
            if (_transactions.Count < 1)
            {
                return;
            }

            transactionList.Items.Clear();
            transactionList.Items.AddRange(_transactions.Where(FilterOrder).Select(ParseTransaction).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        private bool FilterOrder(Transaction orderInformation)
        {
            var bookTitle = customerName.Text;
            var orderTimestamp = orderInformation.Timestamp;
            return (orderInformation.Status == Status.StorePurchased
                    || orderInformation.Status == Status.WaitingExpedition && checkWaiting.Checked
                    || orderInformation.Status == Status.WaitingDispatch && checkProcessing.Checked
                    || orderInformation.Status == Status.DispatchComplete && checkDispatched.Checked)
                   && (string.IsNullOrEmpty(bookTitle) || bookTitle == orderInformation.BookName)
                   && (dateFromPicker.Checked == false || orderTimestamp > dateFromPicker.Value)
                   && (dateToPicker.Checked == false || orderTimestamp < dateToPicker.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonUpdate.Enabled = transactionList.SelectedItems.Count == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OrderList_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonManage_Click(object sender, EventArgs args)
        {
            //new InventoryForm().ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void WarehouseClient_Load(object sender, EventArgs args)
        {
            RefreshBooks();
            RefreshOrders();
            dateFromPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateToPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OrdersList_DoubleClicked(object sender, MouseEventArgs args)
        {
            ButtonUpdate_Click(sender, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PickerFrom_ValueChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PickerUntil_ValueChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckWaiting_CheckedChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckProcessing_CheckedChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckDispatched_CheckedChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ComboCustomer_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }
    }
}