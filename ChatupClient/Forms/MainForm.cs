using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Rooms;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userStatus"></param>
    delegate void ActionUserHandler(string userName, string userStatus);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lvItem"></param>
    /// <returns></returns>
    delegate ListViewItem ListViewInsert(ListViewItem lvItem);

    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            sessionIntermediate.OnLogin += OnLogin;
            sessionIntermediate.OnLogout += OnLogout;
            lobbyIntermediate.OnCreate += OnCreate;
            lobbyIntermediate.OnDelete += OnDelete;
            lobbyIntermediate.OnUpdate += OnUpdate;
            ChatupClient.Instance.InitializeLobby(lobbyIntermediate);
            ChatupClient.Instance.IntializeSession(sessionIntermediate);
            ChatupClient.Instance.InitializeMessaging(OnConnect, OnDisconnect, OnReceive);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogin(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionUserHandler(UpsertUser), new object[]
                {
                    userInformation.Username, "Active"
                });
            }
            else
            {
                UpsertUser(userInformation.Username, "Active");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogout(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionUserHandler(UpsertUser), new object[]
                {
                    userInformation.Username, "Offline"
                });
            }
            else
            {
                UpsertUser(userInformation.Username, "Offline");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomInformation"></param>
        private void OnCreate(int roomId, Room roomInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomInsertHandler(InsertRoom), new object[]
                {
                    roomId, roomInformation
                });
            }
            else
            {
                InsertRoom(roomId, roomInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void OnDelete(int roomId)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomDeleteHandler(DeleteRoom), new object[]
                {
                    roomId
                });
            }
            else
            {
                DeleteRoom(roomId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        private void OnUpdate(int roomId, int roomCount, int roomCapacity)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomUpdateHandler(UpdateRoom), new object[]
                {
                    roomId, roomCount, roomCapacity
                });
            }
            else
            {
                UpdateRoom(roomId, roomCount, roomCapacity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        public void OnConnect(UserProfile userProfile, Address userHost)
        {
            var groupRoom = new PrivateRoom(ChatupClient.Instance.Profile, userProfile, userHost);

            if (groupRoom != null)
            {
                privateChatrooms.Add(userProfile.Username, groupRoom);
                groupRoom.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void OnDisconnect(string userName)
        {
            if (privateChatrooms.ContainsKey(userName))
            {
                var userForm = privateChatrooms[userName];

                if (userForm != null)
                {
                    userForm.Close();
                    userForm.Dispose();
                    privateChatrooms.Remove(userName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void OnReceive(RemoteMessage remoteMessage)
        {
            var userName = remoteMessage.Author;

            if (string.IsNullOrEmpty(userName))
            {
                return;
            }

            if (privateChatrooms.ContainsKey(userName))
            {
                var userForm = privateChatrooms[userName];

                if (userForm != null)
                {
                    userForm.AppendMessage(remoteMessage);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private LobbyIntermediate lobbyIntermediate = new LobbyIntermediate();

        /// <summary>
        /// 
        /// </summary>
        private SessionIntermediate sessionIntermediate = new SessionIntermediate();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, Room> groupChatrooms = new Dictionary<int, Room>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, PrivateRoom> privateChatrooms = new Dictionary<string, PrivateRoom>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            args.Cancel = true;

            if (MessageBox.Show(this,
                Properties.Resources.WarnLogout,
                Properties.Resources.WarnLogoutTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes
            )
            {
                var operationResult = ChatupClient.Instance.Logout();

                if (operationResult == RemoteResponse.Success)
                {
                    args.Cancel = false;
                    ChatupClient.Instance.DestroyLobby(lobbyIntermediate);
                    ChatupClient.Instance.DestroySession(sessionIntermediate);
                    ChatupClient.Instance.DestroyMessaging(OnConnect, OnDisconnect, OnReceive);
                }
                else
                {
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }

            base.OnClosing(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomInformation"></param>
        private void InsertRoom(int roomId, Room roomInformation)
        {
            DeleteRoom(roomId);

            var listItem = new ListViewItem(new string[]
            {
                roomInformation.Name,
                FormatCapacity(roomInformation)
            });

            if (roomInformation.IsPrivate())
            {
                listItem.Group = roomsList.Groups[1];
            }
            else
            {
                listItem.Group = roomsList.Groups[0];
            }

            listItem.Name = Convert.ToString(roomId);
            roomsList.Items.Add(listItem);
            groupChatrooms.Add(roomId, roomInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void DeleteRoom(int roomId)
        {
            var _roomId = Convert.ToString(roomId);

            if (roomsList.Items.ContainsKey(_roomId))
            {
                roomsList.Items.RemoveByKey(_roomId);
                groupChatrooms.Remove(roomId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        private void UpdateRoom(int roomId, int roomCount, int roomCapacity)
        {
            var _roomId = Convert.ToString(roomId);

            if (!roomsList.Items.ContainsKey(_roomId))
            {
                return;
            }

            var listItems = roomsList.Items.Find(_roomId, false);

            if (listItems.Length > 0)
            {
                listItems[0].SubItems.RemoveAt(0);
                listItems[0].SubItems.Add(FormatCapacity(roomCount, roomCapacity));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userStatus"></param>
        private void UpsertUser(string userName, string userStatus)
        {
            if (usersList.Items.ContainsKey(userName))
            {
                usersList.Items.RemoveByKey(userName);
            }

            var lvi = new ListViewItem(new string[]
            {
                userName, userStatus
            });

            lvi.Name = userName;
            usersList.Items.Insert(0, lvi);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdatePrivateButtons()
        {
            buttonMessage.Enabled = usersList.SelectedItems.Count > 0;
            buttonInvite.Enabled = groupchatCount > 0 && buttonMessage.Enabled;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateRoomButtons()
        {
            buttonDelete.Enabled = roomsList.SelectedItems.Count > 0;
            buttonJoin.Enabled = buttonDelete.Enabled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void listView2_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdatePrivateButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        private int groupchatCount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainForm_Load(object sender, EventArgs args)
        {
            InitializeUsers();
            InitializeRoooms();
            UpdateRoomButtons();
            UpdatePrivateButtons();
            HandleInvitation("koreris");
            labelUser.Text = "User: " + ChatupClient.Instance.Username;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeUsers()
        {
            var remoteList = ChatupClient.Instance.Session.List();

            foreach (var userInformation in remoteList)
            {
                UpsertUser(userInformation.Key, userInformation.Value.Status ? "Active" : "Offline");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeRoooms()
        {
            var remoteList = ChatupClient.Instance.Lobby.List();

            foreach (var roomInformation in remoteList)
            {
                InsertRoom(roomInformation.Key, roomInformation.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs args)
        {
            UpdateRoomButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomForm"></param>
        private void LaunchRoom(GroupRoom roomForm)
        {
            UpdatePrivateButtons();
            roomForm.ExitHandler += UpdateCount;
            roomForm.Show(this);
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, ToolStripItem> contextDictionary = new Dictionary<int, ToolStripItem>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void JoinRoom(int roomId)
        {
            var passwordForm = new PasswordForm();
            var privateRoom = ChatupClient.Instance.Lobby.IsPrivate(roomId);

            if (privateRoom == RemoteResponse.NotFound)
            {
                ErrorHandler.DisplayError(this, privateRoom);
            }
            else if (privateRoom == RemoteResponse.OperationFailed)
            {
                Connect(roomId, null);
            }
            else if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                Connect(roomId, passwordForm.Password);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userInvited"></param>
        private void JoinRoom(int roomId, string userPassword)
        {
            var privateRoom = ChatupClient.Instance.Lobby.IsPrivate(roomId);

            if (privateRoom == RemoteResponse.NotFound)
            {
                ErrorHandler.DisplayError(this, privateRoom);
            }
            else if (privateRoom == RemoteResponse.OperationFailed)
            {
                Connect(roomId, null);
            }
            else if (!string.IsNullOrEmpty(userPassword))
            {
                Connect(roomId, userPassword);
            }
        }

        private void Connect(int roomId, string userPassword)
        {
            var operationResult = ChatupClient.Instance.Lobby.Join(
                ChatupClient.Instance.Username,
                userPassword,
                roomId
            );

            if (operationResult.Response == RemoteResponse.Success)
            {
                string remoteUri = Convert.ToString(operationResult.Contents);

                if (!string.IsNullOrEmpty(remoteUri))
                {
                    if (contextDictionary.ContainsKey(roomId))
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
                        groupchatCount++;
                        contextDictionary.Add(roomId, contextMenuStrip1.Items.Add(groupChatrooms[roomId].Name));
                        LaunchRoom(new GroupRoom(roomId, groupChatrooms[roomId], remoteUri));
                    }
                }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonJoin_Click(object sender, EventArgs args)
        {
            JoinRoom(Convert.ToInt32(roomsList.SelectedItems[0].Name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void roomsList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            JoinRoom(Convert.ToInt32(roomsList.SelectedItems[0].Name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonLogout_Click(object sender, EventArgs args)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatroomInstance"></param>
        private void UpdateCount(int roomId)
        {
            if (contextDictionary.ContainsKey(roomId))
            {
                var toolStripItem = contextDictionary[roomId];

                if (toolStripItem != null)
                {
                    contextMenuStrip1.Items.Remove(contextDictionary[roomId]);
                }

                groupchatCount--;
                contextDictionary.Remove(roomId);
                UpdatePrivateButtons();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonMessage_Click(object sender, EventArgs args)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                var listItem = usersList.SelectedItems[0];

                if (listItem != null)
                {
                    JoinPrivate(listItem.Text);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void JoinPrivate(string userName)
        {
            if (userName == ChatupClient.Instance.Username)
            {
                MessageBox.Show("You can't launch a private conversation with yourself!");
            }
            else
            {
                var remoteHost = ChatupClient.Instance.Lobby.Lookup(userName);

                if (remoteHost != null)
                {
                    new PrivateRoom(ChatupClient.Instance.Profile, null, remoteHost).Show();
                }
                else
                {
                    MessageBox.Show("This user is currently offline!");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void usersList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                var listItem = usersList.SelectedItems[0];

                if (listItem != null)
                {
                    JoinPrivate(listItem.Text);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        private void HandleInvitation(string userName)
        {
            if (MessageBox.Show(this,
                string.Format(Properties.Resources.PromptInvite, userName),
                Properties.Resources.PromptInviteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
            )
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonDelete_Click(object sender, EventArgs args)
        {
            if (roomsList.SelectedItems.Count > 0)
            {
                var selectedRoom = roomsList.SelectedItems[0];

                var dialogResult = MessageBox.Show(
                    this,
                    string.Format(Properties.Resources.WarnDelete, selectedRoom.Text),
                    Properties.Resources.WarnDeleteTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    var operationResult = ChatupClient.Instance.Lobby.Delete(
                        ChatupClient.Instance.Username,
                        Convert.ToInt32(selectedRoom.Name)
                    );

                    if (operationResult == RemoteResponse.Success)
                    {
                        roomsList.Items.Remove(selectedRoom);
                    }
                    else
                    {
                        ErrorHandler.DisplayError(this, operationResult);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        private string FormatCapacity(Room roomInstance)
        {
            return FormatCapacity(roomInstance.Count, roomInstance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        /// <returns></returns>
        private string FormatCapacity(int roomCount, int roomCapacity)
        {
            return string.Format("{0} / {1}", roomCount, roomCapacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonNew_Click(object sender, EventArgs args)
        {
            var modalDialog = new InsertForm();

            if (modalDialog.ShowDialog(this) == DialogResult.OK)
            {
                var roomObject = modalDialog.RoomObject;
                var operationResult = ChatupClient.Instance.Lobby.New(roomObject);

                if (operationResult.Response == RemoteResponse.Success)
                {
                    int roomId = Convert.ToInt32(operationResult.Contents);

                    if (roomId > 0)
                    {
                        InsertRoom(roomId, roomObject);
                        JoinRoom(roomId, roomObject.Password);
                    }
                    else
                    {

                    }
                }
                else
                {
                    ErrorHandler.DisplayError(this, operationResult.Response);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonInvite_Click(object sender, EventArgs args)
        {
            contextMenuStrip1.Show(buttonInvite.PointToScreen(new Point(0, buttonInvite.Height)));
        }
    }
}