using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class Base_TreeModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 显示节点名称
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<Base_TreeModel> children { get; set; }
        public List<base_user> userlist { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string iconCls { get; set; }
        /// <summary>
        ///字典类别名
        /// </summary>
        //public string FullName { get; set; }//DicCategoryId
        /// <summary>
        ///字典类id
        /// </summary>
        public string DicCategoryId { get; set; }



    }
}
