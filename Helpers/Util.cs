using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;


namespace Helpers
{
    /// <summary>
    /// Utility to convert xml files produced in the U8 style (with rs:data / z:row elements)
    /// into a JSON array. Each z:row becomes a JSON object with its attributes as properties.
    /// This class avoids external JSON dependencies and produces a compact JSON string.
    /// </summary>
    public static class Util
    {
        public static object GetLoginParam(JObject loginData, string key)
        {
            var value = loginData.GetValue(key, StringComparison.OrdinalIgnoreCase);
            if (value != null)
                return value;
            return "";
        }
        public static object GetLoginParam(Dictionary<string, object> loginData, string key)
        {
            if (loginData == null || string.IsNullOrEmpty(key))
                return "";

            // 使用不区分大小写的比较器查找键
            var comparer = StringComparer.OrdinalIgnoreCase;

            // 方法1: 遍历字典查找不区分大小写的键
            foreach (var kvp in loginData)
            {
                if (comparer.Equals(kvp.Key, key))
                {
                    return kvp.Value ?? "";
                }
            }

            return "";

        }
        /// <summary>
        /// 获取 DOM
        /// </summary>
        /// <param name="Strsql">SQL 查询语句</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <returns>包含查询结果的 XML DOM 对象</returns>
        public static MSXML2.DOMDocument getDom(string Strsql, string strConn)
        {
            MSXML2.DOMDocument dom = new MSXML2.DOMDocument();
            ADODB.Connection conn = new ADODB.Connection();
            ADODB.Recordset rs = new ADODB.Recordset();

            conn.Open(strConn);
            rs.Open(Strsql, conn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic, -1);
            rs.Save(dom, ADODB.PersistFormatEnum.adPersistXML);
            return dom;
        }

        /// <summary>
        /// 查找XML节点（支持命名空间）
        /// </summary>
        private static MSXML2.IXMLDOMNode FindDataNode(MSXML2.IXMLDOMDocument2 doc)
        {
            // 方法1: 尝试带命名空间的前缀
            MSXML2.IXMLDOMNode node = doc.selectSingleNode("//rs:data");
            if (node != null) return node;
            
            // 方法2: 尝试不带命名空间
            node = doc.selectSingleNode("//data");
            if (node != null) return node;
            
            // 方法3: 使用local-name()忽略命名空间
            node = doc.selectSingleNode("//*[local-name()='data']");
            if (node != null) return node;
            
            // 方法4: 直接使用documentElement
            return doc.documentElement;
        }

        /// <summary>
        /// 转换头部XML
        /// </summary>
        /// <param name="doc">XML文档对象</param>
        /// <param name="parameter">参数对象</param>
        public static void ConvertHeadXML(MSXML2.IXMLDOMDocument2 doc, JObject parameter)
        {
            MSXML2.IXMLDOMNode node = FindDataNode(doc);
            
            if (node == null)
            {
                Console.WriteLine("ConvertHeadXML: 找不到 data 节点");
                Console.WriteLine("XML内容: " + doc.xml);
                throw new Exception("找不到 data 节点，XML结构可能不正确");
            }

            MSXML2.IXMLDOMElement element = doc.createElement("z:row");

            Parameter(element, parameter);
            node.appendChild(element);
        }

        /// <summary>
        /// 转换头部XML
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="doc">XML文档对象</param>
        /// <param name="parameter">参数对象</param>
        public static void ConvertHeadXML<T>(MSXML2.IXMLDOMDocument2 doc, T parameter)
        {
            MSXML2.IXMLDOMNode node = FindDataNode(doc);
            
            if (node == null)
            {
                Console.WriteLine("ConvertHeadXML: 找不到 data 节点");
                Console.WriteLine("XML内容: " + doc.xml);
                throw new Exception("找不到 data 节点，XML结构可能不正确");
            }

            MSXML2.IXMLDOMElement element = doc.createElement("z:row");

            Parameter(element, parameter);
            node.appendChild(element);
        }

        /// <summary>
        /// 转换主体XML
        /// </summary>
        /// <param name="doc">XML文档对象</param>
        /// <param name="parameter">参数对象列表</param>
        public static void ConvertBodyXML(MSXML2.IXMLDOMDocument2 doc, JArray parameter)
        {
            MSXML2.IXMLDOMNode node = FindDataNode(doc);
            
            if (node == null)
            {
                Console.WriteLine("ConvertBodyXML: 找不到 data 节点");
                Console.WriteLine("XML内容: " + doc.xml);
                throw new Exception("找不到 data 节点，XML结构可能不正确");
            }

            foreach (JObject body in parameter)
            {
                MSXML2.IXMLDOMElement element = doc.createElement("z:row");
                Parameter(element, body);
                node.appendChild(element);
            }
        }

        /// <summary>
        /// 将JObject属性转换为XML元素属性
        /// </summary>
        /// <param name="element">XML元素</param>
        /// <param name="parameter">JObject参数</param>
        public static void Parameter(MSXML2.IXMLDOMElement element, JObject parameter)
        {
            foreach (var property in parameter.Properties())
            {
                string key = property.Name;
                JToken value = property.Value;
                if (value != null && value.Type != JTokenType.Null && !string.IsNullOrEmpty(value.ToString()))
                {
                    // 处理日期时间类型
                    if (value.Type == JTokenType.Date)
                    {
                        DateTime dt = value.ToObject<DateTime>();
                        element.setAttribute(key, dt.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        element.setAttribute(key, value.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 将对象属性转换为XML元素属性
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="element">XML元素</param>
        /// <param name="parameter">参数对象</param>
        public static void Parameter<T>(MSXML2.IXMLDOMElement element, T parameter)
        {
            object value = null;

            foreach (PropertyInfo pi in parameter.GetType().GetProperties())
            {
                value = pi.GetValue(parameter, null);

                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    if (pi.PropertyType.FullName.IndexOf("System.DateTime") != -1)
                    {
                        DateTime dt = (DateTime)pi.GetValue(parameter, null);
                        element.setAttribute(pi.Name, dt.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        element.setAttribute(pi.Name, value.ToString());
                    }
                }
            }
        }




    }
}
