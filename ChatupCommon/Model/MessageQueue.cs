using System;
using System.Collections.Concurrent;

namespace ChatupNET.Model
{
    [Serializable]
    public class MessageQueue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageLimit"></param>
        public MessageQueue(int messageLimit)
        {
            _limit = messageLimit;
        }

        /// <summary>
        /// 
        /// </summary>
        private int _limit;

        /// <summary>
        /// 
        /// </summary>
        private ConcurrentQueue<RemoteMessage> _queue = new ConcurrentQueue<RemoteMessage>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        public void Enqueue(RemoteMessage messageInstance)
        {
            _queue.Enqueue(messageInstance);

            lock (this)
            {
                RemoteMessage overflowMessage;

                while (_queue.Count > _limit && _queue.TryDequeue(out overflowMessage))
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

            if (_queue.TryDequeue(out enqueuedMessage))
            {
                return enqueuedMessage;
            }

            return null;
        }
    }
}