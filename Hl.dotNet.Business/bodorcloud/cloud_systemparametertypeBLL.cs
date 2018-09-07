
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
    public class cloud_systemparametertypeBLL : Icloud_systemparametertypeBLL
    {
        cloud_systemparametertypeDal cloud_systemparametertypedal = new cloud_systemparametertypeDal();

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_systemparametertype model)
        {

            return cloud_systemparametertypedal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_systemparametertypeBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_systemparametertypedal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_systemparametertypeBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_systemparametertype model)
        {
            return cloud_systemparametertypedal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_systemparametertypeBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_systemparametertypedal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_systemparametertypeBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_systemparametertype> getcloud_systemparametertypeList(cloud_systemparametertype model)
        {
            IList<cloud_systemparametertype> list = new List<cloud_systemparametertype>();
            try
            {
                list = cloud_systemparametertypedal.getcloud_systemparametertypeList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_systemparametertype QueryObject(cloud_systemparametertype model)
        {
            IList<cloud_systemparametertype> list = cloud_systemparametertypedal.getcloud_systemparametertypeList(model);
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
        public bool Insert(cloud_systemparametertype model)
        {
            return cloud_systemparametertypedal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_systemparametertype model)
        {
            return cloud_systemparametertypedal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_systemparametertypedal.Delete(Id);

        }

    }
}