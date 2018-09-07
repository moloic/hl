using Hl.dotNet.Models;
using Hl.dotNet.Orm;
using Hl.dotNet.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.DataAccess
{
    public class base_menuDal : RepositoryFactory<base_menu>
    {

        public List<base_menu> GetList(base_menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select   *  from");
            strSql.Append(" (");
            strSql.Append(" select a.* from base_menu a");
            strSql.Append(" left join base_rolemenu b on a.MenuId = b.menuid");
            strSql.Append(" WHERE 1=1");

            if (!string.IsNullOrEmpty(model.MenuId))
            {
                strSql.Append(string.Format(" AND b.MenuId <> '{0}' ", model.MenuId));
            }
            if (!string.IsNullOrEmpty(model.RoleId))
            {
                strSql.Append(string.Format(" AND b.roleid in ({0}) ", model.RoleId));
            }

            strSql.Append(" group by a.MenuId");
            strSql.Append(" order by   a.MenuOrder asc");

            strSql.Append(" ) a");
            strSql.Append(" union");
            strSql.Append(" select a.* from base_menu a");
            strSql.Append(" left join base_usermenu b on a.MenuId = b.MenuId");
            strSql.Append(" WHERE 1=1");
            if (!string.IsNullOrEmpty(model.MenuId))
            {
                strSql.Append(string.Format(" AND b.MenuId <> '{0}' ", model.MenuId));
            }
            if (!string.IsNullOrEmpty(model.Id))
            {
                strSql.Append(string.Format(" AND b.UserId = '{0}' ", model.Id));
            }

            return Repository().FindListBySql(strSql.ToString());
        }

    }
}
