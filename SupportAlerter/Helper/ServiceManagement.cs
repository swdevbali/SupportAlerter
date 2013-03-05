using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace SupportAlerter.Helper
{
    class ServiceManagement
    {
        private static string SERVICENAME = "SMS Alert from eMail";
        public static string getServiceStatus()
        {
            ServiceController sc = new ServiceController(SERVICENAME);
            try
            {
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return "Running";
                    case ServiceControllerStatus.Stopped:
                        return "Stopped";
                    case ServiceControllerStatus.Paused:
                        return "Paused";
                    case ServiceControllerStatus.StopPending:
                        return "Stopping";
                    case ServiceControllerStatus.StartPending:
                        return "Starting";
                    default:
                        return "Status Changing";
                }
            }
            catch (Exception)
            {
                return "Service is not installed";
            }
        }


        internal static void stopService()
        {
            ServiceController sc = new ServiceController(SERVICENAME);
            sc.Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
        }

        internal static void startService()
        {
            ServiceController sc = new ServiceController(SERVICENAME);
            sc.Start();
            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
        }
    }

   
}
