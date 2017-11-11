using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
	public partial class tbl_captchaDAO
	{
        #region 向数据库中添加一条记录 +int Insert(tbl_captcha model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_captcha model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_captcha] (
	[id_tbl_captcha]
	,[col_userid]
	,[col_token]
	,[col_actved]
	,[col_expired]
)
VALUES (
	@id_tbl_captcha
	,@col_userid
	,@col_token
	,@col_actved
	,@col_expired
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@id_tbl_captcha", model.id_tbl_captcha),					
					new SqlParameter("@col_userid", model.col_userid),					
					new SqlParameter("@col_token", model.col_token),					
					new SqlParameter("@col_actved", model.col_actved),					
					new SqlParameter("@col_expired", model.col_expired)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_captcha)
        public int Delete(int id_tbl_captcha)
        {
            const string sql = "DELETE FROM [dbo].[tbl_captcha] WHERE [id_tbl_captcha] = @id_tbl_captcha";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_captcha", id_tbl_captcha));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_captcha model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_captcha model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_captcha]
SET 
	[id_tbl_captcha] = @id_tbl_captcha
	,[col_userid] = @col_userid
	,[col_token] = @col_token
	,[col_actved] = @col_actved
	,[col_expired] = @col_expired
WHERE [id_tbl_captcha] = @id_tbl_captcha";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id_tbl_captcha", model.id_tbl_captcha),					
					new SqlParameter("@col_userid", model.col_userid),					
					new SqlParameter("@col_token", model.col_token),					
					new SqlParameter("@col_actved", model.col_actved),					
					new SqlParameter("@col_expired", model.col_expired)					
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_captcha> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_captcha> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_captcha", new[] { "id_tbl_captcha", "col_userid", "col_token", "col_actved", "col_expired" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_captcha>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_captcha QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_captcha QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_captcha QuerySingle(int id_tbl_captcha)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_captcha">key</param>
        /// <returns>实体</returns>
        public tbl_captcha QuerySingle(int id_tbl_captcha)
        {
            const string sql = "SELECT TOP 1 [id_tbl_captcha], [col_userid], [col_token], [col_actved], [col_expired] FROM [dbo].[tbl_captcha] WHERE [id_tbl_captcha] = @id_tbl_captcha";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_captcha", id_tbl_captcha)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_captcha>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("tbl_captcha", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
	}
}