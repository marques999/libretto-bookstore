using System;
using System.Collections.Generic;
using System.Linq;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    class LobbyService : MarshalByRefObject, LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomInsertHandler OnCreate;

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
        public Dictionary<int, Room> mRooms;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, Room> List()
        {
            if (mRooms == null)
            {
                LazyInitialize();
            }

            return mRooms;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LazyInitialize()
        {
            mRooms = ChatupServer.Instance.Rooms;

            if (mRooms.Count > 0)
            {
                lastId = mRooms.Aggregate((l, r) => l.Key > r.Key ? l : r).Key;
            }
            else
            {
                lastId = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int lastId;

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
                return RemoteResponse.MissingParameters;
            }

            if (mRooms == null)
            {
                LazyInitialize();
            }

            if (!mRooms.ContainsKey(roomId))
            {
                return RemoteResponse.EntityNotFound;
            }

            if (mRooms[roomId].Owner == userName)
            {
                OnDelete?.Invoke(roomId);
                ChatupServer.Instance.Lobby.DeleteRoom(roomId);
                mRooms.Remove(roomId);
            }
            else
            {
                return RemoteResponse.InsufficientPermissions;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RemoteResponse Join(string userName, string userPassword, int roomId)
        {
            if (string.IsNullOrEmpty(userName) || roomId < 1)
            {
                return RemoteResponse.MissingParameters;
            }

            if (mRooms == null)
            {
                LazyInitialize();
            }

            if (mRooms.ContainsKey(roomId))
            {
                var roomInformation = mRooms[roomId];

                if (roomInformation.Password == null || roomInformation.Password.Equals(userPassword))
                {
                    OnUpdate?.Invoke(roomId, roomInformation.Count, roomInformation.Capacity);
                    ChatupServer.Instance.Lobby.UpdateRoom(roomId, roomInformation.Count, roomInformation.Capacity);
                }
                else
                {
                    return RemoteResponse.AuthenticationFailed;
                }
            }
            else
            {
                return RemoteResponse.EntityNotFound;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        public RemoteResponse New(Room roomInformation)
        {
            if (roomInformation == null)
            {
                return RemoteResponse.MissingParameters;
            }

            if (string.IsNullOrEmpty(roomInformation.Owner))
            {
                return RemoteResponse.MissingParameters;
            }

            if (string.IsNullOrEmpty(roomInformation.Name))
            {
                return RemoteResponse.MissingParameters;
            }

            if (mRooms == null)
            {
                LazyInitialize();
            }

            var roomId = ++lastId;

            OnCreate?.Invoke(roomId, roomInformation);
            ChatupServer.Instance.Lobby.CreateRoom(roomId, roomInformation);
            mRooms.Add(roomId, roomInformation);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RemoteResponse IsPrivate(int roomId)
        {
            if (mRooms == null)
            {
                LazyInitialize();
            }

            if (mRooms.ContainsKey(roomId))
            {
                if (mRooms[roomId].IsPrivate())
                {
                    return RemoteResponse.Success;
                }

                return RemoteResponse.Failure;
            }

            return RemoteResponse.EntityNotFound;
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