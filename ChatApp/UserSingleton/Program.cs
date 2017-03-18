using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class UserSingleton : MarshalByRefObject, IUserSingleton
{
    ArrayList usersList;
    ArrayList loggedUsers;
    int type = 2;

    public event AlterDelegateUser alterEvent;

    public UserSingleton()
    {
        Console.WriteLine("Message Singleton Instantiated");
        usersList = new ArrayList();
        loggedUsers = new ArrayList();
        User u1 = new User(2,1,"Test1","koad","pw123");
        //usersList.Add(u1);
        AddUser(u1);
    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public ArrayList GetUsers()
    {
        Console.WriteLine("Called getUsers()");
        return usersList;
    }

    public ArrayList GetLoggedUsers()
    {
        Console.WriteLine("Called GetLoggedUsers()");
        return loggedUsers;
    }

    public int GetNewType()
    {
        return type++;
    }

    public void AddUser(User usr)
    {
        Console.WriteLine("Adding a new User");
        Console.WriteLine("User's name: " + usr.Name);
        Console.WriteLine("User's username: " + usr.Username);
        Console.WriteLine("User's password: " + usr.Password);
        usersList.Add(usr);
        Console.WriteLine("Current Users: ");
        foreach(User user in usersList)
        {
            Console.WriteLine(user.Username);
        }
    }

    public bool LogoutUser(User usr)
    {
        foreach(User user in loggedUsers)
        {
            if (user.Username.Equals(usr.Username))
            {
                Console.WriteLine("Logout successful for username: " + usr.Username);
                loggedUsers.Remove(user);
                NotifyClients(UserOperation.Logout, usr);
                return true;
            }
        }
        return false;
    }
    public bool LoginUser(User usr)
    {
        foreach(User u1 in usersList)
        {
            Console.WriteLine("In Server username: " + u1.Username);
            Console.WriteLine("In Server password: " + u1.Password);
            Console.WriteLine("User logging in username: " + usr.Username);
            Console.WriteLine("User logging in password: " + usr.Password);

            if (u1.Username.Equals(usr.Username) && u1.Password.Equals(usr.Password))
            {
                Console.WriteLine("HERE");
                loggedUsers.Add(usr);
                NotifyClients(UserOperation.New, usr);
                return true;
            }
                
        }

        return false;
    }

    void NotifyClients(UserOperation op, User usr)
    {
        if (alterEvent != null)
        {
            Delegate[] invkList = alterEvent.GetInvocationList();

            foreach (AlterDelegateUser handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, usr);
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