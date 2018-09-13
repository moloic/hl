using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_helpinfoBLL
    {
        //分页数据
        DataTable getPageList(cloud_helpinfo model);
        //返回总条数
        int GetRecordCount(cloud_helpinfo model);

        //List列表
        IList<cloud_helpinfo> getcloud_helpinfoList(cloud_helpinfo model);
        //实体
        cloud_helpinfo QueryObject(cloud_helpinfo model);
        //新增
        bool Insert(cloud_helpinfo model);
        //更新
        bool Update(cloud_helpinfo model);
        //删除
        bool Delete(string DicsId);


    }
}
