using System.Collections.Generic;
using System.Linq;
using BusSystem.DAL;
using BusSystem.Model;

namespace BusSystem.BLL 
{
	public partial class tbl_bus_stationService
	{
   		     
		/// <summary>
        /// 数据库操作对象
        /// </summary>
        private tbl_bus_stationDAO _dao = new tbl_bus_stationDAO();

        #region 向数据库中添加一条记录 +int Insert(tbl_bus_station model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_bus_station model)
        {
            return _dao.Insert(model);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_bus_station)
        public int Delete(int id_tbl_bus_station)
        {
            return _dao.Delete(id_tbl_bus_station);
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
            return _dao.Update(model);
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
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
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
            return _dao.QuerySingle(wheres);
        }
        #endregion
        #region 查询单个模型实体 +QuerySingleforcityname(string col_name)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public tbl_bus_station QuerySingleforcityname(string col_name)
        {
            return _dao.QuerySingleforcityname(col_name);
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
            return _dao.QuerySingle(id_tbl_bus_station);
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