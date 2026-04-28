using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Bom_Component
{
    /// <summary> 备注 </summary>
    public string DRemark { get; set; }

    /// <summary> 子件行号(默认系统自增) </summary>
    public int? DSortSeq { get; set; }

    /// <summary> 工序行号(默认0000) </summary>
    public string DOpSeq { get; set; }

    /// <summary> 子件编码 </summary>
    public string DInvCode { get; set; }

    /// <summary> 子件代号(导出用) </summary>
    public string DInvAddCode { get; set; }

    /// <summary> 基本用量(默认1) </summary>
    public double? DBaseQtyN { get; set; }

    /// <summary> 基础数量(默认1) </summary>
    public double? DBaseQtyD { get; set; }

    /// <summary> 子件损耗率％(默认0) </summary>
    public double? DCompScrap { get; set; }

    /// <summary> 固定用量(默认固定) 0-是,1-否 </summary>
    public int? DFVFlag { get; set; }

    /// <summary> 供应类型(默认领用) 1-入库倒冲,2-工序倒冲,3-领用,4-虚拟件,5-直接供应 </summary>
    public int? DWIPType { get; set; }

    /// <summary> 生效日期(默认母件生效日) </summary>
    public string DEffBegDate { get; set; }

    /// <summary> 失效日期(默认2099-12-31) </summary>
    public string DEffEndDate { get; set; }

    /// <summary> 偏置期(默认不偏置) </summary>
    public int? DOffset { get; set; }

    /// <summary> 计划比例％(默认100) </summary>
    public double? DPlanRate { get; set; }

    /// <summary> 产出品(默认否) 0-否,1-是 </summary>
    public int? DByproductFlag { get; set; }

    /// <summary> 成本相关 0-否,1-是 </summary>
    public int? DAccuCostFlag { get; set; }

    /// <summary> 是否可选(默认全选) 0-否,1-是 </summary>
    public int? DOptionalFlag { get; set; }

    /// <summary> 选择规则(默认全选) 1-一个,2-全部,3-任意,4-至少一个 </summary>
    public int? DMutexRule { get; set; }

    /// <summary> 仓库编码(默认子件存货档案) </summary>
    public string DWhCode { get; set; }

    /// <summary> 领料部门(默认为子件存货档案) </summary>
    public string DDeptCode { get; set; }

    /// <summary> 子件自由项1 </summary>
    public string DInvFree_1 { get; set; }

    /// <summary> 子件自由项2 </summary>
    public string DInvFree_2 { get; set; }

    /// <summary> 子件自由项3 </summary>
    public string DInvFree_3 { get; set; }

    /// <summary> 子件自由项4 </summary>
    public string DInvFree_4 { get; set; }

    /// <summary> 子件自由项5 </summary>
    public string DInvFree_5 { get; set; }

    /// <summary> 子件自由项6 </summary>
    public string DInvFree_6 { get; set; }

    /// <summary> 子件自由项7 </summary>
    public string DInvFree_7 { get; set; }

    /// <summary> 子件自由项8 </summary>
    public string DInvFree_8 { get; set; }

    /// <summary> 子件自由项9 </summary>
    public string DInvFree_9 { get; set; }

    /// <summary> 子件自由项10 </summary>
    public string DInvFree_10 { get; set; }

    /// <summary> 子件自定义项1 </summary>
    public string DInvDefine_1 { get; set; }

    /// <summary> 子件自定义项2 </summary>
    public string DInvDefine_2 { get; set; }

    /// <summary> 子件自定义项3 </summary>
    public string DInvDefine_3 { get; set; }

    /// <summary> 子件自定义项4 </summary>
    public string DInvDefine_4 { get; set; }

    /// <summary> 子件自定义项5 </summary>
    public string DInvDefine_5 { get; set; }

    /// <summary> 子件自定义项6 </summary>
    public string DInvDefine_6 { get; set; }

    /// <summary> 子件自定义项7 </summary>
    public string DInvDefine_7 { get; set; }

    /// <summary> 子件自定义项8 </summary>
    public string DInvDefine_8 { get; set; }

    /// <summary> 子件自定义项9 </summary>
    public string DInvDefine_9 { get; set; }

    /// <summary> 子件自定义项10 </summary>
    public string DInvDefine_10 { get; set; }

    /// <summary> 子件自定义项11 </summary>
    public int? DInvDefine_11 { get; set; }

    /// <summary> 子件自定义项12 </summary>
    public int? DInvDefine_12 { get; set; }

    /// <summary> 子件自定义项13 </summary>
    public double? DInvDefine_13 { get; set; }

    /// <summary> 子件自定义项14 </summary>
    public double? DInvDefine_14 { get; set; }

    /// <summary> 子件自定义项15 </summary>
    public string DInvDefine_15 { get; set; }

    /// <summary> 子件自定义项16 </summary>
    public string DInvDefine_16 { get; set; }

    /// <summary> 替换日期(导出用) </summary>
    public string DSubDate { get; set; }

    /// <summary> 辅助单位编码 </summary>
    public string DAuxUnitCode { get; set; }

    /// <summary> 换算率 </summary>
    public double? DChangeRate { get; set; }

    /// <summary> 辅助基本用量 </summary>
    public double? DAuxBaseQtyN { get; set; }

    /// <summary> 产出类型(默认空，受是否产出品约束) 1-,2-联产品,3-副产品 </summary>
    public int? DProductType { get; set; }

    /// <summary> 工程图号(导出用) </summary>
    public string DBasEngineerFigNo { get; set; }

    /// <summary> BOM表体自定义项1 </summary>
    public string DDefine_22 { get; set; }

    /// <summary> BOM表体自定义项2 </summary>
    public string DDefine_23 { get; set; }

    /// <summary> BOM表体自定义项3 </summary>
    public string DDefine_24 { get; set; }

    /// <summary> BOM表体自定义项4 </summary>
    public string DDefine_25 { get; set; }

    /// <summary> BOM表体自定义项5 </summary>
    public double? DDefine_26 { get; set; }

    /// <summary> BOM表体自定义项6 </summary>
    public double? DDefine_27 { get; set; }

    /// <summary> BOM表体自定义项7 </summary>
    public string DDefine_28 { get; set; }

    /// <summary> BOM表体自定义项8 </summary>
    public string DDefine_29 { get; set; }

    /// <summary> BOM表体自定义项9 </summary>
    public string DDefine_30 { get; set; }

    /// <summary> BOM表体自定义项10 </summary>
    public string DDefine_31 { get; set; }

    /// <summary> BOM表体自定义项11 </summary>
    public string DDefine_32 { get; set; }

    /// <summary> BOM表体自定义项12 </summary>
    public string DDefine_33 { get; set; }

    /// <summary> BOM表体自定义项13 </summary>
    public int? DDefine_34 { get; set; }

    /// <summary> BOM表体自定义项14 </summary>
    public int? DDefine_35 { get; set; }

    /// <summary> BOM表体自定义项15 </summary>
    public string DDefine_36 { get; set; }

    /// <summary> BOM表体自定义项16 </summary>
    public string DDefine_37 { get; set; }

    /// <summary> 计量单位组(导出用) </summary>
    public string DInvGroupCode { get; set; }

    /// <summary> 子件名称(导出用) </summary>
    public string DInvName { get; set; }

    /// <summary> 子件规格(导出用) </summary>
    public string DInvStd { get; set; }

    /// <summary> 计量单位编码(子件) </summary>
    public string DInvUnit { get; set; }

    /// <summary> 计量单位(导出用) </summary>
    public string DInvUnitName { get; set; }

    /// <summary> 使用数量(默认1) </summary>
    public double? DQty { get; set; }

    /// <summary> 仓库名称(导出用) </summary>
    public string DWhName { get; set; }

    /// <summary> 部门名称(导出用) </summary>
    public string DDeptName { get; set; }

    /// <summary> 替代标志(导出用) </summary>
    public int? DSubFlag { get; set; }

    /// <summary> 辅助单位(导出用) </summary>
    public string DAuxUnitName { get; set; }

    /// <summary> 辅助使用量 </summary>
    public double? DAuxQty { get; set; }

    /// <summary> 计量单位组类别(导出用) </summary>
    public int? DInvGroupType { get; set; }

    /// <summary> 工序名称(导出用) </summary>
    public string DOpDesc { get; set; }

    /// <summary> 存货计量单位名称(导出用) </summary>
    public string DInvGroupName { get; set; }

    /// <summary> 子件物料ID </summary>
    public int? DPartId { get; set; }

    /// <summary> 阶梯损耗(导出用) </summary>
    public int? DCompScrapFlag { get; set; }

    /// <summary> 成本投产推算 0-否,1-是 </summary>
    public int? DCostWIPRel { get; set; }

    public List<Bom_ComponentSubs> bomcomponentSubsList { get; set; }

    public List<Bom_ComponentLoc> bom_componentLocList { get; set; }
}
