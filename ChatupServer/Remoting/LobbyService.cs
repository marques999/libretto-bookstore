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
        public event RoomHandler OnInsert;

        /// <summary>
        /// 
        /// </summary>
        public event DeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        public event RoomHandler OnUpdate;

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
        public string Lookup(string userName)
        {
            return ChatupServer.Instance.LookupHost(userName);
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
                    OnDelete?.Invoke(roomId);
                    ChatupServer.Instance.Lobby.DeleteRoom(roomId);
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
        /// <param name="roomId"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public CustomResponse Join(int roomId, string userName, string userPassword)
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
                    OnUpdate?.Invoke(roomInformation);
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

            roomInformation.ID = ChatupServer.Instance.NextID;

            if (ChatupServer.Instance.RegisterChatrooom(roomInformation))
            {
                OnInsert?.Invoke(roomInformation);
            }
            else
            {
                return new CustomResponse(RemoteResponse.OperationFailed, null);
            }

            return new CustomResponse(RemoteResponse.Success, roomInformation);
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