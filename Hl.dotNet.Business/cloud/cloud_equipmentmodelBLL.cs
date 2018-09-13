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
    public class cloud_equipmentmodelBLL : Icloud_equipmentmodelBLL
    {

        cloud_equipmentmodelDal cloud_equipmentmodelDal = new cloud_equipmentmodelDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_equipmentmodel model)
        {

            return cloud_equipmentmodelDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_equipmentmodelBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_equipmentmodelDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentmodelBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_equipmentmodel model)
        {
            return cloud_equipmentmodelDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_equipmentmodelBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_equipmentmodelDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_equipmentmodelBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_equipmentmodel> getcloud_equipmentmodelList(cloud_equipmentmodel model)
        {
            IList<cloud_equipmentmodel> list = new List<cloud_equipmentmodel>();
            try
            {
                list = cloud_equipmentmodelDal.getcloud_equipmentmodelList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_equipmentmodel QueryObject(cloud_equipmentmodel model)
        {
            IList<cloud_equipmentmodel> list = cloud_equipmentmodelDal.getcloud_equipmentmodelList(model);
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
        public bool Insert(cloud_equipmentmodel model)
        {
            return cloud_equipmentmodelDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_equipmentmodel model)
        {
            return cloud_equipmentmodelDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_equipmentmodelDal.Delete(Id);

        }



    }
}
