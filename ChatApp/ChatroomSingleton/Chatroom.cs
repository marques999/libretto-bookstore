using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class ChatroomSingleton : MarshalByRefObject, IChatroomSingleton
{
    ArrayList ChatRooms;

    public event AlterCRDelegate alterEvent;

    public ChatroomSingleton()
    {
        Console.WriteLine("Chatroom Singleton Instantiated");
        ChatRooms = new ArrayList();
        //usersList.Add(u1);
    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public ArrayList GetUsers(string chName)
    {
        foreach(Chatroom ch in ChatRooms)
        {
            if (ch.Name.Equals(chName))
            {
                return ch.GetUsers();
            }
        }

        return new ArrayList();
    }
    public void AddMessage(string chName, Message msg)
    {
        foreach(Chatroom ch in ChatRooms)
        {
            if(ch.Name.Equals(chName))
            {
                ch.AddMessage(msg);
                NotifyClients(CROperation.NewMessage, ch);
                return;
            }
        }
    }
    public ArrayList GetMessages(string chName)
    {
        foreach(Chatroom ch in ChatRooms)
        {
            if(ch.Name.Equals(chName))
            {
                return ch.GetMessages();
            }
        }

        return new ArrayList();
    }
    public void AddUser(string chName, User usr)
    {
        int index = 0;
        foreach (Chatroom ch in ChatRooms)
        {
            if(ch.Name.Equals(chName))
            {
                ch.addUser(usr);
                NotifyClients(CROperation.UserJoined, ch);
                return;
            }
            index++;
        }        
    }
    public void RemoveUser(string chName, User usr)
    {
        int index = 0;
        foreach (Chatroom ch in ChatRooms)
        {
            
            if(ch.Name.Equals(chName))
            {
                foreach (User u1 in ch.GetUsers())
                {
                    Console.WriteLine("Trying to remove user:" + usr.Username + " so far found: " + u1.Username);
                    if (u1.Username.Equals(usr.Username))
                    {
                        ch.RemoveUser(index);
                        NotifyClients(CROperation.UserLeft, ch);
                        return;
                    }
                    index++;
                }   
            }
        }
    }
    public void AddChatroom(Chatroom ch)
    {
        ChatRooms.Add(ch);
        NotifyClients(CROperation.New, ch);
    }

    public ArrayList GetChatrooms()
    {
        return ChatRooms;
    }

    public void DeleteChatroom(string chname)
    {
        Console.WriteLine("Deleting chatroom name:" + chname);
        int index = 0;
        foreach(Chatroom ch in ChatRooms)
        {
            if (ch.Name.Equals(chname))
            {
                ChatRooms.Remove(index);
                NotifyClients(CROperation.Delete, ch);
            }
            index++;
        }
    }

    void NotifyClients(CROperation op, Chatroom chroom)
    {
        if (alterEvent != null)
        {
            Delegate[] invkList = alterEvent.GetInvocationList();

            foreach (AlterCRDelegate handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, chroom);
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


}