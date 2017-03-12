using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting;

using ChatupNET.Remoting;
using ChatupNET.Model;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    public delegate void ExitHandler(int rooomId);

    /// <summary>
    /// 
    /// </summary>
    public partial class GroupRoom : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Room mInstance;

        /// <summary>
        /// 
        /// </summary>
        private int mId;

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Color> mUsers;

        /// <summary>
        /// 
        /// </summary>
        private RoomIntermediate mIntermediate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="remoteHost"></param>
        public GroupRoom(int roomId, Room roomInformation, string remoteHost)
        {
            InitializeComponent();
            mId = roomId;
            mInstance = roomInformation;
            mUsers = new Dictionary<string, Color>();
            mIntermediate = new RoomIntermediate();
            mIntermediate.OnJoin += UserJoined;
            mIntermediate.OnLeave += UserLeft;
            mIntermediate.OnMessage += AppendMessage;
            roomInterface = (RoomInterface)RemotingServices.Connect(typeof(RoomInterface), remoteHost);
            roomInterface.OnJoin += mIntermediate.JoinRoom;
            roomInterface.OnLeave += mIntermediate.LeaveRoom;
            roomInterface.OnSend += mIntermediate.SendMessage;
            UserJoined(ChatupClient.Instance.Profile);

            /*var userList = roomInterface.List();

            if (mUsers.Count > 0)
            {
                foreach (var userEntry in userList)
                {
                    UserJoined(new UserProfile(userEntry.Key, userEntry.Value));
                }
            }*/
        }

        /// <summary>
        /// 
        /// </summary>
        private RoomInterface roomInterface;

        /// <summary>
        /// 
        /// </summary>
        public event ExitHandler ExitHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            mIntermediate.OnJoin -= UserJoined;
            mIntermediate.OnLeave -= UserLeft;
            mIntermediate.OnMessage -= AppendMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textContents"></param>
        /// <param name="textColor"></param>
        private void AppendText(string textContents, Color textColor)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = textColor;
            richTextBox1.AppendText(textContents);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        private void UserJoined(UserProfile userProfile)
        {
            listBox1.Items.Add(userProfile.Username);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userProfile.Username, userProfile.Color);
            AppendText(" has joined the conversation." + "\n", Color.DimGray);
            mUsers.Add(userProfile.Username, userProfile.Color);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        private void UserLeft(string userName)
        {
            listBox1.Items.Remove(userName);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, mUsers[userName]);
            AppendText(" has left the conversation." + "\n", Color.DimGray);
            mUsers.Remove(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        public void AppendMessage(RemoteMessage messageInstance)
        {
            AppendText("(" + messageInstance.Timestamp.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(messageInstance.Author + ": ", mUsers[messageInstance.Author]);
            AppendText(messageInstance.Contents + "\n", Color.Black);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RoomForm_Load(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
            Text = string.Format("{0} [{1}/{2}]", mInstance.Name, mInstance.Count, mInstance.GetCapacity());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonValidate_Click(object sender, EventArgs args)
        {
            AppendMessage(new RemoteMessage("marques999", textBox2.Text));
            textBox2.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void textBox2_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RoomForm_FormClosing(object sender, FormClosingEventArgs args)
        {
            ExitHandler?.Invoke(mId);
        }
    }
}