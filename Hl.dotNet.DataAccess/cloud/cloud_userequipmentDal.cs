
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
    public class cloud_userequipmentDal : RepositoryFactory<cloud_userequipment>
    {


        /// <summary>
        /// 返回用户分配的设备数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserPageList(cloud_userequipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select b.*,c.RealName,d.Name as ModelName  ");
            strSql.Append(" from cloud_userequipment a ");
            strSql.Append(" left join cloud_equipment b on a.EquipmentId=b.EquipmentId ");
            strSql.Append(" left join base_user c on b.Businesspeople=c.UserId ");
            strSql.Append(" left join cloud_equipmentmodel d on b.Model=d.Id ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.UserId))
            {
                strSql.Append(string.Format(" AND a.UserId = '{0}' ", model.UserId));
            }
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }
        /// <summary>
        /// 返回用户分配的设备条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetuserRecordCount(cloud_userequipment model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select b.*   ");
                strSql.Append(" from cloud_userequipment a ");
                strSql.Append(" left join cloud_equipment b on a.EquipmentId=b.EquipmentId ");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.UserId))
                {
                    strSql.Append(string.Format(" AND a.UserId = '{0}' ", model.UserId));
                }
                strSql.Append(" )  a  ");
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




        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_userequipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* ,b.Name as  ModelName  ");
            strSql.Append(" from cloud_equipment a left join cloud_equipmentmodel b on a.Model=b.Id");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Businesspeople = '{0}' ", model.Id));
            }
            strSql.Append(string.Format(" AND a.EquipmentId not in (select * from (select EquipmentId from  cloud_userequipment union select EquipmentId from cloud_agentequipment) as tb) "));
            if (!string.IsNullOrEmpty(model.StateName))
            {
                strSql.Append(string.Format(" and a.OrderNumber like '%{0}%' ", model.StateName));
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
        public int GetRecordCount(cloud_userequipment model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.* ,b.Name as  ModelName  ");
                strSql.Append(" from cloud_equipment a left join cloud_equipmentmodel b on a.Model=b.Id");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.Id))
                {
                    strSql.Append(string.Format(" AND a.Businesspeople = '{0}' ", model.Id));
                }
                strSql.Append(string.Format(" AND EquipmentId not in (select * from (select EquipmentId from  cloud_userequipment) as tb) "));
                if (!string.IsNullOrEmpty(model.StateName))
                {
                    strSql.Append(string.Format(" and a.OrderNumber like '%{0}%' ", model.StateName));
                }
                strSql.Append(" )  a  ");
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
        public IList<cloud_userequipment> getcloud_userequipmentList(cloud_userequipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from cloud_userequipment a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.EquipmentId))
            {
                strSql.Append(string.Format(" AND a.EquipmentId = '{0}' ", model.EquipmentId));
            }

            return Repository().FindListBySql(strSql.ToString());

        }

        //增加
        public bool Insert(cloud_userequipment model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_userequipment` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `EquipmentId`, ");
                strSql.Append(" `UserId` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" '{0}' ", model.UserId));

                strSql.Append("   );  ");
            }
            i = Repository().InsertBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                // database.Commit();
                Insertcomponentrepairrecord(model);
            }
            else
            {
                // database.Rollback();
            }
            return isok;
        }


        /// <summary>
        /// 添加零件保养信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insertcomponentrepairrecord(cloud_userequipment model)
        {
            StringBuilder strinserSql = new StringBuilder();
            //查询设备下零件信息 返回Datetable
            DataTable dt = getcloud_componentlist(model);
            //判断非空
            if (dt != null && dt.Rows.Count > 0)
            {
                //遍历数据 组成SQL语句
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    strinserSql.Append(" INSERT INTO `cloud_componentrepairrecord` ");
                    strinserSql.Append(" ( ");
                    strinserSql.Append(" `Id`, ");
                    strinserSql.Append(" `Cloud_componentId`, ");
                    strinserSql.Append(" `StartTime`, ");
                    strinserSql.Append(" `EndTime`, ");
                    strinserSql.Append(" `CreateDate`, ");
                    strinserSql.Append(" `EquipmentId`, ");
                    strinserSql.Append(" `CustomerId` ");

                    strinserSql.Append("  ) ");
                    strinserSql.Append(" VALUES  ");
                    strinserSql.Append(" (  ");
                    strinserSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                    strinserSql.Append(string.Format(" '{0}', ", dt.Rows[j]["Id"]));
                    strinserSql.Append(string.Format(" '{0}', ", model.CreateTime));
                    strinserSql.Append(string.Format(" '{0}', ", Convert.ToDateTime(model.CreateTime).AddDays(Convert.ToDouble(dt.Rows[j]["CycleDate"]))));
                    strinserSql.Append(string.Format(" '{0}', ", DateTime.Now));
                    strinserSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                    strinserSql.Append(string.Format(" '{0}' ", model.UserId));
                    strinserSql.Append("   );  ");
                }
            }
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;


            i = Repository().InsertBySql(strinserSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
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
        /// 查询设备下零件信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getcloud_componentlist(cloud_userequipment model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* from cloud_componentlist a    ");
            strSql.Append(" left join cloud_equipmentcomponen b  ");
            strSql.Append(" on a.Id=b.component ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.EquipmentId))
            {
                strSql.Append(string.Format(" AND b.EquipmentId = '{0}' ", model.EquipmentId));
            }
            strSql.Append(" )  a  ");

            return Repository().FindTableBySql(strSql.ToString());
        }




        /// <summary>
        ///  更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_userequipment model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_userequipment  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Id = '{0}', ", model.Id));
                strSql.Append(string.Format(" EquipmentId = '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" UserId = '{0}', ", model.UserId));

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
        public bool Delete(string EquipmentId, string UserId)
        {
            //带事务的增加(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            //  IDatabase database = DataFactory.Database();
            //  DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  delete from cloud_userequipment ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" UserId =  '{0}'  ", UserId));
            strSql.Append(string.Format(" and EquipmentId =  '{0}'  ;", EquipmentId));

            strSql.Append("  delete from cloud_componentrepairrecord ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" CustomerId =  '{0}'  ", UserId));
            strSql.Append(string.Format(" and EquipmentId =  '{0}'  ;", EquipmentId));

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