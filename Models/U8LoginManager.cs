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
            try
            {
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
                }
                return u8login;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("登录异常：" + ex.Message);
            }
            return u8login;
        }


    }
}