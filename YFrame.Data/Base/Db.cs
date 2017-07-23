using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Data.Base
{
    public class Db
    {
        public static readonly DbSession dbSession = GetDbSession(DatabaseType.MySql);
        /// <summary>
        /// 创建数据访问Session
        /// </summary>
        /// <param name="databaseType">数据库类型</param>
        /// <param name="connectName"></param>
        /// <returns></returns>
        private static DbSession GetDbSession(DatabaseType databaseType, string connectStr = "DefaultConnect")
        {
            try
            {
                if (ConfigurationManager.ConnectionStrings[connectStr] == null) return null;

                // 获取SQL连接字符串
                string connectionString = ConfigurationManager.ConnectionStrings[connectStr].ConnectionString;
                return new DbSession(databaseType, connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
