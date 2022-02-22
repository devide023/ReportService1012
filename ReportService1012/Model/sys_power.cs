using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    //产线日电能消耗、压缩空气消耗、能耗比
    public class sys_power
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime rq { get; set; }
        /// <summary>
        /// 电能消耗
        /// </summary>
        public decimal dnxh { get; set; }
        /// <summary>
        /// 压缩空气消耗
        /// </summary>
        public decimal yskqxh { get; set; }
        /// <summary>
        /// 电能比
        /// </summary>
        public decimal dnb { get; set; }
        /// <summary>
        /// 压缩空气比
        /// </summary>
        public decimal yskqb { get; set; }
    }
}
