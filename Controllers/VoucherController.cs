//using Helpers;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Web.Http;
//using U8API;
//using U8Login;
//using U8WebAPIApplication.Models;

//namespace U8WebAPIApplication.Controllers
//{
//    [RoutePrefix("api/voucher")]
//    public class VoucherController : ApiController
//    {
//        [HttpPost]
//        [Route("create")]
//        public IHttpActionResult Create([FromBody] Dictionary<string, object> data)
//        {
//            try
//            {
//                // 验证并获取 login 参数
//                if (!data.ContainsKey("login") || data["login"] == null)
//                    return Ok(new { code = -1, message = "没有找到 login 参数", data = data });

//                // 将 data["login"] 转换为 JObject
//                JObject loginData = data["login"] as JObject;

//                if (loginData == null)
//                    return Ok(new { code = -1, message = "login 参数格式不正确", data = data });

//                // 提取登录参数
//                string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
//                string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
//                string user = Util.GetLoginParam(loginData, "User").ToString();
//                string password = Util.GetLoginParam(loginData, "Password").ToString();
//                string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
//                string sServer = Util.GetLoginParam(loginData, "sServer").ToString();
//                string msg = "";
//                clsLogin U8clsLogin = new U8LoginManager().LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");
//                if (!string.IsNullOrEmpty(U8clsLogin.ShareString))
//                {
//                    return Ok(new { code = -1, message = U8clsLogin.ShareString });
//                }

//                //获取操作单据
//                if (!data.ContainsKey("query") || data["query"] == null)
//                    return Ok(new { code = -1, message = "没有找到 query 参数", data = data });

//                JObject queryData = data["query"] as JObject;
//                string billType = Util.GetLoginParam(queryData, "voucherType").ToString();

//                JObject head = Util.GetLoginParam(data, "head") as JObject;
//                JArray body = Util.GetLoginParam(data, "body") as JArray;
//                JArray pos = Util.GetLoginParam(data, "pos") as JArray;
//                string VouchId = "";
//                List<Dictionary<string, object>> result = new Voucher().Create(U8clsLogin, billType, head, body, pos, ref msg, ref VouchId);

//                if (!string.IsNullOrEmpty(msg))
//                {
//                    // domMsgList 就是解析后的 <z:row> 数据，可以在这里使用
//                    U8clsLogin.ShutDown();
//                    return Ok(new { code = -1, message = msg, domMsgList = result });
//                }

//                U8clsLogin.ShutDown();
//                return Ok(new { code = 1, message = "新增成功", data = new { id = VouchId } });
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("========== Create 异常 ==========");
//                System.Diagnostics.Debug.WriteLine($"消息: {ex.Message}");
//                System.Diagnostics.Debug.WriteLine($"堆栈: {ex.StackTrace}");
//                if (ex.InnerException != null)
//                {
//                    System.Diagnostics.Debug.WriteLine($"内部异常: {ex.InnerException.Message}");
//                }
//                System.Diagnostics.Debug.WriteLine("================================");
//                return Ok(new { code = -1, message = "Create失败: " + ex.Message, stack = ex.StackTrace });
//            }
//        }

//        [HttpPost]
//        [Route("select")]
//        public IHttpActionResult Select([FromBody] Dictionary<string, object> data)
//        {
//            try
//            {
//                // 验证并获取 login 参数
//                if (!data.ContainsKey("login") || data["login"] == null)
//                    return Ok(new { code = -1, message = "没有找到 login 参数", data = data });

//                // 将 data["login"] 转换为 JObject
//                JObject loginData = data["login"] as JObject;

//                if (loginData == null)
//                    return Ok(new { code = -1, message = "login 参数格式不正确", data = data });

//                // 提取登录参数
//                string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
//                string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
//                string user = Util.GetLoginParam(loginData, "User").ToString();
//                string password = Util.GetLoginParam(loginData, "Password").ToString();
//                string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
//                string sServer = Util.GetLoginParam(loginData, "sServer").ToString();
//                string msg = "";
//                clsLogin U8clsLogin = new U8LoginManager().LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");
//                if (!string.IsNullOrEmpty(U8clsLogin.ShareString))
//                {
//                    return Ok(new { code = -1, message = U8clsLogin.ShareString });
//                }

//                //获取查询条件
//                if (!data.ContainsKey("query") || data["query"] == null)
//                    return Ok(new { code = -1, message = "没有找到 query 参数", data = data });

//                JObject queryData = data["query"] as JObject;
//                string billType = Util.GetLoginParam(queryData, "voucherType").ToString();
//                string id = Util.GetLoginParam(queryData, "id").ToString();

//                Dictionary<string, object> result = new Voucher().Select(U8clsLogin, billType, id, ref msg);
//                U8clsLogin.ShutDown();
//                return Ok(new { code = 1, message = msg, data = result });
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("========== Select 异常 ==========");
//                System.Diagnostics.Debug.WriteLine($"消息: {ex.Message}");
//                System.Diagnostics.Debug.WriteLine($"堆栈: {ex.StackTrace}");
//                if (ex.InnerException != null)
//                {
//                    System.Diagnostics.Debug.WriteLine($"内部异常: {ex.InnerException.Message}");
//                }
//                System.Diagnostics.Debug.WriteLine("================================");
//                return Ok(new { code = -1, message = "Select失败: " + ex.Message, stack = ex.StackTrace });
//            }
//        }

//        [HttpPost]
//        [Route("verify")]
//        public IHttpActionResult Verify([FromBody] Dictionary<string, object> data)
//        {
//            try
//            {
//                if (!data.ContainsKey("login") || data["login"] == null)
//                    return Ok(new { code = -1, message = "没有找到 login 参数", data = data });

//                JObject loginData = data["login"] as JObject;
//                if (loginData == null)
//                    return Ok(new { code = -1, message = "login 参数格式不正确", data = data });

//                string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
//                string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
//                string user = Util.GetLoginParam(loginData, "User").ToString();
//                string password = Util.GetLoginParam(loginData, "Password").ToString();
//                string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
//                string sServer = Util.GetLoginParam(loginData, "sServer").ToString();
//                string msg = "";
//                clsLogin U8clsLogin = new U8LoginManager().LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");
//                if (!string.IsNullOrEmpty(U8clsLogin.ShareString))
//                {
//                    return Ok(new { code = -1, message = U8clsLogin.ShareString });
//                }

//                if (!data.ContainsKey("query") || data["query"] == null)
//                    return Ok(new { code = -1, message = "没有找到 query 参数", data = data });

//                JObject queryData = data["query"] as JObject;
//                string billType = Util.GetLoginParam(queryData, "voucherType").ToString();
//                string id = Util.GetLoginParam(queryData, "id").ToString();

//                bool result = new Voucher().Verify(U8clsLogin, billType, id, ref msg);
//                U8clsLogin.ShutDown();
//                return Ok(new { code = result ? 1 : 0, message = msg });
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("========== Verify 异常 ==========");
//                System.Diagnostics.Debug.WriteLine($"消息: {ex.Message}");
//                System.Diagnostics.Debug.WriteLine($"堆栈: {ex.StackTrace}");
//                if (ex.InnerException != null)
//                {
//                    System.Diagnostics.Debug.WriteLine($"内部异常: {ex.InnerException.Message}");
//                }
//                System.Diagnostics.Debug.WriteLine("================================");
//                return Ok(new { code = -1, message = "Verify失败: " + ex.Message, stack = ex.StackTrace });
//            }
//        }

//        [HttpPost]
//        [Route("unverify")]
//        public IHttpActionResult UnVerify([FromBody] Dictionary<string, object> data)
//        {
//            try
//            {
//                if (!data.ContainsKey("login") || data["login"] == null)
//                    return Ok(new { code = -1, message = "没有找到 login 参数", data = data });

//                JObject loginData = data["login"] as JObject;
//                if (loginData == null)
//                    return Ok(new { code = -1, message = "login 参数格式不正确", data = data });

//                string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
//                string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
//                string user = Util.GetLoginParam(loginData, "User").ToString();
//                string password = Util.GetLoginParam(loginData, "Password").ToString();
//                string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
//                string sServer = Util.GetLoginParam(loginData, "sServer").ToString();
//                string msg = "";
//                clsLogin U8clsLogin = new U8LoginManager().LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");
//                if (!string.IsNullOrEmpty(U8clsLogin.ShareString))
//                {
//                    return Ok(new { code = -1, message = U8clsLogin.ShareString });
//                }

//                if (!data.ContainsKey("query") || data["query"] == null)
//                    return Ok(new { code = -1, message = "没有找到 query 参数", data = data });

//                JObject queryData = data["query"] as JObject;
//                string billType = Util.GetLoginParam(queryData, "voucherType").ToString();
//                string id = Util.GetLoginParam(queryData, "id").ToString();

//                bool result = new Voucher().UnVerify(U8clsLogin, billType, id, ref msg);
//                U8clsLogin.ShutDown();
//                return Ok(new { code = result ? 1 : 0, message = msg });
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("========== UnVerify 异常 ==========");
//                System.Diagnostics.Debug.WriteLine($"消息: {ex.Message}");
//                System.Diagnostics.Debug.WriteLine($"堆栈: {ex.StackTrace}");
//                if (ex.InnerException != null)
//                {
//                    System.Diagnostics.Debug.WriteLine($"内部异常: {ex.InnerException.Message}");
//                }
//                System.Diagnostics.Debug.WriteLine("==================================");
//                return Ok(new { code = -1, message = "UnVerify失败: " + ex.Message, stack = ex.StackTrace });
//            }
//        }

//        [HttpPost]
//        [Route("delete")]
//        public IHttpActionResult Delete([FromBody] Dictionary<string, object> data)
//        {
//            try
//            {
//                if (!data.ContainsKey("login") || data["login"] == null)
//                    return Ok(new { code = -1, message = "没有找到 login 参数", data = data });

//                JObject loginData = data["login"] as JObject;
//                if (loginData == null)
//                    return Ok(new { code = -1, message = "login 参数格式不正确", data = data });

//                string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
//                string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
//                string user = Util.GetLoginParam(loginData, "User").ToString();
//                string password = Util.GetLoginParam(loginData, "Password").ToString();
//                string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
//                string sServer = Util.GetLoginParam(loginData, "sServer").ToString();
//                string msg = "";
//                clsLogin U8clsLogin = new U8LoginManager().LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");
//                if (!string.IsNullOrEmpty(U8clsLogin.ShareString))
//                {
//                    return Ok(new { code = -1, message = U8clsLogin.ShareString });
//                }

//                if (!data.ContainsKey("query") || data["query"] == null)
//                    return Ok(new { code = -1, message = "没有找到 query 参数", data = data });

//                JObject queryData = data["query"] as JObject;
//                string billType = Util.GetLoginParam(queryData, "voucherType").ToString();
//                string id = Util.GetLoginParam(queryData, "id").ToString();

//                bool result = new Voucher().Delete(U8clsLogin, billType, id, ref msg);
//                U8clsLogin.ShutDown();
//                return Ok(new { code = result ? 1 : 0, message = msg });
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("========== Delete 异常 ==========");
//                System.Diagnostics.Debug.WriteLine($"消息: {ex.Message}");
//                System.Diagnostics.Debug.WriteLine($"堆栈: {ex.StackTrace}");
//                if (ex.InnerException != null)
//                {
//                    System.Diagnostics.Debug.WriteLine($"内部异常: {ex.InnerException.Message}");
//                }
//                System.Diagnostics.Debug.WriteLine("================================");
//                return Ok(new { code = -1, message = "Delete失败: " + ex.Message, stack = ex.StackTrace });
//            }
//        }

//    }
//}