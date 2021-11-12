using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    /// <summary>
    /// 生产数量统计
    /// </summary>
    public class sys_sctj
    {
        public string order_no { get; set; }
        public string status_no { get; set; }
        /// <summary>
        /// 技术数
        /// </summary>
        public int jhsl { get; set; }
        /// <summary>
        /// 上线数
        /// </summary>
        public int sxsl { get; set; }
        /// <summary>
        /// 未完成数，剩余数
        /// </summary>
        public int wscsl { get; set; }
        /// <summary>
        /// 首台上线时间
        /// </summary>
        public DateTime stsj { get; set; }
        /// <summary>
        /// 末台上线时间
        /// </summary>
        public DateTime mtsj { get; set; }
    }
}
