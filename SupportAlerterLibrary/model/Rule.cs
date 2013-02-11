using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterLibrary.model
{
    public class Rule
    {
        public Rule(string name, string contains, bool send_sms, bool voice_call,bool use_body, bool use_sender, string sender_contains, bool use_subject, string subject_contains)
        {
            this.name = name;
            this.contains = contains;
            this.send_sms = send_sms;
            this.voice_call = voice_call;
            this.use_body=use_body;
            this.use_sender=use_sender;
            this.sender_contains=sender_contains;
            this.use_subject=use_subject;
            this.subject_contains=subject_contains;
        }
        public string name { get; set; }
        public string contains { get; set; }
        public bool send_sms { get; set; }
        public bool voice_call { get; set; }
        
        public bool use_body{get;set;}
        public bool use_sender{get;set;}
        public string sender_contains{get;set;}
        public bool use_subject{get;set;}
        public string subject_contains{get;set;}


        
    }
}
