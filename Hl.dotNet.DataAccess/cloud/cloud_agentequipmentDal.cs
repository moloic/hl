
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
    public class cloud_agentequipmentDal : RepositoryFactory<cloud_agentequipment>
    {

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_agentequipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select b.*,c.RealName ,d.Name as ModelName,   ");
            strSql.Append(" case a.State    ");
            strSql.Append(" when 1 then '未卖出'   ");
            strSql.Append(" when 0 then '已卖出'    ");
            strSql.Append("end as 'issellout'   ");
            strSql.Append(" from cloud_agentequipment a    ");
            strSql.Append(" left join cloud_equipment b on a.EquipmentId=b.EquipmentId   ");
            strSql.Append(" left join base_user c on b.Businesspeople=c.UserId ");
            strSql.Append(" left join cloud_equipmentmodel d on b.Model=d.Id ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.AgentId))
            {
                strSql.Append(string.Format(" AND a.AgentId = '{0}' ", model.AgentId));
            }
            if (model.State != null)
            {
                strSql.Append(string.Format(" AND a.State = {0} ", model.State));
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
        public int GetRecordCount(cloud_agentequipment model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select b.*,c.RealName,   ");
                strSql.Append(" case a.State    ");
                strSql.Append(" when 1 then '未卖出'   ");
                strSql.Append(" when 0 then '已卖出'    ");
                strSql.Append("end as 'issellout'   ");
                strSql.Append(" from cloud_agentequipment a    ");
                strSql.Append(" left join cloud_equipment b on a.EquipmentId=b.EquipmentId   ");
                strSql.Append(" left join base_user c on b.Businesspeople=c.UserId ");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.AgentId))
                {
                    strSql.Append(string.Format(" AND a.AgentId = '{0}' ", model.AgentId));
                }
                if (model.State != null)
                {
                    strSql.Append(string.Format(" AND a.State = {0} ", model.State));
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
        public IList<cloud_agentequipment> getcloud_agentequipmentList(cloud_agentequipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_agentequipment  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.DicsId = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_agentequipment model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_agentequipment` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `EquipmentId`, ");
                strSql.Append(" `AgentId`, ");
                strSql.Append(" `State` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" '{0}', ", model.AgentId));
                strSql.Append(string.Format(" {0} ", model.State));
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
        public bool Update(cloud_agentequipment model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_agentequipment  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Id = '{0}', ", model.Id));
                strSql.Append(string.Format(" EquipmentId = '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" AgentId = '{0}', ", model.AgentId));
                strSql.Append(string.Format(" State = '{0}', ", model.State));

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
        public bool Delete(string EquipmentId, string UserId)
        {
            //带事务的增加(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            //  IDatabase database = DataFactory.Database();
            //  DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("  delete from cloud_agentequipment ");
            //strSql.Append(" where ");
            //strSql.Append(string.Format(" DicsId in ( {0} ) ", Id));

            strSql.Append("  delete from cloud_agentequipment ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" AgentId =  '{0}'  ", UserId));
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


        /// <summary>
        /// 修改设备状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Agentupdate(cloud_agentequipment model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_agentequipment  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" State = {0} ", model.State));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" EquipmentId = '{0}' ", model.EquipmentId));
                strSql.Append(string.Format(" and AgentId = '{0}' ", model.AgentId));
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







    }

}