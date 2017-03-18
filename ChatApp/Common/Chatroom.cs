using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]

public class Chatroom
{

    public long Id = 0;
    public string Name { get; set; }
    public bool IsPrivate { get; set; }

    ArrayList messages;

    ArrayList users;

    public long getId()
    {
        return Id;
    }

    public void setId(long id)
    {
        Id = id;
    }

    public Chatroom(string name, bool privacy)
    {
        Id += 1;
        Name = name;
        IsPrivate = privacy;
        users = new ArrayList();
        messages = new ArrayList();
    }

    public void addUser(User usr)
    {
        users.Add(usr);
    }

    public ArrayList GetUsers()
    {
        return users;
    }

    public void AddMessage(Message msg)
    {
        messages.Add(msg);
    }

    public ArrayList GetMessages()
    {
        return messages;
    }

    public void RemoveUser(int index)
    {
        users.RemoveAt(index);
    }
}

public enum CROperation { New , Delete , UserJoined , NewMessage , UserLeft }

public delegate void AlterCRDelegate(CROperation op, Chatroom msg);

public interface IChatroomSingleton
{
    event AlterCRDelegate alterEvent;
    ArrayList GetUsers(string chName);
    void AddMessage(string chName, Message msg);
    ArrayList GetMessages(string chName);
    void AddChatroom(Chatroom ch);
    void AddUser(string chName, User usr);
    void RemoveUser(string chName, User usr);
    ArrayList GetChatrooms();
    void DeleteChatroom(string chName);
}

public class AlterEventRepeaterCR : MarshalByRefObject
{
    public event AlterCRDelegate alterEvent;

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public void Repeater(CROperation op, Chatroom msg)
    {
        if (alterEvent != null)
            alterEvent(op, msg);
    }
}