using System;
using System.Globalization;
using System.Windows.Forms;

using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class BookForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public BookForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public BookForm(Book bookInformation)
        {
            InitializeComponent();
            BookInformation = bookInformation;
            titleField.Text = bookInformation.Title;
            stockField.Text = Convert.ToString(bookInformation.Stock);
            priceField.Text = Convert.ToString(bookInformation.Price, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        public Book BookInformation
        {
            get;
        } = new Book();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TitleField_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = string.IsNullOrEmpty(titleField.Text.Trim()) == false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            BookInformation.Title = titleField.Text;
            BookInformation.Price = Convert.ToDouble(priceField.Value);
            BookInformation.Stock = Convert.ToInt32(stockField.Value);
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BookForm_Load(object sender, EventArgs args)
        {
            guidField.Text = LibrettoCommon.FormatGuid(BookInformation.Identifier);
        }
    }
}