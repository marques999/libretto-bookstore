using System;
using System.Collections.Generic;
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
            InitializeForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        public OrderForm(Order orderInformation)
        {
            InitializeComponent();
            InitializeForm();
            Text = @"Update Order";
            Information = orderInformation;
            orderQuantity.Value = orderInformation.Quantity;

            var customerIndex = Customers.FindIndex(customerInformation => customerInformation.Id == orderInformation.CustomerId);

            if (customerIndex >= 0)
            {
                customerName.SelectedIndex = customerIndex;
                UpdateCustomer(Customers[customerIndex]);
            }

            var bookIndex = LibrettoClient.Instance.Books.FindIndex(bookInformation => bookInformation.Id == orderInformation.BookId);

            if (bookIndex < 0)
            {
                return;
            }

            bookTitle.SelectedIndex = bookIndex;
            bookTitle.Enabled = false;
            customerName.Enabled = false;
            orderQuantity.Enabled = false;
            customerNameButton.Enabled = false;
            UpdateBook(LibrettoClient.Instance.Books[bookIndex]);
        }

        /// <summary>
        /// 
        /// </summary>
        private Book _bookInformation;

        /// <summary>
        /// 
        /// </summary>
        private List<Customer> Customers
        {
            get;
        } = LibrettoClient.Instance.Proxy.ListCustomers();

        /// <summary>
        /// 
        /// </summary>
        public Order Information
        {
            get;
        } = new Order();

        /// <summary>
        /// 
        /// </summary>
        private void InitializeForm()
        {
            var customersList = Customers.Select(customerInformation => customerInformation.Name).ToArray<object>();

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
        /// <param name="numberUnits"></param>
        private void UpdateStock(int numberUnits)
        {
            orderQuantityInfo.Text = Convert.ToString(numberUnits);

            var remainingUnits = _bookInformation.Stock - numberUnits;

            if (Information.Status == Status.Processing)
            {
                statusProcessing.Checked = true;
                bookStock.Text = Convert.ToString(remainingUnits);
            }
            else if (remainingUnits < 0)
            {
                statusWaiting.Checked = true;
                bookStock.Text = @"10";
                Information.Status = Status.Waiting;
            }
            else
            {
                statusDispatched.Checked = true;
                bookStock.Text = Convert.ToString(remainingUnits);
                Information.Status = Status.Dispatched;
            }

            var purchaseTotal = _bookInformation.Price * numberUnits;

            statusWaiting.Enabled = Information.Status == Status.Waiting;
            statusProcessing.Enabled = Information.Status == Status.Processing;
            statusDispatched.Enabled = Information.Status != Status.Waiting;
            orderTotal.Text = LibrettoCommon.FormatDecimal(purchaseTotal);
            Information.Quantity = numberUnits;
            Information.Total = purchaseTotal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OrderQuantity_Scroll(object sender, EventArgs args)
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
                UpdateCustomer(Customers[customerName.SelectedIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        private void UpdateCustomer(Customer customerInformation)
        {
            Information.CustomerId = customerInformation.Id;
            Information.CustomerName = customerInformation.Name;
            customerEmail.Text = customerInformation.Email;
            customerLocation.Text = customerInformation.Location;
            customerGuid.Text = LibrettoCommon.FormatGuid(customerInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        private void UpdateBook(Book bookInformation)
        {
            _bookInformation = bookInformation;
            bookGuid.Text = LibrettoCommon.FormatGuid(bookInformation.Id);
            bookStock.Text = Convert.ToString(bookInformation.Stock);
            bookPrice.Text = LibrettoCommon.FormatDecimal(bookInformation.Price);
            Information.BookTitle = bookInformation.Title;
            Information.BookId = bookInformation.Id;
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
            Information.Status = Status.Waiting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusProcessing_CheckedChanged(object sender, EventArgs args)
        {
            Information.Status = Status.Processing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusDispatched_CheckedChanged(object sender, EventArgs args)
        {
            Information.Status = Status.Dispatched;
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

            var customerInformation = customerForm.Information;

            if (customerInformation == null)
            {
                return;
            }

            var operationResult = LibrettoClient.Instance.Proxy.InsertCustomer(customerInformation);

            if (operationResult == Response.Success)
            {
                Customers.Add(customerInformation);
                customerName.Items.Add(customerInformation.Name);
                customerName.SelectedIndex = customerName.Items.Count - 1;
            }
            else
            {
                MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}