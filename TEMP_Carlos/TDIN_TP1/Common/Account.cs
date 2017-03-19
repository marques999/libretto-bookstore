using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Account
    {
        private string username;
        private string password;
        private string adress;

        public Account(string username, string password, string adress)
        {
            this.username = username;
            this.password = password;
            this.adress = adress;
        }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string getPassword()
        {
            return password;
        }

        public string getAdress()
        {
            return adress;
        }

        public string getUsername()
        {
            return username;
        }        
    }
}
