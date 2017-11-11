using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;
using System.Data;
using System.Text;

namespace BusSystem.DAL
{
    public partial class view_lineDAO
    {
        #region 向数据库中添加一条记录 +int Insert(view_line model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(view_line model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[view_line] (
	[starttime]
	,[id_tbl_bus_station]
	,[id_tbl_schedule]
	,[id_tbl_coach]
	,[Expr1]
	,[id_tbl_line]
	,[col_start_date]
	,[backcity]
	,[startcity]
	,[price]
	,[type]
	,[tnum]
	,[count]
	,[definitionbusstation]
	,[startbusstation]
)
VALUES (
	@starttime
	,@id_tbl_bus_station
	,@id_tbl_schedule
	,@id_tbl_coach
	,@Expr1
	,@id_tbl_line
	,@col_start_date
	,@backcity
	,@startcity
	,@price
	,@type
	,@tnum
	,@count
	,@definitionbusstation
	,@startbusstation
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@starttime", model.starttime),
                    new SqlParameter("@id_tbl_bus_station", model.id_tbl_bus_station),
                    new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),
                    new SqlParameter("@id_tbl_coach", model.id_tbl_coach),
                    new SqlParameter("@Expr1", model.Expr1),
                    new SqlParameter("@id_tbl_line", model.id_tbl_line),
                    new SqlParameter("@col_start_date", model.col_start_date),
                    new SqlParameter("@backcity", model.backcity),
                    new SqlParameter("@startcity", model.startcity),
                    new SqlParameter("@price", model.price),
                    new SqlParameter("@type", model.type),
                    new SqlParameter("@tnum", model.tnum),
                    new SqlParameter("@count", model.count),
                    new SqlParameter("@definitionbusstation", model.definitionbusstation),
                    new SqlParameter("@startbusstation", model.startbusstation)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(string starttime)
        public int Delete(string starttime)
        {
            const string sql = "DELETE FROM [dbo].[view_line] WHERE [starttime] = @starttime";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@starttime", starttime));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(view_line model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(view_line model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[view_line]
SET 
	[starttime] = @starttime
	,[id_tbl_bus_station] = @id_tbl_bus_station
	,[id_tbl_schedule] = @id_tbl_schedule
	,[id_tbl_coach] = @id_tbl_coach
	,[Expr1] = @Expr1
	,[id_tbl_line] = @id_tbl_line
	,[col_start_date] = @col_start_date
	,[backcity] = @backcity
	,[startcity] = @startcity
	,[price] = @price
	,[type] = @type
	,[tnum] = @tnum
	,[count] = @count
	,[definitionbusstation] = @definitionbusstation
	,[startbusstation] = @startbusstation
WHERE [starttime] = @starttime";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@starttime", model.starttime),
                    new SqlParameter("@id_tbl_bus_station", model.id_tbl_bus_station),
                    new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),
                    new SqlParameter("@id_tbl_coach", model.id_tbl_coach),
                    new SqlParameter("@Expr1", model.Expr1),
                    new SqlParameter("@id_tbl_line", model.id_tbl_line),
                   // new SqlParameter("@col_start_date", model.col_start_date),
                    new SqlParameter("@backcity", model.backcity),
                    new SqlParameter("@startcity", model.startcity),
                    new SqlParameter("@price", model.price),
                    new SqlParameter("@type", model.type),
                    new SqlParameter("@tnum", model.tnum),
                    new SqlParameter("@count", model.count),
                    new SqlParameter("@definitionbusstation", model.definitionbusstation),
                    new SqlParameter("@startbusstation", model.startbusstation)
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<view_line> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<view_line> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("view_line", new[] { "starttime", "id_tbl_bus_station", "id_tbl_schedule", "id_tbl_coach", "Expr1", "id_tbl_line", "col_start_date", "backcity", "startcity", "price", "type", "tnum", "count", "definitionbusstation", "startbusstation" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<view_line>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +view_line QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public view_line QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +view_line QuerySingle2(int id_tbl_line)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="starttime">key</param>
        /// <returns>实体</returns>
        public view_line QuerySingle2(int id_tbl_line)
        {
            const string sql = "SELECT TOP 1 [starttime], [id_tbl_bus_station], [id_tbl_schedule], [id_tbl_coach], [Expr1], [id_tbl_line], [col_start_date], [backcity], [startcity], [price], [type], [tnum], [count], [definitionbusstation], [startbusstation] FROM [dbo].[view_line] WHERE [id_tbl_line] = @id_tbl_line";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_line", id_tbl_line)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<view_line>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +view_line search(string col_start_date,string backcity,string startcity)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="starttime">key</param>
        /// <returns>实体</returns>
        public view_line search(string col_start_date, string backcity, string startcity)
        {
            const string sql = "SELECT  [starttime], [id_tbl_bus_station], [id_tbl_schedule], [id_tbl_coach], [Expr1], [id_tbl_line], [col_start_date], [backcity], [startcity], [price], [type], [tnum], [count], [definitionbusstation], [startbusstation] FROM [dbo].[view_line] WHERE [startcity] = @startcity and [backcity] = @backcity and [col_start_date] = @col_start_date";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@col_start_date", col_start_date), new SqlParameter("@backcity", backcity), new SqlParameter("@startcity", startcity)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<view_line>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        //public DataSet searchline(string col_start_date, string backcity, string startcity)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select starttime,id_tbl_bus_station,id_tbl_schedule,id_tbl_coach,Expr1,id_tbl_line,col_start_date,backcity,startcity,price,type,tnum,count,definitionbusstation,startbusstation");
        //    strSql.Append(" FROM view_line ");
        //    strSql.Append(" where col_start_date=" + col_start_date);
            
        //    //strSql.Append(" and backcity=" + backcity);
        //   // strSql.Append(" and startcity=" + startcity);
        //    return SqlHelper.Query(strSql.ToString());
        //}


        public DataSet searchline(string col_start_date, string backcity, string startcity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select starttime,id_tbl_bus_station,id_tbl_schedule,id_tbl_coach,Expr1,id_tbl_line,col_start_date,backcity,startcity,price,type,tnum,count,definitionbusstation,startbusstation");
            strSql.Append(" FROM view_ticket ");
            strSql.Append(" where col_start_date=" + col_start_date);

            return SqlHelper.Query(strSql.ToString());
        }
        //select starttime,id_tbl_bus_station,id_tbl_schedule,id_tbl_coach,Expr1,id_tbl_line,col_start_date,backcity,startcity,price,type,tnum,count,definitionbusstation,startbusstation
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
            var sql = SqlHelper.GenerateQuerySql("view_line", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
    }
}