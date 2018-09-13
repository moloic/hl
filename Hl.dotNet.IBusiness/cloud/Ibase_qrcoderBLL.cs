
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Ibase_qrcoderBLL
    {
        //分页数据
        DataTable getPageList(base_qrcoder model);
        //返回总条数
        int GetRecordCount(base_qrcoder model);

        //List列表
        IList<base_qrcoder> getbase_qrcoderList(base_qrcoder model);
        //实体
        base_qrcoder QueryObject(base_qrcoder model);
        //新增
        bool Insert(base_qrcoder model);
        //更新
        bool Update(base_qrcoder model);
        //删除
        bool Delete(string DicsId);


    }
}
