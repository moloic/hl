
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
    public class cloud_ordernodeDal : RepositoryFactory<cloud_ordernode>
    {

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_ordernode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,b.NodeName ");
            strSql.Append(" from cloud_ordernode a ");
            strSql.Append(" left join cloud_node b on a.NodeId=b.id ");
          
            strSql.Append(string.Format(" where a.OrderId = '{0}' ", model.Id));
            strSql.Append(" order by a.CreateDate ");
            strSql.Append(" )  a ; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_ordernode model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from cloud_ordernode a ");
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
        public IList<cloud_ordernode> getcloud_ordernodeList(cloud_ordernode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_ordernode  a ");

            if (!string.IsNullOrEmpty(model.OrderId))
            {
                strSql.Append(string.Format(" where a.OrderId = '{0}' ", model.OrderId));
            }
            if (!string.IsNullOrEmpty(model.NodeId))
            {
                strSql.Append(string.Format(" AND a.NodeId = '{0}' ", model.NodeId));
            }
            strSql.Append("order by a.CreateDate desc ");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_ordernode model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
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
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.OrderId));
                strSql.Append(string.Format(" '{0}', ", model.NodeId));
                strSql.Append(string.Format(" '{0}', ", model.CreateUser));
                strSql.Append(string.Format(" '{0}', ", model.CreateDate));
                strSql.Append(string.Format(" '{0}' ", model.Rmark));

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
        public bool Update(cloud_ordernode model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_ordernode  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Id = '{0}', ", model.Id));
                strSql.Append(string.Format(" OrderId = '{0}', ", model.OrderId));
                strSql.Append(string.Format(" NodeId = '{0}', ", model.NodeId));
                strSql.Append(string.Format(" CreateUser = '{0}', ", model.CreateUser));
                strSql.Append(string.Format(" CreateDate = '{0}', ", model.CreateDate));
                strSql.Append(string.Format(" Rmark = '{0}', ", model.Rmark));

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
            strSql.Append("  delete from cloud_ordernode ");
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