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
    public class cloud_alarmBLL : Icloud_alarmBLL
    {

        cloud_alarmDal cloud_alarmDal = new cloud_alarmDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_alarm model)
        {

            return cloud_alarmDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_alarmBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_alarmDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_alarmBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_alarm model)
        {
            return cloud_alarmDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_alarmBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_alarmDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_alarmBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_alarm> getcloud_alarmList(cloud_alarm model)
        {
            IList<cloud_alarm> list = new List<cloud_alarm>();
            try
            {
                list = cloud_alarmDal.getcloud_alarmList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_alarm QueryObject(cloud_alarm model)
        {
            IList<cloud_alarm> list = cloud_alarmDal.getcloud_alarmList(model);
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
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_alarm model)
        {
            return cloud_alarmDal.Update(model);

        }

        //获取警报个数
        public DataTable getalarmCount(cloud_alarm model)
        {

            return cloud_alarmDal.getalarmCount(model);
        }



    }
}
