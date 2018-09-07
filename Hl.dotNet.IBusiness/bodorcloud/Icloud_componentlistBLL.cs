using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_componentlistBLL
    {
        //分页数据
        DataTable getPageList(cloud_componentlist model);
        //返回总条数
        int GetRecordCount(cloud_componentlist model);

        //List列表
        IList<cloud_componentlist> getcloud_componentlistList(cloud_componentlist model);
        //实体
        cloud_componentlist QueryObject(cloud_componentlist model);
        //新增
        bool Insert(cloud_componentlist model);
        //更新
        bool Update(cloud_componentlist model);
        //删除
        bool Delete(string DicsId);
        //下拉
        DataTable getDiccategory(cloud_componentlist model);

    }
}
