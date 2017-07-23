using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace YFrame.Data.Base
{
    public abstract class Repository<T> where T : Entity
    {
        protected DbSession CurrentSession;

        protected Repository(DbSession session)
        {
            this.CurrentSession = session;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public DbTrans BeginTransaction()
        {
            return this.CurrentSession.BeginTransaction();
        }

        #region 查询

        /// <summary>
        /// 得到所有的数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return this.CurrentSession.From<T>().ToList();
        }

        /// <summary>
        /// 得到所有的数据，返回一个DataTable
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetAllDT()
        {
            return this.CurrentSession.From<T>().ToDataTable();
        }

        /// <summary>
        /// 通过条件得到集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> GetList(Where<T> where, Expression<Func<T, object>> orderby = null, OrderByType orderbyType = OrderByType.DESC, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderby);
                }
                else
                {
                    fs.OrderBy(orderby);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }

            return fs.ToList<T>();
        }

        /// <summary>
        /// 通过条件得到集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> GetList(Where<T> where, OrderByClip orderby, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }

            return fs.ToList<T>();
        }

        /// <summary>
        /// 通过条件得到集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby = null, OrderByType orderbyType = OrderByType.DESC, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderby);
                }
                else
                {
                    fs.OrderBy(orderby);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToList();
        }

        /// <summary>
        /// 通过条件得到集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> where, OrderByClip orderby = null, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToList();
        }

        /// <summary>
        /// 通过条件得到集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public DataTable GetListToTable(Where<T> where, Expression<Func<T, object>> orderby = null, OrderByType orderbyType = OrderByType.ASC, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderby);
                }
                else
                {
                    fs.OrderBy(orderby);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToDataTable();
        }

        /// <summary>
        /// 通过条件得到集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public DataTable GetListToTable(Where<T> where, OrderByClip orderby = null, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToDataTable();
        }

        /// <summary>
        /// 通过条件得到单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public T GetFirst(Where<T> where, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.First();
        }

        /// <summary>
        /// 通过条件得到单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> where, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.First();
        }


        /// <summary>
        /// 通过条件得到单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public T GetFirst(Where<T> where, Expression<Func<T, object>> orderby = null, OrderByType orderbyType = OrderByType.ASC, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderby);
                }
                else
                {
                    fs.OrderBy(orderby);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.First();
        }

        /// <summary>
        /// 通过条件得到单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public T GetFirst(Where<T> where, OrderByClip orderby = null, params Field[] fields)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.First();
        }

        /// <summary>
        /// 得到top的几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="orderbyType"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> GetTop(int top, Where<T> where, Expression<Func<T, object>> orderby = null, OrderByType orderbyType = OrderByType.ASC, params Field[] fields)
        {
            if (top == 0)
            {
                throw new Exception("top 值不能为0");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            fs.Top(top);
            if (orderby != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderby);
                }
                else
                {
                    fs.OrderBy(orderby);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToList();
        }

        /// <summary>
        /// 得到top的几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> GetTop(int top, Where<T> where, OrderByClip orderby = null, params Field[] fields)
        {
            if (top == 0)
            {
                throw new Exception("top 值不能为0");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            fs.Top(top);
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToList();
        }

        /// <summary>
        /// 得到top的几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public DataTable GetTableByTop(int top, Where<T> where, OrderByClip orderby = null, params Field[] fields)
        {
            if (top == 0)
            {
                throw new Exception("top 值不能为0");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            fs.Top(top);
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            return fs.ToDataTable();
        }

        /// <summary>
        /// 通过条件得到指定字段的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="field">查询字段</param>
        /// <returns></returns>
        public Object GetToScalar(Where<T> where, Field field)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            fs.Select(field);
            return fs.ToScalar();
        }

        /// <summary>
        /// 通过条件得到指定字段的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="field">查询字段</param>
        /// <returns></returns>
        public K GetToScalar<K>(Where<T> where, Field field)
        {
            var fs = this.CurrentSession.From<T>().Where(where);
            fs.Select(field);
            return fs.ToScalar<K>();
        }

        /// <summary>
        /// 分页查询数据，输出总项数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> Query(Where<T> where, int pageIndex, int pageSize,
            out int recordCount,
            OrderByClip orderby = null, params Field[] fields)
        {
            if (pageIndex <= 0)
            {
                throw new Exception("pageIndex 值必须大于0！");
            }
            if (pageSize <= 0)
            {
                throw new Exception("pageSize 值必须大于0！");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            recordCount = fs.Count();
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            fs.Page(pageSize, pageIndex);
            return fs.ToList();
        }

        /// <summary>
        /// 分页查询数据，输出总项数和总页数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderby"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> Query(Where<T> where, int pageIndex, int pageSize,
            out int recordCount, out int pageCount,
            OrderByClip orderby = null, params Field[] fields)
        {
            if (pageIndex <= 0)
            {
                throw new Exception("pageIndex 值必须大于0！");
            }
            if (pageSize <= 0)
            {
                throw new Exception("pageSize 值必须大于0！");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            recordCount = fs.Count();
            pageCount = (recordCount + pageSize - 1) / pageSize;
            if (orderby != null)
            {
                fs.OrderBy(orderby);
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            fs.Page(pageSize, pageIndex);
            return fs.ToList();
        }

        /// <summary>
        /// 分页查询数据，输出总项数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="orderbyType"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> Query(Expression<Func<T, bool>> where,
            int pageIndex, int pageSize,
            out int recordCount,
            Expression<Func<T, object>> orderBy = null, OrderByType orderbyType = OrderByType.DESC, params Field[] fields)
        {
            if (pageIndex <= 0)
            {
                throw new Exception("pageIndex 值必须大于0！");
            }
            if (pageSize <= 0)
            {
                throw new Exception("pageSize 值必须大于0！");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            recordCount = fs.Count();
            if (orderBy != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderBy);
                }
                else
                {
                    fs.OrderBy(orderBy);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            fs.Page(pageSize, pageIndex);
            return fs.ToList();
        }

        /// <summary>
        /// 分页查询数据，输出总项数和总页数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderby"></param>
        /// <param name="orderbyType"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<T> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize,
            out int recordCount, out int pageCount,
            Expression<Func<T, object>> orderby = null, OrderByType orderbyType = OrderByType.ASC, params Field[] fields)
        {
            if (pageIndex <= 0)
            {
                throw new Exception("pageIndex 值必须大于0！");
            }
            if (pageSize <= 0)
            {
                throw new Exception("pageSize 值必须大于0！");
            }
            var fs = this.CurrentSession.From<T>().Where(where);
            recordCount = fs.Count();
            pageCount = (recordCount + pageSize - 1) / pageSize;
            if (orderby != null)
            {
                if (orderbyType == OrderByType.DESC)
                {
                    fs.OrderByDescending(orderby);
                }
                else
                {
                    fs.OrderBy(orderby);
                }
            }
            if (fields != null)
            {
                fs.Select(fields);
            }
            fs.Page(pageSize, pageIndex);
            return fs.ToList();
        }

        /// <summary>
        /// 根据条件判断是否存在数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Exists(Expression<Func<T, bool>> where)
        {
            return this.CurrentSession.Exists<T>(where);
        }

        /// <summary>
        /// 根据条件判断是否存在数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Exists(Where where)
        {
            return this.CurrentSession.Exists<T>(where);
        }

        /// <summary>
        /// 取总数
        /// </summary>
        public int Count(Expression<Func<T, bool>> where)
        {
            return this.CurrentSession.From<T>().Where(where).Count();
        }

        /// <summary>
        /// 取总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Count(Where<T> where)
        {
            return this.CurrentSession.From<T>().Where(where).Count();
        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            return this.CurrentSession.Insert<T>(entity);
        }

        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(DbTrans context, T entity)
        {
            return this.CurrentSession.Insert<T>(context, entity);
        }

        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert(IEnumerable<T> entities)
        {
            return this.CurrentSession.Insert<T>(entities);
        }

        public void Insert(DbTrans context, IEnumerable<T> entities)
        {
            this.CurrentSession.Insert<T>(context, entities.ToArray());
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            return this.CurrentSession.Update(entity);
        }

        /// <summary>
        /// 更新单个实体
        /// </summary>
        public int Update(T entity, Where where)
        {
            return this.CurrentSession.Update(entity, where);
        }

        /// <summary>
        /// 更新单个实体
        /// </summary>
        public int Update(T entity, Expression<Func<T, bool>> lambdaWhere)
        {
            return this.CurrentSession.Update(entity, lambdaWhere);
        }

        public int Update(DbTrans context, T entity)
        {
            return this.CurrentSession.Update(context, entity);
        }

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update(IEnumerable<T> entities)
        {
            var enumerable = entities as T[] ?? entities.ToArray();
            this.CurrentSession.Update(enumerable.ToArray());
            return 1;
        }

        public int Update(DbTrans context, IEnumerable<T> entities)
        {
            return this.CurrentSession.Update(context, entities.ToArray());
        }

        public int Update(Dictionary<Field, object> fieldValue, Expression<Func<T, bool>> lambdaWhere)
        {
            return this.CurrentSession.Update(fieldValue, lambdaWhere);
        }

        public int Update(DbTrans context, Dictionary<Field, object> fieldValue, Expression<Func<T, bool>> lambdaWhere)
        {
            return this.CurrentSession.Update(context, fieldValue, lambdaWhere);
        }

        public int Update(Dictionary<Field, object> fieldValue, Where where)
        {
            return this.CurrentSession.Update<T>(fieldValue, where);
        }

        public int Update(Dictionary<Field, object> fieldValue, WhereClip where)
        {
            return this.CurrentSession.Update<T>(fieldValue, where);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除单个实体
        /// </summary>
        public int Delete(T entitie)
        {
            return this.CurrentSession.Delete<T>(entitie);
        }

        /// <summary>
        /// 删除多个实体
        /// </summary>
        public int Delete(IEnumerable<T> entities)
        {
            return this.CurrentSession.Delete<T>(entities);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual int Delete(Guid? id)
        {
            if (id == null)
            {
                return 0;
            }
            return this.CurrentSession.Delete<T>(id.Value);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        public int Delete(Expression<Func<T, bool>> where)
        {
            return this.CurrentSession.Delete<T>(where);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        public int Delete(Where<T> where)
        {
            return this.CurrentSession.Delete<T>(where.ToWhereClip());
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        public int Delete(DbTrans trans, Expression<Func<T, bool>> where)
        {
            return this.CurrentSession.Delete<T>(trans, where);
        }
        #endregion

    }

    public enum OrderByType
    {
        /// <summary>
        /// 正序
        /// </summary>
        ASC,
        /// <summary>
        /// 倒序
        /// </summary>
        DESC
    }
}
