using Hl.dotNet.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Ibase_dicsBLL
    {

        //分页数据
        DataTable getPageList(Base_DicsModel model);
        //返回总条数
        int GetRecordCount(Base_DicsModel model);

        //List列表
        IList<Base_DicsModel> getbase_dicsList(Base_DicsModel model);
        //实体
        Base_DicsModel QueryObject(Base_DicsModel model);
        //新增
        bool Insert(Base_DicsModel model);
        //更新
        bool Update(Base_DicsModel model);
        //删除
        bool Delete(string DicsId);
        //下拉
        DataTable getDiccategory(Base_DicsModel model);

        /// <summary>
        /// 获取下拉框（公用）
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        DataTable getDropdownval(Hashtable ht);

        DataTable getDicsTable(Base_DicsModel model);
    }
}
