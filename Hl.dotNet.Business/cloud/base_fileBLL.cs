  
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
public class base_fileBLL : Ibase_fileBLL
    {
     base_fileDal base_filedal = new base_fileDal();
    
    /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_file model)
        {

            return base_filedal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_fileBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_filedal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_fileBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        
        
        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(base_file model)
        {
            return base_filedal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_fileBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_filedal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_fileBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }
        
         //查询List
        public IList<base_file> getbase_fileList(base_file model)
        {
            IList<base_file> list = new List<base_file>();
            try
            {
                list = base_filedal.getbase_fileList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }
        
        
        //获取实体
        public base_file QueryObject(base_file model)
        {
            IList<base_file> list = base_filedal.getbase_fileList(model);
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
        public bool Insert(base_file model)
        {
            return base_filedal.Insert(model);

        }
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(base_file model)
        {
            return base_filedal.Update(model);

        }
        
         /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return base_filedal.Delete(Id);

        }
        
        
        
    
    }
}