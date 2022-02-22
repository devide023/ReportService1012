using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindowsService.Model
{
    public class base_gwzd
    {
        /// <summary>
        ///工厂
        ///</summary>
        public string gcdm { get; set; }
        /// <summary>
        ///生产线
        ///</summary>
        public string scx { get; set; }
        /// <summary>
        ///岗位编码
        ///</summary>
        public string gwh { get; set; }
        /// <summary>
        ///岗位名称
        ///</summary>
        public string gwmc { get; set; }
        /// <summary>
        ///岗位分类（部装、装配、测试、返工）
        ///</summary>
        public string gwlx { get; set; }
        /// <summary>
        ///岗位分类（人工、自动）
        ///</summary>
        public string gwfl { get; set; }
        /// <summary>
        ///审核标志（Y已审核 N未审核）
        ///</summary>
        public string shbz { get; set; }
        /// <summary>
        ///故障停用（Y停用 N启用）
        ///</summary>
        public string gzty { get; set; }
        /// <summary>
        ///备注
        ///</summary>
        public string bz { get; set; }
        /// <summary>
        ///录入人
        ///</summary>
        public string lrr { get; set; }
        /// <summary>
        ///录入时间
        ///</summary>
        public DateTime lrsj { get; set; }
        /// <summary>
        ///审核人
        ///</summary>
        public string shr { get; set; }
        /// <summary>
        ///审核时间
        ///</summary>
        public DateTime shsj { get; set; }
        /// <summary>
        ///PCS人工岗位PCIP
        ///</summary>
        public string ip { get; set; }
        /// <summary>
        ///看护岗位
        ///</summary>
        public string khgw { get; set; }
        /// <summary>
        ///最后登录时间
        ///</summary>
        public DateTime dlsj { get; set; }
        /// <summary>
        ///最后登录PCS客户端版本号
        ///</summary>
        public string dlbbh { get; set; }
        /// <summary>
        ///最后登录员工代码
        ///</summary>
        public string user_code { get; set; }
        /// <summary>
        ///PCS客户端日志记录等级标识（0 1 2）
        ///</summary>
        public string logenable { get; set; }
        /// <summary>
        ///绑定发动机（Y/N）
        ///</summary>
        public string bdfdj { get; set; }
        /// <summary>
        ///解绑发动机（Y/N）
        ///</summary>
        public string jbfdj { get; set; }
        /// <summary>
        ///绑定夹具（Y/N）
        ///</summary>
        public string bdjj { get; set; }
        /// <summary>
        ///解绑夹具（Y/N）
        ///</summary>
        public string jbjj { get; set; }
        /// <summary>
        ///呼叫空AGV（Y/N）
        ///</summary>
        public string hjkagv { get; set; }
        /// <summary>
        ///呼叫空夹具（Y/N）
        ///</summary>
        public string hjkjj { get; set; }
        /// <summary>
        ///默认返修岗位号
        ///</summary>
        public string fxgwh { get; set; }
        /// <summary>
        ///合箱前（Y/N）
        ///</summary>
        public string hxq { get; set; }
        /// <summary>
        ///是否允许更新程序
        ///</summary>
        public string allowlowversion { get; set; }
    }
}
