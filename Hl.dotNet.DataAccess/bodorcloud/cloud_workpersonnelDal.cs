
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
    public class cloud_workpersonnelDal : RepositoryFactory<cloud_workpersonnel>
    {



        public DataTable ZGGetDirectorOrderList(cloud_workpersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
            strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId,b.ID as CRMordId  ");
            strSql.Append(" from cloud_repairorder a    ");
            strSql.Append(" left join cloud_workpersonnel b on a.Id=b.OrderId  ");
            strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
            strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
            strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
            strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
            strSql.Append(" where 1=1 ");

            if (!string.IsNullOrEmpty(model.UserId))//用户ID
            {
                strSql.Append(string.Format(" AND b.UserId in ({0}) ", model.UserId));
            }
            if (!string.IsNullOrEmpty(model.deparId))//部门ID
            {
                strSql.Append(string.Format(" AND b.UserId in ( select UserId from base_user where DepartmentId = '{0}' ) ", model.deparId));
            }
            if (!string.IsNullOrEmpty(model.OrderId))//查询详情 工单ID
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.OrderId));
            }
            strSql.Append(string.Format(" AND b.State = 0 "));

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
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int ZGGetDirectorCount(cloud_workpersonnel model)
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
                strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId,b.ID as CRMordId  ");
                strSql.Append(" from cloud_repairorder a    ");
                strSql.Append(" left join cloud_workpersonnel b on a.Id=b.OrderId  ");
                strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
                strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
                strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
                strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
                strSql.Append(" where 1=1 ");

                if (!string.IsNullOrEmpty(model.UserId))//用户ID
                {
                    strSql.Append(string.Format(" AND b.UserId in ({0}) ", model.UserId));
                }
                if (!string.IsNullOrEmpty(model.deparId))//部门ID
                {
                    strSql.Append(string.Format(" AND b.UserId in ( select UserId from base_user where DepartmentId = '{0}' ) ", model.deparId));
                }
                if (!string.IsNullOrEmpty(model.OrderId))//查询详情 工单ID
                {
                    strSql.Append(string.Format(" AND a.Id = '{0}' ", model.OrderId));
                }
                strSql.Append(string.Format(" AND b.State = 0 "));

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




        #region 主管查询订单列表

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDirectorOrderList(cloud_workpersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
            strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId,b.ID as CRMordId  ");
            strSql.Append(" from cloud_repairorder a    ");
            strSql.Append(" left join cloud_workpersonnel b on a.Id=b.OrderId  ");
            strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
            strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
            strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
            strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
            strSql.Append(" where 1=1 ");

            if (!string.IsNullOrEmpty(model.UserId))//用户ID
            {
                strSql.Append(string.Format(" AND b.UserId in ({0}) ", model.UserId));
            }
            if (!string.IsNullOrEmpty(model.OrderId))//查询详情 工单ID
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.OrderId));
            }
            strSql.Append(string.Format(" AND b.State = 0 "));

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
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetDirectorCount(cloud_workpersonnel model)
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
                strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId,b.ID as CRMordId  ");
                strSql.Append(" from cloud_repairorder a    ");
                strSql.Append(" left join cloud_workpersonnel b on a.Id=b.OrderId  ");
                strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
                strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
                strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
                strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
                strSql.Append(" where 1=1 ");

                if (!string.IsNullOrEmpty(model.UserId))//用户ID
                {
                    strSql.Append(string.Format(" AND b.UserId in ({0}) ", model.UserId));
                }
                if (!string.IsNullOrEmpty(model.OrderId))//查询详情 工单ID
                {
                    strSql.Append(string.Format(" AND a.Id = '{0}' ", model.OrderId));
                }
                strSql.Append(string.Format(" AND b.State = 0 "));

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



        /// <summary>
        /// 查看订单详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDirectorOrderListInfo(cloud_workpersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
            strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId,b.ID as CRMordId  ");
            strSql.Append(" from cloud_repairorder a    ");
            strSql.Append(" left join cloud_workpersonnel b on a.Id=b.OrderId  ");
            strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
            strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
            strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
            strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
            strSql.Append(" where 1=1 ");

            if (!string.IsNullOrEmpty(model.UserId))//用户ID
            {
                strSql.Append(string.Format(" AND b.UserId in ({0}) ", model.UserId));
            }
            if (!string.IsNullOrEmpty(model.OrderId))//查询详情 工单ID
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.OrderId));
            }


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


            //strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }
        #endregion







        /// <summary>
        /// CRM分配订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CRMInsertwork(cloud_workpersonnel model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();


            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" INSERT INTO `cloud_workpersonnel` ");
            strSql.Append(" ( ");
            strSql.Append(" `Id`, ");
            strSql.Append(" `OrderId`, ");
            strSql.Append(" `UserId`, ");
            strSql.Append(" `CreateDate`, ");
            strSql.Append(" `State` ");
            strSql.Append("  ) ");
            strSql.Append(" VALUES  ");
            strSql.Append(" (  ");
            strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
            strSql.Append(string.Format(" '{0}', ", model.OrderId));
            strSql.Append(string.Format(" '{0}', ", model.UserId));
            strSql.Append(string.Format(" '{0}', ", model.CreateDate));
            strSql.Append(string.Format(" {0} ", model.State));
            strSql.Append("   );  ");

            i = Repository().InsertBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
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
        /// 查询部门人员列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getderuserList(cloud_workpersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,b.ordernum ");
            strSql.Append(" from base_user a ");
            strSql.Append(" left join (select a.*,count(b.Id) as ordernum from base_user a  ");
            strSql.Append(" left join cloud_workpersonnel b on a.UserId=b.UserId  left join cloud_repairorder c on b.OrderId=c.id  where c.State!=3 and c.State!=5 group by a.UserId ) b  ");
            strSql.Append(" on a.UserId=b.UserId");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.DepartmentId = '{0}' ", model.Id));
            }
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" AND a.RealName like '%{0}%' ", model.UserId));
            }
            strSql.Append(string.Format(" {0} ", model.OrderId));
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }
        /// <summary>
        /// 查询部门人员条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetderuserCount(cloud_workpersonnel model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*,b.ordernum ");
                strSql.Append(" from base_user a ");
                strSql.Append(" left join (select a.*,count(b.Id) as ordernum from base_user a  ");
                strSql.Append(" left join cloud_workpersonnel b on a.UserId=b.UserId  left join cloud_repairorder c on b.OrderId=c.id  where c.State!=3 and c.State!=5 group by a.UserId ) b  ");
                strSql.Append(" on a.UserId=b.UserId");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.Id))
                {
                    strSql.Append(string.Format(" AND a.DepartmentId = '{0}' ", model.Id));
                }
                if (!string.IsNullOrEmpty(model.UserId))
                {
                    strSql.Append(string.Format(" AND a.RealName = '{0}' ", model.UserId));
                }
                strSql.Append(string.Format(" {0} ", model.OrderId));
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


        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_workpersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*   ");
            strSql.Append(" from cloud_workpersonnel a ");
            strSql.Append(" where  1=1  ");
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_workpersonnel model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from cloud_workpersonnel a ");
                strSql.Append(" where  1=1  ");
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
        public IList<cloud_workpersonnel> getcloud_workpersonnelList(cloud_workpersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_workpersonnel  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }

            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_workpersonnel model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();


            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                string[] s = null;
                if (model.OrderId != null && model.OrderId != "")
                {
                    s = model.OrderId.Split(',');
                }

                for (int j = 0; j < s.Length; j++)
                {
                    strSql.Append(" INSERT INTO `cloud_workpersonnel` ");
                    strSql.Append(" ( ");
                    strSql.Append(" `Id`, ");
                    strSql.Append(" `OrderId`, ");
                    strSql.Append(" `UserId`, ");
                    strSql.Append(" `CreateDate` ");
                    strSql.Append("  ) ");
                    strSql.Append(" VALUES  ");
                    strSql.Append(" (  ");
                    strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                    strSql.Append(string.Format(" {0}, ", s[j]));
                    strSql.Append(string.Format(" '{0}', ", model.UserId));
                    strSql.Append(string.Format(" '{0}' ", model.CreateDate));

                    strSql.Append("   );  ");
                }


            }
            i = Repository().InsertBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
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
        ///  更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_workpersonnel model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_workpersonnel  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" State = {0} ", model.State));
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
            strSql.Append("  delete from cloud_workpersonnel ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" DicsId in ( {0} ) ", DicsId));
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



        #region 查询用户是否与此订单关联

        public int GetUserOrderCount(cloud_workpersonnel model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from cloud_workpersonnel a ");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.OrderId))//工单ID
                {
                    strSql.Append(string.Format(" AND a.OrderId = '{0}' ", model.OrderId));
                }
                if (!string.IsNullOrEmpty(model.UserId))//用户ID
                {
                    strSql.Append(string.Format(" AND a.UserId = '{0}' ", model.UserId));
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

        #region 售后回退工单更改工单信息

        public bool UpdateOrderState(cloud_workpersonnel model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_workpersonnel  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" State = {0} ", model.State));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" OrderId = '{0}' ", model.OrderId));
                strSql.Append(string.Format(" and UserId = '{0}' ", model.UserId));
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







    }

}