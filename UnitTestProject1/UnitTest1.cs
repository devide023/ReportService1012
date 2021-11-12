using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ReportService1012.MQ;
using ReportService1012.Model;
using Newtonsoft.Json;
using ReportService1012.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //string error = string.Empty;
            //var scz = new RabbitMQCreater("ad_scz", "zsdl1012mes", "zsdl_1012Mes", "172.16.201.228");
            //scz.CreateQueue("scjh", WorkMode.direct, out error);
            //ReportService1012.Services.QtyToMQService s = new ReportService1012.Services.QtyToMQService();
            //sys_qty entity = new sys_qty();
            //entity.drjhsl = s.GetCurJHS();
            //entity.drsxsl = s.GetCurSXS();
            //entity.xbsj = s.GetXBSJ();
            //string json = JsonConvert.SerializeObject(entity);
            //scz.Send("scjh", json,out error);
            //int i=1;
            //while(true)
            //{
            //    var j = "{i:" + (i++).ToString() + "}";
            //    scz.Send("scjh", j, out error);
            //}

            CalcXBSjService service = new CalcXBSjService();
            var sj = service.GetXBSJ();
            Console.WriteLine(sj);

        }

        [TestMethod]
        public void TestMethod2()
        {
            var xfz = new RabbitMQConsumer("ad_xfz", "zsdl1012mes", "zsdl_1012Mes", "172.16.201.228");
            xfz.SubscribeMsgFromExChange("scjh");
            xfz.ReceMsg += Xfz_ReceMsg;
        }

        private void Xfz_ReceMsg(string qname, string msg, string cName)
        {
            try
            {
                Console.WriteLine(qname);
                Console.WriteLine(msg);
                Console.WriteLine(cName);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
