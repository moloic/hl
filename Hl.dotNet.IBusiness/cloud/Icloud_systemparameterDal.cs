using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_systemparameterBLL
    {
        //分页数据
        DataTable getPageList(cloud_systemparameter model);
        //返回总条数
        int GetRecordCount(cloud_systemparameter model);

        //List列表
        IList<cloud_systemparameter> getcloud_systemparameterList(cloud_systemparameter model);
        //实体
        cloud_systemparameter QueryObject(cloud_systemparameter model);
        //新增
        bool Insert(cloud_systemparameter model);
        //更新
        bool Update(cloud_systemparameter oldmodel,cloud_systemparameter model);
        //删除
        bool Delete(string DicsId);

    }
}
