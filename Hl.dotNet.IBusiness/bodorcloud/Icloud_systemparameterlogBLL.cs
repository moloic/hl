
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_systemparameterlogBLL
    {
        //分页数据
        DataTable getPageList(cloud_systemparameterlog model);
        //返回总条数
        int GetRecordCount(cloud_systemparameterlog model);

        //List列表
        IList<cloud_systemparameterlog> getcloud_systemparameterlogList(cloud_systemparameterlog model);
        //实体
        cloud_systemparameterlog QueryObject(cloud_systemparameterlog model);
     


    }
}
