using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_equipmentcomponen : BaseModel
    {
        #region 获取/设置 字段值
        public cloud_equipmentcomponen() { }



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
        /// component
        /// </summary>
        /// <returns></returns>
        public string component { get; set; }

        #endregion




    }
}