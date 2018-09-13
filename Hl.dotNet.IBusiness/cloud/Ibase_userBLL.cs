using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Ibase_userBLL
    {

        #region 售后获取首页信息 月份 工单总量 好评量 完成量
        DataTable getAftersaleQuery(base_user model);
        #endregion

        #region 主管获取首页信息 月份 工单总量 好评量 完成量
        DataTable DergetAftersaleQuery(base_user model);
        #endregion

        #region 售后查询上月评价量
        DataTable getPJQuery(base_user model);
        #endregion



        bool CRMUpdateIsReceive(base_user model);

        base_user getEntityModel(base_user model);

        string getbase_userroleQuery(base_user model);

        bool getuserEmail(base_user model);

        bool getuserAccount(base_user model);

        bool getuserMobile(base_user model);

        bool Insertuserinfo(base_user model);


        #region 代理SQL

        DataTable getAgentUserPageList(base_user model);
        //返回总条数
        int GetAgentUserCount(base_user model);

        #endregion


        #region 动软生成代码


        //分页数据
        DataTable getPageList(base_user model);
        //返回总条数
        int GetRecordCount(base_user model);

        //List列表
        IList<base_user> getbase_userList(base_user model);
        //实体
        base_user QueryObject(base_user model);
        //新增
        bool Insert(base_user model);
        //更新
        bool Update(base_user model);
        //删除
        bool Delete(string DicsId);

        #endregion

        #region CRM/技术支持 按部门获取人员

        DataTable getCRMUserPageList(base_user model);
        //返回总条数
        int GetCRMUserCount(base_user model);

        #endregion


        #region  查看部门下的人员（好多部门ID）

        DataTable getMyDepartmentUserPageList(base_user model);


        #endregion
        bool UpdateUserinfoUrl(base_user model);
    }
}
