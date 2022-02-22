using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    public class sys_produce
    {
        /// <summary>
        /// 岗位号
        /// </summary>
        public string gwh { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string gwmc { get; set; }
        /// <summary>
        /// 加工数
        /// </summary>
        public int jgs { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        public decimal hgl { get; set; }
    }
}
