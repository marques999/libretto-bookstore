using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private enum ServerStatus
        {
            Stopped = 0,
            Running = 1,
            Restarting = 2,
            Failure = 3
        }

        /// <summary>
        /// 
        /// </summary>
        private enum UserAction
        {
            Login,
            Logout,
            Register
        }

        /// <summary>
        /// 
        /// </summary>
        private static string[] statusMessages =
        {
            "Stopped",
            "Running",
            "Restarting",
            "Failure"
        };

        /// <summary>
        /// 
        /// </summary>
        private static Color[] statusColor =
        {
            Color.Black,
            Color.ForestGreen,
            Color.DarkOrange,
            Color.Red
        };

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ChatupServer.Instance.InitializeSession(OnLogin, OnLogout, OnRegister);
            ChatupServer.Instance.InitializeLobby(OnInsert, OnDelete);
            ChatupServer.Instance.InitializeRoom(OnJoin, OnLeave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userAction"></param>
        private delegate void UpsertHandler(UserInformation userInformation, UserAction userAction);

        /// <summary>
        /// 
        /// </summary>
        private ServerStatus serverStatus = ServerStatus.Running;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogin(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpsertHandler(UpsertUser), new object[]
                {
                    userInformation, UserAction.Login
                });
            }
            else
            {
                UpsertUser(userInformation, UserAction.Login);
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
                BeginInvoke(new UpsertHandler(UpsertUser), new object[]
                {
                    userInformation, UserAction.Logout
                });
            }
            else
            {
                UpsertUser(userInformation, UserAction.Logout);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnRegister(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpsertHandler(UpsertUser), new object[]
                {
                    userInformation, UserAction.Register
                });
            }
            else
            {
                UpsertUser(userInformation, UserAction.Register);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void OnInsert(Room roomInformation)
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
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void OnJoin(Room roomInformation, string userName, string fullName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(JoinRoom), new object[]
                {
                    roomInformation, userName, fullName
                });
            }
            else
            {
                JoinRoom(roomInformation, userName, fullName);
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void OnLeave(Room roomInformation, string userName, string fullName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(LeaveRoom), new object[]
                {
                    roomInformation, userName, fullName
                });
            }
            else
            {
                LeaveRoom(roomInformation, userName, fullName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void JoinRoom(Room roomInformation, string userName, string fullName)
        {
            AppendTime();
            AppendText(fullName, colorBlue);
            AppendText(" (" + userName + ") ", colorYellow);
            AppendText("has joined chatroom ", colorDefault);
            AppendText(roomInformation.Name, colorBlue);
            AppendText(" (id=" + roomInformation.ID + ")\n", colorYellow);

            int nodeIndex = treeView1.Nodes.IndexOfKey(Convert.ToString(roomInformation.ID));

            if (nodeIndex >= 0)
            {
                var nodeItem = treeView1.Nodes[nodeIndex];

                if (nodeItem != null)
                {
                    InsertNode(nodeItem, userName);
                    nodeItem.Text = FormatRoom(roomInformation);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void LeaveRoom(Room roomInformation, string userName, string fullName)
        {
            AppendTime();
            AppendText(fullName, colorBlue);
            AppendText(" (" + userName + ") ", colorYellow);
            AppendText("has left chatroom ", colorDefault);
            AppendText(roomInformation.Name, colorBlue);
            AppendText(" (id=" + roomInformation.ID + ")\n", colorYellow);

            int nodeIndex = treeView1.Nodes.IndexOfKey(Convert.ToString(roomInformation.ID));

            if (nodeIndex >= 0)
            {
                var nodeItem = treeView1.Nodes[nodeIndex];

                if (nodeItem != null)
                {
                    RemoveNode(nodeItem, userName);
                    nodeItem.Text = FormatRoom(roomInformation);
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeItem"></param>
        /// <param name="userName"></param>
        private void InsertNode(TreeNode nodeItem, string userName)
        {
            if (nodeItem != null && nodeItem.Nodes != null)
            {
                if (!nodeItem.Nodes.ContainsKey(userName))
                {
                    nodeItem.Nodes.Add(userName, userName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeItem"></param>
        /// <param name="userName"></param>
        private void RemoveNode(TreeNode nodeItem, string userName)
        {
            if (nodeItem != null && nodeItem.Nodes != null)
            {
                if (nodeItem.Nodes.ContainsKey(userName))
                {
                    nodeItem.Nodes.RemoveByKey(userName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void InsertRoom(Room roomInformation)
        {
            treeView1.Nodes.Add(
                Convert.ToString(roomInformation.ID),
                FormatRoom(roomInformation)
            );

            AppendTime();
            AppendText(ChatupServer.Instance.Users[roomInformation.Owner].Name, colorBlue);
            AppendText(" (" + roomInformation.Owner + ") ", colorYellow);
            AppendText("has created chatroom ", colorDefault);
            AppendText(roomInformation.Name, colorBlue);
            AppendText(" (id=" + roomInformation.ID + ")\n", colorYellow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void DeleteRoom(int roomId)
        {
            var _roomId = Convert.ToString(roomId);

            if (treeView1.Nodes.ContainsKey(_roomId))
            {
                treeView1.Nodes.RemoveByKey(_roomId);
            }

            if (ChatupServer.Instance.Rooms.ContainsKey(roomId))
            {
                var roomInformation = ChatupServer.Instance.Rooms[roomId];

                if (roomInformation != null)
                {
                    AppendTime();
                    AppendText(ChatupServer.Instance.Rooms[roomId].Name, colorBlue);
                    AppendText(" (id=" + roomId + ") ", colorYellow);
                    AppendText("was deleted by owner request.\n", colorDefault);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userAction"></param>
        private void LogUser(UserInformation userInformation, UserAction userAction)
        {
            AppendTime();
            AppendText(userInformation.Name, colorBlue);
            AppendText(" (" + userInformation.Username + ") ", colorYellow);

            if (userAction == UserAction.Login)
            {
                AppendText("has connected.\n", colorDefault);
            }
            else if (userAction == UserAction.Logout)
            {
                AppendText("has terminated session.\n", colorDefault);
            }
            else
            {
                AppendText("account registered.\n", colorDefault);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userAction"></param>
        private void UpsertUser(UserInformation userInformation, UserAction userAction)
        {
            if (listView1.Items.ContainsKey(userInformation.Username))
            {
                listView1.Items.RemoveByKey(userInformation.Username);
            }

            var userStatus = Properties.Resources.user_Offline;

            if (userAction == UserAction.Login)
            {
                activeUsers++;
                userStatus = Properties.Resources.user_Active;
            }
            else if (userAction == UserAction.Logout)
            {
                activeUsers--;
            }

            var lvi = new ListViewItem(new string[]
            {
                userInformation.Username,
                userAction == UserAction.Login ? userInformation.Host : "Offline"
            });

            lvi.Name = userInformation.Username;
            listView1.Items.Insert(0, lvi);
            LogUser(userInformation, userAction);
            UpdateStats();
        }

        /// <summary>
        /// 
        /// </summary>
        private void AppendTime()
        {
            AppendText("[" + DateTime.Now.ToLongTimeString() + "] ", colorGreen);
        }

        /// <summary>
        /// 
        /// </summary>
        private int activeUsers = 0;

        /// <summary>
        /// 
        /// </summary>
        private void UpdateStats()
        {
            labelStats.Text = string.Format(Properties.Resources.label_Stats, activeUsers, listView1.Items.Count - activeUsers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextStatus"></param>
        private void HandleChange(ServerStatus nextStatus)
        {
            if (serverStatus == nextStatus)
            {
                return;
            }

            switch (serverStatus)
            {
                case ServerStatus.Restarting:
                    buttonStart.Enabled = true;
                    buttonRestart.Enabled = true;
                    buttonExit.Enabled = true;
                    break;
            }

            switch (nextStatus)
            {
                case ServerStatus.Stopped:
                    buttonStart.Text = Properties.Resources.status_Start;
                    buttonRestart.Enabled = false;
                    break;
                case ServerStatus.Running:
                    buttonStart.Text = Properties.Resources.status_Stopped;
                    buttonRestart.Enabled = true;
                    break;
                case ServerStatus.Restarting:
                    buttonStart.Text = Properties.Resources.status_Restarting;
                    buttonStart.Enabled = false;
                    buttonRestart.Enabled = false;
                    buttonExit.Enabled = false;
                    break;
            }

            LogStatus(nextStatus);
            serverStatus = nextStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverStatus"></param>
        private void LogStatus(ServerStatus serverStatus)
        {
            AppendTime();
            AppendText("ChatupServer ", colorYellow);

            switch (serverStatus)
            {
                case ServerStatus.Stopped:
                    AppendText("stopped as requested by the user.\n", colorDefault);
                    break;
                case ServerStatus.Running:
                    AppendText("running at ", colorDefault);
                    AppendText(labelAddress.Text, colorBlue);
                    AppendText("...\n", colorDefault);
                    break;
                case ServerStatus.Restarting:
                    AppendText("restarting...\n", colorDefault);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonStart_Click(object sender, EventArgs args)
        {
            if (serverStatus == ServerStatus.Stopped)
            {
                ChangeStatus(ServerStatus.Running);
            }
            else if (serverStatus == ServerStatus.Running)
            {
                ChangeStatus(ServerStatus.Stopped);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonExit_Click(object sender, EventArgs args)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonRestart_Click(object sender, EventArgs args)
        {
            ChangeStatus(ServerStatus.Restarting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusValue"></param>
        private void ChangeStatus(ServerStatus statusValue)
        {
            HandleChange(statusValue);
            labelStatus.ForeColor = statusColor[(int)serverStatus];
            labelStatus.Text = statusMessages[(int)serverStatus];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            ChatupServer.Instance.DestroyLobby(OnInsert, OnDelete);
            ChatupServer.Instance.DestroySession(OnLogin, OnLogout, OnRegister);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        private string FormatRoom(Room roomInstance)
        {
            return string.Format("{0} ({1:D}/{2:D})", roomInstance.Name, roomInstance.Count, roomInstance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        private Color colorPink = Color.FromArgb(249, 38, 114);
        private Color colorGreen = Color.FromArgb(166, 226, 46);
        private Color colorBlue = Color.FromArgb(102, 217, 239);
        private Color colorYellow = Color.FromArgb(244, 191, 117);
        private Color colorDefault = Color.FromArgb(248, 248, 242);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageContent"></param>
        /// <param name="messageColor"></param>
        protected void AppendText(string messageContent, Color messageColor)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = messageColor;
            richTextBox1.AppendText(messageContent);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
            richTextBox1.ScrollToCaret();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainForm_Load(object sender, EventArgs args)
        {
            var userList = ChatupServer.Instance.Users;

            if (userList.Count > 0)
            {
                foreach (var userInformation in userList)
                {
                    UpsertUser(userInformation.Value, UserAction.Register);
                }
            }

            var roomList = ChatupServer.Instance.Rooms;

            if (roomList.Count > 0)
            {
                foreach (var roomInfo in roomList)
                {
                    InsertRoom(roomInfo.Value);
                }
            }

            UpdateStats();
            UpdateAddress(new Address(IPAddress.Loopback, 12480));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInstance"></param>
        private void UpdateAddress(Address objectInstance)
        {
            labelAddress.Text = objectInstance.Host.ToString() + ":" + objectInstance.Port;
            LogStatus(ServerStatus.Running);
        }
    }
}