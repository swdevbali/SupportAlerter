using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.ModifyRegistry;

namespace SupportAlerterLibrary
{
    public class RegistrySettings
    {
        private static RegistrySettings instance = null;
        private static ModifyRegistry reg = new ModifyRegistry();

       
        public static int emailCheckInterval;
        public static string mysqlHost;
        public static string mysqlDatabase;
        public static string mysqlUsername;
        public static string mysqlPassword;
        public static string loggingLevel;

        private RegistrySettings()
        {
            reg.SubKey = "SOFTWARE\\Swdev Bali\\eMailToSMS";
            loadValues();
        }

        public static RegistrySettings getInstance()
        {
            if (instance == null)
            {
                instance = new RegistrySettings();
            }
            return instance;

        }

        public static void loadValues()
        {
            emailCheckInterval = (int)reg.Read("emailCheckInterval", 1);//in minutes
            mysqlHost = (string) reg.Read("mysqlHost", "localhost");
            mysqlDatabase = (string)reg.Read("mysqlDatabase", "email2sms");
            mysqlUsername = (string)reg.Read("mysqlUsername", "root");
            mysqlPassword = Cryptho.Decrypt((string)reg.Read("mysqlPassword", Cryptho.Encrypt("adminadmin")));
            loggingLevel = (string)reg.Read("loggingLevel", "Normal");
        }

        public static void writeValues()
        {
            reg.Write("emailCheckInterval", emailCheckInterval);
            reg.Write("mysqlHost", mysqlHost);
            reg.Write("mysqlDatabase", mysqlDatabase);
            reg.Write("mysqlUsername", mysqlUsername);
            reg.Write("mysqlPassword", Cryptho.Encrypt(mysqlPassword));
            reg.Write("loggingLevel", loggingLevel);
        }
    }
}
