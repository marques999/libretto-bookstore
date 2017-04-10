using System;
using System.Linq;
using System.Windows.Forms;

using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class OrderForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderForm()
        {
            InitializeComponent();
            Information = new Order();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="information"></param>
        public OrderForm(Order information)
        {
            InitializeComponent();
            Information = information;
        }

        /// <summary>
        /// 
        /// </summary>
        public Order Information
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        private Book _bookInformation;

        /// <summary>
        /// 
        /// </summary>
        private Customer _customerInformation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OrderForm_Load(object sender, EventArgs args)
        {
            var customersEmpty = true;
            var customersList = LibrettoClient.Instance.Customers.Select(c => c.Name).ToArray<object>();

            if (customersList.Length > 0)
            {
                customersEmpty = false;
                customerName.Items.AddRange(customersList);
                customerName.SelectedIndex = 0;
            }

            var booksList = LibrettoClient.Instance.Books.Select(b => b.Title).ToArray<object>();

            if (booksList.Length <= 0)
            {
                customersEmpty = true;
            }

            itemDescription.Items.AddRange(booksList);
            itemDescription.SelectedIndex = 0;
            orderQuantity.Enabled = buttonConfirm.Enabled = !customersEmpty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            Information.Timestamp = DateTime.Now;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberUnits"></param>
        private void UpdateStock(int numberUnits)
        {
            orderQuantityInfo.Text = Convert.ToString(numberUnits);

            var remainingUnits = _bookInformation.Stock - numberUnits;
            var purchaseTotal = _bookInformation.Price * numberUnits;

            if (remainingUnits < 0)
            {
                statusWaiting.Checked = true;
            }
            else
            {
                statusProcessing.Checked = true;
            }

            statusWaiting.Enabled = remainingUnits < 0;
            statusProcessing.Enabled = statusDispatched.Enabled = !statusWaiting.Enabled;
            itemStock.Text = Convert.ToString(remainingUnits);
            orderTotal.Text = LibrettoCommon.FormatCurrency(purchaseTotal);
            Information.Quantity = numberUnits;
            Information.Total = purchaseTotal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateStock(orderQuantity.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ComboCustomers_SelectedIndexChanged(object sender, EventArgs args)
        {
            var customerIndex = customerName.SelectedIndex;

            if (customerIndex >= 0)
            {
                UpdateCustomer(LibrettoClient.Instance.Customers[customerName.SelectedIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        private void UpdateCustomer(Customer customerInformation)
        {
            _customerInformation = customerInformation;
            customerGuid.Text = LibrettoCommon.FormatGuid(customerInformation.Identifier);
            customerEmail.Text = customerInformation.Email;
            customerLocation.Text = customerInformation.Location;
            Information.CustomerName = _customerInformation.Name;
            Information.CustomerId = _customerInformation.Identifier;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        private void UpdateBook(Book bookInformation)
        {
            _bookInformation = bookInformation;
            itemGuid.Text = LibrettoCommon.FormatGuid(bookInformation.Identifier);
            itemStock.Text = Convert.ToString(bookInformation.Stock);
            itemPrice.Text = LibrettoCommon.FormatCurrency(bookInformation.Price);
            Information.BookName = _bookInformation.Title;
            Information.BookId = _bookInformation.Identifier;
            UpdateStock(orderQuantity.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ComboBooks_SelectedIndexChanged(object sender, EventArgs args)
        {
            var bookIndex = itemDescription.SelectedIndex;

            if (bookIndex >= 0)
            {
                UpdateBook(LibrettoClient.Instance.Books[itemDescription.SelectedIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RadioWaiting_CheckedChanged(object sender, EventArgs args)
        {
            Information.Status = Status.WaitingExpedition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RadioProcessing_CheckedChanged(object sender, EventArgs args)
        {
            Information.Status = Status.WaitingDispatch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioDispatched_CheckedChanged(object sender, EventArgs e)
        {
            Information.Status = Status.DispatchComplete;
        }
    }
}