using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_componetmessageBLL
    {
        //分页数据
        DataTable getPageList(cloud_componetmessage model);
        //返回总条数
        int GetRecordCount(cloud_componetmessage model);

        //List列表
        IList<cloud_componetmessage> getcloud_componetmessageList(cloud_componetmessage model);
        //实体
        cloud_componetmessage QueryObject(cloud_componetmessage model);
        //新增
        bool Insert(cloud_componetmessage model);
        //更新
        bool Update(cloud_componetmessage model);
        //删除
        bool Delete(string DicsId);
        //批量增加
        bool InsertList(List<cloud_componetmessage> list);
        //我的推送信息
        DataTable getMyMessagePageList(cloud_componetmessage model);
        //分页
        int GetMyMessageRecordCount(cloud_componetmessage model);

        //邮件信息
        DataTable getMessageList(cloud_componetmessage model);

    }
}
