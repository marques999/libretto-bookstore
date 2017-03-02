using System;
using System.Collections.Generic;
using System.Data.SQLite;

using ChatupNET.Database;
using ChatupNET.Database.Enums;
using ChatupNET.Rooms;
using ChatupNET.Session;

public class ChatupServer
{
    /// <summary>
    /// Default constructor for the "ChatupServer" class
    /// </summary>
    private ChatupServer()
    {
        roomsInitialized = false;
        usersInitialized = false;
        InitializeSQLite();
    }

    /// <summary>
    /// 
    /// </summary>
    private static ChatupServer instance;

    /// <summary>
    /// Public getter property for the "instance" private member
    /// </summary>
    public static ChatupServer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ChatupServer();
            }

            return instance;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private SQLiteConnection sqliteConnection;

    /// <summary>
    /// 
    /// </summary>
    public SQLiteConnection Database
    {
        get
        {
            return sqliteConnection;
        }
    }

    private bool roomsInitialized;
    private bool usersInitialized;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, GroupChatroom> rooms = new Dictionary<int, GroupChatroom>();

    /// <summary>
    /// 
    /// </summary>
    private HashSet<string> users = new HashSet<string>();

    /// <summary>
    /// 
    /// </summary>
    private const string tableUsers = "users";
    private const string fieldUsername = "username";
    private const string tableRooms = "rooms";
    private const string fieldId = "id";
    private const string fieldName = "name";
    private const string fieldOwner = "owner";
    private const string fieldPassword = "password";
    private const string fieldCapacity = "capacity";

    /// <summary>
    /// 
    /// </summary>
    private SqlColumn[] roomColumns = new SqlColumn[]
    {
        new SqlColumn(fieldId, null),
        new SqlColumn(fieldName, null),
        new SqlColumn(fieldPassword, null),
        new SqlColumn(fieldCapacity, null)
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    internal bool DeleteRoom(int roomId, string roomOwner)
    {
        int queryResult = 0;
        var deleteRoom = "DELETE FROM rooms WHERE id = :id AND owner = :owner";

        using (var sqlCommand = new SQLiteCommand(deleteRoom, sqliteConnection))
        {
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldId, roomId));
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldOwner, roomOwner));
            queryResult = sqlCommand.ExecuteNonQuery();
        }

        return queryResult == 0 ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="chatroomInstance"></param>
    /// <returns></returns>
    internal bool InsertRoom(int roomId, GroupChatroom chatroomInstance)
    {
        int queryResult = 0;
        var insertRoom = "INSERT INTO rooms(id, name, owner, password, capacity) VALUES(:id, :name, :owner, :password, :capacity)";

        using (var sqlCommand = new SQLiteCommand(insertRoom, sqliteConnection))
        {
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldId, roomId));
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldName, chatroomInstance.Name));
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldOwner, chatroomInstance.Owner));

            if (chatroomInstance.IsPrivate())
            {
                sqlCommand.Parameters.Add(new SQLiteParameter(fieldPassword, chatroomInstance.Password));
            }

            sqlCommand.Parameters.Add(new SQLiteParameter(fieldCapacity, chatroomInstance.Capacity));
            queryResult = sqlCommand.ExecuteNonQuery();
        }

        return queryResult == 0 ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal Dictionary<int, GroupChatroom> QueryRooms()
    {
        var sqlQuery = new SqlBuilder().FromTable(tableRooms).Columns(roomColumns);

        if (roomsInitialized)
        {
            return rooms;
        }

        using (var roomEntry = QueryDatabase(sqlQuery))
        {
            while (roomEntry.Read())
            {
                rooms.Add(roomEntry.GetInt32(roomEntry.GetOrdinal(fieldId)), new GroupChatroom(
                    roomEntry.GetString(roomEntry.GetOrdinal(fieldName)),
                    roomEntry.GetString(roomEntry.GetOrdinal(fieldOwner)),
                    roomEntry.GetString(roomEntry.GetOrdinal(fieldPassword)),
                    roomEntry.GetInt32(roomEntry.GetOrdinal(fieldCapacity))
                ));
            }
        }

        return rooms;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    internal string QueryPassword(string userName)
    {
        var sqlQuery = new SqlBuilder()
            .FromTable(tableUsers)
            .Column(fieldPassword)
            .Where(fieldUsername, Comparison.Equals, userName);

        using (var userInfo = QueryDatabase(sqlQuery))
        {
            if (!userInfo.Read())
            {
                return null;
            }

            return userInfo.GetString(userInfo.GetOrdinal(fieldPassword));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="registerObject"></param>
    /// <returns></returns>
    internal bool InsertUser(RegisterObject registerObject)
    {
        int queryResult = 0;
        var registerUser = "INSERT INTO users(username, password) VALUES(:username, :password)";

        using (var sqlCommand = new SQLiteCommand(registerUser, sqliteConnection))
        {
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldUsername, registerObject.Username));
            sqlCommand.Parameters.Add(new SQLiteParameter(fieldPassword, registerObject.Password));
            queryResult = sqlCommand.ExecuteNonQuery();
        }

        return queryResult == 0 ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal HashSet<string> QueryUsers()
    {
        if (usersInitialized)
        {
            return users;
        }

        var sqlQuery = new SqlBuilder().FromTable(tableUsers).Column(fieldUsername);

        using (var userEntry = QueryDatabase(sqlQuery))
        {
            while (userEntry.Read())
            {
                users.Add(userEntry.GetString(userEntry.GetOrdinal(fieldUsername)));
            }
        }

        return users;
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<int, GroupChatroom> Rooms
    {
        get
        {
            return QueryRooms();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public HashSet<string> Users
    {
        get
        {
            return QueryUsers();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sqlBuilder"></param>
    /// <returns></returns>
    private SQLiteDataReader QueryDatabase(SqlBuilder sqlBuilder)
    {
        SQLiteDataReader dataReader;

        using (SQLiteCommand sqlQuery = sqliteConnection.CreateCommand())
        {
            sqlQuery.CommandText = sqlBuilder.BuildQuery();
            dataReader = sqlQuery.ExecuteReader();
        }

        return dataReader;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="tableSql"></param>
    private void GenerateTable(string tableName, string tableSql)
    {
        using (SQLiteCommand sqlQuery = sqliteConnection.CreateCommand())
        {
            sqlQuery.CommandText = new SqlBuilder()
                .FromTable("sqlite_master")
                .Column("name")
                .Where("name", Comparison.Equals, tableName).BuildQuery();

            var queryResult = sqlQuery.ExecuteScalar();

            if (queryResult == null || !queryResult.ToString().Equals(tableName))
            {
                sqlQuery.CommandText = tableSql;
                sqlQuery.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitializeSQLite()
    {
        sqliteConnection = new SQLiteConnection(string.Format(
            "Data Source={0}ChatupServer.db;Version=3;",
            AppDomain.CurrentDomain.BaseDirectory)
        );

        sqliteConnection.Open();

        GenerateTable(
            "users",
            "CREATE TABLE `users`(`username` TEXT NOT NULL UNIQUE, `password` TEXT NOT NULL)"
        );

        GenerateTable(
            "rooms",
            "CREATE TABLE `rooms`(`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `owner` TEXT NOT NULL, `password` TEXT, `capacity` INTEGER DEFAULT 4 CHECK(capacity > 0), FOREIGN KEY(`owner`) REFERENCES `users`(`username`))"
        );
    }
}