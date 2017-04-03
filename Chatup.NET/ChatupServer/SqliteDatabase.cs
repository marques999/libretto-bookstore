using System.Collections.Generic;
using System.Data.SQLite;

using ChatupNET.Database;
using ChatupNET.Model;

namespace ChatupNET
{
    /// <summary>
    ///
    /// </summary>
    internal class SqliteDatabase
    {
        /// <summary>
        ///
        /// </summary>
        private SqliteDatabase()
        {
            _sqliteConnection.Open();
            GenerateTable(SqliteConstants.USERS, SqliteConstants.users_CREATE);
            GenerateTable(SqliteConstants.ROOMS, SqliteConstants.rooms_CREATE);
        }

        /// <summary>
        ///
        /// </summary>
        private static SqliteDatabase _instance;

        /// <summary>
        ///
        /// </summary>
        public static SqliteDatabase Instance => _instance ?? (_instance = new SqliteDatabase());

        /// <summary>
        ///
        /// </summary>
        private readonly SQLiteConnection _sqliteConnection = new SQLiteConnection(SqliteConstants.DatabaseUrl);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlBuilder"></param>
        /// <returns></returns>
        private SQLiteDataReader QueryDatabase(SqlBuilder sqlBuilder)
        {
            SQLiteDataReader dataReader;

            using (var sqlQuery = _sqliteConnection.CreateCommand())
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
            bool operationResult;

            using (var sqlCommand = new SQLiteCommand(SqliteConstants.users_INSERT, _sqliteConnection))
            {
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Username, userForm.Username));
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Name, userForm.Name));
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Password, userForm.Password));
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
            var sqlQuery = new SqlBuilder()
                .FromTable(SqliteConstants.USERS)
                .Column(SqliteConstants.Password)
                .Where(SqliteConstants.Username, Comparison.Equals, userName);

            using (var dbResult = QueryDatabase(sqlQuery))
            {
                return dbResult.Read() ? ReadString(dbResult, SqliteConstants.Password) : null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="groupChatroom"></param>
        /// <returns></returns>
        public bool InsertRoom(Room groupChatroom)
        {
            bool operationResult;
            var queryString = SqliteConstants.rooms_INSERT_Public;

            if (groupChatroom.IsPrivate())
            {
                queryString = SqliteConstants.rooms_INSERT_Private;
            }

            using (var sqlCommand = new SQLiteCommand(queryString, _sqliteConnection))
            {
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Id, groupChatroom.Id));
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Name, groupChatroom.Name));
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Owner, groupChatroom.Owner));

                if (groupChatroom.IsPrivate())
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Password, groupChatroom.Password));
                }

                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Capacity, groupChatroom.Capacity));
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            return operationResult;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomOwner"></param>
        /// <returns></returns>
        public bool DeleteRoom(int roomId, string roomOwner)
        {
            bool operationResult;

            using (var sqlCommand = new SQLiteCommand(SqliteConstants.rooms_DELETE, _sqliteConnection))
            {
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Id, roomId));
                sqlCommand.Parameters.Add(new SQLiteParameter(SqliteConstants.Owner, roomOwner));
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
            using (var sqlQuery = _sqliteConnection.CreateCommand())
            {
                sqlQuery.CommandText = new SqlBuilder()
                    .FromTable(SqliteConstants.MASTER)
                    .Column(SqliteConstants.Name)
                    .Where(SqliteConstants.Name, Comparison.Equals, tableName).BuildQuery();

                var dbResult = sqlQuery.ExecuteScalar();

                if (dbResult == null || !dbResult.ToString().Equals(tableName))
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

            using (var dbResult = QueryDatabase(sqlQuery))
            {
                while (dbResult.Read())
                {
                    var userName = ReadString(dbResult, SqliteConstants.Username);

                    users.Add(userName, new UserInformation(
                        userName,
                        ReadString(dbResult, SqliteConstants.Name),
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
        /// <param name="dbColumn"></param>
        /// <returns></returns>
        private static string ReadString(SQLiteDataReader sqliteReader, string dbColumn)
        {
            return sqliteReader == null || sqliteReader.IsDBNull(sqliteReader.GetOrdinal(dbColumn)) ? null : sqliteReader.GetString(sqliteReader.GetOrdinal(dbColumn));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqliteReader"></param>
        /// <param name="dbColumn"></param>
        /// <returns></returns>
        private static int ReadInteger(SQLiteDataReader sqliteReader, string dbColumn)
        {
            return sqliteReader == null || sqliteReader.IsDBNull(sqliteReader.GetOrdinal(dbColumn)) ? 0 : sqliteReader.GetInt32(sqliteReader.GetOrdinal(dbColumn));
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

            using (var dbResult = QueryDatabase(sqlQuery))
            {
                while (dbResult.Read())
                {
                    var roomId = ReadInteger(dbResult, SqliteConstants.Id);

                    rooms.Add(roomId, new Room(roomId,
                        ReadString(dbResult, SqliteConstants.Name),
                        ReadString(dbResult, SqliteConstants.Owner),
                        ReadString(dbResult, SqliteConstants.Password),
                        ReadInteger(dbResult, SqliteConstants.Capacity))
                    );
                }
            }

            return rooms;
        }
    }
}