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

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lobbyIntermediate = new LobbyIntermediate();
            sessionIntermediate = new SessionIntermediate();

            sessionIntermediate.OnLogin += delegate (UserInformation userInformation)
            {
                BeginInvoke(new ActionUserHandler(UpsertUser), new object[]
                {
                    userInformation.Username, "Active"
                });
            };

            sessionIntermediate.OnLogout += delegate (UserInformation userInformation)
            {
                BeginInvoke(new ActionUserHandler(UpsertUser), new object[]
                {
                    userInformation.Username, "Offline"
                });
            };

            lobbyIntermediate.OnCreate += delegate (int roomId, Room roomInformation)
            {
                BeginInvoke(new RoomInsertHandler(InsertRoom), new object[]
                {
                    roomId, roomInformation
                });
            };

            lobbyIntermediate.OnDelete += delegate (int roomId)
            {
                BeginInvoke(new RoomDeleteHandler(DeleteRoom), new object[]
                {
                    roomId
                });
            };

            lobbyIntermediate.OnUpdate += delegate (int roomId, int roomCount, int roomCapacity)
            {
                BeginInvoke(new RoomUpdateHandler(UpdateRoom), new object[]
                {
                    roomId, roomCount, roomCapacity
                });
            };

            ChatupClient.Instance.InitializeLobby(lobbyIntermediate);
            ChatupClient.Instance.IntializeSession(sessionIntermediate);
        }

        private LobbyIntermediate lobbyIntermediate;
        private SessionIntermediate sessionIntermediate;
        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ChatupClient.Instance.DestroyLobby(lobbyIntermediate);
            ChatupClient.Instance.DestroySession(sessionIntermediate);
        }

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
            rooms.Add(roomId, roomInformation);
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
                rooms.Remove(roomId);
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
        /// <param name="e"></param>
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrivateButtons();
        }

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
        /// <param name="roomId"></param>
        private void JoinRoom(int roomId)
        {
            if (contextDictionary.ContainsKey(Convert.ToString(roomId)))
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
                RegisterContext(roomId, rooms[roomId]);
                LaunchRoom(new RoomForm(rooms[roomId]));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomObject"></param>
        private void RegisterContext(int roomId, Room roomObject)
        {
            var _roomId = Convert.ToString(roomId);

            if (roomObject.IsGroup())
            {
                groupchatCount++;
                contextDictionary.Add(_roomId, contextMenuStrip1.Items.Add(roomObject.Name));
            }
            else
            {
                contextDictionary.Add(_roomId, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomObject"></param>
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
                // RegisterContext(roomObject);
                //  LaunchRoom(new RoomForm(roomObject));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomForm"></param>
        private void LaunchRoom(RoomForm roomForm)
        {
            UpdatePrivateButtons();
            roomForm.ExitHandler += UpdateCount;
            roomForm.Show(this);
        }

        private Dictionary<Room, ListViewItem> groupRooms = new Dictionary<Room, ListViewItem>();
        private Dictionary<string, ToolStripItem> contextDictionary = new Dictionary<string, ToolStripItem>();

        private void JoinRoom(int roomId, bool userInvited)
        {
            var passwordForm = new PasswordForm();
            var privateRoom = ChatupClient.Instance.Lobby.IsPrivate(roomId);

            if (privateRoom == RemoteResponse.NotFound)
            {

            }
            else if (privateRoom == RemoteResponse.OperationFailed || userInvited)
            {
                JoinRoom(roomId);
            }
            else if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                var operationResult = ChatupClient.Instance.Lobby.Join(
                    ChatupClient.Instance.Username,
                    passwordForm.Password,
                    roomId
                );

                if (operationResult == RemoteResponse.Success)
                {
                    JoinRoom(roomId);
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
            JoinRoom(Convert.ToInt32(roomsList.SelectedItems[0].Name), false);
        }

        private void roomsList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            JoinRoom(Convert.ToInt32(roomsList.SelectedItems[0].Name), false);
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
                var operationResult = ChatupClient.Instance.Logout();

                if (operationResult == RemoteResponse.Success)
                {
                    Close();
                }
                else
                {
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }
        }

        private void UpdateCount(Room chatroomInstance)
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
                JoinRoom(new PrivateChatroom(usersList.SelectedItems[0].Text, ChatupClient.Instance.Username));
            }
        }

        private void usersList_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                JoinRoom(new PrivateChatroom(usersList.SelectedItems[0].Text, ChatupClient.Instance.Username));
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
                JoinRoom(new PrivateChatroom(userName, ChatupClient.Instance.Username));
            }
        }

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

        private string FormatCapacity(Room roomInstance)
        {
            return FormatCapacity(roomInstance.Count, roomInstance.Capacity);
        }

        private string FormatCapacity(int roomCount, int roomCapacity)
        {
            return string.Format("{0} / {1}", roomCount, roomCapacity);
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
                    var operationResult = ChatupClient.Instance.Lobby.New(roomObject);

                    if (operationResult == RemoteResponse.Success)
                    {
                        InsertRoom(1, roomObject);
                        JoinRoom(1);
                    }
                    else
                    {
                        ErrorHandler.DisplayError(this, operationResult);
                    }
                }
            }
        }

        private void buttonInvite_Click(object sender, EventArgs args)
        {
            contextMenuStrip1.Show(buttonInvite.PointToScreen(new Point(0, buttonInvite.Height)));
        }
    }
}