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

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                // 输出到控制台/日志
                Console.WriteLine("========== 全局异常 ==========");
                Console.WriteLine($"时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"类型: {exception.GetType().FullName}");
                Console.WriteLine($"消息: {exception.Message}");
                Console.WriteLine($"来源: {exception.Source}");
                Console.WriteLine($"路径: {Request?.Url?.AbsoluteUri}");
                Console.WriteLine($"方法: {Request?.HttpMethod}");
                Console.WriteLine($"堆栈: {exception.StackTrace}");
                
                if (exception.InnerException != null)
                {
                    Console.WriteLine($"内部异常: {exception.InnerException.Message}");
                    Console.WriteLine($"内部堆栈: {exception.InnerException.StackTrace}");
                }
                Console.WriteLine("==============================");
            }
        }
    }
}
