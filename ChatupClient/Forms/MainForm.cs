using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Rooms;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            sessionIntermediate.OnLogin += OnLogin;
            sessionIntermediate.OnLogout += OnLogout;
            lobbyIntermediate.OnInsert += OnCreate;
            lobbyIntermediate.OnDelete += OnDelete;
            ChatupClient.Instance.InitializeSession(sessionIntermediate);
            ChatupClient.Instance.InitializeLobby(lobbyIntermediate);
            ChatupClient.Instance.InitializeMessaging(OnConnect, OnDisconnect, OnInvite, OnReceive);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listItem"></param>
        /// <returns></returns>
        private delegate ListViewItem ListViewInsert(ListViewItem listItem);

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, Room> groupChatrooms = new Dictionary<int, Room>();

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
        private Dictionary<string, string> connections = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, PrivateRoom> privateChatrooms = new Dictionary<string, PrivateRoom>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogin(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UserHandler(UpsertUser), new object[]
                {
                    userInformation
                });
            }
            else
            {
                UpsertUser(userInformation);
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
                BeginInvoke(new UserHandler(UpsertUser), new object[]
                {
                    userInformation
                });
            }
            else
            {
                UpsertUser(userInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void OnCreate(Room roomInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new InsertHandler(InsertRoom), new object[]
                {
                    roomInformation
                });
            }
            else
            {
                InsertRoom(roomInformation);
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
                BeginInvoke(new DeleteHandler(DeleteRoom), new object[]
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
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        public void OnConnect(Tuple<string, Color> userProfile, string userHost)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ConnectHandler(OnConnectAUX), new object[]
                {
                    userProfile, userHost
                });
            }
            else
            {
                OnConnectAUX(userProfile, userHost);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        private void OnConnectAUX(Tuple<string, Color> userProfile, string userHost)
        {
            var privateRoom = new PrivateRoom(userProfile, userHost);

            if (privateRoom != null)
            {
                privateChatrooms.Add(userProfile.Item1, privateRoom);
                privateRoom.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="remoteInvocation"></param>
        public void OnDisconnect(string userName, bool remoteInvocation)
        {
            if (remoteInvocation)
            {
                if (privateChatrooms.ContainsKey(userName))
                {
                    privateChatrooms.Remove(userName);
                }
            }
            else
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new LeaveHandler(OnDisconnectAUX), new object[]
                    {
                        userName
                    });
                }
                else
                {
                    OnDisconnectAUX(userName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        private void OnDisconnectAUX(string userName)
        {
            if (privateChatrooms.ContainsKey(userName))
            {
                privateChatrooms[userName].Disconnect();
                privateChatrooms[userName].Close();
                privateChatrooms.Remove(userName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInvitation"></param>
        private void OnInvite(RoomInvitation roomInvitation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new InviteHandler(HandleInvitation), new object[]
                {
                    roomInvitation
                });
            }
            else
            {
                HandleInvitation(roomInvitation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInvitation"></param>
        private void HandleInvitation(RoomInvitation roomInvitation)
        {
            if (MessageBox.Show(this,
                string.Format(Properties.Resources.PromptInvite, roomInvitation.Username, roomInvitation.Room),
                Properties.Resources.PromptInviteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var roomId = roomInvitation.ID;
                var operationResult = ChatupClient.Instance.Lobby.QueryRoom(roomId);

                if (operationResult.Item2 == null)
                {
                    ErrorHandler.DisplayError(this, RemoteResponse.NotFound);
                }
                else if (operationResult.Item1 == false)
                {
                    Connect(roomId, operationResult.Item2, null);
                }
                else if (!string.IsNullOrEmpty(roomInvitation.Password))
                {
                    Connect(roomId, operationResult.Item2, roomInvitation.Password);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        private void OnReceive(RemoteMessage remoteMessage)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MessageHandler(OnReceiveAUX), new object[]
                {
                    remoteMessage
                });
            }
            else
            {
                OnReceiveAUX(remoteMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void OnReceiveAUX(RemoteMessage remoteMessage)
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
                    ChatupClient.Instance.DestroyMessaging(OnConnect, OnDisconnect, OnInvite, OnReceive);
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
        /// <param name="roomInformation"></param>
        private void InsertRoom(Room roomInformation)
        {
            var _roomId = Convert.ToString(roomInformation.ID);

            if (roomsList.Items.ContainsKey(_roomId))
            {
                roomsList.Items.RemoveByKey(_roomId);
                groupChatrooms.Remove(roomInformation.ID);
            }

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

            listItem.Name = _roomId;
            roomsList.Items.Insert(roomsList.Items.Count, listItem);
            groupChatrooms.Add(roomInformation.ID, roomInformation);
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
        /// <param name="roomInformation"></param>
        private void UpdateRoom(Room roomInformation)
        {
            var listItems = roomsList.Items.Find(Convert.ToString(roomInformation.ID), false);

            if (listItems != null && listItems.Length > 0)
            {
                var subItems = listItems[0].SubItems;

                if (subItems != null && subItems.Count > 1)
                {
                    subItems[1].Text = FormatCapacity(roomInformation);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void UpsertUser(UserInformation userInformation)
        {
            var userName = userInformation.Username;

            if (usersList.Items.ContainsKey(userName))
            {
                usersList.Items.RemoveByKey(userName);
            }

            if (userInformation.Online)
            {
                connections.Add(userName, userInformation.Host);
            }
            else
            {
                if (connections.ContainsKey(userName))
                {
                    connections.Remove(userName);
                }
            }

            var lvi = new ListViewItem(new string[]
            {
                userName,
                userInformation.Online ? userInformation.Host : "Offline"
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
            buttonInvite.Enabled = true;//groupchatCount > 0 && buttonMessage.Enabled;
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
            var userList = ChatupClient.Instance.Session.List();

            if (userList.Count > 0)
            {
                foreach (var userInformation in userList)
                {
                    UpsertUser(userInformation.Value);
                }
            }

            var roomList = ChatupClient.Instance.Lobby.List();

            if (roomList.Count > 0)
            {
                foreach (var roomInformation in roomList)
                {
                    InsertRoom(roomInformation.Value);
                }
            }

            UpdateRoomButtons();
            UpdatePrivateButtons();
            labelUser.Text = "User: " + ChatupClient.Instance.Username;
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
        /// <param name="grouproomInstance"></param>
        private void LaunchRoom(GroupRoom grouproomInstance)
        {
            UpdatePrivateButtons();
            grouproomInstance.ExitHandler += LeaveGroup;
            grouproomInstance.Show(this);
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
            var operationResult = ChatupClient.Instance.Lobby.QueryRoom(roomId);

            if (operationResult.Item2 == null)
            {
                ErrorHandler.DisplayError(this, RemoteResponse.NotFound);
            }
            else if (!operationResult.Item1)
            {
                Connect(roomId, operationResult.Item2, null);
            }
            else if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                Connect(roomId, operationResult.Item2, passwordForm.Password);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="remoteHost"></param>
        /// <param name="roomPassword"></param>
        private void Connect(int roomId, string remoteHost, string roomPassword)
        {
            var roomInterface = (RoomInterface)RemotingServices.Connect(typeof(RoomInterface), remoteHost);

            if (roomInterface == null)
            {
                return;
            }

            var operationResult = roomInterface.Join(ChatupClient.Instance.Username, roomPassword);

            if (operationResult.Item1 == RemoteResponse.Success)
            {
                var messageQueue = operationResult.Item2;

                if (messageQueue != null)
                {
                    groupchatCount++;
                    //contextDictionary.Add(roomId, contextMenuStrip1.Items.Add(groupChatrooms[roomId].Name));
                    LaunchRoom(new GroupRoom(groupChatrooms[roomId], roomInterface, messageQueue));
                }
                /*if (groupChatrooms.ContainsKey(roomId))
                {
                    MessageBox.Show(this,
                    Properties.Resources.PasswordError,
                    Properties.Resources.PasswordErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                    );
                }*/
            }
            else
            {
                ErrorHandler.DisplayError(this, operationResult.Item1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonJoin_Click(object sender, EventArgs args)
        {
            if (roomsList.SelectedItems.Count > 0)
            {
                var listItem = roomsList.SelectedItems[0];

                if (listItem != null)
                {
                    JoinRoom(Convert.ToInt32(listItem.Name));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void roomsList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            buttonJoin_Click(sender, args);
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
        /// <param name="roomInformation"></param>
        private void LeaveGroup(Room roomInformation)
        {
            var roomId = roomInformation.ID;

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

            if (groupChatrooms.ContainsKey(roomId))
            {
                groupChatrooms.Remove(roomId);
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void usersList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            buttonMessage_Click(sender, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        private void JoinPrivate(string userName)
        {
            if (userName == ChatupClient.Instance.Username)
            {
                MessageBox.Show("You can't launch a private conversation with yourself!");
            }
            else
            {
                if (connections.ContainsKey(userName))
                {
                    var privateRoom = new PrivateRoom(connections[userName]);

                    if (privateRoom != null)
                    {
                        privateChatrooms.Add(userName, privateRoom);
                        privateRoom.Show();
                    }
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
        private void buttonDelete_Click(object sender, EventArgs args)
        {
            if (roomsList.SelectedItems.Count > 0)
            {
                var listItem = roomsList.SelectedItems[0];

                var dialogResult = MessageBox.Show(this,
                    string.Format(Properties.Resources.WarnDelete, listItem.Text),
                    Properties.Resources.WarnDeleteTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    var operationResult = ChatupClient.Instance.Lobby.Delete(
                        Convert.ToInt32(listItem.Name),
                        ChatupClient.Instance.Username
                    );

                    if (operationResult == RemoteResponse.Success)
                    {
                        roomsList.Items.Remove(listItem);
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
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        private string FormatCapacity(Room roomInformation)
        {
            return FormatCapacity(roomInformation.Count, roomInformation.Capacity);
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
                var operationResult = ChatupClient.Instance.Lobby.Insert(modalDialog.RoomObject);

                if (operationResult.Item1 == RemoteResponse.Success)
                {
                    var roomInformation = operationResult.Item2;

                    if (roomInformation == null)
                    {
                        ErrorHandler.DisplayError(this, RemoteResponse.OperationFailed);
                    }
                }
                else
                {
                    ErrorHandler.DisplayError(this, operationResult.Item1);
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
            InviteUser(1, "koreris");
            //contextMenuStrip1.Show(buttonInvite.PointToScreen(new Point(0, buttonInvite.Height)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs args)
        {
            if (args.ClickedItem != null)
            {
                if (usersList.SelectedItems.Count > 0)
                {
                    var listItem = usersList.SelectedItems[0];

                    if (listItem != null)
                    {
                        InviteUser(Convert.ToInt32(args.ClickedItem.Text), listItem.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userName"></param>
        private void InviteUser(int roomId, string userName)
        {
            if (connections.ContainsKey(userName) && groupChatrooms.ContainsKey(roomId))
            {
                var roomInformation = groupChatrooms[roomId];

                if (roomInformation != null)
                {
                    var remoteUser = (MessageInterface)RemotingServices.Connect(typeof(MessageInterface), connections[userName]);
                    var operationResult = remoteUser.Invite(new RoomInvitation(roomInformation));

                    if (operationResult != RemoteResponse.Success)
                    {
                        ErrorHandler.DisplayError(this, operationResult);
                    }
                }
            }
        }
    }
}