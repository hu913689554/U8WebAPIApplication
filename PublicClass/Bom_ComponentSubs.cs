using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Bom_ComponentSubs
{
    /// <summary>
    /// 可替代料编码
    /// </summary>
    /// <remarks>必输，最大长度 20</remarks>
    public string DInvCode { get; set; }

    /// <summary>
    /// 替代料代号(导出用)
    /// </summary>
    /// <remarks>非必输，最大长度 30</remarks>
    public string DInvAddCode { get; set; }

    /// <summary>
    /// 替代次序(默认1)
    /// </summary>
    /// <remarks>必输，int 长度 4</remarks>
    public int DSequence { get; set; }

    /// <summary>
    /// 替代比(默认1)
    /// </summary>
    /// <remarks>必输，长度 8</remarks>
    public double DFactor { get; set; }

    /// <summary>
    /// 生效日期(默认子件生效日)
    /// </summary>
    /// <remarks>必输，日期格式 长度10</remarks>
    public DateTime DEffBegDate { get; set; }

    /// <summary>
    /// 失效日期(默认子件失效日)
    /// </summary>
    /// <remarks>必输，日期格式 长度10</remarks>
    public DateTime DEffEndDate { get; set; }

    /// <summary>
    /// 替代料自由项1
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_1 { get; set; }

    /// <summary>
    /// 替代料自由项2
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_2 { get; set; }

    /// <summary>
    /// 替代料自由项3
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_3 { get; set; }

    /// <summary>
    /// 替代料自由项4
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_4 { get; set; }

    /// <summary>
    /// 替代料自由项5
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_5 { get; set; }

    /// <summary>
    /// 替代料自由项6
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_6 { get; set; }

    /// <summary>
    /// 替代料自由项7
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_7 { get; set; }

    /// <summary>
    /// 替代料自由项8
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_8 { get; set; }

    /// <summary>
    /// 替代料自由项9
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_9 { get; set; }

    /// <summary>
    /// 替代料自由项10
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvFree_10 { get; set; }

    /// <summary>
    /// 替代料自定义项1
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvDefine_1 { get; set; }

    /// <summary>
    /// 替代料自定义项2
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvDefine_2 { get; set; }

    /// <summary>
    /// 替代料自定义项3
    /// </summary>
    /// <remarks>非必输，最大长度 20</remarks>
    public string DInvDefine_3 { get; set; }

    /// <summary>
    /// 替代料自定义项4
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_4 { get; set; }

    /// <summary>
    /// 替代料自定义项5
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_5 { get; set; }

    /// <summary>
    /// 替代料自定义项6
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_6 { get; set; }

    /// <summary>
    /// 替代料自定义项7
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_7 { get; set; }

    /// <summary>
    /// 替代料自定义项8
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_8 { get; set; }

    /// <summary>
    /// 替代料自定义项9
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_9 { get; set; }

    /// <summary>
    /// 替代料自定义项10
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DInvDefine_10 { get; set; }

    /// <summary>
    /// 替代料自定义项11
    /// </summary>
    /// <remarks>非必输，int 长度 9</remarks>
    public int? DInvDefine_11 { get; set; }

    /// <summary>
    /// 替代料自定义项12
    /// </summary>
    /// <remarks>非必输，int 长度 9</remarks>
    public int? DInvDefine_12 { get; set; }

    /// <summary>
    /// 替代料自定义项13
    /// </summary>
    /// <remarks>非必输，长度 15</remarks>
    public double? DInvDefine_13 { get; set; }

    /// <summary>
    /// 替代料自定义项14
    /// </summary>
    /// <remarks>非必输，长度 15</remarks>
    public double? DInvDefine_14 { get; set; }

    /// <summary>
    /// 替代料自定义项15
    /// </summary>
    /// <remarks>非必输，日期格式 长度10</remarks>
    public DateTime? DInvDefine_15 { get; set; }

    /// <summary>
    /// 替代料自定义项16
    /// </summary>
    /// <remarks>非必输，日期格式 长度10</remarks>
    public DateTime? DInvDefine_16 { get; set; }

    /// <summary>
    /// ComponentSubId(导出用)
    /// </summary>
    /// <remarks>非必输，int 长度 4</remarks>
    public int? ComponentSubId { get; set; }

    /// <summary>
    /// 替换料(默认否)
    /// </summary>
    /// <remarks>必输，枚举：0=否，1=是</remarks>
    public int DReplaceFlag { get; set; }

    /// <summary>
    /// 工程图号(导出用)
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DBasEngineerFigNo { get; set; }

    /// <summary>
    /// 表体自定义项1
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DDefine_22 { get; set; }

    /// <summary>
    /// 表体自定义项2
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DDefine_23 { get; set; }

    /// <summary>
    /// 表体自定义项3
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DDefine_24 { get; set; }

    /// <summary>
    /// 表体自定义项4
    /// </summary>
    /// <remarks>非必输，最大长度 60</remarks>
    public string DDefine_25 { get; set; }

    /// <summary>
    /// 表体自定义项5
    /// </summary>
    /// <remarks>非必输，长度 15</remarks>
    public double? DDefine_26 { get; set; }

    /// <summary>
    /// 表体自定义项6
    /// </summary>
    /// <remarks>非必输，长度 15</remarks>
    public double? DDefine_27 { get; set; }

    /// <summary>
    /// 表体自定义项7
    /// </summary>
    /// <remarks>非必输，最大长度 120</remarks>
    public string DDefine_28 { get; set; }

    /// <summary>
    /// 表体自定义项8
    /// </summary>
    /// <remarks>非必输，最大长度 120</remarks>
    public string DDefine_29 { get; set; }

    /// <summary>
    /// 表体自定义项9
    /// </summary>
    /// <remarks>非必输，最大长度 120</remarks>
    public string DDefine_30 { get; set; }

    /// <summary>
    /// 表体自定义项10
    /// </summary>
    /// <remarks>非必输，最大长度 120</remarks>
    public string DDefine_31 { get; set; }

    /// <summary>
    /// 表体自定义项11
    /// </summary>
    /// <remarks>非必输，最大长度 120</remarks>
    public string DDefine_32 { get; set; }

    /// <summary>
    /// 表体自定义项12
    /// </summary>
    /// <remarks>非必输，最大长度 120</remarks>
    public string DDefine_33 { get; set; }

    /// <summary>
    /// 表体自定义项13
    /// </summary>
    /// <remarks>非必输，int 长度 9</remarks>
    public int? DDefine_34 { get; set; }

    /// <summary>
    /// 表体自定义项14
    /// </summary>
    /// <remarks>非必输，int 长度 9</remarks>
    public int? DDefine_35 { get; set; }

    /// <summary>
    /// 表体自定义项15
    /// </summary>
    /// <remarks>非必输，日期格式 长度10</remarks>
    public DateTime? DDefine_36 { get; set; }

    /// <summary>
    /// 表体自定义项16
    /// </summary>
    /// <remarks>非必输，日期格式 长度10</remarks>
    public DateTime? DDefine_37 { get; set; }

    /// <summary>
    /// 替代料名称(导出用)
    /// </summary>
    /// <remarks>必输，最大长度 98</remarks>
    public string DInvName { get; set; }

    /// <summary>
    /// 替代料规格(导出用)
    /// </summary>
    /// <remarks>必输，最大长度 98</remarks>
    public string DInvStd { get; set; }

    /// <summary>
    /// 计量单位编码(导出用)
    /// </summary>
    /// <remarks>必输，最大长度 10</remarks>
    public string DInvUnit { get; set; }

    /// <summary>
    /// 计量单位(导出用)
    /// </summary>
    /// <remarks>必输，最大长度 20</remarks>
    public string DInvUnitName { get; set; }

    /// <summary>
    /// 存货计量单位组类型(导出用)
    /// </summary>
    /// <remarks>非必输</remarks>
    public int? DInvGroupType { get; set; }

    /// <summary>
    /// 存货计量单位组编码(导出用)
    /// </summary>
    /// <remarks>非必输</remarks>
    public string DInvGroupCode { get; set; }

    /// <summary>
    /// 存货计量单位组名称(导出用)
    /// </summary>
    /// <remarks>非必输</remarks>
    public string DInvGroupName { get; set; }

    /// <summary>
    /// 替代物料ID(导出用)
    /// </summary>
    /// <remarks>非必输</remarks>
    public int? DPartId { get; set; }
}
