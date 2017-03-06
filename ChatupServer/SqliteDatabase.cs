using System;
using System.Collections.Generic;
using System.Data.SQLite;

using ChatupNET.Database;
using ChatupNET.Database.Enums;
using ChatupNET.Model;
using ChatupNET.Remoting;

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
            sqliteConnection = new SQLiteConnection(string.Format(Properties.Resources.database_Url, AppDomain.CurrentDomain.BaseDirectory));
            sqliteConnection.Open();
            GenerateTable(SqliteConstants.USERS, SqliteConstants.users_CREATE);
            GenerateTable(SqliteConstants.ROOMS, SqliteConstants.rooms_CREATE);
        }

        /// <summary>
        /// 
        /// </summary>
        private SqlColumn[] userColumns = new SqlColumn[]
        {
            new SqlColumn(SqliteConstants.Name, null),
            new SqlColumn(SqliteConstants.Username, null)
        };

        /// <summary>
        /// 
        /// </summary>
        private SqlColumn[] roomColumns = new SqlColumn[]
        {
            new SqlColumn(SqliteConstants.Id, null),
            new SqlColumn(SqliteConstants.Name, null),
            new SqlColumn(SqliteConstants.Password, null),
            new SqlColumn(SqliteConstants.Capacity, null)
        };

        /// <summary>
        /// 
        /// </summary>
        private SQLiteConnection sqliteConnection;

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
        /// <param name="userInformation"></param>
        /// <returns></returns>
        public bool InsertUser(UserForm userInformation)
        {
            bool operationResult = false;

            using (SQLiteCommand sqlCommand = new SQLiteCommand(SqliteConstants.users_INSERT, sqliteConnection))
            {
                AddParameter(sqlCommand, SqliteConstants.Username, userInformation.Username);
                AddParameter(sqlCommand, SqliteConstants.Name, userInformation.Name);
                AddParameter(sqlCommand, SqliteConstants.Password, userInformation.Password);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string QueryPassword(string userName)
        {
            SqlBuilder sqlQuery = new SqlBuilder()
                .FromTable(SqliteConstants.USERS)
                .Column(SqliteConstants.Password)
                .Where(SqliteConstants.Username, Comparison.Equals, userName);

            using (SQLiteDataReader userInfo = QueryDatabase(sqlQuery))
            {
                if (userInfo.Read())
                {
                    return userInfo.GetString(userInfo.GetOrdinal(SqliteConstants.Password));
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="groupChatroom"></param>
        /// <returns></returns>
        public bool InsertRoom(int roomId, GroupChatroom groupChatroom)
        {
            bool operationResult = false;
            var queryString = SqliteConstants.rooms_INSERT_Public;

            if (groupChatroom.IsPrivate())
            {
                queryString = SqliteConstants.rooms_INSERT_Private;
            }

            using (SQLiteCommand sqlCommand = new SQLiteCommand(queryString, sqliteConnection))
            {
                AddParameter(sqlCommand, SqliteConstants.Id, roomId);
                AddParameter(sqlCommand, SqliteConstants.Name, groupChatroom.Name);
                AddParameter(sqlCommand, SqliteConstants.Owner, groupChatroom.Owner);

                if (groupChatroom.IsPrivate())
                {
                    AddParameter(sqlCommand, SqliteConstants.Password, groupChatroom.Password);
                }

                AddParameter(sqlCommand, SqliteConstants.Capacity, groupChatroom.Capacity);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameterKey"></param>
        /// <param name="parameterValue"></param>
        private void AddParameter(SQLiteCommand sqlCommand, string parameterKey, object parameterValue)
        {
            sqlCommand.Parameters.Add(new SQLiteParameter(parameterKey, parameterValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool DeleteRoom(int roomId, string roomOwner)
        {
            bool operationResult = false;

            using (SQLiteCommand sqlCommand = new SQLiteCommand(SqliteConstants.rooms_DELETE, sqliteConnection))
            {
                AddParameter(sqlCommand, SqliteConstants.Id, roomId);
                AddParameter(sqlCommand, SqliteConstants.Owner, roomOwner);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            return operationResult;
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
        /// <returns></returns>
        public Dictionary<string, UserInformation> QueryUsers()
        {
            Dictionary<string, UserInformation> users = new Dictionary<string, UserInformation>();
            SqlBuilder sqlQuery = new SqlBuilder().FromTable(SqliteConstants.USERS).Columns(userColumns);

            using (SQLiteDataReader userEntry = QueryDatabase(sqlQuery))
            {
                while (userEntry.Read())
                {
                    string userName = ReadString(userEntry, SqliteConstants.Username);

                    users.Add(userName, new UserInformation(
                        userName,
                        ReadString(userEntry, SqliteConstants.Name)
                    ));
                }
            }

            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqliteReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        private string ReadString(SQLiteDataReader sqliteReader, string sqlColumn)
        {
            return sqliteReader.GetString(sqliteReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqliteReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        private int ReadInteger(SQLiteDataReader sqliteReader, string sqlColumn)
        {
            return sqliteReader.GetInt32(sqliteReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Room> QueryRooms()
        {
            Dictionary<int, Room> rooms = new Dictionary<int, Room>();
            SqlBuilder sqlQuery = new SqlBuilder().FromTable(SqliteConstants.ROOMS).Columns(roomColumns);

            using (SQLiteDataReader roomEntry = QueryDatabase(sqlQuery))
            {
                while (roomEntry.Read())
                {
                    rooms.Add(ReadInteger(roomEntry, SqliteConstants.Id), new Room(
                        ReadString(roomEntry, SqliteConstants.Name),
                        ReadString(roomEntry, SqliteConstants.Owner),
                        ReadString(roomEntry, SqliteConstants.Password),
                        ReadInteger(roomEntry, SqliteConstants.Capacity))
                    );
                }
            }

            return rooms;
        }
    }
}