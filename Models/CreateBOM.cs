extern alias globalU8Login;

using System;
using System.Configuration;
using System.Web.UI.WebControls;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Parameter;
using UFIDA.U8.U8MOMAPIFramework;


namespace U8WebAPIApplication.Models
{
    public class CreateBOM
    {
        public string CreateBom(U8Login.clsLogin clsLogin, Bom_Parent bomParent)
        {
            U8ApiBroker broker = null;
            try
            {
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = (globalU8Login::U8Login.clsLogin)clsLogin;
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/BOM/BomAdd");
                broker = new U8ApiBroker(myApiAddress, envContext);
                ExtensionBusinessEntity extbo = broker.GetExtBoEntity("extbo");
                ExtensionItem newItem = extbo.NewItem();

                //region 主表 - 优先使用bomParent值，为空则使用默认值常量
                extbo[0]["InvCode"] = bomParent.InvCode ?? "";
                extbo[0]["Version"] = bomParent.Version ?? 10;
                extbo[0]["VersionEffDate"] = bomParent.VersionEffDate ?? "";
                extbo[0]["VersionDesc"] = bomParent.VersionDesc ?? "";
                extbo[0]["ParentScrap"] = bomParent.ParentScrap ?? 0;
                extbo[0]["BomType"] = bomParent.BomType != null ? bomParent.BomType : 1;

                extbo[0]["InvStd"] = bomParent.InvStd ?? "";
                extbo[0]["InvUnitName"] = bomParent.InvUnitName ?? "";
                extbo[0]["InvUnit"] = bomParent.InvUnit ?? "";
                extbo[0]["CreateUser"] = bomParent.CreateUser ?? "";
                extbo[0]["ModifyUser"] = bomParent.ModifyUser ?? "";
                extbo[0]["CreateDate"] = bomParent.CreateDate ?? "";
                extbo[0]["ModifyDate"] = bomParent.ModifyDate ?? "";
                extbo[0]["ModifyTime"] = bomParent.ModifyTime ?? "";
                extbo[0]["CreateTime"] = bomParent.CreateTime ?? "";
                extbo[0]["RelsUser"] = bomParent.RelsUser ?? "";
                extbo[0]["RelsDate"] = bomParent.RelsDate ?? "";
                extbo[0]["RelsTime"] = bomParent.RelsTime ?? "";
                extbo[0]["CloseUser"] = bomParent.CloseUser ?? "";
                extbo[0]["CloseDate"] = bomParent.CloseDate ?? "";
                extbo[0]["CloseTime"] = bomParent.CloseTime ?? "";
                extbo[0]["UpdateByDiff"] = bomParent.UpdateByDiff ?? 0;
                extbo[0]["PartId"] = bomParent.PartId ?? 0;
                extbo[0]["BasEngineerFigNo"] = bomParent.BasEngineerFigNo ?? "";
                extbo[0]["IdentCode"] = bomParent.IdentCode ?? "";
                extbo[0]["IdentDesc"] = bomParent.IdentDesc ?? "";
                extbo[0]["InvAddCode"] = bomParent.InvAddCode ?? "";
                extbo[0]["InvFree_1"] = bomParent.InvFree_1 ?? "";
                extbo[0]["InvFree_2"] = bomParent.InvFree_2 ?? "";
                extbo[0]["InvFree_3"] = bomParent.InvFree_3 ?? "";
                extbo[0]["InvFree_4"] = bomParent.InvFree_4 ?? "";
                extbo[0]["InvFree_5"] = bomParent.InvFree_5 ?? "";
                extbo[0]["InvFree_6"] = bomParent.InvFree_6 ?? "";
                extbo[0]["InvFree_7"] = bomParent.InvFree_7 ?? "";
                extbo[0]["InvFree_8"] = bomParent.InvFree_8 ?? "";
                extbo[0]["InvFree_9"] = bomParent.InvFree_9 ?? "";
                extbo[0]["InvFree_10"] = bomParent.InvFree_10 ?? "";
                extbo[0]["Define_1"] = bomParent.Define_1 ?? "";
                extbo[0]["Define_2"] = bomParent.Define_2 ?? "";
                extbo[0]["Define_3"] = bomParent.Define_3 ?? "";
                extbo[0]["Define_4"] = bomParent.Define_4 ?? "";
                extbo[0]["Define_5"] = bomParent.Define_5 ?? 0;
                extbo[0]["Define_6"] = bomParent.Define_6 ?? "";
                extbo[0]["Define_7"] = bomParent.Define_7 ?? 0;
                extbo[0]["Define_8"] = bomParent.Define_8 ?? "";
                extbo[0]["Define_9"] = bomParent.Define_9 ?? "";
                extbo[0]["Define_10"] = bomParent.Define_10 ?? "";
                extbo[0]["Define_11"] = bomParent.Define_11 ?? "";
                extbo[0]["Define_12"] = bomParent.Define_12 ?? "";
                extbo[0]["Define_13"] = bomParent.Define_13 ?? "";
                extbo[0]["Define_14"] = bomParent.Define_14 ?? "";
                extbo[0]["InvDefine_1"] = bomParent.InvDefine_1 ?? "";
                extbo[0]["InvDefine_2"] = bomParent.InvDefine_2 ?? "";
                extbo[0]["InvDefine_3"] = bomParent.InvDefine_3 ?? "";
                extbo[0]["InvDefine_4"] = bomParent.InvDefine_4 ?? "";
                extbo[0]["InvDefine_5"] = bomParent.InvDefine_5 ?? "";
                extbo[0]["InvDefine_6"] = bomParent.InvDefine_6 ?? "";
                extbo[0]["InvDefine_7"] = bomParent.InvDefine_7 ?? "";
                extbo[0]["InvDefine_8"] = bomParent.InvDefine_8 ?? "";
                extbo[0]["InvDefine_9"] = bomParent.InvDefine_9 ?? "";
                extbo[0]["InvDefine_10"] = bomParent.InvDefine_10 ?? "";
                extbo[0]["InvDefine_15"] = bomParent.InvDefine_15 ?? "";
                extbo[0]["InvDefine_16"] = bomParent.InvDefine_16 ?? "";
                extbo[0]["VersionEndDate"] = bomParent.VersionEndDate ?? "";
                extbo[0]["InvGroupName"] = bomParent.InvGroupName ?? "";
                extbo[0]["InvGroupCode"] = bomParent.InvGroupCode ?? "";
                extbo[0]["InvGroupType"] = bomParent.InvGroupType ?? 0;
                extbo[0]["BomState"] = bomParent.BomState ?? 0;
                extbo[0]["InvDefine_11"] = bomParent.InvDefine_11 ?? 0;
                extbo[0]["InvDefine_12"] = bomParent.InvDefine_12 ?? 0;
                extbo[0]["InvDefine_13"] = bomParent.InvDefine_13 ?? 0;
                extbo[0]["InvDefine_14"] = bomParent.InvDefine_14 ?? 0;
                //endregion 主表

                // 子表
                if (bomParent.bomcomponentList != null && bomParent.bomcomponentList.Count > 0)
                {
                    ExtensionBusinessEntity Bom_Component = extbo[0].SubEntity["Bom_Component"];

                    for (int i = 0; i < bomParent.bomcomponentList.Count; i++)
                    {
                        Bom_Component component = bomParent.bomcomponentList[i];

                        // 优先使用bomParent值，为空则使用默认值常量
                        Bom_Component[i]["DSortSeq"] = component.DSortSeq != null ? component.DSortSeq.ToString() : "";
                        Bom_Component[i]["DOpSeq"] = component.DOpSeq ?? "0000";
                        Bom_Component[i]["DInvCode"] = component.DInvCode ?? "";
                        Bom_Component[i]["DBaseQtyN"] = component.DBaseQtyN;
                        Bom_Component[i]["DBaseQtyD"] = component.DBaseQtyD;
                        Bom_Component[i]["DCompScrap"] = component.DCompScrap;
                        Bom_Component[i]["DFVFlag"] = component.DFVFlag;
                        Bom_Component[i]["DWIPType"] = Convert.ToInt32(component.DWIPType);
                        Bom_Component[i]["DEffBegDate"] = component.DEffBegDate != null ? DateTime.Parse(component.DEffBegDate).ToLongDateString() : "";
                        Bom_Component[i]["DEffEndDate"] = component.DEffEndDate == null ? DateTime.Parse("2099-12-31") : DateTime.Parse(component.DEffEndDate);
                        Bom_Component[i]["DPlanRate"] = component.DPlanRate == 0 ? 100.0 : component.DPlanRate;
                        Bom_Component[i]["DByproductFlag"] = component.DByproductFlag ?? 0;
                        Bom_Component[i]["DAccuCostFlag"] = component.DAccuCostFlag ?? 1;
                        Bom_Component[i]["DOptionalFlag"] = component.DOptionalFlag ?? 0;
                        Bom_Component[i]["DMutexRule"] = component.DMutexRule ?? 2;
                        Bom_Component[i]["DProductType"] = component.DProductType;
                        Bom_Component[i]["DInvName"] = component.DInvName ?? "";
                        Bom_Component[i]["DInvStd"] = component.DInvStd ?? "";
                        Bom_Component[i]["DInvUnit"] = component.DInvUnit ?? "";
                        Bom_Component[i]["DInvUnitName"] = component.DInvUnitName ?? "";
                        Bom_Component[i]["DQty"] = component.DQty ?? 1;
                        Bom_Component[i]["DWhName"] = component.DWhName ?? "";
                        Bom_Component[i]["DDeptName"] = component.DDeptName ?? "";
                        Bom_Component[i]["DSubFlag"] = component.DSubFlag ?? 0;
                        Bom_Component[i]["DAuxUnitName"] = component.DAuxUnitName ?? "";
                        Bom_Component[i]["DAuxQty"] = component.DAuxQty;
                        Bom_Component[i]["DInvGroupType"] = component.DInvGroupType;
                        Bom_Component[i]["DOpDesc"] = component.DOpDesc ?? "";
                        Bom_Component[i]["DRemark"] = component.DRemark ?? "";
                        Bom_Component[i]["DInvAddCode"] = component.DInvAddCode ?? "";
                        Bom_Component[i]["DOffset"] = component.DOffset ?? 0;
                        Bom_Component[i]["DWhCode"] = component.DWhCode ?? "";
                        Bom_Component[i]["DDeptCode"] = component.DDeptCode ?? "";
                        Bom_Component[i]["DInvFree_1"] = component.DInvFree_1 ?? "";
                        Bom_Component[i]["DInvFree_2"] = component.DInvFree_2 ?? "";
                        Bom_Component[i]["DInvFree_3"] = component.DInvFree_3 ?? "";
                        Bom_Component[i]["DInvFree_4"] = component.DInvFree_4 ?? "";
                        Bom_Component[i]["DInvFree_5"] = component.DInvFree_5 ?? "";
                        Bom_Component[i]["DInvFree_6"] = component.DInvFree_6 ?? "";
                        Bom_Component[i]["DInvFree_7"] = component.DInvFree_7 ?? "";
                        Bom_Component[i]["DInvFree_8"] = component.DInvFree_8 ?? "";
                        Bom_Component[i]["DInvFree_9"] = component.DInvFree_9 ?? "";
                        Bom_Component[i]["DInvFree_10"] = component.DInvFree_10 ?? "";
                        Bom_Component[i]["DInvDefine_1"] = component.DInvDefine_1 ?? "";
                        Bom_Component[i]["DInvDefine_2"] = component.DInvDefine_2 ?? "";
                        Bom_Component[i]["DInvDefine_3"] = component.DInvDefine_3 ?? "";
                        Bom_Component[i]["DInvDefine_4"] = component.DInvDefine_4 ?? "";
                        Bom_Component[i]["DInvDefine_5"] = component.DInvDefine_5 ?? "";
                        Bom_Component[i]["DInvDefine_6"] = component.DInvDefine_6 ?? "";
                        Bom_Component[i]["DInvDefine_7"] = component.DInvDefine_7 ?? "";
                        Bom_Component[i]["DInvDefine_8"] = component.DInvDefine_8 ?? "";
                        Bom_Component[i]["DInvDefine_9"] = component.DInvDefine_9 ?? "";
                        Bom_Component[i]["DInvDefine_10"] = component.DInvDefine_10 ?? "";
                        Bom_Component[i]["DInvDefine_11"] = component.DInvDefine_11 ?? 0;
                        Bom_Component[i]["DInvDefine_12"] = component.DInvDefine_12 ?? 0;
                        Bom_Component[i]["DInvDefine_13"] = component.DInvDefine_13 ?? 0;
                        Bom_Component[i]["DInvDefine_14"] = component.DInvDefine_14 ?? 0;
                        Bom_Component[i]["DInvDefine_15"] = component.DInvDefine_15 ?? "";
                        Bom_Component[i]["DInvDefine_16"] = component.DInvDefine_16 ?? "";
                        Bom_Component[i]["DSubDate"] = component.DSubDate ?? "";
                        Bom_Component[i]["DAuxUnitCode"] = component.DAuxUnitCode ?? "";
                        Bom_Component[i]["DChangeRate"] = component.DChangeRate ?? 0;
                        Bom_Component[i]["DAuxBaseQtyN"] = component.DAuxBaseQtyN ?? 0;
                        Bom_Component[i]["DBasEngineerFigNo"] = component.DBasEngineerFigNo ?? "";
                        Bom_Component[i]["DDefine_22"] = component.DDefine_22 ?? "";
                        Bom_Component[i]["DDefine_23"] = component.DDefine_23 ?? "";
                        Bom_Component[i]["DDefine_24"] = component.DDefine_24 ?? "";
                        Bom_Component[i]["DDefine_25"] = component.DDefine_25 ?? "";
                        Bom_Component[i]["DDefine_26"] = component.DDefine_26 ?? 0;
                        Bom_Component[i]["DDefine_27"] = component.DDefine_27 ?? 0;
                        Bom_Component[i]["DDefine_28"] = component.DDefine_28 ?? "";
                        Bom_Component[i]["DDefine_29"] = component.DDefine_29 ?? "";
                        Bom_Component[i]["DDefine_30"] = component.DDefine_30 ?? "";
                        Bom_Component[i]["DDefine_31"] = component.DDefine_31 ?? "";
                        Bom_Component[i]["DDefine_32"] = component.DDefine_32 ?? "";
                        Bom_Component[i]["DDefine_33"] = component.DDefine_33 ?? "";
                        Bom_Component[i]["DDefine_34"] = component.DDefine_34 ?? 0;
                        Bom_Component[i]["DDefine_35"] = component.DDefine_35 ?? 0;
                        Bom_Component[i]["DDefine_36"] = component.DDefine_36 ?? "";
                        Bom_Component[i]["DDefine_37"] = component.DDefine_37 ?? "";
                        Bom_Component[i]["DInvGroupCode"] = component.DInvGroupCode ?? "";
                        Bom_Component[i]["DInvGroupName"] = component.DInvGroupName ?? "";
                        Bom_Component[i]["DPartId"] = component.DPartId ?? 0;
                        Bom_Component[i]["DCompScrapFlag"] = component.DCompScrapFlag ?? 0;
                        Bom_Component[i]["DCostWIPRel"] = component.DCostWIPRel ?? 0;

                        // 子子表 - Bom_ComponentSubs
                        if (component.bomcomponentSubsList != null && component.bomcomponentSubsList.Count > 0)
                        {
                            ExtensionBusinessEntity Bom_ComponentSubs = Bom_Component[i].SubEntity["Bom_ComponentSubs"];

                            for (int j = 0; j < component.bomcomponentSubsList.Count; j++)
                            {
                                Bom_ComponentSubs subs = component.bomcomponentSubsList[j];

                                Bom_ComponentSubs[j]["DInvCode"] = subs.DInvCode ?? "";
                                Bom_ComponentSubs[j]["DSequence"] = subs.DSequence;
                                Bom_ComponentSubs[j]["DFactor"] = subs.DFactor;
                                Bom_ComponentSubs[j]["DEffBegDate"] = subs.DEffBegDate;
                                Bom_ComponentSubs[j]["DEffEndDate"] = subs.DEffEndDate;
                                Bom_ComponentSubs[j]["DReplaceFlag"] = subs.DReplaceFlag;
                                Bom_ComponentSubs[j]["DInvName"] = subs.DInvName ?? "";
                                Bom_ComponentSubs[j]["DInvStd"] = subs.DInvStd ?? "";
                                Bom_ComponentSubs[j]["DInvUnit"] = subs.DInvUnit ?? "";
                                Bom_ComponentSubs[j]["DInvUnitName"] = subs.DInvUnitName ?? "";
                                Bom_ComponentSubs[j]["DInvAddCode"] = subs.DInvAddCode ?? "";
                                Bom_ComponentSubs[j]["DInvFree_1"] = subs.DInvFree_1 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_2"] = subs.DInvFree_2 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_3"] = subs.DInvFree_3 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_4"] = subs.DInvFree_4 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_5"] = subs.DInvFree_5 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_6"] = subs.DInvFree_6 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_7"] = subs.DInvFree_7 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_8"] = subs.DInvFree_8 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_9"] = subs.DInvFree_9 ?? "";
                                Bom_ComponentSubs[j]["DInvFree_10"] = subs.DInvFree_10 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_1"] = subs.DInvDefine_1 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_2"] = subs.DInvDefine_2 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_3"] = subs.DInvDefine_3 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_4"] = subs.DInvDefine_4 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_5"] = subs.DInvDefine_5 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_6"] = subs.DInvDefine_6 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_7"] = subs.DInvDefine_7 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_8"] = subs.DInvDefine_8 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_9"] = subs.DInvDefine_9 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_10"] = subs.DInvDefine_10 ?? "";
                                Bom_ComponentSubs[j]["DInvDefine_11"] = subs.DInvDefine_11 ?? 0;
                                Bom_ComponentSubs[j]["DInvDefine_12"] = subs.DInvDefine_12 ?? 0;
                                Bom_ComponentSubs[j]["DInvDefine_13"] = subs.DInvDefine_13 ?? 0;
                                Bom_ComponentSubs[j]["DInvDefine_14"] = subs.DInvDefine_14 ?? 0;
                                Bom_ComponentSubs[j]["DInvDefine_15"] = subs.DInvDefine_15;
                                Bom_ComponentSubs[j]["DInvDefine_16"] = subs.DInvDefine_16;
                                Bom_ComponentSubs[j]["ComponentSubId"] = subs.ComponentSubId ?? 0;
                                Bom_ComponentSubs[j]["DBasEngineerFigNo"] = subs.DBasEngineerFigNo ?? "";
                                Bom_ComponentSubs[j]["DDefine_22"] = subs.DDefine_22 ?? "";
                                Bom_ComponentSubs[j]["DDefine_23"] = subs.DDefine_23 ?? "";
                                Bom_ComponentSubs[j]["DDefine_24"] = subs.DDefine_24 ?? "";
                                Bom_ComponentSubs[j]["DDefine_25"] = subs.DDefine_25 ?? "";
                                Bom_ComponentSubs[j]["DDefine_26"] = subs.DDefine_26 ?? 0;
                                Bom_ComponentSubs[j]["DDefine_27"] = subs.DDefine_27 ?? 0;
                                Bom_ComponentSubs[j]["DDefine_28"] = subs.DDefine_28 ?? "";
                                Bom_ComponentSubs[j]["DDefine_29"] = subs.DDefine_29 ?? "";
                                Bom_ComponentSubs[j]["DDefine_30"] = subs.DDefine_30 ?? "";
                                Bom_ComponentSubs[j]["DDefine_31"] = subs.DDefine_31 ?? "";
                                Bom_ComponentSubs[j]["DDefine_32"] = subs.DDefine_32 ?? "";
                                Bom_ComponentSubs[j]["DDefine_33"] = subs.DDefine_33 ?? "";
                                Bom_ComponentSubs[j]["DDefine_34"] = subs.DDefine_34 ?? 0;
                                Bom_ComponentSubs[j]["DDefine_35"] = subs.DDefine_35 ?? 0;
                                Bom_ComponentSubs[j]["DDefine_36"] = subs.DDefine_36;
                                Bom_ComponentSubs[j]["DDefine_37"] = subs.DDefine_37;
                                Bom_ComponentSubs[j]["DInvGroupType"] = subs.DInvGroupType ?? 0;
                                Bom_ComponentSubs[j]["DInvGroupCode"] = subs.DInvGroupCode ?? "";
                                Bom_ComponentSubs[j]["DInvGroupName"] = subs.DInvGroupName ?? "";
                                Bom_ComponentSubs[j]["DPartId"] = subs.DPartId ?? 0;
                            }
                        }

                        // 子子表 - Bom_ComponentLoc
                        if (component.bom_componentLocList != null && component.bom_componentLocList.Count > 0)
                        {
                            ExtensionBusinessEntity BomComponentLocList = Bom_Component[i].SubEntity["Bom_ComponentLoc"];

                            for (int m = 0; m < component.bom_componentLocList.Count; m++)
                            {
                                Bom_ComponentLoc loc = component.bom_componentLocList[m];

                                BomComponentLocList[m]["DLoc"] = loc.DLoc ?? "";
                                BomComponentLocList[m]["DSortSeq"] = loc.DSortSeq ?? 0;
                            }
                        }
                    }
                }

                if (!broker.Invoke())
                {
                    Exception apiEx = broker.GetException();
                    string errorMsg = apiEx.InnerException != null ? apiEx.InnerException.Message : apiEx.Message;
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            errorMsg = "系统异常：" + (sysEx.InnerException != null ? sysEx.InnerException.Message : sysEx.Message);
                            System.Diagnostics.Debug.WriteLine(errorMsg);
                            throw sysEx;
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            errorMsg = "API异常：" + (bizEx.InnerException != null ? bizEx.InnerException.Message : bizEx.Message);
                            System.Diagnostics.Debug.WriteLine(errorMsg);
                            throw bizEx;
                        }
                        string exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            errorMsg = errorMsg +"异常原因：" + exReason;
                        }
                        throw new Exception(errorMsg);
                    }
                    broker.Release();
                    throw new Exception(errorMsg);
                }

                bool result = Convert.ToBoolean(broker.GetReturnValue());
                if (result)
                {
                    broker.Release();
                    return extbo[0]["BomId"]?.ToString();
                }
                broker.Release();
                return "失败";
            }
            finally
            {
                try { broker.Release(); } catch { }
            }
        }


        public string ApproveBOM(U8Login.clsLogin clsLogin, int partid, int bomtype,string versionoridencode)
        {
            //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
            U8EnvContext envContext = new U8EnvContext();
            envContext.U8Login = (globalU8Login::U8Login.clsLogin)clsLogin;
            //第三步：设置API地址标识(Url)
            //当前API：审核物料清单的地址标识为：U8API/BOM/BomAuditing
            U8ApiAddress myApiAddress = new U8ApiAddress("U8API/BOM/BomAuditing");

            //第四步：构造APIBroker
            U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);
            //第五步：API参数赋值
            broker.AssignNormalValue("partid", partid);
            broker.AssignNormalValue("bomtype", bomtype);
            broker.AssignNormalValue("versionoridencode", versionoridencode==null? "10": versionoridencode);
            //第六步：调用API
            if (!broker.Invoke())
            {
                Exception apiEx = broker.GetException();
                string errorMsg = apiEx.InnerException != null ? apiEx.InnerException.Message : apiEx.Message;
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;
                        errorMsg = "系统异常：" + (sysEx.InnerException != null ? sysEx.InnerException.Message : sysEx.Message);
                        System.Diagnostics.Debug.WriteLine(errorMsg);
                        throw sysEx;
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        errorMsg = "API异常：" + (bizEx.InnerException != null ? bizEx.InnerException.Message : bizEx.Message);
                        System.Diagnostics.Debug.WriteLine(errorMsg);
                        throw bizEx;
                    }
                    string exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        errorMsg = errorMsg + "异常原因：" + exReason;
                    }
                    throw new Exception(errorMsg);
                }
                broker.Release();
                throw new Exception(errorMsg);
            }

            //第七步：获取返回结果

            //获取返回值
            //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值: true:成功, false: 失败
            Boolean result = Convert.ToBoolean(broker.GetReturnValue());
            broker.Release();
            return "成功";
        }
    }
}
