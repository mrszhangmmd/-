using System.Collections.Generic;
using System.Linq;
using BusSystem.DAL;
using BusSystem.Model;
using System.Data;

namespace BusSystem.BLL
{
    public partial class view_lineService
    {

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        private view_lineDAO _dao = new view_lineDAO();

        #region 向数据库中添加一条记录 +int Insert(view_line model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(view_line model)
        {
            return _dao.Insert(model);
        }
        #endregion

        #region 删除一条记录 +int Delete(string starttime)
        public int Delete(string starttime)
        {
            return _dao.Delete(starttime);
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
            return _dao.Update(model);
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
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
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
            return _dao.QuerySingle(wheres);
        }
        #endregion

        #region 查询单个模型实体 +view_line QuerySingle2(int id_tbl_line)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public view_line QuerySingle2(int  id_tbl_line)
        {
            return _dao.QuerySingle2(id_tbl_line);
        }
        #endregion
        #region 查询多个模型实体 +view_line  search(string col_start_date,string backcity,string startcity)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public view_line search(string col_start_date, string backcity, string startcity)
        {
            return _dao.search(col_start_date, startcity, backcity);
        }
        #endregion
        #region 查询单个模型实体 +view_line QuerySingle(string starttime)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="starttime">key</param>
        /// <returns>实体</returns>
        public view_line QuerySingle(string starttime)
        {
            return _dao.QuerySingle(starttime);
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

          public DataSet searchline(string col_start_date, string backcity, string startcity)
        {
            return _dao.searchline(col_start_date, col_start_date, col_start_date);
        }
    }
}