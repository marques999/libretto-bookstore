using System;
using System.Collections.Concurrent;

namespace ChatupNET.Model
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class MessageQueue : ConcurrentQueue<RemoteMessage>
    {
        /// <summary>
        ///
        /// </summary>
        private readonly int _limit = ChatupCommon.QueueLimit;

        /// <summary>
        ///
        /// </summary>
        private readonly object _syncObject = new object();

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        public new void Enqueue(RemoteMessage obj)
        {
            base.Enqueue(obj);

            lock (_syncObject)
            {
                while (Count > _limit)
                {
                    RemoteMessage remoteMessage;
                    TryDequeue(out remoteMessage);
                }
            }
        }
    }
}