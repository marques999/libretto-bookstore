using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    class ChatManager : MarshalByRefObject, IChat
    {
        private Dictionary<Guid, Account> connectedUsers;
        private Dictionary<string, Account> accounts;

        public event AlterDelegate alterEvent;

        public ChatManager()
        {
            connectedUsers = new Dictionary<Guid, Account>();
            accounts = new Dictionary<string, Account>();

            accounts["cenas"] = new Account("cenas", "123");
            accounts["cenas1"] = new Account("cenas1", "123");
        }

        Guid IChat.authenticate(string username, string pw, string adress)
        {
            Account acc;
            if (accounts.TryGetValue(username, out acc))
            {
                if (acc.getPassword().Equals(pw))
                {
                    Guid id = Guid.NewGuid();
                    Account newUser = new Account(username, pw, adress);
                    connectedUsers[id] = newUser;
                    NotifyClients(newUser, Operation.New);
                    return id;
                }
            }    
            
            return Guid.Empty;
        }

        List<Account> IChat.getActiveUsers()
        {
            return connectedUsers.Values.ToList();
        }

        bool IChat.logout(Guid id)
        {
            if (connectedUsers.ContainsKey(id))
            {                
                NotifyClients(connectedUsers[id], Operation.Delete);
                connectedUsers.Remove(id);
                return true;
            }
            return false;
        }

        bool IChat.register(string username, string pw)
        {
            throw new NotImplementedException();
        }

        void NotifyClients(Account acc, Operation opr)
        {
            if (alterEvent != null)
            {
                Delegate[] invkList = alterEvent.GetInvocationList();
                foreach (AlterDelegate handler in invkList)
                {
                    new Thread(() => {
                        try
                        {
                            handler(acc, opr);
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
}
