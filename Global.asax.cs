using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace U8WebAPIApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_EndRequest()
        {
            // 处理 API 请求的 404 错误（路由找不到控制器）
            string url = Request?.Url?.AbsoluteUri ?? "";
            if (url.Contains("/api/") && Response.StatusCode == 404)
            {
                Response.Clear();
                Response.ContentType = "application/json";
                Response.StatusCode = 200;
                Response.Write("{\"code\":-1,\"message\":\"请求的资源不存在\",\"data\":null}");
                Response.End();
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                // 输出到控制台/日志
                System.Diagnostics.Debug.WriteLine("========== 全局异常 ==========");
                System.Diagnostics.Debug.WriteLine($"时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                System.Diagnostics.Debug.WriteLine($"类型: {exception.GetType().FullName}");
                System.Diagnostics.Debug.WriteLine($"消息: {exception.Message}");
                System.Diagnostics.Debug.WriteLine($"来源: {exception.Source}");
                System.Diagnostics.Debug.WriteLine($"路径: {Request?.Url?.AbsoluteUri}");
                System.Diagnostics.Debug.WriteLine($"方法: {Request?.HttpMethod}");
                System.Diagnostics.Debug.WriteLine($"堆栈: {exception.StackTrace}");
                
                if (exception.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"内部异常: {exception.InnerException.Message}");
                    System.Diagnostics.Debug.WriteLine($"内部堆栈: {exception.InnerException.StackTrace}");
                }
                System.Diagnostics.Debug.WriteLine("==============================");

                // 判断是否是 API 请求，统一返回 JSON 格式
                string url = Request?.Url?.AbsoluteUri ?? "";
                if (url.Contains("/api/"))
                {
                    // 清除错误
                    Server.ClearError();

                    // 返回统一格式
                    Response.Clear();
                    Response.ContentType = "application/json";
                    Response.StatusCode = 200;

                    string errorMsg = exception.InnerException != null 
                        ? exception.InnerException.Message 
                        : exception.Message;

                    string json = $"{{\"code\":-1,\"message\":\"{errorMsg}\",\"data\":null}}";
                    Response.Write(json);
                    Response.End();
                }
            }
        }
    }
}
