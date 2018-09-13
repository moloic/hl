
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_equipmentBLL
    {

        DataTable getagentPageList(cloud_equipment model);
        //返回总条数
        int GetAgentPageCount(cloud_equipment model);


        //获取零件分类信息
        DataTable getcomponentList(cloud_equipment model);

        DataTable getcomponentinfo(cloud_equipment model);
        int GetcomponentinfoCount(cloud_equipment model);
        //查询用户下设备详情
        DataTable getuserequipment(cloud_equipment model);
        //分页数据
        DataTable getPageList(cloud_equipment model);
        //返回总条数
        int GetRecordCount(cloud_equipment model);

        //List列表
        IList<cloud_equipment> getcloud_equipmentList(cloud_equipment model);
        //实体
        cloud_equipment QueryObject(cloud_equipment model);
        //新增
        bool Insert(cloud_equipment model);
        //更新
        bool Update(cloud_equipment model);
        //删除
        bool Delete(string DicsId);
        //获取设备个数
        DataTable getequipmentCount(cloud_equipment model);
        /// <summary>
        /// 查询自己及自己的代理 设备管理业务人员下拉框使用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable IandAgent(cloud_equipment model);

        /// <summary>
        /// 客户首页设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable getCousmentList(cloud_equipment model);

    }

}