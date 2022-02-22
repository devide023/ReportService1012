using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Runtime;

namespace ConsoleWindowsService.App_Start
{
    public class HostingConfiguration: ServiceControl
    {
        private HostSettings _settings;
        private IDisposable _webApplication;
        public HostingConfiguration(HostSettings settings)
        {
            _settings = settings;
        }
        public bool Start(HostControl hostControl)
        {
            _webApplication = WebApp.Start<OwinConfiguration>("http://localhost:9002");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _webApplication?.Dispose();
            return true;
        }
    }
}
