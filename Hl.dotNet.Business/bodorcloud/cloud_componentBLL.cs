
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
    public class cloud_componentBLL : Icloud_componentBLL
    {
        cloud_componentDal cloud_componentdal = new cloud_componentDal();

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_component model)
        {

            return cloud_componentdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_componentBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_componentdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_component model)
        {
            return cloud_componentdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_componentBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_componentdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_component> getcloud_componentList(cloud_component model)
        {
            IList<cloud_component> list = new List<cloud_component>();
            try
            {
                list = cloud_componentdal.getcloud_componentList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_component QueryObject(cloud_component model)
        {
            IList<cloud_component> list = cloud_componentdal.getcloud_componentList(model);
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
        public bool Insert(cloud_component model)
        {
            return cloud_componentdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_component model)
        {
            return cloud_componentdal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_componentdal.Delete(Id);

        }

    }
}