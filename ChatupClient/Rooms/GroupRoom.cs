using System;
using System.ComponentModel;
using System.Drawing;

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
    /// <param name="roomId"></param>
    /// <param name="roomCount"></param>
    /// <param name="roomCapacity"></param>
    internal delegate void UpdateHandler(int roomId, int roomCount, int roomCapacity);

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
            _roomIntermediate.OnJoin += OnJoin;
            _roomIntermediate.OnLeave += OnLeave;
            _roomIntermediate.OnMessage += AppendMessage;
            _roomInterface.OnJoin += _roomIntermediate.JoinRoom;
            _roomInterface.OnLeave += _roomIntermediate.LeaveRoom;
            _roomInterface.OnSend += _roomIntermediate.SendMessage;

            var userList = roomInterface.List();

            if (userList.Count > 0)
            {
                foreach (var userEntry in userList)
                {
                    JoinRoom(new Tuple<string, Color>(userEntry.Key, userEntry.Value));
                }
            }

            if (messageHistory == null)
            {
                return;
            }

            RemoteMessage q;

            while (messageHistory.TryDequeue(out q))
            {
                AppendMessage(q);
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
        private readonly RoomIntermediate _roomIntermediate = new RoomIntermediate();

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
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            _roomIntermediate.OnLeave -= LeaveRoom;
            _roomIntermediate.OnJoin -= JoinRoom;
            _roomIntermediate.OnMessage -= AppendMessage;
            OnExit?.Invoke(_instance);

            if (_roomInterface != null)
            {
                var operationResult = _roomInterface.Leave(ChatupClient.Instance.Username);

                if (operationResult == RemoteResponse.Success)
                {
                    base.OnClosing(args);
                }
                else
                {
                    args.Cancel = true;
                    ErrorHandler.DisplayError(operationResult);
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
            var operationResult = _roomInterface.Send(GenerateMessage());

            if (operationResult != RemoteResponse.Success)
            {
                ErrorHandler.DisplayError(operationResult);
            }
        }
    }
}