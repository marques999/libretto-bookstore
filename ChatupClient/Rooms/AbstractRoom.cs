using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract partial class AbstractRoom : Form
    {
        /// <summary>
        /// 
        /// </summary>
        protected AbstractRoom()
        {
            InitializeComponent();
            ErrorHandler = new ErrorHandler(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, Color> Users
        {
            get;
        } = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        protected ErrorHandler ErrorHandler;

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
        /// <param name="userProfile"></param>
        protected void OnJoin(Tuple<string, Color> userProfile)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new JoinHandler(JoinRoom), userProfile);
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
        protected void JoinRoom(Tuple<string, Color> userProfile)
        {
            listBox1.Items.Add(userProfile.Item1);
            Users.Add(userProfile.Item1, userProfile.Item2);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userProfile.Item1, userProfile.Item2);
            AppendText(" has joined the conversation." + "\n", Color.DimGray);
            UpdateRoom();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected void OnLeave(string userName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new LeaveHandler(LeaveRoom), userName);
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
        protected void LeaveRoom(string userName)
        {
            if (listBox1.Items.Contains(userName))
            {
                listBox1.Items.Remove(userName);
            }

            if (Users.ContainsKey(userName))
            {
                Users.Remove(userName);
            }

            UpdateRoom();
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, Users[userName]);
            AppendText(" has left the conversation." + "\n", Color.DimGray);
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
            AppendText(userMessage.Author + ": ", Users[userMessage.Author]);
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
                BeginInvoke(new AppendHandler(AppendMessage), messageInstance, false);
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
        protected abstract void UpdateRoom();

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