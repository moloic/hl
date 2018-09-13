
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_componentBLL
    {
        //分页数据
        DataTable getPageList(cloud_component model);
        //返回总条数
        int GetRecordCount(cloud_component model);

        //List列表
        IList<cloud_component> getcloud_componentList(cloud_component model);
        //实体
        cloud_component QueryObject(cloud_component model);
        //新增
        bool Insert(cloud_component model);
        //更新
        bool Update(cloud_component model);
        //删除
        bool Delete(string DicsId);


    }
}
