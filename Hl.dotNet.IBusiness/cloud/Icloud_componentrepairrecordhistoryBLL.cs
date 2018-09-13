using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_componentrepairrecordhistoryBLL
    {
        //分页数据
        DataTable getPageList(cloud_componentrepairrecordhistory model);
        //返回总条数
        int GetRecordCount(cloud_componentrepairrecordhistory model);

        //List列表
        IList<cloud_componentrepairrecordhistory> getcloud_componentrepairrecordhistoryList(cloud_componentrepairrecordhistory model);
        //实体
        cloud_componentrepairrecordhistory QueryObject(cloud_componentrepairrecordhistory model);
        //新增
        bool Insert(cloud_componentrepairrecordhistory model);
        //更新
        bool Update(cloud_componentrepairrecordhistory model);
        //删除
        bool Delete(string DicsId);

    }
}
