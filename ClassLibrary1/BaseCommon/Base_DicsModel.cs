using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class Base_DicsModel : BaseModel
    {
        public string DicsId { get; set; }
        public string DicCategoryId { get; set; }
        public string ParentId { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int? Sortnum { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
