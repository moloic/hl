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
    public class cloud_systemparameterDal : RepositoryFactory<cloud_systemparameter>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_systemparameter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select ");
            strSql.Append(" a.*, ");
            strSql.Append(" case a.effectivetime  when '0'  then '未启用' when  '1' then  '立即生效' else '未知' end as  effectivetimename,");
            strSql.Append(" b.fullname  as Equipmentfullname, ");
            strSql.Append(" c.fullname  as  DicsTypeName , ");
            strSql.Append(" d.Name as typeName ");
            strSql.Append(" from cloud_systemparameter a left join   base_dics b on a.EquipmentType = b.DicsId  ");
            strSql.Append(" left join  base_dics c on   a.`dicsid` = c.dicsid ");
            strSql.Append(" left join cloud_systemparametertype d on d.id = a.Type ");
            strSql.Append(" where  1=1  ");
            strSql.Append(" and  a.IsDeleted= 0  ");
            if (model.Name != null && model.Name != "")
            {
                strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
            }
            if (model.DicsId != null && model.DicsId != "")
            {
                strSql.Append(string.Format(" and  a.DicsId = '{0}' ", model.DicsId));
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
        public int GetRecordCount(cloud_systemparameter model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select ");
                strSql.Append(" a.*, ");
                strSql.Append(" b.fullname  as Equipmentfullname, ");
                strSql.Append(" c.fullname  as  DicsTypeName , ");
                strSql.Append(" d.Name as typeName ");
                strSql.Append(" from cloud_systemparameter a left join   base_dics b on a.EquipmentType = b.DicsId  ");
                strSql.Append(" left join  base_dics c on   a.`dicsid` = c.dicsid ");
                strSql.Append(" left join cloud_systemparametertype d on d.id = a.Type ");
                strSql.Append(" where  1=1  ");
                strSql.Append(" and  a.IsDeleted= 0  ");
                if (model.Name != null && model.Name != "")
                {
                    strSql.Append(string.Format(" and  a.Name  like '%{0}%' ", model.Name));
                }
                if (model.DicsId != null && model.DicsId != "")
                {
                    strSql.Append(string.Format(" and  a.DicsId = '{0}' ", model.DicsId));
                }

                strSql.Append(" order by a.CreateTime desc ");
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
        public IList<cloud_systemparameter> getcloud_systemparameterList(cloud_systemparameter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_systemparameter a  WHERE 1=1");
            strSql.Append(" and  a.IsDeleted= 0  ");
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateTime desc");
            return Repository().FindListBySql(strSql.ToString());
        }


        //增加
        public bool Insert(cloud_systemparameter model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" INSERT INTO `cloud_systemparameter` ");
                strSql.Append(" ( ");
                strSql.Append("`Id`,");
                strSql.Append("`Code`,");
                strSql.Append("`Name`,");
                strSql.Append("`ConVal`,");
                strSql.Append("`Conunit`,");
                strSql.Append("`EffectiveTime`,");
                strSql.Append("`Remark`,");
                strSql.Append("`EquipmentType`,");
                strSql.Append("`DicsId`,");
                strSql.Append("`Type`,");
                strSql.Append(" `IsDeleted`,  ");
                strSql.Append("`CreateTime`");
                strSql.Append("  ) ");
                strSql.Append(" VALUES  ");
                strSql.Append(" (  ");
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.Code));
                strSql.Append(string.Format(" '{0}', ", model.Name));
                strSql.Append(string.Format(" '{0}', ", model.ConVal));
                strSql.Append(string.Format(" '{0}' ,", model.Conunit));
                strSql.Append(string.Format(" '{0}', ", model.EffectiveTime));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}', ", model.EquipmentType));
                strSql.Append(string.Format(" '{0}', ", model.DicsId));
                strSql.Append(string.Format(" '{0}', ", model.Type));
                strSql.Append(string.Format(" '{0}', ", 0));
                strSql.Append(string.Format(" '{0}'", model.CreateTime));
                strSql.Append("   );  ");

                //写入历史
                strSql.Append(" INSERT INTO `cloud_systemparameterlog` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `cloud_systemparameterId`, ");
                strSql.Append(" `UserId`, ");
                strSql.Append(" `Oldvalue`, ");
                strSql.Append(" `NewValue`,  ");
                strSql.Append(" `CreateTime` ");
                strSql.Append("  ) ");
                strSql.Append("VALUES ");
                strSql.Append("( ");
                strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid)); //Guid 已经封装完毕));
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.UserId));
                strSql.Append(string.Format(" '{0}' ,", "新增操作原有值："));
                strSql.Append(string.Format(" '{0}', ", "新增之后最新值：Code:" + model.Code + " Name:" + model.Name + " ConVal:" + model.ConVal + " Conunit:" + model.Conunit + " EffectiveTime:" + model.EffectiveTime + " Remark:" + model.Remark + " EquipmentType:" + model.EquipmentType + " DicsId:" + model.DicsId + " Type:" + model.Type));
                strSql.Append(string.Format(" '{0}'", DateTime.Now));
                strSql.Append(" ); ");


            }
            i = Repository().InsertBySql(strSql.ToString(), isOpenTrans);//isOpenTrans(不需要事务的时候就传入null)
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
        ///  更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_systemparameter oldmodel, cloud_systemparameter model)
        {

            //带事务的更新(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {
                strSql.Append(" update cloud_systemparameter  ");
                strSql.Append(" SET  ");
                strSql.Append(string.Format(" Code = '{0}', ", model.Code));
                strSql.Append(string.Format(" Name = '{0}' ,", model.Name));
                strSql.Append(string.Format(" ConVal = '{0}', ", model.ConVal));
                strSql.Append(string.Format(" Conunit = '{0}', ", model.Conunit));
                strSql.Append(string.Format(" EffectiveTime = '{0}', ", model.EffectiveTime));
                strSql.Append(string.Format(" Remark = '{0}', ", model.Remark));
                strSql.Append(string.Format(" DicsId = '{0}', ", model.DicsId));
                strSql.Append(string.Format(" Type = '{0}', ", model.Type));
                strSql.Append(string.Format(" EquipmentType = '{0}' ", model.EquipmentType));
                strSql.Append(" where  ");
                strSql.Append(string.Format(" Id = '{0}' ; ", model.Id));
                //

                //写入历史
                strSql.Append(" INSERT INTO `cloud_systemparameterlog` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `cloud_systemparameterId`, ");
                strSql.Append(" `UserId`, ");
                strSql.Append(" `Oldvalue`, ");
                strSql.Append(" `NewValue`,  ");
                strSql.Append(" `CreateTime` ");
                strSql.Append("  ) ");
                strSql.Append("VALUES ");
                strSql.Append("( ");
                strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid)); //Guid 已经封装完毕));
                strSql.Append(string.Format(" '{0}', ", model.Id));
                strSql.Append(string.Format(" '{0}', ", model.UserId));
                strSql.Append(string.Format(" '{0}' ,", "更新操作原有值：Code:" + oldmodel.Code + " Name:" + oldmodel.Name + " ConVal:" + oldmodel.ConVal + " Conunit:" + oldmodel.Conunit + " EffectiveTime:" + oldmodel.EffectiveTime + " Remark:" + oldmodel.Remark + " EquipmentType:" + oldmodel.EquipmentType + " DicsId:" + oldmodel.DicsId + " Type:" + oldmodel.Type));
                strSql.Append(string.Format(" '{0}', ", "更新之后最新值：Code:" + model.Code + " Name:" + model.Name + " ConVal:" + model.ConVal + " Conunit:" + model.Conunit + " EffectiveTime:" + model.EffectiveTime + " Remark:" + model.Remark + " EquipmentType:" + model.EquipmentType + " DicsId:" + model.DicsId + " Type:" + model.Type));
                strSql.Append(string.Format(" '{0}'", DateTime.Now));
                strSql.Append(" ); ");





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
        public bool Delete(List<cloud_systemparameter> List)
        {
            //带事务的增加(当有复杂层级关系修改时候用到事物在放开，单表操作不需要事物)
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();

            foreach (cloud_systemparameter oldmodel in List)
            {
                // strSql.Append("  delete from cloud_systemparameter ");
                strSql.Append("    update  cloud_systemparameter  set IsDeleted=1  ");
                strSql.Append(" where ");
                strSql.Append(string.Format(" Id = '{0}' ;", oldmodel.Id));


                //写入历史
                strSql.Append(" INSERT INTO `cloud_systemparameterlog` ");
                strSql.Append(" ( ");
                strSql.Append(" `Id`, ");
                strSql.Append(" `cloud_systemparameterId`, ");
                strSql.Append(" `UserId`, ");
                strSql.Append(" `Oldvalue`, ");
                strSql.Append(" `NewValue`,  ");
                strSql.Append(" `CreateTime` ");
                strSql.Append("  ) ");
                strSql.Append("VALUES ");
                strSql.Append("( ");
                strSql.Append(string.Format(" '{0}', ", CommonHelper.GetGuid)); //Guid 已经封装完毕));
                strSql.Append(string.Format(" '{0}', ", oldmodel.Id));
                strSql.Append(string.Format(" '{0}', ", ManageProvider.Provider.Current().UserId.ToString()));
                strSql.Append(string.Format(" '{0}' ,", "删除操作原有值：Code:" + oldmodel.Code + " Name:" + oldmodel.Name + " ConVal:" + oldmodel.ConVal + " Conunit:" + oldmodel.Conunit + " EffectiveTime:" + oldmodel.EffectiveTime + " Remark:" + oldmodel.Remark + " EquipmentType:" + oldmodel.EquipmentType + " DicsId:" + oldmodel.DicsId + " Type:" + oldmodel.Type));
                strSql.Append(string.Format(" '{0}', ", "删除操作"));
                strSql.Append(string.Format(" '{0}'", DateTime.Now));
                strSql.Append(" ); ");

            }


            i = Repository().DeleteBySql(strSql.ToString(), isOpenTrans);//isOpenTrans(不需要事务的时候就传入null)
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






    }
}
