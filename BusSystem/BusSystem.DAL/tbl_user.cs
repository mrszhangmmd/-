using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
	public partial class tbl_userDAO
	{
        #region 向数据库中添加一条记录 +int Insert(tbl_user model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_user model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_user] (
	[col_user_password]
	,[col_user_tel]
	,[col_user_email]
	,[col_user_state]
	,[col_nickname]
)
VALUES (
	@col_user_password
	,@col_user_tel
	,@col_user_email
	,@col_user_state
	,@col_nickname
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@col_user_password", model.col_user_password),					
					new SqlParameter("@col_user_tel", model.col_user_tel),					
					new SqlParameter("@col_user_email", model.col_user_email),					
					new SqlParameter("@col_user_state", model.col_user_state),					
					new SqlParameter("@col_nickname", model.col_nickname)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_user)
        public int Delete(int id_tbl_user)
        {
            const string sql = "DELETE FROM [dbo].[tbl_user] WHERE [id_tbl_user] = @id_tbl_user";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_user", id_tbl_user));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_user model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_user model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_user]
SET 
	[col_user_password] = @col_user_password
	,[col_user_tel] = @col_user_tel
	,[col_user_email] = @col_user_email
	,[col_user_state] = @col_user_state
	,[col_nickname] = @col_nickname
WHERE [id_tbl_user] = @id_tbl_user";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id_tbl_user", model.id_tbl_user),					
					new SqlParameter("@col_user_password", model.col_user_password),					
					new SqlParameter("@col_user_tel", model.col_user_tel),					
					new SqlParameter("@col_user_email", model.col_user_email),					
					new SqlParameter("@col_user_state", model.col_user_state),					
					new SqlParameter("@col_nickname", model.col_nickname)					
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_user> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_user> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        {
            var parameters = new List<SqlParameter>();
            var whereBuilder = new System.Text.StringBuilder();
            if (wheres != null)
            {
                var props = wheres.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name.Equals("__o", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // 操作符
                        whereBuilder.AppendFormat(" {0} ", prop.GetValue(wheres, null).ToString());
                    }
                    else
                    {
                        var val = prop.GetValue(wheres, null).ToString();
                        whereBuilder.AppendFormat(" [{0}] = @{0} ", prop.Name);
                        parameters.Add(new SqlParameter("@" + prop.Name, val));
                    }
                }
            }
            var sql = SqlHelper.GenerateQuerySql("tbl_user", new[] { "id_tbl_user", "col_user_password", "col_user_tel", "col_user_email", "col_user_state", "col_nickname" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_user>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_user QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_user QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_user QuerySingle(int id_tbl_user)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_user">key</param>
        /// <returns>实体</returns>
        public tbl_user QuerySingle(int id_tbl_user)
        {
            const string sql = "SELECT TOP 1 [id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname] FROM [dbo].[tbl_user] WHERE [id_tbl_user] = @id_tbl_user";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_user", id_tbl_user)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_user>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 查询条数 +int QueryCount(object wheres)
        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>条数</returns>
        public int QueryCount(object wheres)
        {
            var parameters = new List<SqlParameter>();
            var whereBuilder = new System.Text.StringBuilder();
            if (wheres != null)
            {
                var props = wheres.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name.Equals("__o", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // 操作符
                        whereBuilder.AppendFormat(" {0} ", prop.GetValue(wheres, null).ToString());
                    }
                    else
                    {
                        var val = prop.GetValue(wheres, null).ToString();
                        whereBuilder.AppendFormat(" [{0}] = @{0} ", prop.Name);
                        parameters.Add(new SqlParameter("@" + prop.Name, val));
                    }
                }
            }
            var sql = SqlHelper.GenerateQuerySql("tbl_user", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
	}
}