using System;
using System.ComponentModel;
using System.Runtime.Remoting;

using ChatupNET.Model;
using ChatupNET.Remoting;
using System.Windows.Forms;

namespace ChatupNET.Rooms
{
    /// <summary>
    /// 
    /// </summary>
    public class PrivateRoom : AbstractRoom
    {
        private string mUsername;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteHost"></param>
        public PrivateRoom(string remoteHost) : base() // CLIENT MODE
        {
            try
            {
                messageInterface = (MessageInterface)RemotingServices.Connect(typeof(MessageInterface), remoteHost);
                InitializeRemote();
            }
            catch (Exception ex)
            {
                mConnected = false;
                ErrorHandler.DisplayException(this, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="remoteHost"></param>
        public PrivateRoom(UserProfile userProfile, string remoteHost) // SERVER MODE
        {
            try
            {
                messageInterface = (MessageInterface)RemotingServices.Connect(typeof(MessageInterface), remoteHost);
                InitializeRoom(userProfile);
            }
            catch (Exception ex)
            {
                mConnected = false;
                ErrorHandler.DisplayException(this, ex);
            }
        }

        private void InitializeRemote()
        {
            var operationResult = messageInterface.Connect(ChatupClient.Instance.Profile, ChatupClient.Instance.LocalAddress);

            if (operationResult == null)
            {
                return;
            }

            if (operationResult.Response == RemoteResponse.Success)
            {
                var userProfile = operationResult.Contents as UserProfile;

                if (userProfile != null)
                {
                    InitializeRoom(userProfile);
                }
                else
                {
                    ErrorHandler.DisplayError(this, RemoteResponse.BadRequest);
                }
            }
            else
            {
                ErrorHandler.DisplayError(this, operationResult.Response);
            }
        }

        private bool mConnected = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="remoteHost"></param>
        private void InitializeRoom(UserProfile userProfile)
        {
            mConnected = true;
            mUsername = userProfile.Username;
            UserJoined(ChatupClient.Instance.Profile);
            UserJoined(userProfile);
            Text = string.Format("{0} [PRIVATE]", mUsername);
        }

        /// <summary>
        /// 
        /// </summary>
        private MessageInterface messageInterface;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            if (mConnected && messageInterface != null)
            {
                var operationResult = messageInterface.Disconnect(ChatupClient.Instance.Username);

                if (operationResult == RemoteResponse.Success)
                {
                    ChatupClient.Instance.Disconnect(mUsername, true);
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void buttonValidate_Click(object sender, EventArgs args)
        {
            var remoteMessage = GenerateMessage();

            if (remoteMessage != null)
            {
                var operationResult = messageInterface.Send(remoteMessage);

                if (operationResult == RemoteResponse.Success)
                {
                    AppendMessage(remoteMessage, true);
                }
                else
                {
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }
        }

        internal void Disconnect()
        {
            mConnected = false;
        }
    }
}