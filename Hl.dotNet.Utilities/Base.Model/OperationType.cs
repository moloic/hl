using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Utilities
{
    public enum OperationType
    {
        /// <summary>
        /// 登陆
        /// </summary>
        Login = 0,
        /// <summary>
        /// 新增
        /// </summary>
        Add = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Update = 2,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 3,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 4,
        /// <summary>
        /// 访问
        /// </summary>
        Visit = 5,
        /// <summary>
        /// 离开
        /// </summary>
        Leave = 6,
        /// <summary>
        /// 查询
        /// </summary>
        Query = 7,
        /// <summary>
        /// 安全退出
        /// </summary>
        Exit = 8,
    }
}
