using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class BaseModel
    {
        

        public string UserId { get; set; }

        /// <summary>
        /// 返回行号
        /// </summary>
        public int? Row_n
        {
            get;
            set;
        }


        /// <summary>
        /// 需要查询多少条数据
        /// </summary>
        public int? TopNums
        {
            get;
            set;
        }


        /// <summary>
        /// 总行数
        /// </summary>
        public int? TotalItems
        {
            get;
            set;
        }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            get;
            set;
        }


        /// <summary>
        /// 开始时间范围 ， 开始时间
        /// </summary>
        public DateTime? CreateTime_B
        {
            get;
            set;
        }


        /// <summary>
        /// 开始时间范围 ， 结束时间
        /// </summary>
        public DateTime? CreateTime_E
        {
            get;
            set;
        }





        /// <summary>
        /// 分页开始行数
        /// </summary>
        public int? PrevPageNums
        {
            get;
            set;
        }


        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsEnable
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? OperateId
        {
            get;
            set;
        }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastOperateId
        {
            get;
            set;
        }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdateTime
        {
            get;
            set;
        }


        /// <summary>
        /// 修改时间范围 ， 开始时间
        /// </summary>
        public DateTime? LastUpdateTime_B
        {
            get;
            set;
        }

        /// <summary>
        /// 修改时间范围 ， 结束时间
        /// </summary>
        public DateTime? LastUpdateTime_E
        {
            get;
            set;
        }


        /// <summary>
        /// 排序
        /// </summary>
        public string OrderStr
        {
            get;
            set;
        }

        /// <summary>
        /// id 列表 
        /// </summary>
        public IList<string> IdList { get; set; }



    }
}
