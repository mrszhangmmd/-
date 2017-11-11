using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
	public partial class tbl_coachDAO
	{
        #region 向数据库中添加一条记录 +int Insert(tbl_coach model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_coach model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_coach] (
	[id_tbl_coach]
	,[col_coach_type]
	,[col_coach_count]
)
VALUES (
	@id_tbl_coach
	,@col_coach_type
	,@col_coach_count
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@id_tbl_coach", model.id_tbl_coach),					
					new SqlParameter("@col_coach_type", model.col_coach_type),					
					new SqlParameter("@col_coach_count", model.col_coach_count)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_coach)
        public int Delete(int id_tbl_coach)
        {
            const string sql = "DELETE FROM [dbo].[tbl_coach] WHERE [id_tbl_coach] = @id_tbl_coach";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_coach", id_tbl_coach));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_coach model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_coach model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_coach]
SET 
	[id_tbl_coach] = @id_tbl_coach
	,[col_coach_type] = @col_coach_type
	,[col_coach_count] = @col_coach_count
WHERE [id_tbl_coach] = @id_tbl_coach";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id_tbl_coach", model.id_tbl_coach),					
					new SqlParameter("@col_coach_type", model.col_coach_type),					
					new SqlParameter("@col_coach_count", model.col_coach_count)					
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_coach> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_coach> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_coach", new[] { "id_tbl_coach", "col_coach_type", "col_coach_count" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_coach>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_coach QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_coach QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_coach QuerySingle(int id_tbl_coach)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_coach">key</param>
        /// <returns>实体</returns>
        public tbl_coach QuerySingle(int id_tbl_coach)
        {
            const string sql = "SELECT TOP 1 [id_tbl_coach], [col_coach_type], [col_coach_count] FROM [dbo].[tbl_coach] WHERE [id_tbl_coach] = @id_tbl_coach";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_coach", id_tbl_coach)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_coach>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("tbl_coach", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
	}
}