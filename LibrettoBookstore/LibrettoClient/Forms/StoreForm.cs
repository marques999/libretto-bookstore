using System;
using System.Collections.Generic;
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

            LibrettoClient.OnRefresh += delegate
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(UpdateFilter));
                }
                else
                {
                    UpdateFilter();
                }
            };
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
        private IEnumerable<Customer> Customers
        {
            get;
        } = LibrettoClient.Instance.Proxy.ListCustomers();

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

                if (transactionInformation is Order)
                {
                    var operationResult = LibrettoClient.Instance.Proxy.DeleteOrder(transactionInformation.Id);

                    if (operationResult != Response.Success)
                    {
                        MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var operationResult = LibrettoClient.Instance.Proxy.DeletePurchase(transactionInformation.Id);

                    if (operationResult != Response.Success)
                    {
                        MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            if (transactionList.SelectedItems.Count == 1)
            {
                var orderInformation = transactionList.SelectedItems[0].Tag as Order;

                if (orderInformation == null || orderInformation.Status >= Status.Dispatched)
                {
                    return;
                }

                if (orderInformation.Status == Status.Pending)
                {
                    DispatchOrder();
                }
                else
                {
                    CancelOrder();
                }
            }
            else
            {
                CancelOrder();
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
            return orderInformation.Filter(checkWaiting.Checked, checkPending.Checked, checkDispatched.Checked)
                && (string.IsNullOrEmpty(customerName.Text) || customerName.Text == orderInformation.CustomerName)
                && (dateFromPicker.Checked == false || orderInformation.Timestamp > dateFromPicker.Value)
                && (dateToPicker.Checked == false || orderInformation.Timestamp < dateToPicker.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonDelete.Enabled = transactionList.SelectedItems.Count > 0;

            if (transactionList.SelectedItems.Count == 1)
            {
                var orderInformation = transactionList.SelectedItems[0].Tag as Order;

                if (orderInformation == null)
                {
                    return;
                }

                buttonCancel.Enabled = orderInformation.Status < Status.Dispatched;
                buttonCancel.Text = orderInformation.Status == Status.Pending ? @"Dispatch Order" : @"Cancel Order";
            }
            else
            {
                buttonCancel.Enabled = false;
                buttonCancel.Text = @"Cancel Order";
            }
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
            customerName.Items.AddRange(Customers.Select(c => c.Name).ToArray<object>());
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
            var operationResult = LibrettoClient.Instance.Proxy.InsertOrder(orderInformation);

            if (operationResult == Response.Success)
            {
                LibrettoClient.Instance.RefreshBooks();
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
            DispatchOrder();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CancelOrder()
        {
            if (MessageBox.Show(this, Resources.CancelOrder, Resources.CancelOrder_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            foreach (ListViewItem listItem in transactionList.SelectedItems)
            {
                var orderInformation = listItem?.Tag as Order;

                if (orderInformation == null)
                {
                    return;
                }

                var operationResult = LibrettoClient.Instance.Proxy.CancelOrder(orderInformation.Id);

                if (operationResult != Response.Success)
                {
                    MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DispatchOrder()
        {
            var orderInformation = transactionList.SelectedItems[0]?.Tag as Order;

            if (orderInformation != null)
            {
                new OrderForm(orderInformation).ShowDialog(this);
            }
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
            var operationResult = LibrettoClient.Instance.Proxy.InsertPurchase(purchaseInformation);

            if (operationResult == Response.Success)
            {
                LibrettoClient.Instance.RefreshBooks();
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
        private void StoreForm_FormClosed(object sender, FormClosedEventArgs args)
        {
            LibrettoClient.Instance.Logout();
        }
    }
}