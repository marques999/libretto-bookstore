using System;
using System.Collections.Generic;

class MessageService : MarshalByRefObject
{
    private Queue<Message> messages = new Queue<Message>();

    private string source;
    private string destination;

    public MessageService(string user1, string user2)
    {
        source = user1;
        destination = user2;
    }

    public void Insert(Message messageObject)
    {
        if (messageObject != null)
        {
            lock (messages)
            {
                messages.Enqueue(messageObject);
            }
        }
    }

    public void Insert(string messageAuthor, string messageContents)
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