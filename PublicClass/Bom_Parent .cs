using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    public class Bom_Parent
    {
    /// <summary> 主键 </summary>
    public int BomId { get; set; }

    /// <summary> 差异更新(更新时使用) 0-否,1-是 </summary>
    public int? UpdateByDiff { get; set; }

    /// <summary> ParentId(导出用) </summary>
    public int? PartId { get; set; }

    /// <summary> BOM类别(1主2替代) 1-主BOM,2-替代BOM,3-不选,4-客户BOM,7-委外商BOM </summary>
    public int? BomType { get; set; }

    /// <summary> 母件编码 </summary>
    public string InvCode { get; set; }

    /// <summary> 工程图号(导出用) </summary>
    public string BasEngineerFigNo { get; set; }

    /// <summary> 母件损耗率(％0~99) </summary>
    public double? ParentScrap { get; set; }

    /// <summary> 版本代号 </summary>
    public int? Version { get; set; }

    /// <summary> 版本说明 </summary>
    public string VersionDesc { get; set; }

    /// <summary> 版本日期(YYYY-MM-DD) </summary>
    public string VersionEffDate { get; set; }

    /// <summary> 替代标识 </summary>
    public string IdentCode { get; set; }

    /// <summary> 替代说明 </summary>
    public string IdentDesc { get; set; }

    /// <summary> 母件代号(导出用) </summary>
    public string InvAddCode { get; set; }

    /// <summary> 母件自由项1 </summary>
    public string InvFree_1 { get; set; }

    /// <summary> 母件自由项2 </summary>
    public string InvFree_2 { get; set; }

    /// <summary> 母件自由项3 </summary>
    public string InvFree_3 { get; set; }

    /// <summary> 母件自由项4 </summary>
    public string InvFree_4 { get; set; }

    /// <summary> 母件自由项5 </summary>
    public string InvFree_5 { get; set; }

    /// <summary> 母件自由项6 </summary>
    public string InvFree_6 { get; set; }

    /// <summary> 母件自由项7 </summary>
    public string InvFree_7 { get; set; }

    /// <summary> 母件自由项8 </summary>
    public string InvFree_8 { get; set; }

    /// <summary> 母件自由项9 </summary>
    public string InvFree_9 { get; set; }

    /// <summary> 母件自由项10 </summary>
    public string InvFree_10 { get; set; }

    /// <summary> BOM自定义项1 </summary>
    public string Define_1 { get; set; }

    /// <summary> BOM自定义项2 </summary>
    public string Define_2 { get; set; }

    /// <summary> BOM自定义项3 </summary>
    public string Define_3 { get; set; }

    /// <summary> BOM自定义项4 </summary>
    public string Define_4 { get; set; }

    /// <summary> BOM自定义项5 </summary>
    public int? Define_5 { get; set; }

    /// <summary> BOM自定义项6 </summary>
    public string Define_6 { get; set; }

    /// <summary> BOM自定义项7 </summary>
    public double? Define_7 { get; set; }

    /// <summary> BOM自定义项8 </summary>
    public string Define_8 { get; set; }

    /// <summary> BOM自定义项9 </summary>
    public string Define_9 { get; set; }

    /// <summary> BOM自定义项10 </summary>
    public string Define_10 { get; set; }

    /// <summary> BOM自定义项11 </summary>
    public string Define_11 { get; set; }

    /// <summary> BOM自定义项12 </summary>
    public string Define_12 { get; set; }

    /// <summary> BOM自定义项13 </summary>
    public string Define_13 { get; set; }

    /// <summary> BOM自定义项14 </summary>
    public string Define_14 { get; set; }

    /// <summary> BOM自定义项15 </summary>
    public int? Define_15 { get; set; }

    /// <summary> BOM自定义项16 </summary>
    public double? Define_16 { get; set; }

    /// <summary> 母件自定义项1 </summary>
    public string InvDefine_1 { get; set; }

    /// <summary> 母件自定义项2 </summary>
    public string InvDefine_2 { get; set; }

    /// <summary> 母件自定义项3 </summary>
    public string InvDefine_3 { get; set; }

    /// <summary> 母件自定义项4 </summary>
    public string InvDefine_4 { get; set; }

    /// <summary> 母件自定义项5 </summary>
    public string InvDefine_5 { get; set; }

    /// <summary> 母件自定义项6 </summary>
    public string InvDefine_6 { get; set; }

    /// <summary> 母件自定义项7 </summary>
    public string InvDefine_7 { get; set; }

    /// <summary> 母件自定义项8 </summary>
    public string InvDefine_8 { get; set; }

    /// <summary> 母件自定义项9 </summary>
    public string InvDefine_9 { get; set; }

    /// <summary> 母件自定义项10 </summary>
    public string InvDefine_10 { get; set; }

    /// <summary> 母件自定义项11 </summary>
    public int? InvDefine_11 { get; set; }

    /// <summary> 母件自定义项12 </summary>
    public int? InvDefine_12 { get; set; }

    /// <summary> 母件自定义项13 </summary>
    public double? InvDefine_13 { get; set; }

    /// <summary> 母件自定义项14 </summary>
    public double? InvDefine_14 { get; set; }

    /// <summary> 母件自定义项15 </summary>
    public string InvDefine_15 { get; set; }

    /// <summary> 母件自定义项16 </summary>
    public string InvDefine_16 { get; set; }

    /// <summary> 母件名称(导出用) </summary>
    public string InvName { get; set; }

    /// <summary> 规格型号(导出用) </summary>
    public string InvStd { get; set; }

    /// <summary> 计量单位(导出用) </summary>
    public string InvUnitName { get; set; }

    /// <summary> 计量单位编码(导出用) </summary>
    public string InvUnit { get; set; }

    /// <summary> 建档人(导出用) </summary>
    public string CreateUser { get; set; }

    /// <summary> 修改人(导出用) </summary>
    public string ModifyUser { get; set; }

    /// <summary> 建档日期(导出用) </summary>
    public string CreateDate { get; set; }

    /// <summary> 修改日期(导出用) </summary>
    public string ModifyDate { get; set; }

    /// <summary> 状态(导出用) </summary>
    public int? BomState { get; set; }

    /// <summary> 修改时间(导出用) </summary>
    public string ModifyTime { get; set; }

    /// <summary> 创建时间(导出用) </summary>
    public string CreateTime { get; set; }

    /// <summary> 审核人(导出用) </summary>
    public string RelsUser { get; set; }

    /// <summary> 审核日期(导出用) </summary>
    public string RelsDate { get; set; }

    /// <summary> 审核时间(导出用) </summary>
    public string RelsTime { get; set; }

    /// <summary> 停用人(导出用) </summary>
    public string CloseUser { get; set; }

    /// <summary> 停用日期(导出用) </summary>
    public string CloseDate { get; set; }

    /// <summary> 停用时间(导出用) </summary>
    public string CloseTime { get; set; }

    /// <summary> 版本失效日期(导出用) </summary>
    public string VersionEndDate { get; set; }

    /// <summary> 存货计量单位组类型(导出用) </summary>
    public int? InvGroupType { get; set; }

    /// <summary> 存货量单位组编码(导出用) </summary>
    public string InvGroupCode { get; set; }

    /// <summary> 存货计量单位名称(导出用) </summary>
    public string InvGroupName { get; set; }

    public List<Bom_Component> bomcomponentList { get; set; }
}
