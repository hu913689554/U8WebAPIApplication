using Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U8Login;
namespace U8WebAPIApplication.Models
{
    public class U8LoginManager
    {
        public U8Login.clsLogin LoginToU8(string pSubId, string pAccId, string pYearId, string pUserId, string pPassword, string pDate, string cSrv, string cSerial)
        {
            clsLogin u8login = new clsLogin();
            u8login.ClearError();

            bool loginResult = u8login.Login(
                ref pSubId,
                ref pAccId,
                ref pYearId,
                ref pUserId,
                ref pPassword,
                ref pDate,
                ref cSrv,
                ref cSerial
            );

            if (loginResult)
            {
                System.Diagnostics.Debug.WriteLine("登录成功！");
                System.Diagnostics.Debug.WriteLine("账套名称：" + u8login.cAccName);
                System.Diagnostics.Debug.WriteLine("当前用户：" + u8login.cUserName);
                System.Diagnostics.Debug.WriteLine("当前年度：" + u8login.cIYear);
                System.Diagnostics.Debug.WriteLine("当前月份：" + u8login.iMonth);
                System.Diagnostics.Debug.WriteLine("ces：" + u8login.ShareString);
            }
            else
            {
                string errMsg = "登陆失败,原因:" + u8login.ShareString;
                System.Diagnostics.Debug.WriteLine(errMsg);
                throw new Exception(errMsg);
            }
            return u8login;
        }

        //获取登陆参数
        public clsLogin LoginToU8(Dictionary<string, object> data)

        {
            if (!data.ContainsKey("login") || data["login"] == null)
                throw new Exception("没有找到 login 参数");

            // 将 data["login"] 转换为 JObject
            Dictionary<string, object> loginData = (Dictionary<string, object>)data["login"] ;

            if (loginData == null)
                throw new Exception("login 参数格式不正确");

            // 提取登录参数
            string sAccID = Util.GetLoginParam(loginData, "sAccID").ToString();
            string sYear = Util.GetLoginParam(loginData, "sYear").ToString();
            string user = Util.GetLoginParam(loginData, "User").ToString();
            string password = Util.GetLoginParam(loginData, "Password").ToString();
            string sDate = Util.GetLoginParam(loginData, "sDate").ToString();
            string sServer = Util.GetLoginParam(loginData, "sServer").ToString();

            clsLogin U8clsLogin = LoginToU8("AS", sAccID, sYear, user, password, sDate, sServer, "");

            return U8clsLogin;
        }


    }
}