using System.Collections.Generic;
using System.Linq;
using BusSystem.DAL;
using BusSystem.Model;

namespace BusSystem.BLL 
{
	public partial class tbl_lineService
	{
   		     
		/// <summary>
        /// 数据库操作对象
        /// </summary>
        private tbl_lineDAO _dao = new tbl_lineDAO();

        #region 向数据库中添加一条记录 +int Insert(tbl_line model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_line model)
        {
            return _dao.Insert(model);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_line)
        public int Delete(int id_tbl_line)
        {
            return _dao.Delete(id_tbl_line);
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
            return _dao.Update(model);
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
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
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
            return _dao.QuerySingle(wheres);
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
            return _dao.QuerySingle(id_tbl_line);
        }
        #endregion

        #region 查询单个模型实体 +tbl_line QuerySingle2(string col_line_time,string col_line_price,int col_startid,int col_definitionid)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_line">key</param>
        /// <returns>实体</returns>
        public int QuerySingle2(string col_line_time, string col_line_price, int col_startid, int col_definitionid)
        {
            return _dao.QuerySingle2(col_line_time, col_line_price, col_startid, col_definitionid);
        }
        #endregion

        #region 查询条数 +int QueryCount(object wheres)
        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>实体</returns>
        public int QueryCount(object wheres)
        {
            return _dao.QueryCount(wheres);
        }
        #endregion
	}
}