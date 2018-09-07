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
    public class cloud_componetmessageBLL : Icloud_componetmessageBLL
    {

        cloud_componetmessageDal cloud_componetmessageDal = new cloud_componetmessageDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componetmessage model)
        {

            return cloud_componetmessageDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_componetmessageBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_componetmessageDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componetmessageBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_componetmessage model)
        {
            return cloud_componetmessageDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_componetmessageBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_componetmessageDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componetmessageBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getMyMessagePageList(cloud_componetmessage model)
        {

            return cloud_componetmessageDal.getMyMessagePageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_componetmessageBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_componetmessageDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componetmessageBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        //获取邮件内容
        public DataTable getMessageList(cloud_componetmessage model)
        {
            return cloud_componetmessageDal.getMessageList(model);
        }
        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetMyMessageRecordCount(cloud_componetmessage model)
        {
            return cloud_componetmessageDal.GetMyMessageRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_componetmessageBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_componetmessageDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_componetmessageBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }











        //查询List
        public IList<cloud_componetmessage> getcloud_componetmessageList(cloud_componetmessage model)
        {
            IList<cloud_componetmessage> list = new List<cloud_componetmessage>();
            try
            {
                list = cloud_componetmessageDal.getcloud_componetmessageList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_componetmessage QueryObject(cloud_componetmessage model)
        {
            IList<cloud_componetmessage> list = cloud_componetmessageDal.getcloud_componetmessageList(model);
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
        public bool Insert(cloud_componetmessage model)
        {
            return cloud_componetmessageDal.Insert(model);

        }
        //批量增加
        public bool InsertList(List<cloud_componetmessage> list)
        {
            return cloud_componetmessageDal.InsertList(list);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_componetmessage model)
        {
            return cloud_componetmessageDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_componetmessageDal.Delete(Id);

        }





    }
}
