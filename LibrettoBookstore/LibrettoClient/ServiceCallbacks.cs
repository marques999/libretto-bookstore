using Libretto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libretto
{
    public class ServiceCallbacks : StoreService.IStoreServiceCallback
    {
        public void UserAdded()
        {
            LibrettoClient.Instance.Books = new List<Book>();
        }
    }
}
