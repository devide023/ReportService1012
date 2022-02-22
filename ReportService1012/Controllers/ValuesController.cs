using ReportService1012.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
namespace ReportService1012.Controllers
{
    [RoutePrefix("api/test")]
    public class ValuesController: ApiController
    {
        [HttpGet,Route("m1")]
        public IHttpActionResult Get()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    var t = i*10 / i;
                }                
                return Json(new { code = 1, msg = "ok" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost, Route("m2")]
        public IHttpActionResult TestM2(sys_test t)
        {
            try
            {
                return Json(new { code = 1, msg = JsonConvert.SerializeObject(t) });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
