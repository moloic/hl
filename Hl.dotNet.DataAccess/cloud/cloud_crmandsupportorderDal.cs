
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
    public class cloud_crmandsupportorderDal : RepositoryFactory<cloud_crmandsupportorder>
    {

        /// <summary>
        /// 获取在线的CRM/技术支持信息和未做的工单数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getCRMInfoList(cloud_crmandsupportorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,d.ordernumber  from base_user a      ");
            strSql.Append(" left join base_userrole c on a.userid=c.userid   ");
            strSql.Append(" left join (select b.userid,count(*) as ordernumber from cloud_crmandsupportorder b    ");
            strSql.Append(" where b.userid in (select userid from base_userrole  ");
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" where roleid = '{0}' ", model.UserId));
            }
            strSql.Append(string.Format(" AND b.State = 0) "));
            strSql.Append(" group by b.userid) d on a.userid=d.userid   ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" AND c.roleid = '{0}' ", model.UserId));
            }
            strSql.Append(string.Format(" AND a.IsWork = 0 "));

            strSql.Append(" ) a ");

            return Repository().FindTableBySql(strSql.ToString());
        }



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_crmandsupportorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.RealName as CJRealName,b.Mobile as CJMobile, b.Email as CJEmail from  ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.FullName as TypeName,d.Name as EquipmentName,    ");
            strSql.Append(" d.OrderNumber as EquipmentNumber,e.name as Modelname, f.RealName as KHRealName,f.Mobile as KHMobile, f.Email as KHEmail,f.CreateUserId,b.ID as CRMordId  ");
            strSql.Append(" from cloud_repairorder a    ");
            strSql.Append(" left join cloud_crmandsupportorder b on a.Id=b.OrderId  ");
            strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
            strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
            strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
            strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
            strSql.Append(" where 1=1 ");

            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" AND b.UserId = '{0}' ", model.UserId));
            }
            if (!string.IsNullOrEmpty(model.OrderId))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.OrderId));
            }
            strSql.Append(string.Format(" AND b.state=0 "));
            if (!string.IsNullOrEmpty(model.Selectval))
            {

                strSql.Append(string.Format(" and d.Name like '%{0}%' ", model.Selectval));
                strSql.Append(string.Format(" or e.name like  '%{0}%' ", model.Selectval));
                strSql.Append(string.Format(" or a.ordernumber like  '%{0}%' ", model.Selectval));
                //strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.Selectval));
                //strSql.Append(string.Format(" or a.Remark like  '%{0}%' ", model.Selectval));

            }
            strSql.Append(" ) a ");
            strSql.Append(" left join base_user b on a.CreateUserId=b.UserId ");
            strSql.Append(" order by a.SubmitTime ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }
        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_crmandsupportorder model)
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
                strSql.Append(" left join cloud_crmandsupportorder b on a.Id=b.OrderId  ");
                strSql.Append(" left join base_dics c on a.OrderType=c.DicsId ");
                strSql.Append(" left join cloud_equipment d on a.EquipmentId=d.EquipmentId ");
                strSql.Append(" left join cloud_equipmentmodel e on d.Model=e.Id");
                strSql.Append(" left join base_user f on  a.SubmitPeople=f.UserId ");
                strSql.Append(" where 1=1 ");

                if (!string.IsNullOrEmpty(model.UserId))
                {
                    strSql.Append(string.Format(" AND b.UserId = '{0}' ", model.UserId));
                }
                strSql.Append(string.Format(" AND b.state=0 "));
                if (!string.IsNullOrEmpty(model.Selectval))
                {

                    strSql.Append(string.Format(" and d.Name like '%{0}%' ", model.Selectval));
                    strSql.Append(string.Format(" or e.name like  '%{0}%' ", model.Selectval));
                    strSql.Append(string.Format(" or a.ordernumber like  '%{0}%' ", model.Selectval));
                    //strSql.Append(string.Format(" or a.Email like  '%{0}%' ", model.Selectval));
                    //strSql.Append(string.Format(" or a.Remark like  '%{0}%' ", model.Selectval));

                }
                strSql.Append(" ) a ");
                strSql.Append(" left join base_user b on a.CreateUserId=b.UserId ");
                strSql.Append(" order by a.SubmitTime ");
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
        public IList<cloud_crmandsupportorder> getcloud_crmandsupportorderList(cloud_crmandsupportorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_crmandsupportorder  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }

            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_crmandsupportorder model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                if (model.orderidlist != null && model.orderidlist.Count > 0)
                {
                    for (int j = 0; j < model.orderidlist.Count; j++)
                    {
                        strSql.Append(" INSERT INTO `cloud_crmandsupportorder` ");
                        strSql.Append(" ( ");
                        strSql.Append(" `Id`, ");
                        strSql.Append(" `UserId`, ");
                        strSql.Append(" `OrderId`, ");
                        strSql.Append(" `State`, ");
                        strSql.Append(" `CreateDate` ");
                        strSql.Append("  ) ");
                        strSql.Append(" VALUES  ");
                        strSql.Append(" (  ");
                        strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                        strSql.Append(string.Format(" '{0}', ", model.UserId));
                        strSql.Append(string.Format(" '{0}', ", model.orderidlist[j].ToString()));
                        strSql.Append(string.Format(" {0}, ", 0));
                        strSql.Append(string.Format(" '{0}' ", DateTime.Now));
                        strSql.Append("   );  ");
                    }
                    strSql.Append(" update cloud_repairorder  ");
                    strSql.Append(" SET  ");
                    strSql.Append(string.Format(" IsReceive = 0 "));
                    strSql.Append(" where  ");
                    strSql.Append(string.Format(" Id in ({0}) ;", model.OrderStr));
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
        public bool Update(cloud_crmandsupportorder model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_crmandsupportorder  ");
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


        public bool ManUpdateorder(cloud_crmandsupportorder model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_crmandsupportorder  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" State = 0 "));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" OrderId = '{0}' ", model.OrderId));
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
            strSql.Append("  delete from cloud_crmandsupportorder ");
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




        /// <summary>
        /// 计算历史月份
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getmonthsList(cloud_crmandsupportorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" DATE_FORMAT(CreateDate,'%Y-%m') months,");
            strSql.Append(" count(id) count ");
            strSql.Append(" from cloud_crmandsupportorder");
            strSql.Append(string.Format(" where userid ='{0}'", model.UserId));
            strSql.Append(" group by months;");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取昨日统计数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getYearDaysList(cloud_crmandsupportorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" COUNT(case when info.State = '0' then State end  ) as daichuliCount,");
            strSql.Append(" COUNT(case when info.State = '1' then State end ) as yichuliCount,");
            strSql.Append(" COUNT(case when info.State IN('0','1') then State end) as allCount");
            strSql.Append(" from  cloud_crmandsupportorder as info ");
            strSql.Append(" where 1=1 ");
            strSql.Append(" and DATEDIFF(info.CreateDate,NOW())=-1 ");
            strSql.Append(string.Format(" and info.UserId='{0}'", model.UserId));
            strSql.Append(";");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 按日统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getdaysList(cloud_crmandsupportorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" DATE_FORMAT(CreateDate,'%Y-%m-%d') days,");
            strSql.Append(" count(id) count ");
            strSql.Append(" from cloud_crmandsupportorder");
            strSql.Append(string.Format(" where userid ='{0}'", model.UserId));
            strSql.Append(" group by days;");
            return Repository().FindTableBySql(strSql.ToString());
        }
        



    }

}