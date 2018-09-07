
using Hl.dotNet.Models;
using Hl.dotNet.Orm;
using Hl.dotNet.Repository;
using Hl.dotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.DataAccess
{
    public class cloud_repairorderDal : RepositoryFactory<cloud_repairorder>
    {






        #region 代理查询工单列表
        /// <summary>
        /// 代理查询工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable DLGetUserOrderList(cloud_repairorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
            strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId  ");
            strSql.Append(" from cloud_repairorder a    ");
            strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
            strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
            strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
            strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(model.UserId))//用户ID
            {
                strSql.Append(" AND  a.SubmitPeople in ( ");
                strSql.Append(" select UserId from base_user a ");
                strSql.Append(string.Format(" where a.CreateUserId in ({0}) ", model.UserId));
                strSql.Append(" )");
            }
            if (!string.IsNullOrEmpty(model.Id))//查询详情 工单ID
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            //strSql.Append(string.Format(" AND b.State = 0 "));

            if (!string.IsNullOrEmpty(model.Selectval))
            {

                strSql.Append(string.Format(" and d.Name like '%{0}%' ", model.Selectval));
                strSql.Append(string.Format(" or e.name like  '%{0}%' ", model.Selectval));
                strSql.Append(string.Format(" or a.ordernumber like  '%{0}%' ", model.Selectval));
            }
            strSql.Append(" ) a ");
            strSql.Append(" left join base_user b on a.CreateUserId=b.UserId ");
            if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件
            {
                strSql.Append(string.Format(" where {0} ", model.OrderStr));
            }
            if (!string.IsNullOrEmpty(model.StateName))//自定义查询条件
            {
                strSql.Append(string.Format("  {0} ", model.StateName));
            }


            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        public int DLGetUserOrderCount(cloud_repairorder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
                strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId  ");
                strSql.Append(" from cloud_repairorder a    ");
                strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
                strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
                strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
                strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
                strSql.Append(" where 1=1 ");
                if (!string.IsNullOrEmpty(model.UserId))//用户ID
                {
                    strSql.Append(" AND  a.SubmitPeople in ( ");
                    strSql.Append(" select UserId from base_user a ");
                    strSql.Append(string.Format(" where a.CreateUserId in ({0}) ", model.UserId));
                    strSql.Append(" )");
                }
                if (!string.IsNullOrEmpty(model.Id))//查询详情 工单ID
                {
                    strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
                }
                //strSql.Append(string.Format(" AND b.State = 0 "));

                if (!string.IsNullOrEmpty(model.Selectval))
                {

                    strSql.Append(string.Format(" and d.Name like '%{0}%' ", model.Selectval));
                    strSql.Append(string.Format(" or e.name like  '%{0}%' ", model.Selectval));
                    strSql.Append(string.Format(" or a.ordernumber like  '%{0}%' ", model.Selectval));
                }
                strSql.Append(" ) a ");
                strSql.Append(" left join base_user b on a.CreateUserId=b.UserId ");
                if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件
                {
                    strSql.Append(string.Format(" where {0} ", model.OrderStr));
                }
                if (!string.IsNullOrEmpty(model.StateName))//自定义查询条件
                {
                    strSql.Append(string.Format("  {0} ", model.StateName));
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

        #region 上传订单

        public bool DLUpdate(cloud_repairorder model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_repairorder  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" OrderClassify = {0} ", 1));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" Id = '{0}' ", model.Id));
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

        #region 用户查询工单信息
        /// <summary>
        /// 用户查询工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetUserOrderList(cloud_repairorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
            strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId  ");
            strSql.Append(" from cloud_repairorder a    ");
            strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
            strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
            strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
            strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(model.UserId))//用户ID
            {
                strSql.Append(string.Format(" AND  a.SubmitPeople in ({0}) ", model.UserId));
            }
            if (!string.IsNullOrEmpty(model.Id))//查询详情 工单ID
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            //strSql.Append(string.Format(" AND b.State = 0 "));

            if (!string.IsNullOrEmpty(model.Selectval))
            {

                strSql.Append(string.Format(" and d.Name like '%{0}%' ", model.Selectval));
                strSql.Append(string.Format(" or e.name like  '%{0}%' ", model.Selectval));
                strSql.Append(string.Format(" or a.ordernumber like  '%{0}%' ", model.Selectval));
            }
            strSql.Append(" ) a ");
            strSql.Append(" left join base_user b on a.CreateUserId=b.UserId ");
            if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件
            {
                strSql.Append(string.Format(" where {0} ", model.OrderStr));
            }
            if (!string.IsNullOrEmpty(model.StateName))//自定义查询条件
            {
                strSql.Append(string.Format("  {0} ", model.StateName));
            }


            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 用户查询工单信息条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetUserOrderCount(cloud_repairorder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
                strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId  ");
                strSql.Append(" from cloud_repairorder a    ");
                strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
                strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
                strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
                strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
                strSql.Append(" where 1=1 ");
                if (!string.IsNullOrEmpty(model.UserId))//用户ID
                {
                    strSql.Append(string.Format(" AND  a.SubmitPeople in ({0}) ", model.UserId));
                }
                if (!string.IsNullOrEmpty(model.Id))//查询详情 工单ID
                {
                    strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
                }
                //strSql.Append(string.Format(" AND b.State = 0 "));

                if (!string.IsNullOrEmpty(model.Selectval))
                {

                    strSql.Append(string.Format(" and d.Name like '%{0}%' ", model.Selectval));
                    strSql.Append(string.Format(" or e.name like  '%{0}%' ", model.Selectval));
                    strSql.Append(string.Format(" or a.ordernumber like  '%{0}%' ", model.Selectval));
                }
                strSql.Append(" ) a ");
                strSql.Append(" left join base_user b on a.CreateUserId=b.UserId ");
                if (!string.IsNullOrEmpty(model.OrderStr))//自定义查询条件
                {
                    strSql.Append(string.Format(" where {0} ", model.OrderStr));
                }
                if (!string.IsNullOrEmpty(model.StateName))//自定义查询条件
                {
                    strSql.Append(string.Format("  {0} ", model.StateName));
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




        #region 管理者界面订单管理
        /// <summary>
        /// 管理界面返回订单详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserlistorder(cloud_repairorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName from  ");
            strSql.Append(" ( ");
            strSql.Append(" select  a.Id as OrderId,a.OrderNumber,a.OrderType, d.FullName as TypeName,a.ProblemDescribe as OrderDescribe,a.EquipmentId, ");
            strSql.Append(" c.Name as EquipmentName, c.OrderNumber as EquipmentNumber,c.Model as EquipmentModel, a.SubmitPeople, a.SubmitTime, a.HandleUser,");
            strSql.Append(" a.State as OrderState, a.HandleOpinion, a.HandleFeedback, a.Handledifficulty, a.HandleEvaluate, a.IsEvaluate, b.RealName as KHRealName,b.Mobile, b.Email, b.CreateUserId , f.Name as ModelName  ");
            strSql.Append(" from cloud_repairorder a");
            strSql.Append(" left join base_user b on a.SubmitPeople = b.userid  ");
            strSql.Append(" left join cloud_equipment c on a.EquipmentId=c.EquipmentId ");
            strSql.Append(" left join base_dics d on a.OrderType=d.DicsId ");
            strSql.Append(" left join cloud_workpersonnel e on e.OrderId=a.Id ");
            strSql.Append(" left join cloud_equipmentmodel f on c.Model=f.Id ");
            strSql.Append(" where 1=1");
            if (!string.IsNullOrEmpty(model.SubmitPeople))
            {
                strSql.Append(" and a.SubmitPeople in  ");
                strSql.Append(" ( ");
                strSql.Append(" select UserId from base_user where CreateUserId in  ");
                strSql.Append(" ( ");
                strSql.Append(" select a.UserId from base_user a where 1=1  ");

                strSql.Append(string.Format(" and  a.DepartmentId = '{0}' ", model.SubmitPeople));
                strSql.Append(" ) ");
                strSql.Append(" ) ");
            }

            if (model.State != null)//订单状态
            {
                strSql.Append(string.Format(" AND a.State = {0} ", model.State));
            }
            if (!string.IsNullOrEmpty(model.Id))//订单ID
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            if (!string.IsNullOrEmpty(model.StateName))//提交人ID
            {
                strSql.Append(string.Format(" AND a.SubmitPeople = '{0}' ", model.StateName));
            }
            if (!string.IsNullOrEmpty(model.UserId))//维修人员ID
            {
                strSql.Append(string.Format(" AND e.UserId = '{0}' ", model.UserId));
            }

            strSql.Append(" ) a ");

            strSql.Append(" left join base_user b on a.CreateUserId=b.userId ");
            if (!string.IsNullOrEmpty(model.OrderStr))//查询条件
            {
                strSql.Append(string.Format(" where {0} ", model.OrderStr));
            }
            strSql.Append("  order by a.SubmitTime desc ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 管理界面返回订单详情条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetUserListCount(cloud_repairorder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append("select a.*,b.RealName as CJRealName from  ");
                strSql.Append(" ( ");
                strSql.Append(" select  a.Id as OrderId,a.OrderNumber,a.OrderType, d.FullName as TypeName,a.ProblemDescribe as OrderDescribe,a.EquipmentId, ");
                strSql.Append(" c.Name as EquipmentName, c.OrderNumber as EquipmentNumber,c.Model as EquipmentModel, a.SubmitPeople, a.SubmitTime, a.HandleUser,");
                strSql.Append(" a.State as OrderState, a.HandleOpinion, a.HandleFeedback, a.Handledifficulty, a.HandleEvaluate, a.IsEvaluate, b.RealName as KHRealName,b.Mobile, b.Email, b.CreateUserId , f.Name as ModelName  ");
                strSql.Append(" from cloud_repairorder a");
                strSql.Append(" left join base_user b on a.SubmitPeople = b.userid  ");
                strSql.Append(" left join cloud_equipment c on a.EquipmentId=c.EquipmentId ");
                strSql.Append(" left join base_dics d on a.OrderType=d.DicsId ");
                strSql.Append(" left join cloud_workpersonnel e on e.OrderId=a.Id ");
                strSql.Append(" left join cloud_equipmentmodel f on c.Model=f.Id ");
                strSql.Append(" where 1=1");
                if (!string.IsNullOrEmpty(model.SubmitPeople))
                {
                    strSql.Append(" and a.SubmitPeople in  ");
                    strSql.Append(" ( ");
                    strSql.Append(" select UserId from base_user where CreateUserId in  ");
                    strSql.Append(" ( ");
                    strSql.Append(" select a.UserId from base_user a where 1=1  ");

                    strSql.Append(string.Format(" and  a.DepartmentId = '{0}' ", model.SubmitPeople));
                    strSql.Append(" ) ");
                    strSql.Append(" ) ");
                }

                if (model.State != null)//订单状态
                {
                    strSql.Append(string.Format(" AND a.State = {0} ", model.State));
                }
                if (!string.IsNullOrEmpty(model.Id))//订单ID
                {
                    strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
                }
                if (!string.IsNullOrEmpty(model.StateName))//提交人ID
                {
                    strSql.Append(string.Format(" AND a.SubmitPeople = '{0}' ", model.StateName));
                }
                if (!string.IsNullOrEmpty(model.UserId))//维修人员ID
                {
                    strSql.Append(string.Format(" AND e.UserId = '{0}' ", model.UserId));
                }

                strSql.Append(" ) a ");

                strSql.Append(" left join base_user b on a.CreateUserId=b.userId ");
                if (!string.IsNullOrEmpty(model.OrderStr))//查询条件
                {
                    strSql.Append(string.Format(" where {0} ", model.OrderStr));
                }
                strSql.Append("  order by a.SubmitTime desc ");
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

        /// <summary>
        /// 返回客户端分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_repairorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.Id,a.OrderNumber,b.FullName as bName,c.Name as cName,a.SubmitTime,e.NodeName,g.RealName  ");
            strSql.Append(" from Cloud_repairorder a ");
            strSql.Append(" left join base_dics b on a.OrderType=b.DicsId   ");
            strSql.Append(" left join cloud_equipment c on a.EquipmentId=c.EquipmentId ");
            strSql.Append(" left join Cloud_ordernode d on a.Id=d.OrderId ");
            strSql.Append(" left join Cloud_node e on d.NodeId=e.Id ");
            strSql.Append(" left join cloud_workpersonnel f on a.Id=f.OrderId ");
            strSql.Append(" left join base_user g on f.UserId=g.UserId  ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.SubmitPeople))
            {
                strSql.Append(string.Format(" AND a.SubmitPeople = '{0}' ", model.SubmitPeople));
            }
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取客户端总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_repairorder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.Id,a.OrderNumber,b.FullName as bName,c.Name as cName,a.SubmitTime,e.NodeName,g.RealName  ");
                strSql.Append(" from Cloud_repairorder a ");
                strSql.Append(" left join base_dics b on a.OrderType=b.DicsId   ");
                strSql.Append(" left join cloud_equipment c on a.EquipmentId=c.EquipmentId ");
                strSql.Append(" left join Cloud_ordernode d on a.Id=d.OrderId ");
                strSql.Append(" left join Cloud_node e on d.NodeId=e.Id ");
                strSql.Append(" left join cloud_workpersonnel f on a.Id=f.OrderId ");
                strSql.Append(" left join base_user g on f.UserId=g.UserId  ");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.SubmitPeople))
                {
                    strSql.Append(string.Format(" AND a.SubmitPeople = '{0}' ", model.SubmitPeople));
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
        public IList<cloud_repairorder> getcloud_repairorderList(cloud_repairorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_repairorder  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }

            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_repairorder model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_repairorder` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `OrderNumber`, ");
                strSql.Append(" `OrderType`, ");
                strSql.Append(" `ProblemDescribe`, ");
                strSql.Append(" `EquipmentId`, ");
                strSql.Append(" `SubmitPeople`, ");
                strSql.Append(" `SubmitTime`, ");
                strSql.Append(" `HandleUser`, ");
                strSql.Append(" `State`, ");
                strSql.Append(" `HandleOpinion`, ");
                strSql.Append(" `HandleFeedback`, ");
                strSql.Append(" `Handledifficulty`, ");
                strSql.Append(" `HandleEvaluate`, ");
                strSql.Append(" `IsEvaluate`, ");
                strSql.Append(" `OrderClassify`, ");
                strSql.Append(" `IsReceive` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.OrderNumber));
                strSql.Append(string.Format(" '{0}', ", model.OrderType));
                strSql.Append(string.Format(" '{0}', ", model.ProblemDescribe));
                strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" '{0}', ", model.SubmitPeople));
                strSql.Append(string.Format(" '{0}', ", model.SubmitTime));
                strSql.Append(string.Format(" '{0}', ", model.HandleUser));
                strSql.Append(string.Format(" {0}, ", model.State));
                strSql.Append(string.Format(" '{0}', ", model.HandleOpinion));
                strSql.Append(string.Format(" '{0}', ", model.HandleFeedback));
                strSql.Append(string.Format(" '{0}', ", model.Handledifficulty));
                strSql.Append(string.Format(" '{0}', ", model.HandleEvaluate));
                strSql.Append(string.Format(" {0}, ", model.IsEvaluate));
                strSql.Append(string.Format(" {0}, ", model.OrderClassify));
                strSql.Append(string.Format(" {0} ", model.IsReceive));
                strSql.Append("   );  ");

                //添加订单节点（订单已提交）
                strSql.Append(" INSERT INTO `cloud_ordernode` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `OrderId`, ");
                strSql.Append(" `NodeId`, ");
                strSql.Append(" `CreateUser`, ");
                strSql.Append(" `CreateDate`, ");
                strSql.Append(" `Rmark` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", "e73e7f9d-38b1-4d23-a7d7-0774c9d8aa1e"));
                strSql.Append(string.Format(" '{0}', ", model.SubmitPeople));
                strSql.Append(string.Format(" '{0}', ", DateTime.Now));

                strSql.Append(string.Format(" '{0}' ", ""));
                strSql.Append("   );  ");
            }
            i = Repository().InsertBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                if (model.OrderStr != null && model.OrderStr != "")
                {
                    model.OrderStr = model.OrderStr.ToString().TrimEnd(',');
                    StringBuilder strfileSql = new StringBuilder();
                    strfileSql.Append(" update base_file ");
                    strfileSql.Append(" SET ");
                    strfileSql.Append(string.Format(" Pid = '{0}' ", model.Id));
                    strfileSql.Append(" where  ");
                    strfileSql.Append(string.Format(" Id in ({0}) ", model.OrderStr));
                    i = Repository().InsertBySql(strfileSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)

                }
                isok = true;
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
        public bool Update(cloud_repairorder model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_repairorder  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" OrderNumber = '{0}', ", model.OrderNumber));
                strSql.Append(string.Format(" OrderType = '{0}', ", model.OrderType));
                strSql.Append(string.Format(" ProblemDescribe = '{0}', ", model.ProblemDescribe));
                strSql.Append(string.Format(" EquipmentId = '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" SubmitPeople = '{0}', ", model.SubmitPeople));
                strSql.Append(string.Format(" SubmitTime = '{0}', ", model.SubmitTime));
                strSql.Append(string.Format(" HandleUser = '{0}', ", model.HandleUser));
                strSql.Append(string.Format(" State = {0}, ", model.State));
                strSql.Append(string.Format(" HandleOpinion = '{0}', ", model.HandleOpinion));
                strSql.Append(string.Format(" HandleFeedback = '{0}', ", model.HandleFeedback));
                strSql.Append(string.Format(" Handledifficulty = '{0}', ", model.Handledifficulty));
                strSql.Append(string.Format(" HandleEvaluate = '{0}', ", model.HandleEvaluate));
                strSql.Append(string.Format(" Level = {0}, ", model.Level));
                if (model.State == 3)
                {
                    strSql.Append(string.Format(" EndOrderTime = '{0}', ", model.EndOrderTime));
                }
                strSql.Append(string.Format(" IsEvaluate = {0} ", model.IsEvaluate));

                strSql.Append(" where  ");
                strSql.Append(string.Format(" Id = '{0}' ", model.Id));
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
            strSql.Append("  delete from cloud_repairorder ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" Id in ('{0}') ", DicsId));
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


        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Updateorderstate(cloud_repairorder model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_repairorder  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" State = {0} ", model.State));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" Id in ({0}) ;", model.Id));
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
        /// 获取工单数（首页功能）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getRepairorderCount(cloud_repairorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) as  repairordercount  from cloud_repairorder a ");
            strSql.Append(" where 1=1  ");
            strSql.Append(string.Format("and a.EquipmentId in (  select EquipmentId from cloud_equipment where Businesspeople='{0}' )", model.UserId));
            strSql.Append("and a.State != 5; ");
            return Repository().FindTableBySql(strSql.ToString());
        }




        #region CRM获取国外工单信息
        /// <summary>
        /// 获取国外未接收工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetCrmOrderList(cloud_repairorder model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            if (model.OrderClassify != null)
            {
                strSql.Append(" select *   ");
                strSql.Append(" from cloud_repairorder a ");
                strSql.Append(string.Format(" where a.OrderClassify = {0} ", model.OrderClassify));
                strSql.Append(string.Format(" and a.IsReceive = {0} ", model.IsReceive));
                strSql.Append(" order by a.SubmitTime ");
            }
            strSql.Append(" )  a  ");

            return Repository().FindTableBySql(strSql.ToString());

        }

        /// <summary>
        /// 获取国外未接收工单条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetCrmOrderListCount(cloud_repairorder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                if (model.OrderClassify != null)
                {
                    strSql.Append(" select *   ");
                    strSql.Append(" from cloud_repairorder a ");
                    strSql.Append(string.Format(" where a.OrderClassify = {0} ", model.OrderClassify));
                    strSql.Append(string.Format(" and a.IsReceive = {0} ", model.IsReceive));
                    strSql.Append(" order by a.SubmitTime ");
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


        /// <summary>
        /// 获取CRM角色用户条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetCrmUserListCount(cloud_repairorder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from base_user a  ");
                strSql.Append(" left join base_userrole b on a.UserId=b.UserId  ");
                strSql.Append(string.Format(" where b.RoleId = '{0}' ", model.OrderType));
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





    }

}