using ConsoleWindowsService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleWindowsService.Controllers
{
    [RoutePrefix("api/demo")]
    public class TestController: ApiController
    {
        public TestController()
        {

        }
        [HttpGet,Route("m1")]
        public IHttpActionResult Test(string gwbh)
        {
            try
            {
                GwJpService s = new GwJpService();
                var info = s.CalcGwJp(gwbh);
                return Json(new { code = 1, msg = "ok", data = info });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
