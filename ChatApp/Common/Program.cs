using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]

public class Message {

    int type;
    public long Id = 0;
    public string Content { get; set; }
    public string Datesent { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }

    public long getId()
    {
        return Id;
    }

    public void setId(long id)
    {
        Id = id;
    }

    public Message(int type, string content, string dateSent, string sender, string receiver) {
        Type = type;
        Id += 1;
        Content = content;
        Datesent = dateSent;
        Sender = sender;
        Receiver = receiver;
    }

    public int Type
    {
        get
        {
            return type;
        }
        set
        {
            if (value < 0)
                type = 999;
            else
                type = value;
        }
    }
}

public enum Operation { New, Search }

public delegate void AlterDelegate(Operation op, Message msg);

public delegate void AlterDelegateArrayList(Operation op, ArrayList msg);

public interface IMessageSingleton
{
    event AlterDelegate alterEvent;

    ArrayList GetMessages();

    int GetNewType();

    void AddMessage(Message msg);

    ArrayList GetMessagesFromToMe(string sender, string receiver);

}

public class AlterEventRepeater : MarshalByRefObject
{
    public event AlterDelegate alterEvent;

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public void Repeater(Operation op, Message msg)
    {
        if (alterEvent != null)
            alterEvent(op, msg);
    }
}

