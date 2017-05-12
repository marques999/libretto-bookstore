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
        private void RefreshBooks()
        {
            listView.Items.Clear();
            listView.Items.AddRange(LibrettoClient.Instance.Books.Select(ParseBook).ToArray());
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
            if (MessageBox.Show(this, Resources.DeleteBook, Resources.DeleteBook_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            foreach (ListViewItem listItem in listView.SelectedItems)
            {
                if (listItem == null || listItem.Index < 0)
                {
                    continue;
                }

                LibrettoClient.Instance.Books.RemoveAt(listItem.Index);
                listView.Items.Remove(listItem);
            }
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
            listView.Items.Add(ParseBook(bookInfomation));
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
            RefreshBooks();
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