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
    public class cloud_messageBLL : Icloud_messageBLL
    {

        cloud_messageDal cloud_messageDal = new cloud_messageDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_message model)
        {

            return cloud_messageDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_messageBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_messageDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_messageBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_message model)
        {
            return cloud_messageDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_messageBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_messageDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_messageBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_message> getcloud_messageList(cloud_message model)
        {
            IList<cloud_message> list = new List<cloud_message>();
            try
            {
                list = cloud_messageDal.getcloud_messageList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_message QueryObject(cloud_message model)
        {
            IList<cloud_message> list = cloud_messageDal.getcloud_messageList(model);
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
        public bool Insert(cloud_message model)
        {
            return cloud_messageDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_message model)
        {
            return cloud_messageDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return cloud_messageDal.Delete(Id);

        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable geteMessageCount(cloud_message model)
        {

            return cloud_messageDal.geteMessageCount(model);


        }


    }
}
