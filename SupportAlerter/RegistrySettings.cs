using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.ModifyRegistry;

namespace SupportAlerter
{
    class RegistrySettings
    {
        private static RegistrySettings instance = null;
        private static ModifyRegistry reg = new ModifyRegistry();

        public static String pop3ServerAddress;
        public static int pop3ServerPort;
        public static String pop3UseSSL;
        public static string pop3Username;
        public static string pop3Password;

        private RegistrySettings()
        {
            reg.SubKey = "SOFTWARE\\Swdev Bali\\SupportAlerter";
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

        internal static void loadValues()
        {
            pop3ServerAddress = (string) reg.Read("pop3ServerAddress", "");
            pop3ServerPort = (int) reg.Read("pop3ServerPort", 110);
            pop3UseSSL = (String) reg.Read("pop3UseSSL", "False");
            pop3Username = (string) reg.Read("pop3Username", "");
            pop3Password = Cryptho.Decrypt((string) reg.Read("pop3Password", ""));
        }

        internal static void writeValues()
        {
            reg.Write("pop3ServerAddress", pop3ServerAddress);
            reg.Write("pop3ServerPort", pop3ServerPort);
            reg.Write("pop3UseSSL", pop3UseSSL);
            reg.Write("pop3Username", pop3Username);
            reg.Write("pop3Password", pop3Password);

        }
    }
}
