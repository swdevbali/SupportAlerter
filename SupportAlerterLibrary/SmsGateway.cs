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
            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Processing Sms notification " + sendSms.content,EventLogEntryType.Information);
        }


        public void processCallNotification(VoiceCall voiceCall)
        {
            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Processing voice call notification " + voiceCall.status,EventLogEntryType.Information);
        }
    }
}
