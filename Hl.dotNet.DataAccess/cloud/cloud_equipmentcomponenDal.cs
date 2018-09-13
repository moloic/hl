
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
    public class cloud_equipmentcomponenDal : RepositoryFactory<cloud_equipmentcomponen>
    {

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_equipmentcomponen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*   ");
            strSql.Append(" from cloud_equipmentcomponen a ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.EquipmentId))
            {
                strSql.Append(string.Format(" AND a.EquipmentId = '{0}' ", model.EquipmentId));
            }
            strSql.Append(" )  a  ");
            //strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_equipmentcomponen model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select a.*   ");
                strSql.Append(" from cloud_equipmentcomponen a ");
                strSql.Append(" where  1=1  ");
                if (!string.IsNullOrEmpty(model.EquipmentId))
                {
                    strSql.Append(string.Format(" AND a.EquipmentId = '{0}' ", model.EquipmentId));
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
        public IList<cloud_equipmentcomponen> getcloud_equipmentcomponenList(cloud_equipmentcomponen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_equipmentcomponen  a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.DicsId = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateDate desc");
            return Repository().FindListBySql(strSql.ToString());
        }

        //增加
        public bool Insert(cloud_equipmentcomponen model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_equipmentcomponen` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `EquipmentId`, ");
                strSql.Append(" `component` ");


                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" '{0}' ", model.component));

                strSql.Append("   );  ");
            }
            i = Repository().InsertBySql(strSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;
                // 查询是否有保养信息
                DataTable dt = getifinfo(model);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //添加零件信息
                    Insertrepairrecord(model, dt);
                }
            }
            else
            {
                // database.Rollback();
            }
            return isok;
        }

        /// <summary>
        /// 查询是否有保养信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getifinfo(cloud_equipmentcomponen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select a.*   ");
            strSql.Append(" from cloud_componentrepairrecord a ");
            strSql.Append(" where  1=1  ");
            if (!string.IsNullOrEmpty(model.EquipmentId))
            {
                strSql.Append(string.Format(" AND a.EquipmentId = '{0}' ", model.EquipmentId));
            }
            strSql.Append(" )  a  ");
            //strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 添加保养信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insertrepairrecord(cloud_equipmentcomponen model, DataTable data)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();

            int i = 0;
            bool isok = false;
            StringBuilder strinserSql = new StringBuilder();
            if (model != null)
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
                //OrderStr
                strinserSql.Append("  ) ");
                strinserSql.Append(" VALUES  ");
                strinserSql.Append(" (  ");
                strinserSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid));//主键    
                strinserSql.Append(string.Format(" '{0}', ", model.component));//零件ID
                strinserSql.Append(string.Format(" '{0}', ", DateTime.Now));//保养开始时间
                strinserSql.Append(string.Format(" '{0}', ", DateTime.Now.AddDays(Convert.ToDouble(model.OrderStr))));//下一次保养时间
                strinserSql.Append(string.Format(" '{0}', ", DateTime.Now));//创建时间
                strinserSql.Append(string.Format(" '{0}', ", model.EquipmentId));//设备ID
                strinserSql.Append(string.Format(" '{0}' ", data.Rows[0]["CustomerId"]));//用户ID
                strinserSql.Append("   );  ");
            }
            i = Repository().InsertBySql(strinserSql.ToString(), null);//isOpenTrans(不需要事务的时候就传入null)
            if (i > 0)
            {
                isok = true;

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
        public bool Update(cloud_equipmentcomponen model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {

                strSql.Append(" update cloud_equipmentcomponen  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Id = '{0}', ", model.Id));
                strSql.Append(string.Format(" EquipmentId = '{0}', ", model.EquipmentId));
                strSql.Append(string.Format(" component = '{0}', ", model.component));

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
        public bool Delete(string DicsId, string EID)
        {
            //带事务的增加(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            //  IDatabase database = DataFactory.Database();
            //  DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from cloud_equipmentcomponen ");
            strSql.Append(" where ");
            strSql.Append(string.Format(" component =  '{0}'  ", DicsId));
            strSql.Append(string.Format(" and EquipmentId =  '{0}'  ", EID));
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