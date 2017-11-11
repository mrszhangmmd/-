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
    public partial class view_orderDAO
    {
        #region 向数据库中添加一条记录 +int Insert(view_order model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(view_order model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[view_order] (
	[id_tbl_order]
	,[col_price]
	,[col_start_date]
	,[definitionbusstation]
	,[startbusstation]
	,[startcity]
	,[backcity]
	,[starttime]
	,[id_tbl_user]
	,[col_passenger_state]
	,[col_indentity_no]
	,[id_tbl_passenger]
	,[tnum]
	,[col_take_order_no]
	,[col_password]
	,[col_start_time]
	,[col_passenger_tel]
	,[col_passenger_num]
	,[col_order_state]
	,[col_insurence_state]
)
VALUES (
	@id_tbl_order
	,@col_price
	,@col_start_date
	,@definitionbusstation
	,@startbusstation
	,@startcity
	,@backcity
	,@starttime
	,@id_tbl_user
	,@col_passenger_state
	,@col_indentity_no
	,@id_tbl_passenger
	,@tnum
	,@col_take_order_no
	,@col_password
	,@col_start_time
	,@col_passenger_tel
	,@col_passenger_num
	,@col_order_state
	,@col_insurence_state
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@id_tbl_order", model.id_tbl_order),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@col_start_date", model.col_start_date),
                    new SqlParameter("@definitionbusstation", model.definitionbusstation),
                    new SqlParameter("@startbusstation", model.startbusstation),
                    new SqlParameter("@startcity", model.startcity),
                    new SqlParameter("@backcity", model.backcity),
                    new SqlParameter("@starttime", model.starttime),
                    new SqlParameter("@id_tbl_user", model.id_tbl_user),
                    new SqlParameter("@col_passenger_state", model.col_passenger_state),
                    new SqlParameter("@col_indentity_no", model.col_indentity_no),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@tnum", model.tnum),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel),
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_order)
        public int Delete(int id_tbl_order)
        {
            const string sql = "DELETE FROM [dbo].[view_order] WHERE [id_tbl_order] = @id_tbl_order";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_order", id_tbl_order));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(view_order model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(view_order model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[view_order]
SET 
	[id_tbl_order] = @id_tbl_order
	,[col_price] = @col_price
	,[col_start_date] = @col_start_date
	,[definitionbusstation] = @definitionbusstation
	,[startbusstation] = @startbusstation
	,[startcity] = @startcity
	,[backcity] = @backcity
	,[starttime] = @starttime
	,[id_tbl_user] = @id_tbl_user
	,[col_passenger_state] = @col_passenger_state
	,[col_indentity_no] = @col_indentity_no
	,[id_tbl_passenger] = @id_tbl_passenger
	,[tnum] = @tnum
	,[col_take_order_no] = @col_take_order_no
	,[col_password] = @col_password
	,[col_start_time] = @col_start_time
	,[col_passenger_tel] = @col_passenger_tel
	,[col_passenger_num] = @col_passenger_num
	,[col_order_state] = @col_order_state
	,[col_insurence_state] = @col_insurence_state
WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_tbl_order", model.id_tbl_order),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@col_start_date", model.col_start_date),
                    new SqlParameter("@definitionbusstation", model.definitionbusstation),
                    new SqlParameter("@startbusstation", model.startbusstation),
                    new SqlParameter("@startcity", model.startcity),
                    new SqlParameter("@backcity", model.backcity),
                    new SqlParameter("@starttime", model.starttime),
                    new SqlParameter("@id_tbl_user", model.id_tbl_user),
                    new SqlParameter("@col_passenger_state", model.col_passenger_state),
                    new SqlParameter("@col_indentity_no", model.col_indentity_no),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@tnum", model.tnum),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel),
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state)
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<view_order> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<view_order> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("view_order", new[] { "id_tbl_order", "col_price", "col_start_date", "definitionbusstation", "startbusstation", "startcity", "backcity", "starttime", "id_tbl_user", "col_passenger_state", "col_indentity_no", "id_tbl_passenger", "tnum", "col_take_order_no", "col_password", "col_start_time", "col_passenger_tel", "col_passenger_num", "col_order_state", "col_insurence_state" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<view_order>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +view_order QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public view_order QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +view_order QuerySingle(int id_tbl_order)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_order">key</param>
        /// <returns>实体</returns>
        public view_order QuerySingle(int id_tbl_order)
        {
            const string sql = "SELECT TOP 1 [id_tbl_order], [col_price], [col_start_date], [definitionbusstation], [startbusstation], [startcity], [backcity], [starttime], [id_tbl_user], [col_passenger_state], [col_indentity_no], [id_tbl_passenger], [tnum], [col_take_order_no], [col_password], [col_start_time], [col_passenger_tel], [col_passenger_num], [col_order_state], [col_insurence_state] FROM [dbo].[view_order] WHERE [id_tbl_order] = @id_tbl_order";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_order", id_tbl_order)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<view_order>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("view_order", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 查询单个模型实体 +view_order QuerySingle2(int id_tbl_user)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_user">key</param>
        /// <returns>实体</returns>
        public view_order QuerySingle2(int id_tbl_user)
        {
            const string sql = "SELECT  [id_tbl_order], [col_price], [col_start_date], [definitionbusstation], [startbusstation], [startcity], [backcity], [starttime], [id_tbl_user], [col_passenger_state], [col_indentity_no], [id_tbl_passenger], [tnum], [col_take_order_no], [col_password], [col_start_time], [col_passenger_tel], [col_passenger_num], [col_order_state], [col_insurence_state] FROM [dbo].[view_order] WHERE [id_tbl_user] = @id_tbl_user";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_user", id_tbl_user)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<view_order>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion



        public DataSet GetList(int id_tbl_user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id_tbl_order,id_tbl_passenger,col_take_order_no,col_password,col_start_time,col_passenger_tel,col_passenger_num,col_order_state,col_insurence_state,col_price,col_start_date,definitionbusstation,startbusstation,startcity,backcity,starttime,id_tbl_user,col_passenger_state,col_indentity_no,tnum");
            strSql.Append(" FROM view_order ");
            strSql.Append(" where id_tbl_user=" + id_tbl_user);

            return SqlHelper.Query(strSql.ToString());
        }
    }
}