using System;
using System.Windows.Forms;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InvoiceForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Purchase _purchaseInformation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        public InvoiceForm(Purchase purchaseInformation)
        {
            InitializeComponent();
            _purchaseInformation = purchaseInformation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void InvoiceForm_Load(object sender, EventArgs args)
        {
            customerGuid.Text = _purchaseInformation.CustomerId.ToString("B").ToUpper();
            customerName.Text = _purchaseInformation.CustomerName;
            bookGuid.Text = _purchaseInformation.BookId.ToString("B").ToUpper();
            bookTitle.Text = _purchaseInformation.BookName;
            purchaseDate.Text = _purchaseInformation.Timestamp.ToString("F");
            purchaseQuantity.Text = _purchaseInformation.Quantity.ToString();
            purchaseTotal.Text = LibrettoCommon.FormatCurrency(_purchaseInformation.Total);
            purchaseTitle.Text = _purchaseInformation.Description;
            Text = _purchaseInformation.Identifier.ToString("B").ToUpper();
        }
    }
}