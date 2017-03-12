using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PrivateRoom : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUser"></param>
        /// <param name="destinationUser"></param>
        /// <param name="remoteHost"></param>
        public PrivateRoom(UserProfile sourceUser, UserProfile destinationUser, Address remoteHost)
        {
            InitializeComponent();

            messageInterface = (MessageInterface)RemotingServices.Connect(
                typeof(MessageInterface),
                string.Format(uriFormat, remoteHost.Host, remoteHost.Port)
            );

            if (destinationUser == null)
            {
                destinationUser = messageInterface.Profile();
            }

            var operationResult = messageInterface.Connect(sourceUser, ChatupClient.Instance.Host);

            mUsername = sourceUser.Username;
            Text = string.Format("{0} [PRIVATE]", destinationUser.Username);

            if (operationResult != RemoteResponse.Success)
            {
                ErrorHandler.DisplayError(this, operationResult);
                Close();
            }

            UserJoined(sourceUser.Username, sourceUser.Color);
            UserJoined(destinationUser.Username, destinationUser.Color);
        }

        /// <summary>
        /// 
        /// </summary>
        private string mUsername;

        /// <summary>
        /// 
        /// </summary>
        private MessageInterface messageInterface;

        /// <summary>
        /// 
        /// </summary>
        private string uriFormat = "tcp://{0}:{1:D}/messaging.rem";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            if (messageInterface != null)
            {
                var operationResult = messageInterface.Disconnect(mUsername);

                if (operationResult == RemoteResponse.Success)
                {
                    base.OnClosing(args);
                }
                else
                {
                    args.Cancel = true;
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }
            else
            {
                base.OnClosing(args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Color> mUsers = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageContents"></param>
        /// <param name="messageColor"></param>
        private void AppendText(string messageContents, Color messageColor)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = messageColor;
            richTextBox1.AppendText(messageContents);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        private void UserJoined(string userName, Color userColor)
        {
            listBox1.Items.Add(userName);
            mUsers.Add(userName, userColor);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, userColor);
            AppendText(" has joined the conversation." + "\n", Color.DimGray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void AppendMessage(RemoteMessage remoteMessage)
        {
            AppendText("(" + remoteMessage.Timestamp.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(remoteMessage.Author + ": ", mUsers[remoteMessage.Author]);
            AppendText(remoteMessage.Contents + "\n", Color.Black);
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonValidate_Click(object sender, EventArgs args)
        {
            var remoteMessage = new RemoteMessage(mUsername, textBox2.Text);

            if (remoteMessage != null)
            {
                var operationResult = messageInterface.Send(remoteMessage);

                if (operationResult == RemoteResponse.Success)
                {
                    textBox2.Text = "";
                    AppendMessage(remoteMessage);
                }
                else
                {
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }
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
    }
}