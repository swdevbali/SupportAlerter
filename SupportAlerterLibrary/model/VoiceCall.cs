using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class VoiceCall
    {
        public VoiceCall(int idvoice_call, string status)
        {
            this.idvoice_call = idvoice_call;
            this.status = status;
        }

        public int idvoice_call { get; set; }
        public string status { get; set; }
    }
}
