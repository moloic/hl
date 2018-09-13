
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_systemparametertypeBLL
    {
        //分页数据
        DataTable getPageList(cloud_systemparametertype model);
        //返回总条数
        int GetRecordCount(cloud_systemparametertype model);

        //List列表
        IList<cloud_systemparametertype> getcloud_systemparametertypeList(cloud_systemparametertype model);
        //实体
        cloud_systemparametertype QueryObject(cloud_systemparametertype model);
        //新增
        bool Insert(cloud_systemparametertype model);
        //更新
        bool Update(cloud_systemparametertype model);
        //删除
        bool Delete(string DicsId);


    }
}
