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
    public partial class StoreForm : Form
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
            if (ordersList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = ordersList.SelectedItems[0];

            if (listItem == null || listItem.Index < 0)
            {
                return;
            }

            if (MessageBox.Show(this, Resources.DeleteOrder, Resources.DeleteOrder_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            LibrettoClient.Instance.Orders.RemoveAt(listItem.Index);
            ordersList.Items.Remove(listItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonUpdate_Click(object sender, EventArgs args)
        {
            if (ordersList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = ordersList.SelectedItems[0];

            if (listItem == null || listItem.Index < 0)
            {
                return;
            }

            var orderForm = new OrderForm(LibrettoClient.Instance.Orders[listItem.Index]);

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

            ordersList.Items.Remove(listItem);

            if (previousIndex >= 0)
            {
                ordersList.Items.Insert(previousIndex, ParseOrder(orderInformation));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        private static ListViewItem ParseOrder(Order orderInformation)
        {
            return new ListViewItem(LibrettoCommon.FormatDate(orderInformation.Timestamp))
            {
                SubItems =
                {
                    orderInformation.BookName,
                    orderInformation.CustomerName,
                    Convert.ToString(orderInformation.Quantity),
                    LibrettoCommon.FormatCurrency(orderInformation.Total),
                    orderInformation.Status.GetDescription()
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateFilter()
        {
            ordersList.Items.Clear();
            ordersList.Items.AddRange(LibrettoClient.Instance.Orders.Where(FilterOrder).Select(ParseOrder).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        private void InsertOrder(Order orderInformation)
        {
            LibrettoClient.Instance.Orders.Add(orderInformation);
            ordersList.Items.Add(ParseOrder(orderInformation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        private bool FilterOrder(Order orderInformation)
        {
            var customerName = comboCustomer.Text;
            var orderTimestamp = orderInformation.Timestamp;
            return (orderInformation.Status == OrderStatus.WaitingExpedition && checkWaiting.Checked
                || orderInformation.Status == OrderStatus.WaitingDispatch && checkProcessing.Checked
                || orderInformation.Status == OrderStatus.DispatchComplete && checkDispatched.Checked)
                && (string.IsNullOrEmpty(customerName) || customerName == orderInformation.CustomerName)
                && (pickerFrom.Checked == false || orderTimestamp > pickerFrom.Value)
                && (pickerUntil.Checked == false || orderTimestamp < pickerUntil.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonUpdate.Enabled = buttonDelete.Enabled = ordersList.SelectedItems.Count > 0;
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
        private void ButtonConfirm_Click(object sender, EventArgs args)
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
    }
}