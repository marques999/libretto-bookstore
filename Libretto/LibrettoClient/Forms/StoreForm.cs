using System;
using System.Linq;
using System.Windows.Forms;

using Libretto.Model;
using Libretto.Properties;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class StoreForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public StoreForm()
        {
            InitializeComponent();
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

        private void ButtonDelete_Click(object sender, EventArgs args)
        {
            if (transactionList.SelectedItems.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show(this, Resources.DeleteOrder, Resources.DeleteOrderTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            foreach (ListViewItem listItem in transactionList.SelectedItems)
            {
                if (listItem == null || listItem.Index < 0)
                {
                    continue;
                }

                LibrettoClient.Instance.Transactions.RemoveAt(listItem.Index);
                transactionList.Items.Remove(listItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonUpdate_Click(object sender, EventArgs args)
        {
            if (transactionList.SelectedItems.Count != 1)
            {
                return;
            }

            var listItem = transactionList.SelectedItems[0];

            if (listItem == null || listItem.Index < 0)
            {
                return;
            }

            var orderInformation = LibrettoClient.Instance.Transactions[listItem.Index] as Order;

            if (orderInformation == null)
            {
                return;
            }

            var orderForm = new OrderForm(orderInformation);

            if (orderForm.ShowDialog(this) == DialogResult.OK)
            {
                UpdateOrder(listItem, orderForm.Information);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="orderInformation"></param>
        private void UpdateOrder(ListViewItem listItem, Transaction orderInformation)
        {
            var previousIndex = listItem.Index;

            transactionList.Items.Remove(listItem);

            if (previousIndex >= 0)
            {
                transactionList.Items.Insert(previousIndex, ParseTransaction(orderInformation));
            }
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
            transactionList.Items.Clear();
            transactionList.Items.AddRange(LibrettoClient.Instance.Transactions.Where(FilterOrder).Select(ParseTransaction).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        private void InsertOrder(Transaction transactionInformation)
        {
            LibrettoClient.Instance.Transactions.Add(transactionInformation);
            transactionList.Items.Add(ParseTransaction(transactionInformation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        private bool FilterOrder(Transaction orderInformation)
        {
            var customerName = comboCustomer.Text;
            var orderTimestamp = orderInformation.Timestamp;
            return (orderInformation.Status == Status.StorePurchased
                || orderInformation.Status == Status.WaitingExpedition && checkWaiting.Checked
                || orderInformation.Status == Status.WaitingDispatch && checkProcessing.Checked
                || orderInformation.Status == Status.DispatchComplete && checkDispatched.Checked)
                && (string.IsNullOrEmpty(customerName) || customerName == orderInformation.CustomerName)
                && (pickerFrom.Checked == false || orderTimestamp > pickerFrom.Value)
                && (pickerUntil.Checked == false || orderTimestamp < pickerUntil.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonUpdate.Enabled = buttonDelete.Enabled = transactionList.SelectedItems.Count > 0;
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
            new InventoryForm().ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StoreForm_Load(object sender, EventArgs args)
        {
            comboCustomer.Items.Add("");
            comboCustomer.Items.AddRange(LibrettoClient.Instance.Customers.Select(c => c.Name).ToArray<object>());
            pickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            pickerUntil.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            UpdateButtons();
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonOrder_Click(object sender, EventArgs args)
        {
            var orderForm = new OrderForm();

            if (orderForm.ShowDialog(this) == DialogResult.OK)
            {
                InsertOrder(orderForm.Information);
            }
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
        private void DateFromPicker_ValueChanged(object sender, EventArgs args)
        {
            UpdateFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DateUntilPicker_ValueChanged(object sender, EventArgs args)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonRegister_Click(object sender, EventArgs args)
        {
            var purchaseForm = new PurchaseForm();

            if (purchaseForm.ShowDialog(this) == DialogResult.OK)
            {
                InsertOrder(purchaseForm.Information);
            }
        }
    }
}