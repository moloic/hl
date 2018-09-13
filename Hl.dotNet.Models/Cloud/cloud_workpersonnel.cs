using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_workpersonnel : BaseModel
    {
        #region 获取/设置 字段值
        public cloud_workpersonnel() { }



        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// OrderId
        /// </summary>
        /// <returns></returns>
        public string OrderId { get; set; }


        /// <summary>
        /// UserId
        /// </summary>
        /// <returns></returns>
        public string UserId { get; set; }


        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        public DateTime? CreateDate_B { get; set; }
        public DateTime? CreateDate_E { get; set; }

        public int State { get; set; }

        #endregion




    }
}