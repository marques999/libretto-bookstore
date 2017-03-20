﻿using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    public delegate void DeleteHandler(int roomId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomInformation"></param>
    public delegate void InsertHandler(Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomCount"></param>
    public delegate void UpdateHandler(int roomId, int roomCount);

    /// <summary>
    /// 
    /// </summary>
    public interface LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event InsertHandler OnInsert;

        /// <summary>
        /// 
        /// </summary>
        event DeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        Dictionary<int, Room> List();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        string LookupUser(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Tuple<bool, string> QueryRoom(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        RemoteResponse Delete(int roomId, string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        Tuple<RemoteResponse, Room> Insert(Room roomInformation);
    }
}