using System;

using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class BookForm : FlatDialog
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
            Text = @"Update Book";
            BookInformation = bookInformation;
            titleField.Text = bookInformation.Title;
            stockField.Text = Convert.ToString(bookInformation.Stock);
            priceField.Text = LibrettoCommon.FormatDecimal(bookInformation.Price);
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
        /// <returns></returns>
        private bool ValidateForm()
        {
            return string.IsNullOrEmpty(titleField.Text.Trim()) == false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TitleField_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            BookInformation.Title = titleField.Text.Trim();
            BookInformation.Stock = Convert.ToInt32(stockField.Value);
            BookInformation.Price = Convert.ToDouble(priceField.Value);
            LibrettoClient.Instance.Proxy.AddBook(BookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BookForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
            guidField.Text = LibrettoCommon.FormatGuid(BookInformation.Id);
        }
    }
}