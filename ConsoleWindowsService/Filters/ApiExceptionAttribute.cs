using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using log4net;
using Newtonsoft.Json;
namespace ConsoleWindowsService.Filters
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        private ILog log;
        public ApiExceptionAttribute()
        {
            log = LogManager.GetLogger(this.GetType());
        }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //var method = actionExecutedContext.Request.Method.Method;
            //var action = actionExecutedContext.Request.GetRouteData().Values["action"].ToString();
            //var ctrl = actionExecutedContext.Request.GetRouteData().Values["controller"].ToString();
            log.Error(actionExecutedContext.Exception.Message);
            object d = null;
            string jsonResult = JsonConvert.SerializeObject(new
            {
                code = 0,
                msg = actionExecutedContext.Exception.Message,
                data = d
            }) ;
            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(jsonResult, System.Text.Encoding.GetEncoding("UTF-8"), "application/json");
            actionExecutedContext.Response = result;
            base.OnException(actionExecutedContext);
        }
    }
}