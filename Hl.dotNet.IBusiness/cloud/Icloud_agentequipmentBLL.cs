  
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
public interface Icloud_agentequipmentBLL
    {
    
    //分页数据
        DataTable getPageList(cloud_agentequipment model);
        //返回总条数
        int GetRecordCount(cloud_agentequipment model);

        //List列表
        IList<cloud_agentequipment> getcloud_agentequipmentList(cloud_agentequipment model);
        //实体
        cloud_agentequipment QueryObject(cloud_agentequipment model);
        //新增
        bool Insert(cloud_agentequipment model);
        //更新
        bool Update(cloud_agentequipment model);
        //删除
        bool Delete(string EquipmentId,string UserId);

        bool Agentupdate(cloud_agentequipment model);
    
    }

}