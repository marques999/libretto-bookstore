using System;
using System.ComponentModel;
using System.Windows.Forms;

using ChatupNET.Remoting;
using ChatupNET.Model;

namespace ChatupNET.Rooms
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    delegate void ExitHandler(Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    class GroupRoom : AbstractRoom
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="remoteHost"></param>
        public GroupRoom(Room roomInformation, RoomInterface roomInterface, MessageQueue messageHistory) : base()
        {
            _server = roomInterface;
            _instance = roomInformation;
            _proxy = new RoomIntermediate();
            _proxy.OnJoin += UserJoined;
            _proxy.OnLeave += UserLeft;
            _proxy.OnMessage += AppendMessage;
            _server.OnJoin += _proxy.JoinRoom;
            _server.OnLeave += _proxy.LeaveRoom;
            _server.OnSend += _proxy.SendMessage;

            var userList = roomInterface.List();

            if (userList.Count > 0)
            {
                foreach (var userEntry in userList)
                {
                    JoinRoom(new UserProfile(userEntry.Key, userEntry.Value));
                }
            }

            var q = messageHistory.Dequeue();

            while (q != null)
            {
                AppendMessage(q);
                q = messageHistory.Dequeue();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        protected override void JoinRoom(UserProfile userProfile)
        {
            base.JoinRoom(userProfile);
            _instance.Count++;
            Text = string.Format("{0} [{1:D}/{2:D}]", _instance.Name, _instance.Count, _instance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected override void LeaveRoom(string userName)
        {
            base.LeaveRoom(userName);
            _instance.Count--;
            Text = string.Format("{0} [{1:D}/{2:D}]", _instance.Name, _instance.Count, _instance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        private Room _instance;

        /// <summary>
        /// 
        /// </summary>
        private RoomInterface _server;

        /// <summary>
        /// 
        /// </summary>
        private RoomIntermediate _proxy;

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
            _proxy.OnLeave -= LeaveRoom;
            _proxy.OnJoin -= JoinRoom;
            _proxy.OnMessage -= AppendMessage;

            if (_server != null)
            {
                var operationResult = _server.Leave(ChatupClient.Instance.Username);

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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void buttonValidate_Click(object sender, EventArgs args)
        {
            var remoteMessage = GenerateMessage();

            if (remoteMessage != null)
            {
                var operationResult = _server.Send(remoteMessage);

                if (operationResult != RemoteResponse.Success)
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
        private void RoomForm_FormClosing(object sender, FormClosingEventArgs args)
        {
            ExitHandler?.Invoke(_instance);
        }
    }
}