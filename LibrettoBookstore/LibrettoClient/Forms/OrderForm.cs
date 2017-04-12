using System;
using System.Linq;
using System.Windows.Forms;
using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class OrderForm : FlatDialog
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
            Text = @"Update Order";
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
            var customersList = LibrettoClient.Instance.Customers.Select(customerInformation => customerInformation.Name).ToArray<object>();

            if (customersList.Length > 0)
            {
                customerName.Items.AddRange(customersList);
                customerName.SelectedIndex = 0;
            }

            var booksList = LibrettoClient.Instance.Books.Select(bookInformation => bookInformation.Title).ToArray<object>();

            if (booksList.Length > 0)
            {
                bookTitle.Items.AddRange(booksList);
                bookTitle.SelectedIndex = 0;
            }

            orderQuantity.Enabled = booksList.Length > 0;
            buttonConfirm.Enabled = orderQuantity.Enabled && customersList.Length > 0;
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
            bookStock.Text = Convert.ToString(remainingUnits);
            orderTotal.Text = LibrettoCommon.FormatDecimal(purchaseTotal);
            Information.Quantity = numberUnits;
            Information.Total = purchaseTotal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderQuantity_Scroll(object sender, EventArgs e)
        {
            UpdateStock(orderQuantity.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CustomerName_SelectedIndexChanged(object sender, EventArgs args)
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
            bookGuid.Text = LibrettoCommon.FormatGuid(bookInformation.Identifier);
            bookStock.Text = Convert.ToString(bookInformation.Stock);
            bookPrice.Text = LibrettoCommon.FormatDecimal(bookInformation.Price);
            Information.BookTitle = _bookInformation.Title;
            Information.BookId = _bookInformation.Identifier;
            UpdateStock(orderQuantity.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BookTitle_SelectedIndexChanged(object sender, EventArgs args)
        {
            var bookIndex = bookTitle.SelectedIndex;

            if (bookIndex >= 0)
            {
                UpdateBook(LibrettoClient.Instance.Books[bookTitle.SelectedIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusWaiting_CheckedChanged(object sender, EventArgs args)
        {
            Information.Status = Status.WaitingExpedition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusProcessing_CheckedChanged(object sender, EventArgs args)
        {
            Information.Status = Status.WaitingDispatch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusDispatched_CheckedChanged(object sender, EventArgs e)
        {
            Information.Status = Status.DispatchComplete;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CustomerNameButton_Click(object sender, EventArgs args)
        {
            var customerForm = new CustomerForm();

            if (customerForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var customerInformation = customerForm.CustomerInformation;

            if (customerInformation == null)
            {
                return;
            }

            LibrettoClient.Instance.Customers.Add(customerInformation);
            customerName.Items.Add(customerInformation.Name);
            customerName.SelectedIndex = customerName.Items.Count - 1;
        }
    }
}