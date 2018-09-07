using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface IBase_DicsBLLDemo
    {

        /// <summary>
        /// 1.获取List集合不带参数
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        IList<Base_DicsModel> getList(Base_DicsModel _model);
        IList<Base_DicsModel> GetListParm(Base_DicsModel _model);
        DataTable getbase_dicsQuery(Base_DicsModel model);
        Base_DicsModel getEntityModel(Base_DicsModel model);
        bool Insert(Base_DicsModel model);
        bool Update(Base_DicsModel model);
        bool Delete(Base_DicsModel model);
        

    }
}
