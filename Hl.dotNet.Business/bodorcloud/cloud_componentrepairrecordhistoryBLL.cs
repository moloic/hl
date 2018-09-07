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
    public class cloud_componentrepairrecordhistoryBLL : Icloud_componentrepairrecordhistoryBLL
    {

        cloud_componentrepairrecordhistoryDal cloud_componentrepairrecordhistoryDal = new cloud_componentrepairrecordhistoryDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componentrepairrecordhistory model)
        {

            return cloud_componentrepairrecordhistoryDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_componentrepairrecordhistoryBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_componentrepairrecordhistoryDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentrepairrecordhistoryBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_componentrepairrecordhistory model)
        {
            return cloud_componentrepairrecordhistoryDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_componentrepairrecordhistoryBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_componentrepairrecordhistoryDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentrepairrecordhistoryBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_componentrepairrecordhistory> getcloud_componentrepairrecordhistoryList(cloud_componentrepairrecordhistory model)
        {
            IList<cloud_componentrepairrecordhistory> list = new List<cloud_componentrepairrecordhistory>();
            try
            {
                list = cloud_componentrepairrecordhistoryDal.getcloud_componentrepairrecordhistoryList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_componentrepairrecordhistory QueryObject(cloud_componentrepairrecordhistory model)
        {
            IList<cloud_componentrepairrecordhistory> list = cloud_componentrepairrecordhistoryDal.getcloud_componentrepairrecordhistoryList(model);
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
        public bool Insert(cloud_componentrepairrecordhistory model)
        {
            return cloud_componentrepairrecordhistoryDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_componentrepairrecordhistory model)
        {
            return cloud_componentrepairrecordhistoryDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_componentrepairrecordhistoryDal.Delete(Id);

        }
    }
}

