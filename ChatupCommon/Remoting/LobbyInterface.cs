using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    public delegate void RoomDeleteHandler(int roomId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomInformation"></param>
    public delegate void RoomInsertHandler(int roomId, Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomCount"></param>
    /// <param name="roomCapacity"></param>
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
        /// <param name="userName"></param>
        /// <returns></returns>
        Address Lookup(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        RemoteResponse IsPrivate(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        RemoteResponse Delete(string userName, int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        CustomResponse New(Room roomInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        CustomResponse Join(string userName, string userPassword, int roomId);
    }
}