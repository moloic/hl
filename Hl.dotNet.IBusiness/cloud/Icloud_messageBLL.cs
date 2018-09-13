using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hl.dotNet.IBusiness
{
    public interface Icloud_messageBLL
    {
        //分页数据
        DataTable getPageList(cloud_message model);
        //返回总条数
        int GetRecordCount(cloud_message model);

        //List列表
        IList<cloud_message> getcloud_messageList(cloud_message model);
        //实体
        cloud_message QueryObject(cloud_message model);
        //新增
        bool Insert(cloud_message model);
        //更新
        bool Update(cloud_message model);
        //删除
        bool Delete(string DicsId);
        //消息个数
        DataTable geteMessageCount(cloud_message model);
    }
}
