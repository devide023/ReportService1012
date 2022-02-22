using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ReportService1012.MQ;
using ReportService1012.Model;
using Newtonsoft.Json;
using ReportService1012.Services;
using System.Collections.Generic;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string error = string.Empty;
            List<sys_ztsl> ztlist = new List<sys_ztsl>();
            ztlist.Add(new sys_ztsl()
            {
                ztbm= "1MXMC4018",
                plan_qty = 150,
                sx_qty=100,
            });
            ztlist.Add(new sys_ztsl()
            {
                ztbm = "1MXMC4033",
                plan_qty = 100,
                sx_qty=50
            });
            ztlist.Add(new sys_ztsl()
            {
                ztbm = "1MMZZ0597",
                plan_qty = 50,
                sx_qty=10
            });
            QtyToMQService _curqty = new QtyToMQService();
            sys_qty entity = new sys_qty();
            entity.zt_qty = ztlist;//_curqty.ZT_Qty();
            string json = JsonConvert.SerializeObject(entity);
            MQManager.Instance.Creator("OrderInfo", out error);
            
            MQManager.Instance.MQCreater.Send("OrderInfo", json, out error);

        }
        [TestMethod]
        public void TestPower()
        {
            sys_power power = new sys_power();
            power.rq = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            power.dnxh = 200.00m;
            power.yskqxh = 100.00m;
            power.dnb = 0.89m;
            power.yskqb = 0.90m;
            var json = JsonConvert.SerializeObject(power);
            Console.WriteLine(json);
        }
        [TestMethod]
        public void TestProduce()
        {
            sys_produce_info entity = new sys_produce_info();
            List< sys_produce > list = new List<sys_produce>();


            list.Add(new sys_produce()
            {
                gwh= "U01-OP010",
                gwmc= "曲轴箱组合上件",
                jgs=121,
                hgl=0.98m,
            });
            list.Add(new sys_produce()
            {
                gwh = "U01-OP020",
                gwmc = "激光刻字",
                jgs = 121,
                hgl = 1m,
            });
            list.Add(new sys_produce()
            {
                gwh = "U02-OP010",
                gwmc = "左曲轴箱组合压装",
                jgs = 121,
                hgl = 0.98m,
            });
            list.Add(new sys_produce()
            {
                gwh = "U02-OP020",
                gwmc = "右曲轴箱组合压装",
                jgs = 121,
                hgl = 0.98m,
            });
            list.Add(new sys_produce()
            {
                gwh = "U02-OP030",
                gwmc = "左曲轴箱组合压装",
                jgs = 121,
                hgl = 0.98m,
            });
            list.Add(new sys_produce()
            {
                gwh = "U02-OP040",
                gwmc = "右曲轴箱组合压装",
                jgs = 121,
                hgl = 0.98m,
            });
            entity.produceinfo = list;
            var json = JsonConvert.SerializeObject(entity);
            Console.WriteLine(json);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var xfz = new RabbitMQConsumer("ad_xfz", "zsdl1012mes", "zsdl_1012Mes", "172.16.201.228");
            xfz.SubscribeMsgFromExChange("OrderInfo");
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
