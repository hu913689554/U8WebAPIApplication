using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace U8WebAPIApplication.Helpers
{
    /// <summary>
    /// 自定义JSON格式化器，将所有层级的JSON转换为纯Dictionary/List
    /// 仅用于读取请求，写入响应使用默认JsonMediaTypeFormatter
    /// </summary>
    public class JsonDotNetFormatter : MediaTypeFormatter
    {
        public JsonDotNetFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/json"));
        }

        public override bool CanReadType(Type type)
        {
            // 只处理读取：Dictionary 和 object 类型
            return type == typeof(Dictionary<string, object>) ||
                   type == typeof(object);
        }

        public override bool CanWriteType(Type type)
        {
            // 不处理写入，交由默认 JsonMediaTypeFormatter 处理
            return false;
        }

        public override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream,
            HttpContent content,
            IFormatterLogger formatterLogger)
        {
            var charset = content.Headers.ContentType?.CharSet;
            if (string.IsNullOrEmpty(charset))
                charset = "utf-8";

            Encoding encoding;
            try
            {
                encoding = Encoding.GetEncoding(charset);
            }
            catch
            {
                encoding = Encoding.UTF8;
            }

            return ReadFromStreamAsyncCore(type, readStream, encoding);
        }

        private async Task<object> ReadFromStreamAsyncCore(Type type, Stream readStream, Encoding encoding)
        {
            using (var reader = new StreamReader(readStream, encoding))
            {
                var json = await reader.ReadToEndAsync();
                
                // 解析为 JToken
                var jToken = JToken.Parse(json);
                
                // 递归转换为纯 Dictionary/List
                return ConvertToPureObject(jToken);
            }
        }

        /// <summary>
        /// 递归将 JToken 转换为纯 Dictionary/List
        /// </summary>
        private object ConvertToPureObject(JToken token)
        {
            if (token == null) return null;

            switch (token.Type)
            {
                case JTokenType.Object:
                    var dict = new Dictionary<string, object>();
                    foreach (var prop in ((JObject)token).Properties())
                    {
                        dict[prop.Name] = ConvertToPureObject(prop.Value);
                    }
                    return dict;

                case JTokenType.Array:
                    var list = new List<object>();
                    foreach (var item in (JArray)token)
                    {
                        list.Add(ConvertToPureObject(item));
                    }
                    return list;

                case JTokenType.String:
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.Boolean:
                case JTokenType.Date:
                case JTokenType.Guid:
                case JTokenType.Uri:
                case JTokenType.TimeSpan:
                    return ((JValue)token).Value;

                case JTokenType.Null:
                    return null;

                default:
                    return ((JValue)token).Value;
            }
        }
    }
}
