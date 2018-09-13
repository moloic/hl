using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{

    [Serializable]
    public class base_user : BaseModel
    {
        #region 获取/设置 字段值
        public base_user() { }



        /// <summary>
        /// UserId
        /// </summary>
        /// <returns></returns>
        public string UserId { get; set; }


        /// <summary>
        /// Spell
        /// </summary>
        /// <returns></returns>
        public string Spell { get; set; }


        /// <summary>
        /// Gender
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }


        /// <summary>
        /// Birthday
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        //public DateTime? Birthday_B { get; set; }
        //public DateTime? Birthday_E { get; set; }


        /// <summary>
        /// Mobile
        /// </summary>
        /// <returns></returns>
        public string Mobile { get; set; }


        /// <summary>
        /// Telephone
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }


        /// <summary>
        /// OICQ
        /// </summary>
        /// <returns></returns>
        public string OICQ { get; set; }


        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }


        /// <summary>
        /// ChangePasswordDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ChangePasswordDate { get; set; }
        //public DateTime? ChangePasswordDate_B { get; set; }
        //public DateTime? ChangePasswordDate_E { get; set; }


        /// <summary>
        /// OpenId
        /// </summary>
        /// <returns></returns>
        public int? OpenId { get; set; }


        /// <summary>
        /// LogOnCount
        /// </summary>
        /// <returns></returns>
        public int? LogOnCount { get; set; }


        /// <summary>
        /// CompanyId
        /// </summary>
        /// <returns></returns>
        public string CompanyId { get; set; }


        /// <summary>
        /// FirstVisit
        /// </summary>
        /// <returns></returns>
        public DateTime? FirstVisit { get; set; }
        //public DateTime? FirstVisit_B { get; set; }
        //public DateTime? FirstVisit_E { get; set; }


        /// <summary>
        /// PreviousVisit
        /// </summary>
        /// <returns></returns>
        public DateTime? PreviousVisit { get; set; }
        //public DateTime? PreviousVisit_B { get; set; }
        //public DateTime? PreviousVisit_E { get; set; }


        /// <summary>
        /// LastVisit
        /// </summary>
        /// <returns></returns>
        public DateTime? LastVisit { get; set; }
        //public DateTime? LastVisit_B { get; set; }
        //public DateTime? LastVisit_E { get; set; }


        /// <summary>
        /// AuditStatus
        /// </summary>
        /// <returns></returns>
        public string AuditStatus { get; set; }


        /// <summary>
        /// AuditUserId
        /// </summary>
        /// <returns></returns>
        public string AuditUserId { get; set; }


        /// <summary>
        /// AuditUserName
        /// </summary>
        /// <returns></returns>
        public string AuditUserName { get; set; }


        /// <summary>
        /// AuditDateTime
        /// </summary>
        /// <returns></returns>
        public DateTime? AuditDateTime { get; set; }
        //public DateTime? AuditDateTime_B { get; set; }
        //public DateTime? AuditDateTime_E { get; set; }


        /// <summary>
        /// Online
        /// </summary>
        /// <returns></returns>
        public int? Online { get; set; }


        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }


        /// <summary>
        /// Enabled
        /// </summary>
        /// <returns></returns>
        public int? Enabled { get; set; }


        /// <summary>
        /// DepartmentId
        /// </summary>
        /// <returns></returns>
        public string DepartmentId { get; set; }


        /// <summary>
        /// SortCode
        /// </summary>
        /// <returns></returns>
        public int? SortCode { get; set; }


        /// <summary>
        /// DeleteMark
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }


        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        //public DateTime? CreateDate_B { get; set; }
        //public DateTime? CreateDate_E { get; set; }


        /// <summary>
        /// CreateUserId
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }


        /// <summary>
        /// CreateUserName
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }


        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        //public DateTime? ModifyDate_B { get; set; }
        //public DateTime? ModifyDate_E { get; set; }


        /// <summary>
        /// ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }


        /// <summary>
        /// ModifyUserName
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }


        /// <summary>
        /// RoleId
        /// </summary>
        /// <returns></returns>
        public string RoleId { get; set; }


        /// <summary>
        /// Url
        /// </summary>
        /// <returns></returns>
        public string Url { get; set; }


        /// <summary>
        /// InnerUser
        /// </summary>
        /// <returns></returns>
        public int? InnerUser { get; set; }


        /// <summary>
        /// Code
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }


        /// <summary>
        /// Account
        /// </summary>
        /// <returns></returns>
        public string Account { get; set; }


        /// <summary>
        /// Password
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }


        /// <summary>
        /// Secretkey
        /// </summary>
        /// <returns></returns>
        public string Secretkey { get; set; }


        /// <summary>
        /// RealName
        /// </summary>
        /// <returns></returns>
        public string RealName { get; set; }


        /// <summary>
        /// FingerData
        /// </summary>
        /// <returns></returns>
        public string FingerData { get; set; }

        /// <summary>
        /// DepartmentName
        /// </summary>
        /// <returns></returns>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 路演id
        /// </summary>
        public string RoadShowId { get; set; }

        /// <summary>
        /// 路演组id
        /// </summary>
        public string RoadShowGroupId { get; set; }

        /// <summary>
        /// 路演项目Id
        /// </summary>
        public string ProjectId { get; set; }
        //密码
        public string CardNum { get; set; }
        //面值
        public string Facevalue { get; set; }
        //条数
        //public string txtCardCount { get; set; }
        ////之前条数
        //public int FrontCardCount { get; set; }

        public int? IsAgent { get; set; }
        public int? IsDomestic { get; set; }


        public int IsWork { get; set; }
        #endregion




    }
}