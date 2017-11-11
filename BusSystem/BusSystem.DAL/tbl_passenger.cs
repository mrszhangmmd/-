using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BusSystem.Model;
using BusSystem.Utility;
using System.Text;

namespace BusSystem.DAL
{
    public partial class tbl_passengerDAO
    {
        #region 向数据库中添加一条记录 +int Insert(tbl_passenger model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_passenger model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[tbl_passenger] (
	[col_name]
	,[col_passenger_state]
	,[col_indentity_no]
	,[id_tbl_user]
,[col_ischecked]
)
VALUES (
	@col_name
	,@col_passenger_state
	,@col_indentity_no
	,@id_tbl_user
,@col_ischecked
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
                    //new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@col_name", model.col_name),
                    new SqlParameter("@col_passenger_state", model.col_passenger_state),
                    new SqlParameter("@col_indentity_no", model.col_indentity_no),
                    new SqlParameter("@id_tbl_user", model.id_tbl_user),
                    new SqlParameter ("@col_ischecked",model .col_ischecked )
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_passenger)
        public int Delete(int id_tbl_passenger)
        {
            const string sql = "DELETE FROM [dbo].[tbl_passenger] WHERE [id_tbl_passenger] = @id_tbl_passenger";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id_tbl_passenger", id_tbl_passenger));
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(tbl_passenger model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(tbl_passenger model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_passenger]
SET 
	[id_tbl_passenger] = @id_tbl_passenger
	,[col_name] = @col_name
	,[col_passenger_state] = @col_passenger_state
	,[col_indentity_no] = @col_indentity_no
	,[id_tbl_user] = @id_tbl_user
WHERE [id_tbl_passenger] = @id_tbl_passenger";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_tbl_passenger", model.id_tbl_passenger),
                    new SqlParameter("@col_name", model.col_name),
                    new SqlParameter("@col_passenger_state", model.col_passenger_state),
                    new SqlParameter("@col_indentity_no", model.col_indentity_no),
                    new SqlParameter("@id_tbl_user", model.id_tbl_user)
                );
        }
        #endregion

        #region 根据主键ID更新是否选择 +int Updateischecked(int id_tbl_passenger,int col_ischecked)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Updateischecked(int id_tbl_passenger, int col_ischecked)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[tbl_passenger]
SET 
	[col_ischecked]=@col_ischecked
WHERE [id_tbl_passenger] = @id_tbl_passenger";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@col_ischecked", col_ischecked),
                    new SqlParameter("@id_tbl_passenger", id_tbl_passenger)
                );
        }
        #endregion

        #region 根据主键ID更新是否选择 +int Updateischecked(int id_tbl_passenger)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Updateischecked(int id_tbl_passenger)
        {
            #region SQL语句
            const string sql = @" UPDATE [dbo].[tbl_passenger] SET [col_ischecked]=0 WHERE [id_tbl_passenger] =@id_tbl_passenger";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    //new SqlParameter("@col_ischecked", 8),
                    new SqlParameter("@id_tbl_passenger", id_tbl_passenger)
                );
        }
        #endregion

        #region 根据主键ID更新是否选择 +int Updateischecked2(int id_tbl_user)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Updateischecked2(int id_tbl_user)
        {
            #region SQL语句
            const string sql = @" UPDATE [dbo].[tbl_passenger] SET [col_ischecked]=0 WHERE [id_tbl_user] =@id_tbl_user";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                //new SqlParameter("@col_ischecked", 8),
                    new SqlParameter("@id_tbl_user", id_tbl_user)
                );
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<tbl_passenger> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<tbl_passenger> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
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
            var sql = SqlHelper.GenerateQuerySql("tbl_passenger", new[] { "id_tbl_passenger", "col_name", "col_passenger_state", "col_indentity_no", "id_tbl_user" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<tbl_passenger>(reader);
                    }
                }
            }
        }
        #endregion

        #region 查询单个模型实体 +tbl_passenger QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_passenger QuerySingle(object wheres)
        {
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion

        #region 查询单个模型实体 +tbl_passenger QuerySingle(int id_tbl_passenger)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_passenger">key</param>
        /// <returns>实体</returns>
        public tbl_passenger QuerySingle(int id_tbl_passenger)
        {
            const string sql = "SELECT TOP 1 [id_tbl_passenger], [col_name], [col_passenger_state], [col_indentity_no], [id_tbl_user] FROM [dbo].[tbl_passenger] WHERE [id_tbl_passenger] = @id_tbl_passenger";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_passenger", id_tbl_passenger)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_passenger>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region 查询单个模型实体 +tbl_passenger QuerySingle2(int id_tbl_user)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_passenger">key</param>
        /// <returns>实体</returns>
        public tbl_passenger QuerySingle2(int id_tbl_user)
        {
            const string sql = "SELECT  [id_tbl_passenger], [col_name],[col_ischecked], [col_passenger_state], [col_indentity_no], [id_tbl_user] FROM [dbo].[tbl_passenger] WHERE [id_tbl_user] = @id_tbl_user";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_user", id_tbl_user)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_passenger>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

       
        #region 查询单个模型实体的乘客ischecked+int QuerySingle4(int id_tbl_user)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_passenger">key</param>
        /// <returns>实体</returns>
        public int QuerySingle4(int id_tbl_user)
        {
            const string sql = "SELECT  [id_tbl_passenger], [col_name],[col_ischecked], [col_passenger_state], [col_indentity_no], [id_tbl_user] FROM [dbo].[tbl_passenger] WHERE [id_tbl_user] = @id_tbl_user";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id_tbl_user", id_tbl_user)))
            {
               
                    
                    return SqlHelper.MapEntity<tbl_passenger>(reader ).col_ischecked;
               
            }
        }
        #endregion
        
        #region 查询单个模型实体 +tbl_passenger QuerySingle3()
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_passenger">key</param>
        /// <returns>实体</returns>
        public tbl_passenger QuerySingle3()
        {
            const string sql = "SELECT   [col_name] FROM [dbo].[tbl_passenger] ";
            using (var reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<tbl_passenger>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("tbl_passenger", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id_tbl_passenger,col_name,col_passenger_state,col_indentity_no,id_tbl_user, col_ischecked");
            strSql.Append(" FROM tbl_passenger ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        public DataSet GetList(int id_tbl_user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id_tbl_passenger,col_name,col_passenger_state,col_indentity_no,id_tbl_user, col_ischecked");
            strSql.Append(" FROM tbl_passenger ");
            strSql.Append(" where id_tbl_user=" + id_tbl_user);
          
            return SqlHelper.Query(strSql.ToString());
        }

        public DataSet GetTopList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id_tbl_passenger,col_name,col_passenger_state,col_indentity_no,id_tbl_user, col_ischecked");
            strSql.Append(" FROM tbl_passenger ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BusSystem.Model.tbl_passenger  DataRowToModel(DataRow row)
        {
            BusSystem.Model.tbl_passenger model = new BusSystem.Model.tbl_passenger();
            if (row != null)
            {
                if (row["id_tbl_passenger"] != null && row["id_tbl_passenger"].ToString() != "")
                {
                    model.id_tbl_passenger = int.Parse(row["id_tbl_passenger"].ToString());
                }
                if (row["col_name"] != null)
                {
                    model.col_name = row["col_name"].ToString();
                }
                if (row["col_passenger_state"] != null)
                {
                    model.col_passenger_state = int.Parse(row["col_passenger_state"].ToString());
                }
                if (row["col_indentity_no"] != null)
                {
                    model.col_indentity_no = row["col_indentity_no"].ToString();
                }
                if (row["id_tbl_user"] != null && row["id_tbl_user"].ToString() != "")
                {
                    model.id_tbl_user = int.Parse(row["id_tbl_user"].ToString());
                }
              
                if (row["col_ischecked"] != null && row["col_ischecked"].ToString() != "")
                {
                    model.col_ischecked = int.Parse(row["col_ischecked"].ToString());
                }
            }
            return model;
        }
        public BusSystem.Model.tbl_passenger GetModel(int id_tbl_user)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   id_tbl_passenger,id_tbl_user,col_ischecked,col_indentity_no,col_passenger_state,col_name from tbl_passenger ");
            strSql.Append(" where id_tbl_user=@id_tbl_user");
            SqlParameter[] parameters = {
					new SqlParameter("@id_tbl_user", SqlDbType.Int,4)
			};
            parameters[0].Value = id_tbl_user;

            BusSystem.Model.tbl_passenger model = new BusSystem.Model.tbl_passenger();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        public BusSystem.Model.tbl_passenger GetTopModel(int id_tbl_user,int col_ischecked)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   id_tbl_passenger,id_tbl_user,col_ischecked,col_indentity_no,col_passenger_state,col_name from tbl_passenger ");
            strSql.Append(" where id_tbl_user=@id_tbl_user and col_ischecked=@col_ischecked");
            SqlParameter[] parameters = {
					new SqlParameter("@id_tbl_user", SqlDbType.Int,4),
                    new SqlParameter ("@col_ischecked",SqlDbType .Int ,4)
			};
            parameters[0].Value = id_tbl_user;
            parameters[1].Value = col_ischecked;
            BusSystem.Model.tbl_passenger model = new BusSystem.Model.tbl_passenger();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tbl_passenger ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}