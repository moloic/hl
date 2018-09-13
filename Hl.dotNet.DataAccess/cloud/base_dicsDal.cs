using Hl.dotNet.Models;
using Hl.dotNet.Orm;
using Hl.dotNet.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.DataAccess
{
    public class base_dicsDal : RepositoryFactory<Base_DicsModel>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(Base_DicsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*, b.FullName as DicCategoryName   ");
            strSql.Append(" from base_dics a ");
            strSql.Append(" left join base_diccategory b  on  a.DicCategoryId = b.DicCategoryId ");
            strSql.Append(" where  1=1  ");
            if (model.FullName != null && model.FullName != "")
            {

                strSql.Append(string.Format(" and  a.FullName  like '%{0}%' ", model.FullName));
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
        public int GetRecordCount(Base_DicsModel model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*, b.FullName as DicCategoryName   ");
                strSql.Append(" from base_dics a ");
                strSql.Append(" left join base_diccategory b  on  a.DicCategoryId = b.DicCategoryId ");
                strSql.Append(" where  1=1  ");
                if (model.FullName != null && model.FullName != "")
                {

                    strSql.Append(string.Format(" and  a.FullName  like '%{0}%' ", model.FullName));
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
        public IList<Base_DicsModel> getbase_dicsList(Base_DicsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM base_dics a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.DicsId))
            {
                strSql.Append(string.Format(" AND a.DicsId = '{0}' ", model.DicsId));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(Base_DicsModel model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `base_dics` ");
                strSql.Append(" ( ");
                strSql.Append(" `DicsId`, ");
                strSql.Append(" `DicCategoryId`, ");
                strSql.Append(" `ParentId`, ");
                strSql.Append(" `FullName`,  ");
                strSql.Append(" `Code`,  ");
                strSql.Append(" `Sortnum`,  ");
                strSql.Append(" `Remark`,  ");
                strSql.Append(" `Status`,  ");
                strSql.Append(" `CreateDate` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.DicsId));
                strSql.Append(string.Format(" '{0}', ", model.DicCategoryId));
                strSql.Append(string.Format(" '{0}', ", model.ParentId));
                strSql.Append(string.Format(" '{0}' ,", model.FullName));
                strSql.Append(string.Format(" '{0}', ", model.Code));
                strSql.Append(string.Format(" '{0}', ", model.Sortnum));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.Status));
                strSql.Append(string.Format(" '{0}' ", model.CreateDate));
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
        public bool Update(Base_DicsModel model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update base_dics  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" DicCategoryId = '{0}', ", model.DicCategoryId));
                strSql.Append(string.Format(" ParentId = '{0}', ", model.ParentId));
                strSql.Append(string.Format(" FullName = '{0}' ,", model.FullName));
                strSql.Append(string.Format(" Code = '{0}', ", model.Code));
                strSql.Append(string.Format(" Sortnum = '{0}', ", model.Sortnum));
                strSql.Append(string.Format(" Remark = '{0}', ", model.Remark));
                strSql.Append(string.Format(" Status = '{0}' ", model.Status));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" DicsId = '{0}' ", model.DicsId));
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
            strSql.Append("  delete from base_dics ");
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



        #region 获取下拉框
        /// <summary>
        /// 获取列别下拉框
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getDiccategory(Base_DicsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from base_diccategory as  a  ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(model.Code))
            {
                strSql.Append(string.Format(" AND a.Code = '{0}' ", model.Code));
            }
            strSql.Append(" ORDER BY a.CreateDate  desc ");
            return Repository().FindTableBySql(strSql.ToString());
        }
        #endregion




        #region 获取下拉框（公用）

        /// <summary>
        /// 获取下拉框（公用）
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable getDropdownval(Hashtable ht)
        {
            string value = ht["surfaceName"].ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select *  from (  ");
            strSql.Append(string.Format("  select a.* from {0} a ", value));
            strSql.Append("  )  a ; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        #endregion



        #region  根据种类获取下拉框

        public DataTable getDicsTable(Base_DicsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" *  ");
            strSql.Append(" from ");
            strSql.Append(" base_dics   ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(model.DicCategoryId))
            {
                strSql.Append(string.Format(" and DicCategoryId ='{0}'", model.DicCategoryId));
            }
            strSql.Append(" and Status=1   ");
            strSql.Append(" order by Sortnum asc; ");
            return Repository().FindTableBySql(strSql.ToString());
        }




        #endregion


    }
}
