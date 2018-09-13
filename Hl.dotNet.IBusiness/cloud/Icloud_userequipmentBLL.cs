
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_userequipmentBLL
    {

        DataTable getuserPageList(cloud_userequipment model);

        int GetuserRecordCount(cloud_userequipment model);

        //分页数据
        DataTable getPageList(cloud_userequipment model);
        //返回总条数
        int GetRecordCount(cloud_userequipment model);

        //List列表
        IList<cloud_userequipment> getcloud_userequipmentList(cloud_userequipment model);
        //实体
        cloud_userequipment QueryObject(cloud_userequipment model);
        //新增
        bool Insert(cloud_userequipment model);
        //更新
        bool Update(cloud_userequipment model);
        //删除
        bool Delete(string EquipmentId, string UserId);

    }

}