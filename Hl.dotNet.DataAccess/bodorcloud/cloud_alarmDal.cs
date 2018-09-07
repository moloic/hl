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
    public class cloud_alarmDal : RepositoryFactory<cloud_alarm>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_alarm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select ");
            strSql.Append(" a.id, ");
            strSql.Append(" a.EquipmentId, ");
            strSql.Append(" b.name as  EquipmentName, ");
            strSql.Append(" a.code,");
            strSql.Append(" c.codeName, ");
            strSql.Append(" c.ReasonMark,");
            strSql.Append(" c.ResolventMark, ");
            strSql.Append(" a.CreateTime, ");
            strSql.Append(" c.Remark ,");
            strSql.Append(" case a.IsRead  when '0'  then '未读' when  '1' then  '已读' else '未知' end as  IsReadState,");
            strSql.Append(" case a.IsOk  when '0'  then '未解决' when  '1' then  '已解决' else '未知' end as  IsOkState ");
            strSql.Append(" from  cloud_alarm a left join  cloud_equipment b on a.EquipmentId = b.EquipmentId");
            strSql.Append(" left join cloud_helpinfo c on c.`Code`= a.`Code`");
            strSql.Append(" left join  cloud_userequipment d on d.EquipmentId= b.EquipmentId ");//客户关联设备
            strSql.Append(" where  1=1  ");

            if (model.CodeName != null && model.CodeName != "")
            {
                strSql.Append(string.Format(" and  c.CodeName  like '%{0}%' ", model.CodeName));
            }
            if (model.UserId != null && model.UserId != "")
            {
                string roleId = ManageProvider.Provider.Current().RoleId;
                //客户角色1
                if (roleId.Contains(ConfigHelper.AppSettings("CustomerRoleId")))
                {
                    strSql.Append(string.Format("  and  d.UserId='{0}' ", model.UserId));//客户看到的

                }

                //销售代表2
                if (roleId.Contains(ConfigHelper.AppSettings("RoleIdByXiaoShou")))
                {
                    strSql.Append(string.Format("  and b.Businesspeople='{0}' ", model.UserId));//销售看到的

                }
            }
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
        public int GetRecordCount(cloud_alarm model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select ");
                strSql.Append(" a.id, ");
                strSql.Append(" a.EquipmentId, ");
                strSql.Append(" b.name as  EquipmentName, ");
                strSql.Append(" a.code,");
                strSql.Append(" c.codeName, ");
                strSql.Append(" c.ReasonMark,");
                strSql.Append(" c.ResolventMark, ");
                strSql.Append(" a.CreateTime, ");
                strSql.Append(" c.Remark ,");
                strSql.Append(" case a.IsRead  when '0'  then '未读' when  '1' then  '已读' else '未知' end as  IsReadState,");
                strSql.Append(" case a.IsOk  when '0'  then '未解决' when  '1' then  '已解决' else '未知' end as  IsOkState ");
                strSql.Append(" from  cloud_alarm a left join  cloud_equipment b on a.EquipmentId = b.EquipmentId");
                strSql.Append(" left join cloud_helpinfo c on c.`Code`= a.`Code`");
                strSql.Append(" left join  cloud_userequipment d on d.EquipmentId= b.EquipmentId ");//客户关联设备
                strSql.Append(" where  1=1  ");

                if (model.CodeName != null && model.CodeName != "")
                {
                    strSql.Append(string.Format(" and  c.CodeName  like '%{0}%' ", model.CodeName));
                }
                if (model.UserId != null && model.UserId != "")
                {
                    string roleId = ManageProvider.Provider.Current().RoleId;
                    //客户角色1
                    if (roleId.Contains(ConfigHelper.AppSettings("CustomerRoleId")))
                    {
                        strSql.Append(string.Format("  and  d.UserId='{0}' ", model.UserId));//客户看到的

                    }

                    //销售代表2
                    if (roleId.Contains(ConfigHelper.AppSettings("RoleIdByXiaoShou")))
                    {
                        strSql.Append(string.Format("  and b.Businesspeople='{0}' ", model.UserId));//销售看到的

                    }
                }
                strSql.Append("order by a.CreateTime desc ");
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
        public IList<cloud_alarm> getcloud_alarmList(cloud_alarm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_alarm a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateTime desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_alarm model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_alarm  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" IsRead = '{0}' ", model.IsRead));
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
        /// 获取报警个数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getalarmCount(cloud_alarm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) as AlarmCount  from cloud_alarm as a ");
            strSql.Append("where 1=1 ");
            string roleId = ManageProvider.Provider.Current().RoleId;

            //销售代表2
            if (roleId.Contains(ConfigHelper.AppSettings("RoleIdByXiaoShou")))
            {
                strSql.Append(string.Format("and a.EquipmentId in (  select EquipmentId from cloud_equipment where Businesspeople='{0}' and (AgentUserId is null  or  AgentUserId='') ) ", model.UserId));
            }
            //客户角色1
            if (roleId.Contains(ConfigHelper.AppSettings("CustomerRoleId")))
            {
                strSql.Append(string.Format("and a.EquipmentId in (select EquipmentId from cloud_userequipment where userid='{0}')", model.UserId));
            }
            strSql.Append("and a.isok=0; ");
            return Repository().FindTableBySql(strSql.ToString());
        }








    }
}
