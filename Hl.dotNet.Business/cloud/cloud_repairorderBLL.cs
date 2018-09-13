
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
    public class cloud_repairorderBLL : Icloud_repairorderBLL
    {
        cloud_repairorderDal cloud_repairorderdal = new cloud_repairorderDal();



        #region  代理查询工单列表


        public DataTable DLGetUserOrderList(cloud_repairorder model)
        {

            return cloud_repairorderdal.DLGetUserOrderList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_repairorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 用户查询工单信息条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DLGetUserOrderCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.DLGetUserOrderCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_repairorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }


        #endregion

        #region 上传工单

        public bool DLUpdate(cloud_repairorder model)
        {
            return cloud_repairorderdal.DLUpdate(model);

        }

        #endregion




        #region 用户查询工单信息

        /// <summary>
        /// 用户查询工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetUserOrderList(cloud_repairorder model)
        {

            return cloud_repairorderdal.GetUserOrderList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_repairorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 用户查询工单信息条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetUserOrderCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.GetUserOrderCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_repairorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }


        #endregion


        /// <summary>
        /// 管理界面返回订单详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserlistorder(cloud_repairorder model)
        {

            return cloud_repairorderdal.getuserlistorder(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_repairorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 管理界面返回订单详情条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetUserListCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.GetUserListCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_repairorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_repairorder model)
        {

            return cloud_repairorderdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_repairorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_repairorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_repairorder> getcloud_repairorderList(cloud_repairorder model)
        {
            IList<cloud_repairorder> list = new List<cloud_repairorder>();
            try
            {
                list = cloud_repairorderdal.getcloud_repairorderList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_repairorder QueryObject(cloud_repairorder model)
        {
            IList<cloud_repairorder> list = cloud_repairorderdal.getcloud_repairorderList(model);
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
        public bool Insert(cloud_repairorder model)
        {
            return cloud_repairorderdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_repairorder model)
        {
            return cloud_repairorderdal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_repairorderdal.Delete(Id);

        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Updateorderstate(cloud_repairorder model)
        {
            return cloud_repairorderdal.Updateorderstate(model);

        }
        /// <summary>
        /// 获取首页工单数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getRepairorderCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.getRepairorderCount(model);
        }

        #region CRM获取国外工单信息
        /// <summary>
        /// 获取国外工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetCrmOrderList(cloud_repairorder model)
        {

            return cloud_repairorderdal.GetCrmOrderList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_repairorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 获取国外工单条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetCrmOrderListCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.GetCrmOrderListCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_repairorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }


        #endregion


        /// <summary>
        /// 获取CRM角色的用户条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetCrmUserListCount(cloud_repairorder model)
        {
            return cloud_repairorderdal.GetCrmUserListCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_repairorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_repairorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_repairorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }




    }
}