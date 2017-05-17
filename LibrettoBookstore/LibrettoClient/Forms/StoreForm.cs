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
                var transactionInformation = listItem?.Tag as Transaction;

                if (transactionInformation == null)
                {
                    continue;
                }

                Response operationResult;

                if (transactionInformation is Order)
                {
                    operationResult = LibrettoClient.Instance.Proxy.DeleteOrder(transactionInformation.Id);
                }
                else
                {
                    operationResult = LibrettoClient.Instance.Proxy.DeletePurchase(transactionInformation.Id);
                }

                if (operationResult == Response.Success)
                {
                    LibrettoClient.Instance.Transactions.RemoveAt(listItem.Index);
                    transactionList.Items.Remove(listItem);
                }
                else
                {
                    MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            var orderInformation = listItem?.Tag as Order;

            if (orderInformation == null)
            {
                return;
            }

            var orderForm = new OrderForm(orderInformation);

            if (orderForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var operationResult = LibrettoClient.Instance.Proxy.UpdateOrder(orderForm.Information);

            if (operationResult == Response.Success)
            {
                UpdateOrder(listItem, orderForm.Information);
            }
            else
            {
                MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Tag = transactionInformation,
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
            buttonUpdate.Enabled = transactionList.SelectedItems.Count == 1 && transactionList.SelectedItems[0].Tag is Order;
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

            if (orderForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var orderInformation = orderForm.Information;

            if (orderInformation == null)
            {
                return;
            }

            var operationResult = LibrettoClient.Instance.Proxy.InsertOrder(orderInformation);

            if (operationResult == Response.Success)
            {
                var validatedOrder = LibrettoClient.Instance.Proxy.LookupOrder(orderInformation.Id);

                if (validatedOrder == null)
                {
                    return;
                }

                LibrettoClient.Instance.Transactions.Add(validatedOrder);
                transactionList.Items.Add(ParseTransaction(validatedOrder));
            }
            else
            {
                MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (purchaseForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var purchaseInformation = purchaseForm.Information;

            if (purchaseInformation == null)
            {
                return;
            }

            var operationResult = LibrettoClient.Instance.Proxy.InsertPurchase(purchaseInformation);

            if (operationResult == Response.Success)
            {
                var validatedPurchase = LibrettoClient.Instance.Proxy.LookupPurchase(purchaseInformation.Id);

                if (validatedPurchase == null)
                {
                    return;
                }

                LibrettoClient.Instance.Transactions.Add(validatedPurchase);
                transactionList.Items.Add(ParseTransaction(validatedPurchase));
            }
            else
            {
                MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LibrettoClient.Instance.Logout();
        }
    }
}