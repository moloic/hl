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
    public class cloud_componentrepairrecordBLL : Icloud_componentrepairrecordBLL
    {

        cloud_componentrepairrecordDal cloud_componentrepairrecordDal = new cloud_componentrepairrecordDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componentrepairrecord model)
        {

            return cloud_componentrepairrecordDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_componentrepairrecordBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_componentrepairrecordDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentrepairrecordBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_componentrepairrecord model)
        {
            return cloud_componentrepairrecordDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_componentrepairrecordBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_componentrepairrecordDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componentrepairrecordBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_componentrepairrecord> getcloud_componentrepairrecordList(cloud_componentrepairrecord model)
        {
            IList<cloud_componentrepairrecord> list = new List<cloud_componentrepairrecord>();
            try
            {
                list = cloud_componentrepairrecordDal.getcloud_componentrepairrecordList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_componentrepairrecord QueryObject(cloud_componentrepairrecord model)
        {
            IList<cloud_componentrepairrecord> list = cloud_componentrepairrecordDal.getcloud_componentrepairrecordList(model);
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
        public bool Insert(cloud_componentrepairrecord model)
        {
            return cloud_componentrepairrecordDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_componentrepairrecord model,cloud_componentrepairrecordhistory  modelhistory)
        {
            return cloud_componentrepairrecordDal.Update(model, modelhistory);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_componentrepairrecordDal.Delete(Id);

        }
    }
}

    