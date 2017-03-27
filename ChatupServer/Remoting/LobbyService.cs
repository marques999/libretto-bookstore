using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    /// <param name="userName"></param>
    /// <param name="fullName"></param>
    delegate void RoomHandler(Room roomInformation, string userName, string fullName);

    /// <summary>
    /// 
    /// </summary>
    class LobbyService : MarshalByRefObject, LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public event InsertHandler OnInsert;

        /// <summary>
        /// 
        /// </summary>
        public event DeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, Room> Rooms
        {
            get
            {
                return ChatupServer.Instance.Rooms;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Room> List()
        {
            return ChatupServer.Instance.Rooms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public RemoteResponse Delete(int roomId, string userName)
        {
            if (string.IsNullOrEmpty(userName) || roomId < 1)
            {
                return RemoteResponse.BadRequest;
            }

            if (!Rooms.ContainsKey(roomId))
            {
                return RemoteResponse.NotFound;
            }

            if (Rooms[roomId].Owner == userName)
            {
                if (Rooms.Remove(roomId))
                {
                    if (SqliteDatabase.Instance.DeleteRoom(roomId, userName))
                    {
                        OnDelete?.Invoke(roomId);
                        ChatupServer.Instance.Lobby.DeleteRoom(roomId);
                    }
                }
                else
                {
                    return RemoteResponse.OperationFailed;
                }
            }
            else
            {
                return RemoteResponse.PermissionDenied;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        public Tuple<RemoteResponse, Room> Insert(Room roomInformation)
        {
            if (roomInformation == null)
            {
                return new Tuple<RemoteResponse, Room>(RemoteResponse.BadRequest, null);
            }

            if (string.IsNullOrEmpty(roomInformation.Owner))
            {
                return new Tuple<RemoteResponse, Room>(RemoteResponse.BadRequest, null);
            }

            if (string.IsNullOrEmpty(roomInformation.Name))
            {
                return new Tuple<RemoteResponse, Room>(RemoteResponse.BadRequest, null);
            }

            roomInformation.ID = ChatupServer.Instance.NextID;

            if (ChatupServer.Instance.RegisterChatrooom(roomInformation))
            {
                OnInsert?.Invoke(roomInformation);
            }
            else
            {
                return new Tuple<RemoteResponse, Room>(RemoteResponse.OperationFailed, null);
            }

            return new Tuple<RemoteResponse, Room>(RemoteResponse.Success, roomInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public Tuple<bool, string> QueryRoom(int roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                return new Tuple<bool, string>(Rooms[roomId].IsPrivate(), ChatupServer.Instance.LookupChatroom(roomId));
            }
            else
            {
                return new Tuple<bool, string>(false, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}