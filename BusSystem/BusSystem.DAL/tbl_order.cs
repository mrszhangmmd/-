using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;

namespace BusSystem.DAL
{
    public partial class tbl_orderDAO
    {
        #region 向数据库中添加一条记录 +int Insert(tbl_order model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_order model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_order] (
	[col_passenger_num]
	,[id_tbl_passenger2]
	,[id_tbl_passenger3]
	,[col_insurence_state]
	,[col_price]
	,[id_tbl_passenger]
	,[id_tbl_schedule]
	,[col_take_order_no]
	,[col_password]
	,[col_start_time]
	,[col_order_state]
	,[col_passenger_tel]
)
VALUES (
	@col_passenger_num
	,@id_tbl_passenger2
	,@id_tbl_passenger3
	,@col_insurence_state
	,@col_price
	,@id_tbl_passenger
	,@id_tbl_schedule
	,@col_take_order_no
	,@col_password
	,@col_start_time
	,@col_order_state
	,@col_passenger_tel
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@id_tbl_passenger2", model.id_tbl_passenger2),
                    new SqlParameter("@id_tbl_passenger3", model.id_tbl_passenger3),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
        #region 向数据库中添加一条记录 +int Insert2(tbl_order model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert2(tbl_order model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_order] (
	[col_passenger_num]
	,[id_tbl_passenger2]
	
	,[col_insurence_state]
	,[col_price]
	,[id_tbl_passenger]
	,[id_tbl_schedule]
	,[col_take_order_no]
	,[col_password]
	,[col_start_time]
	,[col_order_state]
	,[col_passenger_tel]
)
VALUES (
	@col_passenger_num
	,@id_tbl_passenger2
	
	,@col_insurence_state
	,@col_price
	,@id_tbl_passenger
	,@id_tbl_schedule
	,@col_take_order_no
	,@col_password
	,@col_start_time
	,@col_order_state
	,@col_passenger_tel
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@id_tbl_passenger2", model.id_tbl_passenger2),
                    //new SqlParameter("@id_tbl_passenger3", model.id_tbl_passenger3),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
        #region 向数据库中添加一条记录 +int Insert3(tbl_order model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert3(tbl_order model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_order] (
	[col_passenger_num]

	,[col_insurence_state]
	,[col_price]
	,[id_tbl_passenger]
	,[id_tbl_schedule]
	,[col_take_order_no]
	,[col_password]
	,[col_start_time]
	,[col_order_state]
	,[col_passenger_tel]
)
VALUES (
	@col_passenger_num

	,@col_insurence_state
	,@col_price
	,@id_tbl_passenger
	,@id_tbl_schedule
	,@col_take_order_no
	,@col_password
	,@col_start_time
	,@col_order_state
	,@col_passenger_tel
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    //new SqlParameter("@id_tbl_passenger2", model.id_tbl_passenger2),
                    //new SqlParameter("@id_tbl_passenger3", model.id_tbl_passenger3),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
        #region 删除一条记录 +int Delete(int id_tbl_order)
        public int Delete(int id_tbl_order)
        {
            const string sql = "DELETE FROM [dbo].[tbl_order] WHERE [id_tbl_order] = @id_tbl_order";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_order", id_tbl_order));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_order model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_order model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_order]
SET 
	[col_passenger_num] = @col_passenger_num
	,[id_tbl_passenger2] = @id_tbl_passenger2
	,[id_tbl_passenger3] = @id_tbl_passenger3
	,[col_insurence_state] = @col_insurence_state
	,[col_price] = @col_price
	,[id_tbl_passenger] = @id_tbl_passenger
	,[id_tbl_schedule] = @id_tbl_schedule
	,[col_take_order_no] = @col_take_order_no
	,[col_password] = @col_password
	,[col_start_time] = @col_start_time
	,[col_order_state] = @col_order_state
	,[col_passenger_tel] = @col_passenger_tel
WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_tbl_order", model.id_tbl_order),
                    new SqlParameter("@col_passenger_num", model.col_passenger_num),
                    new SqlParameter("@id_tbl_passenger2", model.id_tbl_passenger2),
                    new SqlParameter("@id_tbl_passenger3", model.id_tbl_passenger3),
                    new SqlParameter("@col_insurence_state", model.col_insurence_state),
                    new SqlParameter("@col_price", model.col_price),
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@id_tbl_schedule", model.id_tbl_schedule),
                    new SqlParameter("@col_take_order_no", model.col_take_order_no),
                    new SqlParameter("@col_password", model.col_password),
                    new SqlParameter("@col_start_time", model.col_start_time),
                    new SqlParameter("@col_order_state", model.col_order_state),
                    new SqlParameter("@col_passenger_tel", model.col_passenger_tel)
                );
        }
        #endregion

        public int 
            Update2(int id_tbl_order, string col_order_state)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_order]
SET 
[col_order_state] = @col_order_state

WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_tbl_order", id_tbl_order),
                 
                    new SqlParameter("@col_order_state", col_order_state)
                    //new SqlParameter("@col_passenger_tel", model.col_passenger_tel)
                );
        }
   

        public int Update2(int id_tbl_order,string col_take_order_no,string col_password)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_order]
SET 
	
	[col_take_order_no] = @col_take_order_no
	,[col_password] = @col_password

WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_tbl_order", id_tbl_order),
                  
                    new SqlParameter("@col_take_order_no", col_take_order_no),
                    new SqlParameter("@col_password", col_password)
                
            
                );
        }
       
        #region 根据主键ID更新一条记录 +int Update2(int id_tbl_order)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update2(int id_tbl_order)
        {
            #region SQL语句
            const string sql = @"UPDATE [dbo].[tbl_order]  SET [col_order_state]=@col_order_state  WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_order", id_tbl_order), new SqlParameter("@col_order_state", "已支付")
                    
                );
        }
        #endregion
        public int Update4(int id_tbl_order)
        {
            #region SQL语句
            const string sql = @"UPDATE [dbo].[tbl_order]  SET [col_order_state]=@col_order_state  WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_order", id_tbl_order), new SqlParameter("@col_order_state", "取消订单")
                    
                );
        }


      

        #region 根据主键ID更新一条记录 +int Update3(int id_tbl_order)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update3(int id_tbl_order)
        {
            #region SQL语句
            const string sql = @"UPDATE [dbo].[tbl_order]  SET [col_order_state]=@col_order_state  WHERE [id_tbl_order] = @id_tbl_order";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_order", id_tbl_order), new SqlParameter("@col_order_state", "已出票")

                );
        }
        #endregion
        #region 分页查询一个集合 +IEnumerable<tbl_order> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_order> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_order", new[] { "id_tbl_order", "col_passenger_num", "id_tbl_passenger2", "id_tbl_passenger3", "col_insurence_state", "col_price", "id_tbl_passenger", "id_tbl_schedule", "col_take_order_no", "col_password", "col_start_time", "col_order_state", "col_passenger_tel" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_order>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_order QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_order QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_order QuerySingle(int id_tbl_order)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_order">key</param>
        /// <returns>实体</returns>
        public tbl_order QuerySingle(int id_tbl_order)
        {
            const string sql = "SELECT TOP 1 [id_tbl_order], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel] FROM [dbo].[tbl_order] WHERE [id_tbl_order] = @id_tbl_order";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_order", id_tbl_order)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_order>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        public tbl_order QuerySingle5(string  col_start_time,string col_passenger_tel,string col_passenger_num)
        {
            const string sql = "SELECT TOP 1 [id_tbl_order], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel] FROM [dbo].[tbl_order] WHERE [col_passenger_tel] = @col_passenger_tel and [col_start_time] = @col_start_time and [col_passenger_num] = @col_passenger_num";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@col_start_time", col_start_time),new SqlParameter("@col_passenger_tel", col_passenger_tel),new SqlParameter("@col_passenger_num", col_passenger_num)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_order>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
       

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
            var sql = SqlHelper.GenerateQuerySql("tbl_order", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
    }
}