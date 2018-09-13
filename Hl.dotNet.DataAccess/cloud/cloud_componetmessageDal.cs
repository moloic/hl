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
    public class cloud_componetmessageDal : RepositoryFactory<cloud_componetmessage>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componetmessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.* ,");
            strSql.Append(" b.Name as componentName,");
            strSql.Append(" c.Name as equipmentname,");
            strSql.Append(" d.realname as  sendUserName,");
            strSql.Append(" e.RealName as  AddresseeUserName");
            strSql.Append(" from cloud_componetmessage a");
            strSql.Append(" left join cloud_componentlist b on  a.ComponentId = b.id ");
            strSql.Append(" left join cloud_equipment c  on  c.EquipmentId = a.equipmentId");
            strSql.Append(" left join base_user d on a.SendUserId = d.UserId");
            strSql.Append(" left join base_User e on a.AddresseeUserId = e.Userid ");
            strSql.Append(" where  1=1  ");
            if (model.Remark != null && model.Remark != "")
            {

                strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Remark));
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
        public int GetRecordCount(cloud_componetmessage model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.* ,");
                strSql.Append(" b.Name as componentName,");
                strSql.Append(" c.Name as equipmentname,");
                strSql.Append(" d.realname as  sendUserName,");
                strSql.Append(" e.RealName as  AddresseeUserName");
                strSql.Append(" from cloud_componetmessage a");
                strSql.Append(" left join cloud_componentlist b on  a.ComponentId = b.id ");
                strSql.Append(" left join cloud_equipment c  on  c.EquipmentId = a.equipmentId");
                strSql.Append(" left join base_user d on a.SendUserId = d.UserId");
                strSql.Append(" left join base_User e on a.AddresseeUserId = e.Userid ");
                strSql.Append(" where  1=1  ");
                if (model.Remark != null && model.Remark != "")
                {
                    strSql.Append(string.Format(" and  a.Remark  like '%{0}%' ", model.Remark));
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







        /// <summary>
        /// 返回我的推送信息分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getMyMessagePageList(cloud_componetmessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select ");
            strSql.Append(" a.*,");
            strSql.Append(" b.Name as componentName , ");
            strSql.Append(" c.OrderNumber , ");
            strSql.Append(" c.Name as equipmentname, ");
            strSql.Append(" d.RealName , ");
            strSql.Append(" e.Endtime  ");
            strSql.Append(" from cloud_componetmessage  a ");
            strSql.Append(" inner join  cloud_componentlist  b on  a.ComponentId = b.id ");
            strSql.Append(" inner join  cloud_equipment c on  c.EquipmentId = a.EquipmentId ");
            strSql.Append(" inner join  base_user d on a.AddresseeUserId = d.UserId   ");
            strSql.Append(" inner join  cloud_componentrepairrecord e on a.EquipmentId= e.EquipmentId and a.ComponentId = e.Cloud_componentId and a.AddresseeUserId = e.CustomerId ");
            strSql.Append(" where 1=1 ");
            if (model.AddresseeUserId != null && model.AddresseeUserId != "")
            {
                strSql.Append(string.Format(" and a.AddresseeUserId='{0}'", model.AddresseeUserId));
            }
            if (model.SendUserId != null && model.SendUserId != "")
            {
                strSql.Append(string.Format("  and a.SendUserId ='{0}'", model.SendUserId));
            }
            if (model.Remark != null && model.Remark != "")
            {
                strSql.Append(string.Format("  and c.OrderNumber like '%{0}%' ", model.Remark));
            }

            strSql.Append(" order by a.CreateDate desc ");
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 获取我的推送信息总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetMyMessageRecordCount(cloud_componetmessage model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select ");
                strSql.Append(" a.*,");
                strSql.Append(" b.Name as componentName , ");
                strSql.Append(" c.OrderNumber , ");
                strSql.Append(" c.Name as equipmentname, ");
                strSql.Append(" d.RealName , ");
                strSql.Append(" e.Endtime  ");
                strSql.Append(" from cloud_componetmessage  a ");
                strSql.Append(" inner join  cloud_componentlist  b on  a.ComponentId = b.id ");
                strSql.Append(" inner join  cloud_equipment c on  c.EquipmentId = a.EquipmentId ");
                strSql.Append(" inner join  base_user d on a.AddresseeUserId = d.UserId   ");
                strSql.Append(" inner join  cloud_componentrepairrecord e on a.EquipmentId= e.EquipmentId and a.ComponentId = e.Cloud_componentId and a.AddresseeUserId = e.CustomerId ");
                strSql.Append(" where 1=1 ");
                if (model.AddresseeUserId != null && model.AddresseeUserId != "")
                {
                    strSql.Append(string.Format(" and a.AddresseeUserId='{0}'", model.AddresseeUserId));
                }
                if (model.SendUserId != null && model.SendUserId != "")
                {
                    strSql.Append(string.Format("  and a.SendUserId ='{0}'", model.SendUserId));
                }
                if (model.Remark != null && model.Remark != "")
                {
                    strSql.Append(string.Format("  and c.OrderNumber like '%{0}%' ", model.Remark));
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
        public IList<cloud_componetmessage> getcloud_componetmessageList(cloud_componetmessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_componetmessage a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取发送信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getMessageList(cloud_componetmessage model)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(" select  ");
            //strSql.Append(" c.OrderNumber ,  ");
            //strSql.Append(" c.Name as equipmentName , ");
            //strSql.Append(" a.*  ,   ");
            //strSql.Append(" b. equipmentId , ");
            //strSql.Append(" d.Id as repairrecordId,   ");
            //strSql.Append(" d.Starttime,  ");
            //strSql.Append(" d.Endtime,  ");
            //strSql.Append(" e.RealName, ");
            //strSql.Append(" e.Email,  ");
            //strSql.Append(" ( select datediff( d.Endtime,  d.Starttime)) as Lev  ");
            //strSql.Append(" from  cloud_componentlist a    ");
            //strSql.Append(" inner join   cloud_equipmentcomponen b  on  a.Id= b.component  ");
            //strSql.Append(" inner join cloud_equipment  c on c.EquipmentId = b.EquipmentId   ");
            //strSql.Append(" left join   cloud_componentrepairrecord   d  on d.Cloud_componentId= a.Id   ");
            //strSql.Append(" inner join base_user e on e.UserId= d.CustomerId ");
            //strSql.Append(" and   b.EquipmentId = d.EquipmentId   where  1=1  ");

            //if (model.AddresseeUserId != null && model.AddresseeUserId != "")
            //{
            //    strSql.Append(string.Format("and  d.CustomerId ='{0}' ", model.AddresseeUserId));
            //}
            //strSql.Append("   order by Lev asc  ");


                strSql.Append(" select  "); 
               strSql.Append("b.*  ,  "); 
               strSql.Append("c.OrderNumber ,  "); 
               strSql.Append("c.Name as equipmentName , "); 
               strSql.Append("c.EquipmentId ,   "); 
               strSql.Append("d.Id as repairrecordId,   ");
               strSql.Append("d.Starttime,   d.Endtime,   e.RealName,  e.Email,   ( select datediff( d.Endtime,  d.Starttime)) as Lev , a.AddresseeUserId  "); 
               strSql.Append("from cloud_componetmessage a  "); 
               strSql.Append("left join cloud_componentlist b on a.ComponentId = b.Id  "); 
               strSql.Append("left join cloud_equipment c  on a.EquipmentId = c.EquipmentId  "); 
               strSql.Append("left join   cloud_componentrepairrecord   d  on d.Cloud_componentId= a.ComponentId and a.EquipmentId=d.EquipmentId "); 
               strSql.Append("left join base_user e on e.UserId= a.AddresseeUserId  "); 
               strSql.Append("where  1=1   "); 
               strSql.Append(string.Format("and  a.id in({0}) ",model.Id)); 
               strSql.Append("order by Lev asc ");
               strSql.Append(" ;  "); 
            return Repository().FindTableBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_componetmessage model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_componetmessage` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `ComponentId`, ");
                strSql.Append(" `EquipmentId`, ");
                strSql.Append(" `SendUserId`, ");
                strSql.Append(" `IsRead`,  ");
                strSql.Append(" `CreateDate`,  ");
                strSql.Append(" `AddresseeUserId`,  ");
                strSql.Append(" `Remark`  ");

                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.ComponentId));
                strSql.Append(string.Format(" '{0}', ", model.SendUserId));
                strSql.Append(string.Format(" '{0}', ", model.IsRead));
                strSql.Append(string.Format(" '{0}' ,", model.CreateTime));
                strSql.Append(string.Format(" '{0}', ", model.AddresseeUserId));
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

        //批量增加
        public bool InsertList(List<cloud_componetmessage> list)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                foreach (cloud_componetmessage model in list)
                {
                    if (model != null)
                    {
                        strSql.Append(" INSERT INTO `cloud_componetmessage` ");
                        strSql.Append(" ( ");
                        strSql.Append(" `Id`, ");
                        strSql.Append(" `ComponentId`, ");
                        strSql.Append(" `EquipmentId`, ");
                        strSql.Append(" `SendUserId`, ");
                        strSql.Append(" `IsRead`,  ");
                        strSql.Append(" `CreateDate`,  ");
                        strSql.Append(" `AddresseeUserId`,  ");
                        strSql.Append(" `Remark`  ");
                        strSql.Append("  ) ");
                        strSql.Append(" VALUES  ");
                        strSql.Append(" (  ");
                        strSql.Append(string.Format(" '{0}', ", model.Id));
                        strSql.Append(string.Format(" '{0}', ", model.ComponentId));
                        strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                        strSql.Append(string.Format(" '{0}', ", model.SendUserId));
                        strSql.Append(string.Format(" '{0}', ", model.IsRead));
                        strSql.Append(string.Format(" '{0}' ,", model.CreateTime));
                        strSql.Append(string.Format(" '{0}', ", model.AddresseeUserId));
                        strSql.Append(string.Format(" '{0}' ", model.Remark));
                        strSql.Append("   );  ");
                    }
                }
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
        public bool Update(cloud_componetmessage model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_componetmessage  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" ComponentId = '{0}', ", model.ComponentId));
                strSql.Append(string.Format(" EquipmentId = '{0}', ", model.ComponentId));
                strSql.Append(string.Format(" SendUserId = '{0}', ", model.SendUserId));
                strSql.Append(string.Format(" IsRead = '{0}' ,", model.IsRead));
                strSql.Append(string.Format(" CreateDate = '{0}', ", model.CreateTime));
                strSql.Append(string.Format(" AddresseeUserId = '{0}', ", model.AddresseeUserId));
                strSql.Append(string.Format(" Remark = '{0}' ", model.Remark));
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
            strSql.Append("  delete from cloud_componetmessage ");
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
