using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_userequipment : BaseModel
    {
        #region 获取/设置 字段值
        public cloud_userequipment() { }



        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// EquipmentId
        /// </summary>
        /// <returns></returns>
        public string EquipmentId { get; set; }


        /// <summary>
        /// UserId
        /// </summary>
        /// <returns></returns>
        public string UserId { get; set; }

        #endregion




    }
}