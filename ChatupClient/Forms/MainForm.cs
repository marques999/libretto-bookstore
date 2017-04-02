using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Properties;
using ChatupNET.Rooms;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class MainForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _errorHandler = new ErrorHandler(this);
            _sessionIntermediate.OnLogin += OnLogin;
            _sessionIntermediate.OnLogout += OnLogin;
            _sessionIntermediate.OnRegister += OnLogin;
            _lobbyIntermediate.OnInsert += OnCreate;
            _lobbyIntermediate.OnDelete += OnDelete;
            _lobbyIntermediate.OnUpdate += OnUpdate;
            ChatupClient.Instance.InitializeSession(_sessionIntermediate);
            ChatupClient.Instance.InitializeLobby(_lobbyIntermediate);
            ChatupClient.Instance.InitializeMessaging(OnConnect, OnDisconnect, OnInvite, OnReceive);
        }

        /// <summary>
        ///
        /// </summary>
        private readonly ErrorHandler _errorHandler;

        /// <summary>
        ///
        /// </summary>
        private readonly LobbyIntermediate _lobbyIntermediate = new LobbyIntermediate();

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<int, Room> _groupChatrooms = new Dictionary<int, Room>();

        /// <summary>
        ///
        /// </summary>
        private readonly SessionIntermediate _sessionIntermediate = new SessionIntermediate();

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<Room, GroupRoom> _context = new Dictionary<Room, GroupRoom>();

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<string, string> _connections = new Dictionary<string, string>();

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<string, PrivateRoom> _privateChatrooms = new Dictionary<string, PrivateRoom>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogin(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UserHandler(UpsertUser), userInformation);
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
                BeginInvoke(new InsertHandler(InsertRoom), roomInformation);
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
                BeginInvoke(new DeleteHandler(DeleteRoom), roomId);
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
        public void OnConnect(UserProfile userProfile, string userHost)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ConnectHandler(OnConnectAux), userProfile, userHost);
            }
            else
            {
                OnConnectAux(userProfile, userHost);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        private void OnConnectAux(UserProfile userProfile, string userHost)
        {
            var userName = userProfile.Username;

            if (_privateChatrooms.ContainsKey(userName))
            {
                _errorHandler.DisplayError(RemoteResponse.ConversationExists);
            }
            else
            {
                var privateRoom = new PrivateRoom(userProfile, userHost);
                _privateChatrooms.Add(userName, privateRoom);
                privateRoom.Show();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        private void LaunchPrivate(string userName)
        {
            if (_privateChatrooms.ContainsKey(userName))
            {
                _errorHandler.DisplayError(RemoteResponse.ConversationExists);
            }
            else
            {
                var privateRoom = new PrivateRoom(_connections[userName]);
                _privateChatrooms.Add(userName, privateRoom);
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
                if (_privateChatrooms.ContainsKey(userName))
                {
                    _privateChatrooms.Remove(userName);
                }
            }
            else if (InvokeRequired)
            {
                BeginInvoke(new LeaveHandler(OnDisconnectAux), userName);
            }
            else
            {
                OnDisconnectAux(userName);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        private void OnDisconnectAux(string userName)
        {
            if (_privateChatrooms.ContainsKey(userName))
            {
                _privateChatrooms[userName].Disconnect();
                _privateChatrooms[userName].Close();
                _privateChatrooms.Remove(userName);
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
                BeginInvoke(new InviteHandler(HandleInvitation), roomInvitation);
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
            var dialogResult = MessageBox.Show(this,
                string.Format(Resources.PromptInvite, roomInvitation.Username, roomInvitation.Room),
                Resources.PromptInviteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            var operationResult = ChatupClient.Instance.Lobby.Join(roomInvitation.Id, roomInvitation.Password);

            if (operationResult.Item1 == RemoteResponse.Success)
            {
                Connect(roomInvitation.Id, operationResult.Item2);
            }
            else
            {
                _errorHandler.DisplayError(RemoteResponse.NotFound);
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
                BeginInvoke(new MessageHandler(OnReceiveAux), remoteMessage);
            }
            else
            {
                OnReceiveAux(remoteMessage);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void OnReceiveAux(RemoteMessage remoteMessage)
        {
            var userName = remoteMessage.Author.Username;

            if (string.IsNullOrEmpty(userName) == false && _privateChatrooms.ContainsKey(userName))
            {
                _privateChatrooms[userName]?.OnReceive(remoteMessage);
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
                Resources.WarnLogout,
                Resources.WarnLogoutTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var operationResult = ChatupClient.Instance.Session.Logout(ChatupClient.Instance.Profile.Username);

                if (operationResult == RemoteResponse.Success)
                {
                    args.Cancel = false;
                    ChatupClient.Instance.DestroyLobby(_lobbyIntermediate);
                    ChatupClient.Instance.DestroySession(_sessionIntermediate);
                    ChatupClient.Instance.DestroyMessaging(OnConnect, OnDisconnect, OnInvite, OnReceive);

                    while (_context.Count > 0)
                    {
                        _context.Values.First()?.Close();
                    }

                    ChatupClient.Instance.Logout();
                }
                else
                {
                    _errorHandler.DisplayError(operationResult);
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
            var convertedId = Convert.ToString(roomInformation.Id);

            if (roomsList.Items.ContainsKey(convertedId))
            {
                roomsList.Items.RemoveByKey(convertedId);
                _groupChatrooms.Remove(roomInformation.Id);
            }

            roomsList.Items.Insert(roomsList.Items.Count, new ListViewItem(new[]
            {
                roomInformation.Name,
                FormatCapacity(roomInformation)
            })
            {
                Name = convertedId,
                Group = roomInformation.IsPrivate() ? roomsList.Groups[1] : roomsList.Groups[0]
            });

            _groupChatrooms.Add(roomInformation.Id, roomInformation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        private void DeleteRoom(int roomId)
        {
            var convertedId = Convert.ToString(roomId);

            if (roomsList.Items.ContainsKey(convertedId))
            {
                roomsList.Items.RemoveByKey(convertedId);
                _groupChatrooms.Remove(roomId);
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
                BeginInvoke(new UpdateHandler(UpdateRoom), roomId, roomCount, roomCapacity);
            }
            else
            {
                UpdateRoom(roomId, roomCount, roomCapacity);
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
            var listItems = roomsList.Items.Find(Convert.ToString(roomId), false);

            if (listItems.Length <= 0)
            {
                return;
            }

            var subItems = listItems[0].SubItems;

            if (subItems.Count > 1)
            {
                subItems[1].Text = FormatCapacity(roomCount, roomCapacity);
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
                _connections.Add(userName, userInformation.Host);
            }
            else if (_connections.ContainsKey(userName))
            {
                _connections.Remove(userName);
            }

            usersList.Items.Insert(0, new ListViewItem(new[]
            {
                userName,
                userInformation.Online ? userInformation.Host : "Offline"
            })
            {
                Name = userName
            });
        }

        /// <summary>
        ///
        /// </summary>
        private void UpdatePrivateButtons()
        {
            buttonMessage.Enabled = usersList.SelectedItems.Count > 0;
            buttonInvite.Enabled = _context.Count > 0 && buttonMessage.Enabled;
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainForm_Load(object sender, EventArgs args)
        {
            var userList = ChatupClient.Instance.Session.Users;

            if (userList.Count > 0)
            {
                foreach (var userInformation in userList)
                {
                    UpsertUser(userInformation.Value);
                }
            }

            var roomList = ChatupClient.Instance.Lobby.Rooms;

            if (roomList.Count > 0)
            {
                foreach (var roomInformation in roomList)
                {
                    InsertRoom(roomInformation.Value);
                }
            }

            UpdateRoomButtons();
            UpdatePrivateButtons();
            labelUser.Text = @"User: " + ChatupClient.Instance.Username;
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
        /// <param name="roomInformation"></param>
        /// <param name="grouproomInstance"></param>
        private void LaunchRoom(Room roomInformation, GroupRoom grouproomInstance)
        {
            UpdatePrivateButtons();
            grouproomInstance.OnExit += LeaveGroup;
            _context.Add(roomInformation, grouproomInstance);
            grouproomInstance.Show(this);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        private void JoinRoom(int roomId)
        {
            var operationResult = ChatupClient.Instance.Lobby.Join(roomId, null);

            if (operationResult.Item1 == RemoteResponse.InvalidPassword)
            {
                using (var passwordForm = new PasswordForm())
                {
                    if (passwordForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    Connect(roomId, ChatupClient.Instance.Lobby.Join(roomId, passwordForm.Password));
                }
            }
            else
            {
                Connect(roomId, operationResult);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="operationResult"></param>
        private void Connect(int roomId, Tuple<RemoteResponse, string> operationResult)
        {
            if (operationResult.Item1 == RemoteResponse.Success)
            {
                Connect(roomId, operationResult.Item2);
            }
            else
            {
                _errorHandler.DisplayError(operationResult.Item1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="remoteHost"></param>
        private void Connect(int roomId, string remoteHost)
        {
            var roomInterface = RemotingServices.Connect(typeof(RoomInterface), remoteHost) as RoomInterface;

            if (roomInterface == null)
            {
                return;
            }

            if (_groupChatrooms.ContainsKey(roomId))
            {
                var roomInformation = _groupChatrooms[roomId];
                var operationResult = roomInterface.Join(ChatupClient.Instance.Profile);

                if (operationResult.Item1 == RemoteResponse.Success)
                {
                    LaunchRoom(roomInformation, new GroupRoom(roomInformation, roomInterface, operationResult.Item2));
                }
                else
                {
                    _errorHandler.DisplayError(operationResult.Item1);
                }
            }
            else
            {
                _errorHandler.DisplayError(RemoteResponse.NotFound);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonJoin_Click(object sender, EventArgs args)
        {
            if (roomsList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = roomsList.SelectedItems[0];

            if (listItem != null)
            {
                JoinRoom(Convert.ToInt32(listItem.Name));
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
            if (_context.ContainsKey(roomInformation))
            {
                _context.Remove(roomInformation);
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
            if (usersList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = usersList.SelectedItems[0];

            if (listItem != null)
            {
                JoinPrivate(listItem.Text);
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
                MessageBox.Show(this,
                    Resources.MainForm_SelfClicked,
                    Resources.MainForm_SelfClickedTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                if (_connections.ContainsKey(userName))
                {
                    LaunchPrivate(userName);
                }
                else
                {
                    MessageBox.Show(this,
                        Resources.MainForm_UserOffline,
                        Resources.MainForm_UserOfflineTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
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
            if (roomsList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = roomsList.SelectedItems[0];

            var dialogResult = MessageBox.Show(this,
                string.Format(Resources.WarnDelete, listItem.Text),
                Resources.WarnDeleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

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
                _errorHandler.DisplayError(operationResult);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        private static string FormatCapacity(Room roomInformation)
        {
            return FormatCapacity(roomInformation.Count, roomInformation.Capacity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        /// <returns></returns>
        private static string FormatCapacity(int roomCount, int roomCapacity)
        {
            return $"{roomCount:D} / {roomCapacity:D}";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonNew_Click(object sender, EventArgs args)
        {
            var modalDialog = new InsertForm();

            if (modalDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var operationResult = ChatupClient.Instance.Lobby.Insert(modalDialog.RoomObject);

            if (operationResult.Item1 == RemoteResponse.Success)
            {
                var roomInformation = operationResult.Item2;

                if (roomInformation == null)
                {
                    _errorHandler.DisplayError(RemoteResponse.OperationFailed);
                }
            }
            else
            {
                _errorHandler.DisplayError(operationResult.Item1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonInvite_Click(object sender, EventArgs args)
        {
            if (usersList.SelectedItems.Count <= 0)
            {
                return;
            }

            var listItem = usersList.SelectedItems[0];

            if (listItem != null)
            {
                InviteUser(listItem.Name);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        private void InviteUser(string userName)
        {
            if (userName == ChatupClient.Instance.Username)
            {
                MessageBox.Show(this,
                    Resources.MainForm_InviteSelf,
                    Resources.MainForm_InviteSelfTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else if (_connections.ContainsKey(userName))
            {
                var inviteForm = new InviteForm(_context.Keys);

                if (inviteForm.ShowDialog() == DialogResult.OK)
                {
                    InviteUser(inviteForm.RoomId, userName);
                }
            }
            else
            {
                MessageBox.Show(this,
                    Resources.MainForm_UserOffline,
                    Resources.MainForm_UserOfflineTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userName"></param>
        private void InviteUser(int roomId, string userName)
        {
            if (_groupChatrooms.ContainsKey(roomId) == false)
            {
                return;
            }

            var roomInformation = _groupChatrooms[roomId];

            if (roomInformation == null)
            {
                return;
            }

            var remoteUser = RemotingServices.Connect(typeof(MessageInterface), _connections[userName]) as MessageInterface;

            if (remoteUser == null)
            {
                return;
            }

            var operationResult = remoteUser.Invite(new RoomInvitation(roomInformation));

            if (operationResult != RemoteResponse.Success)
            {
                _errorHandler.DisplayError(operationResult);
            }
        }
    }
}