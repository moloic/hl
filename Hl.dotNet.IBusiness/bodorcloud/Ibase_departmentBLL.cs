
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Ibase_departmentBLL
    {



        DataTable GetDeparpeopleOrderNum(base_department model);

        /// <summary>
        /// 获取部门下人员总销售额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetDeparUserOrderNumtotal(base_department model);


        /// <summary>
        /// 获取部门下各人员上/本季度销售额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetDeparUserOrderNum(base_department model);


        DataTable getQBdatatable(base_department model);
        /// <summary>
        ///查询上季度及本季度销售情况 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable getdatatableList(base_department model);
        //分页数据
        DataTable getPageList(base_department model);
        //返回总条数
        int GetRecordCount(base_department model);

        //List列表
        IList<base_department> getbase_departmentList(base_department model);
        //实体
        base_department QueryObject(base_department model);
        //新增
        bool Insert(base_department model);
        //更新
        bool Update(base_department model);
        //删除
        bool Delete(string DicsId);

    }

}