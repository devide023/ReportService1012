using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService1012.DAO;
using ReportService1012.InterFace;
using log4net;
using Dapper;
using Autofac.Extras.DynamicProxy;
using ReportService1012.Interceptor;
using ReportService1012.Model;

namespace ReportService1012.Services
{
    //[Intercept(typeof(TestCeptor))]
    public class QtyToMQService : OracleBaseFixture, ICurQty
    {
        private ILog log;
        public QtyToMQService()
        {
            log = LogManager.GetLogger(this.GetType());
        }
        /// <summary>
        /// 当日计划数量
        /// </summary>
        /// <returns></returns>
        public int GetCurJHS()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select nvl(sum(scsl),0) as scsl from PP_ZPJH  where jhsj = trunc(sysdate) ");
                return Db.Connection.ExecuteScalar<int>(sql.ToString());
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }
        /// <summary>
        /// 当日上线数量
        /// </summary>
        /// <returns></returns>
        public int GetCurSXS()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select count(engine_no) FROM   v_barcode_print where  trunc(print_time) = trunc(sysdate)");
                return Db.Connection.ExecuteScalar<int>(sql.ToString());
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }
        
    }
}
