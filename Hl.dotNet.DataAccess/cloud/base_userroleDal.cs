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
    public class base_userroleDal : RepositoryFactory<base_userrole>
    {

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insertuserrole(base_userrole models)
        {

            //带事务的增加
            StringBuilder strSql = new StringBuilder();
            string Modelname = "";
            object Modelvalue = "";
            bool isok = false;
            try
            {

                int istrue = Repository().Insert(models);
                //int istrue = Repository().ExecuteBySql(strSql);
                if (istrue > 0)
                {
                    isok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isok;
        }


    }
}
