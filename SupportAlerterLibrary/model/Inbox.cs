using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class Inbox
    {

        public Inbox(int idinbox, string subject)
        {
            // TODO: Complete member initialization
            this.idinbox = idinbox;
            this.subject = subject;
        }
        public int idinbox { get; set; }
        public string account_name { get; set; }
        public string sender { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string date { get; set; }
        public bool handled { get; set; }
    }
}
