
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
    public class cloud_equipmentStatusmodelDal : RepositoryFactory<cloud_equipmentStatusmodel>
    {


        /// <summary>
        /// 加载地图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<cloud_equipmentStatusmodel> getMyequipmentShow(cloud_equipmentStatusmodel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from cloud_equipment a ");
            strSql.Append(" where 1=1 ");
            strSql.Append(string.Format(" and a.Businesspeople='{0}' ; ", model.UserId));
            return Repository().FindListBySql(strSql.ToString());
        }

     

    }
}
