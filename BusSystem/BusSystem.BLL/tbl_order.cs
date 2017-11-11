using System.Collections.Generic;
using System.Linq;
using BusSystem.DAL;
using BusSystem.Model;

namespace BusSystem.BLL
{
    public partial class tbl_orderService
    {

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        private tbl_orderDAO _dao = new tbl_orderDAO();

        #region 向数据库中添加一条记录 +int Insert(tbl_order model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_order model)
        {
            return _dao.Insert(model);
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
            return _dao.Insert2(model);
        }
        #endregion

        public int Update2(int id_tbl_order)
        {
            return _dao.Update2(id_tbl_order);
        }
        public int Update4(int id_tbl_order)
        {
            return _dao.Update4(id_tbl_order);
        }

        public tbl_order QuerySingle5(string col_start_time, string col_passenger_tel, string col_passenger_num)
        {
            return _dao.QuerySingle5(col_start_time, col_passenger_tel, col_passenger_num);
        }
        #region 向数据库中添加一条记录 +int Insert3(tbl_order model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert3(tbl_order model)
        {
            return _dao.Insert3(model);
        }
        #endregion

        public int Update3(int id_tbl_order)
        {
            return _dao.Update3(id_tbl_order);
        }
    
        #region 删除一条记录 +int Delete(int id_tbl_order)
        public int Delete(int id_tbl_order)
        {
            return _dao.Delete(id_tbl_order);
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
            return _dao.Update(model);
        }
        #endregion
        public int Update2(int id_tbl_order, string col_order_state)
        {
            return _dao.Update2 ( id_tbl_order,  col_order_state);
        }
        public int Update2(int id_tbl_order, string col_take_order_no, string col_password)
        {
            return _dao.Update2( id_tbl_order,  col_take_order_no,  col_password);
        }

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
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
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
            return _dao.QuerySingle(wheres);
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
            return _dao.QuerySingle(id_tbl_order);
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