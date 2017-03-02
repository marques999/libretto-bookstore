using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ChatupNET.Rooms;
using ChatupNET.Remoting;
using System.Runtime.Remoting;

namespace ChatupNET.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            sessionService = (SessionInterface)RemoteAccess.New(typeof(SessionInterface));
            sessionIntermediate = new SessionIntermediate();
            sessionIntermediate.OnLogin += UserJoined;
            sessionIntermediate.OnLogout += UserLeft;
            sessionService.OnLogin += sessionIntermediate.Login;
            sessionService.OnLogout += sessionIntermediate.Logout;
            InitializeComponent();
        }

        private void UserJoined(string userName)
        {
            MessageBox.Show("UserJoined");
            ListViewItem lvi = new ListViewItem();

            if (usersList.Items.ContainsKey(userName))
            {
                usersList.Items.RemoveByKey(userName);
            }

            lvi.Text = userName;
            lvi.SubItems.Add("Online");
            usersList.Items.Add(lvi);
        }

        private void UserLeft(string userName)
        {
            ListViewItem lvi = new ListViewItem();

            if (usersList.Items.ContainsKey(userName))
            {
                ListViewItem[] existingItem = usersList.Items.Find(userName, false);

                if (existingItem.Length > 0)
                {
                    lvi = existingItem[0];
                    lvi.SubItems.RemoveAt(0);
                    lvi.SubItems.Add("Offline");
                }
            }
            else
            {
                lvi.Text = userName;
                lvi.SubItems.Add("Offline");
                usersList.Items.Add(lvi);
            }
        }

        private SessionInterface sessionService;
        private SessionIntermediate sessionIntermediate;

        private void UpdatePrivateButtons()
        {
            buttonMessage.Enabled = usersList.SelectedItems.Count > 0;
            buttonInvite.Enabled = groupchatCount > 0 && buttonMessage.Enabled;
        }

        private void UpdateRoomButtons()
        {
            buttonDelete.Enabled = roomsList.SelectedItems.Count > 0;
            buttonJoin.Enabled = buttonDelete.Enabled;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrivateButtons();
        }

        private int groupchatCount = 0;

        private void MainForm_Load(object sender, EventArgs args)
        {
            UpdateRoomButtons();
            UpdatePrivateButtons();
            HandleInvitation("koreris");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateRoomButtons();
        }

        private void JoinRoom(GroupChatroom roomObject)
        {
            if (contextDictionary.ContainsKey(roomObject.Name))
            {
                MessageBox.Show(this,
                    Properties.Resources.ConversationExists,
                    Properties.Resources.ConversationExistsTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                roomObject.InsertUser(ChatupClient.Instance.Username);
                RegisterContext(roomObject);
                LaunchRoom(new RoomForm(roomObject));
            }
        }

        private void RegisterContext(Chatroom roomObject)
        {
            if (roomObject.IsGroup())
            {
                groupchatCount++;
                contextDictionary.Add(roomObject.Name, contextMenuStrip1.Items.Add(roomObject.Name));
            }
            else
            {
                contextDictionary.Add(roomObject.Name, null);
            }
        }

        private void JoinRoom(PrivateChatroom roomObject)
        {
            if (contextDictionary.ContainsKey(roomObject.Name))
            {
                MessageBox.Show(this,
                    Properties.Resources.ConversationExists,
                    Properties.Resources.ConversationExistsTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                roomObject.InsertUser(ChatupClient.Instance.Username);
                roomObject.InsertUser(roomObject.Name);
                RegisterContext(roomObject);
                LaunchRoom(new RoomForm(roomObject));
            }
        }

        private void LaunchRoom(RoomForm roomForm)
        {
            UpdatePrivateButtons();
            roomForm.ExitHandler += UpdateCount;
            roomForm.Show(this);
        }

        private Dictionary<Chatroom, ListViewItem> groupRooms = new Dictionary<Chatroom, ListViewItem>();
        private Dictionary<string, ToolStripItem> contextDictionary = new Dictionary<string, ToolStripItem>();

        private void JoinRoom(GroupChatroom roomObject, bool userInvited)
        {
            var passwordForm = new PasswordForm();

            if (userInvited || roomObject.Password == null)
            {
                JoinRoom(roomObject);
            }
            else if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                if (passwordForm.Password.Equals(roomObject.Password))
                {
                    JoinRoom(roomObject);
                }
                else
                {
                    MessageBox.Show(this,
                        Properties.Resources.PasswordError,
                        Properties.Resources.PasswordErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void buttonJoin_Click(object sender, EventArgs args)
        {
            JoinRoom(new GroupChatroom(roomsList.SelectedItems[0].Text, "qwerty", 4), false);
        }

        private void roomsList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            JoinRoom(new GroupChatroom(roomsList.SelectedItems[0].Text, "qwerty", 4), false);
        }

        private void buttonLogout_Click(object sender, EventArgs args)
        {
            if (MessageBox.Show(this,
                Properties.Resources.WarnLogout,
                Properties.Resources.WarnLogoutTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes
            )
            {
                ChatupClient.Instance.Logout();
                Close();
            }
        }

        private void UpdateCount(Chatroom chatroomInstance)
        {
            var roomName = chatroomInstance.Name;

            if (contextDictionary.ContainsKey(roomName))
            {
                var toolStripItem = contextDictionary[roomName];

                if (toolStripItem != null)
                {
                    contextMenuStrip1.Items.Remove(contextDictionary[roomName]);
                }

                if (chatroomInstance.IsGroup())
                {
                    groupchatCount--;

                    if (groupRooms.ContainsKey(chatroomInstance))
                    {
                        var listViewItem = groupRooms[chatroomInstance];

                        if (listViewItem != null)
                        {
                            roomsList.Items.Remove(listViewItem);
                        }

                        groupRooms.Remove(chatroomInstance);
                    }
                }

                contextDictionary.Remove(roomName);
                UpdatePrivateButtons();
            }
        }

        private void buttonMessage_Click(object sender, EventArgs args)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                JoinRoom(new PrivateChatroom(usersList.SelectedItems[0].Text));
            }
        }

        private void usersList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                JoinRoom(new PrivateChatroom(usersList.SelectedItems[0].Text));
            }
        }

        private void HandleInvitation(string userName)
        {
            if (MessageBox.Show(this,
                string.Format(Properties.Resources.PromptInvite, userName),
                Properties.Resources.PromptInviteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
            )
            {
                JoinRoom(new PrivateChatroom(userName));
            }
        }

        private void buttonDelete_Click(object sender, EventArgs args)
        {
            if (roomsList.SelectedItems.Count > 0)
            {
                var selectedRoom = roomsList.SelectedItems[0];

                if (MessageBox.Show(this,
                    string.Format(Properties.Resources.WarnDelete, selectedRoom.Text),
                    Properties.Resources.WarnDeleteTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes
                )
                {
                    roomsList.Items.Remove(selectedRoom);
                }
            }
        }

        private string FormatCapacity(GroupChatroom groupChatroom)
        {
            return string.Format("{0} / {1}", groupChatroom.Count, groupChatroom.GetCapacity());
        }

        private void buttonNew_Click(object sender, EventArgs args)
        {
            var modalDialog = new CreateForm();

            if (modalDialog.ShowDialog(this) == DialogResult.OK)
            {
                var roomObject = modalDialog.RoomObject;

                if (contextDictionary.ContainsKey(roomObject.Name))
                {
                    MessageBox.Show(this,
                      Properties.Resources.ConversationExists,
                      Properties.Resources.ConversationExistsTitle,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning
                    );
                }
                else
                {
                    JoinRoom(roomObject);
                    InsertGroup(roomObject);
                }
            }
        }

        private void InsertGroup(GroupChatroom roomObject)
        {
            var listItem = new ListViewItem(roomObject.Name);

            if (roomObject.Password == null)
            {
                listItem.Group = roomsList.Groups[0];
            }
            else
            {
                listItem.Group = roomsList.Groups[1];
            }

            listItem.SubItems.Add(FormatCapacity(roomObject));
            roomsList.Items.Add(listItem);
        }

        private void buttonInvite_Click(object sender, EventArgs args)
        {
            contextMenuStrip1.Show(buttonInvite.PointToScreen(new Point(0, buttonInvite.Height)));
        }
    }
}