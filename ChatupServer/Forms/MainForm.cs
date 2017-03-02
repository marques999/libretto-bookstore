using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    public partial class MainForm : Form
    {
        private ServerStatus serverStatus = ServerStatus.Running;

        private enum ServerStatus
        {
            Stopped = 0,
            Running = 1,
            Restarting = 2,
            Failure = 3
        }

        private static string[] statusMessages =
        {
            "Stopped",
            "Running",
            "Restarting",
            "Failure"
        };

        private static Color[] statusColor =
        {
            Color.Black,
            Color.ForestGreen,
            Color.DarkOrange,
            Color.Red
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void UserJoined(string userName)
        {
            ListViewItem lvi = new ListViewItem();

            if (listView1.Items.ContainsKey(userName))
            {
                listView1.Items.RemoveByKey(userName);
            }

            lvi.Text = userName;
            lvi.SubItems.Add("Online");
            listView1.Items.Add(lvi);
        }

        private void UserLeft(string userName)
        {
            ListViewItem lvi = new ListViewItem();

            if (listView1.Items.ContainsKey(userName))
            {
                ListViewItem[] existingItem = listView1.Items.Find(userName, false);

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
                listView1.Items.Add(lvi);
            }
        }

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
                    buttonStart.Text = "Start";
                    buttonRestart.Enabled = false;
                    break;
                case ServerStatus.Running:
                    buttonStart.Text = "Stop";
                    buttonRestart.Enabled = true;
                    break;
                case ServerStatus.Restarting:
                    buttonStart.Text = "Restarting...";
                    buttonStart.Enabled = false;
                    buttonRestart.Enabled = false;
                    buttonExit.Enabled = false;
                    break;
            }

            serverStatus = nextStatus;
        }

        private void buttonStart_Click(object sender, EventArgs e)
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            ChangeStatus(ServerStatus.Restarting);
        }

        private void ChangeStatus(ServerStatus statusValue)
        {
            HandleChange(statusValue);
            labelStatus.ForeColor = statusColor[(int)serverStatus];
            labelStatus.Text = statusMessages[(int)serverStatus];
        }

        private void LoadUsers()
        {
            foreach (var userInfo in ChatupServer.Instance.Users)
            {
                listView1.Items.Add(userInfo);
            }
        }

        private void LoadRooms()
        {
            foreach (var roomInfo in ChatupServer.Instance.Rooms)
            {
                var roomInstance = roomInfo.Value;

                if (roomInstance != null)
                {
                    treeView1.Nodes.Add(
                        Convert.ToString(roomInfo.Key),
                        string.Format("{0} (0/{1})", roomInstance.Name, roomInstance.Capacity)
                    );
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs args)
        {
            LoadRooms();
            LoadUsers();
            UpdateAddress(new AddressObject(IPAddress.Loopback, 12480));
        }

        private AddressObject addressObject;

        private void UpdateAddress(AddressObject objectInstance)
        {
            addressObject = objectInstance;
            labelAddress.Text = addressObject.Address.ToString() + ":" + addressObject.Port;
        }

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