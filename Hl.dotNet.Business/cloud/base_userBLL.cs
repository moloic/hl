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
    public class base_userBLL : Ibase_userBLL
    {
        base_userDal base_userDal = new base_userDal();

        #region 售后获取首页信息 月份 工单总量 好评量 完成量
        public DataTable getAftersaleQuery(base_user model)
        {

            return base_userDal.getAftersaleQuery(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        #endregion
        #region 主管获取首页信息 月份 工单总量 好评量 完成量
        public DataTable DergetAftersaleQuery(base_user model)
        {

            return base_userDal.DergetAftersaleQuery(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        #endregion




        #region 售后查询上月评价量
        public DataTable getPJQuery(base_user model)
        {

            return base_userDal.getPJQuery(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        #endregion

     




        #region CRM/技术支持 更改IsWork信息  是否开始工作（0：开始   1：未开始）

        /// <summary>
        /// 更改IsReceive信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CRMUpdateIsReceive(base_user model)
        {
            return base_userDal.CRMUpdateIsReceive(model);

        }


        #endregion


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public base_user getEntityModel(base_user model)
        {
            //return base_userDal.getEntityModel(model);

            IList<base_user> list = base_userDal.getEntityModel(model);
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
        /// 获取用户角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string getbase_userroleQuery(base_user model)
        {
            DataTable dt = base_userDal.getbase_userroleQuery(model);
            string roleid = "";
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    roleid += "'" + dt.Rows[i]["RoleId"] + "',";
                }

            }
            return roleid.TrimEnd(',');
        }







        /// <summary>
        /// 注册验证邮箱是否重复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool getuserEmail(base_user model)
        {
            DataTable dt = base_userDal.getuserEmail(model);
            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool getuserAccount(base_user model)
        {
            DataTable dt = base_userDal.getuserAccount(model);
            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool getuserMobile(base_user model)
        {
            DataTable dt = base_userDal.getuserMobile(model);
            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }





        public bool Insertuserinfo(base_user model)
        {
            return base_userDal.Insertuserinfo(model);

        }

        #region 代理SQL

        public DataTable getAgentUserPageList(base_user model)
        {

            return base_userDal.getAgentUserPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetAgentUserCount(base_user model)
        {
            return base_userDal.GetAgentUserCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_userBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_userDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }


        #endregion



        #region 动软生成的代码

        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_user model)
        {

            return base_userDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(base_user model)
        {
            return base_userDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_userBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_userDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<base_user> getbase_userList(base_user model)
        {
            IList<base_user> list = new List<base_user>();
            try
            {
                list = base_userDal.getbase_userList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }


        //获取实体
        public base_user QueryObject(base_user model)
        {
            IList<base_user> list = base_userDal.getbase_userList(model);
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
        public bool Insert(base_user model)
        {
            return base_userDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(base_user model)
        {
            return base_userDal.Update(model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            return base_userDal.Delete(Id);

        }
        

        #endregion


        #region CRM/技术支持 按部门获取人员


        public DataTable getCRMUserPageList(base_user model)
        {

            return base_userDal.getCRMUserPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }


        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetCRMUserCount(base_user model)
        {
            return base_userDal.GetCRMUserCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("base_userBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = base_userDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        #endregion


        #region 查看部门下的人员（好多部门ID）
        public DataTable getMyDepartmentUserPageList(base_user model)
        {

            return base_userDal.getMyDepartmentUserPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("base_userBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = base_userDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("base_userBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }
        #endregion



        public bool UpdateUserinfoUrl(base_user model)
        {
            return base_userDal.UpdateUserinfoUrl(model);

        }




    }
}
