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
            BookInformation = new Book();
        }

        /// <summary>
        /// 
        /// </summary>
        public BookForm(Book bookInformation)
        {
            InitializeComponent();
            BookInformation = bookInformation;
            fieldTitle.Text = bookInformation.Title;
            fieldStock.Text = Convert.ToString(bookInformation.Stock);
            fieldPrice.Text = Convert.ToString(bookInformation.Price, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        public Book BookInformation
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FieldTitle_TextChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = string.IsNullOrEmpty(fieldTitle.Text.Trim()) == false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            BookInformation.Title = fieldTitle.Text;
            BookInformation.Price = Convert.ToDouble(fieldPrice.Value);
            BookInformation.Stock = Convert.ToInt32(fieldStock.Value);
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
        /// <param name="e"></param>
        private void BookForm_Load(object sender, EventArgs e)
        {
            fieldGuid.Text = LibrettoCommon.FormatGuid(BookInformation.Identifier);
        }
    }
}