using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public User(int type, long id, string username, string name, string password)
    {
        Id = id;
        Username = username;
        Name = name;
        Password = password;
    }
}

public enum UserOperation { New, Logout }

public delegate void AlterDelegateUser(UserOperation op, User usr);

public interface IUserSingleton
{
    event AlterDelegateUser alterEvent;

    ArrayList GetUsers();

    ArrayList GetLoggedUsers();

    int GetNewType();

    void AddUser(User usr);

    bool LoginUser(User usr);

    bool LogoutUser(User usr);

}

public class AlterEventUserRepeater : MarshalByRefObject
{
    public event AlterDelegateUser alterEvent;

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public void Repeater(UserOperation op, User usr)
    {
        if (alterEvent != null)
            alterEvent(op, usr);
    }
}