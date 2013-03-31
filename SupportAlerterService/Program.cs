using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterService
{
    static class Program
    {
        public const string EventLogName = "SMS Alert from eMail";

        static void Main(string[] args)
        {
            if (System.Environment.UserInteractive)
            {
                if (args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "i":
                            {
                                ServiceController ctl = ServiceController.GetServices().Where(s => s.ServiceName == Program.EventLogName).FirstOrDefault();
                                if (ctl != null)
                                {
                                    Console.WriteLine("Existing service detected, uninstalling...");
                                    ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                                }
                                ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });

                                break;
                            }

                        case "u":
                            {
                                ServiceController ctl = ServiceController.GetServices().Where(s => s.ServiceName == Program.EventLogName).FirstOrDefault();
                                if (ctl != null)
                                {
                                    Console.WriteLine("Existing service detected, uninstalling...");
                                    ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                                }
                                else
                                {
                                    Console.WriteLine("Service not detected");
                                }
                                break;
                            }

                        case "c":
                            {
                                CoreService service = new CoreService();
                                service.DoStart();
                                Console.WriteLine("Press Enter to terminate ...");
                                Console.ReadLine();
                                service.DoStop();
                                break;
                            }
                    }
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new CoreService() };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
