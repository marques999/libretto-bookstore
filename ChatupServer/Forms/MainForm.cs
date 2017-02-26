using System;
using System.Windows.Forms;

using ChatupNET.Remoting;
using System.Drawing;

namespace ChatupNET.Forms
{
    public partial class MainForm : Form
    {
        private ServerStatus serverStatus = 0;

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
            MessageBox.Show("UserJoined");
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

        private SessionService remoteSession;

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
    }
}