
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_workpersonnelBLL
    {


        DataTable ZGGetDirectorOrderList(cloud_workpersonnel model);
        //返回总条数
        int ZGGetDirectorCount(cloud_workpersonnel model);

        #region 主管查询订单列表
        /// <summary>
        /// 查看订单详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetDirectorOrderListInfo(cloud_workpersonnel model);

        DataTable GetDirectorOrderList(cloud_workpersonnel model);
        //返回总条数
        int GetDirectorCount(cloud_workpersonnel model);
        
        #endregion

        bool CRMInsertwork(cloud_workpersonnel model);

        DataTable getderuserList(cloud_workpersonnel model);
        //返回总条数
        int GetderuserCount(cloud_workpersonnel model);


        //分页数据
        DataTable getPageList(cloud_workpersonnel model);
        //返回总条数
        int GetRecordCount(cloud_workpersonnel model);

        //List列表
        IList<cloud_workpersonnel> getcloud_workpersonnelList(cloud_workpersonnel model);
        //实体
        cloud_workpersonnel QueryObject(cloud_workpersonnel model);
        //新增
        bool Insert(cloud_workpersonnel model);
        //更新
        bool Update(cloud_workpersonnel model);
        //删除
        bool Delete(string DicsId);


        int GetUserOrderCount(cloud_workpersonnel model);


        bool UpdateOrderState(cloud_workpersonnel model);
    }

}