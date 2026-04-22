extern alias globalU8Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using U8Login;
using globalU8Login::U8Login;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Parameter;
using UFIDA.U8.U8MOMAPIFramework;


namespace U8WebAPIApplication.Models
{
    public class CreateBOM
    {
        public string CreateBom(U8Login.clsLogin clsLogin, BomDTO bom)
        {
            globalU8Login::U8Login.clsLogin u8Login = (globalU8Login::U8Login.clsLogin)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72A6FADA-FE26-46BD-A921-BFD1179C1E1E")));
            string sSubId = "AS";
            string sAccID = "999";
            string sYear ="2026";
            string sUserID = "demo";
            string sPassword = "DEMO";
            string sDate ="2025-12-12";
            string sServer ="192.168.88.252";
            string sSerial = "";
            string exReason = "";
            U8ApiBroker broker=null;
            try
            {
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    return "******登陆失败******" + u8Login.ShareString;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("BOM登陆成功：" );
                }
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = (globalU8Login::U8Login.clsLogin)clsLogin;
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/BOM/BomAdd");
                 broker = new U8ApiBroker(myApiAddress, envContext);
                ExtensionBusinessEntity extbo = broker.GetExtBoEntity("extbo");
                ExtensionItem newItem = extbo.NewItem();
                extbo[0]["InvCode"] = bom.Cinvcode;
                extbo[0]["InvStd"] = "";
                extbo[0]["InvUnitName"] = "";
                extbo[0]["CreateUser"] = "";
                extbo[0]["ModifyUser"] = "";
                extbo[0]["CreateDate"] = "";
                extbo[0]["ModifyDate"] = "";
                extbo[0]["ModifyTime"] = "";
                extbo[0]["CreateTime"] = "";
                extbo[0]["RelsUser"] = "";
                extbo[0]["RelsDate"] = "";
                extbo[0]["RelsTime"] = "";
                extbo[0]["CloseUser"] = "";
                extbo[0]["CloseDate"] = "";
                extbo[0]["CloseTime"] = "";
                extbo[0]["BomType"] = int.Parse(bom.BomType);
                extbo[0]["BasEngineerFigNo"] = "";
                extbo[0]["ParentScrap"] = 0;
                extbo[0]["Version"] = 101;
                extbo[0]["VersionDesc"] = bom.VersionDesc;
                extbo[0]["VersionEffDate"] = DateTime.Parse(bom.VsDate);
                extbo[0]["IdentCode"] = "";
                extbo[0]["IdentDesc"] = "";
                extbo[0]["InvAddCode"] = "";
                extbo[0]["InvFree_1"] = "";
                extbo[0]["InvFree_2"] = "";
                extbo[0]["InvFree_3"] = "";
                extbo[0]["InvFree_4"] = "";
                extbo[0]["InvFree_5"] = "";
                extbo[0]["InvFree_6"] = "";
                extbo[0]["InvFree_7"] = "";
                extbo[0]["InvFree_8"] = "";
                extbo[0]["InvFree_9"] = "";
                extbo[0]["InvFree_10"] = "";
                extbo[0]["Define_1"] = "";
                extbo[0]["Define_2"] = "";
                extbo[0]["Define_3"] = "";
                extbo[0]["Define_4"] = "";
                extbo[0]["Define_5"] = "";
                extbo[0]["Define_6"] = "";
                extbo[0]["Define_7"] = "";
                extbo[0]["Define_8"] = "";
                extbo[0]["Define_9"] = "";
                extbo[0]["Define_10"] = "";
                extbo[0]["Define_11"] = "";
                extbo[0]["Define_12"] = "";
                extbo[0]["Define_13"] = "";
                extbo[0]["Define_14"] = "";
                extbo[0]["InvDefine_1"] = "";
                extbo[0]["InvDefine_2"] = "";
                extbo[0]["InvDefine_3"] = "";
                extbo[0]["InvDefine_4"] = "";
                extbo[0]["InvDefine_5"] = "";
                extbo[0]["InvDefine_6"] = "";
                extbo[0]["InvDefine_7"] = "";
                extbo[0]["InvDefine_8"] = "";
                extbo[0]["InvDefine_9"] = "";
                extbo[0]["InvDefine_10"] = "";
                extbo[0]["InvDefine_15"] = "";
                extbo[0]["InvDefine_16"] = "";
                extbo[0]["VersionEndDate"] = DateTime.Parse(bom.VeDate);
                extbo[0]["InvGroupName"] = "";
                ExtensionBusinessEntity Bom_Component = extbo[0].SubEntity["Bom_Component"];
                int i = 0;
                foreach (BomLineDTO line in bom.bomline)
                {
                    Bom_Component[i]["DSortSeq"] = line.DsortSeq;
                    Bom_Component[i]["DOpSeq"] = "0000";
                    Bom_Component[i]["DInvCode"] = line.Cinvcodez;
                    Bom_Component[i]["DBaseQtyN"] = line.Ijbyl;
                    Bom_Component[i]["DBaseQtyD"] = line.Ijcyl;
                    Bom_Component[i]["DCompScrap"] = line.DCompScrap;
                    Bom_Component[i]["DFVFlag"] = line.DFVFlag;
                    Bom_Component[i]["DWIPType"] = Convert.ToInt32(line.DWIPType);
                    Bom_Component[i]["DEffBegDate"] = DateTime.Parse(bom.VsDate);
                    Bom_Component[i]["DEffEndDate"] = DateTime.Parse("2099-12-31");
                    Bom_Component[i]["DPlanRate"] = 100.0;
                    Bom_Component[i]["DByproductFlag"] = 0;
                    Bom_Component[i]["DAccuCostFlag"] = 1;
                    Bom_Component[i]["DOptionalFlag"] = 0;
                    Bom_Component[i]["DMutexRule"] = 2;
                    Bom_Component[i]["DInvName"] = "";
                    Bom_Component[i]["DInvStd"] = "";
                    Bom_Component[i]["DInvUnit"] = "";
                    Bom_Component[i]["DInvUnitName"] = "";
                    Bom_Component[i]["DQty"] = 1;
                    Bom_Component[i]["DWhName"] = "";
                    Bom_Component[i]["DDeptName"] = "";
                    Bom_Component[i]["DSubFlag"] = 0;
                    Bom_Component[i]["DAuxUnitName"] = "";
                    Bom_Component[i]["DAuxQty"] = "";
                    Bom_Component[i]["DOpDesc"] = "";
                    Bom_Component[i]["DRemark"] = line.Remark;
                    Bom_Component[i]["DInvAddCode"] = "";
                    Bom_Component[i]["DInvFree_1"] = "";
                    Bom_Component[i]["DInvFree_2"] = "";
                    Bom_Component[i]["DInvFree_3"] = "";
                    Bom_Component[i]["DInvFree_4"] = "";
                    Bom_Component[i]["DInvFree_5"] = "";
                    Bom_Component[i]["DInvFree_6"] = "";
                    Bom_Component[i]["DInvFree_7"] = "";
                    Bom_Component[i]["DInvFree_8"] = "";
                    Bom_Component[i]["DInvFree_9"] = "";
                    Bom_Component[i]["DInvFree_10"] = "";
                    Bom_Component[i]["DInvDefine_1"] = "";
                    Bom_Component[i]["DInvDefine_2"] = "";
                    Bom_Component[i]["DInvDefine_3"] = "";
                    Bom_Component[i]["DInvDefine_4"] = "";
                    Bom_Component[i]["DInvDefine_5"] = "";
                    Bom_Component[i]["DInvDefine_6"] = "";
                    Bom_Component[i]["DInvDefine_7"] = "";
                    Bom_Component[i]["DInvDefine_8"] = "";
                    Bom_Component[i]["DInvDefine_9"] = "";
                    Bom_Component[i]["DInvDefine_10"] = "";
                    Bom_Component[i]["DInvDefine_15"] = "";
                    Bom_Component[i]["DInvDefine_16"] = "";
                    Bom_Component[i]["DSubDate"] = "";
                    Bom_Component[i]["DAuxUnitCode"] = "";
                    Bom_Component[i]["DBasEngineerFigNo"] = "";
                    Bom_Component[i]["DDefine_22"] = "";
                    Bom_Component[i]["DDefine_23"] = "";
                    Bom_Component[i]["DDefine_24"] = "";
                    Bom_Component[i]["DDefine_25"] = "";
                    Bom_Component[i]["DDefine_26"] = "";
                    Bom_Component[i]["DDefine_27"] = "";
                    Bom_Component[i]["DDefine_28"] = "";
                    Bom_Component[i]["DDefine_29"] = "";
                    Bom_Component[i]["DDefine_30"] = "";
                    Bom_Component[i]["DDefine_31"] = "";
                    Bom_Component[i]["DDefine_32"] = "";
                    Bom_Component[i]["DDefine_33"] = "";
                    Bom_Component[i]["DDefine_36"] = "";
                    Bom_Component[i]["DDefine_37"] = "";
                    Bom_Component[i]["DInvGroupCode"] = "";
                    Bom_Component[i]["DInvGroupName"] = "";
                    i++;
                }
                if (!broker.Invoke())
                {
                    Exception apiEx = broker.GetException();
                    string errorMsg = "";
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            errorMsg = "系统异常：" + sysEx.Message;
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            errorMsg = "业务异常：" + bizEx.Message;
                        }
                        else
                        {
                            errorMsg = "API异常：" + apiEx.Message;
                        }
                        exReason = broker.GetExceptionString();
                        if (!string.IsNullOrEmpty(exReason))
                        {
                            errorMsg += " | 原因：" + exReason;
                        }
                    }
                    else
                    {
                        errorMsg = "API调用失败";
                    }
                    broker.Release();
                    return errorMsg;
                }
                
                // Invoke 成功后才能获取返回值
                bool result = Convert.ToBoolean(broker.GetReturnValue());
                if (result)
                {
                    string bomId = "";
                    try { bomId = extbo[0]["BomId"]?.ToString() ?? ""; } catch { }
                    broker.Release();
                    return "成功|BomId:" + bomId;
                }
                broker.Release();
                return "失败";
            }
            catch (Exception ex)
            {
                return "异常：" + ex.Message;
            }
            finally
            {
                try { broker.Release(); } catch { }
            }
        }
    }
}