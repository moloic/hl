using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class base_menuModel
    {
        #region 获取/设置 字段值
        public base_menuModel() { }
        public string id { get; set; }
        /// <summary>
        /// 显示节点名称
        /// </summary>
        public string text { get; set; }

        public string state { get; set; }

        public List<base_menuModel> children { get; set; }
        /// <summary>
        /// MenuId
        /// </summary>
        /// <returns></returns>
        public string MenuId { get; set; }

        public string Id { get; set; }
        /// <summary>
        /// MenuName
        /// </summary>
        /// <returns></returns>
        public string MenuName { get; set; }


        /// <summary>
        /// ParentMenuId
        /// </summary>
        /// <returns></returns>
        public string ParentMenuId { get; set; }


        /// <summary>
        /// url
        /// </summary>
        /// <returns></returns>
        public string url { get; set; }


        /// <summary>
        /// MenuOrder
        /// </summary>
        /// <returns></returns>
        public string MenuOrder { get; set; }


        /// <summary>
        /// Img
        /// </summary>
        /// <returns></returns>
        public string Img { get; set; }


        /// <summary>
        /// MenuType
        /// </summary>
        /// <returns></returns>
        public int? MenuType { get; set; }


        public string RoleId { get; set; }

        public string IsDeleted { get; set; }
        public string IsEnable { get; set; }
        public string OperateId { get; set; }
        public string LastOperateId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }







        #endregion




    }
}