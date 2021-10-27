using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.InterFace
{
    /// <summary>
    /// 计算下班时间
    /// </summary>
    public interface ICalcXBSJ
    {
        DateTime? GetXBSJ();
    }
}
