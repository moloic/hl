
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
    public class cloud_crmandsupportorderBLL : Icloud_crmandsupportorderBLL
    {
        cloud_crmandsupportorderDal cloud_crmandsupportorderdal = new cloud_crmandsupportorderDal();

        /// <summary>
        /// 获取在线的CRM/技术支持信息和未做的工单数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getCRMInfoList(cloud_crmandsupportorder model)
        {

            return cloud_crmandsupportorderdal.getCRMInfoList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_crmandsupportorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_crmandsupportorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_crmandsupportorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_crmandsupportorder model)
        {

            return cloud_crmandsupportorderdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_crmandsupportorderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_crmandsupportorderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_crmandsupportorderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_crmandsupportorderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_crmandsupportorderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_crmandsupportorderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_crmandsupportorder> getcloud_crmandsupportorderList(cloud_crmandsupportorder model)
        {
            IList<cloud_crmandsupportorder> list = new List<cloud_crmandsupportorder>();
            try
            {
                list = cloud_crmandsupportorderdal.getcloud_crmandsupportorderList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public cloud_crmandsupportorder QueryObject(cloud_crmandsupportorder model)
        {
            IList<cloud_crmandsupportorder> list = cloud_crmandsupportorderdal.getcloud_crmandsupportorderList(model);
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
        public bool Insert(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.Update(model);

        }

        public bool ManUpdateorder(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.ManUpdateorder(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_crmandsupportorderdal.Delete(Id);

        }

        /// <summary>
        /// 获取历史月份
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getmonthsList(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.getmonthsList(model);
        }

        /// <summary>
        /// 昨天统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getYearDaysList(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.getYearDaysList(model);
        
        }

        /// <summary>
        /// 按照天统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getdaysList(cloud_crmandsupportorder model)
        {
            return cloud_crmandsupportorderdal.getdaysList(model);
        }
 
    }
}