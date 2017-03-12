using ChatupNET.Model;

using System.Collections.Concurrent;

namespace ChatupNET.Remoting
{
    class MessageQueue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageLimit"></param>
        public MessageQueue(int messageLimit)
        {
            mLimit = messageLimit;
        }

        /// <summary>
        /// 
        /// </summary>
        private int mLimit;

        /// <summary>
        /// 
        /// </summary>
        ConcurrentQueue<RemoteMessage> q = new ConcurrentQueue<RemoteMessage>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void Enqueue(RemoteMessage remoteMessage)
        {
            q.Enqueue(remoteMessage);

            lock (this)
            {
                RemoteMessage overflowMessage;

                while (q.Count > mLimit && q.TryDequeue(out overflowMessage))
                {
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public RemoteMessage Dequeue()
        {
            RemoteMessage enqueuedMessage;

            if (q.TryDequeue(out enqueuedMessage))
            {
                return enqueuedMessage;
            }

            return null;
        }
    }
}