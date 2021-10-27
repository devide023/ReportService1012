using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    public class sys_qty
    {
        /// <summary>
        /// 当日计划数量
        /// </summary>
        public int drjhsl { get; set; }
        /// <summary>
        /// 当日上线数量
        /// </summary>
        public int drsxsl { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        public DateTime? xbsj { get; set; }
    }
}
