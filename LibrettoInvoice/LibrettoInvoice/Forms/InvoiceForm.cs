using System.Windows.Forms;
using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InvoiceForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Model.Invoice _invoiceInformation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceInformation"></param>
        public InvoiceForm(Invoice invoiceInformation)
        {
            InitializeComponent();
            _invoiceInformation = invoiceInformation;
        }
    }
}