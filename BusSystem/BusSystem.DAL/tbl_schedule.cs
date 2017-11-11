using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
	public partial class tbl_scheduleDAO
	{
        #region 向数据库中添加一条记录 +int Insert(tbl_schedule model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_schedule model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_schedule] (
	[id_tbl_line]
	,[id_tbl_coach]
	
	,[col_start_date]
	,[col_remainticket]
)
VALUES (
	@id_tbl_line
	,@id_tbl_coach
	
	,@col_start_date
	,@col_remainticket
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@id_tbl_line", model.id_tbl_line),					
					new SqlParameter("@id_tbl_coach", model.id_tbl_coach),					
					//new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),					
					new SqlParameter("@col_start_date", model.col_start_date),					
					new SqlParameter("@col_remainticket", model.col_remainticket)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_schedule)
        public int Delete(int id_tbl_schedule)
        {
            const string sql = "DELETE FROM [dbo].[tbl_schedule] WHERE [id_tbl_schedule] = @id_tbl_schedule";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_schedule", id_tbl_schedule));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_schedule model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_schedule model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_schedule]
SET 
	[id_tbl_line] = @id_tbl_line
	,[id_tbl_coach] = @id_tbl_coach
	
	,[col_start_date] = @col_start_date
	,[col_remainticket] = @col_remainticket
WHERE [id_tbl_schedule] = @id_tbl_schedule";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id_tbl_line", model.id_tbl_line),					
					new SqlParameter("@id_tbl_coach", model.id_tbl_coach),					
					new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),					
					new SqlParameter("@col_start_date", model.col_start_date),					
					new SqlParameter("@col_remainticket", model.col_remainticket)					
                );
        }
        #endregion

      public int Update2(int id_tbl_schedule,int col_remainticket )
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_schedule]
SET 
	[col_remainticket] = @col_remainticket
WHERE [int id_tbl_schedule] = @int id_tbl_schedule";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_tbl_schedule", id_tbl_schedule),			
					new SqlParameter("@col_remainticket", col_remainticket)					
                );
        }
//                public int Updateischecked(int id_tbl_passenger, int col_ischecked)
//        {
//            #region SQL语句
//            const string sql = @"
//UPDATE [dbo].[tbl_passenger]
//SET 
//	[col_ischecked]=@col_ischecked
//WHERE [id_tbl_passenger] = @id_tbl_passenger";
//            #endregion
//            return SqlHelper.ExecuteNonQuery(sql,
//                    new SqlParameter("@col_ischecked", col_ischecked),
//                    new SqlParameter("@id_tbl_passenger", id_tbl_passenger)
//                );
//        }
//        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_schedule> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_schedule> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_schedule", new[] { "id_tbl_line", "id_tbl_coach", "id_tbl_schedule", "col_start_date", "col_remainticket" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_schedule>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_schedule QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_schedule QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_schedule QuerySingle(int id_tbl_schedule)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_schedule">key</param>
        /// <returns>实体</returns>
        public tbl_schedule QuerySingle(int id_tbl_schedule)
        {
            const string sql = "SELECT TOP 1 [id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket] FROM [dbo].[tbl_schedule] WHERE [id_tbl_schedule] = @id_tbl_schedule";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_schedule", id_tbl_schedule)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_schedule>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("tbl_schedule", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
	}
}