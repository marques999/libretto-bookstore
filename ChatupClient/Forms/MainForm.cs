using System;
using System.Windows.Forms;

namespace ChatupClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdatePrivateButtons()
        {
            buttonMessage.Enabled = listView2.SelectedItems.Count > 0;
            buttonInvite.Enabled = conversationCount > 0 && buttonMessage.Enabled;
        }

        private void UpdateRoomButtons()
        {
            buttonDelete.Enabled = listView1.SelectedItems.Count > 0;
            buttonJoin.Enabled = buttonDelete.Enabled;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrivateButtons();
        }

        private void MainForm_Load(object sender, EventArgs args)
        {
            UpdateRoomButtons();
            UpdatePrivateButtons();
            HandleInvitation("koreris");
        }

        private int conversationCount = 0;

        private void listView1_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateRoomButtons();
        }

        private void JoinRoom(PrivateChatroom roomObject)
        {
            roomObject.InsertUser(SessionData.Instance.Username);
            roomObject.InsertUser(roomObject.Name);
            LaunchRoom(new RoomForm(roomObject));
        }

        private void LaunchRoom(RoomForm roomForm)
        {
            conversationCount++;
            UpdatePrivateButtons();
            roomForm.ExitHandler += UpdateCount;
            roomForm.Show(this);
        }

        private void JoinRoom(GroupChatroom roomObject, bool userInvited)
        {
            var passwordForm = new ChatupNET.PasswordForm();

            if (userInvited || roomObject.Password == null)
            {
                roomObject.InsertUser(SessionData.Instance.Username);
                LaunchRoom(new RoomForm(roomObject));
            }
            else if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                if (passwordForm.Password.Equals(roomObject.Password))
                {
                    roomObject.InsertUser(SessionData.Instance.Username);
                    LaunchRoom(new RoomForm(roomObject));
                }
                else
                {
                    MessageBox.Show(this,
                        ChatupNET.Properties.Resources.PasswordError,
                        ChatupNET.Properties.Resources.PasswordErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void buttonJoin_Click(object sender, EventArgs args)
        {
            JoinRoom(new GroupChatroom(listView1.SelectedItems[0].Text, "qwerty", 4), false);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            JoinRoom(new GroupChatroom(listView1.SelectedItems[0].Text, "qwerty", 4), false);
        }

        private void buttonLogout_Click(object sender, EventArgs args)
        {
            if (MessageBox.Show(this,
                ChatupNET.Properties.Resources.WarnLogout,
                ChatupNET.Properties.Resources.WarnLogoutTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes
            )
            {
                SessionData.Instance.Username = null;
                Close();
            }
        }

        private void UpdateCount(int instanceCount)
        {
            conversationCount = instanceCount;
            UpdatePrivateButtons();
        }

        private void buttonMessage_Click(object sender, EventArgs args)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                JoinRoom(new PrivateChatroom(listView2.SelectedItems[0].Text));
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                JoinRoom(new PrivateChatroom(listView2.SelectedItems[0].Text));
            }
        }

        private void HandleInvitation(string userName)
        {
            if (MessageBox.Show(this,
                string.Format(ChatupNET.Properties.Resources.PromptInvite, userName),
                ChatupNET.Properties.Resources.PromptInviteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
            )
            {
                JoinRoom(new PrivateChatroom(userName));
            }
        }

        private void buttonDelete_Click(object sender, EventArgs args)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedRoom = listView1.SelectedItems[0];

                if (MessageBox.Show(this,
                    string.Format(ChatupNET.Properties.Resources.WarnDelete, selectedRoom.Text),
                    ChatupNET.Properties.Resources.WarnDeleteTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes
                )
                {
                    listView1.Items.Remove(selectedRoom);
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs args)
        {
            var modalDialog = new ChatupNET.CreateForm();

            if (modalDialog.ShowDialog(this) == DialogResult.OK)
            {
                LaunchRoom(new RoomForm(modalDialog.RoomObject));
            }
        }
    }
}