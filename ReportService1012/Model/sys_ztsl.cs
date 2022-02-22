using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    /// <summary>
    /// 状态数量
    /// </summary>
    public class sys_ztsl
    {
        /// <summary>
        /// 状态编码
        /// </summary>
        public string ztbm { get; set; }
        /// <summary>
        /// 状态计划数量
        /// </summary>
        public int plan_qty { get; set; }
        /// <summary>
        /// 状态上线数量
        /// </summary>
        public int sx_qty { get; set; }
    }
}
