
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
    public class cloud_systemparameterlogDal : RepositoryFactory<cloud_systemparameterlog>
    {



        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_systemparameterlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ");
            strSql.Append(" ( ");
            strSql.Append(" select ");
            strSql.Append(" a.* ,");
            strSql.Append(" b.RealName ,");
            strSql.Append(" c.name ");
            strSql.Append(" from  cloud_systemparameterlog a left join  base_user  b on a.UserId= b.UserId ");
            strSql.Append(" left join cloud_systemparameter c on c.id= a.cloud_systemparameterId ");
            strSql.Append(" where  1=1  ");
            if (model.RealName != null && model.RealName != "")
            {
                strSql.Append(string.Format(" and  b.RealName  like '%{0}%' ", model.RealName));
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
        public int GetRecordCount(cloud_systemparameterlog model)
        {
            int TotalItems = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select   count(1) as TotalItems  from ");
                strSql.Append(" ( ");
                strSql.Append(" select ");
                strSql.Append(" a.* ,");
                strSql.Append(" b.RealName ,");
                strSql.Append(" c.name ");
                strSql.Append(" from  cloud_systemparameterlog a left join  base_user  b on a.UserId= b.UserId ");
                strSql.Append(" left join cloud_systemparameter c on c.id= a.cloud_systemparameterId ");
                strSql.Append(" where  1=1  ");
                if (model.RealName != null && model.RealName != "")
                {
                    strSql.Append(string.Format(" and  b.RealName  like '%{0}%' ", model.RealName));
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
        public IList<cloud_systemparameterlog> getcloud_systemparameterlogList(cloud_systemparameterlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM cloud_systemparameterlog  a  WHERE 1=1");
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND a.Id = '{0}' ", model.Id));
            }
            strSql.Append(" ORDER BY a.CreateTime desc");
            return Repository().FindListBySql(strSql.ToString());
        }
    }
}
