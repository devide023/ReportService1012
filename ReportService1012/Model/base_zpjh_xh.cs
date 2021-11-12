using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    public class base_zpjh_xh
    {
        /// <summary>
        /// 生产订单号
        /// </summary>
        public string order_no { get; set; }
        public int xh { get; set; }
        /// <summary>
        /// 计划时间
        /// </summary>
        public DateTime jhsj { get; set; }
        /// <summary>
        /// 生产数量
        /// </summary>
        public int scsl { get; set; }
        /// <summary>
        /// 状态编码
        /// </summary>
        public string ztbm { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string jx { get; set; }
        /// <summary>
        /// 生产线
        /// </summary>
        public string scx { get; set; }
        public string gcdm { get; set; }
    }
}
