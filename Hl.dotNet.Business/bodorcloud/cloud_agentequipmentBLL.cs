  
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
public class cloud_agentequipmentBLL : Icloud_agentequipmentBLL
    {
     cloud_agentequipmentDal cloud_agentequipmentdal = new cloud_agentequipmentDal();
    
    /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_agentequipment model)
        {

            return cloud_agentequipmentdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_agentequipmentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_agentequipmentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_agentequipmentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        
        
        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_agentequipment model)
        {
            return cloud_agentequipmentdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_agentequipmentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_agentequipmentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_agentequipmentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }
        
         //查询List
        public IList<cloud_agentequipment> getcloud_agentequipmentList(cloud_agentequipment model)
        {
            IList<cloud_agentequipment> list = new List<cloud_agentequipment>();
            try
            {
                list = cloud_agentequipmentdal.getcloud_agentequipmentList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }
        
        
        //获取实体
        public cloud_agentequipment QueryObject(cloud_agentequipment model)
        {
            IList<cloud_agentequipment> list = cloud_agentequipmentdal.getcloud_agentequipmentList(model);
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
        public bool Insert(cloud_agentequipment model)
        {
            return cloud_agentequipmentdal.Insert(model);

        }
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_agentequipment model)
        {
            return cloud_agentequipmentdal.Update(model);

        }
        
         /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string EquipmentId,string UserId)
        {
            return cloud_agentequipmentdal.Delete(EquipmentId, UserId);

        }


        public bool Agentupdate(cloud_agentequipment model)
        {
            return cloud_agentequipmentdal.Agentupdate(model);

        }
    
    }
}