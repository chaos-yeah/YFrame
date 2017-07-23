using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    /// <summary>
    /// API请求助手
    /// </summary>
    public class ApiHelper
    {
        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postValues"></param>
        /// <returns></returns>
        public static T Post<T>(string url, NameValueCollection postValues) where T : new()
        {
            var response = Post(url, postValues);
            if (!string.IsNullOrEmpty(response))
            {
                T result = JsonConvert.DeserializeObject<T>(response);
                return result;
            }
            return default(T);
        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Post(string url, NameValueCollection args)
        {
            var client = new WebClient();
            byte[] responseArray = client.UploadValues(url, args);
            string response = Encoding.UTF8.GetString(responseArray);
            return response;
        }

        //需要System.Net.Http.Formatting.dll
        //public static string PostAsync<T>(string url, T request)
        //{
        //    HttpClient client = new HttpClient();
        //    var responseMessage = client.PostAsJsonAsync(url, request).Result;
        //    string response = responseMessage.Content.ReadAsStringAsync().Result;
        //    return response;
        //}
    }
}
