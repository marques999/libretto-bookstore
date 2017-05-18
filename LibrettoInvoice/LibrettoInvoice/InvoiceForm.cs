using Libretto.Forms;
using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InvoiceForm : FlatDialog
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceInformation"></param>
        public InvoiceForm(Invoice invoiceInformation)
        {
            InitializeComponent();
            invoiceTitle.Text = invoiceInformation.Title;
            invoiceCustomer.Text = invoiceInformation.Customer;
            purchaseDate.Text = invoiceInformation.Timestamp.ToString("F");
            purchaseQuantity.Text = invoiceInformation.Quantity.ToString();
            purchaseTotal.Text = LibrettoCommon.FormatCurrency(invoiceInformation.Total);
            invoiceIdentifier.Text = invoiceInformation.Identifier.ToString("B").ToUpper();
        }
    }
}