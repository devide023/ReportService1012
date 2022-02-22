using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Model
{
    public class barcode_print
    {
        /// <summary>
        ///工厂代码
        ///</summary>
        public string gcdm { get; set; }
        /// <summary>
        ///机号（完整）
        ///</summary>
        public string engine_no { get; set; }
        /// <summary>
        ///排产计划号
        ///</summary>
        public string bill_no { get; set; }
        /// <summary>
        ///生产订单号
        ///</summary>
        public string order_no { get; set; }
        /// <summary>
        ///状态号
        ///</summary>
        public string status_no { get; set; }
        /// <summary>
        ///机型
        ///</summary>
        public string engine_type_no { get; set; }
        /// <summary>
        ///批次号
        ///</summary>
        public string batch_no { get; set; }
        /// <summary>
        ///客户号
        ///</summary>
        public string custom_no { get; set; }
        /// <summary>
        ///刻字要求
        ///</summary>
        public string write_req { get; set; }
        /// <summary>
        ///机号
        ///</summary>
        public string seq_no { get; set; }
        /// <summary>
        ///计划数-打印数
        ///</summary>
        public string lsh { get; set; }
        /// <summary>
        ///打印人
        ///</summary>
        public string printer { get; set; }
        /// <summary>
        ///打印时间
        ///</summary>
        public DateTime print_time { get; set; }
        /// <summary>
        ///状态标记 （E 为生成，F打印完毕， P打印中，C 打印取消，H计调撤销 ）
        ///</summary>
        public string status_flag { get; set; }
        /// <summary>
        ///总检下线标记
        ///</summary>
        public string in_flag { get; set; }
        /// <summary>
        ///扫描入库标记
        ///</summary>
        public string sjin_flag { get; set; }
        /// <summary>
        ///包装下线标记
        ///</summary>
        public string finish_flag { get; set; }
        /// <summary>
        ///机号生成日期
        ///</summary>
        public DateTime scrq { get; set; }
        /// <summary>
        ///抽检标志（N不检， A性能检， B挂车检， C生产检）
        ///</summary>
        public string cjbj { get; set; }
        /// <summary>
        ///对应箱号
        ///</summary>
        public string xh { get; set; }
        /// <summary>
        ///箱条码打印份数
        ///</summary>
        public int fs { get; set; }
        /// <summary>
        ///打刻生产线（实验机  --原值为空）
        ///</summary>
        public string syj { get; set; }
        /// <summary>
        ///防伪码
        ///</summary>
        public string vin_code { get; set; }
        /// <summary>
        ///防伪码加密
        ///</summary>
        public string vin_jmh { get; set; }
        /// <summary>
        ///打刻标记 （E 为生成, F打印完毕， P打印中，C 打印取消，H重复打印 ， S 扫描验证）
        ///</summary>
        public string vin_flag { get; set; }
        /// <summary>
        ///小包装号
        ///</summary>
        public string pack_no { get; set; }
        /// <summary>
        ///打刻头
        ///</summary>
        public string printer_no { get; set; }
        /// <summary>
        ///
        ///</summary>
        public string section_no { get; set; }
        /// <summary>
        ///
        ///</summary>
        public string dybz { get; set; }
        /// <summary>
        ///示波器波形参数
        ///</summary>
        public string bxcs { get; set; }
        /// <summary>
        ///
        ///</summary>
        public string bdtm { get; set; }
        /// <summary>
        ///
        ///</summary>
        public string engine_no_1 { get; set; }
        /// <summary>
        ///真伪查询次数
        ///</summary>
        public int num { get; set; }
        /// <summary>
        ///
        ///</summary>
        public DateTime vin_jmh_lrsj { get; set; }
        /// <summary>
        ///安第斯客户箱号
        ///</summary>
        public string a_xh { get; set; }
        /// <summary>
        ///清关单序号
        ///</summary>
        public string qgd_xh { get; set; }
        /// <summary>
        ///份数
        ///</summary>
        public int qgd_xh_fs { get; set; }
        /// <summary>
        ///VENTO流水号
        ///</summary>
        public string v_xh { get; set; }
        /// <summary>
        ///VENTO车型
        ///</summary>
        public string v_cx { get; set; }
    }
}
