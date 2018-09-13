  
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
public interface Icloud_ordernodeBLL
    {
    
    //分页数据
        DataTable getPageList(cloud_ordernode model);
        //返回总条数
        int GetRecordCount(cloud_ordernode model);

        //List列表
        IList<cloud_ordernode> getcloud_ordernodeList(cloud_ordernode model);
        //实体
        cloud_ordernode QueryObject(cloud_ordernode model);
        //新增
        bool Insert(cloud_ordernode model);
        //更新
        bool Update(cloud_ordernode model);
        //删除
        bool Delete(string DicsId);
    
    }

}