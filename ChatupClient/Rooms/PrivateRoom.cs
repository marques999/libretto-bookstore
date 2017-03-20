﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    class PrivateRoom : AbstractRoom
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
                ErrorHandler.DisplayException(this, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="remoteHost"></param>
        public PrivateRoom(Tuple<string, Color> userProfile, string remoteHost)
        {
            try
            {
                _server = (MessageInterface)RemotingServices.Connect(typeof(MessageInterface), remoteHost);
                InitializeRoom(userProfile);
            }
            catch (Exception ex)
            {
                _connected = false;
                ErrorHandler.DisplayException(this, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _username;

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
                    ErrorHandler.DisplayError(this, RemoteResponse.BadRequest);
                }
            }
            else
            {
                ErrorHandler.DisplayError(this, operationResult.Item1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool _connected = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        private void InitializeRoom(Tuple<string, Color> userProfile)
        {
            _connected = true;
            _username = userProfile.Item1;
            JoinRoom(ChatupClient.Instance.Profile);
            JoinRoom(userProfile);
            Text = string.Format("{0} [PRIVATE]", _username);
        }

        /// <summary>
        /// 
        /// </summary>
        private MessageInterface _server;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            if (_connected && _server != null)
            {
                var operationResult = _server.Disconnect(ChatupClient.Instance.Username);

                if (operationResult == RemoteResponse.Success)
                {
                    ChatupClient.Instance.Messaging.p2pDisconnect(_username, true);
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
                var operationResult = _server.Send(remoteMessage);

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

        /// <summary>
        /// 
        /// </summary>
        public void Disconnect()
        {
            _connected = false;
        }
    }
}