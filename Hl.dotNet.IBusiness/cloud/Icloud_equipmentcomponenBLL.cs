  
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
public interface Icloud_equipmentcomponenBLL
    {
    
    //分页数据
        DataTable getPageList(cloud_equipmentcomponen model);
        //返回总条数
        int GetRecordCount(cloud_equipmentcomponen model);

        //List列表
        IList<cloud_equipmentcomponen> getcloud_equipmentcomponenList(cloud_equipmentcomponen model);
        //实体
        cloud_equipmentcomponen QueryObject(cloud_equipmentcomponen model);
        //新增
        bool Insert(cloud_equipmentcomponen model);
        //更新
        bool Update(cloud_equipmentcomponen model);
        //删除
        bool Delete(string DicsId, string EID);
    
    }

}