using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    /// <summary>
    /// Object扩展方法
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 扩展方法，尝试将object转换成DateTime，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object source, DateTime defaultValue = default(DateTime))
        {
            try
            {
                return Convert.ToDateTime(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成decimal，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object source, decimal defaultValue = default(decimal))
        {
            try
            {
                return Convert.ToDecimal(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成double，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static double ToDouble(this object source, double defaultValue = default(double))
        {
            try
            {
                return Convert.ToDouble(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成Int16，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static ushort ToUInt16(this object source, ushort defaultValue = default(ushort))
        {
            try
            {
                return Convert.ToUInt16(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成Int32，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static uint ToUInt32(this object source, uint defaultValue = default(uint))
        {
            try
            {
                return Convert.ToUInt32(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成Int64，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static ulong ToUInt64(this object source, ulong defaultValue = default(ulong))
        {
            try
            {
                return Convert.ToUInt64(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成Int16，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static short ToInt16(this object source, short defaultValue = default(short))
        {
            try
            {
                return Convert.ToInt16(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成Int32，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt32(this object source, int defaultValue = default(int))
        {
            try
            {
                return Convert.ToInt32(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成Int64，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long ToInt64(this object source, long defaultValue = default(long))
        {
            try
            {
                return Convert.ToInt64(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成bool，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool ToBoolean(this object source, bool defaultValue = default(bool))
        {
            try
            {
                return Convert.ToBoolean(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成string，转换失败时，返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ToStringOrNull(this object source, string defaultValue = default(string))
        {
            try
            {
                return Convert.ToString(source);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成string，若不为null时，返回除去前后空白字符的字符串，否则返回null
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToTrim(this object source)
        {
            var str = ToStringOrNull(source);
            return str == null ? null : str.Trim();
        }

        /// <summary>
        /// 扩展方法，尝试将object转换成string，转换失败时，返回string.Empty
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToStringOrEmpty(this object source)
        {
            return ToStringOrNull(source, string.Empty);
        }

        /// <summary>
        /// 将对象转换成Json格式字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name">属性名称</param>
        /// <returns>属性值</returns>
        public static object GetPropertyValue(this object source, string name, object defaultValue = null)
        {
            try
            {
                Type type = source.GetType();
                return type.GetProperty(name).GetValue(source, null);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="name">属性名称</param>
        /// <param name="defaultValue">获取失败时，返回默认值</param>
        /// <returns>属性值</returns>
        public static T GetPropertyValue<T>(this object source, string name, T defaultValue = default(T))
        {
            try
            {
                return (T)GetPropertyValue(source, name, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        /// <returns>返回布尔值，指示是否设置成功</returns>
        public static bool SetPropertyValue(this object source, string name, object value)
        {
            try
            {
                Type type = source.GetType();
                object v = Convert.ChangeType(value, type.GetProperty(name).PropertyType);
                type.GetProperty(name).SetValue(source, v, null);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
