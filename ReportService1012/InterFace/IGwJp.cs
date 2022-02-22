using ReportService1012.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.InterFace
{
    /// <summary>
    /// 实时岗位节拍
    /// </summary>
    interface IGwJp
    {
        sys_gwjp CalcGwJp(string gwbh);
    }
}
