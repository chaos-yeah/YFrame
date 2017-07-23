using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace YFrame.Tools.IP
{
    /// <summary>
    /// IP助手
    /// </summary>
    public class IPHelper
    {
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 获取真实IP
        /// </summary>
        /// <returns></returns>
        public static string GetRealIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //可能有代理 
            if (!string.IsNullOrWhiteSpace(result))
            {
                //没有"." 肯定是非IP格式
                if (result.IndexOf(".") == -1)
                {
                    result = null;
                }
                else
                {
                    //有","，估计多个代理。取第一个不是内网的IP。
                    if (result.IndexOf(",") != -1)
                    {
                        result = result.Replace(" ", string.Empty).Replace("\"", string.Empty);

                        string[] temparyip = result.Split(",;".ToCharArray());

                        if (temparyip != null && temparyip.Length > 0)
                        {
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                //找到不是内网的地址
                                if (IsIPAddress(temparyip[i])
                                    && temparyip[i].Substring(0, 3) != "10."
                                    && temparyip[i].Substring(0, 7) != "192.168"
                                    && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i];
                                }
                            }
                        }
                    }
                    //代理即是IP格式
                    else if (IsIPAddress(result))
                    {
                        return result;
                    }
                    //代理中的内容非IP
                    else
                    {
                        result = "127.0.0.1";
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            return result;
        }

        /// <summary>
        /// 获取代理ip
        /// </summary>
        /// <returns></returns>
        public static string GetProxyIp()
        {
            var result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                return "";
            }
            return result;
        }

        /// <summary>
        /// 获取客户端本地IP
        /// </summary>
        /// <param name="type">内网ip</param>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        /// <summary>
        /// 获取时区ID
        /// </summary>
        /// <returns></returns>
        public static string GetTimeZoneInfo()
        {
            TimeZoneInfo local = TimeZoneInfo.Local;
            return local.Id;
        }

        /// <summary>
        /// 是否是IP地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 7 || str.Length > 15)
                return false;

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}{1}";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(str);
        }

        /// <summary>
        /// 获取操作系统
        /// </summary>
        /// <returns></returns>
        public static string GetOprationSystem()
        {
            var userAgent = HttpContext.Current.Request.UserAgent;
            string osVersion = "未知";
            if (!string.IsNullOrEmpty(userAgent))
            {
                if (userAgent.Contains("NT 6."))
                {
                    osVersion = "Windows Vista/Server 2008";
                }
                else if (userAgent.Contains("NT 5.2"))
                {
                    osVersion = "Windows Server 2003";
                }
                else if (userAgent.Contains("NT 5.1"))
                {
                    osVersion = "Windows XP";
                }
                else if (userAgent.Contains("NT 5"))
                {
                    osVersion = "Windows 2000";
                }
                else if (userAgent.Contains("NT 4"))
                {
                    osVersion = "Windows NT4";
                }
                else if (userAgent.Contains("NT"))
                {
                    osVersion = "Windows 8及以上版本";
                }
                else if (userAgent.Contains("Me"))
                {
                    osVersion = "Windows Me";
                }
                else if (userAgent.Contains("98"))
                {
                    osVersion = "Windows 98";
                }
                else if (userAgent.Contains("95"))
                {
                    osVersion = "Windows 95";
                }
                else if (userAgent.Contains("Mac"))
                {
                    osVersion = "Mac";
                }
                else if (userAgent.Contains("Unix"))
                {
                    osVersion = "UNIX";
                }
                else if (userAgent.Contains("Linux"))
                {
                    osVersion = "Linux";
                }
                else if (userAgent.Contains("SunOS"))
                {
                    osVersion = "SunOS";
                }
            }
            return osVersion;
        }
    }
}
