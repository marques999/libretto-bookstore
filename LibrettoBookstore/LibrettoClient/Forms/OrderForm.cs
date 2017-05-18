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
            UpdateBook(LibrettoClient.Instance.Books[bookIndex]);
            ToggleRadio((int)orderInformation.Status);
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
        /// <param name="radioChecked"></param>
        private void ToggleRadio(int radioChecked)
        {
            statusWaiting.Checked = radioChecked == 0;
            statusProcessing.Checked = radioChecked == 1;
            statusDispatched.Checked = radioChecked == 2;
        }

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
            if(remainingUnits >= 0)
            {
                Information.Status = Status.Processing;
            }
            else
            {
                Information.Status = Status.Waiting;
            }
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
        /// <param name="e"></param>
        private void StatusDispatched_CheckedChanged(object sender, EventArgs e)
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