using System;
using System.Linq;
using System.Windows.Forms;

using Libretto.Model;
using Libretto.Properties;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InventoryForm : FlatDialog
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
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        private static ListViewItem ParseBook(Book bookInformation)
        {
            return new ListViewItem(LibrettoCommon.FormatGuid(bookInformation.Id))
            {
                Tag = bookInformation,
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
            var listItem = listView.SelectedItems[0];
            var bookInformation = listItem?.Tag as Book;

            if (bookInformation == null)
            {
                return;
            }

            var bookForm = new BookForm(bookInformation);

            if (bookForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var operationResult = LibrettoClient.Instance.Proxy.UpdateBook(bookForm.BookInformation);

            if (operationResult == Response.Success)
            {
                UpdateBook(listItem, bookForm.BookInformation);
            }
            else
            {
                MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonDelete_Click(object sender, EventArgs args)
        {
            if (MessageBox.Show(this, Resources.DeleteBook, Resources.DeleteBook_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            foreach (ListViewItem listItem in listView.SelectedItems)
            {
                var bookInformation = listItem?.Tag as Book;

                if (bookInformation == null)
                {
                    continue;
                }

                var operationResult = LibrettoClient.Instance.Proxy.DeleteBook(bookInformation.Id);

                if (operationResult == Response.Success)
                {
                    listView.Items.Remove(listItem);
                    LibrettoClient.Instance.Books.Remove(bookInformation);
                }
                else
                {
                    MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInfomation"></param>
        private void InsertBook(Book bookInfomation)
        {
            LibrettoClient.Instance.Books.Add(bookInfomation);
            listView.Items.Add(ParseBook(bookInfomation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="bookInformation"></param>
        private void UpdateBook(ListViewItem listItem, Book bookInformation)
        {
            var previousIndex = listItem.Index;

            listView.Items.Remove(listItem);

            if (previousIndex >= 0)
            {
                listView.Items.Insert(previousIndex, ParseBook(bookInformation));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateButtons()
        {
            buttonUpdate.Enabled = listView.SelectedItems.Count == 1;
            buttonDelete.Enabled = listView.SelectedItems.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BookForm_Load(object sender, EventArgs args)
        {
            UpdateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ListView_SelectedIndexChanged(object sender, EventArgs args)
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

            if (bookForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var operationResult = LibrettoClient.Instance.Proxy.InsertBook(bookForm.BookInformation);

            if (operationResult == Response.Success)
            {
                InsertBook(bookForm.BookInformation);
            }
            else
            {
                MessageBox.Show(this, operationResult.ToString(), @"Libretto Bookstore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonRefresh_Click(object sender, EventArgs args)
        {
            listView.Items.Clear();
            LibrettoClient.Instance.RefreshBooks();
            listView.Items.AddRange(LibrettoClient.Instance.Books.Select(ParseBook).ToArray());
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