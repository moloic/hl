
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
    public class cloud_workpersonnelBLL : Icloud_workpersonnelBLL
    {
        cloud_workpersonnelDal cloud_workpersonneldal = new cloud_workpersonnelDal();



        public DataTable ZGGetDirectorOrderList(cloud_workpersonnel model)
        {

            return cloud_workpersonneldal.ZGGetDirectorOrderList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_workpersonneldal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ZGGetDirectorCount(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.ZGGetDirectorCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_workpersonneldal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }


        #region 主管查询订单列表

        public DataTable GetDirectorOrderList(cloud_workpersonnel model)
        {

            return cloud_workpersonneldal.GetDirectorOrderList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_workpersonneldal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetDirectorCount(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.GetDirectorCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_workpersonneldal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }


        /// <summary>
        /// 查看订单详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDirectorOrderListInfo(cloud_workpersonnel model)
        {

            return cloud_workpersonneldal.GetDirectorOrderListInfo(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_workpersonneldal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        #endregion

        /// <summary>
        /// CRM分配订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CRMInsertwork(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.CRMInsertwork(model);

        }

        public DataTable getderuserList(cloud_workpersonnel model)
        {

            return cloud_workpersonneldal.getderuserList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_workpersonneldal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetderuserCount(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.GetderuserCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_workpersonneldal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }



        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_workpersonnel model)
        {

            return cloud_workpersonneldal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_workpersonneldal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_workpersonneldal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_workpersonnel> getcloud_workpersonnelList(cloud_workpersonnel model)
        {
            IList<cloud_workpersonnel> list = new List<cloud_workpersonnel>();
            try
            {
                list = cloud_workpersonneldal.getcloud_workpersonnelList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_workpersonnel QueryObject(cloud_workpersonnel model)
        {
            IList<cloud_workpersonnel> list = cloud_workpersonneldal.getcloud_workpersonnelList(model);
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
        public bool Insert(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_workpersonneldal.Delete(Id);

        }




        #region 查询用户是否与此订单关联


        public int GetUserOrderCount(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.GetUserOrderCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_workpersonnelBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_workpersonneldal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_workpersonnelBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }
        #endregion

        #region 售后回退工单更改工单信息

        /// <summary>
        /// 售后回退工单更改工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOrderState(cloud_workpersonnel model)
        {
            return cloud_workpersonneldal.UpdateOrderState(model);

        }
        #endregion



    }
}