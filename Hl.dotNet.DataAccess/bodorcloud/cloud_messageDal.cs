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
    public class cloud_messageDal : RepositoryFactory<cloud_message>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*  , case a.IsRead  when '0'  then '未读' when  '1' then  '已读' else '未知' end as  statename from cloud_message a   ");
            strSql.Append(" where  1=1  ");
            strSql.Append(string.Format(" and a.SendToUserId='{0}' ", model.UserId));

            if (model.Title != null && model.Title != "")
            {
                strSql.Append(string.Format(" and  a.Title  like '%{0}%' ", model.Title));
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
        public int GetRecordCount(cloud_message model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*  , case a.IsRead  when '0'  then '未读' when  '1' then  '已读' else '未知' end as  statename from cloud_message a   ");
                strSql.Append(" where  1=1  ");
                strSql.Append(string.Format(" and a.SendToUserId='{0}' ", model.UserId));
                if (model.Title != null && model.Title != "")
                {
                    strSql.Append(string.Format(" and  a.Title  like '%{0}%' ", model.Title));
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
        public IList<cloud_message> getcloud_messageList(cloud_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_message a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            if (!string.IsNullOrEmpty(model.Title))
            {
                strSql.Append(string.Format(" AND a.Title = '{0}' ", model.Title));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_message model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_message` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `Title`, ");
                strSql.Append(" `Remark`, ");
                strSql.Append(" `IsRead`,  ");
                strSql.Append(" `CreateUserId`,  ");
                strSql.Append(" `SendToUserId`,  ");
                strSql.Append(" `CreateDate` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.Title));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.IsRead));
                strSql.Append(string.Format(" '{0}' ,", model.CreateUserId));
                strSql.Append(string.Format(" '{0}', ", model.SendToUserId));
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
        public bool Update(cloud_message model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {


                strSql.Append(" update cloud_message  ");
                strSql.Append(" SET  ");

                //strSql.Append(string.Format(" Title = '{0}', ", model.Title));
                //strSql.Append(string.Format(" Remark = '{0}' ,", model.Remark));
                strSql.Append(string.Format(" IsRead = '{0}' ", model.IsRead));
                //strSql.Append(string.Format(" Remark = '{0}'", model.Remark));
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
            strSql.Append("  delete from cloud_message ");
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





        /// <summary>
        ///获取消息信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable geteMessageCount(cloud_message model)
        {
            StringBuilder strSql = new StringBuilder();
            if (model.IsRead == 1)  //如果点击的通知栏或者更多就更新下
            {
                strSql.Append(string.Format("update  cloud_message set IsRead =1  where  SendToUserId='{0}' ;", model.UserId));
            }


            strSql.Append(" select   * from   cloud_message a   ");// strSql.Append(" select   count( *) as messageCount  from   cloud_message a   ");   
            strSql.Append(" where ");
            strSql.Append(" 1=1 ");
            strSql.Append(" and a.IsRead=0  ");
            strSql.Append(string.Format(" and a.SendToUserId='{0}' ", model.UserId));
            return Repository().FindTableBySql(strSql.ToString());
        }





    }
}
