
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
    public class base_fileDal : RepositoryFactory<base_file>
    {

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_file model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*   ");
            strSql.Append(" from base_file a ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.Pid))
            {
                strSql.Append(string.Format(" AND a.Pid = '{0}' ", model.Pid));
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
        public int GetRecordCount(base_file model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from base_file a ");
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
        public IList<base_file> getbase_fileList(base_file model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM base_file  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.DicsId = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(base_file model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `base_file` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `FileName`, ");
                strSql.Append(" `OldFileName`, ");
                strSql.Append(" `FileType`, ");
                strSql.Append(" `CreateTime`, ");
                strSql.Append(" `Url`, ");
                strSql.Append(" `Pid`, ");
                //strSql.Append(" `FileCategory`, ");
                strSql.Append(" `IsEnable` ");
                //strSql.Append(" `Type` ");


                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.FileName));
                strSql.Append(string.Format(" '{0}', ", model.OldFileName));
                strSql.Append(string.Format(" '{0}', ", model.FileType));
                strSql.Append(string.Format(" '{0}', ", model.CreateTime));
                strSql.Append(string.Format(" '{0}', ", model.Url));
                strSql.Append(string.Format(" '{0}', ", model.Pid));
                //strSql.Append(string.Format(" '{0}', ", model.FileCategory));
                strSql.Append(string.Format(" {0} ", model.IsEnable));
                //strSql.Append(string.Format(" '{0}' ", model.Type));

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
        public bool Update(base_file model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update base_file  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Id = '{0}', ", model.Id));
                strSql.Append(string.Format(" FileName = '{0}', ", model.FileName));
                strSql.Append(string.Format(" OldFileName = '{0}', ", model.OldFileName));
                strSql.Append(string.Format(" FileType = '{0}', ", model.FileType));
                strSql.Append(string.Format(" CreateTime = '{0}', ", model.CreateTime));
                strSql.Append(string.Format(" Url = '{0}', ", model.Url));
                strSql.Append(string.Format(" Pid = '{0}', ", model.Pid));
                strSql.Append(string.Format(" FileCategory = '{0}', ", model.FileCategory));
                strSql.Append(string.Format(" IsEnable = '{0}', ", model.IsEnable));
                strSql.Append(string.Format(" Type = '{0}', ", model.Type));

                strSql.Append(" where  ");
                strSql.Append(string.Format(" DicsId = '{0}' ", model.Id));
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
            strSql.Append("  delete from base_file ");
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







    }

}