using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;

using Libretto.Properties;
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WarehouseClient : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IWarehouseService _warehouse;

        /// <summary>
        /// 
        /// </summary>
        private List<WarehouseOrder> _transactions = new List<WarehouseOrder>();

        /// <summary>
        /// 
        /// </summary>
        private readonly WarehouseIntermediate _warehouseIntermediate = new WarehouseIntermediate();

        /// <summary>
        /// 
        /// </summary>
        public WarehouseClient()
        {
            InitializeComponent();
            _warehouseIntermediate.OnRefresh += OnRefresh;
            _warehouse = (IWarehouseService)RemotingServices.Connect(typeof(IWarehouseService), WarehouseCommon.WarehouseAddress);
            _warehouse.OnRefresh += _warehouseIntermediate.Refresh;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRefresh(List<WarehouseOrder> transactionInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TransactionHandler(RefreshOrders), transactionInformation);
            }
            else
            {
                RefreshOrders(transactionInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshOrders(List<WarehouseOrder> transactionInformation)
        {
            _transactions = transactionInformation;
            checkPending.Checked = true;
            checkCancelled.Checked = false;
            checkDispatched.Checked = false;
            filterTitle.Items.Clear();
            filterTitle.Items.Add("");
            filterTitle.SelectedIndex = 0;
            UpdateButtons();
            UpdateFilter(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonLogout_Click(object sender, EventArgs args)
        {
            if (MessageBox.Show(this, Resources.TerminateSession, Resources.TerminateSession_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateFilter(bool reorderCustomers)
        {
            if (_transactions.Count < 1)
            {
                return;
            }

            listView.Items.Clear();
            listView.Items.AddRange(_transactions.Where(FilterOrder).Select(ParseTransaction).ToArray());

            if (reorderCustomers)
            {
                filterTitle.Items.AddRange(_transactions.Select(transactionInformation => transactionInformation.Title).Distinct().OrderBy(bookTitle => bookTitle).ToArray<object>());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        private bool FilterOrder(WarehouseOrder orderInformation)
        {
            var bookTitle = filterTitle.Text;
            var orderTimestamp = orderInformation.DateCreated;
            return (orderInformation.Status == WarehouseStatus.Pending && checkPending.Checked
                || orderInformation.Status == WarehouseStatus.Dispatched && checkDispatched.Checked
                || orderInformation.Status == WarehouseStatus.Cancelled && checkCancelled.Checked)
                && (string.IsNullOrEmpty(bookTitle) || bookTitle == orderInformation.Title)
                && (dateFromPicker.Checked == false || orderTimestamp > dateFromPicker.Value)
                && (dateUntilPicker.Checked == false || orderTimestamp < dateUntilPicker.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        /// <returns></returns>
        private static ListViewItem ParseTransaction(WarehouseOrder transactionInformation)
        {
            return new ListViewItem(LibrettoCommon.FormatDate(transactionInformation.DateCreated))
            {
                Name = LibrettoCommon.FormatGuid(transactionInformation.Identifier),
                SubItems =
                {
                    transactionInformation.Title,
                    Convert.ToString(transactionInformation.Quantity),
                    LibrettoCommon.FormatCurrency(transactionInformation.Total),
                    transactionInformation.Status.ToString(),
                    LibrettoCommon.FormatDate(transactionInformation.DateModified),
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonSatisfy.Enabled = listView.SelectedItems.Count > 0 && listView.SelectedItems[0].SubItems[4].Text == @"Pending";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void WarehouseClient_Load(object sender, EventArgs args)
        {
            RefreshOrders(_warehouse.ListOrders());
            dateFromPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateUntilPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshOrders(_warehouse.ListOrders());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSatisfy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Resources.ConfirmRequest, Resources.ConfirmRequest_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (Guid.TryParse(listView.SelectedItems[0].Name, out Guid transactionIdentifier))
            {
                if (_warehouse.DispatchOrder(transactionIdentifier))
                {
                    MessageBox.Show(this, Resources.RequestComplete, Resources.RequestComplete_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, Resources.RequestDenied, Resources.RequestDenied_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, Resources.ParseError, Resources.ParseError_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void ListView_DoubleClicked(object sender, MouseEventArgs args)
        {
            ButtonSatisfy_Click(sender, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DateFromPicker_ValueChanged(object sender, EventArgs args)
        {
            UpdateFilter(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DateToPicker_ValueChanged(object sender, EventArgs args)
        {
            UpdateFilter(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckPending_CheckedChanged(object sender, EventArgs args)
        {
            UpdateFilter(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckDispatched_CheckedChanged(object sender, EventArgs args)
        {
            UpdateFilter(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckCancelled_CheckedChanged(object sender, EventArgs args)
        {
            UpdateFilter(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ComboCustomer_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateFilter(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _warehouse.OnRefresh -= _warehouseIntermediate.Refresh;
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RemotingConfiguration.RegisterActivatedServiceType(typeof(IWarehouseService));
            Application.Run(new WarehouseClient());
        }
    }
}