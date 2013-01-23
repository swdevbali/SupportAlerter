using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SupportAlerterService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
      
        public ProjectInstaller()
        {
            InitializeComponent();

            if (!CheckSourceExists(Program.EventLogName))
            {
                EventLog.CreateEventSource(Program.EventLogName, Program.EventLogName);
            }
            EventLogInstaller installer = FindInstaller(this.Installers);
            if (installer != null)
            {
                installer.Log = Program.EventLogName;
            }
        }

        private static bool CheckSourceExists(string source)
        {
            if (EventLog.SourceExists(source))
            {
                EventLog evLog = new EventLog { Source = source };
                if (evLog.Log != Program.EventLogName)
                {
                    EventLog.DeleteEventSource(source);
                }
            }

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, Program.EventLogName);
                EventLog.WriteEntry(source, String.Format("Event Log Created '{0}'/'{1}'", Program.EventLogName, source), EventLogEntryType.Information);
            }

            return EventLog.SourceExists(source);
        }

        

        private EventLogInstaller FindInstaller(InstallerCollection installers)
        {
            foreach (Installer installer in installers)
            {
                if (installer is EventLogInstaller)
                {
                    return (EventLogInstaller)installer;
                }

                EventLogInstaller eventLogInstaller = FindInstaller(installer.Installers);
                if (eventLogInstaller != null)
                {
                    return eventLogInstaller;
                }
            }
            return null;
        }

        private void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController(Program.EventLogName);
            sc.Start();
        }
    }
}
