using ConsoleWindowsService.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using log4net;
namespace ConsoleWindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(x =>
                {
                    x.Service<HostingConfiguration>(setting =>new HostingConfiguration(setting));
                    x.RunAsLocalService();
                    x.StartAutomatically();
                    x.SetDescription("WebApi服务");
                    x.SetDisplayName("WebApiService");
                    x.SetServiceName("ConsoleWindowsService");
                });
            }
            catch (Exception e)
            {
                LogManager.GetLogger("ConsoleWindowsService.Main").Error(e.Message);
            }
            //HostFactory.Run(x =>
            //{
            //    x.StartAutomatically();
            //    x.Service<HostingConfiguration>(t=> {
            //        t.ConstructUsing(c => new HostingConfiguration());
            //        t.WhenStarted(tc => tc.Start());
            //        t.WhenStopped(tc => tc.Stop());
            //    });
            //    x.RunAsLocalSystem();
            //    x.SetDescription("宗申MESWebApi服务,响应Web请求服务");
            //    x.SetDisplayName("ConsoleWindowsService");
            //    x.SetServiceName("ConsoleWindowsService");
            //});
        }
    }
}
