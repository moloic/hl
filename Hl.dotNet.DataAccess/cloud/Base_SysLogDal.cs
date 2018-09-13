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
    public class Base_SysLogDal : RepositoryFactory<Base_SysLog>
    {
        //增加
        public bool Insert(Base_SysLog model)
        {
            //带事务的增加(当有复杂层级关系保存时候用到事物在放开，单表操作不需要事物)
            // IDatabase database = DataFactory.Database();
            //DbTransaction isOpenTrans = database.BeginTrans();
            int i = 0;
            bool isok = false;
            StringBuilder strSql = new StringBuilder();
            if (model != null)
            {

                strSql.Append(" INSERT INTO `base_syslog` ");
                strSql.Append(" (  ");
                strSql.Append(" `SysLogId`,  ");
                strSql.Append(" `ObjectId`,  ");
                strSql.Append(" `LogType`,  ");
                strSql.Append(" `IPAddress`,  ");
                strSql.Append(" `CompanyId`,  ");
                strSql.Append(" `DepartmentId`, ");
                strSql.Append(" `UserId`, ");
                strSql.Append(" `SqlText`, ");
                strSql.Append(" `Remark`, ");
                strSql.Append(" `CreateDate` ");
                strSql.Append("  ) ");
                strSql.Append(" VALUES ");
                strSql.Append(" ( ");
                strSql.Append(string.Format(" '{0}', ", model.SysLogId));
                strSql.Append(string.Format(" '{0}', ", model.ObjectId));
                strSql.Append(string.Format(" '{0}', ", model.LogType));
                strSql.Append(string.Format(" '{0}', ", model.IPAddress));
                strSql.Append(string.Format(" '{0}', ", model.CompanyId));
                strSql.Append(string.Format(" '{0}', ", model.DepartmentId));
                strSql.Append(string.Format(" '{0}', ", model.CreateUserId));
                strSql.Append(string.Format(" '{0}', ", model.SqlText));
                strSql.Append(string.Format(" '{0}', ", model.Remark));
                strSql.Append(string.Format(" '{0}' ", model.CreateDate));
                strSql.Append(" );");
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
    }
}
