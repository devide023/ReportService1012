using ReportService1012.InterFace;
using ReportService1012.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService1012.DAO;
using Dapper;
using log4net;
namespace ReportService1012.Services
{
    public class CalcXBSjService :OracleBaseFixture, ICalcXBSJ
    {
        private IEnumerable<sys_sctj> list = new List<sys_sctj>();
        private IEnumerable<base_jx_bzcn> cnlist = new List<base_jx_bzcn>();
        private ILog log;

        public CalcXBSjService()
        {
            log = LogManager.GetLogger(this.GetType());
            this.cnlist = Get_BZCN();
        }
        public void SetSCSLInfo()
        {
            this.list = this.Get_SCSLInfo();
        }
        /// <summary>
        /// 获取当日生产信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<sys_sctj> Get_SCSLInfo()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ta.order_no, ta.ztbm, ta.scsl, tb.stsxsj, tb.mtsxsj, ta.scsl - nvl(tb.sxsl, 0) wscsl ");
            sql.Append(" FROM(select order_no, ztbm, sum(scsl) scsl ");
            sql.Append("          FROM   base_zpjh_xh  where trunc(jhsj) = trunc(sysdate) ");
            sql.Append("          group  by ztbm, order_no ");
            sql.Append("          ) ta, (select count(engine_no) sxsl, min(print_time) stsxsj, max(print_time) mtsxsj, order_no, status_no ");
            sql.Append("          from   barcode_print ");
            sql.Append("          where trunc(print_time) = trunc(sysdate) ");
            sql.Append("          group by order_no, status_no) tb ");
            sql.Append(" where  ta.order_no = tb.order_no(+) ");
            sql.Append(" and ta.ztbm = tb.status_no(+) ");
            //查询当日装配计划
            return Db.Connection.Query<sys_sctj>(sql.ToString());
        }
        public IEnumerable<base_jx_bzcn> Get_BZCN()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select gcdm, scx, jx_no, bzcn, lrr, lrsj FROM base_jx_bzcn ");
                return Db.Connection.Query<base_jx_bzcn>(sql.ToString());
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }
        /// <summary>
        /// 通过状态码获取产能,每小时生产数量
        /// </summary>
        /// <param name="status_no"></param>
        /// <returns></returns>
        public int Get_StatusCN(string status_no)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select bzcn FROM base_jx_bzcn ta,bd_status tb ");
                sql.Append(" where ta.jx_no = tb.engine_type_no ");
                sql.Append(" and tb.status_no = :ztm ");
                var list = Db.Connection.Query(sql.ToString(), new { ztm = status_no });
                if (list.Count() > 0)
                {
                    return Convert.ToInt32(list.FirstOrDefault());
                }
                else
                {
                    return 65;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// 计算完成时间
        /// </summary>
        /// <returns></returns>
        public DateTime? GetXBSJ()
        {
            try
            {
                Get_SCSLInfo();
                double all_time_wsx = 0;
                DateTime yjwcsj = DateTime.Parse("18:30");
                foreach (sys_sctj item in list)
                {
                    var bzcn = Get_StatusCN(item.status_no);
                    log.Info("状态编码：" + item.status_no + "标准产能：" + bzcn);
                    all_time_wsx += (double)(bzcn / 60) * item.wscsl;//未上线所需时间（分钟）
                }
                //11:30-13:00 15:00-15:15
                var d0 = DateTime.Now;
                var d1 = DateTime.Parse("7:00");
                var d2 = DateTime.Parse("11:30");
                var d3 = DateTime.Parse("13:00");
                var d4 = DateTime.Parse("15:00");
                var d5 = DateTime.Parse("15:15");
                if (DateTime.Compare(d1, d0) <= 0 && DateTime.Compare(d0, d2) < 0)
                {
                    var ts1 = d3 - d2;
                    var ts2 = d5 - d4;
                    yjwcsj = DateTime.Now.AddMinutes(ts1.Minutes + ts2.Minutes).AddMinutes(all_time_wsx);
                }
                else if (DateTime.Compare(d2, d0) <= 0 && DateTime.Compare(d0, d3) < 0)
                {
                    var ts1 = d3 - d2;
                    var ts2 = d5 - d4;
                    var ts = d0 - d2;
                    var zxxsj = ts1.Minutes + ts2.Minutes;
                    yjwcsj = DateTime.Now.AddMinutes(zxxsj - ts.Minutes).AddMinutes(all_time_wsx);
                }
                else if (DateTime.Compare(d3, d0) <= 0 && DateTime.Compare(d0, d4) < 0)
                {
                    var ts = d5 - d4;
                    yjwcsj = DateTime.Now.AddMinutes(ts.Minutes).AddMinutes(all_time_wsx);
                }
                else if (DateTime.Compare(d4, d0) <= 0 && DateTime.Compare(d0, d5) < 0)
                {
                    var ts = d5 - d4;
                    var ts1 = d0 - d4;
                    yjwcsj = DateTime.Now.AddMinutes(ts.Minutes - ts1.Minutes).AddMinutes(all_time_wsx);
                }
                else if (DateTime.Compare(d5, d0) <= 0)
                {
                    yjwcsj = DateTime.Now.AddMinutes(all_time_wsx);
                }
                return yjwcsj;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
