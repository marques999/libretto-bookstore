using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InviteForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupChatrooms"></param>
        public InviteForm(IEnumerable<Room> groupChatrooms)
        {
            InitializeComponent();

            foreach (var roomInformation in groupChatrooms)
            {
                InsertRoom(roomInformation);
            }

            if (roomsList.Items.Count <= 0)
            {
                return;
            }

            roomsList.Items[0].Selected = true;
            roomsList.Select();
        }

        /// <summary>
        /// 
        /// </summary>
        public int RoomId
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void InsertRoom(Room roomInformation)
        {
            roomsList.Items.Insert(roomsList.Items.Count, new ListViewItem(new[]
            {
                roomInformation.Name,
                $"{roomInformation.Count:D} / {roomInformation.Capacity:D}"
            })
            {
                Name = Convert.ToString(roomInformation.Id),
                Group = roomInformation.IsPrivate() ? roomsList.Groups[1] : roomsList.Groups[0]
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonInvite_Click(object sender, EventArgs args)
        {
            if (roomsList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = roomsList.SelectedItems[0];

            if (listItem == null)
            {
                return;
            }

            RoomId = Convert.ToInt32(listItem.Name);
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void roomsList_DoubleClick(object sender, EventArgs args)
        {
            buttonInvite_Click(sender, args);
        }
    }
}