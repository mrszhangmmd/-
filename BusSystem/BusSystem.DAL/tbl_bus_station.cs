using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
	public partial class tbl_bus_stationDAO
	{
        #region 向数据库中添加一条记录 +int Insert(tbl_bus_station model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_bus_station model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_bus_station] (
	[id_tbl_bus_station]
	,[col_name]
	,[col_bs_state]
	,[col_city]
)
VALUES (
	@id_tbl_bus_station
	,@col_name
	,@col_bs_state
	,@col_city
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@id_tbl_bus_station", model.id_tbl_bus_station),					
					new SqlParameter("@col_name", model.col_name),					
					new SqlParameter("@col_bs_state", model.col_bs_state),					
					new SqlParameter("@col_city", model.col_city)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_bus_station)
        public int Delete(int id_tbl_bus_station)
        {
            const string sql = "DELETE FROM [dbo].[tbl_bus_station] WHERE [id_tbl_bus_station] = @id_tbl_bus_station";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_bus_station", id_tbl_bus_station));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_bus_station model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_bus_station model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_bus_station]
SET 
	[id_tbl_bus_station] = @id_tbl_bus_station
	,[col_name] = @col_name
	,[col_bs_state] = @col_bs_state
	,[col_city] = @col_city
WHERE [id_tbl_bus_station] = @id_tbl_bus_station";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id_tbl_bus_station", model.id_tbl_bus_station),					
					new SqlParameter("@col_name", model.col_name),					
					new SqlParameter("@col_bs_state", model.col_bs_state),					
					new SqlParameter("@col_city", model.col_city)					
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_bus_station> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_bus_station> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_bus_station", new[] { "id_tbl_bus_station", "col_name", "col_bs_state", "col_city" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_bus_station>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_bus_station QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_bus_station QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_bus_station QuerySingle(int id_tbl_bus_station)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_bus_station">key</param>
        /// <returns>实体</returns>
        public tbl_bus_station QuerySingle(int id_tbl_bus_station)
        {
            const string sql = "SELECT TOP 1 [id_tbl_bus_station], [col_name], [col_bs_state], [col_city] FROM [dbo].[tbl_bus_station] WHERE [id_tbl_bus_station] = @id_tbl_bus_station";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_bus_station", id_tbl_bus_station)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_bus_station>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region 查询单个模型实体 +tbl_bus_station QuerySingleforcityname(string col_name)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_bus_station">key</param>
        /// <returns>实体</returns>
        public tbl_bus_station QuerySingleforcityname(string col_name)
        /// <summary>
        {
            const string sql = "SELECT  [id_tbl_bus_station], [col_name], [col_bs_state], [col_city] FROM [dbo].[tbl_bus_station] WHERE [col_name] = @col_name";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@col_name", col_name)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_bus_station>(reader) ;
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
            var sql = SqlHelper.GenerateQuerySql("tbl_bus_station", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
	}
}