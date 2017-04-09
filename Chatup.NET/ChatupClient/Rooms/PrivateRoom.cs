using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    /// <summary>
    ///
    /// </summary>
    internal class PrivateRoom : AbstractRoom
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="remoteHost"></param>
        public PrivateRoom(string remoteHost)
        {
            try
            {
                _server = (MessageInterface)RemotingServices.Connect(typeof(MessageInterface), remoteHost);
                InitializeRemote();
            }
            catch (Exception ex)
            {
                _connected = false;
                ErrorHandler.DisplayException(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="remoteHost"></param>
        public PrivateRoom(UserProfile userProfile, string remoteHost)
        {
            try
            {
                _server = (MessageInterface)RemotingServices.Connect(typeof(MessageInterface), remoteHost);
                InitializeRoom(userProfile);
            }
            catch (Exception ex)
            {
                _connected = false;
                ErrorHandler.DisplayException(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        private string _username;

        /// <summary>
        ///
        /// </summary>
        private bool _connected;

        /// <summary>
        ///
        /// </summary>
        private readonly MessageInterface _server;

        /// <summary>
        ///
        /// </summary>
        private void InitializeRemote()
        {
            var operationResult = _server.Connect(ChatupClient.Instance.Profile, ChatupClient.Instance.LocalAddress);

            if (operationResult == null)
            {
                return;
            }

            if (operationResult.Item1 == RemoteResponse.Success)
            {
                if (operationResult.Item2 != null)
                {
                    InitializeRoom(operationResult.Item2);
                }
                else
                {
                    ErrorHandler.DisplayError(RemoteResponse.BadRequest);
                }
            }
            else
            {
                ErrorHandler.DisplayError(operationResult.Item1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userProfile"></param>
        private void InitializeRoom(UserProfile userProfile)
        {
            _connected = true;
            _username = userProfile.Username;
            JoinRoom(ChatupClient.Instance.Profile);
            JoinRoom(userProfile);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void AbstractRoom_FormClosing(object sender, FormClosingEventArgs args)
        {
            if (!_connected || _server == null)
            {
                return;
            }

            var operationResult = _server.Disconnect(ChatupClient.Instance.Username);

            if (operationResult == RemoteResponse.Success)
            {
                ChatupClient.Instance.Messaging.P2PDisconnect(_username, true);
            }
            else
            {
                args.Cancel = true;
                ErrorHandler.DisplayError(operationResult);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void ButtonValidate_Click(object sender, EventArgs args)
        {
            var remoteMessage = GenerateMessage();
            var operationResult = _server.Send(remoteMessage);

            if (operationResult == RemoteResponse.Success)
            {
                AppendMessage(remoteMessage, true);
            }
            else
            {
                ErrorHandler.DisplayError(operationResult);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Disconnect()
        {
            _connected = false;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void UpdateRoom()
        {
            Text = $@"{_username} [PRIVATE]";
        }
    }
}