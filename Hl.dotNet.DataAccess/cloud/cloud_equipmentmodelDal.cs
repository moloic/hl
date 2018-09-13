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
    public class cloud_equipmentmodelDal : RepositoryFactory<cloud_equipmentmodel>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_equipmentmodel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*  , case a.Status  when '0'  then '停用' when  '1' then  '启用' else '未知' end as  statename from cloud_equipmentmodel a   ");
            strSql.Append(" where  1=1  ");
            strSql.Append(" and  a.IsDeleted= 0  ");
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
            }
            strSql.Append(" order by a.CreateDate desc ");
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_equipmentmodel model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*  , case a.Status  when '0'  then '停用' when  '1' then  '启用' else '未知' end as  statename from cloud_equipmentmodel a   ");
                strSql.Append(" where  1=1  ");
                strSql.Append(" and  a.IsDeleted= 0  ");
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
                }
                strSql.Append(" order by a.CreateDate desc ");
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
        public IList<cloud_equipmentmodel> getcloud_equipmentmodelList(cloud_equipmentmodel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  a.*, b.Url  FROM cloud_equipmentmodel a  left join   base_file b on a.id = b.pid   WHERE 1=1");
            strSql.Append(" and  a.IsDeleted= 0  ");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_equipmentmodel model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_equipmentmodel` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `DicsId`, ");

                strSql.Append(" `Name`,  ");
                strSql.Append(" `Status`,  ");
                strSql.Append(" `IsDeleted`,  ");
                strSql.Append(" `CreateDate` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.DicsId));

                strSql.Append(string.Format(" '{0}', ", model.Name));
                strSql.Append(string.Format(" '{0}' ,", model.Status));
                strSql.Append(string.Format(" '{0}' ,", 0));
                strSql.Append(string.Format(" '{0}' ", model.CreateTime));
                strSql.Append("   );  ");

                if (!string.IsNullOrEmpty(model.FileId))
                {
                    strSql.Append(string.Format(" update   base_file set Pid='{0}' where id in ({1}); ", model.Id, model.FileId));
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
        public bool Update(cloud_equipmentmodel model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql = new StringBuilder();
                strSql.Append(" update cloud_equipmentmodel  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" DicsId = '{0}', ", model.DicsId));

                strSql.Append(string.Format(" Name = '{0}' ,", model.Name));
                strSql.Append(string.Format(" Status = '{0}' ", model.Status));

                strSql.Append(" where  ");
                strSql.Append(string.Format(" Id = '{0}' ; ", model.Id));

                if (!string.IsNullOrEmpty(model.FileId))
                {
                    strSql.Append(strSql.AppendFormat(" delete  from base_file  where pid = '{0}' and Id  not in ({1}) ;", model.Id, model.FileId));

                    strSql.Append(string.Format(" update   base_file set Pid='{0}' where id in ({1}); ", model.Id, model.FileId));
                }
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
            //strSql.Append("  delete from cloud_equipmentmodel ");
            strSql.Append("   update  cloud_equipmentmodel  set IsDeleted=1  ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" Id in ( {0} ) ;", Id));

            strSql.Append(strSql.AppendFormat(" delete  from base_file  where Pid in ( {0} ) ;", Id));

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
