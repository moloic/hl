﻿  
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
public class cloud_equipmentcomponenBLL : Icloud_equipmentcomponenBLL
    {
     cloud_equipmentcomponenDal cloud_equipmentcomponendal = new cloud_equipmentcomponenDal();
    
    /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_equipmentcomponen model)
        {

            return cloud_equipmentcomponendal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentcomponenBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentcomponendal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentcomponenBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        
        
        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_equipmentcomponen model)
        {
            return cloud_equipmentcomponendal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_equipmentcomponenBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_equipmentcomponendal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentcomponenBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }
        
         //查询List
        public IList<cloud_equipmentcomponen> getcloud_equipmentcomponenList(cloud_equipmentcomponen model)
        {
            IList<cloud_equipmentcomponen> list = new List<cloud_equipmentcomponen>();
            try
            {
                list = cloud_equipmentcomponendal.getcloud_equipmentcomponenList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }
        
        
        //获取实体
        public cloud_equipmentcomponen QueryObject(cloud_equipmentcomponen model)
        {
            IList<cloud_equipmentcomponen> list = cloud_equipmentcomponendal.getcloud_equipmentcomponenList(model);
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
        public bool Insert(cloud_equipmentcomponen model)
        {
            return cloud_equipmentcomponendal.Insert(model);

        }
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_equipmentcomponen model)
        {
            return cloud_equipmentcomponendal.Update(model);

        }
        
         /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id, string EID)
        {
            return cloud_equipmentcomponendal.Delete(Id, EID);

        }
        
        
        
    
    }
}