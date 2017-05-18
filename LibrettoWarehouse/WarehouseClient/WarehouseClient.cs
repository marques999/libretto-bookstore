using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
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
        private readonly WarehouseIntermediate _warehouseIntermediate = new WarehouseIntermediate();

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Guid, WarehouseOrder> _transactions = new Dictionary<Guid, WarehouseOrder>();

        /// <summary>
        /// 
        /// </summary>
        public WarehouseClient()
        {
            InitializeComponent();
            _warehouseIntermediate.OnDelete += OnDelete;
            _warehouseIntermediate.OnUpsert += OnUpsert;
            _warehouse = (IWarehouseService)RemotingServices.Connect(typeof(IWarehouseService), WarehouseCommon.WarehouseAddress);
            _warehouse.OnDelete += _warehouseIntermediate.Delete;
            _warehouse.OnUpsert += _warehouseIntermediate.Upsert;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        private void OnUpsert(WarehouseOrder transactionInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new WarehouseUpsertHandler(UpsertOrder), transactionInformation);
            }
            else
            {
                UpsertOrder(transactionInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        private void OnDelete(Guid transactionIdentifier)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new WarehouseDeleteHandler(DeleteOrder), transactionIdentifier);
            }
            else
            {
                DeleteOrder(transactionIdentifier);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpsertOrder(WarehouseOrder transactionInformation)
        {
            _transactions.Remove(transactionInformation.Identifier);
            _transactions.Add(transactionInformation.Identifier, transactionInformation);
            ResetWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        private void DeleteOrder(Guid transactionIdentifier)
        {
            _transactions.Remove(transactionIdentifier);
            ResetWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        private void RefreshOrders(List<WarehouseOrder> transactionInformation)
        {
            _transactions.Clear();
            transactionInformation.ForEach(warehouseOrder => _transactions.Add(warehouseOrder.Identifier, warehouseOrder));
            ResetWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetWindow()
        {
            filterTitle.Items.Clear();
            filterTitle.Items.Add("");
            filterTitle.SelectedIndex = 0;
            dateFromPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateUntilPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
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
        private void UpdateFilter(bool refreshBooks)
        {
            if (_transactions.Count < 1)
            {
                return;
            }

            listView.Items.Clear();
            listView.Items.AddRange(_transactions.Values.Where(FilterOrder).Select(ParseTransaction).ToArray());

            if (refreshBooks)
            {
                filterTitle.Items.AddRange(_transactions.Values.Select(transactionInformation => transactionInformation.Title).Distinct().OrderBy(bookTitle => bookTitle).ToArray<object>());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        private bool FilterOrder(WarehouseOrder orderInformation)
        {
            return (string.IsNullOrEmpty(filterTitle.Text) || filterTitle.Text == orderInformation.Title)
                && (dateFromPicker.Checked == false || orderInformation.DateCreated > dateFromPicker.Value)
                && (dateUntilPicker.Checked == false || orderInformation.DateCreated < dateUntilPicker.Value);
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
                    LibrettoCommon.FormatDate(transactionInformation.DateModified),
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonSatisfy.Enabled = listView.SelectedItems.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void WarehouseClient_Load(object sender, EventArgs args)
        {
            RefreshOrders(_warehouse.ListOrders());
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
            _warehouse.OnDelete -= _warehouseIntermediate.Delete;
            _warehouse.OnUpsert -= _warehouseIntermediate.Upsert;
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ChannelServices.RegisterChannel(new TcpChannel(new Hashtable
            {
                {"port", 0}
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = TypeFilterLevel.Full
            }), false);

            RemotingConfiguration.RegisterActivatedServiceType(typeof(IWarehouseService));
            Application.Run(new WarehouseClient());
        }
    }
}