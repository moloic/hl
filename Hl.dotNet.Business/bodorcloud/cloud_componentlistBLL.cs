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
    public class cloud_componentlistBLL : Icloud_componentlistBLL
    {

        cloud_componentlistDal cloud_componentlistDal = new cloud_componentlistDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componentlist model)
        {

            return cloud_componentlistDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_componentlistBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_componentlistDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentlistBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_componentlist model)
        {
            return cloud_componentlistDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_componentlistBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_componentlistDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentlistBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_componentlist> getcloud_componentlistList(cloud_componentlist model)
        {
            IList<cloud_componentlist> list = new List<cloud_componentlist>();
            try
            {
                list = cloud_componentlistDal.getcloud_componentlistList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_componentlist QueryObject(cloud_componentlist model)
        {
            IList<cloud_componentlist> list = cloud_componentlistDal.getcloud_componentlistList(model);
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
        public bool Insert(cloud_componentlist model)
        {
            return cloud_componentlistDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_componentlist model)
        {
            return cloud_componentlistDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_componentlistDal.Delete(Id);

        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getDiccategory(cloud_componentlist model)
        {
            DataTable dt = cloud_componentlistDal.getDiccategory(model);
            return dt;
        }


    }
}
