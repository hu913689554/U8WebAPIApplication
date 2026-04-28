using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using U8WebAPIApplication.Helpers;

namespace U8WebAPIApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.Filters.Add(new GlobalExceptionFilter()); // 注册全局异常过滤器

            // 替换默认的 JSON 格式化器，启用纯 Dictionary/List 转换
            config.Formatters.Clear();
            config.Formatters.Add(new JsonDotNetFormatter()); // 读取请求用
            config.Formatters.Add(new JsonMediaTypeFormatter()); // 写入响应用

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
