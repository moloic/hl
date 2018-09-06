using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class base_menubuttonsModel
    {
        #region 获取/设置 字段值
        public base_menubuttonsModel() { }



        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// menuId
        /// </summary>
        /// <returns></returns>
        public string menuId { get; set; }


        /// <summary>
        /// ButtonId
        /// </summary>
        /// <returns></returns>
        public string ButtonId { get; set; }


        /// <summary>
        /// Sortnum
        /// </summary>
        /// <returns></returns>
        public int? Sortnum { get; set; }

        public string ButtonText { get; set; }

        #endregion




    }
}