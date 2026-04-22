using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Helpers
{
    /// <summary>
    /// Utility to convert xml files produced in the U8 style (with rs:data / z:row elements)
    /// into a JSON array. Each z:row becomes a JSON object with its attributes as properties.
    /// This class avoids external JSON dependencies and produces a compact JSON string.
    /// </summary>
    public static class XmlRsDataConverter
    {
        // XML 字符串转 JSON 字符串
        public static string ConvertXmlToJson(string xml, string namespacePrefix = "z")
        {
            try
            {
                object result = ConvertXmlToObject(xml, namespacePrefix);
                return JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw new Exception($"XML转换失败: {ex.Message}", ex);
            }
        }

        // XML 字符串转可操作对象
        public static object ConvertXmlToObject(string xml, string namespacePrefix = "z")
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                // 创建命名空间管理器
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("rs", "urn:schemas-microsoft-com:rowset");
                nsmgr.AddNamespace("z", "#RowsetSchema");
                nsmgr.AddNamespace("s", "uuid:BDC6E3F0-6DA3-11d1-A2A3-00AA00C14882");
                nsmgr.AddNamespace("dt", "uuid:C2F41010-65B3-11d1-A29F-00AA00C14882");

                // 查找 rs:data 节点
                XmlNode dataNode = doc.SelectSingleNode("//rs:data", nsmgr);

                if (dataNode == null)
                {
                    throw new Exception("未找到 rs:data 节点");
                }

                // 提取所有行
                XmlNodeList rowNodes = dataNode.SelectNodes($"//{namespacePrefix}:row", nsmgr);

                // 多行数据，返回数组
                var rowList = new List<Dictionary<string, object>>();
                foreach (XmlNode rowNode in rowNodes)
                {
                    rowList.Add(ExtractRowData(rowNode));
                }
                return rowList;
            }
            catch (Exception ex)
            {
                throw new Exception($"XML转换失败: {ex.Message}", ex);
            }
        }

        private static Dictionary<string, object> ExtractRowData(XmlNode rowNode)
        {
            var rowData = new Dictionary<string, object>();

            if (rowNode.Attributes != null)
            {
                foreach (XmlAttribute attr in rowNode.Attributes)
                {
                    // 将属性名和值添加到字典
                    rowData[attr.Name] = attr.Value;
                }
            }

            return rowData;
        }
    }
}
