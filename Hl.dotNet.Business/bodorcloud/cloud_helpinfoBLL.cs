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
    public class cloud_helpinfoBLL : Icloud_helpinfoBLL
    {

        cloud_helpinfoDal cloud_helpinfoDal = new cloud_helpinfoDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_helpinfo model)
        {

            return cloud_helpinfoDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_helpinfoBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_helpinfoDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_helpinfoBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_helpinfo model)
        {
            return cloud_helpinfoDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_helpinfoBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_helpinfoDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_helpinfoBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_helpinfo> getcloud_helpinfoList(cloud_helpinfo model)
        {
            IList<cloud_helpinfo> list = new List<cloud_helpinfo>();
            try
            {
                list = cloud_helpinfoDal.getcloud_helpinfoList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_helpinfo QueryObject(cloud_helpinfo model)
        {
            IList<cloud_helpinfo> list = cloud_helpinfoDal.getcloud_helpinfoList(model);
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
        public bool Insert(cloud_helpinfo model)
        {
            return cloud_helpinfoDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_helpinfo model)
        {
            return cloud_helpinfoDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_helpinfoDal.Delete(Id);

        }

       

    }
}
