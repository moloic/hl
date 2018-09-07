
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
    public class cloud_systemparameterlogBLL : Icloud_systemparameterlogBLL
    {
        cloud_systemparameterlogDal cloud_systemparameterlogdal = new cloud_systemparameterlogDal();

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_systemparameterlog model)
        {

            return cloud_systemparameterlogdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_systemparameterlogBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_systemparameterlogdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_systemparameterlogBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_systemparameterlog model)
        {
            return cloud_systemparameterlogdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_systemparameterlogBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_systemparameterlogdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_systemparameterlogBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_systemparameterlog> getcloud_systemparameterlogList(cloud_systemparameterlog model)
        {
            IList<cloud_systemparameterlog> list = new List<cloud_systemparameterlog>();
            try
            {
                list = cloud_systemparameterlogdal.getcloud_systemparameterlogList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_systemparameterlog QueryObject(cloud_systemparameterlog model)
        {
            IList<cloud_systemparameterlog> list = cloud_systemparameterlogdal.getcloud_systemparameterlogList(model);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }
    }
}