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

       
        public static int emailCheckInterval;

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

        internal static void loadValues()
        {
            emailCheckInterval = (int)reg.Read("emailCheckInterval", 1);//in minutes
           
        }

        internal static void writeValues()
        {
            reg.Write("emailCheckInterval", emailCheckInterval);

        }
    }
}
