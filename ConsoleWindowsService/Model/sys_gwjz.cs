using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindowsService.Model
{
    /// <summary>
    /// 岗位进站
    /// </summary>
    public class sys_gwjz
    {
        /// <summary>
        /// 岗位编码
        /// </summary>
        public string gwbh { get; set; }
        /// <summary>
        /// 进站时间
        /// </summary>
        public DateTime jcsj { get; set; }
    }
}
