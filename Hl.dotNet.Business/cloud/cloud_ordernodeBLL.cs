  
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
public class cloud_ordernodeBLL : Icloud_ordernodeBLL
    {
     cloud_ordernodeDal cloud_ordernodedal = new cloud_ordernodeDal();
    
    /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_ordernode model)
        {

            return cloud_ordernodedal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_ordernodeBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_ordernodedal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_ordernodeBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        
        
        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_ordernode model)
        {
            return cloud_ordernodedal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_ordernodeBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_ordernodedal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_ordernodeBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }
        
         //查询List
        public IList<cloud_ordernode> getcloud_ordernodeList(cloud_ordernode model)
        {
            IList<cloud_ordernode> list = new List<cloud_ordernode>();
            try
            {
                list = cloud_ordernodedal.getcloud_ordernodeList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }
        
        
        //获取实体
        public cloud_ordernode QueryObject(cloud_ordernode model)
        {
            IList<cloud_ordernode> list = cloud_ordernodedal.getcloud_ordernodeList(model);
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
        public bool Insert(cloud_ordernode model)
        {
            return cloud_ordernodedal.Insert(model);

        }
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_ordernode model)
        {
            return cloud_ordernodedal.Update(model);

        }
        
         /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_ordernodedal.Delete(Id);

        }
        
        
        
    
    }
}