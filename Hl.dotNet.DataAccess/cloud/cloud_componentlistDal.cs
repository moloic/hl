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
    public class cloud_componentlistDal : RepositoryFactory<cloud_componentlist>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componentlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* ,b.Name as TypeName , case a.State  when '0'  then '停用' when  '1' then  '启用' else '未知' end as  statename from cloud_componentlist a   ");
            strSql.Append(" left join  ");
            strSql.Append(" cloud_component b on a.ComponentId = b.id ");
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
        public int GetRecordCount(cloud_componentlist model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.* ,b.Name as TypeName from cloud_componentlist a   ");
                strSql.Append(" left join  ");
                strSql.Append(" cloud_component b on a.ComponentId = b.id ");
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
        public IList<cloud_componentlist> getcloud_componentlistList(cloud_componentlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_componentlist a  WHERE 1=1");
            strSql.Append(" and  a.IsDeleted= 0  ");
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_componentlist model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_componentlist` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `ComponentId`, ");
                strSql.Append(" `BomCode`, ");
                strSql.Append(" `Name`,  ");
                strSql.Append(" `Marker`,  ");
                strSql.Append(" `State`,  ");
                strSql.Append(" `Remark`,  ");
                strSql.Append(" `UnityModel`,  ");
                strSql.Append(" `CycleDate`,  ");
                strSql.Append(" `IsDeleted`,  ");
                strSql.Append(" `CreateDate` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.ComponentId));
                strSql.Append(string.Format(" '{0}', ", model.BomCode));
                strSql.Append(string.Format(" '{0}', ", model.Name));
                strSql.Append(string.Format(" '{0}' ,", model.Marker));
                strSql.Append(string.Format(" '{0}', ", model.State));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.UnityModel));
                strSql.Append(string.Format(" '{0}', ", model.CycleDate));
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
        public bool Update(cloud_componentlist model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_componentlist  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" ComponentId = '{0}', ", model.ComponentId));
                strSql.Append(string.Format(" BomCode = '{0}', ", model.BomCode));
                strSql.Append(string.Format(" Name = '{0}' ,", model.Name));
                strSql.Append(string.Format(" Marker = '{0}', ", model.Marker));
                strSql.Append(string.Format(" State = '{0}', ", model.State));
                strSql.Append(string.Format(" Remark = '{0}', ", model.Remark));
                strSql.Append(string.Format(" CycleDate = '{0}', ", model.CycleDate));
                strSql.Append(string.Format(" UnityModel = '{0}' ", model.UnityModel));
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
            //strSql.Append("  delete from cloud_componentlist ");
            strSql.Append("  update  cloud_componentlist  set IsDeleted=1 ");    
            strSql.Append(" where ");
            strSql.Append(string.Format(" Id in ( {0} ) ", DicsId));
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



        #region 获取下拉框
        /// <summary>
        /// 获取列别下拉框
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getDiccategory(cloud_componentlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from cloud_component as  a  ");
            strSql.Append(" where 1=1 ");
            strSql.Append(" and  a.IsDeleted= 0  ");
            strSql.Append(string.Format(" AND a.State = '{0}' ", 1));
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate  desc ");
            return Repository().FindTableBySql(strSql.ToString());
        }
        #endregion


    }
}
