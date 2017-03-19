using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Rooms
{
    public abstract partial class AbstractRoom : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Color> mUsers = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="remoteHost"></param>
        public AbstractRoom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textContents"></param>
        /// <param name="textColor"></param>
        protected void AppendText(string textContents, Color textColor)
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
        protected virtual void UserJoined(UserProfile userProfile)
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
        protected virtual void UserLeft(string userName)
        {
            if (listBox1.Items.Contains(userName))
            {
                listBox1.Items.Remove(userName);
            }

            if (mUsers.ContainsKey(userName))
            {
                AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
                AppendText(userName, mUsers[userName]);
                AppendText(" has left the conversation." + "\n", Color.DimGray);
                mUsers.Remove(userName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        protected void AppendMessage(RemoteMessage messageInstance, bool clearInput)
        {
            AppendText("(" + messageInstance.Timestamp.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(messageInstance.Author + ": ", mUsers[messageInstance.Author]);
            AppendText(messageInstance.Contents + "\n", Color.Black);

            if (clearInput)
            {
                textBox2.Text = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        public void AppendMessage(RemoteMessage messageInstance)
        {
            AppendMessage(messageInstance, false);
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
        /// <param name="messageAuthor"></param>
        /// <param name="messageContents"></param>
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