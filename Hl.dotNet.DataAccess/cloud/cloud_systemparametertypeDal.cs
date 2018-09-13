
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
    public class cloud_systemparametertypeDal : RepositoryFactory<cloud_systemparametertype>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_systemparametertype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* ,  ");
            strSql.Append(" case state ");
            strSql.Append(" when '0' then '停用' ");
            strSql.Append(" when '1' then '启用' ");
            strSql.Append(" else '未知' ");
            strSql.Append(" end as 'StateName' ");
            strSql.Append(" from cloud_systemparametertype a ");
            strSql.Append(" where  1=1  ");
            strSql.Append(" and  a.IsDeleted= 0  ");
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
            }
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_systemparametertype model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from cloud_systemparametertype  a ");
                strSql.Append(" where  1=1  ");
                strSql.Append(" and  a.IsDeleted= 0  ");
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
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
        public IList<cloud_systemparametertype> getcloud_systemparametertypeList(cloud_systemparametertype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_systemparametertype  a  WHERE 1=1");
            strSql.Append(" and  a.IsDeleted= 0  ");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            if (!string.IsNullOrEmpty(model.DicsId))
            {
                strSql.Append(string.Format(" AND a.DicsId = '{0}' ", model.DicsId));
            }

            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_systemparametertype model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_systemparametertype` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `Name`, ");
                strSql.Append(" `State`, ");
                strSql.Append(" `Remark`, ");
                strSql.Append(" `DicsId`, ");
                strSql.Append(" `IsDeleted`,  ");
                strSql.Append(" `CreateDate`");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.Name));
                strSql.Append(string.Format(" '{0}', ", model.State));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.DicsId));
                strSql.Append(string.Format(" '{0}', ", 0));
                strSql.Append(string.Format(" '{0}' ", model.CreateTime));
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
        public bool Update(cloud_systemparametertype model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_systemparametertype  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Name = '{0}', ", model.Name));
                strSql.Append(string.Format(" State = '{0}', ", model.State));
                strSql.Append(string.Format(" DicsId = '{0}', ", model.DicsId));
                strSql.Append(string.Format(" Remark = '{0}' ", model.Remark));
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
        public bool Delete(string Id)
        {
            //带事务的增加(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            //  IDatabase database = DataFactory.Database();
            //  DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("  delete from cloud_systemparametertype ");
            strSql.Append("   update  cloud_systemparametertype  set IsDeleted=1  ");
            strSql.Append("  where ");
            strSql.Append(string.Format(" Id in ( {0} ) ", Id));
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



    }
}
