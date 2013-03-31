using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class SendSms
    {
        public SendSms(int idsend_sms, string content, string account_name)
        {
            this.idsend_sms = idsend_sms;
            this.content = content;
            this.account_name = account_name;
        }

        public int idsend_sms { get; set; }
        public int idinbox { get; set; }
        public string content { get; set; }
        public string status { get; set; }


        public string account_name { get; set; }
    }
}
