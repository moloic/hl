using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_alarmBLL
    {
        //分页数据
        DataTable getPageList(cloud_alarm model);
        //返回总条数
        int GetRecordCount(cloud_alarm model);

        //List列表
        IList<cloud_alarm> getcloud_alarmList(cloud_alarm model);
        //实体
        cloud_alarm QueryObject(cloud_alarm model);

        //更新
        bool Update(cloud_alarm model);

        //报警个数
        DataTable getalarmCount(cloud_alarm model);

    }
}
