using System;

using Libretto.Properties;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class WarehouseLogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public static void LogException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LogMessage($"{ex.Source}: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageParams"></param>
        public static void LogMessage(string messageFormat, params object[] messageParams)
        {
            Console.WriteLine(Resources.LogFormat, DateTime.Now.ToLongTimeString(), string.Format(messageFormat, messageParams));
        }
    }
}