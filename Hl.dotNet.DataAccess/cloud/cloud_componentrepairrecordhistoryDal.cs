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
    public class cloud_componentrepairrecordhistoryDal : RepositoryFactory<cloud_componentrepairrecordhistory>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_componentrepairrecordhistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select   ");
            strSql.Append(" a.id, ");
            strSql.Append(" a.Cloud_componentId, ");
            strSql.Append(" b.bomcode, ");
            strSql.Append(" b.Name, ");
            strSql.Append(" c.RealName, ");
            strSql.Append(" a.CreateTime,a.HistoryTime,a.NextTime, e.OrderNumber, e.name as equipmentname ");
            strSql.Append(" from  cloud_componentrepairrecordhistory  a ");
            strSql.Append(" left join cloud_componentlist b on a.Cloud_componentId = b.Id ");
            strSql.Append(" left join base_user c on c.UserId= a.userid ");
            strSql.Append(" left join cloud_equipmentcomponen  d on d.component= b.id  ");
            strSql.Append(" left join cloud_equipment e on e.EquipmentId= d.EquipmentId and a.Cloud_componentId=d.component  ");
            strSql.Append(" where  1=1  ");

            if (model.UserId != null && model.UserId != "")
            {
                strSql.Append(string.Format("   and a.userid ='{0}'", model.UserId));
            }
            if (model.Cloud_componentId != null && model.Cloud_componentId != "")
            {
                strSql.Append(string.Format("  and b.id ='{0}'", model.Cloud_componentId));
            }
            if (model.EquipmentId != null && model.EquipmentId != "")
            {
                strSql.Append(string.Format("   and e.EquipmentId ='{0}'", model.EquipmentId));
            }
            strSql.Append(" order by a.CreateTime desc ");
            strSql.Append(" )  a  ");
            strSql.Append("limit " + model.PrevPageNums + "," + model.TopNums + "; ");
            return Repository().FindTableBySql(strSql.ToString());
        }


        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="_Model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_componentrepairrecordhistory model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select   ");
                strSql.Append(" a.id, ");
                strSql.Append(" a.Cloud_componentId, ");
                strSql.Append(" b.bomcode, ");
                strSql.Append(" b.Name, ");
                strSql.Append(" c.RealName, ");
                strSql.Append(" a.CreateTime,a.HistoryTime,a.NextTime, e.OrderNumber, e.name as equipmentname ");
                strSql.Append(" from  cloud_componentrepairrecordhistory  a ");
                strSql.Append(" left join cloud_componentlist b on a.Cloud_componentId = b.Id ");
                strSql.Append(" left join base_user c on c.UserId= a.userid ");
                strSql.Append(" left join cloud_equipmentcomponen  d on d.component= b.id  ");
                strSql.Append(" left join cloud_equipment e on e.EquipmentId= d.EquipmentId and a.Cloud_componentId=d.component  ");
                strSql.Append(" where  1=1  ");

                if (model.UserId != null && model.UserId != "")
                {
                    strSql.Append(string.Format("   and a.userid ='{0}'", model.UserId));
                }
                if (model.Cloud_componentId != null && model.Cloud_componentId != "")
                {
                    strSql.Append(string.Format("  and b.id ='{0}'", model.Cloud_componentId));
                }
                if (model.EquipmentId != null && model.EquipmentId != "")
                {
                    strSql.Append(string.Format("   and e.EquipmentId ='{0}'", model.EquipmentId));
                }

                strSql.Append(" order by a.CreateTime desc ");
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
        public IList<cloud_componentrepairrecordhistory> getcloud_componentrepairrecordhistoryList(cloud_componentrepairrecordhistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_componentrepairrecordhistory a  WHERE 1=1");

            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateTime desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_componentrepairrecordhistory model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_componentrepairrecordhistory` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `Cloud_componentId`, ");
                strSql.Append(" `UserId`, ");
                strSql.Append(" `CreateTime`  ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.Cloud_componentId));
                strSql.Append(string.Format(" '{0}', ", model.UserId));
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
        public bool Update(cloud_componentrepairrecordhistory model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            // DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_componentrepairrecordhistory  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Cloud_componentId = '{0}', ", model.Cloud_componentId));
                strSql.Append(string.Format(" UserId = '{0}', ", model.UserId));
                strSql.Append(string.Format(" CreateTime = '{0}' ", model.CreateTime));

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
            strSql.Append("  delete from cloud_componentrepairrecordhistory ");
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
