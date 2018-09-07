
using Hl.dotNet.CacheBase;
using Hl.dotNet.DataAccess;
using Hl.dotNet.IBusiness;
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Business
{
    public class base_departmentBLL : Ibase_departmentBLL
    {
        base_departmentDal base_departmentdal = new base_departmentDal();




        public DataTable GetDeparpeopleOrderNum(base_department model)
        {

            return base_departmentdal.GetDeparpeopleOrderNum(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_departmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_departmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        public DataTable GetDeparUserOrderNumtotal(base_department model)
        {

            return base_departmentdal.GetDeparUserOrderNumtotal(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_departmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_departmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 获取部门下各人员上/本季度销售额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDeparUserOrderNum(base_department model)
        {

            return base_departmentdal.GetDeparUserOrderNum(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_departmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_departmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        public DataTable getQBdatatable(base_department model)
        {

            return base_departmentdal.getQBdatatable(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_departmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_departmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 获取上季度活本季度销售情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getdatatableList(base_department model)
        {

            return base_departmentdal.getdatatableList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_departmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_departmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_department model)
        {

            return base_departmentdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_departmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_departmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(base_department model)
        {
            return base_departmentdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_departmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_departmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_departmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<base_department> getbase_departmentList(base_department model)
        {
            IList<base_department> list = new List<base_department>();
            try
            {
                list = base_departmentdal.getbase_departmentList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public base_department QueryObject(base_department model)
        {
            IList<base_department> list = base_departmentdal.getbase_departmentList(model);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(base_department model)
        {
            return base_departmentdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(base_department model)
        {
            return base_departmentdal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return base_departmentdal.Delete(Id);

        }




    }
}