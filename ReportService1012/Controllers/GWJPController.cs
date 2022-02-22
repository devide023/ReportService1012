using ReportService1012.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ReportService1012.Controllers
{
    /// <summary>
    /// 岗位实际节拍控制器
    /// </summary>
    /// 
    [RoutePrefix("api/jp")]
    public class GWJPController:ApiController
    {
        [HttpGet,Route("gw")]
        public IHttpActionResult RealGwJp(string gwbh)
        {
            try
            {
                var jpinfo = new GwJpService().CalcGwJp(gwbh);
                return Json(new { code = 1, msg = "ok", data = jpinfo });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
