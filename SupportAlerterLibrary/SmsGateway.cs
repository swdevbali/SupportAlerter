using SupportAlerterLibrary.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary
{
    public class SmsGateway
    {
        private static SmsGateway instance = null;
        private SmsGateway()
        { 
        }

        public static SmsGateway getInstance()
        {
            if (instance == null)
            {
                instance = new SmsGateway();
            }
            return instance;
        }

        public void processSmsNotification(SendSms sendSms)
        {
            EventLog.WriteEntry(Program.EventLogName, "Processing Sms notification " + sendSms.content);
        }


        public void processCallNotification(VoiceCall voiceCall)
        {
            EventLog.WriteEntry(Program.EventLogName, "Processing voice call notification " + voiceCall.status);
        }
    }
}
