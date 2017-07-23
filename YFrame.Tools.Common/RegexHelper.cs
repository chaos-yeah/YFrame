using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    /// <summary>
    /// 正则助手
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 字母数字
        /// </summary>
        public const string Alphanum = @"^[A-Za-z0-9]+$";

        /// <summary>
        /// 字符限制：数字、字母、.、-
        /// </summary>
        public const string StringRegular = @"^[A-Za-z0-9.-]+$";

        /// <summary>
        /// 账号
        /// </summary>
        public const string UserCode = @"^((?!([aA][dD][mM][iI][nN])).)\w+$";

        /// <summary>
        /// 密码
        /// </summary>
        public const string Password = @"^\w*[@~#]*\w*[@~#]*\w*$";

        /// <summary>
        /// 身份证格式
        /// </summary>
        public const string IdCardNo = "(^[1-9][0-9]{14}$)|(^[1-9][0-9]{17}$)|(^[1-9][0-9]{16}([0-9]|X|x))$";

        /// <summary>
        /// 人物姓名
        /// </summary>
        public const string PersonName = @"";

        /// <summary>
        /// 电子邮件
        /// </summary>
        /// public const string Email = @"^(\w+[\w\-]*[.]?[\w\-]*\w+)+[@][A-Za-z0-9\-]+(([.])|([.][\w\-]+[.][\w\-]+[.])*)[A-Za-z0-9\-]+$";
        public const string Email = @"^(\w+([.]\w+)*)[@](\w+([.]\w+)+)$";

        /// <summary>
        /// 互联网Url
        /// </summary>
        public const string Url = @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";

        /// <summary>
        /// 电话号码
        /// </summary>
        public const string Phone = @"^[\d\-\+]*$";

        /// <summary>
        /// 固定电话号码
        /// </summary>
        /// public const string Telephone = @"^0((\d{2}-?\d{8})|(\d{3}-?\d{7}))$";
        public const string Telephone = @"^\d+[-]\d+$";

        /// <summary>
        /// 移动电话号码
        /// </summary>
        /// public const string Cellphone = @"^((\+?86)|(\(\+86\)))?(13[012356789][0-9]{8}|15[012356789][0-9]{8}|18[02356789][0-9]{8}|147[0-9]{8}|1349[0-9]{7})$";
        public const string Cellphone = @"^\d+[-]\d+$";

        /// <summary>
        /// 图片
        /// </summary>
        public const string Image = @"^.*[.](([jJ][pP][eE]?[gG])|([gG][iI][fF])|([pP][nN][gG])|([bB][mM][pP]))$";

        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="pattern">指定正则</param>
        /// <returns></returns>
        public static bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 在指定的输入字符串中搜索指定的正则表达式的第一个匹配项
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="pattern">指定正则</param>
        /// <returns></returns>
        public static string GetMatch(string input, string pattern)
        {
            var result = Regex.Match(input, pattern);
            return result.ToString();
        }
    }
}
