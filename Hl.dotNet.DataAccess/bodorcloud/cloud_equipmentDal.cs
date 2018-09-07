
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
    public class cloud_equipmentDal : RepositoryFactory<cloud_equipment>
    {



        #region 代理查询设备列表

        public DataTable getagentPageList(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.RealName,d.Name as ModelName    ");
            strSql.Append(" from cloud_equipment a ");
            strSql.Append(" left join cloud_agentequipment e on a.EquipmentId=e.EquipmentId ");
            strSql.Append(" left join base_user c on a.Businesspeople=c.UserId ");
            strSql.Append(" left join cloud_equipmentmodel d on a.Model=d.Id ");
            strSql.Append(" where  1=1  ");
            if (model.EquipmentId != null && model.EquipmentId != "")
            {
                strSql.Append(string.Format(" and a.AgentUserId='{0}' ", model.EquipmentId));
            }
            if (!string.IsNullOrEmpty(model.Selectval))
            {
                strSql.Append(string.Format(" and {0} ", model.Selectval));
            }
            if (model.OrderStr != null && model.OrderStr != "")
            {
                strSql.Append(string.Format("  {0} ", model.OrderStr));
            }

            strSql.Append(" )  a  ");
            //strSql.Append(" where  1=1  ");
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" where a.Name like '%{0}%' ", model.Name));
                strSql.Append(string.Format(" or a.OrderNumber like  '%{0}%' ", model.Name));
                strSql.Append(string.Format(" or a.Model like  '%{0}%' ", model.Name));
            }
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetAgentPageCount(cloud_equipment model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*,c.RealName,d.Name as ModelName    ");
                strSql.Append(" from cloud_equipment a ");
                strSql.Append(" left join cloud_agentequipment e on a.EquipmentId=e.EquipmentId ");
                strSql.Append(" left join base_user c on a.Businesspeople=c.UserId ");
                strSql.Append(" left join cloud_equipmentmodel d on a.Model=d.Id ");
                strSql.Append(" where  1=1  ");
                if (model.EquipmentId != null && model.EquipmentId != "")
                {
                    strSql.Append(string.Format(" and a.AgentUserId='{0}' ", model.EquipmentId));
                }
                if (!string.IsNullOrEmpty(model.Selectval))
                {
                    strSql.Append(string.Format(" and {0} ", model.Selectval));
                }
                if (model.OrderStr != null && model.OrderStr != "")
                {
                    strSql.Append(string.Format("  {0} ", model.OrderStr));
                }
                strSql.Append(" )  a  ");
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" where a.Name like '%{0}%' ", model.Name));
                    strSql.Append(string.Format(" or a.OrderNumber like  '%{0}%' ", model.Name));
                    strSql.Append(string.Format(" or a.Model like  '%{0}%' ", model.Name));
                }
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
        #endregion


        /// <summary>
        /// 查询用户下设备详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getuserequipment(cloud_equipment model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*    ");
            strSql.Append(" from cloud_equipment a ");
            strSql.Append(" left join cloud_userequipment b on a.EquipmentId=b.EquipmentId");
            strSql.Append(" where ");
            if (model.UserId != null && model.UserId != "")
            {
                strSql.Append(string.Format(" b.userid = '{0}' ", model.UserId));
            }
            strSql.Append(" )  a  ");

            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*,c.RealName,d.Name as ModelName    ");
            strSql.Append(" from cloud_equipment a ");
            //strSql.Append(" left join cloud_userequipment b ");
            strSql.Append(" left join base_user c on a.Businesspeople=c.UserId ");
            strSql.Append(" left join cloud_equipmentmodel d on a.Model=d.Id ");
            strSql.Append(" where  1=1  ");
            if (model.EquipmentId != null && model.EquipmentId != "")
            {
                strSql.Append(string.Format(" and a.Businesspeople='{0}' ", model.EquipmentId));
            }
            if (!string.IsNullOrEmpty(model.Selectval))
            {
                strSql.Append(string.Format(" and {0} ", model.Selectval));
            }
            if (model.OrderStr != null && model.OrderStr != "")
            {
                strSql.Append(string.Format("  {0} ", model.OrderStr));
            }

            strSql.Append(" )  a  ");
            //strSql.Append(" where  1=1  ");
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" where a.Name like '%{0}%' ", model.Name));
                strSql.Append(string.Format(" or a.OrderNumber like  '%{0}%' ", model.Name));
                strSql.Append(string.Format(" or a.Model like  '%{0}%' ", model.Name));
            }
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_equipment model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*,c.RealName,d.Name as ModelName    ");
                strSql.Append(" from cloud_equipment a ");
                //strSql.Append(" left join cloud_userequipment b ");
                strSql.Append(" left join base_user c on a.Businesspeople=c.UserId ");
                strSql.Append(" left join cloud_equipmentmodel d on a.Model=d.Id ");
                strSql.Append(" where  1=1  ");
                if (model.EquipmentId != null && model.EquipmentId != "")
                {
                    strSql.Append(string.Format(" and a.Businesspeople='{0}' ", model.EquipmentId));
                }
                if (!string.IsNullOrEmpty(model.Selectval))
                {
                    strSql.Append(string.Format(" and {0} ", model.Selectval));
                }
                if (model.OrderStr != null && model.OrderStr != "")
                {
                    strSql.Append(string.Format("  {0} ", model.OrderStr));
                }
                strSql.Append(" )  a  ");
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" where a.Name like '%{0}%' ", model.Name));
                    strSql.Append(string.Format(" or a.OrderNumber like  '%{0}%' ", model.Name));
                    strSql.Append(string.Format(" or a.Model like  '%{0}%' ", model.Name));
                }
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
        public IList<cloud_equipment> getcloud_equipmentList(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_equipment  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.EquipmentId))
            {
                strSql.Append(string.Format(" AND a.EquipmentId = '{0}' ", model.EquipmentId));
            }

            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_equipment model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_equipment` ");
                strSql.Append(" ( ");
                strSql.Append(" `EquipmentId`, ");
                strSql.Append(" `Name`, ");
                strSql.Append(" `OrderNumber`, ");
                strSql.Append(" `Model`, ");
                strSql.Append(" `Type`, ");
                strSql.Append(" `Power`, ");
                strSql.Append(" `Voltage`, ");
                strSql.Append(" `Language`, ");
                strSql.Append(" `Encryption`, ");
                strSql.Append(" `Region`, ");
                strSql.Append(" `Businesspeople`, ");
                strSql.Append(" `Warranty`, ");
                strSql.Append(" `LssueDate`, ");
                strSql.Append(" `Phone`, ");
                strSql.Append(" `Picture`, ");
                strSql.Append(" `Baidulng`, ");
                strSql.Append(" `Baidulat`, ");
                strSql.Append(" `Address`, ");
                strSql.Append(" `AgentUserId`, ");
                strSql.Append(" `Series`,CreateTime ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" '{0}', ", model.Name));
                strSql.Append(string.Format(" '{0}', ", model.OrderNumber));
                strSql.Append(string.Format(" '{0}', ", model.Model));
                strSql.Append(string.Format(" {0}, ", model.Type));
                strSql.Append(string.Format(" '{0}', ", model.Power));
                strSql.Append(string.Format(" '{0}', ", model.Voltage));
                strSql.Append(string.Format(" '{0}', ", model.Language));
                strSql.Append(string.Format(" '{0}', ", model.Encryption));
                strSql.Append(string.Format(" '{0}', ", model.Region));
                strSql.Append(string.Format(" '{0}', ", model.Businesspeople));
                strSql.Append(string.Format(" '{0}', ", model.Warranty));
                strSql.Append(string.Format(" '{0}', ", model.LssueDate));
                strSql.Append(string.Format(" '{0}', ", model.Phone));
                strSql.Append(string.Format(" '{0}', ", model.Picture));
                strSql.Append(string.Format(" '{0}', ", model.Baidulng));
                strSql.Append(string.Format(" '{0}', ", model.Baidulat));
                strSql.Append(string.Format(" '{0}', ", model.Address));
                strSql.Append(string.Format(" '{0}', ", model.AgentUserId));
                strSql.Append(string.Format(" '{0}', ", model.Series));
                strSql.Append(string.Format(" '{0}' ", model.CreateTime));
                strSql.Append("   );  ");

                //if (model.UserId != null && model.UserId != "")
                //{
                //    strSql.Append(" INSERT INTO `cloud_userequipment` ");
                //    strSql.Append(" ( ");
                //    strSql.Append(" `Id`, ");
                //    strSql.Append(" `EquipmentId`, ");
                //    strSql.Append(" `UserId` ");
                //    strSql.Append("  ) ");
                //    strSql.Append(" VALUES  ");
                //    strSql.Append(" (  ");
                //    strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                //    strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                //    strSql.Append(string.Format(" '{0}' ", model.UserId));
                //    strSql.Append("   );  ");
                //}
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
        public bool Update(cloud_equipment model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_equipment  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" EquipmentId = '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" Name = '{0}', ", model.Name));
                strSql.Append(string.Format(" OrderNumber = '{0}', ", model.OrderNumber));
                strSql.Append(string.Format(" Model = '{0}', ", model.Model));
                strSql.Append(string.Format(" Type = {0}, ", model.Type));
                strSql.Append(string.Format(" Power = '{0}', ", model.Power));
                strSql.Append(string.Format(" Voltage = '{0}', ", model.Voltage));
                strSql.Append(string.Format(" Language = '{0}', ", model.Language));
                strSql.Append(string.Format(" Encryption = '{0}', ", model.Encryption));
                strSql.Append(string.Format(" Region = '{0}', ", model.Region));
                strSql.Append(string.Format(" Businesspeople = '{0}', ", model.Businesspeople));
                strSql.Append(string.Format(" Warranty = '{0}', ", model.Warranty));
                strSql.Append(string.Format(" LssueDate = '{0}', ", model.LssueDate));
                strSql.Append(string.Format(" Phone = '{0}', ", model.Phone));
                strSql.Append(string.Format(" Picture = '{0}', ", model.Picture));

                strSql.Append(string.Format(" Baidulng = '{0}', ", model.Baidulng));
                strSql.Append(string.Format(" Baidulat = '{0}', ", model.Baidulat));
                strSql.Append(string.Format(" Address = '{0}', ", model.Address));
                strSql.Append(string.Format(" AgentUserId = '{0}', ", model.AgentUserId));
                strSql.Append(string.Format(" Series = '{0}' ", model.Series));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" EquipmentId = '{0}' ;", model.EquipmentId));

                //if (model.UserId != null && model.UserId != "")
                //{
                //    //strSql.Append("  delete from cloud_userequipment ");
                //    //strSql.Append(" where ");
                //    //strSql.Append(string.Format(" UserId = '{0}' ", model.UserId));
                //    //strSql.Append(string.Format(" and EquipmentId = '{0}' ;", model.EquipmentId));

                //    //strSql.Append(" INSERT INTO `cloud_userequipment` ");
                //    //strSql.Append(" ( ");
                //    //strSql.Append(" `Id`, ");
                //    //strSql.Append(" `EquipmentId`, ");
                //    //strSql.Append(" `UserId` ");
                //    //strSql.Append("  ) ");
                //    //strSql.Append(" VALUES  ");
                //    //strSql.Append(" (  ");
                //    //strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));
                //    //strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                //    //strSql.Append(string.Format(" '{0}' ", model.UserId));
                //    //strSql.Append("   );  ");
                //}
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
            strSql.Append("  delete from cloud_equipment ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" EquipmentId in ( {0} ) ;", DicsId));

            //删除关联零件
            strSql.Append("  delete from cloud_userequipment ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" EquipmentId in ( {0} ) ;", DicsId));
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
        /// 获取零件分类信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getcomponentList(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*, b.CId,ifnull(b.cun,0) as cun from cloud_component a   ");
            strSql.Append(" left join ");
            strSql.Append(" ( ");
            strSql.Append(" select ComponentId as CId, ");
            strSql.Append(" count(*) as cun  ");
            strSql.Append(" from cloud_componentlist  where IsDeleted=0  ");
            strSql.Append(" group by ComponentId ");
            strSql.Append(" ) b on a.Id=b.CId where a.State=1 and a.IsDeleted=0 ");
            strSql.Append(" ) c;");

            return Repository().FindTableBySql(strSql.ToString());
        }




        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getcomponentinfo(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*   ");
            strSql.Append(" from cloud_componentlist a ");
            strSql.Append(" where  1=1  ");
            if (model.EquipmentId != null && model.EquipmentId != "")
            {
                strSql.Append(string.Format(" and a.ComponentId='{0}' ", model.EquipmentId));
            }
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" and a.Name like '%{0}%' ", model.Name));
            }
            strSql.Append(" )  a  ");
            strSql.Append(" where  IsDeleted=0  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetcomponentinfoCount(cloud_equipment model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append("select *  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from cloud_componentlist a ");
                strSql.Append(" where  1=1  ");
                if (model.EquipmentId != null && model.EquipmentId != "")
                {
                    strSql.Append(string.Format(" and a.ComponentId='{0}' ", model.EquipmentId));
                }
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" and a.Name like '%{0}%' ", model.Name));
                }
                strSql.Append(" )  a ) a; ");
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
        ///获取设备个数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getequipmentCount(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count( *) as equipmentCount  from  cloud_equipment ");
            strSql.Append(" where  1=1 ");
            strSql.Append(string.Format(" and Businesspeople='{0}' ", model.UserId));
            strSql.Append(" and (AgentUserId is null or AgentUserId ='' )");
            return Repository().FindTableBySql(strSql.ToString());
        }





        /// <summary>
        /// 查询自己及自己的代理 设备管理业务人员下拉框使用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable IandAgent(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select *  from ");
            strSql.Append(" ( ");
            if (model.Type == 2)
            {
                strSql.Append(" select a.*   ");
                strSql.Append(" from base_user a ");

                strSql.Append(" where 1=1 ");
                if (model.UserId != null && model.UserId != "")
                {
                    strSql.Append(string.Format(" and a.UserId='{0}' ", model.UserId));
                }

            }
            else
            {

                strSql.Append(" select * from base_user a  ");
                strSql.Append(" where 1=1 ");
                if (model.UserId != null && model.UserId != "")
                {
                    strSql.Append(string.Format(" and a.CreateUserId='{0}' ", model.UserId));
                }
                strSql.Append(" and a.IsAgent=0 ");
            }
            strSql.Append(" )  a  ");

            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 获取客户当前的设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getCousmentList(cloud_equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,c.url ,d.Name as modelname ");
            strSql.Append(" from  cloud_equipment a  ");
            strSql.Append(" left join  cloud_userequipment b on a.EquipmentId = b.EquipmentId ");
            strSql.Append(" left join base_file c on a.model= c.pid   ");
            strSql.Append("  left join cloud_equipmentmodel d on d.id = a.Model ");
            strSql.Append(" where 1=1 ");
            if (model.UserId != null && model.UserId != "")
            {
                strSql.Append(string.Format(" and b.UserId='{0}' ", model.UserId));
            }
            return Repository().FindTableBySql(strSql.ToString());
        }





    }

}