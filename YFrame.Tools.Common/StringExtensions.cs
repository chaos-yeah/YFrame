using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    /// <summary>
    /// String扩展方法
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 过滤脚本标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterScript(this string str)
        {
            return str.Replace("script", "");
        }

        /// <summary>
        /// Format扩展
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string MyFormat(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        /// <summary>
        /// Format扩展
        /// </summary>
        /// <param name="str"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static string MyFormat(this string str, object arg0)
        {
            return string.Format(str, arg0);
        }

        /// <summary>
        /// 判断当前字符串是否为null、Empty或者空白
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return source == null || source == string.Empty || source.Trim() == string.Empty;
        }

        /// <summary>
        /// 字符串超出隐藏
        /// </summary>
        /// <param name="source"></param>
        /// <param name="maxLength">最大字符长度</param>
        /// <param name="ellipse">省略号</param>
        /// <returns></returns>
        public static string ToEllipse(this string source, int maxLength, string ellipse = "...")
        {
            if (source == null)
            {
                return null;
            }

            if (source.Length <= maxLength)
            {
                return source;
            }

            return string.Format("{0}{1}", source.Substring(0, maxLength), ellipse);
        }

        /// <summary>
        /// 尝试将源字符串转换成 T 类型，转换失败会返回 T 的默认值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">源字符串</param>
        /// <returns></returns>
        public static T TryFormatTo<T>(this string source)
            where T : struct
        {
            try
            {
                return FormatTo<T>(source);
            }
            catch { }
            return default(T);
        }

        /// <summary>
        /// 将源字符串转换成 T 类型，转换失败会抛出 FormatException 异常
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">源字符串</param>
        /// <returns></returns>
        public static T FormatTo<T>(this string source)
            where T : struct
        {
            IConvertible convertible = source as IConvertible;
            switch ((default(T) as IConvertible).GetTypeCode())
            {
                case TypeCode.Boolean: { return (T)(object)convertible.ToBoolean(CultureInfo.InvariantCulture); }
                case TypeCode.Char: { return (T)(object)convertible.ToChar(CultureInfo.InvariantCulture); }
                case TypeCode.SByte: { return (T)(object)convertible.ToSByte(CultureInfo.InvariantCulture); }
                case TypeCode.Byte: { return (T)(object)convertible.ToByte(CultureInfo.InvariantCulture); }
                case TypeCode.Int16: { return (T)(object)convertible.ToInt16(CultureInfo.InvariantCulture); }
                case TypeCode.UInt16: { return (T)(object)convertible.ToUInt16(CultureInfo.InvariantCulture); }
                case TypeCode.Int32: { return (T)(object)convertible.ToInt32(CultureInfo.InvariantCulture); }
                case TypeCode.UInt32: { return (T)(object)convertible.ToUInt32(CultureInfo.InvariantCulture); }
                case TypeCode.Int64: { return (T)(object)convertible.ToInt64(CultureInfo.InvariantCulture); }
                case TypeCode.UInt64: { return (T)(object)convertible.ToUInt64(CultureInfo.InvariantCulture); }
                case TypeCode.Single: { return (T)(object)convertible.ToSingle(CultureInfo.InvariantCulture); }
                case TypeCode.Double: { return (T)(object)convertible.ToDouble(CultureInfo.InvariantCulture); }
                case TypeCode.Decimal: { return (T)(object)convertible.ToDecimal(CultureInfo.InvariantCulture); }
                case TypeCode.DateTime: { return (T)(object)convertible.ToDateTime(CultureInfo.InvariantCulture); }
                default: { throw new FormatException(string.Format("\"{0}\"无法转换成{1}", source, typeof(T))); }
            }
        }

        /// <summary>
        /// 默认以 ',' 分割字符串，返回 T 数据类型数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(
            this string source,
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
             where T : struct
        {
            return ToList<T>(source, new string[] { "," }, options);
        }

        /// <summary>
        /// 默认以 separator 分割字符串，返回 T 数据类型数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(
            this string source,
            string[] separator,
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
             where T : struct
        {
            if (source == null)
            {
                return null;
            }

            var sArray = source.Split(separator, options);
            if (sArray.IsNullOrEmpty())
            {
                return null;
            }

            return sArray.Select(e => e.FormatTo<T>()).ToList();
        }
    }
}
