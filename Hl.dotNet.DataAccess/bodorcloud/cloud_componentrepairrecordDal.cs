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
    public class cloud_componentrepairrecordDal : RepositoryFactory<cloud_componentrepairrecord>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componentrepairrecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select ");
            strSql.Append(" c.OrderNumber , ");
            strSql.Append(" c.Name as equipmentName , ");
            strSql.Append(" a.*  ,");
            strSql.Append(" b. equipmentId ,");
            strSql.Append(" d.Id as repairrecordId,");
            strSql.Append(" d.Starttime,");
            strSql.Append(" d.Endtime,");
            strSql.Append(" ( select datediff( d.Endtime,  d.Starttime)) as Lev ");
            strSql.Append(" from  cloud_componentlist a  ");
            strSql.Append(" inner join   cloud_equipmentcomponen b  on  a.Id= b.component");
            strSql.Append(" inner join cloud_equipment  c on c.EquipmentId = b.EquipmentId ");
            strSql.Append(" left join   cloud_componentrepairrecord   d  on d.Cloud_componentId= a.Id  and   b.EquipmentId = d.EquipmentId  ");
            strSql.Append(" left join  cloud_userequipment  e on  e.EquipmentId= c.EquipmentId   ");
            strSql.Append(" where  1=1  ");
            if (model.ComponentName != null && model.ComponentName != "")
            {
                strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.ComponentName));
            }
            if (model.UserId != null && model.UserId != "")
            {
                string roleId = ManageProvider.Provider.Current().RoleId;
                //客户角色1
                if (roleId.Contains(ConfigHelper.AppSettings("CustomerRoleId")))
                {
                    strSql.Append(string.Format("  and  e.UserId='{0}' ", model.UserId));//客户看到的

                }

                //销售代表2
                if (roleId.Contains(ConfigHelper.AppSettings("RoleIdByXiaoShou")))
                {
                    strSql.Append(string.Format("  and c.Businesspeople='{0}' and  (c.AgentUserId is null  or  c.AgentUserId='') ", model.UserId));//销售看到的

                }
            }



            strSql.Append(" order by Lev asc ");
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_componentrepairrecord model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select ");
                strSql.Append(" c.OrderNumber , ");
                strSql.Append(" c.Name as equipmentName , ");
                strSql.Append(" a.*  ,");
                strSql.Append(" d.Id as repairrecordId,");
                strSql.Append(" d.Starttime,");
                strSql.Append(" d.Endtime,");
                strSql.Append(" ( select datediff(d.Starttime, d.Endtime)) as Lev ");
                strSql.Append(" from  cloud_componentlist a  ");
                strSql.Append(" inner join   cloud_equipmentcomponen b  on  a.Id= b.component");
                strSql.Append(" inner join cloud_equipment  c on c.EquipmentId = b.EquipmentId ");
                strSql.Append(" left join   cloud_componentrepairrecord  d  on d.Cloud_componentId= a.Id   and   b.EquipmentId = d.EquipmentId ");
                strSql.Append(" left join  cloud_userequipment  e on  e.EquipmentId= c.EquipmentId   ");
                strSql.Append(" where  1=1  ");
                if (model.ComponentName != null && model.ComponentName != "")
                {
                    strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.ComponentName));
                }
                if (model.UserId != null && model.UserId != "")
                {
                    string roleId = ManageProvider.Provider.Current().RoleId;
                    //客户角色1
                    if (roleId.Contains(ConfigHelper.AppSettings("CustomerRoleId")))
                    {
                        strSql.Append(string.Format("  and  e.UserId='{0}' ", model.UserId));//客户看到的

                    }

                    //销售代表2
                    if (roleId.Contains(ConfigHelper.AppSettings("RoleIdByXiaoShou")))
                    {
                        strSql.Append(string.Format("  and c.Businesspeople='{0}' and  (c.AgentUserId is null  or  c.AgentUserId='') ", model.UserId));//销售看到的

                    }
                }
                strSql.Append(" order by Lev asc ");
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
        public IList<cloud_componentrepairrecord> getcloud_componentrepairrecordList(cloud_componentrepairrecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_componentrepairrecord a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_componentrepairrecord model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_componentrepairrecord` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `Cloud_componentId`, ");
                strSql.Append(" `StartTime`, ");
                strSql.Append(" `EndTime`,  ");
                strSql.Append(" `CreateDate`,  ");
                strSql.Append(" `UpdateUserId`,  ");
                strSql.Append(" `Remark` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.Cloud_componentId));
                strSql.Append(string.Format(" '{0}', ", model.StartTime));
                strSql.Append(string.Format(" '{0}', ", model.EndTime));
                strSql.Append(string.Format(" '{0}', ", model.CreateTime));
                strSql.Append(string.Format(" '{0}', ", model.UpdateUserId));
                strSql.Append(string.Format(" '{0}' ", model.Remark));
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
        public bool Update(cloud_componentrepairrecord model, cloud_componentrepairrecordhistory modelhistory)
        {




            //带事务的更新(当有复杂层级关系修改时候用到事物z在放开，单表操作不需要事物)
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_componentrepairrecord  ");
                strSql.Append(" SET  ");
               
                strSql.Append(string.Format(" StartTime = '{0}', ", model.StartTime));
                strSql.Append(string.Format(" EndTime = '{0}' ,", model.EndTime));
                strSql.Append(string.Format(" UpdateUserId = '{0}' ", model.UpdateUserId));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" Id = '{0}'; ", model.Id));

                //更新记录写入到维修记录表
                strSql.Append(" insert into cloud_componentrepairrecordhistory ");
                strSql.Append(" ( ");
                strSql.Append(" Id,");
                strSql.Append(" EquipmentId,  ");
                strSql.Append(" Cloud_componentId, ");
                strSql.Append(" UserId, ");
                strSql.Append(" HistoryTime, ");
                strSql.Append(" NextTime, ");
                strSql.Append(" CreateTime ");
                strSql.Append(" ) ");
                strSql.Append(" values");
                strSql.Append(" (");
                strSql.Append(string.Format(" '{0}', ", modelhistory.Id));
                strSql.Append(string.Format(" '{0}', ", modelhistory.EquipmentId));
                strSql.Append(string.Format(" '{0}', ", modelhistory.Cloud_componentId));
                strSql.Append(string.Format(" '{0}', ", modelhistory.UserId));
                strSql.Append(string.Format(" '{0}', ", model.StartTime));
                strSql.Append(string.Format(" '{0}', ", model.EndTime));
                strSql.Append(string.Format(" '{0}' ", modelhistory.CreateTime));
                strSql.Append(" );");


            }
            i = Repository().UpdateBySql(strSql.ToString(), isOpenTrans);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                database.Commit();
            }
            else
            {
                database.Rollback();
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
            strSql.Append("  delete from cloud_componentrepairrecord ");
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
    }
}
