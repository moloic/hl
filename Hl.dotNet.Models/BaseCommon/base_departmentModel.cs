using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class base_departmentModel
    {
        #region 获取/设置 字段值
        public base_departmentModel() { }

        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 显示节点名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// DepartmentId
        /// </summary>
        /// <returns></returns>
        public string DepartmentId { get; set; }


        /// <summary>
        /// CompanyId
        /// </summary>
        /// <returns></returns>
        public string CompanyId { get; set; }


        /// <summary>
        /// ParentId
        /// </summary>
        /// <returns></returns>
        public string ParentId { get; set; }


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
        /// ShortName
        /// </summary>
        /// <returns></returns>
        public string ShortName { get; set; }


        /// <summary>
        /// Manager
        /// </summary>
        /// <returns></returns>
        public string Manager { get; set; }


        /// <summary>
        /// Phone
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }


        /// <summary>
        /// Fax
        /// </summary>
        /// <returns></returns>
        public string Fax { get; set; }


        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }


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

        public List<base_departmentModel> children { get; set; }


        #endregion




    }
}