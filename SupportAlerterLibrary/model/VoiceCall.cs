using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class VoiceCall
    {
        public VoiceCall(int idvoice_call, string status, string account_name)
        {
            this.idvoice_call = idvoice_call;
            this.status = status;
            this.account_name = account_name;
        }

        public int idvoice_call { get; set; }
        public string status { get; set; }

        public string account_name { get; set; }
    }
}
