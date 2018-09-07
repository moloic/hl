
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_repairorderBLL
    {



        #region 代理查询工单列表
        /// <summary>
        /// 用户查询工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable DLGetUserOrderList(cloud_repairorder model);

        /// <summary>
        /// 用户查询工单信息条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DLGetUserOrderCount(cloud_repairorder model);

        #endregion

        #region 上传工单

        bool DLUpdate(cloud_repairorder model);

        #endregion



        #region 用户查询工单信息
        /// <summary>
        /// 用户查询工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetUserOrderList(cloud_repairorder model);

        /// <summary>
        /// 用户查询工单信息条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetUserOrderCount(cloud_repairorder model);

        #endregion

        //分页数据
        DataTable getPageList(cloud_repairorder model);
        //返回总条数
        int GetRecordCount(cloud_repairorder model);

        //List列表
        IList<cloud_repairorder> getcloud_repairorderList(cloud_repairorder model);
        //实体
        cloud_repairorder QueryObject(cloud_repairorder model);
        //新增
        bool Insert(cloud_repairorder model);
        //更新
        bool Update(cloud_repairorder model);
        //删除
        bool Delete(string DicsId);


        DataTable getuserlistorder(cloud_repairorder model);
        int GetUserListCount(cloud_repairorder model);

        //更该订单状态    
        bool Updateorderstate(cloud_repairorder model);
        //首页设备数
        DataTable getRepairorderCount(cloud_repairorder model);


        #region CRM获取国外工单信息
        /// <summary>
        /// 获取国外工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetCrmOrderList(cloud_repairorder model);

        /// <summary>
        /// 获取国外工单信息条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetCrmOrderListCount(cloud_repairorder model);

        #endregion


        /// <summary>
        /// 获取CRM角色的用户数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetCrmUserListCount(cloud_repairorder model);


    }

}