using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class base_rolesModel
    {
        #region 获取/设置 字段值
        public base_rolesModel() { }



        /// <summary>
        /// RoleId
        /// </summary>
        /// <returns></returns>
        public string RoleId { get; set; }


        /// <summary>
        /// CompanyId
        /// </summary>
        /// <returns></returns>
        public string CompanyId { get; set; }


        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
        public string Category { get; set; }


        /// <summary>
        /// Code
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }


        /// <summary>
        /// FullName
        /// </summary>
        /// <returns></returns>
        public string FullName { get; set; }


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
        public DateTime? CreateDate_B { get; set; }
        public DateTime? CreateDate_E { get; set; }


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
        public DateTime? ModifyDate_B { get; set; }
        public DateTime? ModifyDate_E { get; set; }


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
        /// DepartmentId
        /// </summary>
        /// <returns></returns>
        public string DepartmentId { get; set; }


        public string EnabledName { get; set; }

        public string DicsFullName { get; set; }
        public string DepartmentFullName { get; set; }

        #endregion




    }
}