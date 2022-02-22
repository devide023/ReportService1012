using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindowsService.Model
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
        /// 岗位类型
        /// </summary>
        public string gwlx { get; set; }
        /// <summary>
        /// 节拍
        /// </summary>
        public int jp { get; set; }
    }
}
