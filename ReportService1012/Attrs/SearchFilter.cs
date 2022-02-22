using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ReportService1012.Attrs
{
    public class SearchFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                string expression = string.Empty;
                string orderexp = string.Empty;
                DynamicParameters p = new DynamicParameters();
                object obj;
                var isok = actionContext.ActionArguments.TryGetValue("parm", out obj);
                if (!isok || obj == null)
                {
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}