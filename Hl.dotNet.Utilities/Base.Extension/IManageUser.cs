using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hl.dotNet.Utilities
{
    /// <summary>
    /// 管理用户接口
    /// </summary>
    public class IManageUser
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登陆账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Secretkey { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 对象用户关系Id,对象分类:1-部门2-角色3-岗位4-群组
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 录IP地址所在地址
        /// </summary>
        public string IPAddressName { get; set; }
        /// <summary>
        /// 是否系统账户；拥有所以权限
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 路演id
        /// </summary>
        public string RoadShowId { get; set; }

        /// <summary>
        /// 路演组id
        /// </summary>
        public string RoadShowGroupId { get; set; }
        /// <summary>
        /// 路演项目id
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public string Msg { get; set; }
        public string URL { get; set; }

        public string ReplayCookie { get; set; }
        public string JianMoCookie { get; set; }
        public string JianMoGroupCookie { get; set; }
        public string CardCookie { get; set; }
        //账户的创建者ID
        public string CreateUserId { get; set; }

        public int? IsAgent { get; set; }

        public int? IsDomestic { get; set; }

    }
}
