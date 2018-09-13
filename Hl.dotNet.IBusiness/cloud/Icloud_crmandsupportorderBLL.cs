
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_crmandsupportorderBLL
    {

        DataTable getCRMInfoList(cloud_crmandsupportorder model);

        //分页数据
        DataTable getPageList(cloud_crmandsupportorder model);
        //返回总条数
        int GetRecordCount(cloud_crmandsupportorder model);

        //List列表
        IList<cloud_crmandsupportorder> getcloud_crmandsupportorderList(cloud_crmandsupportorder model);
        //实体
        cloud_crmandsupportorder QueryObject(cloud_crmandsupportorder model);
        //新增
        bool Insert(cloud_crmandsupportorder model);
        //更新
        bool Update(cloud_crmandsupportorder model);

        bool ManUpdateorder(cloud_crmandsupportorder model);
        //删除
        bool Delete(string DicsId);
        //计算历史月份
        DataTable getmonthsList(cloud_crmandsupportorder model);

        /// <summary>
        /// 昨日统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable getYearDaysList(cloud_crmandsupportorder model);
        //按日统计
        DataTable getdaysList(cloud_crmandsupportorder model);

    }

}