using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class base_userrole
    {
        #region 获取/设置 字段值
        public base_userrole() { }



        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// UserId
        /// </summary>
        /// <returns></returns>
        public string UserId { get; set; }


        /// <summary>
        /// RoleId
        /// </summary>
        /// <returns></returns>
        public string RoleId { get; set; }

        #endregion




    }
}