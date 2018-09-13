using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_equipmentmodelBLL
    {
        //分页数据
        DataTable getPageList(cloud_equipmentmodel model);
        //返回总条数
        int GetRecordCount(cloud_equipmentmodel model);

        //List列表
        IList<cloud_equipmentmodel> getcloud_equipmentmodelList(cloud_equipmentmodel model);
        //实体
        cloud_equipmentmodel QueryObject(cloud_equipmentmodel model);
        //新增
        bool Insert(cloud_equipmentmodel model);
        //更新
        bool Update(cloud_equipmentmodel model);
        //删除
        bool Delete(string DicsId);


    }
}
