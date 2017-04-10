using System;
using System.Data;
using System.Data.SqlClient;

namespace Libretto.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class SqliteDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        protected static bool ReadBoolean(IDataRecord sqlReader, string sqlColumn)
        {
            return NullCheck(sqlReader, sqlColumn) == false && sqlReader.GetBoolean(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        protected static double ReadFloat(IDataRecord sqlReader, string sqlColumn)
        {
            return NullCheck(sqlReader, sqlColumn) ? 0 : sqlReader.GetDouble(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        protected static int ReadInteger(IDataRecord sqlReader, string sqlColumn)
        {
            return NullCheck(sqlReader, sqlColumn) ? 0 : sqlReader.GetInt32(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        protected static string ReadString(IDataRecord sqlReader, string sqlColumn)
        {
            return NullCheck(sqlReader, sqlColumn) ? null : sqlReader.GetString(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        protected static Guid ReadGuid(IDataRecord sqlReader, string sqlColumn)
        {
            return NullCheck(sqlReader, sqlColumn) ? new Guid() : sqlReader.GetGuid(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        protected static DateTime ReadTimestamp(IDataRecord sqlReader, string sqlColumn)
        {
            return NullCheck(sqlReader, sqlColumn) ? DateTime.Now : sqlReader.GetDateTime(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <param name="sqlColumn"></param>
        /// <returns></returns>
        private static bool NullCheck(IDataRecord sqlReader, string sqlColumn)
        {
            return sqlReader == null || sqlReader.IsDBNull(sqlReader.GetOrdinal(sqlColumn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        protected static SqlCommand Query(string sqlQuery)
        {
            return new SqlCommand(sqlQuery, LibrettoServer.Instance.Database);
        }
    }
}