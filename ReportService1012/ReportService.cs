using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Autofac;
using ReportService1012.Tool;
using Microsoft.Owin.Hosting;
using ReportService1012.App_Start;

namespace ReportService1012
{
    public partial class ReportService : ServiceBase
    {
        private ILog log;
        private IScheduler scheduler;
        private const string _baseAddress = "http://localhost:9001/";
        private IDisposable _server = null;
        public  ReportService()
        {
            InitializeComponent();
            log = LogManager.GetLogger(this.GetType());
            Init().GetAwaiter().GetResult();
        }

        private async Task Init()
        {
            //StdSchedulerFactory factory = new StdSchedulerFactory();
            scheduler = AutofacUtil.GetFromFac<IScheduler>();
            //scheduler = await factory.GetScheduler();
            await scheduler.Start();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                log.Info("--------启动服务---------");
                _server = WebApp.Start<StartUp>(url: _baseAddress);
                if (!scheduler.IsStarted)
                {
                    scheduler.Start();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }

        protected override void OnStop()
        {
            if (!scheduler.IsShutdown)
            {
                scheduler.Shutdown();
            }
            _server?.Dispose();
            base.OnStop();
            log.Info("--------服务停止---------");
        }

        protected override void OnPause()
        {
            scheduler.PauseAll();
            base.OnPause();
            log.Info("--------服务暂停---------");
        }
        protected override void OnContinue()
        {
            scheduler.ResumeAll();
            base.OnContinue();
            log.Info("--------服务继续---------");
        }
    }
}
