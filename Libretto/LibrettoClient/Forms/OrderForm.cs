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
                customerCombo.Items.AddRange(customersList);
                customerCombo.SelectedIndex = 0;
            }

            var booksList = LibrettoClient.Instance.Books.Select(b => b.Title).ToArray<object>();

            if (booksList.Length <= 0)
            {
                customersEmpty = true;
            }

            comboBooks.Items.AddRange(booksList);
            comboBooks.SelectedIndex = 0;
            trackBar1.Enabled = buttonConfirm.Enabled = !customersEmpty;
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
            fieldQuantity.Text = Convert.ToString(numberUnits);

            var remainingUnits = _bookInformation.Stock - numberUnits;
            var purchaseTotal = _bookInformation.Price * numberUnits;

            if (remainingUnits < 0)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            radioButton1.Enabled = remainingUnits < 0;
            radioButton2.Enabled = radioButton3.Enabled = !radioButton1.Enabled;
            fieldStock.Text = Convert.ToString(remainingUnits);
            fieldTotal.Text = LibrettoCommon.FormatCurrency(purchaseTotal);
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
            UpdateStock(trackBar1.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ComboCustomers_SelectedIndexChanged(object sender, EventArgs args)
        {
            var customerIndex = customerCombo.SelectedIndex;

            if (customerIndex >= 0)
            {
                UpdateCustomer(LibrettoClient.Instance.Customers[customerCombo.SelectedIndex]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        private void UpdateCustomer(Customer customerInformation)
        {
            _customerInformation = customerInformation;
            customerGuidField.Text = LibrettoCommon.FormatGuid(customerInformation.Identifier);
            customerEmailField.Text = customerInformation.Email;
            customerLocationField.Text = customerInformation.Location;
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
            bookIdField.Text = LibrettoCommon.FormatGuid(bookInformation.Identifier);
            fieldStock.Text = Convert.ToString(bookInformation.Stock);
            fieldPrice.Text = LibrettoCommon.FormatCurrency(bookInformation.Price);
            Information.BookName = _bookInformation.Title;
            Information.BookId = _bookInformation.Identifier;
            UpdateStock(trackBar1.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ComboBooks_SelectedIndexChanged(object sender, EventArgs args)
        {
            var bookIndex = comboBooks.SelectedIndex;

            if (bookIndex >= 0)
            {
                UpdateBook(LibrettoClient.Instance.Books[comboBooks.SelectedIndex]);
            }
        }
    }
}