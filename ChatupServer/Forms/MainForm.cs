using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    enum UserAction
    {
        Login,
        Logout,
        Register
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userInformation"></param>
    /// <param name="userAction"></param>
    delegate void UpsertHandler(UserInformation userInformation, UserAction userAction);

    /// <summary>
    /// 
    /// </summary>
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
        /// <param name="roomId"></param>
        /// <param name="roomInformation"></param>
        private void OnInsert(Room roomInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(InsertRoom), new object[]
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
        /// <param name="roomId"></param>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        private void OnUpdate(Room roomInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(UpdateRoom), new object[]
                {
                    roomInformation
                });
            }
            else
            {
                UpdateRoom(roomInformation);
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ChatupServer.Instance.InitializeSession(OnLogin, OnLogout, OnRegister);
            ChatupServer.Instance.InitializeLobby(OnInsert, OnDelete, OnUpdate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomInformation"></param>
        private void InsertRoom(Room roomInformation)
        {
            treeView1.Nodes.Add(
                Convert.ToString(roomInformation.ID),
                FormatCapacity(roomInformation)
            );
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomExit"></param>
        private void UpdateRoom(Room roomInformation)
        {
            var _roomId = Convert.ToString(roomInformation.ID);
            var nodeIndex = treeView1.Nodes.IndexOfKey(_roomId);

            if (nodeIndex >= 0)
            {
                var nodeItem = treeView1.Nodes[nodeIndex];

                if (nodeItem != null)
                {
                    nodeItem.Nodes.RemoveAt(0);
                    nodeItem.Nodes.Insert(0, FormatCapacity(roomInformation));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userStatus"></param>
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
            UpdateStats();
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

            serverStatus = nextStatus;
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
        private void LoadUsers()
        {
            foreach (var userInformation in ChatupServer.Instance.Users)
            {
                UpsertUser(userInformation.Value, UserAction.Register);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadRooms()
        {
            foreach (var roomInfo in ChatupServer.Instance.Rooms)
            {
                var roomInstance = roomInfo.Value;

                if (roomInstance != null)
                {

                }
            }
        }

        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            ChatupServer.Instance.DestroyLobby(OnInsert, OnDelete, OnUpdate);
            ChatupServer.Instance.DestroySession(OnLogin, OnLogout, OnRegister);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        private string FormatCapacity(Room roomInstance)
        {
            return string.Format("{0} ({1}/{2})", roomInstance.Name, roomInstance.Count, roomInstance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainForm_Load(object sender, EventArgs args)
        {
            LoadRooms();
            LoadUsers();
            UpdateAddress(new Address(IPAddress.Loopback, 12480));
            UpdateStats();
        }

        /// <summary>
        /// 
        /// </summary>
        private Address addressObject;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInstance"></param>
        private void UpdateAddress(Address objectInstance)
        {
            addressObject = objectInstance;
            labelAddress.Text = addressObject.Host.ToString() + ":" + addressObject.Port;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonAddress_click(object sender, EventArgs args)
        {
            var addressForm = new AddressForm(addressObject);

            if (addressForm.ShowDialog() == DialogResult.OK)
            {
                UpdateAddress(addressForm.ModalData);
            }
        }
    }
}