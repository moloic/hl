using Hl.dotNet.Models;
using Hl.dotNet.Orm;
using Hl.dotNet.Repository;
using Hl.dotNet.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.DataAccess
{
    public class base_userDal : RepositoryFactory<base_user>
    {

        #region 售后查询上月评价量

        public DataTable getPJQuery(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) as pjnum,a.Level from cloud_repairorder a");
            strSql.Append(" left join cloud_workpersonnel b on a.Id=b.OrderId ");
            strSql.Append(" where PERIOD_DIFF( date_format( now( ) , '%Y%m' ) , date_format( b.CreateDate, '%Y%m' ) ) =1");
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" and b.UserId = '{0}' ", model.UserId));
            }
            strSql.Append(" group by a.`Level` ; ");



            return Repository().FindTableBySql(strSql.ToString());
        }


        #endregion

        #region 售后获取首页信息 月份 工单总量 好评量 完成量

        public DataTable getAftersaleQuery(base_user model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select a.*,b.complete,c.Praise from (SELECT month,COUNT(*) AS total ");
            strSql.Append(" FROM (");
            strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month FROM cloud_workpersonnel a ");
            strSql.Append(" WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018 ");
            strSql.Append(" and a.UserId in ( ");
            //按部门查询
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" select UserId from base_user where DepartmentId = '{0}' ", model.DepartmentId));
            }
            //按人员查询
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" '{0}' ", model.UserId));
            }

            strSql.Append(" ) ");
            strSql.Append("  GROUP BY a.OrderId ) a GROUP BY month)a left join ( SELECT month,COUNT(*) AS complete FROM ( ");
            strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month FROM cloud_workpersonnel a left join cloud_repairorder b on a.orderid=b.id ");
            strSql.Append("  WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018 ");
            strSql.Append(" and b.state=5  and a.UserId in (");
            //按部门查询
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" select UserId from base_user where DepartmentId = '{0}' ", model.DepartmentId));
            }
            //按人员查询
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" '{0}' ", model.UserId));
            }
            strSql.Append(" ) group by b.id ");
            strSql.Append(" )a GROUP BY month  ) b on a.month=b.month left join  (  SELECT month,COUNT(*) AS Praise FROM ( ");
            strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month FROM cloud_workpersonnel a left join cloud_repairorder b on a.orderid=b.id ");
            strSql.Append(" WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018");
            strSql.Append(" and b.Level>3  and a.UserId in (");
            //按部门查询
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" select UserId from base_user where DepartmentId = '{0}' ", model.DepartmentId));
            }
            //按人员查询
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" '{0}' ", model.UserId));
            }
            strSql.Append(" )  group by b.id ");

            strSql.Append(" )a GROUP BY month ) c on a.month=c.month GROUP BY month;");
            //strSql.Append(" SELECT a.month,COUNT(*) AS count,a.num,c.ccount");
            //strSql.Append(" FROM (");
            //strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month,b.num");
            //strSql.Append(" FROM cloud_workpersonnel a ");
            //strSql.Append(" left join( select b.Id,count(b.Id) as num from cloud_repairorder b  where  b.Level>=4) b on a.OrderId=b.Id");
            //strSql.Append(" WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018");
            //if (!string.IsNullOrEmpty(model.UserId))
            //{
            //    strSql.Append(string.Format(" and a.UserId = '{0}' ", model.UserId));
            //}
            //strSql.Append(" )a");
            //strSql.Append(" left join  ( ");
            //strSql.Append("  SELECT month,COUNT(*) AS ccount");
            //strSql.Append(" FROM (");
            //strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month");
            //strSql.Append(" FROM cloud_workpersonnel a ");
            //strSql.Append(" WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018 and a.State=1 ");
            //if (!string.IsNullOrEmpty(model.UserId))
            //{
            //    strSql.Append(string.Format(" and a.UserId = '{0}' ", model.UserId));
            //}
            //strSql.Append(" )a");
            //strSql.Append(" GROUP BY month) c on a.month=c.month");
            //strSql.Append(" GROUP BY month;");



            return Repository().FindTableBySql(strSql.ToString());
        }

        #endregion

        #region 主管获取首页信息 月份 工单总量 好评量 完成量

        public DataTable DergetAftersaleQuery(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,b.complete,c.Praise from (SELECT month,COUNT(*) AS total ");
            strSql.Append(" FROM (");
            strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month FROM cloud_workpersonnel a ");
            strSql.Append(" WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018 ");
            strSql.Append(" and a.UserId in ( ");
            //按部门查询
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" select UserId from base_user where DepartmentId = '{0}' ", model.DepartmentId));
            }
            //按人员查询
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" '{0}' ", model.UserId));
            }

            strSql.Append(" ) ");
            strSql.Append("  GROUP BY a.OrderId ) a GROUP BY month)a left join ( SELECT month,COUNT(*) AS complete FROM ( ");
            strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month FROM cloud_workpersonnel a left join cloud_repairorder b on a.orderid=b.id ");
            strSql.Append("  WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018 ");
            strSql.Append(" and b.state=5  and a.UserId in (");
            //按部门查询
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" select UserId from base_user where DepartmentId = '{0}' ", model.DepartmentId));
            }
            //按人员查询
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" '{0}' ", model.UserId));
            }
            strSql.Append(" ) group by b.id ");
            strSql.Append(" )a GROUP BY month  ) b on a.month=b.month left join  (  SELECT month,COUNT(*) AS Praise FROM ( ");
            strSql.Append(" SELECT DATE_FORMAT(a.CreateDate, '%m') month FROM cloud_workpersonnel a left join cloud_repairorder b on a.orderid=b.id ");
            strSql.Append(" WHERE DATE_FORMAT(a.CreateDate, '%Y') = 2018");
            strSql.Append(" and b.Level>3  and a.UserId in (");
            //按部门查询
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" select UserId from base_user where DepartmentId = '{0}' ", model.DepartmentId));
            }
            //按人员查询
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" '{0}' ", model.UserId));
            }
            strSql.Append(" )  group by b.id ");

            strSql.Append(" )a GROUP BY month ) c on a.month=c.month GROUP BY month;");

            return Repository().FindTableBySql(strSql.ToString());
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

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update base_user  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" IsWork = {0} ", model.IsWork));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" UserId = '{0}' ", model.UserId));
            }
            i = Repository().UpdateBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                //database.Commit();
            }
            else
            {
                // database.Rollback();
            }
            return isok;

        }



        #endregion



        public IList<base_user> getEntityModel(base_user model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,b.FullName as DepartmentName");
            strSql.Append(" from   base_user a left join base_department b");
            strSql.Append(" on a.DepartmentId=b.DepartmentId");
            strSql.Append(" where");

            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" a.UserId = '{0}' ", model.UserId));
            }
            if (!string.IsNullOrEmpty(model.Account))
            {
                strSql.Append(string.Format("  a.Account = '{0}' ", model.Account));
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                strSql.Append(string.Format("  a.Email = '{0}' ", model.Email));
            }
            return Repository().FindListBySql(strSql.ToString());

        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public base_user getEntityModel(base_user model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append(" select a.*,b.FullName as DepartmentName");
        //    strSql.Append(" from   base_user a left join base_department b");
        //    strSql.Append(" on a.DepartmentId=b.DepartmentId");
        //    strSql.Append(" where");

        //    if (!string.IsNullOrEmpty(model.UserId))
        //    {
        //        strSql.Append(string.Format(" a.UserId = '{0}' ", model.UserId));
        //    }
        //    if (!string.IsNullOrEmpty(model.Account))
        //    {
        //        strSql.Append(string.Format("  a.Account = '{0}' ", model.Account));
        //    }
        //    if (!string.IsNullOrEmpty(model.Email))
        //    {
        //        strSql.Append(string.Format("  a.Email = '{0}' ", model.Email));
        //    }

        //    return Repository().FindEntityBySql(strSql.ToString());
        //}


        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getbase_userroleQuery(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select   *  from");
            strSql.Append(" (");
            strSql.Append(" select *  from   base_userrole a");
            strSql.Append(" WHERE");


            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" a.UserId = '{0}' ", model.UserId));
            }
            strSql.Append(" ) a");
            return Repository().FindTableBySql(strSql.ToString());
        }




        /// <summary>
        /// 注册验证邮箱是否重复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserEmail(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *,1 as DepartmentName");
            strSql.Append(" from   base_user a");
            strSql.Append(" where 1=1");


            if (!string.IsNullOrEmpty(model.Email))
            {
                strSql.Append(string.Format(" and a.Email = '{0}' ", model.Email));
            }
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 验证用户名是否重复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserAccount(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * ");
            strSql.Append(" from   base_user a");
            strSql.Append(" where 1=1");


            if (!string.IsNullOrEmpty(model.Email))
            {
                strSql.Append(string.Format(" and a.Account = '{0}' ", model.Email));
            }
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 验证手机号码是否重复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserMobile(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * ");
            strSql.Append(" from   base_user a");
            strSql.Append(" where 1=1");


            if (!string.IsNullOrEmpty(model.Email))
            {
                strSql.Append(string.Format(" and a.Mobile = '{0}' ", model.Email));
            }
            return Repository().FindTableBySql(strSql.ToString());
        }





        /// <summary>
        /// 注册添加信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insertuserinfo(base_user model)
        {

            //带事务的增加
            StringBuilder strSql = new StringBuilder();
            string Modelname = "";
            object Modelvalue = "";
            bool isok = false;
            try
            {
                //PropertyInfo[] propertys = model.GetType().GetProperties();
                //foreach (PropertyInfo property in propertys)
                //{
                //    string name = property.Name;
                //    object value = property.GetValue(model, null);
                //    if (value != null)
                //    {
                //        Modelname += "" + name + ",";
                //        Modelvalue += value.ToString() + ",";
                //    }
                //}
                //Modelname = Modelname.TrimEnd(',');
                //Modelvalue = Modelvalue.ToString().TrimEnd(',');
                //strSql.Append(" INSERT INTO base_user ");
                //strSql.Append(" ( ");
                //strSql.Append(" " + Modelname + " ");
                //strSql.Append(" ) VALUES ");
                //strSql.Append(" ( ");
                //strSql.Append(" " + Modelvalue + " ");
                //strSql.Append(" ) ");
                int istrue = Repository().Insert(model);
                //int istrue = Repository().ExecuteBySql(strSql);
                if (istrue > 0)
                {
                    isok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isok;
        }

        #region 代理SQL
        /// <summary>
        /// 获取代理下用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getAgentUserPageList(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* ,case a.Enabled   when '0' then '停用' when '1' then '启用'  else '未知' end as 'StateName'  ");
            strSql.Append(" from base_user a ");
            strSql.Append(" where  1=1  ");
            strSql.Append(string.Format(" and a.DeleteMark = 0 "));
            if (!string.IsNullOrEmpty(model.CreateUserId))
            {
                strSql.Append(string.Format(" and a.CreateUserId = '{0}' ", model.CreateUserId));
            }
            if (!string.IsNullOrEmpty(model.RealName))
            {
                strSql.Append(string.Format(" and (a.RealName like '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Account like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Mobile like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Remark like  '%{0}%' )", model.RealName));
            }
            if (!string.IsNullOrEmpty(model.Selectval))
            {
                strSql.Append(string.Format(" {0} ", model.Selectval));
            }

            if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件（排序后生成的排序）
            {
                strSql.Append(string.Format("  {0} ", model.OrderStr));
            }

            strSql.Append(" )  a  ");

            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 代理获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetAgentUserCount(base_user model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.* ,case a.Enabled   when '0' then '停用' when '1' then '启用'  else '未知' end as 'StateName'  ");
                strSql.Append(" from base_user a ");
                strSql.Append(" where  1=1  ");
                strSql.Append(string.Format(" and a.DeleteMark = 0 "));
                if (!string.IsNullOrEmpty(model.CreateUserId))
                {
                    strSql.Append(string.Format(" and a.CreateUserId = '{0}' ", model.CreateUserId));
                }
                if (!string.IsNullOrEmpty(model.RealName))
                {
                    strSql.Append(string.Format(" and (a.RealName like '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Account like  '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Mobile like  '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Remark like  '%{0}%' )", model.RealName));
                }
                if (!string.IsNullOrEmpty(model.Selectval))
                {
                    strSql.Append(string.Format(" {0} ", model.Selectval));
                }

                if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件（排序后生成的排序）
                {
                    strSql.Append(string.Format("  {0} ", model.OrderStr));
                }
                strSql.Append(" )  a ; ");
                DataTable dt = Repository().FindTableBySql(strSql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    TotalItems = Convert.ToInt32(dt.Rows[0]["TotalItems"]);
                }
            }
            catch (Exception ex)
            {

            }
            return TotalItems;

        }
        #endregion


        #region 动软生成代码

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* ,case a.Enabled   when '0' then '停用' when '1' then '启用'  else '未知' end as 'StateName'  ");
            strSql.Append(" from base_user a ");
            strSql.Append(" where  1=1  ");
            strSql.Append(string.Format(" and a.DeleteMark = 0 "));
            if (!string.IsNullOrEmpty(model.CreateUserId))
            {
                strSql.Append(string.Format(" and a.CreateUserId = '{0}' ", model.CreateUserId));
            }
            if (!string.IsNullOrEmpty(model.Selectval))
            {
                strSql.Append(string.Format(" {0} ", model.Selectval));
            }

            if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件（排序后生成的排序）
            {
                strSql.Append(string.Format("  {0} ", model.OrderStr));
            }
            strSql.Append(" )  a  ");
            if (!string.IsNullOrEmpty(model.RealName))
            {
                strSql.Append(string.Format(" where a.RealName like '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Account like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Mobile like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Remark like  '%{0}%' ", model.RealName));
            }
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(base_user model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.* ,case a.Enabled   when '0' then '停用' when '1' then '启用'  else '未知' end as 'StateName'  ");
                strSql.Append(" from base_user a ");
                strSql.Append(" where  1=1  ");
                strSql.Append(string.Format(" and a.DeleteMark = 0 "));
                if (!string.IsNullOrEmpty(model.CreateUserId))
                {
                    strSql.Append(string.Format(" and a.CreateUserId = '{0}' ", model.CreateUserId));
                }
                if (!string.IsNullOrEmpty(model.RealName))
                {
                    strSql.Append(string.Format(" and a.RealName like '%{0}%' ", model.RealName));
                }
                if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件（排序后生成的排序）
                {
                    strSql.Append(string.Format("  {0} ", model.OrderStr));
                }
                strSql.Append(" )  a ; ");
                DataTable dt = Repository().FindTableBySql(strSql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    TotalItems = Convert.ToInt32(dt.Rows[0]["TotalItems"]);
                }
            }
            catch (Exception ex)
            {

            }
            return TotalItems;

        }

        //list列表
        public IList<base_user> getbase_userList(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM base_user  a  WHERE 1=1");
            strSql.Append(string.Format(" and a.DeleteMark = 0 "));
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" AND a.UserId = '{0}' ", model.UserId));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(base_user model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `base_user` ");
                strSql.Append(" ( ");
                strSql.Append(" `UserId`, ");
                strSql.Append(" `CompanyId`, ");
                strSql.Append(" `DepartmentId`, ");
                strSql.Append(" `InnerUser`, ");
                strSql.Append(" `Code`, ");
                strSql.Append(" `Account`, ");
                strSql.Append(" `Password`, ");
                strSql.Append(" `Secretkey`, ");
                strSql.Append(" `RealName`, ");
                strSql.Append(" `Spell`, ");
                strSql.Append(" `Gender`, ");
                strSql.Append(" `Birthday`, ");
                strSql.Append(" `Mobile`, ");
                strSql.Append(" `Telephone`, ");
                strSql.Append(" `OICQ`, ");
                strSql.Append(" `Email`, ");
                strSql.Append(" `ChangePasswordDate`, ");
                strSql.Append(" `OpenId`, ");
                strSql.Append(" `LogOnCount`, ");
                strSql.Append(" `FirstVisit`, ");
                strSql.Append(" `PreviousVisit`, ");
                strSql.Append(" `LastVisit`, ");
                strSql.Append(" `AuditStatus`, ");
                strSql.Append(" `AuditUserId`, ");
                strSql.Append(" `AuditUserName`, ");
                strSql.Append(" `AuditDateTime`, ");
                strSql.Append(" `Online`, ");
                strSql.Append(" `Remark`, ");
                strSql.Append(" `Enabled`, ");
                strSql.Append(" `SortCode`, ");
                strSql.Append(" `DeleteMark`, ");
                strSql.Append(" `CreateDate`, ");
                strSql.Append(" `CreateUserId`, ");
                strSql.Append(" `CreateUserName`, ");
                strSql.Append(" `ModifyDate`, ");
                strSql.Append(" `ModifyUserId`, ");
                strSql.Append(" `ModifyUserName`, ");
                strSql.Append(" `RoleId`, ");
                strSql.Append(" `Url`, ");
                strSql.Append(" `FingerData`, ");
                strSql.Append(" `RoadShowId`, ");
                strSql.Append(" `RoadShowGroupId`, ");
                strSql.Append(" `ProjectId`, ");
                strSql.Append(" `CardNum`, ");
                strSql.Append(" `Facevalue`, ");
                strSql.Append(" `IsAgent`, ");
                strSql.Append(" `IsDomestic` ");

                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.UserId));
                strSql.Append(string.Format(" '{0}', ", model.CompanyId));
                strSql.Append(string.Format(" '{0}', ", model.DepartmentId));
                strSql.Append(string.Format(" '{0}', ", model.InnerUser));
                strSql.Append(string.Format(" '{0}', ", model.Code));
                strSql.Append(string.Format(" '{0}', ", model.Account));
                strSql.Append(string.Format(" '{0}', ", model.Password));
                strSql.Append(string.Format(" '{0}', ", model.Secretkey));
                strSql.Append(string.Format(" '{0}', ", model.RealName));
                strSql.Append(string.Format(" '{0}', ", model.Spell));
                strSql.Append(string.Format(" '{0}', ", model.Gender));
                strSql.Append(string.Format(" '{0}', ", model.Birthday));
                strSql.Append(string.Format(" '{0}', ", model.Mobile));
                strSql.Append(string.Format(" '{0}', ", model.Telephone));
                strSql.Append(string.Format(" '{0}', ", model.OICQ));
                strSql.Append(string.Format(" '{0}', ", model.Email));
                strSql.Append(string.Format(" '{0}', ", model.ChangePasswordDate));
                strSql.Append(string.Format(" '{0}', ", model.OpenId));
                strSql.Append(string.Format(" '{0}', ", model.LogOnCount));
                strSql.Append(string.Format(" '{0}', ", model.FirstVisit));
                strSql.Append(string.Format(" '{0}', ", model.PreviousVisit));
                strSql.Append(string.Format(" '{0}', ", model.LastVisit));
                strSql.Append(string.Format(" '{0}', ", model.AuditStatus));
                strSql.Append(string.Format(" '{0}', ", model.AuditUserId));
                strSql.Append(string.Format(" '{0}', ", model.AuditUserName));
                strSql.Append(string.Format(" '{0}', ", model.AuditDateTime));
                strSql.Append(string.Format(" '{0}', ", model.Online));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.Enabled));
                strSql.Append(string.Format(" '{0}', ", model.SortCode));
                strSql.Append(string.Format(" '{0}', ", model.DeleteMark));
                strSql.Append(string.Format(" '{0}', ", model.CreateDate));
                strSql.Append(string.Format(" '{0}', ", model.CreateUserId));
                strSql.Append(string.Format(" '{0}', ", model.CreateUserName));
                strSql.Append(string.Format(" '{0}', ", model.ModifyDate));
                strSql.Append(string.Format(" '{0}', ", model.ModifyUserId));
                strSql.Append(string.Format(" '{0}', ", model.ModifyUserName));
                strSql.Append(string.Format(" '{0}', ", model.RoleId));
                strSql.Append(string.Format(" '{0}', ", model.Url));
                strSql.Append(string.Format(" '{0}', ", model.FingerData));
                strSql.Append(string.Format(" '{0}', ", model.RoadShowId));
                strSql.Append(string.Format(" '{0}', ", model.RoadShowGroupId));
                strSql.Append(string.Format(" '{0}', ", model.ProjectId));
                strSql.Append(string.Format(" '{0}', ", model.CardNum));
                strSql.Append(string.Format(" '{0}', ", model.Facevalue));
                strSql.Append(string.Format(" '{0}', ", model.IsAgent));
                strSql.Append(string.Format(" '{0}' ", model.IsDomestic));

                strSql.Append("   );  ");
            }
            i = Repository().InsertBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                //添加角色数据ConfigHelper.AppSettings("CustomerRoleId");
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append(" INSERT INTO `base_userrole` ");
                strSql2.Append(" ( ");
                strSql2.Append(" `Id`, ");
                strSql2.Append(" `UserId`, ");
                strSql2.Append(" `RoleId` ");
                strSql2.Append("  ) ");
                strSql2.Append(" VALUES  ");
                strSql2.Append(" (  ");
                strSql2.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                strSql2.Append(string.Format(" '{0}', ", model.UserId));
                if (model.IsAgent != null)
                {
                    switch (model.IsAgent)
                    {
                        case 0:
                            strSql2.Append(string.Format(" '{0}' ", ConfigHelper.AppSettings("RoleIdByAgent").ToString()));//代理角色
                            break;
                        case 1:
                            strSql2.Append(string.Format(" '{0}' ", ConfigHelper.AppSettings("CustomerRoleId").ToString()));//客户角色
                            break;
                    }
                }

                strSql2.Append("   );  ");
                int num = Repository().InsertBySql(strSql2.ToString(), null);
                if (num > 0)
                {
                    isok = true;
                }
                // database.Commit();
            }
            else
            {
                // database.Rollback();
            }
            return isok;
        }


        /// <summary>
        ///  更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(base_user model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update base_user  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" CompanyId = '{0}', ", model.CompanyId));
                strSql.Append(string.Format(" DepartmentId = '{0}', ", model.DepartmentId));
                strSql.Append(string.Format(" InnerUser = '{0}', ", model.InnerUser));
                strSql.Append(string.Format(" Code = '{0}', ", model.Code));
                strSql.Append(string.Format(" Account = '{0}', ", model.Account));
                strSql.Append(string.Format(" Password = '{0}', ", model.Password));
                strSql.Append(string.Format(" Secretkey = '{0}', ", model.Secretkey));
                strSql.Append(string.Format(" RealName = '{0}', ", model.RealName));
                strSql.Append(string.Format(" Spell = '{0}', ", model.Spell));
                strSql.Append(string.Format(" Gender = '{0}', ", model.Gender));
                strSql.Append(string.Format(" Birthday = '{0}', ", model.Birthday));
                strSql.Append(string.Format(" Mobile = '{0}', ", model.Mobile));
                strSql.Append(string.Format(" Telephone = '{0}', ", model.Telephone));
                strSql.Append(string.Format(" OICQ = '{0}', ", model.OICQ));
                strSql.Append(string.Format(" Email = '{0}', ", model.Email));
                strSql.Append(string.Format(" ChangePasswordDate = '{0}', ", model.ChangePasswordDate));
                strSql.Append(string.Format(" OpenId = '{0}', ", model.OpenId));
                strSql.Append(string.Format(" LogOnCount = '{0}', ", model.LogOnCount));
                strSql.Append(string.Format(" FirstVisit = '{0}', ", model.FirstVisit));
                strSql.Append(string.Format(" PreviousVisit = '{0}', ", model.PreviousVisit));
                strSql.Append(string.Format(" LastVisit = '{0}', ", model.LastVisit));
                strSql.Append(string.Format(" AuditStatus = '{0}', ", model.AuditStatus));
                strSql.Append(string.Format(" AuditUserId = '{0}', ", model.AuditUserId));
                strSql.Append(string.Format(" AuditUserName = '{0}', ", model.AuditUserName));
                strSql.Append(string.Format(" AuditDateTime = '{0}', ", model.AuditDateTime));
                strSql.Append(string.Format(" `Online` = '{0}', ", model.Online));
                strSql.Append(string.Format(" Remark = '{0}', ", model.Remark));
                strSql.Append(string.Format(" Enabled = '{0}', ", model.Enabled));
                strSql.Append(string.Format(" SortCode = '{0}', ", model.SortCode));
                strSql.Append(string.Format(" DeleteMark = '{0}', ", model.DeleteMark));
                strSql.Append(string.Format(" CreateDate = '{0}', ", model.CreateDate));
                strSql.Append(string.Format(" CreateUserId = '{0}', ", model.CreateUserId));
                strSql.Append(string.Format(" CreateUserName = '{0}', ", model.CreateUserName));
                strSql.Append(string.Format(" ModifyDate = '{0}', ", model.ModifyDate));
                strSql.Append(string.Format(" ModifyUserId = '{0}', ", model.ModifyUserId));
                strSql.Append(string.Format(" ModifyUserName = '{0}', ", model.ModifyUserName));
                strSql.Append(string.Format(" RoleId = '{0}', ", model.RoleId));
                strSql.Append(string.Format(" Url = '{0}', ", model.Url));
                strSql.Append(string.Format(" FingerData = '{0}', ", model.FingerData));
                strSql.Append(string.Format(" RoadShowId = '{0}', ", model.RoadShowId));
                strSql.Append(string.Format(" RoadShowGroupId = '{0}', ", model.RoadShowGroupId));
                strSql.Append(string.Format(" ProjectId = '{0}', ", model.ProjectId));
                strSql.Append(string.Format(" CardNum = '{0}', ", model.CardNum));
                strSql.Append(string.Format(" Facevalue = '{0}', ", model.Facevalue));
                strSql.Append(string.Format(" IsAgent = '{0}', ", model.IsAgent));
                strSql.Append(string.Format(" IsDomestic = '{0}' ", model.IsDomestic));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" UserId = '{0}' ", model.UserId));
            }
            i = Repository().UpdateBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                //database.Commit();
            }
            else
            {
                // database.Rollback();
            }
            return isok;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string DicsId)
        {
            //带事务的增加(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            //  IDatabase database = DataFactory.Database();
            //  DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update base_user  ");
            strSql.Append(" SET  ");
            strSql.Append(string.Format(" DeleteMark = 1 "));
            strSql.Append(" where ");
            strSql.Append(string.Format(" UserId in ( {0} ) ", DicsId));
            i = Repository().DeleteBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                // database.Commit();
            }
            else
            {
                // database.Rollback();
            }
            return isok;
        }


        #endregion


        #region CRM/技术支持 按部门获取人员

        /// <summary>
        /// CRM/技术支持 按部门获取人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getCRMUserPageList(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as rolesname,c.RoleId as userrole ");
            strSql.Append(" from base_user a ");
            strSql.Append(" left join base_userrole b on a.UserId=b.UserId ");
            strSql.Append(" left join base_roles c on b.RoleId=c.RoleId ");
            strSql.Append(" where  1=1  ");
            strSql.Append(string.Format(" and a.DeleteMark = 0 "));
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" and a.DepartmentId = '{0}' ", model.DepartmentId));
            }
            if (!string.IsNullOrEmpty(model.RealName))
            {
                strSql.Append(string.Format(" and a.RealName like '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Account like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Mobile like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Remark like  '%{0}%' ", model.RealName));
            }
            if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件（排序后生成的排序）
            {
                strSql.Append(string.Format("  {0} ", model.OrderStr));
            }
            strSql.Append(" )  a  ");


            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// CRM/技术支持 按部门获取人员获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetCRMUserCount(base_user model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*,c.FullName as rolesname,c.RoleId  as userrole ");
                strSql.Append(" from base_user a ");
                strSql.Append(" left join base_userrole b on a.UserId=b.UserId ");
                strSql.Append(" left join base_roles c on b.RoleId=c.RoleId ");
                strSql.Append(" where  1=1  ");
                strSql.Append(string.Format(" and a.DeleteMark = 0 "));
                if (!string.IsNullOrEmpty(model.DepartmentId))
                {
                    strSql.Append(string.Format(" and a.DepartmentId = '{0}' ", model.DepartmentId));
                }
                if (!string.IsNullOrEmpty(model.RealName))
                {
                    strSql.Append(string.Format(" and a.RealName like '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Account like  '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Mobile like  '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.RealName));
                    strSql.Append(string.Format(" or a.Remark like  '%{0}%' ", model.RealName));
                }
                if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件（排序后生成的排序）
                {
                    strSql.Append(string.Format("  {0} ", model.OrderStr));
                }
                strSql.Append(" )  a ; ");
                DataTable dt = Repository().FindTableBySql(strSql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    TotalItems = Convert.ToInt32(dt.Rows[0]["TotalItems"]);
                }
            }
            catch (Exception ex)
            {

            }
            return TotalItems;

        }


        #endregion




        #region 查看部门下的人员（好多部门ID）


        public DataTable getMyDepartmentUserPageList(base_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as rolesname,c.RoleId as userrole ");
            strSql.Append(" from base_user a ");
            strSql.Append(" left join base_userrole b on a.UserId=b.UserId ");
            strSql.Append(" left join base_roles c on b.RoleId=c.RoleId ");
            strSql.Append(" where  1=1  ");
            strSql.Append(string.Format(" and a.DeleteMark = 0 "));
            if (!string.IsNullOrEmpty(model.DepartmentId))
            {
                strSql.Append(string.Format(" and a.DepartmentId in ({0}) ", model.DepartmentId));
            }
            if (!string.IsNullOrEmpty(model.RealName))
            {
                strSql.Append(string.Format(" and a.RealName like '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Account like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Mobile like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.RealName));
                strSql.Append(string.Format(" or a.Remark like  '%{0}%' ", model.RealName));
            }




            strSql.Append(" )  a  ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        #endregion


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateUserinfoUrl(base_user model)
        {
            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model.UserId != null && model.UserId != "")
            {
                strSql.Append(string.Format(" update base_user set Url='{0}' where  userid='{1}'", model.Url, model.UserId));
            }
            i = Repository().UpdateBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                //database.Commit();
            }
            else
            {
                // database.Rollback();
            }
            return isok;


        }



    }
}
