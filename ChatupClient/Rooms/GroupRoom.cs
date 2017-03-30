using System;
using System.Windows.Forms;

using ChatupNET.Remoting;
using ChatupNET.Model;

namespace ChatupNET.Rooms
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    internal delegate void ExitHandler(Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    internal sealed class GroupRoom : AbstractRoom
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="roomInterface"></param>
        /// <param name="messageHistory"></param>
        public GroupRoom(Room roomInformation, RoomInterface roomInterface, MessageQueue messageHistory)
        {
            _instance = roomInformation;
            _roomInterface = roomInterface;
            _roomIntermediate = new RoomIntermediate();
            _roomIntermediate.OnJoin += OnJoin;
            _roomIntermediate.OnLeave += OnLeave;
            _roomIntermediate.OnSend += OnReceive;
            _roomInterface.OnJoin += _roomIntermediate.JoinRoom;
            _roomInterface.OnLeave += _roomIntermediate.LeaveRoom;
            _roomInterface.OnSend += _roomIntermediate.SendMessage;

            if (messageHistory != null)
            {
                RemoteMessage q;

                while (messageHistory.TryDequeue(out q))
                {
                    OnReceive(q);
                }
            }

            var userList = roomInterface.List();

            if (userList.Count <= 0)
            {
                return;
            }

            foreach (var userEntry in userList)
            {
                JoinRoom(new UserProfile(userEntry.Key, userEntry.Value));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ExitHandler OnExit;

        /// <summary>
        /// 
        /// </summary>
        public event UpdateHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        private readonly Room _instance;

        /// <summary>
        /// 
        /// </summary>
        private readonly RoomInterface _roomInterface;

        /// <summary>
        /// 
        /// </summary>
        private readonly RoomIntermediate _roomIntermediate;

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateRoom()
        {
            OnUpdate?.Invoke(_instance.Id, Users.Count, _instance.Capacity);
            Text = $@"{_instance.Name} [{Users.Count:D}/{_instance.Capacity:D}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void AbstractRoom_FormClosing(object sender, FormClosingEventArgs args)
        {
            if (_roomInterface != null)
            {
                var operationResult = _roomInterface.Leave(ChatupClient.Instance.Username);

                if (operationResult == RemoteResponse.Success)
                {
                    OnDisconnect();
                }
                else
                {
                    args.Cancel = true;
                    ErrorHandler.DisplayError(operationResult);
                }
            }
            else
            {
                OnDisconnect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDisconnect()
        {
            _roomInterface.OnJoin -= _roomIntermediate.JoinRoom;
            _roomInterface.OnLeave -= _roomIntermediate.LeaveRoom;
            _roomInterface.OnSend -= _roomIntermediate.SendMessage;
            OnExit?.Invoke(_instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void buttonValidate_Click(object sender, EventArgs args)
        {
            var operationResult = _roomInterface.Send(GenerateMessage());

            if (operationResult != RemoteResponse.Success)
            {
                ErrorHandler.DisplayError(operationResult);
            }
        }
    }
}