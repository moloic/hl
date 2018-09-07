
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
    public class cloud_equipmentBLL : Icloud_equipmentBLL
    {
        cloud_equipmentDal cloud_equipmentdal = new cloud_equipmentDal();




        /// <summary>
        /// 代理查询设备列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getagentPageList(cloud_equipment model)
        {

            return cloud_equipmentdal.getagentPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 代理查询设备列表总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetAgentPageCount(cloud_equipment model)
        {
            return cloud_equipmentdal.GetAgentPageCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_equipmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }




        /// <summary>
        /// 获取零件分类信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getcomponentList(cloud_equipment model)
        {

            return cloud_equipmentdal.getcomponentList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 获取零件信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getcomponentinfo(cloud_equipment model)
        {

            return cloud_equipmentdal.getcomponentinfo(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回零件信息总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetcomponentinfoCount(cloud_equipment model)
        {
            return cloud_equipmentdal.GetcomponentinfoCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_equipmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        /// <summary>
        /// 查询用户下设备详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserequipment(cloud_equipment model)
        {

            return cloud_equipmentdal.getuserequipment(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_equipment model)
        {

            return cloud_equipmentdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_equipment model)
        {
            return cloud_equipmentdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_equipmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_equipment> getcloud_equipmentList(cloud_equipment model)
        {
            IList<cloud_equipment> list = new List<cloud_equipment>();
            try
            {
                list = cloud_equipmentdal.getcloud_equipmentList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_equipment QueryObject(cloud_equipment model)
        {
            IList<cloud_equipment> list = cloud_equipmentdal.getcloud_equipmentList(model);
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
        public bool Insert(cloud_equipment model)
        {
            return cloud_equipmentdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_equipment model)
        {
            return cloud_equipmentdal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_equipmentdal.Delete(Id);

        }


        /// <summary>
        /// 查询自己及自己的代理 设备管理业务人员下拉框使用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable IandAgent(cloud_equipment model)
        {

            return cloud_equipmentdal.IandAgent(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 获取设备个数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getequipmentCount(cloud_equipment model)
        {

            return cloud_equipmentdal.getequipmentCount(model);
        }


        /// <summary>
        /// 客户首页设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getCousmentList(cloud_equipment model)
        {

            return cloud_equipmentdal.getCousmentList(model);
        }
    }
}