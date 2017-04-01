using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="roomInformation"></param>
    /// <param name="userProfile"></param>
    /// <param name="fullName"></param>
    internal delegate void RoomHandler(Room roomInformation, UserProfile userProfile, string fullName);

    /// <summary>
    ///
    /// </summary>
    internal class LobbyService : MarshalByRefObject, LobbyInterface
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
        public event UpdateHandler OnUpdate;

        /// <summary>
        ///
        /// </summary>
        public Dictionary<int, Room> Rooms => ChatupServer.Instance.Rooms;

        /// <summary>
        ///
        /// </summary>
        private LobbyService()
        {
            ChatupServer.Instance.InitializeUpdates(UpdateRoom);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        public void UpdateRoom(int roomId, int roomCount, int roomCapacity)
        {
            OnUpdate?.Invoke(roomId, roomCount, roomCapacity);
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

            var roomInformation = Rooms[roomId];

            if (roomInformation.Count > 0)
            {
                return RemoteResponse.NotEmpty;
            }

            if (roomInformation.Owner == userName)
            {
                if (SqliteDatabase.Instance.DeleteRoom(roomId, userName))
                {
                    OnDelete?.Invoke(roomId);
                    ChatupServer.Instance.Lobby.DeleteRoom(roomId);
                    Rooms.Remove(roomId);
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

            roomInformation.Id = ChatupServer.Instance.NextId;

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
        /// <param name="roomPassword"></param>
        /// <returns></returns>
        public Tuple<RemoteResponse, string> Join(int roomId, string roomPassword)
        {
            if (Rooms.ContainsKey(roomId) == false)
            {
                return new Tuple<RemoteResponse, string>(RemoteResponse.NotFound, null);
            }

            var roomInformation = Rooms[roomId];

            if (roomInformation == null)
            {
                return new Tuple<RemoteResponse, string>(RemoteResponse.NotFound, null);
            }

            if (roomInformation.IsPrivate() && (string.IsNullOrEmpty(roomPassword) || roomPassword != roomInformation.Password))
            {
                return new Tuple<RemoteResponse, string>(RemoteResponse.InvalidPassword, null);
            }

            if (roomInformation.IsFull())
            {
                return new Tuple<RemoteResponse, string>(RemoteResponse.RoomFull, null);
            }

            OnUpdate?.Invoke(roomId, roomInformation.Count, roomInformation.Capacity);

            return new Tuple<RemoteResponse, string>(RemoteResponse.Success, ChatupServer.Instance.LookupChatroom(roomId));
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