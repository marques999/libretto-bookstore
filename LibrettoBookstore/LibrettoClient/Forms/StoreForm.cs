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
    internal sealed partial class StoreForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public StoreForm()
        {
            InitializeComponent();
            Text = $@"Libreto Bookstore ({LibrettoClient.Instance.Session.Name})";
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
            if (MessageBox.Show(this, Resources.DeleteOrder, Resources.DeleteOrder_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
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
        private void UpdateOrder(ListViewItem listItem, Order orderInformation)
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
                    transactionInformation.BookTitle,
                    transactionInformation.CustomerName,
                    Convert.ToString(transactionInformation.Quantity),
                    LibrettoCommon.FormatCurrency(transactionInformation.Total),
                    transactionInformation.Description
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
        /// <param name="transactionInformation"></param>
        private void InsertPurchase(Transaction transactionInformation)
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
            return orderInformation.Filter(checkWaiting.Checked, checkProcessing.Checked, checkDispatched.Checked)
                && (string.IsNullOrEmpty(customerName.Text) || customerName.Text == orderInformation.CustomerName)
                && (dateFromPicker.Checked == false || orderInformation.Timestamp > dateFromPicker.Value)
                && (dateToPicker.Checked == false || orderInformation.Timestamp < dateToPicker.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonUpdate.Enabled = transactionList.SelectedItems.Count == 1;
            buttonDelete.Enabled = transactionList.SelectedItems.Count > 0;
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
            customerName.Items.Add("");
            customerName.Items.AddRange(LibrettoClient.Instance.Customers.Select(c => c.Name).ToArray<object>());
            buttonDelete.Enabled = transactionList.SelectedItems.Count > 0;
            buttonManage.Enabled = LibrettoClient.Instance.IsAdministrator();
            dateFromPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateToPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
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
                InsertPurchase(purchaseForm.Information);
            }
        }
    }
}