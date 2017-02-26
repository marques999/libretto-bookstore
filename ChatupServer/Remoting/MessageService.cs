using System;
using System.Collections.Generic;

using ChatupNET.Messaging;

namespace ChatupNET.Remoting
{
    class MessageService : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="user2"></param>
        public MessageService(string user1, string user2)
        {
            source = user1;
            destination = user2;
        }

        /// <summary>
        /// 
        /// </summary>
        private string source;

        /// <summary>
        /// 
        /// </summary>
        private string destination;

        /// <summary>
        /// 
        /// </summary>
        private Queue<Message> messages = new Queue<Message>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageObject"></param>
        void Insert(Message messageObject)
        {
            if (messageObject != null)
            {
                lock (messages)
                {
                    messages.Enqueue(messageObject);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageAuthor"></param>
        /// <param name="messageContents"></param>
        void Insert(string messageAuthor, string messageContents)
        {
            if (string.IsNullOrEmpty(messageAuthor) == false && string.IsNullOrEmpty(messageContents) == false)
            {
                lock (messages)
                {
                    messages.Enqueue(new Message(messageAuthor, messageContents, DateTime.Now));
                }
            }
        }
    }
}