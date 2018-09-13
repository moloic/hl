
using Hl.dotNet.Models;
using Hl.dotNet.Orm;
using Hl.dotNet.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.DataAccess
{
    public class base_departmentDal : RepositoryFactory<base_department>
    {

        /// <summary>
        /// 获取人员本/上季度销售额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDeparpeopleOrderNum(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("select ifnull(count(*),0) as value,concat(DATE_FORMAT(CreateTime, '%m'),'月') as name from cloud_equipment a "));
            strSql.Append(string.Format(" WHERE YEAR(a.CreateTime)=YEAR(now()) "));
            strSql.Append(string.Format(" and quarter( a.CreateTime ) = {0} ", model.FullName));
            if (model.UserId != null)
            {
                strSql.Append(string.Format("and  a.Businesspeople='{0}' ", model.UserId));
            }
            strSql.Append(string.Format(" group by  name;"));
            return Repository().FindTableBySql(strSql.ToString());
        }





        /// <summary>
        /// 获取部门下人员总销售额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDeparUserOrderNumtotal(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(" select a.RealName as name,ifnull(b.eqnum,0) as value from base_user a left join "));
            strSql.Append(string.Format(" ( "));
            strSql.Append(string.Format(" select count(*) as eqnum, a.Businesspeople, b.RealName from cloud_equipment a "));
            strSql.Append(string.Format(" left join base_user b on a.Businesspeople=b.userid "));
            //strSql.Append(string.Format(" WHERE YEAR(a.CreateTime)=YEAR(now()) "));
            //strSql.Append(string.Format(" and quarter( a.CreateTime ) = {0} ", model.StateName));
            strSql.Append(string.Format(" group by a.Businesspeople"));
            strSql.Append(string.Format(" ) b "));
            strSql.Append(string.Format(" on a.userid=b.Businesspeople "));
            strSql.Append(string.Format(" where  a.DeleteMark=0 "));

            if (model.DepartmentId != null)
            {
                strSql.Append(string.Format("and  a.DepartmentId='{0}' ", model.DepartmentId));
            }
            return Repository().FindTableBySql(strSql.ToString());
        }



        /// <summary>
        /// 获取部门下各人员上/本季度销售额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDeparUserOrderNum(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(" select a.RealName as name,ifnull(b.eqnum,0) as value from base_user a left join "));
            strSql.Append(string.Format(" ( "));
            strSql.Append(string.Format(" select count(*) as eqnum, a.Businesspeople, b.RealName from cloud_equipment a "));
            strSql.Append(string.Format(" left join base_user b on a.Businesspeople=b.userid "));
            strSql.Append(string.Format(" WHERE YEAR(a.CreateTime)=YEAR(now()) "));
            strSql.Append(string.Format(" and quarter( a.CreateTime ) = {0} ", model.StateName));
            strSql.Append(string.Format(" group by a.Businesspeople"));
            strSql.Append(string.Format(" ) b "));
            strSql.Append(string.Format(" on a.userid=b.Businesspeople "));
            strSql.Append(string.Format(" where  a.DeleteMark=0 "));

            if (model.DepartmentId != null)
            {
                strSql.Append(string.Format("and  a.DepartmentId='{0}' ", model.DepartmentId));
            }
            return Repository().FindTableBySql(strSql.ToString());
        }


        public DataTable getQBdatatable(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(" select DATE_FORMAT(CreateTime, '%m') as months,count(*) as countnum "));
            strSql.Append(string.Format(" from cloud_equipment a "));
            if (model.year != null)
            {
                strSql.Append(string.Format(" WHERE YEAR(a.CreateTime)={0} ", model.year));
            }
            else
            {
                strSql.Append(string.Format(" WHERE YEAR(a.CreateTime)=YEAR(now()) "));
            }

            if (!string.IsNullOrEmpty(model.UserId))
            {

                strSql.Append(string.Format(" and a.Businesspeople in ({0}) ", model.UserId));
            }

            strSql.Append(string.Format(" group by months; "));
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取上季度或本季度的销售情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getdatatableList(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(" {0} ", model.Manager));
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*   ");
            strSql.Append(" from base_department a ");
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
        public int GetRecordCount(base_department model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from base_department a ");
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
        public IList<base_department> getbase_departmentList(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM base_department  a  WHERE 1=1");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(base_department model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `base_department` ");
                strSql.Append(" ( ");
                strSql.Append(" `DepartmentId`, ");
                strSql.Append(" `CompanyId`, ");
                strSql.Append(" `ParentId`, ");
                strSql.Append(" `Code`, ");
                strSql.Append(" `FullName`, ");
                strSql.Append(" `ShortName`, ");
                strSql.Append(" `Manager`, ");
                strSql.Append(" `Phone`, ");
                strSql.Append(" `Fax`, ");
                strSql.Append(" `Email`, ");
                strSql.Append(" `Remark`, ");
                strSql.Append(" `Enabled`, ");
                strSql.Append(" `SortCode`, ");
                strSql.Append(" `DeleteMark`, ");
                strSql.Append(" `CreateDate`, ");
                strSql.Append(" `CreateUserId`, ");


                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.DepartmentId));
                strSql.Append(string.Format(" '{0}', ", model.CompanyId));
                strSql.Append(string.Format(" '{0}', ", model.ParentId));
                strSql.Append(string.Format(" '{0}', ", model.Code));
                strSql.Append(string.Format(" '{0}', ", model.FullName));
                strSql.Append(string.Format(" '{0}', ", model.ShortName));
                strSql.Append(string.Format(" '{0}', ", model.Manager));
                strSql.Append(string.Format(" '{0}', ", model.Phone));
                strSql.Append(string.Format(" '{0}', ", model.Fax));
                strSql.Append(string.Format(" '{0}', ", model.Email));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.Enabled));
                strSql.Append(string.Format(" '{0}', ", model.SortCode));
                strSql.Append(string.Format(" '{0}', ", model.DeleteMark));
                strSql.Append(string.Format(" '{0}', ", model.CreateDate));
                strSql.Append(string.Format(" '{0}', ", model.CreateUserId));

                strSql.Append("   );  ");
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
        public bool Update(base_department model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update base_department  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" DepartmentId = '{0}', ", model.DepartmentId));
                strSql.Append(string.Format(" CompanyId = '{0}', ", model.CompanyId));
                strSql.Append(string.Format(" ParentId = '{0}', ", model.ParentId));
                strSql.Append(string.Format(" Code = '{0}', ", model.Code));
                strSql.Append(string.Format(" FullName = '{0}', ", model.FullName));
                strSql.Append(string.Format(" ShortName = '{0}', ", model.ShortName));
                strSql.Append(string.Format(" Manager = '{0}', ", model.Manager));
                strSql.Append(string.Format(" Phone = '{0}', ", model.Phone));
                strSql.Append(string.Format(" Fax = '{0}', ", model.Fax));
                strSql.Append(string.Format(" Email = '{0}', ", model.Email));
                strSql.Append(string.Format(" Remark = '{0}', ", model.Remark));
                strSql.Append(string.Format(" Enabled = '{0}', ", model.Enabled));
                strSql.Append(string.Format(" SortCode = '{0}', ", model.SortCode));
                strSql.Append(string.Format(" DeleteMark = '{0}', ", model.DeleteMark));
                strSql.Append(string.Format(" CreateDate = '{0}', ", model.CreateDate));
                strSql.Append(string.Format(" CreateUserId = '{0}', ", model.CreateUserId));

                strSql.Append(" where  ");
                strSql.Append(string.Format(" DicsId = '{0}' ", model.DepartmentId));
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
            strSql.Append("  delete from base_department ");
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





        public DataTable getequipmentnumList(base_department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.DepartmentId,a.FullName,b.equipmentnum  ");
            strSql.Append(" from base_department a ");
            strSql.Append(" left join(   ");
            strSql.Append(" select count(*) as equipmentnum,b.DepartmentId ");
            strSql.Append(" from cloud_equipment a  ");
            strSql.Append(" left join base_user b on a.Businesspeople=b.userid  ");
            strSql.Append(" left join base_department c on b.DepartmentId=c.DepartmentId ");
            strSql.Append(" WHERE YEAR(a.CreateTime)=YEAR(now())   ");
            switch (model.SortCode)
            {
                case 0:
                    strSql.Append(" and quarter( a.CreateTime ) = QUARTER(now()) ");//本季度
                    break;
                case 1:
                    strSql.Append(" and quarter( a.CreateTime ) = quarter(DATE_SUB(now(),interval 1 QUARTER)) ");//上季度
                    break;
            }
            strSql.Append(" group by b.DepartmentId) b ");
            strSql.Append(" on a.DepartmentId=b.DepartmentId  ");
            if (!string.IsNullOrEmpty(model.ParentId))
            {
                strSql.Append(string.Format(" where a.ParentId='{0}' ", model.ParentId));
            }

            return Repository().FindTableBySql(strSql.ToString());
        }





    }

}