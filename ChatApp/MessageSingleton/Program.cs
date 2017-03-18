using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class MessageSingleton : MarshalByRefObject, IMessageSingleton
{
    ArrayList messageList;
    int type = 2;


    public MessageSingleton()
    {
        Console.WriteLine("Message Singleton Instantiated");
        messageList = new ArrayList();
        //Message msg = new Message(...);
        //messageList.Add(msg);
    }

    public event AlterDelegate alterEvent;
    public event AlterDelegateArrayList alterEventArrayList;

    public void AddMessage(Message msg)
    {
        messageList.Add(msg);
        NotifyClients(Operation.New, msg);
    }

    public ArrayList GetMessagesFromToMe(string sender, string receiver)
    {
        ArrayList ret = new ArrayList();

        foreach(Message msg in messageList)
        {
            if(msg.Sender.Equals(sender) && msg.Receiver.Equals(receiver) || msg.Receiver.Equals(sender) && msg.Sender.Equals(receiver))
            {
                ret.Add(msg);
            }
        }

        Console.WriteLine("I am looking for messages from: " + sender + " to the user: " + receiver + " and I found: " + ret.Count + " messages!");
        //NotifyClients(Operation.Search, ret);

        return ret;
    }

    public ArrayList GetMessages()
    {
        Console.WriteLine("GetMessages() called");
        return messageList;
    }

    public int GetNewType()
    {
        return type++;
    }

    void NotifyClients(Operation op, Message msg)
    {
          if(alterEvent != null)
        {
            Delegate[] invkList = alterEvent.GetInvocationList();

            foreach(AlterDelegate handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, msg);
                        Console.WriteLine("Invoking event handler");
                    }
                    catch (Exception)
                    {
                        alterEvent -= handler;
                        Console.WriteLine("Exception: Removed an event handler");
                    }
                }).Start();
            }
        }
    }

    void NotifyClients(Operation op, ArrayList msg)
    {
        if (alterEvent != null)
        {
            Delegate[] invkList = alterEventArrayList.GetInvocationList();

            foreach (AlterDelegateArrayList handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, msg);
                        Console.WriteLine("Invoking event handler");
                    }
                    catch (Exception)
                    {
                        alterEventArrayList -= handler;
                        Console.WriteLine("Exception: Removed an event handler");
                    }
                }).Start();
            }
        }
    }
}
