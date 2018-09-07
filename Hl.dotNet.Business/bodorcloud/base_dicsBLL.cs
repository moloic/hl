using Hl.dotNet.CacheBase;
using Hl.dotNet.DataAccess;
using Hl.dotNet.IBusiness;
using Hl.dotNet.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Business
{
    public class base_dicsBLL : Ibase_dicsBLL
    {

        base_dicsDal base_dicsDal = new base_dicsDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(Base_DicsModel model)
        {

            return base_dicsDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_dicsBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_dicsDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_dicsBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Base_DicsModel model)
        {
            return base_dicsDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_dicsBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_dicsDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_dicsBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<Base_DicsModel> getbase_dicsList(Base_DicsModel model)
        {
            IList<Base_DicsModel> list = new List<Base_DicsModel>();
            try
            {
                list = base_dicsDal.getbase_dicsList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public Base_DicsModel QueryObject(Base_DicsModel model)
        {
            IList<Base_DicsModel> list = base_dicsDal.getbase_dicsList(model);
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
        public bool Insert(Base_DicsModel model)
        {
            return base_dicsDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Base_DicsModel model)
        {
            return base_dicsDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return base_dicsDal.Delete(Id);

        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getDiccategory(Base_DicsModel model)
        {
            DataTable dt = base_dicsDal.getDiccategory(model);
            return dt;
        }
        public DataTable getDicsTable(Base_DicsModel model)
        {
            DataTable dt = base_dicsDal.getDicsTable(model);
            return dt;
        }


        #region 获取下拉框（公用）

        /// <summary>
        /// 获取下拉框（公用）
        /// </summary>
        /// <param name="ht">值</param>
        /// <returns></returns>
        public DataTable getDropdownval(Hashtable ht)
        {
            DataTable dt = base_dicsDal.getDropdownval(ht);
            return dt;
        }

        #endregion


    }
}
