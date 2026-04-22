using Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

using U8Login;
using U8WebAPIApplication.Models;

namespace U8WebAPIApplication.Controllers
{
    [RoutePrefix("api/bom")]
    public class BomController : ApiController
    {
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] Dictionary<string, object> data)
        {
            try
            {
                // 验证并获取 login 参数
                if (!data.ContainsKey("login") || data["login"] == null)
                    return Ok(new { code = -1, message = "没有找到 login 参数", data = data });

                // 将 data["login"] 转换为 JObject
                JObject loginData = data["login"] as JObject;

                if (loginData == null)
                    return Ok(new { code = -1, message = "login 参数格式不正确", data = data });

                // 提取登录参数
                string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
                string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
                string user = Util.GetLoginParam(loginData, "User").ToString();
                string password = Util.GetLoginParam(loginData, "Password").ToString();
                string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
                string sServer = Util.GetLoginParam(loginData, "sServer").ToString();
                string msg = "";
                clsLogin U8clsLogin = new U8LoginManager().LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");
                if (!string.IsNullOrEmpty(U8clsLogin.ShareString))
                {
                    return Ok(new { code = -1, message = U8clsLogin.ShareString });
                }
                BomDTO BomDTO = new BomDTO();
                BomDTO.Cinvcode = "14000109";
                BomDTO.BomType = "1";
                BomDTO.VersionDesc = "11";
                BomDTO.VsDate = "2026-12-12";
                BomDTO.VeDate = "2026-12-15";
                BomLineDTO BomLineDTO = new BomLineDTO();
                BomLineDTO.DsortSeq = 10;
                BomLineDTO.Cinvcodez = "14000107";
                BomLineDTO.Ijbyl = 10;
                BomLineDTO.Ijcyl = 10;
                BomLineDTO.DCompScrap = 12;
                BomLineDTO.DFVFlag = "1";
                BomLineDTO.DWIPType = 1;
                BomLineDTO.Remark = "";
                List<BomLineDTO> List = new List<BomLineDTO>();
                List.Add(BomLineDTO);
                BomDTO.bomline = List;
                string re = new CreateBOM().CreateBom(U8clsLogin, BomDTO);
                return Ok(new { code = 1, message = "" + re });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("========== Create 异常 ==========");
                System.Diagnostics.Debug.WriteLine($"消息: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"堆栈: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"内部异常: {ex.InnerException.Message}");
                }
                System.Diagnostics.Debug.WriteLine("================================");
                return Ok(new { code = -1, message = "Create失败: " + ex.Message, stack = ex.StackTrace });
            }
        }

        [HttpPost]
        [Route("Approve")]
        public IHttpActionResult ApproveBOM([FromBody] Dictionary<string, object> data)
        {

            return Ok(new { code = -1, message = "审核成功" });
        }
    }
}