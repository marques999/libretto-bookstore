using System;
using System.Collections.Generic;
using System.Data.SQLite;

using ChatupNET.Database;
using ChatupNET.Database.Enums;
using ChatupNET.Model;
using ChatupNET.Rooms;

namespace ChatupNET
{
    class SqliteDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        private static SqliteDatabase instance;

        /// <summary>
        /// Public getter property for the "instance" private member
        /// </summary>
        public static SqliteDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqliteDatabase();
                }

                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private SqliteDatabase()
        {
            sqliteConnection = new SQLiteConnection(string.Format(
                "Data Source={0}ChatupServer.db;Version=3;",
                AppDomain.CurrentDomain.BaseDirectory)
            );

            sqliteConnection.Open();

            GenerateTable(
                "users",
                "CREATE TABLE `users`(`username` TEXT NOT NULL UNIQUE, `name` TEXT NOT NULL, `password` TEXT NOT NULL)"
            );

            GenerateTable(
                "rooms",
                "CREATE TABLE `rooms`(`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `owner` TEXT NOT NULL, `password` TEXT, `capacity` INTEGER DEFAULT 4 CHECK(capacity > 0), FOREIGN KEY(`owner`) REFERENCES `users`(`username`))"
            );
        }

        /// <summary>
        /// 
        /// </summary>
        private SQLiteConnection sqliteConnection;

        /// <summary>
        /// 
        /// </summary>
        public SQLiteConnection Connection
        {
            get
            {
                return sqliteConnection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool DeleteRoom(int roomId, string roomOwner)
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
        /// <param name="registerObject"></param>
        /// <returns></returns>
        internal bool InsertUser(UserForm registerObject)
        {
            int queryResult = 0;
            var registerUser = "INSERT INTO users(username, name, password) VALUES(:username, :name, :password)";

            using (var sqlCommand = new SQLiteCommand(registerUser, sqliteConnection))
            {
                sqlCommand.Parameters.Add(new SQLiteParameter(fieldUsername, registerObject.Username));
                sqlCommand.Parameters.Add(new SQLiteParameter(fieldName, registerObject.Name));
                sqlCommand.Parameters.Add(new SQLiteParameter(fieldPassword, registerObject.Password));
                queryResult = sqlCommand.ExecuteNonQuery();
            }

            return true;
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
        /// <param name="roomId"></param>
        /// <param name="chatroomInstance"></param>
        /// <returns></returns>
        public bool InsertRoom(int roomId, GroupChatroom chatroomInstance)
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
        private SqlColumn[] userColumns = new SqlColumn[]
        {
            new SqlColumn(fieldName, null),
            new SqlColumn(fieldUsername, null)
        };

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

        internal Dictionary<string, UserInformation> QueryUsers()
        {
            var users = new Dictionary<string, UserInformation>();
            var sqlQuery = new SqlBuilder().FromTable(tableUsers).Columns(userColumns);

            using (var userEntry = QueryDatabase(sqlQuery))
            {
                while (userEntry.Read())
                {
                    var userName = userEntry.GetString(userEntry.GetOrdinal(fieldUsername));

                    users.Add(userName, new UserInformation(
                        userName,
                        userEntry.GetString(userEntry.GetOrdinal(fieldName))
                    ));
                }
            }

            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, GroupChatroom> QueryRooms()
        {
            var rooms = new Dictionary<int, GroupChatroom>();
            var sqlQuery = new SqlBuilder().FromTable(tableRooms).Columns(roomColumns);

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
    }
}