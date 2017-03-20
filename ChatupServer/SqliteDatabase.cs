using System;
using System.Collections.Generic;
using System.Data.SQLite;

using ChatupNET.Database;
using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET
{
    class SqliteDatabase
    {
        /// <summary>
        /// Default constructor
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
        private static SqliteDatabase mInstance;

        /// <summary>
        /// 
        /// </summary>
        private SQLiteConnection sqliteConnection;

        /// <summary>
        /// Public getter property for the "mInstance" private member
        /// </summary>
        public static SqliteDatabase Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new SqliteDatabase();
                }

                return mInstance;
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
        /// <param name="userForm"></param>
        /// <returns></returns>
        public bool InsertUser(UserForm userForm)
        {
            bool operationResult = false;

            using (SQLiteCommand sqlCommand = new SQLiteCommand(SqliteConstants.users_INSERT, sqliteConnection))
            {
                AddParameter(sqlCommand, SqliteConstants.Username, userForm.Username);
                AddParameter(sqlCommand, SqliteConstants.Name, userForm.Name);
                AddParameter(sqlCommand, SqliteConstants.Password, userForm.Password);
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

            using (var userInfo = QueryDatabase(sqlQuery))
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
        /// <param name="groupChatroom"></param>
        /// <returns></returns>
        public bool InsertRoom(Room groupChatroom)
        {
            bool operationResult = false;
            var queryString = SqliteConstants.rooms_INSERT_Public;

            if (groupChatroom.IsPrivate())
            {
                queryString = SqliteConstants.rooms_INSERT_Private;
            }

            using (var sqlCommand = new SQLiteCommand(queryString, sqliteConnection))
            {
                AddParameter(sqlCommand, SqliteConstants.Id, groupChatroom.ID);
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
        /// <param name="roomOwner"></param>
        /// <returns></returns>
        public bool DeleteRoom(int roomId, string roomOwner)
        {
            bool operationResult = false;

            using (var sqlCommand = new SQLiteCommand(SqliteConstants.rooms_DELETE, sqliteConnection))
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
            using (var sqlQuery = sqliteConnection.CreateCommand())
            {
                sqlQuery.CommandText = new SqlBuilder()
                    .FromTable(SqliteConstants.MASTER)
                    .Column(SqliteConstants.Name)
                    .Where(SqliteConstants.Name, Comparison.Equals, tableName).BuildQuery();

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
            var users = new Dictionary<string, UserInformation>();

            var sqlQuery = new SqlBuilder()
                .FromTable(SqliteConstants.USERS)
                .Column(SqliteConstants.Name)
                .Column(SqliteConstants.Username);

            using (var entryRow = QueryDatabase(sqlQuery))
            {
                while (entryRow.Read())
                {
                    string userName = ReadString(entryRow, SqliteConstants.Username);

                    users.Add(userName, new UserInformation(
                        userName,
                        ReadString(entryRow, SqliteConstants.Name),
                        null
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
            int dbIndex = sqliteReader.GetOrdinal(sqlColumn);

            if (sqliteReader.IsDBNull(dbIndex))
            {
                return null;
            }

            return sqliteReader.GetString(dbIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqliteReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        private int ReadInteger(SQLiteDataReader sqliteReader, string sqlColumn)
        {
            int dbIndex = sqliteReader.GetOrdinal(sqlColumn);

            if (sqliteReader.IsDBNull(dbIndex))
            {
                return 0;
            }

            return sqliteReader.GetInt32(dbIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Room> QueryRooms()
        {
            var rooms = new Dictionary<int, Room>();

            var sqlQuery = new SqlBuilder()
                .FromTable(SqliteConstants.ROOMS)
                .Column(SqliteConstants.Id)
                .Column(SqliteConstants.Name)
                .Column(SqliteConstants.Owner)
                .Column(SqliteConstants.Password)
                .Column(SqliteConstants.Capacity);

            using (var entryRow = QueryDatabase(sqlQuery))
            {
                while (entryRow.Read())
                {
                    var roomId = ReadInteger(entryRow, SqliteConstants.Id);

                    rooms.Add(roomId, new Room(roomId,
                        ReadString(entryRow, SqliteConstants.Name),
                        ReadString(entryRow, SqliteConstants.Owner),
                        ReadString(entryRow, SqliteConstants.Password),
                        ReadInteger(entryRow, SqliteConstants.Capacity))
                    );
                }
            }

            return rooms;
        }
    }
}