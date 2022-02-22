using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ReportService1012.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = WebApiConfig.Register();
            builder.UseWebApi(config);
        }
    }
}
