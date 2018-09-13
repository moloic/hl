  
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
public interface Ibase_fileBLL
    {
    
    //分页数据
        DataTable getPageList(base_file model);
        //返回总条数
        int GetRecordCount(base_file model);

        //List列表
        IList<base_file> getbase_fileList(base_file model);
        //实体
        base_file QueryObject(base_file model);
        //新增
        bool Insert(base_file model);
        //更新
        bool Update(base_file model);
        //删除
        bool Delete(string DicsId);
    
    }

}