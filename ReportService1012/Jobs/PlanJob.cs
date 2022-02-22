using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using log4net;
using ReportService1012.InterFace;
using ReportService1012.Model;
using Newtonsoft.Json;
using ReportService1012.MQ;

namespace ReportService1012.Jobs
{
    public class PlanJob : IJob
    {
        private ILog log;
        private ICalcXBSJ _calxbsj;
        private ICurQty _curqty;
        private string error = string.Empty;
        public PlanJob(ICalcXBSJ calxbsj, ICurQty curqty)
        {
            log = LogManager.GetLogger(this.GetType());
            _curqty = curqty;
            _calxbsj = calxbsj;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                return Task.Run(() =>
                {
                    sys_qty entity = new sys_qty();
                    entity.zt_qty = _curqty.ZT_Qty();
                    string json = JsonConvert.SerializeObject(entity);
                    log.Info("当前任务ID：" + Task.CurrentId.ToString());
                    MQManager.Instance.Creator("OrderInfo",out error);
                    log.Info("_creator hash:" + MQManager.Instance.MQCreater.GetHashCode());
                    MQManager.Instance.MQCreater.Send("OrderInfo", json, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        log.Error(error);
                    }
                    log.Info(json);
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
