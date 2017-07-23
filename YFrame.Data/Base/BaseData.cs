using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Data.Base
{
    public class BaseData<T> : Repository<T> where T : Entity
    {
        /// <summary>
        /// 连接默认数据库
        /// </summary>
        public BaseData() : base(Db.dbSession) { }
        /// <summary>
        /// 连接自定义数据库
        /// </summary>
        /// <param name="dbSession"></param>
        public BaseData(DbSession dbSession) : base(dbSession) { }
    }
}
