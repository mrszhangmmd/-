using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
	public partial class tbl_lineDAO
	{
        #region 向数据库中添加一条记录 +int Insert(tbl_line model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_line model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_line] (
	[col_line_time]
	,[col_line_price]
	,[col_definitionid]
	,[col_startid]
)
VALUES (
	@col_line_time
	,@col_line_price
	,@col_definitionid
	,@col_startid
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					//new SqlParameter("@id_tbl_line", model.id_tbl_line),					
					new SqlParameter("@col_line_time", model.col_line_time),					
					new SqlParameter("@col_line_price", model.col_line_price),					
					new SqlParameter("@col_definitionid", model.col_definitionid),					
					new SqlParameter("@col_startid", model.col_startid)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_line)
        public int Delete(int id_tbl_line)
        {
            const string sql = "DELETE FROM [dbo].[tbl_line] WHERE [id_tbl_line] = @id_tbl_line";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_line", id_tbl_line));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_line model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_line model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_line]
SET 
	
	[col_line_time] = @col_line_time
	,[col_line_price] = @col_line_price

WHERE [id_tbl_line] = @id_tbl_line";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id_tbl_line", model.id_tbl_line),					
					new SqlParameter("@col_line_time", model.col_line_time),					
					new SqlParameter("@col_line_price", model.col_line_price)					
					//new SqlParameter("@col_definitionid", model.col_definitionid),					
					//new SqlParameter("@col_startid", model.col_startid)					
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_line> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_line> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_line", new[] { "id_tbl_line", "col_line_time", "col_line_price", "col_definitionid", "col_startid" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_line>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_line QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_line QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_line QuerySingle(int id_tbl_line)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_line">key</param>
        /// <returns>实体</returns>
        public tbl_line QuerySingle(int id_tbl_line)
        {
            const string sql = "SELECT TOP 1 [id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid] FROM [dbo].[tbl_line] WHERE [id_tbl_line] = @id_tbl_line";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_line", id_tbl_line)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_line>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region 查询单个模型实体 +int QuerySingle2(string col_line_time,string col_line_price,int col_startid,int col_definitionid)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_line">key</param>
        /// <returns>实体</returns>
        public int QuerySingle2(string col_line_time, string col_line_price, int col_startid, int col_definitionid)
        {
            const string sql = "SELECT TOP 1 [id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid] FROM [dbo].[tbl_line] WHERE [col_line_time] = @col_line_time and [col_line_price]=@col_line_price and [col_definitionid]=@col_definitionid and [col_startid]=@col_startid ";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@col_line_time", col_line_time), new SqlParameter("@col_line_price", col_line_price), new SqlParameter("@col_definitionid", col_definitionid), new SqlParameter("@col_startid", col_startid)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                  
                    int a = SqlHelper.MapEntity<tbl_line>(reader).id_tbl_line;
                    return a;
                }
                else
                {
                    return 0;
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
            var sql = SqlHelper.GenerateQuerySql("tbl_line", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
	}
}