using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace ReportService1012.Interceptor
{
    public class TestCeptor : IInterceptor
    {
        private ILog log;
        public TestCeptor()
        {
            log = LogManager.GetLogger(this.GetType());
        }
        public void Intercept(IInvocation invocation)
        {
            log.Info(string.Format("Calling method {0} with parameters {1}... ", 
                invocation.Method.Name, 
                string.Join(",", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())));

            invocation.Proceed();

            log.Info(string.Format( "Done: result was {0}.", invocation.ReturnValue));
        }
    }
}
