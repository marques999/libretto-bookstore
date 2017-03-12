using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    class LobbyService : MarshalByRefObject, LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomInsertHandler OnInsert;

        /// <summary>
        /// 
        /// </summary>
        public event RoomDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        public event RoomUpdateHandler OnUpdate;

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
        /// <param name="userName"></param>
        /// <returns></returns>
        public Address Lookup(string userName)
        {
            return ChatupServer.Instance.LookupHost(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RemoteResponse Delete(string userName, int roomId)
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
                OnDelete?.Invoke(roomId);
                ChatupServer.Instance.Lobby.DeleteRoom(roomId);
                Rooms.Remove(roomId);
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
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public CustomResponse Join(string userName, string userPassword, int roomId)
        {
            if (string.IsNullOrEmpty(userName) || roomId < 1)
            {
                return new CustomResponse(RemoteResponse.BadRequest, null);
            }

            if (Rooms.ContainsKey(roomId))
            {
                var roomInformation = Rooms[roomId];

                if (roomInformation.Password == null || roomInformation.Password.Equals(userPassword))
                {
                    OnUpdate?.Invoke(roomId, roomInformation.Count, roomInformation.Capacity);
                    ChatupServer.Instance.Lobby.UpdateRoom(roomId, roomInformation.Count, roomInformation.Capacity);
                }
                else
                {
                    return new CustomResponse(RemoteResponse.AuthenticationFailed, null);
                }
            }
            else
            {
                 return new CustomResponse(RemoteResponse.NotFound, null);
            }

            return new CustomResponse(RemoteResponse.Success, ChatupServer.Instance.LookupChatroom(roomId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        public CustomResponse New(Room roomInformation)
        {
            if (roomInformation == null)
            {
                return new CustomResponse(RemoteResponse.BadRequest, null);
            }

            if (string.IsNullOrEmpty(roomInformation.Owner))
            {
                return new CustomResponse(RemoteResponse.BadRequest, null);
            }

            if (string.IsNullOrEmpty(roomInformation.Name))
            {
                return new CustomResponse(RemoteResponse.BadRequest, null);
            }

            var roomId = ChatupServer.Instance.NextID;

            if (ChatupServer.Instance.RegisterChatrooom(roomId, roomInformation))
            {
                OnInsert?.Invoke(roomId, roomInformation);
            }
            else
            {
                return new CustomResponse(RemoteResponse.OperationFailed, null);
            }

            return new CustomResponse(RemoteResponse.Success, roomId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RemoteResponse IsPrivate(int roomId)
        {
            if (roomId < 1)
            {
                return RemoteResponse.BadRequest;
            }

            if (Rooms.ContainsKey(roomId))
            {
                if (Rooms[roomId].IsPrivate())
                {
                    return RemoteResponse.Success;
                }

                return RemoteResponse.OperationFailed;
            }

            return RemoteResponse.NotFound;
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