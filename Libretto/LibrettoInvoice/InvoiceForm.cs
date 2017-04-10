using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrettoInvoice
{
    public partial class InvoiceForm : Form
    {
        private Invoice _invoiceInformation;

        public InvoiceForm(Invoice invoiceInformation)
        {
            InitializeComponent();
            _invoiceInformation = invoiceInformation;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
