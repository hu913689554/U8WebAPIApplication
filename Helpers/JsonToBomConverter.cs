using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace U8WebAPIApplication.Helpers
{
    /// <summary>
    /// JSON 转 BOM 对象的转换器（大小写不敏感）
    /// </summary>
    public static class JsonToBomConverter
    {
        /// <summary>
        /// 将 Dictionary 转换为 Bom_Parent
        /// </summary>
        public static Bom_Parent ConvertToBomParent(Dictionary<string, object> data)
        {
            var parent = new Bom_Parent();
            
            // 获取 head 对象
            if (data.ContainsKey("head") && data["head"] is Dictionary<string, object> head)
            {
                SetPropertyValues(parent, head, GetPropertyMapping<Bom_Parent>());
            }
            
            return parent;
        }

        /// <summary>
        /// 将 body 数组转换为 List<Bom_Component>
        /// </summary>
        public static List<Bom_Component> ConvertToBomComponentList(Dictionary<string, object> data)
        {
            var result = new List<Bom_Component>();
            
            if (data.ContainsKey("body") && data["body"] is IEnumerable bodyList)
            {
                foreach (var item in bodyList)
                {
                    if (item is Dictionary<string, object> componentDict)
                    {
                        var component = new Bom_Component();
                        var mapping = GetPropertyMapping<Bom_Component>();
                        SetPropertyValues(component, componentDict, mapping);
                        
                        // 处理 Bom_ComponentSubsList
                        if (componentDict.ContainsKey("Bom_ComponentSubsList") && componentDict["Bom_ComponentSubsList"] is IEnumerable subsList)
                        {
                            component.bomcomponentSubsList = new List<Bom_ComponentSubs>();
                            foreach (var subsItem in subsList)
                            {
                                if (subsItem is Dictionary<string, object> subsDict)
                                {
                                    var subs = new Bom_ComponentSubs();
                                    SetPropertyValues(subs, subsDict, GetPropertyMapping<Bom_ComponentSubs>());
                                    component.bomcomponentSubsList.Add(subs);
                                }
                            }
                        }
                        
                        // 处理 Bom_ComponentSubs (单个对象转List)
                        if (componentDict.ContainsKey("Bom_ComponentSubs") && componentDict["Bom_ComponentSubs"] is Dictionary<string, object> subsSingle)
                        {
                            if (component.bomcomponentSubsList == null)
                                component.bomcomponentSubsList = new List<Bom_ComponentSubs>();
                            
                            var subs = new Bom_ComponentSubs();
                            SetPropertyValues(subs, subsSingle, GetPropertyMapping<Bom_ComponentSubs>());
                            component.bomcomponentSubsList.Add(subs);
                        }
                        
                        // 处理 Bom_ComponentLocList
                        if (componentDict.ContainsKey("Bom_ComponentLocList") && componentDict["Bom_ComponentLocList"] is IEnumerable locList)
                        {
                            component.bom_componentLocList = new List<Bom_ComponentLoc>();
                            foreach (var locItem in locList)
                            {
                                if (locItem is Dictionary<string, object> locDict)
                                {
                                    var loc = new Bom_ComponentLoc();
                                    SetPropertyValues(loc, locDict, GetPropertyMapping<Bom_ComponentLoc>());
                                    component.bom_componentLocList.Add(loc);
                                }
                            }
                        }
                        
                        // 处理 Bom_ComponentLoc (单个对象转List)
                        if (componentDict.ContainsKey("Bom_ComponentLoc") && componentDict["Bom_ComponentLoc"] is Dictionary<string, object> locSingle)
                        {
                            if (component.bom_componentLocList == null)
                                component.bom_componentLocList = new List<Bom_ComponentLoc>();
                            
                            var loc = new Bom_ComponentLoc();
                            SetPropertyValues(loc, locSingle, GetPropertyMapping<Bom_ComponentLoc>());
                            component.bom_componentLocList.Add(loc);
                        }
                        
                        result.Add(component);
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// 获取类型属性名映射（属性名小写 → 属性名）
        /// </summary>
        private static Dictionary<string, string> GetPropertyMapping<T>() where T : class
        {
            var properties = typeof(T).GetProperties();
            var mapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            
            foreach (var prop in properties)
            {
                mapping[prop.Name.ToLower()] = prop.Name;
            }
            
            return mapping;
        }

        /// <summary>
        /// 设置对象属性值（大小写不敏感）
        /// </summary>
        private static void SetPropertyValues(object obj, Dictionary<string, object> source, Dictionary<string, string> mapping)
        {
            var type = obj.GetType();
            
            foreach (var kvp in source)
            {
                var keyLower = kvp.Key.ToLower();
                if (mapping.TryGetValue(keyLower, out string propertyName))
                {
                    var prop = type.GetProperty(propertyName);
                    if (prop != null && prop.CanWrite)
                    {
                        try
                        {
                            var value = ConvertValue(kvp.Value, prop.PropertyType);
                            prop.SetValue(obj, value);
                        }
                        catch { /* 忽略转换失败 */ }
                    }
                }
            }
        }

        /// <summary>
        /// 值类型转换
        /// </summary>
        private static object ConvertValue(object value, Type targetType)
        {
            if (value == null || value == DBNull.Value)
                return null;

            var sourceType = value.GetType();
            
            // 如果源类型已经是目标类型，直接返回
            if (targetType.IsAssignableFrom(sourceType))
                return value;

            // 处理 JValue
            if (value is JValue jValue)
                value = jValue.Value;

            // 处理 JToken
            if (value is JToken jToken)
                value = jToken.Type == JTokenType.Null ? null : jToken.ToObject<object>();

            if (value == null)
                return null;

            sourceType = value.GetType();

            // nullable 类型处理
            var nullableType = Nullable.GetUnderlyingType(targetType);
            if (nullableType != null)
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    return null;
                targetType = nullableType;
            }

            // 基础类型转换
            if (targetType == typeof(string))
                return value.ToString();

            if (targetType == typeof(int) || targetType == typeof(int?))
            {
                if (int.TryParse(value.ToString(), out int result))
                    return result;
                return 0;
            }

            if (targetType == typeof(double) || targetType == typeof(double?))
            {
                if (double.TryParse(value.ToString(), out double result))
                    return result;
                return 0.0;
            }

            if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
            {
                if (DateTime.TryParse(value.ToString(), out DateTime result))
                    return result;
                return DateTime.MinValue;
            }

            if (targetType == typeof(bool) || targetType == typeof(bool?))
            {
                if (bool.TryParse(value.ToString(), out bool result))
                    return result;
                if (int.TryParse(value.ToString(), out int intResult))
                    return intResult != 0;
                return false;
            }

            // 其他类型尝试直接转换
            try
            {
                return Convert.ChangeType(value, targetType);
            }
            catch
            {
                return null;
            }
        }
    }
}
