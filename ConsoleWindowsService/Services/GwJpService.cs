using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using log4net;
using ConsoleWindowsService.DAO;
using ConsoleWindowsService.Model;
using ConsoleWindowsService.Interfaces;

namespace ConsoleWindowsService.Services
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
                sql.Append(" select gwh as gwbh,time as jcsj ");
                sql.Append(" FROM (select gwh, time ");
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
                if(list.Count == 2)
                {
                    //当前进站时间
                    var current_jcsj = list[0].jcsj;
                    //上一次进站时间
                    var up_jcsj = list[1].jcsj;
                    jp = (current_jcsj - up_jcsj).TotalSeconds;
                }
                return new sys_gwjp()
                {
                    gwbh = gwbh,
                    gwmc = gwzd?.gwmc,
                    gwlx = gwzd?.gwfl,
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
