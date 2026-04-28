using Helpers;
using System;
using System.Collections.Generic;
using System.Web.Http;
using U8Login;
using U8WebAPIApplication.Helpers;
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
            // 解析登录信息
            clsLogin U8clsLogin = new U8LoginManager().LoginToU8(data);

            // 使用转换器将 JSON 转换为 BOM 对象
            Bom_Parent bomParent = JsonToBomConverter.ConvertToBomParent(data);
            List<Bom_Component> componentList = JsonToBomConverter.ConvertToBomComponentList(data);
            bomParent.bomcomponentList = componentList;

            // 调用 BOM 创建
            string re = new CreateBOM().CreateBom(U8clsLogin, bomParent);
            return Ok(new { code = 1, message = "BOM插入成功", data = re });
        }

        [HttpPost]
        [Route("Approve")]
        public IHttpActionResult ApproveBOM([FromBody] Dictionary<string, object> data)
        {
            // 解析登录信息
            clsLogin U8clsLogin = new U8LoginManager().LoginToU8(data);
            Dictionary<string, object> head = (Dictionary<string, object>)data["head"];

            int partid;
            if (head.ContainsKey("partid"))
            {
                partid = Convert.ToInt32(head["partid"]);
            }
            else
            {
                return Ok(new { code = -1, message = "请输入partid字段" });
            }
            int bomtype = 1;
            if (head.ContainsKey("bomtype"))
            {
                bomtype = Convert.ToInt32(head["bomtype"]);
            }
            string versionoridencode = "10";
            if (head.ContainsKey("versionoridencode"))
            {
                versionoridencode = (string)head["versionoridencode"];
            }
            string re = new CreateBOM().ApproveBOM(U8clsLogin, partid, bomtype, versionoridencode);
            return Ok(new { code = -1, message = "审核成功", data = re });
        }
    }
}