using ConsoleWindowsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindowsService.Interfaces
{
    /// <summary>
    /// 实时岗位节拍
    /// </summary>
    interface IGwJp
    {
        sys_gwjp CalcGwJp(string gwbh);
    }
}
