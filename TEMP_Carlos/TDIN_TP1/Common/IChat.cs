using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IChat
    {
        event AlterDelegate alterEvent;

        bool register(string username, string pw);
        Guid authenticate(string username, string pw, string adress);
        bool logout(Guid id);
        List<Account> getActiveUsers();
    }
}
