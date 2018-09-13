using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_equipmentStatusmodel : BaseModel
    {

        //设备
        #region 获取/设置 字段值
    



        /// <summary>
        /// EquipmentId
        /// </summary>
        /// <returns></returns>
        public string EquipmentId { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }


        /// <summary>
        /// OrderNumber
        /// </summary>
        /// <returns></returns>
        public string OrderNumber { get; set; }


        /// <summary>
        /// Model
        /// </summary>
        /// <returns></returns>
        public string Model { get; set; }


        /// <summary>
        /// Type
        /// </summary>
        /// <returns></returns>
        public int? Type { get; set; }


        /// <summary>
        /// Power
        /// </summary>
        /// <returns></returns>
        public string Power { get; set; }


        /// <summary>
        /// Voltage
        /// </summary>
        /// <returns></returns>
        public string Voltage { get; set; }


        /// <summary>
        /// Language
        /// </summary>
        /// <returns></returns>
        public string Language { get; set; }


        /// <summary>
        /// Encryption
        /// </summary>
        /// <returns></returns>
        public string Encryption { get; set; }


        /// <summary>
        /// Region
        /// </summary>
        /// <returns></returns>
        public string Region { get; set; }


        /// <summary>
        /// Businesspeople
        /// </summary>
        /// <returns></returns>
        public string Businesspeople { get; set; }


        /// <summary>
        /// Warranty
        /// </summary>
        /// <returns></returns>
        public string Warranty { get; set; }


        /// <summary>
        /// LssueDate
        /// </summary>
        /// <returns></returns>
        public DateTime? LssueDate { get; set; }
        public DateTime? LssueDate_B { get; set; }
        public DateTime? LssueDate_E { get; set; }


        /// <summary>
        /// Phone
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }


        /// <summary>
        /// Picture
        /// </summary>
        /// <returns></returns>
        public string Picture { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Baidulng { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Baidulat { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 代理ID
        /// </summary>
        public string AgentUserId { get; set; }

        /// <summary>
        /// 系列ID
        /// </summary>
        public string Series { get; set; }

        #endregion

        public IList<cloud_equipmentstatus> cloud_equipmentstatusList { get; set; }

    }

}
