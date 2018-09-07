
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
    public class cloud_userequipmentBLL : Icloud_userequipmentBLL
    {
        cloud_userequipmentDal cloud_userequipmentdal = new cloud_userequipmentDal();


        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserPageList(cloud_userequipment model)
        {

            return cloud_userequipmentdal.getuserPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_userequipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_userequipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_userequipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        public int GetuserRecordCount(cloud_userequipment model)
        {
            return cloud_userequipmentdal.GetuserRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_userequipmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_userequipmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_userequipmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }




        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_userequipment model)
        {

            return cloud_userequipmentdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_userequipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_userequipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_userequipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_userequipment model)
        {
            return cloud_userequipmentdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_userequipmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_userequipmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_userequipmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_userequipment> getcloud_userequipmentList(cloud_userequipment model)
        {
            IList<cloud_userequipment> list = new List<cloud_userequipment>();
            try
            {
                list = cloud_userequipmentdal.getcloud_userequipmentList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_userequipment QueryObject(cloud_userequipment model)
        {
            IList<cloud_userequipment> list = cloud_userequipmentdal.getcloud_userequipmentList(model);
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
        public bool Insert(cloud_userequipment model)
        {
            return cloud_userequipmentdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_userequipment model)
        {
            return cloud_userequipmentdal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string EquipmentId, string UserId)
        {
            return cloud_userequipmentdal.Delete(EquipmentId, UserId);

        }




    }
}