using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Clients
{
    public class ApiClient
    {
        private Lazy<CustomerClient> _CustomerClient = new Lazy<CustomerClient>();
        public CustomerClient CustomerClient => _CustomerClient.Value;
    }
}
