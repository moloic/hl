
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
    public class base_qrcoderDal : RepositoryFactory<base_qrcoder>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(base_qrcoder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*  ");
            strSql.Append(" from base_qrcoder a ");
            strSql.Append(" where  1=1  ");
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
            }
            strSql.Append(string.Format(" AND a.IsDeleted = 0 "));
            strSql.Append("order by a.CreateTime desc ");
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(base_qrcoder model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from base_qrcoder  a ");
                strSql.Append(" where  1=1  ");
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
                }
                strSql.Append(string.Format(" AND a.IsDeleted = 0 "));
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
        public IList<base_qrcoder> getbase_qrcoderList(base_qrcoder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM base_qrcoder  a  WHERE 1=1");
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(string.Format(" AND a.IsDeleted = 0 "));
            strSql.Append(" ORDER BY a.CreateTime desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(base_qrcoder model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `base_qrcoder` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `Name`, ");
                strSql.Append(" `Url`, ");
                strSql.Append(" `CoderMsg`, ");
                strSql.Append(" `CreateUserId`, ");
                strSql.Append(" `CreateTime`,  ");
                strSql.Append(" `ImgeUrl`,  ");
                strSql.Append(" `IsDeleted`,  ");
                strSql.Append(" `ObjectId`");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.Name));
                strSql.Append(string.Format(" '{0}', ", model.Url));
                strSql.Append(string.Format(" '{0}', ", model.CoderMsg));
                strSql.Append(string.Format(" '{0}', ", model.UserId));
                strSql.Append(string.Format(" '{0}', ", model.CreateTime));
                strSql.Append(string.Format(" '{0}', ", model.ImgeUrl));
                strSql.Append(string.Format(" '{0}', ", model.IsDeleted));
                strSql.Append(string.Format(" '{0}' ", model.ObjectId));
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
        public bool Update(base_qrcoder model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update base_qrcoder  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Name = '{0}' ", model.Name));
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

            strSql.Append("  update  base_qrcoder  set IsDeleted=1  ");
            strSql.Append(" where ");
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
