using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InventoryForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public InventoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshBooks()
        {
            booksList.Items.Clear();
            booksList.Items.AddRange(LibrettoClient.Instance.Books.Select(ParseBook).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        private static ListViewItem ParseBook(Book bookInformation)
        {
            return new ListViewItem(LibrettoCommon.FormatGuid(bookInformation.Identifier))
            {
                SubItems =
                {
                    bookInformation.Title,
                    LibrettoCommon.FormatCurrency(bookInformation.Price),
                    Convert.ToString(bookInformation.Stock)
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonUpdate_Click(object sender, EventArgs args)
        {
            if (booksList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = booksList.SelectedItems[0];

            if (listItem == null || listItem.Index < 0)
            {
                return;
            }

            var bookForm = new BookForm(LibrettoClient.Instance.Books[listItem.Index]);

            if (bookForm.ShowDialog(this) == DialogResult.OK)
            {
                UpdateBook(listItem, bookForm.BookInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonDelete_Click(object sender, EventArgs args)
        {
            if (booksList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = booksList.SelectedItems[0];

            if (listItem == null || listItem.Index < 0)
            {
                return;
            }

            var bookIndex = listItem.Index;
            var bookInformation = LibrettoClient.Instance.Books[listItem.Index];

            if (MessageBox.Show(this, $@"Please confirm you want to remove ""{bookInformation.Title}"" from your bookstore.", @"Remove Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            LibrettoClient.Instance.Books.RemoveAt(bookIndex);
            booksList.Items.Remove(listItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        private delegate void BookInsertHandler(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="bookInformation"></param>
        private delegate void BookUpdateHandler(ListViewItem listItem, Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        private void OnInsert(Book bookInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new BookInsertHandler(InsertBook), bookInformation);
            }
            else
            {
                InsertBook(bookInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInfomation"></param>
        private void InsertBook(Book bookInfomation)
        {
            LibrettoClient.Instance.Books.Add(bookInfomation);
            booksList.Items.Add(ParseBook(bookInfomation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="bookInformation"></param>
        private void OnUpdate(ListViewItem listItem, Book bookInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new BookUpdateHandler(UpdateBook), listItem, bookInformation);
            }
            else
            {
                UpdateBook(listItem, bookInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="bookInformation"></param>
        private void UpdateBook(ListViewItem listItem, Book bookInformation)
        {
            var previousIndex = listItem.Index;

            booksList.Items.Remove(listItem);

            if (previousIndex >= 0)
            {
                booksList.Items.Insert(previousIndex, ParseBook(bookInformation));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonUpdate.Enabled = buttonDelete.Enabled = booksList.SelectedItems.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BookForm_Load(object sender, EventArgs args)
        {
            RefreshBooks();
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BooksList_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonPublish_Click(object sender, EventArgs args)
        {
            var bookForm = new BookForm();

            if (bookForm.ShowDialog(this) == DialogResult.OK)
            {
                InsertBook(bookForm.BookInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonRefresh_Click(object sender, EventArgs args)
        {
            RefreshBooks();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BooksList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            ButtonUpdate_Click(sender, args);
        }
    }
}