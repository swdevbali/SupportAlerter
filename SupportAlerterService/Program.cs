using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterService
{
    static class Program
    {
        public const string EventLogName = "eMail To SMS";
        private static object _lockObject = new object();
        private static int _runningTasks = 0;

        public static void PrintToConsole()
        {
            lock (_lockObject)
            {
                _runningTasks += 1;
            }
            try
            {
                EventLog.WriteEntry(Program.EventLogName, "Starting work. Total active: " + _runningTasks, EventLogEntryType.Information,1);
                var r = new Random();
                System.Threading.Thread.Sleep(r.Next(1000));//3500
            }
            finally
            {
                lock (_lockObject)
                {
                    _runningTasks -= 1;
                }
            }
        }

        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new CoreService() 
            };
            if (Environment.UserInteractive)
            {
                // This used to run the service as a console (development phase only)

                
                CoreService service = (CoreService) ServicesToRun[0];
                service.DoStart();
                Console.WriteLine("Press Enter to terminate ...");
                Console.ReadLine();

                service.DoStop();
            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
