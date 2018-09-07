
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
    public class cloud_equipmentstatusDal : RepositoryFactory<cloud_equipmentstatus>
    {




        //list列表
        public IList<cloud_equipmentstatus> getcloud_equipmentstatusList(cloud_equipmentstatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from  cloud_equipmentstatus a where 1=1 ");
            if (!string.IsNullOrEmpty(model.EquipmentId))
            {
                strSql.Append(string.Format(" AND a.EquipmentId = '{0}' ", model.EquipmentId));
            }
            strSql.Append("  order by CreateTime desc  limit 0,1  ; ");
            return Repository().FindListBySql(strSql.ToString());
        }

    }
}
