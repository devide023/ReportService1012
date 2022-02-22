using ReportService1012.DAO;
using ReportService1012.InterFace;
using ReportService1012.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using log4net;

namespace ReportService1012.Services
{
    public class GwJpService : OracleBaseFixture,IGwJp
    {
        private ILog log;
        public GwJpService()
        {
            log = LogManager.GetLogger(this.GetType());
        }
        public sys_gwjp CalcGwJp(string gwbh)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select gwh as gwbh,engine_no,time as jcsj ");
                sql.Append(" FROM (select gwh,engine_no,time ");
                sql.Append("          from PCS_STATIONINOUT_LOG ");
                sql.Append("          where gwh = :gwbh ");
                sql.Append("          and    result = '允许' ");
                sql.Append("          and    inout = '进站' ");
                sql.Append("          and    trunc(time) = to_date('2021-12-18', 'yyyy-mm-dd') ");
                sql.Append("          order  by time desc)");
                sql.Append(" where  rownum < 3 ");
                DynamicParameters p = new DynamicParameters();
                p.Add(":gwbh", gwbh, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var list = Db.Connection.Query<sys_gwjz>(sql.ToString(), p).ToList();
                base_gwzd gwzd = Db.Connection.Query<base_gwzd>("select gcdm, scx, gwh, gwmc, gwlx, gwfl, shbz, gzty, bz, lrr, lrsj, shr, shsj, ip, khgw, dlsj, dlbbh, user_code, logenable, bdfdj, jbfdj, bdjj, jbjj, hjkagv, hjkjj, fxgwh, hxq, allowlowversion FROM base_gwzd  where  gwh = :gwbh", new { gwbh = gwbh }).FirstOrDefault();
                double jp = 0;
                StringBuilder enginesql = new StringBuilder();
                enginesql.Append("select gcdm, engine_no, bill_no, order_no, status_no, engine_type_no, batch_no, custom_no, write_req, seq_no, lsh, printer, print_time, status_flag, in_flag, sjin_flag, finish_flag, scrq, cjbj, xh, fs, syj, vin_code, vin_jmh, vin_flag, pack_no, printer_no, section_no, dybz, bxcs, bdtm, engine_no_1, num, vin_jmh_lrsj, a_xh, qgd_xh, qgd_xh_fs, v_xh, v_cx from barcode_print where engine_no = :engineno");
                barcode_print kzobj = new barcode_print();
                if (list.Count == 2)
                {
                    kzobj = Db.Connection.Query<barcode_print>(enginesql.ToString(), new { engineno = list[0].engine_no }).FirstOrDefault();
                    //当前进站时间
                    var current_jcsj = list[0].jcsj;
                    //上一次进站时间
                    var up_jcsj = list[1].jcsj;
                    jp = (current_jcsj - up_jcsj).TotalSeconds;
                }else if(list.Count == 1)
                {
                    kzobj = Db.Connection.Query<barcode_print>(enginesql.ToString(), new { engineno = list[0].engine_no }).FirstOrDefault();
                    var current_jcsj = list[0].jcsj;
                    jp = 0f;
                }
                return new sys_gwjp()
                {
                    gwbh = gwbh,
                    gwmc = gwzd?.gwmc,
                    gwlx = gwzd?.gwfl,
                    jxno = kzobj?.engine_type_no,
                    statusno = kzobj?.status_no,
                    jp = Convert.ToInt32(jp)
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
