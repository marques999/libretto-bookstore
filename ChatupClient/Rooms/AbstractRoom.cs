using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    abstract partial class AbstractRoom : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public AbstractRoom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Color> _users = new Dictionary<string, Color>();

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected void UserJoined(UserProfile userProfile)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new JoinHandler(JoinRoom), new object[]
                {
                    userProfile
                });
            }
            else
            {
                JoinRoom(userProfile);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        protected virtual void JoinRoom(UserProfile userProfile)
        {
            listBox1.Items.Add(userProfile.Username);
            _users.Add(userProfile.Username, userProfile.Color);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userProfile.Username, userProfile.Color);
            AppendText(" has joined the conversation." + "\n", Color.DimGray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected void UserLeft(string userName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new LeaveHandler(LeaveRoom), new object[]
                {
                    userName
                });
            }
            else
            {
                LeaveRoom(userName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected virtual void LeaveRoom(string userName)
        {
            if (listBox1.Items.Contains(userName))
            {
                listBox1.Items.Remove(userName);
            }

            if (_users.ContainsKey(userName))
            {
                AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
                AppendText(userName, _users[userName]);
                AppendText(" has left the conversation." + "\n", Color.DimGray);
                _users.Remove(userName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMessage"></param>
        /// <param name="clearInput"></param>
        protected void AppendMessage(RemoteMessage userMessage, bool clearInput)
        {
            if (userMessage.Author == ChatupClient.Instance.Username)
            {
                clearInput = true;
            }

            AppendText("(" + userMessage.Timestamp.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userMessage.Author + ": ", _users[userMessage.Author]);
            AppendText(userMessage.Contents + "\n", Color.Black);

            if (clearInput)
            {
                textBox2.Text = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMessage"></param>
        /// <param name="clearInput"></param>
        delegate void AppendHandler(RemoteMessage userMessage, bool clearInput);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        public void AppendMessage(RemoteMessage messageInstance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AppendHandler(AppendMessage), new object[]
                {
                    messageInstance, false
                });
            }
            else
            {
                AppendMessage(messageInstance, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RoomForm_Load(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected RemoteMessage GenerateMessage()
        {
            return new RemoteMessage(ChatupClient.Instance.Username, textBox2.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected abstract void buttonValidate_Click(object sender, EventArgs args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void textBox2_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
        }
    }
}