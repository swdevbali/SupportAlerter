using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class Rule
    {
        public Rule(string name, string contains, bool send_sms, bool voice_call)
        {
            this.name = name;
            this.contains = contains;
            this.send_sms = send_sms;
            this.voice_call = voice_call;
        }
        public string name { get; set; }
        public string contains { get; set; }
        public bool send_sms { get; set; }
        public bool voice_call { get; set; }

        
    }
}
