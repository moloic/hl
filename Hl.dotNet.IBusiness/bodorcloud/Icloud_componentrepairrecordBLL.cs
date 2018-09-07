using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_componentrepairrecordBLL
    {
        //分页数据
        DataTable getPageList(cloud_componentrepairrecord model);
        //返回总条数
        int GetRecordCount(cloud_componentrepairrecord model);

        //List列表
        IList<cloud_componentrepairrecord> getcloud_componentrepairrecordList(cloud_componentrepairrecord model);
        //实体
        cloud_componentrepairrecord QueryObject(cloud_componentrepairrecord model);
        //新增
        bool Insert(cloud_componentrepairrecord model);
        //更新
        bool Update(cloud_componentrepairrecord model,cloud_componentrepairrecordhistory  modelhistory);
        //删除
        bool Delete(string DicsId);

    }
}
