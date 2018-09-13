
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
    public class base_qrcoderBLL : Ibase_qrcoderBLL
    {
        base_qrcoderDal base_qrcoderdal = new base_qrcoderDal();

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_qrcoder model)
        {

            return base_qrcoderdal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_qrcoderBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_qrcoderdal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_qrcoderBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(base_qrcoder model)
        {
            return base_qrcoderdal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_qrcoderBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_qrcoderdal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_qrcoderBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<base_qrcoder> getbase_qrcoderList(base_qrcoder model)
        {
            IList<base_qrcoder> list = new List<base_qrcoder>();
            try
            {
                list = base_qrcoderdal.getbase_qrcoderList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public base_qrcoder QueryObject(base_qrcoder model)
        {
            IList<base_qrcoder> list = base_qrcoderdal.getbase_qrcoderList(model);
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
        public bool Insert(base_qrcoder model)
        {
            return base_qrcoderdal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(base_qrcoder model)
        {
            return base_qrcoderdal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return base_qrcoderdal.Delete(Id);

        }

    }
}