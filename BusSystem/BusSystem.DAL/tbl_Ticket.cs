using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
    public partial class tbl_TicketDAO
    {
        #region 向数据库中添加一条记录 +int Insert(tbl_Ticket model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public void Insert(tbl_Ticket model)
        {

            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_Ticket] (
	[col_ticket_time]
	
	,[id_tbl_order]
	,[col_ticket_entrance]
	,[col_ticket_State]
	,[col_seatno]
	,[id_tbl_passenger]
)
VALUES (
	@col_ticket_time

	,@id_tbl_order
	,@col_ticket_entrance
	,@col_ticket_State
	,@col_seatno
	,@id_tbl_passenger
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@col_ticket_time", model.col_ticket_time),
                   // new SqlParameter("@id_tbl_ticket", model.id_tbl_ticket),
                    new SqlParameter("@id_tbl_order", model.id_tbl_order),
                    new SqlParameter("@col_ticket_entrance", model.col_ticket_entrance),
                    new SqlParameter("@col_ticket_State", model.col_ticket_State),
                    new SqlParameter("@col_seatno", model.col_seatno),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger)
                );
            //return res == null ? 0 : Convert.ToInt32(res);

        }
        
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_ticket)
        public int Delete(int id_tbl_ticket)
        {
            const string sql = "DELETE FROM [dbo].[tbl_Ticket] WHERE [id_tbl_ticket] = @id_tbl_ticket";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_ticket", id_tbl_ticket));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_Ticket model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_Ticket model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_Ticket]
SET 
	[col_ticket_time] = @col_ticket_time
	,[id_tbl_ticket] = @id_tbl_ticket
	,[id_tbl_order] = @id_tbl_order
	,[col_ticket_entrance] = @col_ticket_entrance
	,[col_ticket_State] = @col_ticket_State
	,[col_seatno] = @col_seatno
	,[id_tbl_passenger] = @id_tbl_passenger
WHERE [id_tbl_ticket] = @id_tbl_ticket";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@col_ticket_time", model.col_ticket_time),
                    new SqlParameter("@id_tbl_ticket", model.id_tbl_ticket),
                    new SqlParameter("@id_tbl_order", model.id_tbl_order),
                    new SqlParameter("@col_ticket_entrance", model.col_ticket_entrance),
                    new SqlParameter("@col_ticket_State", model.col_ticket_State),
                    new SqlParameter("@col_seatno", model.col_seatno),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger)
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_Ticket> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_Ticket> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_Ticket", new[] { "col_ticket_time", "id_tbl_ticket", "id_tbl_order", "col_ticket_entrance", "col_ticket_State", "col_seatno", "id_tbl_passenger" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_Ticket>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_Ticket QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_Ticket QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_Ticket QuerySingle(int id_tbl_ticket)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_ticket">key</param>
        /// <returns>实体</returns>
        public tbl_Ticket QuerySingle(int id_tbl_ticket)
        {
            const string sql = "SELECT TOP 1 [col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger] FROM [dbo].[tbl_Ticket] WHERE [id_tbl_ticket] = @id_tbl_ticket";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_ticket", id_tbl_ticket)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_Ticket>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("tbl_Ticket", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
    }
}