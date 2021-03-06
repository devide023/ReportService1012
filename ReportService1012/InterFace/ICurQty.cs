using ReportService1012.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.InterFace
{
    /// <summary>
    /// 查询今日计划数量，上线数量
    /// </summary>
    public interface ICurQty
    {
        /// <summary>
        /// 计划数量
        /// </summary>
        /// <returns></returns>
        int Plan_Qty();
        /// <summary>
        /// 上线数量
        /// </summary>
        /// <returns></returns>
        int SX_Qty();
        /// <summary>
        /// 状态数量
        /// </summary>
        /// <returns></returns>
        IEnumerable<sys_ztsl> ZT_Qty();
    }
}
