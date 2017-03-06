using ChatupNET.Model;
using System.Collections.Generic;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    public delegate void RoomInsertHandler(int id, Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    public delegate void RoomDeleteHandler(int roomId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomExit"></param>
    public delegate void RoomUpdateHandler(int roomId, int roomCount, int roomCapacity);

    /// <summary>
    /// 
    /// </summary>
    public interface LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event RoomInsertHandler OnInsert;

        /// <summary>
        /// 
        /// </summary>
        event RoomUpdateHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        event RoomDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        Dictionary<int, Room> List();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        RemoteResponse IsPrivate(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        RemoteResponse New(Room roomInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        RemoteResponse Delete(string userName, int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        RemoteResponse Join(string userName, string userPassword, int roomId);
    }
}