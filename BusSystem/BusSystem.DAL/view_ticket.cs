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
    public partial class view_ticketDAO
    {
        #region 向数据库中添加一条记录 +int Insert(view_ticket model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(view_ticket model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[view_ticket] (
	[Expr1]
	,[startcity]
	,[startbusstation]
	,[definitionbusstation]
	,[col_start_date]
	,[col_price]
	,[col_insurence_state]
	,[col_order_state]
	,[col_passenger_num]
	,[col_passenger_tel]
	,[col_start_time]
	,[col_seatno]
	,[col_password]
	,[col_take_order_no]
	,[Expr2]
	,[col_passenger_state]
	,[col_indentity_no]
	,[tnum]
	,[col_name]
	,[Expr3]
	,[col_ticket_State]
	,[col_ticket_entrance]
	,[id_tbl_ticket]
	,[id_tbl_passenger]
	,[id_tbl_user]
	,[starttime]
	,[backcity]
)
VALUES (
	@Expr1
	,@startcity
	,@startbusstation
	,@definitionbusstation
	,@col_start_date
	,@col_price
	,@col_insurence_state
	,@col_order_state
	,@col_passenger_num
	,@col_passenger_tel
	,@col_start_time
	,@col_seatno
	,@col_password
	,@col_take_order_no
	,@Expr2
	,@col_passenger_state
	,@col_indentity_no
	,@tnum
	,@col_name
	,@Expr3
	,@col_ticket_State
	,@col_ticket_entrance
	,@id_tbl_ticket
	,@id_tbl_passenger
	,@id_tbl_user
	,@starttime
	,@backcity
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@Expr1", model.Expr1),
                    new SqlParameter("@startcity", model.startcity),
                    new SqlParameter("@startbusstation", model.startbusstation),
                    new SqlParameter("@definitionbusstation", model.definitionbusstation),
                    new SqlParameter("@col_start_date", model.col_start_date),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_seatno", model.col_seatno),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@Expr2", model.Expr2),
                    new SqlParameter("@col_passenger_state", model.col_passenger_state),
                    new SqlParameter("@col_indentity_no", model.col_indentity_no),
                    new SqlParameter("@tnum", model.tnum),
                    new SqlParameter("@col_name", model.col_name),
                    new SqlParameter("@Expr3", model.Expr3),
                    new SqlParameter("@col_ticket_State", model.col_ticket_State),
                    new SqlParameter("@col_ticket_entrance", model.col_ticket_entrance),
                    new SqlParameter("@id_tbl_ticket", model.id_tbl_ticket),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@id_tbl_user", model.id_tbl_user),
                    new SqlParameter("@starttime", model.starttime),
                    new SqlParameter("@backcity", model.backcity)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int expr1)
        public int Delete(int expr1)
        {
            const string sql = "DELETE FROM [dbo].[view_ticket] WHERE [Expr1] = @Expr1";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@Expr1", expr1));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(view_ticket model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(view_ticket model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[view_ticket]
SET 
	[Expr1] = @Expr1
	,[startcity] = @startcity
	,[startbusstation] = @startbusstation
	,[definitionbusstation] = @definitionbusstation
	,[col_start_date] = @col_start_date
	,[col_price] = @col_price
	,[col_insurence_state] = @col_insurence_state
	,[col_order_state] = @col_order_state
	,[col_passenger_num] = @col_passenger_num
	,[col_passenger_tel] = @col_passenger_tel
	,[col_start_time] = @col_start_time
	,[col_seatno] = @col_seatno
	,[col_password] = @col_password
	,[col_take_order_no] = @col_take_order_no
	,[Expr2] = @Expr2
	,[col_passenger_state] = @col_passenger_state
	,[col_indentity_no] = @col_indentity_no
	,[tnum] = @tnum
	,[col_name] = @col_name
	,[Expr3] = @Expr3
	,[col_ticket_State] = @col_ticket_State
	,[col_ticket_entrance] = @col_ticket_entrance
	,[id_tbl_ticket] = @id_tbl_ticket
	,[id_tbl_passenger] = @id_tbl_passenger
	,[id_tbl_user] = @id_tbl_user
	,[starttime] = @starttime
	,[backcity] = @backcity
WHERE [Expr1] = @Expr1";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@Expr1", model.Expr1),
                    new SqlParameter("@startcity", model.startcity),
                    new SqlParameter("@startbusstation", model.startbusstation),
                    new SqlParameter("@definitionbusstation", model.definitionbusstation),
                    new SqlParameter("@col_start_date", model.col_start_date),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_seatno", model.col_seatno),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@Expr2", model.Expr2),
                    new SqlParameter("@col_passenger_state", model.col_passenger_state),
                    new SqlParameter("@col_indentity_no", model.col_indentity_no),
                    new SqlParameter("@tnum", model.tnum),
                    new SqlParameter("@col_name", model.col_name),
                    new SqlParameter("@Expr3", model.Expr3),
                    new SqlParameter("@col_ticket_State", model.col_ticket_State),
                    new SqlParameter("@col_ticket_entrance", model.col_ticket_entrance),
                    new SqlParameter("@id_tbl_ticket", model.id_tbl_ticket),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@id_tbl_user", model.id_tbl_user),
                    new SqlParameter("@starttime", model.starttime),
                    new SqlParameter("@backcity", model.backcity)
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<view_ticket> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<view_ticket> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("view_ticket", new[] { "Expr1", "startcity", "startbusstation", "definitionbusstation", "col_start_date", "col_price", "col_insurence_state", "col_order_state", "col_passenger_num", "col_passenger_tel", "col_start_time", "col_seatno", "col_password", "col_take_order_no", "Expr2", "col_passenger_state", "col_indentity_no", "tnum", "col_name", "Expr3", "col_ticket_State", "col_ticket_entrance", "id_tbl_ticket", "id_tbl_passenger", "id_tbl_user", "starttime", "backcity" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<view_ticket>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +view_ticket QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public view_ticket QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +view_ticket QuerySingle(int id_tbl_user,int id_tbl_order)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="expr1">key</param>
        /// <returns>实体</returns>
        public view_ticket QuerySingle2( int id_tbl_user,int id_tbl_order)
        {
            const string sql = "SELECT TOP 1 [col_seatno],[col_ticket_State],[col_ticket_entrance],[id_tbl_ticket],[id_tbl_passenger],[id_tbl_user],[starttime],[backcity],[startcity],[startbusstation],[definitionbusstation],[col_start_date],[col_price],[col_insurence_state],[col_order_state],[col_passenger_num],[col_passenger_tel],[col_start_time],[col_password],[col_take_order_no],[col_passenger_state],[col_indentity_no],[tnum],[col_name],[id_tbl_order] FROM [dbo].[view_ticket] WHERE [id_tbl_order] = @id_tbl_order and [id_tbl_user]=@id_tbl_user";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_user", id_tbl_user), new SqlParameter("@id_tbl_order", id_tbl_order)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<view_ticket>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("view_ticket", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion


        public DataSet GetList(int id_tbl_user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id_tbl_order,col_take_order_no,col_password,col_start_time,col_passenger_tel,col_passenger_num,col_order_state,col_insurence_state,col_price,col_start_date,definitionbusstation,startbusstation,startcity,backcity,starttime,id_tbl_user,col_passenger_state,tnum,col_name,id_tbl_ticket,col_entrance,col_ticket_State,col_seatno");
            strSql.Append(" FROM view_ticket ");
            strSql.Append(" where id_tbl_user=" + id_tbl_user);

            return SqlHelper.Query(strSql.ToString());
        }
        public DataSet GetList2(int id_tbl_user,int id_tbl_order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Top 1 id_tbl_order,col_take_order_no,col_password,col_start_time,col_passenger_tel,col_passenger_num,col_order_state,col_insurence_state,col_price,col_start_date,definitionbusstation,startbusstation,startcity,backcity,starttime,id_tbl_user,col_passenger_state,tnum,col_name,id_tbl_ticket,col_entrance,col_ticket_State,col_seatno,col_indentity_no");
            strSql.Append(" FROM view_ticket ");
            strSql.Append(" where id_tbl_user=" + id_tbl_user);
            strSql.Append(" and id_tbl_order=" + id_tbl_order);
            return SqlHelper.Query(strSql.ToString());
        }

        public DataSet GetList3(int id_tbl_user, int id_tbl_order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Top 3 id_tbl_order,col_take_order_no,col_password,col_start_time,col_passenger_tel,col_passenger_num,col_order_state,col_insurence_state,col_price,col_start_date,definitionbusstation,startbusstation,startcity,backcity,starttime,id_tbl_user,col_passenger_state,tnum,col_name,id_tbl_ticket,col_entrance,col_ticket_State,col_seatno,col_indentity_no");
            strSql.Append(" FROM view_ticket ");
            strSql.Append(" where id_tbl_user=" + id_tbl_user);
            strSql.Append(" and id_tbl_order=" + id_tbl_order);
            return SqlHelper.Query(strSql.ToString());
        }
    }
}