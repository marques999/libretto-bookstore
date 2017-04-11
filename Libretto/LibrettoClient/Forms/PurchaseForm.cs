using System;
using System.Linq;
using System.Windows.Forms;

using Libretto.Controls;
using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class PurchaseForm : FlatDialog
    {
        /// <summary>
        /// 
        /// </summary>
        public PurchaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public Purchase Information
        {
            get;
        } = new Purchase();

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
        private void PurchaseForm_Load(object sender, EventArgs args)
        {
            var validPurchase = false;
            var booksList = LibrettoClient.Instance.Books.Select(bookInformation => bookInformation.Title).ToArray<object>();
            var customersList = LibrettoClient.Instance.Customers.Select(customerInformation => customerInformation.Name).ToArray<object>();

            if (customersList.Length > 0)
            {
                customerName.Items.AddRange(customersList);
                customerName.SelectedIndex = 0;
                validPurchase = true;
            }

            if (booksList.Length > 0)
            {
                bookTitle.Items.AddRange(booksList);
                bookTitle.SelectedIndex = 0;
                validPurchase = true;
            }

            purchaseQuantity.Enabled = buttonConfirm.Enabled = validPurchase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        private void UpdateBook(Book bookInformation)
        {
            _bookInformation = bookInformation;
            purchaseQuantity.Minimum = 1;
            purchaseQuantity.Maximum = bookInformation.Stock;
            Information.BookName = bookInformation.Title;
            Information.BookId = bookInformation.Identifier;
            bookStock.Text = Convert.ToString(bookInformation.Stock);
            bookPrice.Text = LibrettoCommon.FormatDecimal(bookInformation.Price);
            bookGuid.Text = LibrettoCommon.FormatGuid(bookInformation.Identifier);
            UpdateQuantity(purchaseQuantity.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        private void UpdateCustomer(Customer customerInformation)
        {
            _customerInformation = customerInformation;
            Information.CustomerName = _customerInformation.Name;
            Information.CustomerId = _customerInformation.Identifier;
            customerEmail.Text = customerInformation.Email;
            customerLocation.Text = customerInformation.Location;
            customerGuid.Text = LibrettoCommon.FormatGuid(customerInformation.Identifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockQuantity"></param>
        private void UpdateQuantity(int stockQuantity)
        {
            Information.Quantity = stockQuantity;
            Information.Total = _bookInformation.Price * stockQuantity;
            purchaseQuantityInfo.Text = Convert.ToString(stockQuantity);
            bookStock.Text = Convert.ToString(_bookInformation.Stock - stockQuantity);
            purchaseTotal.Text = LibrettoCommon.FormatDecimal(_bookInformation.Price * stockQuantity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PurchaseQuantity_Scroll(object sender, EventArgs args)
        {
            UpdateQuantity(purchaseQuantity.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            Information.Timestamp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BookTitle_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (bookTitle.SelectedIndex >= 0)
            {
                UpdateBook(LibrettoClient.Instance.Books[bookTitle.SelectedIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CustomerName_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (customerName.SelectedIndex >= 0)
            {
                UpdateCustomer(LibrettoClient.Instance.Customers[customerName.SelectedIndex]);
            }
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