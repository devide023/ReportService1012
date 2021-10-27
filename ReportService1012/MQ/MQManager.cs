using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.MQ
{     
    public class MQManager
    {
        private static MQManager instance = null;
        public static RabbitMQCreater MQCreater;
        private static readonly object padlock = new object();
        private MQManager()
        {
            MQCreater = new RabbitMQCreater("ad_scz", "zsdl1012mes", "zsdl_1012Mes", "172.16.201.228");
        }
        public static MQManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MQManager();
                        }
                    }
                }
                return instance;
            }
        }
        public bool Creator(string queuename,out string error)
        {
            error = string.Empty;
            return MQCreater.CreateQueue(queuename, WorkMode.fanout, out error);

        }
    }
}
