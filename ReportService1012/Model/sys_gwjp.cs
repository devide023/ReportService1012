using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    public class sys_gwjp
    {
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string gwbh { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string gwmc { get; set; }
        /// <summary>
        /// 岗位分类
        /// </summary>
        public string gwlx { get; set; }
        /// <summary>
        /// 机型编号
        /// </summary>
        public string jxno { get; set; }
        /// <summary>
        /// 状态编码
        /// </summary>
        public string statusno { get; set; }
        /// <summary>
        /// 节拍
        /// </summary>
        public int jp { get; set; }
    }
}
