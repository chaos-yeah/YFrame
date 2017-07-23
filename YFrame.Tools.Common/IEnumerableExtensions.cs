using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    /// <summary>
    /// IEnumerable扩展方法
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// 集合转为表；
        /// 列名默认为属性名称，isDesc=true则为DescriptionAttribute值；
        /// isDesc=true时，请确保每个属性的DescriptionAttribute不为空，否则将异常；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source, bool isDesc = false)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            if (isDesc)
            {
                dt.Columns.AddRange(props.Select(p =>
                                                    new DataColumn
                                                    (
                                                        (p.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute).Description
                                                        , p.PropertyType
                                                    )
                                                ).ToArray()
                                    );
            }
            else
            {
                dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            }
            if (source.Count() > 0)
            {
                for (int i = 0; i < source.Count(); i++)
                {
                    var tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(source.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        /// <summary>
        /// 判断集合是否有元素
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool HasItems<TSource>(this IEnumerable<TSource> source)
        {
            return source != null && source.Count() > 0;
        }

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source == null || source.Count() == 0;
        }

        /// <summary>
        /// 在调用List.Contains前，判断List是否为空。当List为null时，返回false，否则返回List.Contains的返回值
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool TryContains<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            if (source == null)
            {
                return false;
            }

            return source.Contains(item);
        }

        /// <summary>
        /// 集合去重
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.Distinct(new EqualityComparer<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 集合去重
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.Distinct(new EqualityComparer<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 集合排序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> OrderByASCII<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keySelector)
        {
            return source.OrderBy(keySelector, new StringASCIIComparer());
        }
    }

    /// <summary>
    /// IComparer实现类，将字符串集合按照ASCII值排序
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class StringASCIIComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            if (s1 == null && s2 == null)
            {
                return 0;
            }

            if (s1 == null)
            {
                return -1;
            }

            if (s2 == null)
            {
                return 1;
            }

            for (var i = 0; i < s1.Length && i < s2.Length; ++i)
            {
                if (s1[i] == s2[i])
                {
                    continue;
                }

                return s1[i].CompareTo(s2[i]);
            }

            return s1.Length == s2.Length ? 0 : s1.Length < s2.Length ? 1 : -1;
        }
    }

    /// <summary>
    /// IEqualityComparer实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class EqualityComparer<TSource, TKey> : IEqualityComparer<TSource>
    {
        private Func<TSource, TKey> keySelector;
        private IEqualityComparer<TKey> comparer;

        public EqualityComparer(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public EqualityComparer(Func<TSource, TKey> keySelector)
            : this(keySelector, EqualityComparer<TKey>.Default)
        {

        }

        public bool Equals(TSource x, TSource y)
        {
            return comparer.Equals(keySelector(x), keySelector(y));
        }

        public int GetHashCode(TSource obj)
        {
            return comparer.GetHashCode(keySelector(obj));
        }
    }
}
