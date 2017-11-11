using System.Collections.Generic;
using System.Linq;
using BusSystem.DAL;
using BusSystem.Model;
using System.Data;

namespace BusSystem.BLL
{
    public partial class tbl_passengerService
    {

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        private tbl_passengerDAO _dao = new tbl_passengerDAO();

        #region 向数据库中添加一条记录 +int Insert(tbl_passenger model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(tbl_passenger model)
        {
            return _dao.Insert(model);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id_tbl_passenger)
        public int Delete(int id_tbl_passenger)
        {
            return _dao.Delete(id_tbl_passenger);
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
            return _dao.Update(model);
        }
        #endregion
        
            #region 根据主键ID更新一条记录 +int Updateischecked(int id_tbl_passenger, int col_ischecked)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Updateischecked(int id_tbl_passenger, int col_ischecked)
        {
            return _dao.Updateischecked(id_tbl_passenger, col_ischecked);
        }
            #endregion
        #region 根据主键ID更新一条记录 +int Updateischecked(int id_tbl_passenger)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Updateischecked(int id_tbl_passenger)
        {
            return _dao.Updateischecked(id_tbl_passenger);
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Updateischecked2(int id_tbl_user)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Updateischecked2(int id_tbl_user)
        {
            return _dao.Updateischecked2(id_tbl_user);
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
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
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
            return _dao.QuerySingle(wheres);
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
            return _dao.QuerySingle(id_tbl_passenger);
        }
        #endregion

        #region 查询单个模型实体 +int QuerySingle4(int id_tbl_passenger)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id_tbl_passenger">key</param>
        /// <returns>实体</returns>
        public int QuerySingle4(int id_tbl_passenger)
        {
            return _dao.QuerySingle4(id_tbl_passenger);
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
            return _dao.QuerySingle3();
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
            return _dao.QuerySingle2(id_tbl_user);
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return _dao.GetList(strWhere);
        }


        public BusSystem.Model.tbl_passenger GetTopModel(int id_tbl_user, int col_ischecked)
        {
            return _dao.GetTopModel(id_tbl_user,col_ischecked );
        }
        /// <summary>
        /// 获得单个数据列表
        /// </summary>
        public DataSet GetTopList(string strWhere)
        {
            return _dao.GetTopList(strWhere);
        }
        //获取记录数
        public int GetRecordCount(string strWhere)
        {
            return _dao.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int id_user)
        {
            return _dao.GetList(id_user);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public BusSystem.Model.tbl_passenger  GetModel(int id_tbl_user)
        {

            return _dao.GetModel(id_tbl_user);
        }
    }
}