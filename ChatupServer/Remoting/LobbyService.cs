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
        /// <param name="roomId"></param>
        /// <returns></returns>
        public string LookupRoom(int roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                return ChatupServer.Instance.LookupChatroom(roomId);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string LookupUser(string userName)
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
        public CustomResponse Insert(Room roomInformation)
        {
            if (roomInformation == null)
            {
                return new CustomResponse(RemoteResponse.BadRequest);
            }

            if (string.IsNullOrEmpty(roomInformation.Owner))
            {
                return new CustomResponse(RemoteResponse.BadRequest);
            }

            if (string.IsNullOrEmpty(roomInformation.Name))
            {
                return new CustomResponse(RemoteResponse.BadRequest);
            }

            roomInformation.ID = ChatupServer.Instance.NextID;

            if (ChatupServer.Instance.RegisterChatrooom(roomInformation))
            {
                OnInsert?.Invoke(roomInformation);
            }
            else
            {
                return new CustomResponse(RemoteResponse.OperationFailed);
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