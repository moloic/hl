using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Description("字典类别管理")]
    [Serializable]
    public class base_diccategoryModel
    {
        #region 获取/设置 字段值
        public base_diccategoryModel() { }



        /// <summary>
        /// DicCategoryId
        /// </summary>
        /// <returns></returns>
        public string DicCategoryId { get; set; }


        /// <summary>
        /// FullName
        /// </summary>
        /// <returns></returns>
        public string FullName { get; set; }


        /// <summary>
        /// Code
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }


        /// <summary>
        /// Sortnum
        /// </summary>
        /// <returns></returns>
        public int? Sortnum { get; set; }


        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }


        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }



        /// <summary>
        /// ParentId
        /// </summary>
        /// <returns></returns>
        public string ParentId { get; set; }

        #endregion




    }
} 