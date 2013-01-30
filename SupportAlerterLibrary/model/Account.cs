using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class Account
    {
        public string name { get; set; }
        public string server { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool use_ssl { get; set; }
        public bool active { get; set; }

        public Account(string name,string server, int port,string username,string password,bool use_ssl,bool active)
        {
            this.name = name;
            this.server = server;
            this.port = port;
            this.username = username;
            this.password = password;
            this.use_ssl = use_ssl;
            this.active = active;
        }

    }
}
