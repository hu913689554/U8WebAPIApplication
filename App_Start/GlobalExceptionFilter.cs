using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace U8WebAPIApplication
{
    /// <summary>
    /// WebAPI 全局异常过滤器 - 统一返回格式
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HandleException(context);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            HandleException(context);
            return Task.CompletedTask;
        }

        private void HandleException(HttpActionExecutedContext context)
        {
            Exception exception = context.Exception;
            
            // 获取错误信息
            string errorMsg = exception.InnerException != null 
                ? exception.InnerException.Message 
                : exception.Message;

            // 记录日志
            System.Diagnostics.Debug.WriteLine("========== WebAPI 全局异常 ==========");
            System.Diagnostics.Debug.WriteLine($"时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            System.Diagnostics.Debug.WriteLine($"类型: {exception.GetType().FullName}");
            System.Diagnostics.Debug.WriteLine($"消息: {exception.Message}");
            System.Diagnostics.Debug.WriteLine($"堆栈: {exception.StackTrace}");
            if (exception.InnerException != null)
            {
                System.Diagnostics.Debug.WriteLine($"内部异常: {exception.InnerException.Message}");
                System.Diagnostics.Debug.WriteLine($"内部堆栈: {exception.InnerException.StackTrace}");
            }
            System.Diagnostics.Debug.WriteLine("======================================");

            // 统一返回格式
            var result = new
            {
                code = -1,
                message = errorMsg,
                data = (object)null
            };

            // 创建响应
            context.Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(result),
                    System.Text.Encoding.UTF8,
                    "application/json"
                )
            };
        }
    }

    /// <summary>
    /// 自定义 IHttpActionResult 返回错误信息
    /// </summary>
    public class ErrorResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly string _errorMessage;

        public ErrorResult(HttpRequestMessage request, string errorMessage)
        {
            _request = request;
            _errorMessage = errorMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var responseData = new
            {
                code = -1,
                message = _errorMessage,
                data = (object)null
            };

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(responseData),
                    System.Text.Encoding.UTF8,
                    "application/json"
                ),
                RequestMessage = _request
            };

            return Task.FromResult(response);
        }
    }
}
